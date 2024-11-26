using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;
using mp3.library.Models;

using mp3.library.Services;

namespace mp3.library.ViewModels
{
   public class Mp3PlayerViewModel : ViewModelBase
{
    private readonly IMusicService _musicService;
    private readonly IAudioPlayer _audioPlayer;
    private readonly ImageService _imageService;
    private readonly IAlertService _alertService;
    public ICommand SelectedSongChangedCommand { get; }
    private string _searchQuery;
    public string SearchQuery
    {
        get => _searchQuery;
        set => SetProperty(ref _searchQuery, value);
    }
    private async Task PlaySelectedSong()
    {
        if (SelectedSong == null) return;

        // 如果当前正在播放同一首歌曲
        if (IsPlaying && !_isPaused && _audioPlayer.GetCurrentTime() > TimeSpan.Zero)
        {
            // 暂停播放
            StopRotation();
            _audioPlayer.Pause();
            IsPlaying = false;
            _isPaused = true;
            return;
        }

        // 如果当前是暂停状态，并且是同一首歌
        if (_isPaused && SelectedSong != null)
        {
            // 恢复播放
            _audioPlayer.Resume();
            StartRotation();
            IsPlaying = true;
            _isPaused = false;
            return;
        }

        // 如果播放的是新歌
        try
        {
            // 停止当前播放，清理状态
            StopPlayback();
            StopRotation();
            // 获取歌曲播放 URL
            var url = await _musicService.GetSongUrlAsync(SelectedSong.id);
            if (string.IsNullOrWhiteSpace(url)) return;

            // 播放新歌曲
            _audioPlayer.Play(url);
            StartRotation();
            IsPlaying = true;
            _isPaused = false;

            // 更新总时长
            TotalDuration = _audioPlayer.GetDuration();

            // 启动播放进度更新计时器
            StartProgressTimer();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in PlaySelectedSong: {ex.Message}");
        }
    }

    private double _currentProgress;
    private TimeSpan _currentTime;
    private TimeSpan _totalDuration;

    public double CurrentProgress
    {
        get => _currentProgress;
        set
        {
            if (Math.Abs(_currentProgress - value) > 0.01 && SetProperty(ref _currentProgress, value))
            {
                if (!_isUpdatingFromPlayback)
                {
                    var newPosition = TimeSpan.FromSeconds(value * TotalDuration.TotalSeconds);
                    _audioPlayer.Seek(newPosition);
                }
            }
        }
    }

    private bool _isUpdatingFromPlayback;
    public TimeSpan CurrentTime
    {
        get => _currentTime;
        set => SetProperty(ref _currentTime, value);
    }

    public TimeSpan TotalDuration
    {
        get => _totalDuration;
        set => SetProperty(ref _totalDuration, value);
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
    public ICommand PlayNextCommand { get; }
    public ICommand PlayPreviousCommand { get; }
    private ICommand OnInitializedCommand { get; }
    public async Task InitializeAsync()
    {
        try
        {
            // 初始化时根据“今日推荐”搜索获取歌曲数据
            var searchQuery = "今日推荐"; // 这里可以根据你的需求动态设置搜索词
            var songs = await _musicService.SearchMusicAsync(searchQuery);

            if (songs != null && songs.Any())
            {
                // 将推荐的歌曲添加到 Songs 集合中
                Songs.Clear();
                foreach (var song in songs)
                {
                    Songs.Add(song);
                    var songDetails = await _musicService.GetSongDetailAsync(song.id);
                    if (songDetails != null)
                    {
                        song.album.picUrl = songDetails.album.picUrl;
                        song.AlbumImageBytes = await _imageService.DownloadImageAsync(song.album.picUrl);
                    }
                }
            }
            else
            {
                await _alertService.AlertAsync("初始化失败", "加载数据时出现问题，请稍后重试。");
            }
        }
        catch (Exception ex)
        {
            // 异常提示
            await _alertService.AlertAsync("错误", $"发生错误: {ex.Message}");
        }
    }
    private bool _isSearching;
    public bool IsSearching
    {
        get => _isSearching;
        set => SetProperty(ref _isSearching, value);
    }
    private double _rotateAngle;
    public double RotateAngle
    {
        get => _rotateAngle;
        set => SetProperty(ref _rotateAngle, value);
    }

    private DispatcherTimer _rotationTimer;

    private void StartRotation()
    {
        if (_rotationTimer == null)
        {
            _rotationTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(30) // 每 30ms 更新一次
            };

            _rotationTimer.Tick += (s, e) =>
            {
                RotateAngle = (RotateAngle + 3) % 360; // 每次增加 3 度，形成平滑旋转
            };
        }

        _rotationTimer.Start();
    }

    private void StopRotation()
    {
        _rotationTimer?.Stop();
    }

    private bool _isPlaying;
    public bool IsPlaying
    {
        get => _isPlaying;
        set => SetProperty(ref _isPlaying, value);
    }

    private bool _isPaused; // 用于标记当前是否处于暂停状态

    public Mp3PlayerViewModel(IMusicService musicService, IAudioPlayer audioPlayer, ImageService imageService)
    {
        _musicService = musicService;
        _audioPlayer = audioPlayer;
        _imageService = imageService;

        // 初始化命令
        SearchCommand = new AsyncRelayCommand(SearchSongsAsync);
        PlayCommand = new RelayCommand(TogglePlayPause);
        StopCommand = new RelayCommand(StopPlayback);
        PlayNextCommand = new RelayCommand(PlayNextSong);
        PlayPreviousCommand = new RelayCommand(PlayPreviousSong);
        SelectedSongChangedCommand = new AsyncRelayCommand(PlaySelectedSong);
        OnInitializedCommand = new AsyncRelayCommand(InitializeAsync);

    }

    private void TogglePlayPause()
    {
        if (IsPlaying)
        {
            if (_isPaused)
            {
                // 如果是暂停状态，继续播放
                _audioPlayer.Resume();
                _isPaused = false;
                StartRotation(); // 启动旋转
            }
            else
            {
                // 如果正在播放，暂停
                _audioPlayer.Pause();
                _isPaused = true;
                StopRotation(); // 停止旋转
            }
        }
        else
        {
            // 如果没有播放，开始播放选中的歌曲
            _ = PlaySongAsync();
            StartRotation(); // 启动旋转
        }

        // 更新 UI 状态
        IsPlaying = !_isPaused;
    }
    private DispatcherTimer _progressTimer;
    private void StopPlayback()
    {
        _audioPlayer.Pause();
        IsPlaying = false;
        _isPaused = false;
        // 停止旋转
        StopRotation();
        // 停止计时器
        _progressTimer?.Stop();
    }

    private async Task PlaySongAsync()
    {
        if (SelectedSong == null) return;

        StopPlayback(); // 停止当前播放
        StopRotation();

        try
        {
            var url = await _musicService.GetSongUrlAsync(SelectedSong.id);
            if (string.IsNullOrWhiteSpace(url)) return;

            _audioPlayer.Play(url);
            StartRotation();
            IsPlaying = true;
            _isPaused = false;

            // 更新总时长
            TotalDuration = _audioPlayer.GetDuration();

            // 开启计时器
            StartProgressTimer();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in PlaySongAsync: {ex.Message}");
        }
    }

    private void StartProgressTimer()
    {
        _progressTimer?.Stop();

        _progressTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(1000)
        };

        _progressTimer.Tick += UpdateProgress;
        _progressTimer.Start();
    }

    private void UpdateProgress(object sender, EventArgs args)
    {
        if (!IsPlaying || _isPaused) return;

        try
        {
            _isUpdatingFromPlayback = true;
            var currentTime = _audioPlayer.GetCurrentTime();
            CurrentTime = currentTime;
            CurrentProgress = TotalDuration.TotalSeconds > 0
                ? currentTime.TotalSeconds / TotalDuration.TotalSeconds
                : 0;

            if (currentTime >= TotalDuration)
            {
                OnPlaybackCompleted();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in UpdateProgress: {ex.Message}");
        }
        finally
        {
            _isUpdatingFromPlayback = false;
        }
    }

    private void OnPlaybackCompleted()
    {
        _progressTimer?.Stop();
        IsPlaying = false;
        _isPaused = false;
        PlayNextSong();
    }

    private void PlayNextSong()
    {
        if (Songs.Count == 0 || SelectedSong == null) return;

        var currentIndex = Songs.IndexOf(SelectedSong);
        if (currentIndex == -1) return;

        var nextIndex = (currentIndex + 1) % Songs.Count;
        SelectedSong = Songs[nextIndex];
        _ = PlaySongAsync();
    }

    private void PlayPreviousSong()
    {
        if (Songs.Count == 0 || SelectedSong == null) return;

        var currentIndex = Songs.IndexOf(SelectedSong);
        if (currentIndex == -1) return;

        var previousIndex = (currentIndex - 1 + Songs.Count) % Songs.Count;
        SelectedSong = Songs[previousIndex];
        _ = PlaySongAsync();
    }

    private async Task SearchSongsAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery)) return;

        IsSearching = true;
        try
        {
            Songs.Clear();
            var songs = await _musicService.SearchMusicAsync(SearchQuery);

            foreach (var song in songs)
            {
                Songs.Add(song);
                var songDetails = await _musicService.GetSongDetailAsync(song.id);
                if (songDetails != null)
                {
                    song.album.picUrl = songDetails.album.picUrl;
                    song.AlbumImageBytes = await _imageService.DownloadImageAsync(song.album.picUrl);
                }
            }
        }
        finally
        {
            IsSearching = false;
        }
    }
}

}
