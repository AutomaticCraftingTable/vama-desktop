using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.SimpleRouter;
using DotNetEnv;
using Flurl.Http;
using Microsoft.Extensions.DependencyInjection;
using VamaDesktop.API;
using VamaDesktop.ViewModels;
using VamaDesktop.Views;

namespace VamaDesktop;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        IServiceProvider services = ConfigureServices();
        var mainViewModel = services.GetRequiredService<MainViewModel>();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainWindow
            {
                DataContext = mainViewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddSingleton<HistoryRouter<ViewModelBase>>(s =>
            new HistoryRouter<ViewModelBase>(t => (ViewModelBase)s.GetRequiredService(t)));

        services.AddSingleton<MainViewModel>();
        services.AddTransient<RegisterViewModel>();
        services.AddTransient<LoginViewModel>();
        services.AddTransient<AdminPanelViewModel>();
        return services.BuildServiceProvider();
    }
}