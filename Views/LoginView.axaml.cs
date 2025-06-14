using Avalonia.Interactivity;
using VamaDesktop.ViewModels;

namespace VamaDesktop.Views;

public partial class LoginView : ViewControl<LoginViewModel>
{
    public LoginView() => InitializeComponent();
    
    private void GoRegister(object? sender, RoutedEventArgs e)
    {
        ViewModel.Router.GoTo<RegisterViewModel>();
    }
    
    private void Login(object? sender, RoutedEventArgs e)
    {
        ViewModel.Login();
    }

    private void LoginGoogle(object? sender, RoutedEventArgs e)
    {
        ViewModel.LoginGoogle();
    }
}
