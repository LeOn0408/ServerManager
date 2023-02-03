using System.Diagnostics;

namespace ServerManagerCore.Servers;

public class ArkServer : IServer
{
    

    public ArkServer(Models.ServerDto serverDto)
    {
        ServerInfo = serverDto;
        Id = ServerInfo.Id;
    }

    public int Id { get; init; }
    public Models.ServerDto ServerInfo{ get;}
    public bool Run()
    {
        var proc = Process.Start(new ProcessStartInfo {
            Arguments = "/C explorer",
            FileName = "cmd",
            WindowStyle = ProcessWindowStyle.Hidden });
        return true;
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

