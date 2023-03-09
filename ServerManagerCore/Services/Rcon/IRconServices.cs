using ServerManagerCore.Models;

namespace ServerManagerCore.Services.Rcon
{
    public interface IRconServices
    {
        List<Player> GetPlayers(ServerAdminInfoDto server);
    }
}