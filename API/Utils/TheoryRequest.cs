using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using VamaDesktop.Extensions;

namespace VamaDesktop.API.Utils;

public static class Theory
{
    public static async Task<(TSuccessBody?, TErrorBody?)> Request<TSuccessBody, TErrorBody, TRequestBody>(
        RequestPayload<TSuccessBody, TErrorBody, TRequestBody> payload
    ) where TSuccessBody : class?, new() where TErrorBody : class?, new() where TRequestBody : class?, new()
    {
        TSuccessBody? successBody = null;
        TErrorBody? errorBody = null;

        payload.Actions.RaiseStart();

        try
        {
            var client = new ApiClient();
            successBody = await client
                .Request(payload.Url)
                .SetQueryParams(payload.QueryParams)
                .WithHeaders(payload.Headers)
                .SendJsonAsync(payload.Method, payload.Body)
                .ReceiveJson<TSuccessBody>();
            payload.Actions.RaiseSuccess(successBody);
        }

        catch (FlurlParsingException)
        {
            $"Error: Couldn't deserialize to:".PrintWithColor(Colors.Red);
            if (successBody == null)
            {
                $"Null".PrintWithColor(Colors.Red);
            }
            else
            {
                "{".PrintWithColor(Colors.Red);
                var props = successBody.GetType().GetProperties();
                foreach (var prop in successBody.GetType().GetProperties())
                {
                    var type = Nullable.GetUnderlyingType(prop.PropertyType)?.Name ?? prop.PropertyType.Name;
                    $"  {prop.Name}: {type}".PrintWithColor(Colors.Red);
                }

                "}".PrintWithColor(Colors.Red);
            }
        }

        catch (FlurlHttpException ex)
        {
            errorBody = await ex.GetResponseJsonAsync<TErrorBody>();
            payload.Actions.RaiseError(errorBody);
        }

        finally
        {
            payload.Actions.RaiseFinish();
        }

        return (successBody, errorBody);
    }
}

public class RequestPayload<TSuccessBody, TErrorBody>(
    HttpMethod method,
    string url,
    Dictionary<string, string>? queryParams = null,
    Dictionary<string, string>? headers = null
) : RequestPayload<TSuccessBody, TErrorBody, object>(method, url, queryParams, headers)
    where TSuccessBody : class?, new()
    where TErrorBody : class?, new();

public class RequestPayload<TSuccessBody, TErrorBody, TBody>(
    HttpMethod method,
    string url,
    TBody? body = null,
    Dictionary<string, string>? queryParams = null,
    Dictionary<string, string>? headers = null
)
    where TSuccessBody : class?, new()
    where TErrorBody : class?, new()
    where TBody : class?, new()
{
    public string Url => url;
    public HttpMethod Method => method;
    public TBody? Body => body;
    public Dictionary<string, string>? QueryParams => queryParams;
    public Dictionary<string, string>? Headers => headers;
    public RequestActions<TSuccessBody, TErrorBody> Actions { get; } = new();

    public async Task<(TSuccessBody?, TErrorBody?)> AsyncInvoke()
    {
        return await Theory.Request(this);
    }
}

public class RequestActions<TSuccessBody, TErrorBody>
{
    public event Action<TSuccessBody>? OnSuccess;
    public event Action<TErrorBody>? OnError;
    public event Action? OnFinish;
    public event Action? OnStart;

    public void RaiseSuccess(TSuccessBody body) => OnSuccess?.Invoke(body);
    public void RaiseError(TErrorBody body) => OnError?.Invoke(body);
    public void RaiseFinish() => OnFinish?.Invoke();
    public void RaiseStart() => OnStart?.Invoke();
}