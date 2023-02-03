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
    public string? PublicIP { get; set; }

}
[Table("sm_players")]
public class Players
{
    public int Id { get; set; }
    public ServerDto Server { get; set; } = null!;
    public int ServerId { get; set; }
    public string Name { get; set; }
    public string SteamId { get; set; }
}