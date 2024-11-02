namespace SteamCommon;

using SteamCommon.Clients;
using SteamCommon.Exceptions;
using SteamCommon.Services;

public static class CommonSetupHelper
{
    public static Configuration GetConfiguration()
    {
        var config = new Configuration();
        const string apiKey = "STEAM_API_KEY";

        config.SteamDevKey = GetEnvVar(apiKey);
        return config;
    }

    private static string GetEnvVar(string keyName)
    {
        var value = Environment.GetEnvironmentVariable(keyName);
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new MissingConfigurationException(keyName);
        }

        return value;
    }

    public static ServiceFactory GetServiceFactory(Configuration configuration)
    {
        var (serviceFactory, _) = BuildCommonFactories(configuration);

        return serviceFactory;
    }

    private static (ServiceFactory, ClientFactory) BuildCommonFactories(Configuration configuration)
    {
        var clientFactory = BuildClientFactory(configuration);
        var serviceFactory = BuildServiceFactory(clientFactory, configuration);

        return (serviceFactory, clientFactory);
    }

    private static ServiceFactory BuildServiceFactory(ClientFactory clientFactory, Configuration configuration)
    {
        var serviceFactory = new ServiceFactory(clientFactory);
        RegisterServices(serviceFactory, clientFactory, configuration);

        return serviceFactory;
    }

    private static ClientFactory BuildClientFactory(Configuration configuration)
    {
        var clientFactory = new ClientFactory();
        RegisterClients(clientFactory, configuration);

        return clientFactory;
    }


    private static void RegisterServices(ServiceFactory serviceFactory, ClientFactory clientFactory, Configuration config)
    {
        // TODO: Scan current assembly to load interfaces inheriting from IService

        // Manual registration :(
        serviceFactory.RegisterService<ILibraryService>((sf, cf) => new LibraryService(sf, cf));
        serviceFactory.RegisterService<IGameService>((sf, cf) => new GameService(sf, cf));
    }

    private static void RegisterClients(ClientFactory clientFactory, Configuration config)
    {
        clientFactory.RegisterClient<ICommunityApiClient>(() => new CommunityApiClient());
        clientFactory.RegisterClient<IWebApiClient>(() => new WebApiClient(config));
        clientFactory.RegisterClient<IStoreApiClient>(() => new StoreApiClient());
        clientFactory.RegisterClient<ISteamCMDClient>(() => new SteamCMDClient());
    }
}
