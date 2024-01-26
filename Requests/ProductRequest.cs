namespace API_FARMACIA_PM.Requests;

public class ProductRequest 
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime ExpirationDate { get; set; }
}