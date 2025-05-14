using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.SimpleRouter;
using Microsoft.Extensions.DependencyInjection;
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
        // In this example we use Microsoft DependencyInjection (instead of ReactiveUI / Splat)
        // Splat would also work, just use the according methods
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
        // Add the HistoryRouter as a service
        services.AddSingleton<HistoryRouter<ViewModelBase>>(s =>
            new HistoryRouter<ViewModelBase>(t => (ViewModelBase)s.GetRequiredService(t)));

        // Add the ViewModels as a service (Main as singleton, others as transient)
        // services.AddTransient<HomeViewModel>();
        services.AddSingleton<MainViewModel>();
        services.AddTransient<RegisterViewModel>();
        return services.BuildServiceProvider();
    }
}