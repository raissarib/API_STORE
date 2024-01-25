namespace API_FARMACIA_PM.Models;

public class StoreModel
{
    public int Id { get; set; }
    public int Number { get; set; }
    public IList<ProductModel>? Products { get; set; }
    public string Name { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Phone { get; set; } = null!;
}
