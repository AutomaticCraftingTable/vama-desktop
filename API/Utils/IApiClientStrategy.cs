using System;
using System.Collections.Generic;

namespace VamaDesktop.API.Utils;

public record ReuqestProps<TSuccessResponse, TErrorResponse>
{
    public required string Url { get; init; }
    public required string Method { get; init; }
    public object? Body { get; init; }
    public Dictionary<string, string> QueryParams { get; init; } = new();
    public Dictionary<string, string> Headers { get; init; } = new();
    public Action<TSuccessResponse> OnSuccess { get; init; } = _ => { };
    public Action<TErrorResponse> OnError { get; init; } = _ => { };
    public Action OnFinish { get; init; } = () => { };
}

public interface IApiClientStrategy
{
    void Request<TSuccessResponse, TErrorResponse>(ReuqestProps<TSuccessResponse, TErrorResponse> props);
}