using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using VamaDesktop.ViewModels;

namespace VamaDesktop.Views;

public partial class LoadingView : ViewControl<RegisterViewModel>
{
    public LoadingView() => InitializeComponent();
}