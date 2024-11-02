using NuGet.Frameworks;
using SteamCommon;
using SteamCommon.Models;

namespace SteamCommonTests.UnitTests.DeserializationTests.CommunityApi;

public class GamesListDeserializationTests
{
    [Fact]
    public void ReadAs_WithDefaultGameList_SuccessfullyDeserializes()
    {
        ulong expectedSteamId64 = 76561198051898704;
        string expectedSteamId = "Yooty";

        uint expectedAppId = 393380;
        string expectedGameName = "Squad";
        string expectedLogo =
            "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/393380/capsule_184x69.jpg?t=1724193974";
        string expectedStoreLink = "https://steamcommunity.com/app/393380";
        const string expectedHours2Weeks = "27.3";
        const string expectedHoursOnRecord = "233";


        string gamesListXml = File.ReadAllText(".\\TestFiles\\gamesList.xml");
        var result = XmlHelpers.ReadAs<GamesList>(gamesListXml);

        Assert.NotNull(result);
        Assert.Equal(expectedSteamId64, result.steamID64);
        Assert.Equal(expectedSteamId, result.steamID);

        Assert.NotNull(result.games);
        Assert.NotEmpty(result.games);

        gamesListGame? actualGame = result.games.FirstOrDefault(g => g.appID == expectedAppId);
        Assert.NotNull(actualGame);
        Assert.Equal(expectedAppId, actualGame.appID);
        Assert.Equal(expectedGameName, actualGame.name);
        Assert.Equal(expectedLogo, actualGame.logo);
        Assert.Equal(expectedStoreLink, actualGame.storeLink);
        Assert.Equal(expectedHours2Weeks, actualGame.hoursLast2Weeks);
        Assert.Equal(expectedHoursOnRecord, actualGame.hoursOnRecord);
    }

    [Fact]
    public void ReadAs_WithBenschiesGameList_SuccessfullyDeserializes()
    {
        string xml = File.ReadAllText(".\\TestFiles\\benschieGameList.xml");
        var result = XmlHelpers.ReadAs<GamesList>(xml);
        
        Assert.NotNull(result);
        Assert.Equal((ulong)76561198019747685, result.steamID64);
        Assert.Equal("Benschie", result.steamID);
        Assert.NotEmpty(result.games);
    }
}