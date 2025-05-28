using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using DotNetEnv;
using Flurl.Http;
using Akavache;
using VamaDesktop.Utils;
using ConsoleColor = VamaDesktop.Utils.ConsoleColor;

namespace VamaDesktop.API;

public class ApiClient : FlurlClient
{
    public ApiClient(string? sessionToken)
    {
        Env.Load();
        BaseUrl = Env.GetString("BASE_URL");
        Headers.Add("Accept", $"application/json");
        Headers.Add("Content-Type", $"application/json");
        Headers.Add("Authorization", $"Bearer {sessionToken}");

        this.AfterCall(call =>
        {
            ConsoleColor.Magenta.Print($"[{call.HttpRequestMessage.Method}] {call.Request.Url}");
            Console.WriteLine("  Headers:");
            foreach (var header in call.Request.Headers)
                Console.WriteLine($"    {header.Name}: {string.Join(", ", header.Value)}");
            if (call.RequestBody != null)
                Console.WriteLine($"  Body: {call.RequestBody}");
            ConsoleColor.Cyan.Print($"  Response: {call.Response.StatusCode}");
            var body = call.Response.ResponseMessage.Content.ReadAsStringAsync().Result;
            ConsoleColor.Yellow.Print($"  Body: {body}");
        });
    }
}