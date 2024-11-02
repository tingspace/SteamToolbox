using System.Runtime.Versioning;
using Microsoft.Win32;
using SteamCommon.Clients;
using SteamCommon.Models;
using VdfParser;

namespace SteamCommon.Services;

public interface ILibraryService : IService
{
    string GetInstallPath();
    List<string> GetLibraryLocations();
    List<Player> GetLocalPlayers();
}

public class LibraryService : ServiceBase, ILibraryService
{
    private const string SteamRegistryPath = "SOFTWARE\\WOW6432Node\\Valve\\Steam";
    private const string InstallPathValue = "InstallPath";

    private readonly object _lock = new object();


    private static string? SteamInstallPath { get; set; }

    public LibraryService(ServiceFactory serviceFactory, ClientFactory clientFactory) 
        : base(serviceFactory, clientFactory)
    {
    }

    [SupportedOSPlatform("Windows")]
    public string GetInstallPath()
    {
        if (!string.IsNullOrWhiteSpace(SteamInstallPath))
        {
            return SteamInstallPath;
        }

        RegistryKey? localMachine = Registry.LocalMachine;
        var steamRegistry = localMachine?.OpenSubKey(SteamRegistryPath);
        if (steamRegistry is null)
        {
            throw new Exception("Could not find Steam Registry");
        }

        var installPathValue = steamRegistry?.GetValue(InstallPathValue)?.ToString();
        if (string.IsNullOrWhiteSpace(installPathValue))
        {
            throw new Exception("Could not find InstallPath value in Steam Registry");
        }

        lock (_lock)
        {
            SteamInstallPath = installPathValue;
        }

        return installPathValue;
    }

    [SupportedOSPlatform("Windows")]
    public List<string> GetLibraryLocations()
    {
        var locations = new List<string>();
        var originalDirectory = Directory.GetCurrentDirectory();

        var installPath = GetInstallPath();

        // TODO: Handle potential failures
        Directory.SetCurrentDirectory(installPath);

        var libraryFolderPaths = $"{installPath}\\steamapps\\libraryfolders.vdf";

        if (!File.Exists(libraryFolderPaths))
        {
            throw new Exception($"Could not find Library Folders file at: {libraryFolderPaths}");
        }

        using FileStream? fs = File.OpenRead(libraryFolderPaths);
        var deserializer = new VdfDeserializer();
        var libraryFolders = deserializer.Deserialize<LibraryFolder>(fs);

        foreach (KeyValuePair<string, VdfLibrary> keypair in libraryFolders.LibraryFolders)
        {
            locations.Add(keypair.Key);
        }

        Directory.SetCurrentDirectory(originalDirectory);

        return locations;
    }

    [SupportedOSPlatform("Windows")]
    public List<Player> GetLocalPlayers()
    {
        var original = Directory.GetCurrentDirectory();

        try
        {
            var loginUsers = GetLocalUsers(GetInstallPath());

            List<Player> players = new();
            foreach (var user in loginUsers.Users)
            {
                players.Add(new Player
                {
                    SteamId = new SteamId(user.Key),
                    PlayerName = user.Value.PersonaName,
                    AccountName = user.Value.AccountName,
                    MostRecent = user.Value.MostRecent,
                    LastLoginTimestamp = int.Parse(user.Value.Timestamp),
                });
            }

            return players;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            Directory.SetCurrentDirectory(original);
        }
    }

    private static LoginUser GetLocalUsers(string installPath)
    {
        Directory.SetCurrentDirectory(
            installPath ??
            throw new ArgumentNullException("Provided installPath is null"));

        var loginUsersFile = $"{installPath}\\config\\loginusers.vdf";
        if (!File.Exists(loginUsersFile))
        {
            throw new Exception($"Could not find hte loginusers file at: {loginUsersFile}");
        }

        using FileStream? fs = File.OpenRead(loginUsersFile);
        VdfDeserializer deserializer = new VdfDeserializer();
        LoginUser? loginUsers = deserializer.Deserialize<LoginUser>(fs);

        return loginUsers is null 
            ? throw new Exception($"Failed to read: {loginUsersFile}") 
            : loginUsers;
    }
}
