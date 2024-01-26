namespace API_FARMACIA_PM.Models;

public class DiscountModel 
{
    public int Id { get; set; }
    public double Value { get; set; }
    public IList<TypeUserModel>? TypeUser { get; set; }
}