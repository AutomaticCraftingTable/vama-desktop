using Avalonia;
using System;
using Akavache;

namespace VamaDesktop;

sealed class Program
{
    [STAThread]
    public static void Main(string[] args) {
        BlobCache.ApplicationName = nameof(VamaDesktop);
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
