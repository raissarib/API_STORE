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
            "Server=localhost;Initial Catalog=API_FARMACIA;User Id=sa;Password=SqlServer2019!;Encrypt=True;TrustServerCertificate=True"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StoreModel>(p =>
        {
            p.HasKey(x=>x.Id);
            p.Property(x => x.Id).UseIdentityColumn();
            p.Property(x => x.Name).IsRequired();
            p.Property(x => x.Location).IsRequired();
            p.Property(x => x.Phone).IsRequired();
            p.Property(x => x.Manager).IsRequired();
        });

        modelBuilder.Entity<PricesModel>(p =>
        {
            p.HasKey(x=>x.Id);
            p.Property(x => x.Id).UseIdentityColumn();
            p.Property(x => x.Price).IsRequired();
            p.Property(x => x.EffectiveDate).IsRequired();
            p.Property(x => x.EndDate).IsRequired();

            p.HasOne(x => x.Product)
            .WithMany(x => x.Prices)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductModel>(p =>
        {
            p.HasKey(x=>x.Id);
            p.Property(x => x.Id).UseIdentityColumn();
            p.Property(x => x.Name).IsRequired();
            p.Property(x => x.Manufacturer).IsRequired();
            p.Property(x => x.Description).IsRequired();
            p.Property(x => x.Brand).IsRequired();
        });

        modelBuilder.Entity<StockModel>(p =>
        {
            p.HasKey(x=>x.Id);
            p.Property(x => x.Id).UseIdentityColumn();
            p.Property(x => x.Quantity).IsRequired();

            p.HasMany(x => x.Products)
            .WithOne(x => x.Stock)
            .OnDelete(DeleteBehavior.ClientSetNull);

            p.HasOne(x => x.Store)
            .WithOne(x => x.Stock)
            .OnDelete(DeleteBehavior.ClientSetNull);
        });

    }

    public DbSet<PricesModel> Prices { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<StockModel> Stocks { get; set; }
    public DbSet<StoreModel> Stores { get; set; }

}
