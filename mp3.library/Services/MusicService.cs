using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using mp3.library.Models;
using System.Globalization;
using System.Text.Json;


namespace mp3.library.Services
{
    public class MusicService : IMusicService
    {
        private readonly HttpClient _httpClient;

        public MusicService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            Console.WriteLine("HttpClient successfully injected in MusicService.");
        }
        public async Task<List<Song>> SearchMusicAsync(string query)
        {
            try
            {
                var url = $"https://music.163.com/api/search/get/web?csrf_token=hlpretag=&hlposttag=&s={WebUtility.UrlEncode(query)}&type=1&offset=0&total=true&limit=10";
                var response = await _httpClient.GetStringAsync(url);

                // 解析 JSON 为 SearchResult 对象
                var searchResult = JsonConvert.DeserializeObject<SearchResult>(response);
                return searchResult?.result?.songs?.ToList() ?? new List<Song>(); // 返回歌曲列表
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchMusicAsync: {ex.Message}");
                return new List<Song>(); // 返回空列表以防止异常
            }
        }
        public async Task<Song> GetSongDetailAsync(string songId)
        {
            try
            {
                // 构造获取歌曲详情的 URL
                var url = $"http://music.163.com/api/song/detail/?id={songId}&ids=%5B{songId}%5D";
                var response = await _httpClient.GetStringAsync(url);

                // 解析 JSON 为 SongDetailResponse 对象
                var songDetailResponse = JsonConvert.DeserializeObject<SongDetailResponse>(response);

                // 提取歌曲信息并返回
                var song = songDetailResponse?.songs?.FirstOrDefault();
                if (song != null)
                {
                    Console.WriteLine($"Successfully retrieved song details for ID {songId}: {song.name}");
                }
                return song; // 返回包含详细信息的 Song 对象
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetSongDetailAsync: {ex.Message}");
                return null; // 返回 null 以防止异常
            }
        }


        public async Task<string> GetSongUrlAsync(string songId)
        {
            try
            {
                var url = $"https://music.163.com/api/song/enhance/player/url?id={songId}&ids=%5B{songId}%5D&br=192000";
                var response = await _httpClient.GetStringAsync(url);

                // 解析 JSON 为 SongUrlResponse 对象
                var songUrlResponse = JsonConvert.DeserializeObject<SongUrlResponse>(response);
                return songUrlResponse?.data?.FirstOrDefault()?.url;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetSongUrlAsync: {ex.Message}");
                return null; // 或者抛出自定义异常
            }
        }
    }
}