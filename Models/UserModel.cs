namespace API_FARMACIA_PM.Models;

public class UserModel 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public TypeUserModel TypeUser { get; set; } = null!;
}