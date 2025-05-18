using Flurl.Http;
using VamaDesktop.API.DTO;
using VamaDesktop.API.DTO.Exceptions;
using VamaDesktop.API.Utils;

namespace VamaDesktop.API.Services;

public class AuthService
{
    public readonly Request<MessageResponse, RegisterError> Register = new(
        async client => await client
            // TODO: remove the query param, it is only for testing
            .BeforeCall(call => call.Request.SetQueryParam("apidogResponseId", "23668515"))
            .Request("/api/auth/register")
            .PostJsonAsync(new { Email = "user@example.com", Password = "secret" })
            .ReceiveJson<MessageResponse>()
    );

    public readonly Request<MessageResponse, ErrorMessageResponse> Logout = new(
        async client => await client
            .Request("/api/auth/logout")
            .PostAsync()
            .ReceiveJson<MessageResponse>());

    public readonly Request<MessageResponse, LoginError> Login = new(
        async client => await client
            .Request("/api/auth/login")
            .PostJsonAsync(new { Email = "user@example.com", Password = "secret" })
            .ReceiveJson<MessageResponse>());
}