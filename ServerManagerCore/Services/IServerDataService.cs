using ServerManagerCore.Models;

namespace ServerManagerCore.Services
{
    public interface IServerDataService
    {
        Task<ServerDto> AddServerInfoAsync(ServerDto serverDto);
        Task<ServerDto> EditServerInfoAsync(ServerDto server);
        Task<ServerDto>? GetAsync(int id);
        Task<List<ServerDto>> GetAllAsync();
    }
}