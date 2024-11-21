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
            Stop(); // 停止任何正在播放的音频
            Dispose(); // 清理资源

            try
            {
                _waveOut = new WaveOutEvent();
                _audioFileReader = new AudioFileReader(fileUrl);

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

        public void Dispose()
        {
            _audioFileReader?.Dispose();
            _audioFileReader = null;

            _waveOut?.Dispose();
            _waveOut = null;
        }
    }
}