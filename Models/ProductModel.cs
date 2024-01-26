namespace API_FARMACIA_PM.Models;

public class ProductModel 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public DateTime ExpirationDate { get; set; }
}