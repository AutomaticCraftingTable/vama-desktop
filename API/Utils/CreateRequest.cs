using System.Net.Http;
using System.Threading.Tasks;
using VamaDesktop.API.DTO.Models.Body;
using VamaDesktop.API.DTO.Models.Error;
using VamaDesktop.API.DTO.Models.Success;

namespace VamaDesktop.API.Utils;

public static class CreateRequest
{
    // public static async Task<(AuthResponse?, CommonErrorRecord<LoginError>?)> Login(
    //     AuthCredentials? requestBody,
    //     RequestActions<AuthResponse?, CommonErrorRecord<LoginError>?> actions
    // )
    // {
    //     return await Theory.Request(
    //         new RequestPayload { Method = HttpMethod.Post, Url = "/api/auth/login" },
    //         actions,
    //         requestBody
    //     );
    // }

    public static RequestPayload<
        AuthResponse,
        CommonErrorRecord<LoginError>,
        AuthCredentials?
    > Login(AuthCredentials body) {
        return new(
            method: HttpMethod.Post,
            url: "/api/auth/login",
            body: body
        );
    }
}