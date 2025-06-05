using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using VamaDesktop.Extensions;

namespace VamaDesktop.API.Utils;

public class RequestClient<TSuccessBody, TErrorBody>(
    RequestClient<TSuccessBody, TErrorBody>.ResponseDefinition definition)
    where TErrorBody : new()
    where TSuccessBody : new()
{
    public event Action<TSuccessBody>? OnSuccess;
    public event Action<TErrorBody>? OnError;
    public event Action? OnFinish;
    public event Action? OnStart;

    private void RaiseSuccess(TSuccessBody body) => OnSuccess?.Invoke(body);
    private void RaiseError(TErrorBody body) => OnError?.Invoke(body);
    private void RaiseFinish() => OnFinish?.Invoke();
    private void RaiseStart() => OnStart?.Invoke();

    public delegate Task<TSuccessBody> ResponseDefinition(ApiClient client);

    public async Task<(TSuccessBody, TErrorBody)> Invoke()
    {
        TSuccessBody successBody = new TSuccessBody();
        TErrorBody errorBody = new TErrorBody();
        
        RaiseStart();
        try
        {
            successBody = await definition(new ApiClient()) ?? new TSuccessBody();
            RaiseSuccess(successBody);
        }
        catch (FlurlParsingException ex)
        {
            $"Error: Couldn't deserialize to:".PrintWithColor(Colors.Red);
            "{".PrintWithColor(Colors.Red);
            var props = successBody.GetType().GetProperties();
            foreach (var prop in successBody.GetType().GetProperties())
            {
                var type = Nullable.GetUnderlyingType(prop.PropertyType)?.Name ?? prop.PropertyType.Name;
                $"  {prop.Name}: {type}".PrintWithColor(Colors.Red);
            }
            "}".PrintWithColor(Colors.Red);
        }
        catch (FlurlHttpException ex)
        {
            errorBody = await ex.GetResponseJsonAsync<TErrorBody>() ?? new TErrorBody();
            RaiseError(errorBody);
        }
        finally
        {
            RaiseFinish();
        }
        
        return (successBody, errorBody);
    }

    public static async Task<(TSuccessBody, TErrorBody)> Request(
        string url,
        HttpMethod method,
        object? body = null,
        Action? onStart = null,
        Action<TSuccessBody>? onSuccess = null,
        Action<TErrorBody>? onError = null,
        Action? onFinish = null,
        Dictionary<string, string>? queryParams = null,
        Dictionary<string, string>? headers = null
    )
    {
        var rc = new RequestClient<TSuccessBody, TErrorBody>(
            async client => await client
                .Request(url)
                .SetQueryParams(queryParams)
                .WithHeaders(headers)
                .SendJsonAsync(method, body)
                .ReceiveJson<TSuccessBody>()
        );
        
        rc.OnStart += onStart;
        rc.OnError += onError;
        rc.OnSuccess += onSuccess;
        rc.OnFinish += onFinish;
        return await rc.Invoke();
    }

    public static async Task<(TSuccessBody, TErrorBody)> Post(
        string url,
        object? body = null,
        Action? onStart = null,
        Action<TSuccessBody>? onSuccess = null,
        Action<TErrorBody>? onError = null,
        Action? onFinish = null,
        Dictionary<string, string>? queryParams = null,
        Dictionary<string, string>? headers = null
    ) => await Request(url, HttpMethod.Post, body, onStart, onSuccess, onError, onFinish, queryParams, headers);
    
    
    public static async Task<(TSuccessBody, TErrorBody)> Get(
        string url,
        object? body = null,
        Action? onStart = null,
        Action<TSuccessBody>? onSuccess = null,
        Action<TErrorBody>? onError = null,
        Action? onFinish = null,
        Dictionary<string, string>? queryParams = null,
        Dictionary<string, string>? headers = null
    ) => await Request(url, HttpMethod.Get, body, onStart, onSuccess, onError, onFinish, queryParams, headers);
    
    
    public static async Task<(TSuccessBody, TErrorBody)> Delete(
        string url,
        object? body = null,
        Action? onStart = null,
        Action<TSuccessBody>? onSuccess = null,
        Action<TErrorBody>? onError = null,
        Action? onFinish = null,
        Dictionary<string, string>? queryParams = null,
        Dictionary<string, string>? headers = null
    ) => await Request(url, HttpMethod.Delete, body, onStart, onSuccess, onError, onFinish, queryParams, headers);
    
    public static async Task<(TSuccessBody, TErrorBody)> Patch(
        string url,
        object? body = null,
        Action? onStart = null,
        Action<TSuccessBody>? onSuccess = null,
        Action<TErrorBody>? onError = null,
        Action? onFinish = null,
        Dictionary<string, string>? queryParams = null,
        Dictionary<string, string>? headers = null
    ) => await Request(url, HttpMethod.Patch, body, onStart, onSuccess, onError, onFinish, queryParams, headers);
}