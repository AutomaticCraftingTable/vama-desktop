using System;
using System.Collections.Generic;
using System.Net.Http;

namespace VamaDesktop.API.Utils;

public interface IApiClientStrategy
{
    void Request<TSuccessBody, TErrorBody>(
        string Url,
        HttpMethod Method,
        object? Body,
        Dictionary<string, string> QueryParams,
        Dictionary<string, string> Headers,
        Action OnStart,
        Action<TSuccessBody> OnSuccess,
        Action<TErrorBody> OnError,
        Action OnFinish,
        ref TSuccessBody? successBody,
        ref TErrorBody? errorBody
    )
        where TSuccessBody : new()
        where TErrorBody : new();
}