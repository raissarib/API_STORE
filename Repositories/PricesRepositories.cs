using API_FARMACIA_PM.Data.SqlServer;
using API_FARMACIA_PM.Models;
using API_FARMACIA_PM.Requests;

namespace API_FARMACIA_PM.Repositories;

public class PricesRepository
{
    private readonly SqlServerContext _sqlServer;

    public PricesRepository(SqlServerContext sqlServer)
    {
        _sqlServer = sqlServer;
    }

    public async Task<PricesModel> CreatePrices(PricesRequest pricesRequest) 
    {
        PricesModel pricesModel = new PricesModel 
        {
            ProductId = pricesRequest.ProductId,
            Price = pricesRequest.Price,
            EffectiveDate = pricesRequest.EffectiveDate,
            EndDate = pricesRequest.EndDate
               
        };

        var result = await _sqlServer.Prices.AddAsync(pricesModel);
        await _sqlServer.SaveChangesAsync();
        return result.Entity;

    }

    public async Task<PricesModel?> GetPrices(int id)
    {
        return await _sqlServer.Prices.FindAsync(id);
    }

    public async Task<PricesModel?> UpdatePrices(UpdatePricesRequest updatePricesRequest)
    {
        PricesModel? prices = await _sqlServer.Prices.FindAsync(updatePricesRequest.Id);
        if (prices is not null)
        {
            prices.Price = updatePricesRequest.Price;
            prices.EffectiveDate = updatePricesRequest.EffectiveDate;
            prices.EndDate = updatePricesRequest.EndDate;
            await _sqlServer.SaveChangesAsync();
            return prices;
        }
        return null;
    }

    public async Task<PricesModel?> DeletePrices(int id)
    {
        PricesModel? prices = await _sqlServer.Prices.FindAsync(id);
        if (prices is not null)
        {
            _sqlServer.Prices.Remove(prices);
            await _sqlServer.SaveChangesAsync();
            return prices;
        }
        return null;
    }


}