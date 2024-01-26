using API_FARMACIA_PM.Models;
using Microsoft.EntityFrameworkCore;
namespace API_FARMACIA_PM.Data.SqlServer;

public class SqlServerContext : DbContext
{
    public SqlServerContext(DbContextOptions options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Initial Catalog=master;User Id=sa;Password=SqlServer2019!;Encrypt=True;TrustServerCertificate=True"
        );
    }
    public DbSet<DiscountModel> Discounts { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<StoreModel> Stores { get; set; }
    public DbSet<TypeUserModel> TypeUserModels { get; set; }
    public DbSet<UserModel> Users { get; set; }
}
