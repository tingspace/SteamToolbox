using SteamCommon.Clients;
using SteamCommon.Models;

namespace SteamCommon.Services;

public interface IGameService : IService
{
    Task<List<Game>> GetGamesFor(SteamId steamId);
    Task<List<Game>> GetGamesFor(string customUrlName);
}

public class GameService : ServiceBase, IGameService
{
    private readonly ICommunityApiClient _apiClient;

    public GameService(ServiceFactory serviceFactory, ClientFactory clientFactory)
        : base(serviceFactory, clientFactory)
    {
        _apiClient = _clientFactory.GetClient<ICommunityApiClient>();
    }

    public async Task<List<Game>> GetGamesFor(SteamId steamId)
    {
        return await Get(steamId);
    }

    public async Task<List<Game>> GetGamesFor(string customUrlName)
    {
        var pieces = customUrlName.Split('/');
        if (pieces.Length < 4)
        {
            // TODO: Implement better error handling without exceptions
            throw new ArgumentException("Invalid custom url name");
        }
        
        var directory = pieces[3];
        var id = pieces[4];

        var games = new List<Game>();
        var gamesList = await _apiClient.GetGamesListFor(directory, id);

        foreach (var game in gamesList.games)
        {
            games.Add(new Game
            {
                Name = game.name,
                Id = game.appID.ToString(),
                Website = game.storeLink
            });
        }

        return games;
    }

    private async Task<List<Game>> Get(SteamId steamId)
    {
        var games = new List<Game>();
        var gamesForPlayer = await _apiClient.GetGamesListFor(steamId);

        foreach (gamesListGame game in gamesForPlayer.games)
        {
            games.Add(new Game
            {
                Id = game.appID.ToString(),
                Name = game.name,
                CapsuleImageUrl = game.logo,
                Website = game.storeLink
            });
        }

        return games;
    }
}
