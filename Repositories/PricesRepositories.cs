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

    public async Task<PricesModel> CreatePrice(PricesRequest pricesRequest) 
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
}