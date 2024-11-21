using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using mp3.library.Models;
using mp3.library.Services;

namespace mp3.library.ViewModels
{
    public class Mp3PlayerViewModel : ViewModelBase
    {
        private readonly IMusicService _musicService;
        private readonly IAudioPlayer _audioPlayer;

       
        private string _searchQuery;

        public string SearchQuery
        {
            get => _searchQuery;
            set => SetProperty(ref _searchQuery, value);
        }

        public ObservableCollection<Song> Songs { get; } = new();

        private Song _selectedSong;

        public Song SelectedSong
        {
            get => _selectedSong;
            set => SetProperty(ref _selectedSong, value);
        }

        public ICommand SearchCommand { get; }

        public ICommand PlayCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand OnInitializedCommand { get; }

        private bool _isSearching;

        public bool IsSearching
        {
            get => _isSearching;
            set => SetProperty(ref _isSearching, value);
        }

        private bool _isPlaying;

        public bool IsPlaying
        {
            get => _isPlaying;
            set => SetProperty(ref _isPlaying, value);
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }
        public ICommand PlayNextCommand { get; }
        public ICommand PlayPreviousCommand { get; }
        public ICommand SelectedSongChangedCommand { get; }
        public Mp3PlayerViewModel(IMusicService musicService, IAudioPlayer audioPlayer)
        {
            _musicService = musicService;
            _audioPlayer = audioPlayer;

            // 初始化命令，确保 CanExecute 始终为 true
            SearchCommand = new AsyncRelayCommand(SearchSongsAsync);
            
            PlayNextCommand = new RelayCommand(PlayNextSong);
            PlayPreviousCommand = new RelayCommand(PlayPreviousSong);
            PlayCommand = new AsyncRelayCommand(PlaySongAsync);
            StopCommand = new RelayCommand(() =>
            {
                _audioPlayer.Stop(); // Call the external method to stop audio playback
                IsPlaying = false;   // Update the IsPlaying property to reflect the new state
            });

            SelectedSongChangedCommand = new AsyncRelayCommand(PlaySelectedSong);
            // 初始化的命令
            OnInitializedCommand = new RelayCommand(OnInitialized);
        }
      

        private void PlayNextSong()
        {
            if (Songs.Count == 0 || SelectedSong == null) return;

            var currentIndex = Songs.IndexOf(SelectedSong);
            var nextIndex = (currentIndex + 1) % Songs.Count; // 循环到第一首
            SelectedSong = Songs[nextIndex];
            PlaySongAsync(); // 播放下一首
        }
        private async Task PlaySelectedSong()
        {
            if (SelectedSong == null) return;

            IsPlaying = true;
            try
            {
                // 使用 await 异步调用方法，避免阻塞线程
                var url = await _musicService.GetSongUrlAsync(SelectedSong.id); 
                if (!string.IsNullOrWhiteSpace(url))
                {
                    _audioPlayer.Play(url); // 播放歌曲
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing song: {ex.Message}");
            }
            /*finally
            {
                IsPlaying = false;
            }*/
        }

        private void PlayPreviousSong()
        {
            if (Songs.Count == 0 || SelectedSong == null) return;

            var currentIndex = Songs.IndexOf(SelectedSong);
            var previousIndex = (currentIndex - 1 + Songs.Count) % Songs.Count; // 循环到最后一首
            SelectedSong = Songs[previousIndex];
            PlaySongAsync(); // 播放上一首
        }

        private void OnInitialized()
        {
            _isPlaying = false;
            Console.WriteLine("ViewModel Initialized");
            // 在应用启动时执行一些异步加载操作
        
        }
        private async Task SearchSongsAsync()
        {
            Console.WriteLine("Search Command Executed");
            if (string.IsNullOrWhiteSpace(SearchQuery)) return;

            IsSearching = true;
            try
            {
                Songs.Clear();
                var songs = await _musicService.SearchMusicAsync(SearchQuery); // 获取所有结果
                foreach (var song in songs)
                {
                    if (!Songs.Contains(song))
                    {
                        Songs.Add(song); // 添加每首歌曲到 ObservableCollection
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchSongsAsync: {ex.Message}");
            }
            finally
            {
                IsSearching = false;
            }
        }
        /*private async Task SearchSongsAsync()
        {
            Console.WriteLine("Search Command Executed");
            if (string.IsNullOrWhiteSpace(SearchQuery)) return;

            IsSearching = true;

            try
            {
                Songs.Clear();

                // 调用 AI 模型获取推荐歌曲
                var aiRecommendedSong = await GetAiRecommendedSong(SearchQuery);
                if (string.IsNullOrEmpty(aiRecommendedSong))
                {
                    Console.WriteLine("AI did not return a valid song recommendation.");
                    return;
                }

                Console.WriteLine($"AI Recommended Song: {aiRecommendedSong}");

                // 使用推荐歌曲名进行搜索
                var songs = await _musicService.SearchMusicAsync(aiRecommendedSong);
                foreach (var song in songs)
                {
                    if (!Songs.Contains(song))
                    {
                        Songs.Add(song); // 添加每首歌曲到 ObservableCollection
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchSongsAsync: {ex.Message}");
            }
            finally
            {
                IsSearching = false;
            }
        }*/

        private async Task<string> GetAiRecommendedSong(string userInput)
        {
            try
            {
                var apiUrl = "https://spark-api-open.xf-yun.com/v1/chat/completions";
                var requestData = new
                {
                    max_tokens = 4096,
                    top_k = 4,
                    temperature = 0.5,
                    messages = new[]
                    {
                        new { role = "system", content = "你是一个为00后服务歌曲推荐专家..." },
                        new { role = "user", content = userInput }
                    },
                    model = "generalv3.5",
                    stream = false
                };

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer fbbJIHxksZqkqdMCOZKy:eDwFUXOuqfdKeXdVOUuR");

                var response = await httpClient.PostAsJsonAsync(apiUrl, requestData);

                // 确保成功响应
                response.EnsureSuccessStatusCode();

                // 读取并明确使用 UTF-8 编码
                var responseContent = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonDocument.Parse(responseContent);

                // 解析歌曲名
                var songName = jsonResponse.RootElement.GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

                return songName?.Trim(); // 返回推荐的歌曲名
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAiRecommendedSong: {ex.Message}");
                return string.Empty;
            }
        }

        private async Task PlaySongAsync()
        {
            Console.WriteLine("Play Command Executed");
            if (SelectedSong == null) return;

            IsPlaying = true;
            try
            {
                var url = await _musicService.GetSongUrlAsync(SelectedSong.id);
                if (!string.IsNullOrWhiteSpace(url))
                {
                    _audioPlayer.Play(url);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PlaySongAsync: {ex.Message}");
            }
          
        }



    }
}
