namespace SteamCommon.Clients;

public abstract class ClientBase : IClient
{
    protected HttpClient HttpClient { get; }

    protected ClientBase()
    {
        // TODO: Manage through Dependency injection
        HttpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
    }
}
