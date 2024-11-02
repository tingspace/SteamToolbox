namespace SteamCommon.Exceptions;

public class UnknownClientType : Exception
{
    public UnknownClientType(Type clientType)
        : base($"Client Type: {nameof(clientType)} unknown in Client Factory")
    {
    }
}
