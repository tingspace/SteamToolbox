namespace SteamCommonTests.IntegrationTests.Clients;

using SteamCommon.Clients;

public class CommunityApiClientIntegrationTests
{
    private readonly CommunityApiClient _communityApiClient = new();

    private const string ProfileId = "YootYoot/";

    [Fact]
    public async Task GetGamesListFor_WithCustomUrl_ReturnsExpectedResult()
    {
        var gamesList = await _communityApiClient.GetGamesListFor("id", ProfileId);
        Assert.NotNull(gamesList);
        Assert.Equal("76561198051898704", gamesList.steamID64.ToString());
        Assert.Equal("Yooty", gamesList.steamID);
        Assert.NotEmpty(gamesList.games);
    }
}