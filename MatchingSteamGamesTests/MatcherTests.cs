using MatchingSteamGames;
using NSubstitute;
using SteamCommon.Clients;
using SteamCommon.Models;
using SteamCommon.Services;

namespace MatchSteamGamesTests;

public class MatcherTests
{
    private readonly ServiceFactory _serviceFactory;

    private const string Url1 = "https://steamcommunity.com/id/YootYoot";
    private const string Url2 = "https://steamcommunity.com/profiles/123123123123";
    
    public MatcherTests()
    {
        _serviceFactory = new ServiceFactory(new ClientFactory());
        
        var gameService = Substitute.For<IGameService>();
        _serviceFactory.RegisterService<IGameService>((_, _) => gameService);
        gameService.GetGamesFor(Url1).Returns(Task.FromResult(GetGamesListFor(Url1)));
        gameService.GetGamesFor(Url2).Returns(Task.FromResult(GetGamesListFor(Url2)));
    }
    
    [Fact]
    public void FindMatchesFor_WithMocks_ReturnsMatchedGames()
    {
        // Arrange
        var matcher = new Matcher(_serviceFactory);
        
        // Act
        var gameListWithMatchCounts = matcher.FindMatchesFor(Url1, Url2);
        var matches = gameListWithMatchCounts
            .Where(g => g.Value > 0)
            .Select(g => g.Key)
            .ToList();
        
        // Assert
        Assert.NotEmpty(matches);
        Assert.Equal(2, matches.Count());
        Assert.Contains("Project Zomboid", matches);
        Assert.Contains("Rust", matches);
    }

    private readonly Dictionary<string, List<Game>> _gamesPerUrl = new()
    {
        {Url1, new List<Game>
        {
            new()
            {
                Id = "1",
                Name = "Project Zomboid",
            },
            new()
            {
                Id = "2",
                Name = "Rust",
            },
            new()
            {
                Id = "3",
                Name = "Star Trek Online"
            }
        }},
        {
            Url2, new List<Game>
            {
                new()
                {
                    Id = "1",
                    Name = "Project Zomboid"
                },
                new()
                {
                    Id = "2",
                    Name = "Rust"
                },
                new()
                {
                    Id = "3",
                    Name = "DayZ"
                }
            }
        }
    };

    private List<Game> GetGamesListFor(string url)
    {
        return _gamesPerUrl
            .TryGetValue(url, out var games) 
                ? games 
                : new();
    }
}