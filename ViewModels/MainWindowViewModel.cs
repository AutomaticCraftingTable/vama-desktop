using System.Reactive;
using ReactiveUI;

namespace VamaDesktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _currentView = new RegisterViewModel();
    public ViewModelBase CurrentView
    {
        get => _currentView;
        set => this.RaiseAndSetIfChanged(ref _currentView, value);
    }

    public ReactiveCommand<Unit, ViewModelBase> ShowRegister { get; }
    public ReactiveCommand<Unit, ViewModelBase> ShowLogin { get; }
    
    public MainWindowViewModel()
    {
        ShowRegister = ReactiveCommand.Create(() => CurrentView = new RegisterViewModel());;
        ShowLogin = ReactiveCommand.Create(() => CurrentView = new LoginViewModel());
    }

}