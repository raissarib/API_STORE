namespace API_FARMACIA_PM.Models;

public class DiscountModel 
{
    public int Id { get; set; }
    public decimal Value { get; set; }
    public IList<TypeUserModel>? TypeUser { get; set; }
}