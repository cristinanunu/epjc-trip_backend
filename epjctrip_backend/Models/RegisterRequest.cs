namespace epjctrip_backend.Models;

public class RegisterRequest
{
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
}