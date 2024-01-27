using API_FARMACIA_PM.Data.SqlServer;
using API_FARMACIA_PM.Models;
using API_FARMACIA_PM.Requests;
using Microsoft.Identity.Client;

namespace API_FARMACIA_PM.Repositories;

public class StoreRepository(SqlServerContext sqlServer)
{
    private readonly SqlServerContext _sqlServer = sqlServer;

    public async Task<StoreModel> CreateStore(StoreRequest storeRequest) 
    {
        StoreModel storeModel = new StoreModel 
        {
            Name = storeRequest.Name,
            Location = storeRequest.Location,
            Phone = storeRequest.Phone,
            Manager = storeRequest.Manager
        };

        var result = await _sqlServer.Stores.AddAsync(storeModel);
        await _sqlServer.SaveChangesAsync();
        return result.Entity;

    }
}

