using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using VamaDesktop.ViewModels;

namespace VamaDesktop.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        this.AttachDevTools();
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}