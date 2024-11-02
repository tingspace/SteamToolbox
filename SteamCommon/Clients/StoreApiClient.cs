using SteamCommon.Models;
using System.Text.Json;

namespace SteamCommon.Clients;

public interface IStoreApiClient : IClient
{
    Task<AppDetails?> GetAppDetails(string appId);
}

public class StoreApiClient : ClientBase, IStoreApiClient
{
    private const string BaseUrl = "https://store.steampowered.com/api";

    public async Task<AppDetails?> GetAppDetails(string appId)
    {
        var response = await HttpClient.GetAsync($"{BaseUrl}/appdetails?appids={appId}");
        response.EnsureSuccessStatusCode();

        var result = JsonSerializer.Deserialize<Dictionary<string, AppDetails>>(await response.Content.ReadAsStringAsync());
        return result?.First().Value;
    }
}
