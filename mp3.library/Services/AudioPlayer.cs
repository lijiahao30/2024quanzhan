using System;
using NAudio.Wave;

namespace mp3.library.Services
{
    public class AudioPlayer : IAudioPlayer, IDisposable
    {
        private IWavePlayer _waveOut;
        private AudioFileReader _audioFileReader;

        public void Play(string fileUrl)
        {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Play: {ex.Message}");
            }
        }

        public void Stop()
        {
            if (_waveOut != null && _waveOut.PlaybackState == PlaybackState.Playing)
            {
                _waveOut.Stop();
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
        }
    }
}
