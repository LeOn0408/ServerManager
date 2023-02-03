namespace ServerManagerCore.Servers;

public interface IServer
{
    public int Id { get; init; }
    public Models.ServerDto ServerInfo{ get;}
    public bool Run();
    public bool Stop();
    public bool Save();
}