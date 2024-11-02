namespace SteamCommon.Models;

using System.Text.Json.Serialization;

public class AppListWrapper
{
    [JsonPropertyName("applist")] public AppList AppList { get; set; }
}

public class AppList
{
    [JsonPropertyName("apps")] public List<App> Apps { get; set; }
}

public class App
{
    [JsonPropertyName("appid")] public int AppId { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }
}
