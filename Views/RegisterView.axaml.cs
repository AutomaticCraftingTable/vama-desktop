﻿using Avalonia.Interactivity;
using VamaDesktop.ViewModels;

namespace VamaDesktop.Views;

public partial class RegisterView : ViewControl<RegisterViewModel>
{
    public RegisterView() => InitializeComponent();

    private void GoLogin(object? sender, RoutedEventArgs e)
    {
        ViewModel.Router.GoTo<LoginViewModel>();
    }

    private void Register(object? sender, RoutedEventArgs e)
    {
        ViewModel.Register();
    }

    private void RegisterGoogle(object? sender, RoutedEventArgs e)
    {
        ViewModel.RegisterGoogle();
    }
}
