namespace SteamCommon.Models;

public class LibraryFolder
{
    public Dictionary<string, VdfLibrary> LibraryFolders { get; set; }
}

public class VdfLibrary
{
    public string path { get; set; }

    public string label { get; set; }

    public string contentid { get; set; }

    public string totalsize { get; set; }

    public string update_clean_bytes_tally { get; set; }

    public string time_last_update_corruption { get; set; }

    // AppId, SizeOnDisk
    public Dictionary<string, string> apps { get; set; }
}
