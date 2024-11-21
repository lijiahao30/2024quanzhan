using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace mp3.library.ViewModels;

public class SimpleViewModel : ViewModelBase
{
    public ICommand SimpleCommand { get; }

    public SimpleViewModel()
    {
        SimpleCommand = new RelayCommand(() => Console.WriteLine("Simple Command Executed"), () => true);
    }
}
