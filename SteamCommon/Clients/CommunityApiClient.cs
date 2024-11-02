namespace SteamCommon.Clients;

using SteamCommon.Models;

public interface ICommunityApiClient : IClient
{
    Task<GamesList> GetGamesListFor(SteamId steamId);
    Task<GamesList> GetGamesListFor(string directory, string id);
}

public class CommunityApiClient : ClientBase, ICommunityApiClient
{
    private const string BaseUrlFormat = "https://steamcommunity.com/{0}/{1}/games?tab=all&xml=1";

    // profiles -> steamid64
    // id -> customurl

    public async Task<GamesList> GetGamesListFor(SteamId steamId)
    {
        string url = string.Format(BaseUrlFormat, "profiles", steamId.SteamId64);
        return await Get(url);
    }

    public async Task<GamesList> GetGamesListFor(string directory, string id)
    {
        string url = string.Format(BaseUrlFormat, directory, id);
        return await Get(url);
    }

    private async Task<GamesList> Get(string url)
    {
        var response = await HttpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        
        var body = await response.Content.ReadAsStringAsync();

        return XmlHelpers.ReadAs<GamesList>(body);
    }
}
