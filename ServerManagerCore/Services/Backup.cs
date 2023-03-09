using A2S;
using ServerManagerCore.Models;
using System.IO.Compression;

namespace ServerManagerCore.Services
{
    public class Backup
    {
        private readonly ServerDto _server;

        public Backup(ServerDto server)
        {
            _server = server;
        }

        public Task LaunchBackup()
        {
            if (string.IsNullOrEmpty(_server.Path))
                return Task.CompletedTask;

            string savepath = Path.Combine(_server.Path, GetDataPath(_server.TypeServer));

            string targetPath = GetTargetPath();

            if (!File.Exists(targetPath))
            {
                ZipFile.CreateFromDirectory(savepath, targetPath);
            }
            return Task.CompletedTask;
        }

        private string GetTargetPath()
        {
            if (string.IsNullOrEmpty(_server.Path))
                return string.Empty;

            string targetDirectory = Path.Combine(_server.Path, "backup");
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }
            string targetPath = Path.Combine(targetDirectory, $"{_server.Name}{DateTime.Today:yyyyMMdd}.zip");
            return targetPath;
        }

        /// <summary>
        /// TODO: Написать код восстановления
        /// </summary>
        //public Task RestoreBackup()
        //{
        //    return Task.CompletedTask;
        //}


        private string GetDataPath(TypeServer typeServer)
        {
            switch (typeServer)
            {
                case TypeServer.Ark:
                    return "ShooterGame/Saved/SavedArks";
                case TypeServer.Minecraft:
                    return "world";
                default:
                    return "";
            }
        }
    }
}