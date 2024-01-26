using API_FARMACIA_PM.Data.SqlServer;
using API_FARMACIA_PM.Models;
using API_FARMACIA_PM.Requests;
using Microsoft.Identity.Client;

namespace API_FARMACIA_PM.Repositories;

public class DiscountRepository
{
    private readonly SqlServerContext _sqlServer;

    public DiscountRepository(SqlServerContext sqlServer)
    {
        _sqlServer = sqlServer;
    }

    public async Task<DiscountModel> CreateDiscount(DiscountRequest discountRequest) 
    {
       DiscountModel discountModel = new DiscountModel 
        {
            Value = discountRequest.Value,
            TypeUser = discountRequest.TypeUser 
        };

        var result = await _sqlServer.Discounts.AddAsync(discountModel);
        return result.Entity;

    }
}

