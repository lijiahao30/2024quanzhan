using CommunityToolkit.Mvvm.ComponentModel;

namespace mp3.library.ViewModels;
    public class ViewModelBase : ObservableObject
    {
        public virtual void SetParameter(object parameter) { }
    }
