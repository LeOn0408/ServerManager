using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using ServerManager.Data.User;
using ServerManagerCore.Models;
using ServerManagerCore.Models.Tasks;
using System.Text;

namespace ServerManager.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<UserDto> UserList => Set<UserDto>();
        public DbSet<ServerDto> ServerList { get; set; }
        public DbSet<ServerAdminInfoDto> ServersAdminInfo { get; set; }
        public DbSet<ServerPublicInfo> ServersPublicInfo { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<ServerTask> Tasks { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<UserDto>().HasData(new UserDto { Id = 1, Name = "admin", Group=Group.PortalAdministrator, Password= "xW2PqVk+e29mqX3T2aZAYPuBl5e4SKVeKDXfvU9XC9g=" });
        }
        
    }
}
