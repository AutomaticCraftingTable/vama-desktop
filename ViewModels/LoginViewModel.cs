using System;
using ReactiveUI;

namespace VamaDesktop.ViewModels;

public class LoginViewModel(IScreen screen) : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
    public IScreen HostScreen { get; } = screen;
}