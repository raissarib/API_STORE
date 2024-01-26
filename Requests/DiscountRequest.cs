using API_FARMACIA_PM.Models;
namespace API_FARMACIA_PM.Requests;

public class DiscountRequest 
{
    public decimal Value { get; set; }
    public IList<TypeUserModel>? TypeUser { get; set; }
}