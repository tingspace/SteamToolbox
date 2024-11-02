namespace SteamCommon.Models;

public class LoginUser
{
    public Dictionary<string, User> Users { get; set; }
}

public class User
{
    public string AccountName { get; set; }
    public string PersonaName { get; set; }
    public string RememberPassword { get; set; }
    public string WantsOfflineMode { get; set; }
    public string SkipOfflineModeWarning { get; set; }
    public string AllowAutoLogin { get; set; }
    public string MostRecent { get; set; }
    public string Timestamp { get; set; }
}
