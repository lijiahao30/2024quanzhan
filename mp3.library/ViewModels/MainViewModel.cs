using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using mp3.library.Services;

namespace mp3.library.ViewModels;

public class MainViewModel: ViewModelBase

{
    private readonly IMenuNavigationService _menuNavigationService;

    public MainViewModel(IMenuNavigationService menuNavigationService)
    {
        _menuNavigationService = menuNavigationService;
        GoBackCommand = new RelayCommand(GoBack);
        OpenPaneCommand= new RelayCommand(OpenPane);
        ClosePaneCommand = new RelayCommand(ClosePane);
        OnMenuTappedCommand = new RelayCommand(OnMenuTapped);
    }
   
    private string _title = "DailyPoetryA";

    public string Title {
        get => _title;
        private set => SetProperty(ref _title, value);
    }
    
    public ObservableCollection<ViewModelBase> ContentStack { get; } = [];
    private ViewModelBase _content;
    private bool _isPaneOpen;
    
    public bool IsPaneOpen {
        get => _isPaneOpen;
        private set => SetProperty(ref _isPaneOpen, value);
    }
    public ICommand OpenPaneCommand { get; }

    public void OpenPane() => IsPaneOpen = true;

    public ICommand ClosePaneCommand { get; }

    public void ClosePane() => IsPaneOpen = false;
    
    public ViewModelBase Content {
        get => _content;
       private set => SetProperty(ref _content, value);
    }
    public void PushContent(ViewModelBase content) =>
        ContentStack.Insert(0, Content = content);
    public void SetMenuAndContent(string view, ViewModelBase content) {
        ContentStack.Clear();
        PushContent(content);
        SelectedMenuItem =
            MenuItem.MenuItems.FirstOrDefault(p => p.View == view);
        Title = SelectedMenuItem.Name;
        IsPaneOpen = false;
    }
    private MenuItem _selectedMenuItem;

    public MenuItem SelectedMenuItem {
        get => _selectedMenuItem;
        set => SetProperty(ref _selectedMenuItem, value);
    }
    
    public void GoBack() {
        if (ContentStack.Count <= 1) {
            return;
        }

        ContentStack.RemoveAt(0);
        Content = ContentStack[0];
    }
    public ICommand GoBackCommand { get; }
    public ICommand OnMenuTappedCommand { get; }

    public void OnMenuTapped() {
        if (SelectedMenuItem is null) {
            return;
        }

        _menuNavigationService.NavigateTo(SelectedMenuItem.View);
    }

}

public class MenuItem {
    public string View { get; private init; }
    public string Name { get; private init; }

    private MenuItem() { }

    private static MenuItem Mp3PlayerView =>
        new() { Name = "今日推荐歌曲", View = MenuNavigationConstant.Mp3PlayerView };

   

    public static IEnumerable<MenuItem> MenuItems { get; } = [
        Mp3PlayerView
    ];
}