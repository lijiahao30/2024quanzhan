
using System.Collections.ObjectModel;
using Mp3Library.Service;

public class SpotifyViewModel
{
    private readonly ISpotifyService _spotifyService;

    public ObservableCollection<Song> SpotifyPlaylists { get; private set; } = new();
    public SpotifyViewModel(ISpotifyService spotifyService)
    {
        _spotifyService = spotifyService;
    }

    public async Task LoadPlaylistsAsync()
    {
        try
        {
            var token = await _spotifyService.GetAccessTokenAsync();
            var playlists = await _spotifyService.GetUserPlaylistsAsync(token);
            // 假设从 Spotify API 获取的播放列表只包含名称
            SpotifyPlaylists.Clear();
            foreach (var playlistName in playlists)
            {
                SpotifyPlaylists.Add(new Song
                {
                    Title = playlistName,
                    Artist = "Spotify Playlist", // 可以设置为固定值
                    CoverImage = "default_playlist_cover.jpg", // 你可以用 Spotify 的 API 获取封面
                    Duration = 0, // 播放列表本身没有时长
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}