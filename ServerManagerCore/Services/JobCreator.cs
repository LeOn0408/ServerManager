using A2S;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServerManagerCore.Models.Tasks;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServerManagerCore.Services
{
    public class JobCreator
    {
        private readonly ILogger _logger;
        private readonly IServerTaskDataService _serverTaskData;
        private readonly IServerDataService _serverDataService;

        private Dictionary<int, ServerTask> ActiveTask { get; set; }

        private Timer timer;

        public JobCreator(ILogger logger, IServerTaskDataService serverTaskData, IServerDataService serverDataService)
        {

            _logger = logger;
            _serverTaskData = serverTaskData;
            _serverDataService = serverDataService;

            ActiveTask = new Dictionary<int, ServerTask>();

            timer = new(Start, null, 0, 60000);
        }
        private async void Start(object? state)
        {
             foreach (ServerTask task in await _serverTaskData.GetTasksAsync())
            {
                bool activeTask = ActiveTask.ContainsKey(task.Id);
                //вычислить разницу
                TimeSpan timeToJob = task.DateJob.Subtract(DateTime.Now);
                if (timeToJob.Hours <= 0 && timeToJob.Minutes <= 1 && !activeTask)
                {
                    ActiveTask.Add(task.Id, task);
                    await Task.Run(() => JobsCreated(task));
                }
            }
        }
        private async void JobsCreated(ServerTask task)
        {
            TimeSpan timeToJob = task.DateJob.Subtract(DateTime.Now);
            if (timeToJob.TotalMilliseconds > 0)
            {
                Thread.Sleep(timeToJob);
            }

            if (task.Repeating)
            {
                task.DateJob = task.DateJob.Add(task.RepeatingTime);
            }
            var update = _serverTaskData.TaskUpdateAsync(task);
            ActiveTask.Remove(task.Id);

            var server = _serverDataService.GetAsync(task.ServerId);

            if (server is null)
                return;

            try
            {
                switch (task.Type)
                {
                    case TaskType.Backup:
                            await new Backup(await server).LaunchBackup();
                        break;
                    default: break;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка");
            }

            await update;
        }
    }
}
