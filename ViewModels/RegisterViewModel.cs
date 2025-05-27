using System;
using Avalonia.SimpleRouter;
using Flurl.Http;
using VamaDesktop.API.DTO.Errors;
using VamaDesktop.API.DTO.Requests;
using VamaDesktop.API.DTO.Responses;
using VamaDesktop.API.Utils;

namespace VamaDesktop.ViewModels;

public class RegisterViewModel(HistoryRouter<ViewModelBase> router) : ViewModelBase(router)
{
    public RegisterCredentialsRequest Credentials { get; set; } = new();
    public CommonErrorRecord<RegisterError> RegisterError { get; set; } = new();
    public string Regulations { get; set; } = string.Empty;
    public bool RegulationsAccepted { get; set; }

    public void Register()
    {
        Console.WriteLine(Credentials);
        var registerRequest = new Request<MessageResponse, CommonErrorRecord<RegisterError>>(
            async client => await client
                .Request("/api/auth/register")
                // .BeforeCall(action => action.Request.SetQueryParams("apidogResponseId","23668515"))
                .BeforeCall(call => Console.WriteLine(call.RequestBody?.ToString()))
                .PostJsonAsync(Credentials)
                .ReceiveJson<MessageResponse>()
        );
        registerRequest.OnStart += () => RegisterError = new();
        registerRequest.OnError += error => RegisterError = error;
        registerRequest.OnSuccess += _ =>
        {
            Router.GoTo<AdminPanelViewModel>();
        };
        registerRequest.OnFinish += () =>
        {
            OnPropertyChanged(nameof(RegisterError));
        };
        if (RegulationsAccepted) 
        {
            registerRequest.Invoke();
        }
        else
        {
            Regulations = RegulationsAccepted ? string.Empty : "Warunki nie byli zaakceptowane";
            OnPropertyChanged(nameof(Regulations));
        }
    }
}