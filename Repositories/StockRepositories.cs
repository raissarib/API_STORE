using API_FARMACIA_PM.Data.SqlServer;
using API_FARMACIA_PM.Models;
using API_FARMACIA_PM.Requests;
using Microsoft.Identity.Client;

namespace API_FARMACIA_PM.Repositories;

public class StockRepository(SqlServerContext sqlServer)
{
    private readonly SqlServerContext _sqlServer = sqlServer;

    public async Task<StockModel> CreateStock(StockRequest stockRequest) 
    {
        StockModel stockModel = new StockModel 
        {
            StoreId = stockRequest.StoreId,
            ProductId = stockRequest.ProductId,
            Quantity = stockRequest.Quantity
        };

        var result = await _sqlServer.Stocks.AddAsync(stockModel);
        await _sqlServer.SaveChangesAsync();
        return result.Entity;

    }
}