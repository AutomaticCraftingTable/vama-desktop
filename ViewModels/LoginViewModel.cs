using Akavache;
using Avalonia.SimpleRouter;
using Flurl.Http;
using VamaDesktop.API.DTO.Errors;
using VamaDesktop.API.DTO.Requests;
using VamaDesktop.API.DTO.Responses;
using VamaDesktop.API.Utils;

namespace VamaDesktop.ViewModels;

public class LoginViewModel(HistoryRouter<ViewModelBase> router) : ViewModelBase(router)
{
    public LoginCredentialsRequest Credentials { get; } = new();
    public CommonErrorRecord<LoginErrors> LoginError { get; set; } = new();

    public void Login()
    {
        var loginRequest = new Request<LoginResponse, CommonErrorRecord<LoginErrors>>(
            async client => await client
                .Request("/api/auth/login")
                .PostJsonAsync(Credentials)
                .ReceiveJson<LoginResponse>()
        );
        loginRequest.OnStart += () => LoginError = new();
        loginRequest.OnSuccess += body =>
        {
            BlobCache.UserAccount.InsertObject("SESSION_TOKEN", body.Token);
            Router.GoTo<AdminPanelViewModel>();
        };
        loginRequest.OnError += error =>
        {
            LoginError = error;
            OnPropertyChanged(nameof(LoginError));
        };

        loginRequest.Invoke();
    }
}