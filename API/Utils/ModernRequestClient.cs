using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Flurl.Http;
using VamaDesktop.Extensions;

namespace VamaDesktop.API.Utils;

public static class Reuqests
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

        catch (FlurlParsingException ex)
        {
            $"Error: {ex.Message}".PrintWithColor(Colors.Red);
            var match = Regex.Match(ex.InnerException?.Message ?? "", @"Path: (.+?) \|");
            if (match.Success)
                $"Path: {match.Groups[1].Value}".PrintWithColor(Colors.Red);
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
) : RequestPayload<TSuccessBody, TErrorBody, Dictionary<string, string>>(method, url, queryParams, headers)
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
        return await Reuqests.Request(this);
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