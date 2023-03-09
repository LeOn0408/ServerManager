using A2S;
using ServerManagerCore.Models;
using ServerManagerCore.Services.Rcon;
using System.Net;

namespace ServerManagerCore.Services
{
    public class ServerServices
    {
        private readonly IServerDataService _serverData;
        private readonly ServerDto _server;
        private readonly IRconServices _rconServices;

        public ServerServices(IServerDataService serverData, ServerDto server)
        {
            _serverData = serverData;
            _server = server;
            _rconServices = new RconServicesBuilder(server.TypeServer).Get();
        }

        public async Task<List<Player>> GetPlayersInfo() => await _rconServices.GetPlayers(_server.AdminInfo);
        public async Task SavePlayerInfo()
        {
            var players = await _rconServices.GetPlayers(_server.AdminInfo);
            foreach (var player in players)
            {
                var sPlayer = _server?.Players?.FirstOrDefault(p => p.SteamId == player.SteamId);
                if(sPlayer is null)
                {
                    _server?.Players?.Add(player);
                }
            }
            await _serverData.EditServerInfoAsync(_server);
        }
        public Task SavePublicInfo()
        {
            if (_server.IpAddress is null)
            {
                _server.Launched = false;
                return Task.CompletedTask;
            }
            if (IPEndPoint.TryParse(_server.IpAddress, out IPEndPoint? ipAddress) && ipAddress is not null)
            {
                try
                {
                    dynamic serverSteam = Server.Query(ipAddress.Address.ToString(), ipAddress.Port, 5);
                    if (serverSteam is not Exception and not null)
                    {
                        _server.Launched = true;
                        _server.ServerPublicInfo.Name = serverSteam.Name;
                        _server.ServerPublicInfo.Map = serverSteam.Map;
                        string[] MapAndVersion = serverSteam.Name.Split("- (v");
                        _server.ServerPublicInfo.Version = MapAndVersion[1].Trim(')');

                        _serverData.EditServerInfoAsync(_server);
                        #region
                        //    var response = $@"
                        //Protocol: {server.Protocol}
                        //Name: {server.Name}
                        //Map: {server.Map}
                        //Folder: {server.Folder}
                        //Game: {server.Game}
                        //ID: {server.Id}
                        //Players: {server.Players}
                        //Max Players: {server.MaxPlayers}
                        //Bots: {server.Bots}
                        //Server Type: {server.ServerType}
                        //Environment: {server.Environment}
                        //Visibility: {server.Visibility}
                        //VAC: {server.Vac}
                        //Version: {server.Version}
                        //ExtraDataFlags:
                        //    Port: {server.Port}
                        //    SteamId: {server.SteamId}
                        //    Spectator:
                        //        Name: {server.Spectator}
                        //        Port: {server.SpectatorPort}
                        //    Keywords: {server.Keywords}
                        //    GameId: {server.GameId}";

                        #endregion
                    }
                    else
                    {
                        _server.Launched = false;
                    }
                }
                catch(Exception ex) { };

                
                return Task.CompletedTask;
            }
            else 
            {
                _server.Launched = false;
                return Task.CompletedTask; 
            }
        }
    }
}
