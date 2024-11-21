using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using mp3.library.Services;

namespace mp3.library.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _content;
    private IRootNavigationService _rootNavigationService;
    private IMenuNavigationService _menuNavigationService;
  

    public MainWindowViewModel(IRootNavigationService rootNavigationService
        , IMenuNavigationService menuNavigationService)
    {
        _rootNavigationService = rootNavigationService;
       
        _menuNavigationService = menuNavigationService;
      

        OnInitializedCommand = new RelayCommand(OnInitialized);
    }

    public ViewModelBase Content
    {
        get => _content;
        set => SetProperty(ref _content, value);
    }

    public ICommand OnInitializedCommand { get; }

    public void OnInitialized()
    {
       
            _rootNavigationService.NavigateTo(RootNavigationConstant
                .InitializationView);
            _rootNavigationService.NavigateTo(RootNavigationConstant.MainView);
            _menuNavigationService.NavigateTo(MenuNavigationConstant.Mp3PlayerView);
       
    }
}