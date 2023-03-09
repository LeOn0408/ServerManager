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

    public async Task<ServerDto>? GetAsync(int id)
    {
        return await _db.ServerList.Include(p => p.ServerPublicInfo).Include(a => a.AdminInfo)?.Include(p => p.Players).FirstOrDefaultAsync(server => server.Id == id);
    }

    public async Task<List<ServerDto>> GetAllAsync()
    {
        var servers = await _db.ServerList.Include(p => p.ServerPublicInfo).Include(a => a.AdminInfo).Include(p=>p.Players).ToListAsync();
        return servers;
    }

    public async Task<ServerDto> AddServerInfoAsync(ServerDto serverDto)
    {
        _db.ServerList.Add(serverDto);
        await _db.SaveChangesAsync();
        return serverDto;
    }
    public async Task<ServerDto> EditServerInfoAsync(ServerDto server)
    {
        var serverData = await _db.ServerList.FirstOrDefaultAsync(s => s.Id == server.Id);
        if (serverData != null)
        {
            serverData = server;
            await _db.SaveChangesAsync();
        }
        var editServer = await _db.ServerList.FirstOrDefaultAsync(s => s.Id == server.Id);
        if (editServer != null)
            return editServer;
        else
            //TODO: Вывести ошибку во вьюшку
            throw new Exception("Error save server");
    }

}