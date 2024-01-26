namespace API_FARMACIA_PM.Requests;

public class ProductRequest 
{
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public DateTime ExpirationDate { get; set; }
}