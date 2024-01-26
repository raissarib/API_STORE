using API_FARMACIA_PM.Data.SqlServer;
using API_FARMACIA_PM.Models;
using API_FARMACIA_PM.Requests;
using Microsoft.Identity.Client;

namespace API_FARMACIA_PM.Repositories;

public class ProductRepository
{
    private readonly SqlServerContext _sqlServer;

    public ProductRepository(SqlServerContext sqlServer)
    {
        _sqlServer = sqlServer;
    }

    public async Task<ProductModel> CreateProduct(ProductRequest productRequest) 
    {
        ProductModel productModel = new ProductModel 
        {
            Name = productRequest.Name,
            Price = productRequest.Price,
            ExpirationDate = productRequest.ExpirationDate
        };

        var result = await _sqlServer.Products.AddAsync(productModel);
        return result.Entity;

    }
}

