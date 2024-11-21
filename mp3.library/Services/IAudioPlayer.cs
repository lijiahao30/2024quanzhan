

namespace mp3.library.Services
{
    public interface IAudioPlayer
    {
        /// <summary>
        /// 播放音频文件
        /// </summary>
        /// <param name="fileUrl">音频文件的 URL 或本地路径</param>
        void Play(string fileUrl);

        /// <summary>
        /// 停止播放音频
        /// </summary>
        void Stop();
    }
}
