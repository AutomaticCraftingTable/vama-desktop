using Avalonia.SimpleRouter;
using CommunityToolkit.Mvvm.ComponentModel;

namespace VamaDesktop.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public bool IsLoggedIn { get; set; }
       
    [ObservableProperty]
    private ViewModelBase _content = default!;

    public MainViewModel(HistoryRouter<ViewModelBase> router)
    {
        IsLoggedIn = false;
        router.CurrentViewModelChanged += viewModel => Content = viewModel;
        router.GoTo<RegisterViewModel>();
    }
}
