

namespace mp3.library.Services
{
    public interface IAudioPlayer
    {
        /// <summary>
        /// 播放音频文件
        /// </summary>
        /// <param name="fileUrl">音频文件的 URL 或本地路径</param>
        void Play(string fileUrl);
        void Pause(); // 新增
        void Resume(); // 新增
        /// <summary>
        /// 停止播放音频
        /// </summary>
        void Stop();
        TimeSpan GetDuration(); // 获取音频总时长
        TimeSpan GetCurrentTime(); // 获取当前播放时间
        void Seek(TimeSpan position); // 设置播放位置
    }
}
