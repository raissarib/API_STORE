using System.Text.Json.Serialization;
using API_FARMACIA_PM.Data.SqlServer;
using API_FARMACIA_PM.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SqlServerContext>();

// Add services to the container.
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<StoreRepository>();
builder.Services.AddScoped<StockRepository>();
builder.Services.AddScoped<PricesRepository>();

builder.Services.AddControllers().AddJsonOptions(c => c.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
