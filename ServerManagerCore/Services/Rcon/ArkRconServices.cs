using A2S;
using A2S.Structs;
using CoreRCON;
using CoreRCON.Parsers.Standard;
using ServerManagerCore.Models;
using ServerManagerCore.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Player = ServerManagerCore.Models.Player;

namespace ServerManagerCore.Services.Rcon
{
    internal class ArkRconServices : IRconServices
    {
        public async Task<List<Player>> GetPlayers(ServerAdminInfoDto server)
        {
            List<Player> players = new();
            if (server.RconAddress is null)
            {
                return players;
            }
            if (IPEndPoint.TryParse(server.RconAddress, out IPEndPoint? ipAddress) && ipAddress is not null)
            {
                string rconCMD = await new RconCommand(ipAddress.Address.ToString(), server.RconPass, (ushort)ipAddress.Port).GetRconAsync("listplayers");
                if (!string.IsNullOrEmpty(rconCMD) && rconCMD is not "No Players Connected")
                {
                    rconCMD = rconCMD.Remove(0, 2);
                    string[] words = rconCMD.Split("\r\n");
                    foreach (string w in words)
                    {
                        Player player = new();
                        string[] idSplit = w.Split(", ");
                        string[] nameSplit = idSplit[0].Split(". ");
                        player.SteamId = idSplit[1];
                        player.Name = nameSplit[1];
                        players.Add(player);

                    }
                }
            }
            return players;
        }


    }
}
