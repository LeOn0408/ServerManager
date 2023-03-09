using ServerManagerCore.Models;

namespace ServerManagerCore.Services.Rcon
{
    public interface IRconServices
    {
        Task<List<Player>> GetPlayers(ServerAdminInfoDto server);
    }
}