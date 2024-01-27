using API_FARMACIA_PM.Data.SqlServer;
using API_FARMACIA_PM.Models;
using API_FARMACIA_PM.Requests;
using Microsoft.EntityFrameworkCore;
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

    public async Task<StockModel?> GetStock(int id)
    {
        return await _sqlServer.Stocks.Include(p => p.Store).Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<StockModel?> UpdateStock(UpdateStockRequest updateStockRequest)
    {
        StockModel? stock = await _sqlServer.Stocks.FindAsync(updateStockRequest.Id);
        if (stock is not null)
        {
            stock.Quantity = updateStockRequest.Quantity;
            await _sqlServer.SaveChangesAsync();
            return stock;
        }
        return null;
    }

    public async Task<StockModel?> DeleteStock(int id)
    {
        StockModel? stock = await _sqlServer.Stocks.FindAsync(id);
        if (stock is not null)
        {
            _sqlServer.Stocks.Remove(stock);
            await _sqlServer.SaveChangesAsync();
            return stock;
        }
        return null;
    }
}