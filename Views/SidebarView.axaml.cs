using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.SimpleRouter;
using VamaDesktop.Controls;
using VamaDesktop.ViewModels;

namespace VamaDesktop.Views;

public partial class SidebarView : UserControl
{
    public static readonly StyledProperty<HistoryRouter<ViewModelBase>> RouterProperty =
        AvaloniaProperty.Register<SidebarView, HistoryRouter<ViewModelBase>>(nameof(Router));

    public HistoryRouter<ViewModelBase> Router
    {
        get => GetValue(RouterProperty);
        set => SetValue(RouterProperty, value);
    }

    public static readonly StyledProperty<int> IndexProperty = AvaloniaProperty.Register<SidebarView, int>(
        nameof(Index));

    public int Index
    {
        get => GetValue(IndexProperty);
        set => SetValue(IndexProperty, value);
    }

    public SidebarView() => InitializeComponent();

    private void GoUsers(object? sender, RoutedEventArgs e)
    {
        Router.GoTo<UsersViewModel>();
    }
}