using Avalonia.SimpleRouter;
using VamaDesktop.API.DTO;
using VamaDesktop.API.DTO.Exceptions;
using VamaDesktop.API.Services;
using VamaDesktop.API.Utils;

namespace VamaDesktop.ViewModels;

public class RegisterViewModel : ViewModelBase
{
    private readonly Request<MessageResponse, RegisterError> registerRequest = new AuthService().Register;
    public bool RegulationsAccepted { get; set; }

    private RegisterError _error = new();

    public RegisterError Error
    {
        get => _error;
        set => SetProperty(ref _error, value);
    }

    public RegisterViewModel(HistoryRouter<ViewModelBase> router) : base(router)
    {
        registerRequest.OnSuccess += _ => Router.GoTo<AdminPanelViewModel>();
        registerRequest.OnError += error => Error = error;
    }

    public void Register()
    {
        if (!RegulationsAccepted)
        {
            Error = _error with { Regulations = "Warunki nie byli zaakceptowane" };
        }
        else
        {
            Error = _error with { Regulations = "" };
            registerRequest.Invoke();
        }
    }
}
