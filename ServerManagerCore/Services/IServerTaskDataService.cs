using ServerManagerCore.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManagerCore.Services
{
    public interface IServerTaskDataService
    {
        public Task<List<ServerTask>> GetTasksAsync();
        public Task<List<ServerTask>> GetTasksServerAsync(int serverId);
        public Task TaskUpdateAsync(ServerTask task);
    }
}
