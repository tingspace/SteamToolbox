using SteamCommon.Clients;

namespace SteamCommon.Services;

public abstract class ServiceBase
{
    protected readonly ServiceFactory _serviceFactory;
    protected readonly ClientFactory _clientFactory;

    protected ServiceBase(ServiceFactory serviceFactory, ClientFactory clientFactory)
    {
        _serviceFactory = serviceFactory;
        _clientFactory = clientFactory;
    }
}
