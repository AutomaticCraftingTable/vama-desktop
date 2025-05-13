using System.Reactive;
using ReactiveUI;

namespace VamaDesktop.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen
{
    public RoutingState Router { get; } = new();
    public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GoBack => Router.NavigateBack;
    
    public MainWindowViewModel()
    {
        GoNext = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new RegisterViewModel(this))
        );
    }
}
