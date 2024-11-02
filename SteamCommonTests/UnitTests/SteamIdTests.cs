using SteamCommon;

namespace SteamCommonTests.UnitTests;

public class SteamIdTests
{
    [Fact]
    public void TestSteamId()
    {
        // Arrange
        long expectedSteamId64 = 76561198092541763;

        int expectedSteam2IdNum = 66138017;
        string expectedSteam2Id = $"STEAM_1:1:{expectedSteam2IdNum}";

        int expectedSteam3IdNum = 132276035;
        string expectedSteam3Id = $"U:1:{expectedSteam3IdNum}";

        // Act
        var steamId = new SteamId(expectedSteamId64);

        // Assert
        Assert.NotNull(steamId);
        Assert.Equal(expectedSteamId64, steamId.SteamId64Number);
        Assert.Equal(expectedSteamId64.ToString(), steamId.SteamId64);

        Assert.Equal(expectedSteam2Id, steamId.Steam2Id);
        Assert.Equal(expectedSteam2IdNum, steamId.Steam2IdNumber);

        Assert.Equal(expectedSteam3Id, steamId.Steam3Id);
        Assert.Equal(expectedSteam3IdNum, steamId.Steam3IdNumber);
    }
}
