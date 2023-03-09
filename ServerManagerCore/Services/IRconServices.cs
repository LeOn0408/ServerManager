using ServerManagerCore.Models;

namespace ServerManagerCore.Services
{
    public interface IRconServices
    {
        List<Player> GetPlayers(ServerAdminInfoDto server);
    }
}