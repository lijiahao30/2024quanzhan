using Mp3Library.Service;

namespace mp3.library.ViewModels;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

public class MusicSearchViewModel : INotifyPropertyChanged
{
    private readonly MusicService _musicService;

    private string _searchQuery = string.Empty;
    private bool _isLoading;
    private string _statusMessage = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    public MusicSearchViewModel()
    {
        _musicService = new MusicService();

        SearchCommand = new AsyncRelayCommand(SearchMusicAsync);
    }

    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            _searchQuery = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Music> MusicList { get; set; } = new();

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged();
        }
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set
        {
            _statusMessage = value;
            OnPropertyChanged();
        }
    }

    public ICommand SearchCommand { get; }

    private async Task SearchMusicAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery))
        {
            StatusMessage = "请输入搜索关键字。";
            return;
        }

        try
        {
            IsLoading = true;
            StatusMessage = "加载中...";

            var result = await _musicService.SearchMusicAsync(SearchQuery);

            MusicList.Clear();

            foreach (var music in result)
            {
                MusicList.Add(music);
            }

            StatusMessage = result.Count > 0 ? "加载完成！" : "未找到相关歌曲。";
        }
        catch (Exception ex)
        {
            StatusMessage = $"加载失败: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
        }
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

