using System.Text.Json.Serialization;

namespace SteamCommon.Models;

public class OwnedGames
{
    [JsonPropertyName("response")] public Response Response { get; set; }
}

public class Response
{
    [JsonPropertyName("game_count")] public int GameCount { get; set; }

    [JsonPropertyName("games")] public List<OwnedGame> Games { get; set; }
}

public class OwnedGame
{
    [JsonPropertyName("appid")] public int AppId { get; set; }

    [JsonPropertyName("playtime_forever")] public int HoursPlayed { get; set; }
}
