using ServerManagerCore;
using ServerManagerCore.Models;
using ServerManagerCore.Servers;

namespace ServerManager.Api;

public class ApiRouter
{
    private readonly WebApplication _app;

    
    public ApiRouter(WebApplication app)
    {
        _app = app;
    }

    public void SetRouting()
    {
        _app.MapPut("/api/server/state/run", RunServer);
    }

    private static IResult RunServer(ServerDto serverInfo)
    {
        return Results.Json("Sorry!Not Working");
    }
}