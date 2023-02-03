using ServerManagerCore.Models;

namespace ServerManagerCore.Servers;

public class MinecraftServer:IServer
{
    public MinecraftServer(ServerDto serverDto)
    {
        ServerInfo = serverDto;
        Id = serverDto.Id;
    }

    public int Id { get; init; }
    public ServerDto ServerInfo { get; }
    public bool Run()
    {
        throw new NotImplementedException();
    }

    public bool Stop()
    {
        throw new NotImplementedException();
    }

    public bool Save()
    {
        throw new NotImplementedException();
    }
}