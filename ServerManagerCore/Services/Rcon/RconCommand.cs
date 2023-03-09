using CoreRCON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerManagerCore.Services.Rcon
{
    public class RconCommand
    {
        public RconCommand(string ip, string? pass, ushort port)
        {
            Ip = ip;
            Pass = pass;
            Port = port;
        }

        public string Ip { get; }
        public string? Pass { get; }
        public ushort Port { get; }

        public async Task<string> GetRconAsync(string cmd)
        {

            try
            {

                RCON rcon = new(IPAddress.Parse(Ip), Port, Pass);
                await rcon.ConnectAsync();
                string rconReq = await rcon.SendCommandAsync(cmd);
                return rconReq;
            }

            catch (Exception)
            {
                //TODO: Обработать ошибки
                return string.Empty;
            }
        }
        public async void SetRconAsync(string cmd)
        {
            try
            {
                using RCON rcon = new(IPAddress.Parse(Ip), Port, Pass);
                await rcon.ConnectAsync();
                string rconReq = await rcon.SendCommandAsync(cmd);

            }
            catch (Exception)
            {

            }
        }
    }
}
