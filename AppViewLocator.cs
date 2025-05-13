using System;
using ReactiveUI;
using VamaDesktop.ViewModels;
using VamaDesktop.Views;

namespace VamaDesktop
{
    public class AppViewLocator : ReactiveUI.IViewLocator
    {
        public IViewFor ResolveView<T>(T? viewModel, string? contract = null) => viewModel switch
        {
            RegisterViewModel context => new RegisterView { DataContext = context },
            _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
        };
    }
}