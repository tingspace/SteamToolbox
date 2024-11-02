namespace SteamCommon.Clients;

using SteamCommon.Exceptions;

public class ClientFactory
{
    private Dictionary<Type, Func<IClient>> _clientMap = new();

    public bool RegisterClient<T>(Func<IClient> constructorFunc)
    {
        return _clientMap.TryAdd(typeof(T), constructorFunc);
    }

    public T GetClient<T>() where T : IClient
    {
        return (T)GetClient(typeof(T));
    }

    public IClient GetClient(Type clientType)
    {
        if (_clientMap.TryGetValue(clientType, out var func))
        {
            return func();
        }

        throw new UnknownClientType(clientType);
    }
}
