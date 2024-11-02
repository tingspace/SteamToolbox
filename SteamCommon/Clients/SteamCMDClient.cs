namespace SteamCommon.Clients;

using SteamCommon.Models;
using System.Text.Json;

public interface ISteamCMDClient : IClient
{
    Task<InfoResponse?> GetAppInfo(string appId);
}

public class SteamCMDClient : ClientBase, ISteamCMDClient
{
    // Example: https://api.steamcmd.net/v1/info/1190460
    private const string BaseUrl = "https://api.steamcmd.net/v1";

    public async Task<InfoResponse?> GetAppInfo(string appId)
    {
        var req = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/info/{appId}");
        var response = await HttpClient.SendAsync(req);
        using var responseBody = await response.Content.ReadAsStreamAsync();

        return await JsonSerializer.DeserializeAsync<InfoResponse>(responseBody);
    }
}
