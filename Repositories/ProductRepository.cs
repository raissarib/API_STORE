using API_FARMACIA_PM.Data.SqlServer;
using API_FARMACIA_PM.Models;
using API_FARMACIA_PM.Requests;
using Microsoft.EntityFrameworkCore;

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
            Manufacturer = productRequest.Manufacturer,
            Description = productRequest.Description,
            Brand = productRequest.Brand
        };

        var result = await _sqlServer.Products.AddAsync(productModel);
        await _sqlServer.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<ProductModel?> GetProduct(int id)
    {
        return await _sqlServer
            .Products.Include(p => p.Prices)
            .Include(p => p.Stocks)
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<ProductModel?> UpdateProduct(UpdateProductRequest updateProductRequest)
    {
        ProductModel? product = await _sqlServer.Products.FindAsync(updateProductRequest.Id);
        if (product is not null)
        {
            product.Name = updateProductRequest.Name;
            await _sqlServer.SaveChangesAsync();
            return product;
        }
        return null;
    }

    public async Task<ProductModel?> DeleteProduct(int id)
    {
        ProductModel? product = await _sqlServer.Products.FindAsync(id);
        if (product is not null)
        {
            _sqlServer.Products.Remove(product);
            await _sqlServer.SaveChangesAsync();
            return product;
        }
        return null;
    }

    public async Task<IEnumerable<StockModel>> GetProductsStore(int storeId)
    {
        return await _sqlServer.Stocks.Include(p => p.Product).Where(p => p.StoreId == storeId).ToListAsync();
    }
}
