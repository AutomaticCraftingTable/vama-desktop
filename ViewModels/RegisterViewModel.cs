using System;
using System.Diagnostics;
using System.Threading;
using Akavache;
using Avalonia.SimpleRouter;
using Flurl.Http;
using VamaDesktop.API;
using VamaDesktop.API.DTO.Models.Body;
using VamaDesktop.API.DTO.Models.Error;
using VamaDesktop.API.DTO.Models.Success;
using VamaDesktop.API.Utils;

namespace VamaDesktop.ViewModels;

public class RegisterViewModel(HistoryRouter<ViewModelBase> router) : RoutedModelBase(router)
{
    private Timer? timer;
    public AuthCredentials Credentials { get; set; } = new();
    public CommonErrorRecord<AuthError> RegisterError { get; set; } = new();
    public string Regulations { get; set; } = string.Empty;
    public bool RegulationsAccepted { get; set; }

    public void Register()
    {
        var registerRequest = new DeprecatedRequestClient<AuthResponse, CommonErrorRecord<AuthError>>(
            async client => await client
                .Request("/api/auth/register")
                .PostJsonAsync(Credentials)
                .ReceiveJson<AuthResponse>()
        );
        registerRequest.OnStart += () => RegisterError = new();
        registerRequest.OnError += error => RegisterError = error;
        registerRequest.OnSuccess += body =>
        {
            // BlobCache.UserAccount.InsertObject("SESSION_TOKEN", body.Token);
            SessionManager.SaveSession(body);
            Router.GoTo<AdminPanelViewModel>();
        };
        registerRequest.OnFinish += SetState;
        if (RegulationsAccepted) 
        {
            registerRequest.Invoke();
        }
        else
        {
            Regulations = RegulationsAccepted ? string.Empty : "Warunki nie byli zaakceptowane";
            SetState();
        }
    }

    public async void RegisterGoogle()
    {
        var (oAuth, error) = await DeprecatedRequestClient<
            InitGoogleLoginResponse,
            MessageError
        >.Get("/auth/google/init");
        
        RegisterError = RegisterError with
        {
            Message = error.Message
        };

        if (oAuth.Redirect_url == null) return;
        Process.Start(new ProcessStartInfo(oAuth.Redirect_url) { UseShellExecute = true });

        var googleLoginPollRequest = new DeprecatedRequestClient<GoogleLoginResponse, MessageError>(
            async client => await client
                .Request($"/auth/google/wait/{oAuth.State}")
                .GetJsonAsync<GoogleLoginResponse>()
        );

        googleLoginPollRequest.OnSuccess += body =>
        {
            if (body?.Status == "waiting") return;
            Console.WriteLine(body?.Token);
            SessionManager.SaveSession(new AuthResponse()
            {
                Token = body?.Token,
                User = body?.User,
            });
            timer?.Dispose();
            Router.GoTo<AdminPanelViewModel>();
        };
        googleLoginPollRequest.OnError += body =>
        {
            RegisterError = new() { Message = body.Message };
            timer?.Dispose();
        };
        googleLoginPollRequest.OnFinish += SetState;

        timer = new Timer(async _ => await googleLoginPollRequest.Invoke(), null, 0, 1000);
    }
}