namespace SteamCommon.Exceptions;

public class MissingConfigurationException : Exception
{
    public MissingConfigurationException(string configurationKey)
        : base($"Key: {configurationKey} missing in Environment Variables")
    {
    }
}
