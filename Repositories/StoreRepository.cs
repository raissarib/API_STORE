using API_FARMACIA_PM.Data.SqlServer;
using API_FARMACIA_PM.Models;
using API_FARMACIA_PM.Requests;
using Microsoft.EntityFrameworkCore;

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

    public async Task<StoreModel?> GetStore(int id)
    {
        return await _sqlServer.Stores.Include(p => p.Stocks).Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<StoreModel?> UpdateStore(UpdateStoreRequest updateStoreRequest)
    {
        StoreModel? store = await _sqlServer.Stores.FindAsync(updateStoreRequest.Id);
        if (store is not null)
        {
            store.Phone = updateStoreRequest.Phone;
            store.Manager = updateStoreRequest.Manager;
            await _sqlServer.SaveChangesAsync();
            return store;
        }
        return null;
    }

    public async Task<StoreModel?> DeleteStore(int id)
    {
        StoreModel? store = await _sqlServer.Stores.FindAsync(id);
        if (store is not null)
        {
            _sqlServer.Stores.Remove(store);
            await _sqlServer.SaveChangesAsync();
            return store;
        }
        return null;
    }
}
