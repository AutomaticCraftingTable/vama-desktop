using Avalonia.SimpleRouter;
using CommunityToolkit.Mvvm.ComponentModel;
using Flurl.Http;
using VamaDesktop.API.DTO.Models.Success;
using VamaDesktop.API.Utils;

namespace VamaDesktop.ViewModels;

public partial class MainViewModel : RoutedModelBase
{
    [ObservableProperty] private ViewModelBase _content = default!;

    public MainViewModel(HistoryRouter<ViewModelBase> router) : base(router)
    {
        Content = new LoadingViewModel(router);
        Router.CurrentViewModelChanged += viewModel => Content = viewModel;
     
        TryRecoverSession();
    }

    public void TryRecoverSession()
    {
        var requset = new DeprecatedRequestClient<AuthResponse, object>(
            async client => await client
                .Request("/api/user")
                .GetJsonAsync<AuthResponse>()
        );
        requset.OnSuccess += body =>
        {
            if (body.User?.Role is "admin" or "superadmin")
                Router.GoTo<AdminPanelViewModel>();
            else
                Router.GoTo<WaitUntilAdminAllowsViewModel>();
        };
        requset.OnError += _ => Router.GoTo<LoginViewModel>();
        requset.Invoke();
    }
}