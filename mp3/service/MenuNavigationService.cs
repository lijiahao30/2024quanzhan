using System;
using mp3.library.Services;
using mp3.library.ViewModels;

namespace mp3.service;

public class MenuNavigationService : IMenuNavigationService {
    public void NavigateTo(string view) {
        ViewModelBase viewModel = view switch {
           
            MenuNavigationConstant.Mp3PlayerView=>ServiceLocator.Current
                .Mp3PlayerViewModel,
            MenuNavigationConstant.DiaryView=>ServiceLocator.Current
                .DiaryViewModel,
            _ => throw new Exception("未知的视图。")
        };

        ServiceLocator.Current.MainViewModel.SetMenuAndContent(view, viewModel);
    }
}