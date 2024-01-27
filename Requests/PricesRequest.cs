namespace API_FARMACIA_PM.Requests;

public class PricesRequest 
{
    public int ProductId { get; set; }
    public double Price { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime EndDate { get; set; }
}