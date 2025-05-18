using Avalonia.SimpleRouter;
using VamaDesktop.API.DTO;
using VamaDesktop.API.DTO.Exceptions;
using VamaDesktop.API.Services;
using VamaDesktop.API.Utils;

namespace VamaDesktop.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private readonly Request<MessageResponse, LoginError> loginRequest = new AuthService().Login;

    private LoginError _error = new();

    public LoginError Error
    {
        get => _error;
        set => SetProperty(ref _error, value);
    }

    public LoginViewModel(HistoryRouter<ViewModelBase> router) : base(router)
    {
        loginRequest.OnSuccess += _ => Router.GoTo<AdminPanelViewModel>();
        loginRequest.OnError += error => Error = error;
    }

    public void Login()
    {
        loginRequest.Invoke();
    }
}