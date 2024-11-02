using SteamCommon.Clients;
using SteamCommon.Exceptions;

namespace SteamCommon.Services;

public class ServiceFactory
{
    private Dictionary<Type, Func<ServiceFactory, ClientFactory, IService>> _serviceMap;

    private readonly ClientFactory _clientFactory;

    public ServiceFactory(ClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _serviceMap = new();
    }

    public bool RegisterService<T>(Func<ServiceFactory, ClientFactory, IService> constructorFunc) where T : IService
    {
        return _serviceMap.TryAdd(typeof(T), constructorFunc);
    }

    public T GetService<T>() where T : IService
    {
        return (T)GetService(typeof(T));
    }

    public IService GetService(Type serviceType)
    {
        if (_serviceMap.TryGetValue(serviceType, out var func))
        {
            return func(this, _clientFactory);
        }

        throw new UnknownServiceType(serviceType);
    }
}
