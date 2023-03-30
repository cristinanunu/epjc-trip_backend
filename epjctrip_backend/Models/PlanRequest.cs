using System.ComponentModel.DataAnnotations;

namespace epjctrip_backend.Models;

public class PlanRequest
{
    [Required]
    public string Name { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public string Destination { get; set; }
    
    public string? Departure { get; set; }

    public int Participants { get; set; }
    
    public int? Cost { get; set; } 
    
    public int UserId { get; set; }
}