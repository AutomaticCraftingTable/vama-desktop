using System.Reactive.Linq;
using DotNetEnv;
using Flurl.Http;
using Akavache;

namespace VamaDesktop.API;

public class ApiClient : FlurlClient
{
    public ApiClient()
    {
        Env.Load();
        BaseUrl = Env.GetString("BASE_URL");
        Headers.Add("Accept", $"application/json");
        Headers.Add("Content-Type", $"application/json");
        LoadToken();
    }

    async void LoadToken()
    {
        string? token = await BlobCache.UserAccount.GetOrCreateObject("SESSION_TOKEN", () => "");
        Headers.Add("Authorization", $"Bearer {token}");
    }
}