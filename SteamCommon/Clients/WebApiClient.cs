namespace SteamCommon.Clients;

using SteamCommon.Models;
using System.Text.Json;

public interface IWebApiClient : IClient
{
    Task<OwnedGames?> GetOwnedGames(SteamId steamId);

    Task<AppListWrapper?> GetAllApps();
}

public class WebApiClient : ClientBase, IWebApiClient
{
    private readonly string _apiKey;

    // Example:
    // https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/?key=7DC2DE1945EE4CE64EB8F420F1389E0B&steamid=76561198441877477&format=json

    private const string BaseUrlFormat = "https://api.steampowered.com/{0}/{1}";

    public WebApiClient(Configuration configuration)
        : base()
    {
        _apiKey = configuration.SteamDevKey;
    }

    public async Task<OwnedGames?> GetOwnedGames(SteamId steamId)
    {
        var url = string.Format(
            BaseUrlFormat,
            "IPlayerService",
            $"GetOwnedGames/v1?key={_apiKey}&steamid={steamId.SteamId64}&format=json");

        var response = await HttpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<OwnedGames>(await response.Content.ReadAsStreamAsync());
    }

    public async Task<AppListWrapper?> GetAllApps()
    {
        var url = string.Format(
            BaseUrlFormat,
            "ISteamApps",
            "GetAppList/v2");

        var response = await HttpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return await JsonSerializer.DeserializeAsync<AppListWrapper>(await response.Content.ReadAsStreamAsync());
    }
}
