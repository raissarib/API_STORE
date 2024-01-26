using API_FARMACIA_PM.Models;
namespace API_FARMACIA_PM.Requests;

public class UserRequest 
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public TypeUserModel TypeUser { get; set; } = null!;
}