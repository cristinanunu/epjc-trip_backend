namespace epjctrip_backend.Models;

public class Activity
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Link { get; set; }
    
    public string ImageUrl { get; set; }

    public double? Rating{ get; set; }
    
    public string? Ranking { get; set; }
    
    public string? Longitude { get; set; }
    
    public string? Latitude { get; set; }
    
    public string Street { get; set; }

    public int ReviewsNumber { get; set; }
    
    public string City { get; set; }

    public int PlanId { get; set; }
}