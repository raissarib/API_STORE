using API_FARMACIA_PM.Data.SqlServer;
using API_FARMACIA_PM.Models;
using API_FARMACIA_PM.Requests;
using Microsoft.Identity.Client;

namespace API_FARMACIA_PM.Repositories;

public class StoreRepository
{
    private readonly SqlServerContext _sqlServer;

    public StoreRepository(SqlServerContext sqlServer)
    {
        _sqlServer = sqlServer;
    }

    public async Task<StoreModel> CreateStore(StoreRequest storeRequest) 
    {
        StoreModel storeModel = new StoreModel 
        {
            Number = storeRequest.Number,
            Products = storeRequest.Products,
            Name = storeRequest.Name,
            City = storeRequest.City,
            Phone = storeRequest.Phone
        };

        var result = await _sqlServer.Stores.AddAsync(storeModel);
        return result.Entity;

    }
}

