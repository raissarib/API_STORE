using API_FARMACIA_PM.Models;
namespace API_FARMACIA_PM.Requests;

public class StoreRequest 
{
    public int Id { get; set; }
    public int Number { get; set; }
    public IList<ProductModel>? Products { get; set; }
    public string Name { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Phone { get; set; } = null!;
}