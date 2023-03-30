namespace epjctrip_backend.Models;

public class User
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public Plan? Plan { get; set; }
}