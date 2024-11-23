namespace mp3.library.Services;

public class ImageService {
    private static readonly HttpClient _httpClient = new();

    public async Task<byte[]> DownloadImageAsync(string url) {
        if (string.IsNullOrEmpty(url)) {
            throw new ArgumentException("URL不能为空", nameof(url));
        }

        try {
            return await _httpClient.GetByteArrayAsync(url);
        } catch (Exception ex) {
            Console.WriteLine($"下载图片失败: {ex.Message}");
            return null;
        }
    }
}