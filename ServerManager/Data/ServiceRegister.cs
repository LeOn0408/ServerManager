using Microsoft.EntityFrameworkCore;
using ServerManager.Data.Context;
using ServerManagerCore.Data;

namespace ServerManager.Data
{
    public class ServiceRegister
    {
        private readonly ConfigurationManager _configuration;
        private readonly IServiceCollection _services;

        public ServiceRegister(ConfigurationManager configuration, IServiceCollection services)
        {
            _configuration = configuration;
            _services = services;
        }

        internal void Register()
        {
            DataBaseRegister();
            _services.AddRazorPages();
            _services.AddServerSideBlazor();
            _services.AddTransient<ServerManagerCore.Data.ServerDataService>();
        }
        private void DataBaseRegister()
        {
            if (!bool.TryParse(_configuration.GetSection("Database").GetSection("MySql").GetSection("Use").Value, out bool useMysql))
            {
                return;
            }
            if (!useMysql)
            {
                return;
            }
            string? connection = _configuration.GetSection("Database").GetSection("MySql").GetSection("DefaultConnection").Value;
            if (connection == null) throw new Exception("DefaultConnection is empty");
            ServerVersion vesrion = ServerVersion.AutoDetect(connection);
            _services.AddDbContext<IDataContext,DataContext>(options =>
                options.UseMySql(connection, vesrion,
                mySqlOptions =>
                {
                    mySqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 1,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorNumbersToAdd: null);
                }));

        }
    }
}
