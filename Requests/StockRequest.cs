namespace API_FARMACIA_PM.Requests;

public class StockRequest 
{
    public int StoreId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    
}