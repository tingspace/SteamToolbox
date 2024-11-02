using System.Collections.Concurrent;
using SteamCommon.Models;
using SteamCommon.Services;

namespace MatchingSteamGames;

public class Matcher
{
    private readonly IGameService _gameService;

    public Matcher(ServiceFactory serviceFactory)
    {
        _gameService = serviceFactory.GetService<IGameService>();
    }

    /// <summary>
    /// Gets the games for both URLs, returning a dictionary mapping the name to
    /// the count of matches.
    ///
    /// NOTE: It does not filter out any games with zero matches.
    /// </summary>
    /// <param name="urls">list of steam profile urls</param>
    /// <returns>Mapping of all games found across profiles and the count
    /// of matches</returns>
    public IDictionary<string, int> FindMatchesFor(params string[] urls)
    {
        var gameMatchCounter = new Dictionary<string, int>();
        
        var gamesPerPlayer = GetGamesFor(urls);
        foreach (var gamesForPlayer in gamesPerPlayer)
        {
            foreach (Game game in gamesForPlayer.Value)
            {
                if (!gameMatchCounter.ContainsKey(game.Name))
                {
                    gameMatchCounter[game.Name] = 0;
                    continue;
                }
                
                gameMatchCounter[game.Name]++;
            }
        }
        
        return gameMatchCounter;
    }

    private IDictionary<string, List<Game>> GetGamesFor(string[] urls)
    {
        var gamesPerPlayer = new ConcurrentDictionary<string, List<Game>>();
        var tasks = new Task[urls.Length];

        for (var index = 0; index < urls.Length; index++)
        {
            var url = urls[index];
            tasks[index] = Task.Run(async () =>
            {
                List<Game> games = await _gameService.GetGamesFor(url);
                gamesPerPlayer.TryAdd(url, games);
            });
        }

        Task.WaitAll(tasks);
        
        return gamesPerPlayer;
    }
}