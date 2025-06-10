using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using VamaDesktop.Extensions;

namespace VamaDesktop.API.Utils;

public static class Theory
{
    public static async Task<(TSuccessBody?, TErrorBody?)> Request<TRequestBody, TSuccessBody, TErrorBody>(
        RequestPayload payload,
        RequestActions<TSuccessBody?, TErrorBody?> actions,
        TRequestBody? requestBody
    ) where TSuccessBody : class?, new() where TErrorBody : class?, new()
    {
        TSuccessBody? successBody = null;
        TErrorBody? errorBody = null;

        actions.RaiseStart();

        try
        {
            var client = new ApiClient();
            successBody = await client
                .Request(payload.Url)
                .SetQueryParams(payload.QueryParams)
                .WithHeaders(payload.Headers)
                .SendJsonAsync(payload.Method, requestBody)
                .ReceiveJson<TSuccessBody>();
            actions.RaiseSuccess(successBody);
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
            actions.RaiseError(errorBody);
        }

        finally
        {
            actions.RaiseFinish();
        }

        return (successBody, errorBody);
    }
}

public struct RequestPayload
{
    public string Url { get; set; }
    public HttpMethod Method { get; set; }
    public Dictionary<string, string> QueryParams { get; set; }
    public Dictionary<string, string> Headers { get; set; }
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