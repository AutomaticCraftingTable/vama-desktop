using System;
using System.Linq;
using DotNetEnv;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VamaDesktop.Extensions;

namespace VamaDesktop.API;

public class ApiClient : FlurlClient
{
    public ApiClient()
    {
        Env.Load();
        BaseUrl = Env.GetString("BASE_URL");
        Headers.Add("Accept", $"application/json");
        Headers.Add("Content-Type", $"application/json");
        Headers.Add("Authorization", $"Bearer {SessionManager.Token}");

        this.AfterCall(call =>
        {
            $"[{call.HttpRequestMessage.Method}] {call.Request.Url}".PrintWithColor(Colors.Magenta);
            Console.WriteLine("  Headers:");
            foreach (var header in call.Request.Headers)
                Console.WriteLine($"    {header.Name}: {string.Join(", ", header.Value)}");
            if (call.RequestBody != null)
                Console.WriteLine($"  Request body: {call.RequestBody}");
            $"  Response: {call.Response.StatusCode}".PrintWithColor(Colors.Cyan);
            var body = call.Response.ResponseMessage.Content.ReadAsStringAsync().Result;
            string formatted = JToken.Parse(body).ToString(Formatting.Indented);
            string padded = string.Join("\n", formatted
                .Split('\n')
                .Select(line => "  " + line));
            $"  Response body:\n{padded}".PrintWithColor(Colors.Yellow);
        });
    }
}