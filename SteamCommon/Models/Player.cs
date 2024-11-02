namespace SteamCommon.Models;

public class Player
{
    public SteamId? SteamId { get; init; }

    public string? PlayerName { get; init; }

    public string? AccountName { get; init; }

    public string? MostRecent { get; init; }

    public int LastLoginTimestamp { get; init; }

    public IList<Game>? Games { get; init; }
}