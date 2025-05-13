using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using ReactiveUI;
using VamaDesktop.ViewModels;

namespace VamaDesktop.Controls;

public class Sidebar : TemplatedControl
{
    public RoutingState Router { get; } = new();
    
    int selectedIndex = -1;

    ReactiveCommand<Unit, IRoutableViewModel>  goPage1;

    Sidebar()
    {
        goPage1 = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new RegisterViewModel(screen)));
    }
    


    // void goPage2 = ReactiveCommand.CreateFromObservable(
    //     () => Router.Navigate.Execute(new RegisterViewModel(screen))
    // );
    // void goPage3
    // void goPage4
    // void goPage5
    // void goPage6
    // void goPage7
    // void goPage8
    // void goPage9
}