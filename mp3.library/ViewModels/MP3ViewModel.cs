using System.Collections.ObjectModel;
using System.Threading.Tasks;
using mp3.ViewModels;

namespace Mp3Library
{
    public class MP3ViewModel : ViewModelBase
    {
        private readonly MP3Service _mp3Service;
        private ObservableCollection<string> _mp3Files;
        private string _directory;

        public ObservableCollection<string> MP3Files
        {
            get => _mp3Files;
            set => SetProperty(ref _mp3Files, value);
        }

        public string Directory
        {
            get => _directory;
            set
            {
                if (SetProperty(ref _directory, value))
                {
                    LoadMP3Files();
                }
            }
        }

        public MP3ViewModel(MP3Service mp3Service)
        {
            _mp3Service = mp3Service;
            _mp3Files = new ObservableCollection<string>();
        }

        public async void LoadMP3Files()
        {
            if (string.IsNullOrEmpty(Directory)) return;

            try
            {
                var files = await Task.Run(() => _mp3Service.GetMP3Files(Directory));
                MP3Files.Clear();
                foreach (var file in files)
                {
                    MP3Files.Add(file);
                }
            }
            catch (Exception ex)
            {
                // Handle errors (e.g., directory not found)
            }
        }
    }
}