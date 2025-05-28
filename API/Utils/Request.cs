using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using Flurl.Http;

namespace VamaDesktop.API.Utils;

public class Request<TSuccess, TError>(Request<TSuccess, TError>.ResponseDefinition definition)
    where TError : new()
    where TSuccess : new()
{
    public delegate Task<TSuccess> DefinitionHandler();

    public event Action<TSuccess>? OnSuccess;
    public event Action<TError>? OnError;
    public event Action? OnFinish;
    public event Action? OnStart;

    private void RaiseSuccess(TSuccess body) => OnSuccess?.Invoke(body);
    private void RaiseError(TError body) => OnError?.Invoke(body);
    private void RaiseFinish() => OnFinish?.Invoke();
    private void RaiseStart() => OnStart?.Invoke();

    public delegate Task<TSuccess> ResponseDefinition(ApiClient client);

    public async void Invoke()
    {
        RaiseStart();
        try
        {
            string? token = await BlobCache.UserAccount.GetOrCreateObject("SESSION_TOKEN", () => "");
            var result = await definition(new ApiClient(token));
            RaiseSuccess(result ?? new TSuccess());
        }
        catch (FlurlHttpException ex)
        {
            var err = await ex.GetResponseJsonAsync<TError>();
            RaiseError(err ?? new TError());
        }
        finally
        {
            RaiseFinish();
        }
    }
}