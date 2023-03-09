using Microsoft.EntityFrameworkCore;
using ServerManager.Data.Context;
using ServerManagerCore.Models.Tasks;
using ServerManagerCore.Services;

namespace ServerManager.Data.Server
{
    public class ServerTaskDataService : IServerTaskDataService
    {
        private readonly DataContext _db;

        public ServerTaskDataService(DataContext db) => _db = db;

        public async Task<List<ServerTask>> GetTasksAsync()
        {
            return await _db.Tasks.ToListAsync();
        }

        public async Task<List<ServerTask>> GetTasksServerAsync(int serverId)
        {
            return await _db.Tasks.Where(server => server.ServerId == serverId).ToListAsync();
        }

        public async Task TaskUpdateAsync(ServerTask task)
        {
            _db.Tasks.Update(task);
            await _db.SaveChangesAsync();
        }
    }
}
