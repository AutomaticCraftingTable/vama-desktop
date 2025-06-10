using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.SimpleRouter;
using Flurl.Http;
using VamaDesktop.API;
using VamaDesktop.API.DTO.Models.Body;
using VamaDesktop.API.DTO.Models.Error;
using VamaDesktop.API.DTO.Models.Success;
using VamaDesktop.API.Utils;

namespace VamaDesktop.ViewModels;

public class LoginViewModel(HistoryRouter<ViewModelBase> router) : RoutedModelBase(router)
{
    private Timer? _timer;
    public AuthCredentials Credentials { get; } = new AuthCredentials();
    public CommonErrorRecord<LoginError>? LoginError { get; set; }

    public async void Login()
    {
        // (_, LoginError) = await RequestClient<
        //     AuthResponse,
        //     CommonErrorRecord<LoginError>
        // >.Post(
        //     "/api/auth/login",
        //     Credentials,
        //     onSuccess: body =>
        //     {
        //         SessionManager.SaveSession(body);
        //         Router.GoTo<AdminPanelViewModel>();
        //     }
        // );

        // var requestActions = new RequestActions<AuthResponse?, CommonErrorRecord<LoginError>?>();
        // requestActions.OnSuccess += body =>
        // {
        //     SessionManager.SaveSession(body);
        //     Router.GoTo<AdminPanelViewModel>();
        // };
        //
        // (_, LoginError) = await CreateRequest.Login(Credentials, requestActions);
        
        
        var r = CreateRequest.Login(Credentials);
        r.Actions.OnSuccess += body =>
        {
            SessionManager.SaveSession(body);
            Router.GoTo<AdminPanelViewModel>();
        };
        
        (_, LoginError) = await Theory.Request(r);

        SetState();
    }

    public async void LoginGoogle()
    {
        var (oAuth, error) = await RequestClient<
            InitGoogleLoginResponse,
            MessageError
        >.Get("/auth/google/init");

        LoginError = (LoginError ?? new CommonErrorRecord<LoginError>()) with
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
            _timer?.Dispose();
            Router.GoTo<AdminPanelViewModel>();
        };
        googleLoginPollRequest.OnError += body =>
        {
            LoginError = new() { Message = body.Message };
            _timer?.Dispose();
        };
        googleLoginPollRequest.OnFinish += SetState;

        _timer = new Timer(async _ => await googleLoginPollRequest.Invoke(), null, 0, 1000);
    }
}