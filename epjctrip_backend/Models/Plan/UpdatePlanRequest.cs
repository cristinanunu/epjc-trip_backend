namespace epjctrip_backend.Models;

public class UpdatePlanRequest
{
    public string Name { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public string Destination { get; set; }
    
    public string Departure { get; set; }
    
    public int Participants { get; set; }
    
    public int Budget { get; set; }
    
    public decimal? TotalCo2E { get; set; }
        
    public string? TransportType { get; set; }
        
    public decimal? TransportCo2E { get; set; }
        
    public string? AccommodationType { get; set; }
        
    public decimal? AccommodationCo2E { get; set; }
    
}