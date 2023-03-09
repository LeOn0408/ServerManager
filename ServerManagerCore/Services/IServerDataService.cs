using ServerManagerCore.Models;

namespace ServerManagerCore.Services
{
    public interface IServerDataService
    {
        Task<ServerDto> AddServerInfo(ServerDto serverDto);
        Task<ServerDto> EditServerInfo(ServerDto server);
        List<ServerDto> GetActive();
        Task<List<ServerDto>> GetAll();
    }
}