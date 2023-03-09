
using Microsoft.Extensions.DependencyInjection;
using ServerManager.Data.Context;
using ServerManager.Data.Server;
using ServerManagerCore.Models.Tasks;
using ServerManagerCore.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerManager.Data
{
    internal class ServerJobs : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<IHostedService> _logger;

        public ServerJobs(IServiceProvider serviceProvider, ILogger<IHostedService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
           

            IServerDataService serverData = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ServerDataService>();
            IServerTaskDataService serverTaskData = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ServerTaskDataService>();


            JobCreator job = new(_logger, serverTaskData,serverData);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}