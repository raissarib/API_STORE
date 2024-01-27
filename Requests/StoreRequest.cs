using API_FARMACIA_PM.Models;
namespace API_FARMACIA_PM.Requests;

public class StoreRequest 
{
    public string Name { get; set; } = null!;
    public string Location { get; internal set; } = null!;
    public string Phone { get; set; } = null!;
    public string Manager { get; internal set; } = null!;
    
}