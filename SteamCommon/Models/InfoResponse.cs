namespace SteamCommon.Models;

using System.Text.Json.Serialization;

public class InfoResponse
{
    [JsonPropertyName("data")]
    public Dictionary<string, AppData> Data { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}

public class AppData
{
    [JsonPropertyName("_change_number")]
    public int ChangeNumber { get; set; }

    [JsonPropertyName("_missing_token")]
    public bool MissingToken { get; set; }

    [JsonPropertyName("_sha")]
    public string Sha { get; set; }

    [JsonPropertyName("_size")]
    public int Size { get; set; }

    [JsonPropertyName("appid")]
    public string AppId { get; set; }

    [JsonPropertyName("common")]
    public CommonAppData Common { get; set; }

    [JsonPropertyName("config")]
    public ConfigApp Config { get; set; }

    [JsonPropertyName("depots")]
    public Dictionary<string, object> Depots { get; set; }

    [JsonPropertyName("extended")]
    public Dictionary<string, string> Extended { get; set; }

    [JsonPropertyName("ufs")]
    public UfsApp Ufs { get; set; }
}

public class CommonAppData
{
    [JsonPropertyName("app_retired_publisher_request")]
    public string AppRetoredPublisherRequest { get; set; }

    [JsonPropertyName("associations")]
    public Dictionary<string, CommonAppDataAssociation> Associations { get; set; }

    [JsonPropertyName("category")]
    public Dictionary<string, string> Category { get; set; }

    [JsonPropertyName("clienticon")]
    public string ClientIcon { get; set; }

    [JsonPropertyName("clienttga")]
    public string ClientTga { get; set; }

    [JsonPropertyName("community_hub_visible")]
    public string CommunityHubVisible { get; set; }

    [JsonPropertyName("community_visible_stats")]
    public string CommunityVisibleStats { get; set; }

    [JsonPropertyName("content_descriptors")]
    public Dictionary<string, string> ContentDescriptors { get; set; }

    [JsonPropertyName("controller_support")]
    public string ControllerSupport { get; set; }

    [JsonPropertyName("eulas")]
    public Dictionary<string, CommonAppDataEula> Eulas { get; set; }

    [JsonPropertyName("gameid")]
    public string GameId { get; set; }

    [JsonPropertyName("genres")]
    public Dictionary<string, string> Genres { get; set; }

    [JsonPropertyName("header_image")]
    public Dictionary<string, string> HeaderImage { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("languages")]
    public Dictionary<string, string> Languages { get; set; }

    [JsonPropertyName("library_assets")]
    public CommonAppLibraryAssets LibraryAssets { get; set; }

    [JsonPropertyName("logo")]
    public string Logo { get; set; }

    [JsonPropertyName("logo_small")]
    public string LogoSmall { get; set; }

    [JsonPropertyName("metacritic_fullurl")]
    public string MetacriticFullUrl { get; set; }

    [JsonPropertyName("metacritic_name")]
    public string MetacriticName { get; set; }

    [JsonPropertyName("metacritic_score")]
    public string MetacrtiticScore { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("primary_genre")]
    public string PrimaryGenre { get; set; }

    [JsonPropertyName("releasedstate")]
    public string ReleasedState { get; set; }

    [JsonPropertyName("review_percentage")]
    public string ReviewPercentage { get; set; }

    [JsonPropertyName("review_score")]
    public string ReviewScore { get; set; }

    [JsonPropertyName("small_capsule")]
    public Dictionary<string, string> SmallCapsule { get; set; }

    [JsonPropertyName("steam_deck_compatibility")]
    public CommonAppSteamDeckCompatibility SteamDeckCompatibility { get; set; }

    [JsonPropertyName("steam_release_date")]
    public string SteamReleaseDate { get; set; }

    [JsonPropertyName("store_asset_mtime")]
    public string SteamAssetMtime { get; set; }

    [JsonPropertyName("store_tags")]
    public Dictionary<string, string> StoreTags { get; set; }

    [JsonPropertyName("supported_languages")]
    public Dictionary<string, CommonAppSupportedLanguage> SupportedLanguages { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class CommonAppDataAssociation
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class CommonAppDataEula
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class CommonAppLibraryAssets
{
    [JsonPropertyName("library_capsule")]
    public string LibraryCapsule { get; set; }

    [JsonPropertyName("library_hero")]
    public string LibraryHero { get; set; }

    [JsonPropertyName("library_logo")]
    public string LibraryLogo { get; set; }

    [JsonPropertyName("logo_position")]
    public CommonAppLibraryAssetsLogoPosition LogoPosition { get; set; }
}

public class CommonAppLibraryAssetsLogoPosition
{
    [JsonPropertyName("height_pct")]
    public string HeightPct { get; set; }

    [JsonPropertyName("pinned_position")]
    public string PinnedPosition { get; set; }

    [JsonPropertyName("width_pct")]
    public string WidthPct { get; set; }
}

public class CommonAppSteamDeckCompatibility
{
    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("configuration")]
    public Dictionary<string, string> Configuration { get; set; }

    [JsonPropertyName("test_timestamp")]
    public string TestTimestamp { get; set; }

    [JsonPropertyName("tested_build_id")]
    public string TestedBuildId { get; set; }

    [JsonPropertyName("tests")]
    public Dictionary<string, CommonAppSteamDeckCompatibilityTest> Tests { get; set; }
}

public class CommonAppSteamDeckCompatibilityTest
{
    [JsonPropertyName("display")]
    public string Display { get; set; }

    [JsonPropertyName("token")]
    public string Token { get; set; }
}

public class CommonAppSupportedLanguage
{
    [JsonPropertyName("full_audio")]
    public string FullAudio { get; set; }

    [JsonPropertyName("subtitles")]
    public string Subtitles { get; set; }

    [JsonPropertyName("supported")]
    public string Supported { get; set; }
}

public class ConfigApp
{
    [JsonPropertyName("installdir")]
    public string InstallDir { get; set; }

    [JsonPropertyName("launch")]
    public ConfigAppLaunch Launch { get; set; }

    [JsonPropertyName("steamconfigurator3rdpartynative")]
    public string SteamConfigurator3rdPartyNative { get; set; }

    [JsonPropertyName("steamcontrollerconfigdetails")]
    public Dictionary<string, ConfigAppControllerConfig> SteamControllerConfigDetails { get; set; }

    [JsonPropertyName("steamcontrollertemplateindex")]
    public string SteamControllerTemplateIndex { get; set; }

    [JsonPropertyName("steamcontrollertouchconfigdetails")]
    public Dictionary<string, ConfigAppControllerTouchConfig> SteamControllerTouchConfigDetails { get; set; }

    [JsonPropertyName("steamcontrollertouchtemplateindex")]
    public string SteamControllerTouchTemplateIndex { get; set; }
}

public class ConfigAppLaunch
{
    [JsonPropertyName("arguments")]
    public string Arguments { get; set; }

    [JsonPropertyName("config")]
    public ConfigAppLaunchConfig Config { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("description_loc")]
    public Dictionary<string, string> DescriptionLoC { get; set; }

    [JsonPropertyName("executable")]
    public string Executable { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class ConfigAppLaunchConfig
{
    [JsonPropertyName("betakey")]
    public string Betakey { get; set; }

    [JsonPropertyName("osarch")]
    public string OSArch { get; set; }

    [JsonPropertyName("oslist")]
    public string OSList { get; set; }
}

public class ConfigAppControllerConfig
{
    [JsonPropertyName("controller_type")]
    public string ControllerType { get; set; }

    [JsonPropertyName("enabled_branches")]
    public string EnabledBranches { get; set; }

    [JsonPropertyName("use_action_block")]
    public string UseActionBlock { get; set; }
}

public class ConfigAppControllerTouchConfig
{
    [JsonPropertyName("controller_type")]
    public string ControllerType { get; set; }

    [JsonPropertyName("enabled_branches")]
    public string EnabledBranches { get; set; }

    [JsonPropertyName("use_action_block")]
    public string UseActionBlock { get; set; }
}

public class UfsApp
{
    [JsonPropertyName("maxnumfiles")]
    public string MaxNumFiles { get; set; }

    [JsonPropertyName("quota")]
    public string Quota { get; set; }

    [JsonPropertyName("savefiles")]
    public Dictionary<string, UfsAppSaveFile> SaveFiles { get; set; }
}

public class UfsAppSaveFile
{
    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("pattern")]
    public string Pattern { get; set; }

    [JsonPropertyName("recursive")]
    public string Recursive { get; set; }

    [JsonPropertyName("root")]
    public string Root { get; set; }
}
