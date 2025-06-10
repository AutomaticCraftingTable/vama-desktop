using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using Avalonia.SimpleRouter;
using CommunityToolkit.Mvvm.ComponentModel;
using Flurl.Http;
using VamaDesktop.API.DTO;
using VamaDesktop.API.Utils;

namespace VamaDesktop.ViewModels;

public partial class MainViewModel : RoutedModelBase
{
    [ObservableProperty] private ViewModelBase _content = default!;


    public MainViewModel(HistoryRouter<ViewModelBase> router) : base(router)
    {
        Content = new LoadingViewModel(router);
        Router.CurrentViewModelChanged += viewModel => Content = viewModel;
     
        Router.GoTo<ProfilesViewModel>();
        // TryRecoverSession();
    }

    public void TryRecoverSession()
    {
        var requset = new RequestClient<object, object>(
            async client => await client
                .Request("/api/user")
                .GetJsonAsync<object>()
        );
        requset.OnSuccess += _ => Router.GoTo<AdminPanelViewModel>();
        requset.OnError += _ => Router.GoTo<LoginViewModel>();
        requset.Invoke();
    }
}