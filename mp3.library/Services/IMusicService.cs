using System.Threading.Tasks;
using mp3.library.Models;


namespace mp3.library.Services
{
    public interface IMusicService
    {
        Task<List<Song>> SearchMusicAsync(string query);
        Task<string> GetSongUrlAsync(string songId);
    }
}