using System;
using mp3.library.Services;
using mp3.library.ViewModels;

namespace mp3.service;

public class ContentNavigationService : IContentNavigationService {
    public void NavigateTo(string view, object parameter = null) {
        ViewModelBase viewModel = view switch {
            ContentNavigationConstant.Mp3PlayerView => ServiceLocator.Current
                .Mp3PlayerViewModel,
          
            _ => throw new Exception("未知的视图。")
        };
        viewModel.SetParameter(parameter);
        ServiceLocator.Current.MainViewModel.PushContent(viewModel);
    }
}