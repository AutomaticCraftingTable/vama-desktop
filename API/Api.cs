using DotNetEnv;
using Flurl.Http;
using Flurl.Http.Configuration;

namespace VamaDesktop.API;

public class Api : FlurlClient
{
    public Api()
    {
        Env.Load();
        BaseUrl = Env.GetString("BASE_URL");
    }

}