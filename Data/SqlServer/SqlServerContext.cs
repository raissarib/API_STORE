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
}
