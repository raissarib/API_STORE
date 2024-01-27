namespace API_FARMACIA_PM.Models;

public class StockModel 
{
    public int Id { get; set; }
    public StoreModel Store { get; set; } = null!;
    public int StoreId { get; set; }
    public ProductModel Product { get; set; } = null!; 
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}