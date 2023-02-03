using System.Net;
using ServerManagerCore.Models;

namespace ServerManagerCore.Data;

public class ServerDataService
{
    private IDataContext _db;

    public ServerDataService(IDataContext db)
    {
        _db = db;
    }

    public List<ServerDto> GetActive()
    {
        throw new NotImplementedException();
    }

    public Task<List<ServerDto>> GetAll()
    {
        return Task.FromResult(_db.ServerList.ToList());
    }
    
    public Task<ServerDto> AddServerInfo(Models.ServerDto serverDto)
    {
        //TODO: реализовать хранение данных
        return Task.FromResult(serverDto);
    }


}