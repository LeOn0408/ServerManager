using System.Net;
using Microsoft.EntityFrameworkCore;
using ServerManager.Data.Context;
using ServerManagerCore.Models;
using ServerManagerCore.Services;

namespace ServerManager.Data.Server;

public class ServerDataService : IServerDataService
{
    private readonly DataContext _db;

    public ServerDataService(DataContext db)
    {
        _db = db;
    }

    public List<ServerDto> GetActive()
    {
        throw new NotImplementedException();
    }

    public Task<List<ServerDto>> GetAll()
    {
        var servers = _db.ServerList.Include(p => p.ServerPublicInfo).Include(a => a.AdminInfo).Include(p=>p.Players).ToList();
        return Task.FromResult(servers);
    }

    public Task<ServerDto> AddServerInfo(ServerDto serverDto)
    {
        _db.ServerList.Add(serverDto);
        _db.SaveChanges();
        return Task.FromResult(serverDto);
    }
    public async Task<ServerDto> EditServerInfo(ServerDto server)
    {
        var serverData = await _db.ServerList.FirstOrDefaultAsync(s => s.Id == server.Id);
        if (serverData != null)
        {
            serverData = server;
            _db.SaveChanges();
        }
        var editServer = await _db.ServerList.FirstOrDefaultAsync(s => s.Id == server.Id);
        if (editServer != null)
            return editServer;
        else
            //TODO: Вывести ошибку во вьюшку
            throw new Exception("Error save server");
    }

}