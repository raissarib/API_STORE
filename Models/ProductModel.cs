using System.Text.Json.Serialization;

namespace API_FARMACIA_PM.Models;

public class ProductModel 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Brand { get; set; } = null!;
    [JsonIgnore]
    public IList<PricesModel>? Prices { get; set; }
    [JsonIgnore]
    public StockModel? Stock { get; internal set; }

}