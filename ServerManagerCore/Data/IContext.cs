using Microsoft.EntityFrameworkCore;
using ServerManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManagerCore.Data
{
    public interface IDataContext
    {
        public DbSet<ServerDto> ServerList { get; set; }
        public DbSet<ServerAdminInfoDto> ServersAdminInfo { get; set; }
        public DbSet<ServerPublicInfo> ServersPublicInfo { get; set; }
        public DbSet<Players> Players { get; set; }
    }
}
