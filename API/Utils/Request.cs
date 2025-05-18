using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using Flurl.Http;

namespace VamaDesktop.API.Utils;

public delegate void SuccessHandler<in T>(T body);

public delegate void ErrorHandler<in T>(T body);

public delegate void FinishHandler();

public class Request<TSuccess, TError>(
    Request<TSuccess, TError>.ResponseDefinition definition)
{
    public delegate Task<TSuccess> DefinitionHandler();

    public event SuccessHandler<TSuccess>? OnSuccess;
    public event ErrorHandler<TError>? OnError;
    public event FinishHandler? OnFinish;

    private void RaiseSuccess(TSuccess body) => OnSuccess?.Invoke(body);
    private void RaiseError(TError body) => OnError?.Invoke(body);
    private void RaiseFinish() => OnFinish?.Invoke();

    public delegate Task<TSuccess> ResponseDefinition(Api client);

    private readonly Api _client = new();
    
    public async void Invoke()
    {
        try
        {
            var result = await definition(_client);
            RaiseSuccess(result);
        }
        catch (FlurlHttpException ex)
        {
            var err = await ex.GetResponseJsonAsync<TError>();
            RaiseError(err);
        }
        finally
        {
            RaiseFinish();
        }
    }
}