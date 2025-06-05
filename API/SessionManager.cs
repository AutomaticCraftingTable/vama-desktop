using System.Reactive.Linq;
using Akavache;
using VamaDesktop.API.DTO.Models.Success;

namespace VamaDesktop.API;

public class SessionManager
{
    public static async void SaveSession(AuthResponse body)
    {
        Session = body;
        await BlobCache.UserAccount.InsertObject("SESSION", body);
    }

    public static AuthResponse LoadSession()
    {
        var session = BlobCache
            .UserAccount
            .GetOrCreateObject("SESSION", () => new AuthResponse())
            .GetAwaiter()
            .GetResult();
        
        return session!;
    }

    public static void Init()
    {
        BlobCache.ApplicationName = nameof(VamaDesktop);
        Session = LoadSession();
    }

    private static AuthResponse Session { get; set; } = new();
    public static string Token => Session.Token;
    public static string? Role => Session.User.Role;
}