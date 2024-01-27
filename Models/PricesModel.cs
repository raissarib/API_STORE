namespace API_FARMACIA_PM.Models;

public class PricesModel 
{
    public int Id { get; set; }
    public ProductModel Product { get; set; } = null!;
    public int ProductId { get; set; }
    public double Price { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime EndDate { get; set; }
    
}