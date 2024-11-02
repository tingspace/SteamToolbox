namespace SteamCommon.Exceptions;

public class UnknownServiceType : Exception
{
    public UnknownServiceType(Type serviceName) 
        : base($"Service Type: {nameof(serviceName)} unknown in Service Factory")
    {
    }
}
