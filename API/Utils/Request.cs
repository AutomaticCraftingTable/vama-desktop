using System;
using System.Threading.Tasks;
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
            var result = await definition(new ApiClient());
            RaiseSuccess(result ?? new TSuccess());
        }
        catch (FlurlHttpException ex)
        {
            var raw = await ex.Call.Response.ResponseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(raw);
            
            var err = await ex.GetResponseJsonAsync<TError>();
            RaiseError(err ?? new TError());
        }
        finally
        {
            RaiseFinish();
        }
    }
}