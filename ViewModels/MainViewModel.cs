using Avalonia.SimpleRouter;
using CommunityToolkit.Mvvm.ComponentModel;
using Flurl.Http;
using VamaDesktop.API.Utils;

namespace VamaDesktop.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _content = default!;

    public MainViewModel(HistoryRouter<ViewModelBase> router): base(router)
    {
        router.CurrentViewModelChanged += viewModel => Content = viewModel;
        
        // TODO: remove
        router.GoTo<AdminPanelViewModel>();
        return;
        //
        bool isLoggedIn = VerifySession();
        if (isLoggedIn)
        {
            router.GoTo<AdminPanelViewModel>();
        }
        else
        {
            router.GoTo<LoginViewModel>();
        }
    }
    
    
    bool VerifySession()
    {
        var verified = false;
        var requset = new Request<object, object>(
            async client => await client
                .Request("/api/session")
                .GetJsonAsync<object>()
        );
        requset.OnSuccess += _ => verified = true;
        requset.OnError += _ => verified = false;
        return verified;
    }
}
