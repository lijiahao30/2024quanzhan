using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;

using mp3.Views;
using Projektanker.Icons.Avalonia;
using Projektanker.Icons.Avalonia.FontAwesome;

namespace mp3;

public partial class App : Application
{
    public override void Initialize()
    {   // 注册 FontAwesome 图标提供程序
        IconProvider.Current.Register<FontAwesomeIconProvider>();
        
        AvaloniaXamlLoader.Load(this);
        
      
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
         

            desktop.MainWindow = new MainWindow
            {
          
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}