using System;
using System.Diagnostics;
using System.Threading;
using Avalonia.SimpleRouter;
using Flurl.Http;
using VamaDesktop.API;
using VamaDesktop.API.DTO.Models.Body;
using VamaDesktop.API.DTO.Models.Error;
using VamaDesktop.API.DTO.Models.Success;
using VamaDesktop.API.Utils;
using VamaDesktop.Utils;
using ConsoleColor = VamaDesktop.Utils.ConsoleColor;

namespace VamaDesktop.ViewModels;

public class LoginViewModel(HistoryRouter<ViewModelBase> router) : ViewModelBase(router)
{
    private Timer? timer;
    public AuthCredentials Credentials { get; } = new();
    public CommonErrorRecord<LoginError> LoginError { get; set; } = new();

    public async void Login()
    {
        (_, LoginError) = await RequestClient<
            AuthResponse,
            CommonErrorRecord<LoginError>
        >.Post(
            "/api/auth/login",
            Credentials,
            onSuccess: body =>
            {
                SessionManager.SaveSession(body);
                Router.GoTo<AdminPanelViewModel>();
            }
        );
        SetState();
    }

    public async void LoginGoogle()
    {
        var (oAuth, error) = await RequestClient<
            InitGoogleLoginResponse,
            MessageError
        >.Get("/auth/google/init");
        
        LoginError = LoginError with
        {
            Message = error.Message
        };

        if (oAuth.Redirect_url == null) return;
        Process.Start(new ProcessStartInfo(oAuth.Redirect_url) { UseShellExecute = true });

        var googleLoginPollRequest = new RequestClient<GoogleLoginResponse, MessageError>(
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
            LoginError = new() { Message = body.Message };
            timer?.Dispose();
        };
        googleLoginPollRequest.OnFinish += SetState;

        timer = new Timer(async _ => await googleLoginPollRequest.Invoke(), null, 0, 1000);
    }
}