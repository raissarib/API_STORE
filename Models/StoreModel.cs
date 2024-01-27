namespace API_FARMACIA_PM.Models;

public class StoreModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Manager { get; set; } = null!;
    public IList<StockModel>? Stocks { get; internal set; }
}
