using System;
using NAudio.Wave;

namespace mp3.library.Services
{
    public class AudioPlayer : IAudioPlayer, IDisposable
    {
        private IWavePlayer _waveOut;
        private AudioFileReader _audioFileReader;
        private bool _isPaused; // 用于标记当前是否为暂停状态

        public void Play(string fileUrl)
        {
            if (_isPaused && _waveOut != null && _audioFileReader != null)
            {
                // 如果当前是暂停状态，调用 Resume 方法
                Resume();
                return;
            }

            Stop();
            Dispose();

            try
            {
                _waveOut = new WaveOutEvent
                {
                    DesiredLatency = 300, // 缓冲区延迟 300ms
                    NumberOfBuffers = 3   // 缓冲区数量
                };

                _audioFileReader = new AudioFileReader(fileUrl);

                // 监听播放停止事件
                _waveOut.PlaybackStopped += (s, e) =>
                {
                    Console.WriteLine("Playback stopped.");
                    Dispose(); // 自动释放资源
                };

                _waveOut.Init(_audioFileReader);
                _waveOut.Play();
                _isPaused = false; // 标记为非暂停状态
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Play: {ex.Message}");
            }
        }

        public void Pause()
        {
            if (_waveOut != null && _waveOut.PlaybackState == PlaybackState.Playing)
            {
                _waveOut.Pause();
                _isPaused = true; // 标记为暂停状态
            }
        }

        public void Resume()
        {
            if (_waveOut != null && _waveOut.PlaybackState == PlaybackState.Paused)
            {
                _waveOut.Play();
                _isPaused = false; // 标记为非暂停状态
            }
        }

        public void Stop()
        {
            if (_waveOut != null && (_waveOut.PlaybackState == PlaybackState.Playing || _waveOut.PlaybackState == PlaybackState.Paused))
            {
                _waveOut.Stop();
                _isPaused = false; // 停止时清除暂停状态
            }
        }

        public TimeSpan GetDuration()
        {
            return _audioFileReader?.TotalTime ?? TimeSpan.Zero;
        }

        public TimeSpan GetCurrentTime()
        {
            return _audioFileReader?.CurrentTime ?? TimeSpan.Zero;
        }

        public void Seek(TimeSpan position)
        {
            if (_audioFileReader != null && position <= _audioFileReader.TotalTime)
            {
                _audioFileReader.CurrentTime = position;
            }
        }

        public float Volume
        {
            get => _audioFileReader?.Volume ?? 1.0f;
            set
            {
                if (_audioFileReader != null)
                {
                    _audioFileReader.Volume = value;
                }
            }
        }

        public void Dispose()
        {
            if (_waveOut != null)
            {
                _waveOut.Stop();
                _waveOut.Dispose();
                _waveOut = null;
            }

            if (_audioFileReader != null)
            {
                _audioFileReader.Dispose();
                _audioFileReader = null;
            }

            _isPaused = false; // 重置暂停状态
        }
    }
}
