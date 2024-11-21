using System;
using mp3.library.Services;

namespace mp3.service;

public class RootNavigationService : IRootNavigationService

{
    
    //给MainWindowViewModel赋值
    public void NavigateTo(string view) {
        
        ServiceLocator.Current.MainWindowViewModel.Content = view switch {
            RootNavigationConstant.InitializationView => ServiceLocator.Current
                .InitializationViewModel,
            RootNavigationConstant.MainView => ServiceLocator.Current
                .MainViewModel,
           
            _ => throw new Exception("未知的视图。")
        };
    }
}