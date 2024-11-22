using System;
using Avalonia;
using Microsoft.Extensions.DependencyInjection;
using mp3.library.Services;
using mp3.library.ViewModels;
using mp3.service;

using MainWindowViewModel = mp3.library.ViewModels.MainWindowViewModel;

namespace mp3
{
    public class ServiceLocator
    {
        private readonly IServiceProvider _serviceProvider;
        private static ServiceLocator _current;

        public static ServiceLocator Current {
            get
            {
                if (_current is not null) {
                    return _current;
                }

                if (Application.Current.TryGetResource(nameof(ServiceLocator),
                        null, out var resource) &&
                    resource is ServiceLocator serviceLocator) {
                    return _current = serviceLocator;
                }

                throw new Exception("理论上来讲不应该发生这种情况。");
            }
        }

        public ServiceLocator()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IMusicService, MusicService>();
            serviceCollection.AddSingleton<IAudioPlayer, AudioPlayer>();
            serviceCollection.AddSingleton<Mp3PlayerViewModel>();
            serviceCollection.AddSingleton<MainWindowViewModel>();
            serviceCollection.AddSingleton<InitializationViewModel>();
            serviceCollection.AddSingleton<IAlertService, AlertService>();
            serviceCollection.AddSingleton<IRootNavigationService, RootNavigationService>();
            serviceCollection.AddSingleton<IMenuNavigationService, MenuNavigationService>();
            serviceCollection.AddSingleton<IContentNavigationService, ContentNavigationService>();
            serviceCollection.AddHttpClient();
            serviceCollection.AddSingleton<MainViewModel>();
            _serviceProvider = serviceCollection.BuildServiceProvider();
            

        }

        // 提供 ViewModel 的实例
        public Mp3PlayerViewModel Mp3PlayerViewModel =>
             _serviceProvider.GetRequiredService<Mp3PlayerViewModel>();
        public MainWindowViewModel MainWindowViewModel =>
        _serviceProvider.GetRequiredService<MainWindowViewModel>();
        public InitializationViewModel InitializationViewModel =>
        _serviceProvider.GetRequiredService<InitializationViewModel>();
        public MainViewModel MainViewModel =>
        _serviceProvider.GetRequiredService<MainViewModel>();
        
    }

   
}