using API_FARMACIA_PM.Models;
namespace API_FARMACIA_PM.Requests;

public class UpdateStoreRequest 
{
    public int Id { get; set; }
    public string Phone { get; set; } = null!;
    public string Manager { get; set; } = null!;
    
}