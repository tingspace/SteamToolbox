namespace SteamCommon.Models;

public class Library
{
    public string Path { get; set; }

    public string? Label { get; set; }

    // TODO: Provide a string representing the size (IE: 1KB, 2MB, 3GB, etc)
    public long SizeInBytes { get; set; }

    // TODO: Add Apps/Games
}
