using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace ServerManagerCore.Models;

[Table("sm_server")]
public class ServerDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public TypeServer TypeServer { get; set; }
    public string? IpAddress { get; set; }
    public string? Path { get; set; }
    public bool Launched { get; set; }
    public ServerAdminInfoDto AdminInfo { get; set; } = new ServerAdminInfoDto();
    public ServerPublicInfo ServerPublicInfo { get; set; } = new ServerPublicInfo();
    public List<Player>? Players { get; set; } = new List<Player>();
}
[Table("sm_serverAdminInfo")]
public class ServerAdminInfoDto
{
    public int Id { get; set; }
    public ServerDto Server { get; set; } = null!;
    public int ServerId { get; set; }
    public string? RconAddress { get; set; }
    public string? RconPass { get; set; }
}
[Table("sm_serverPublicInfo")]
public class ServerPublicInfo
{
    public int Id { get; set; }
    public ServerDto Server { get; set; } = null!;
    public int ServerId { get; set; }
    public bool IsVisible { get; set; }
    public string? IP { get; set; }
    public string? Name { get; set; }
    public string? Map { get; set; }
    public string? Version { get; set; }

}
[Table("sm_players")]
public class Player
{
    public int Id { get; set; }
    public ServerDto Server { get; set; } = null!;
    public int ServerId { get; set; }
    public string? Name { get; set; }
    public string? SteamId { get; set; }
}