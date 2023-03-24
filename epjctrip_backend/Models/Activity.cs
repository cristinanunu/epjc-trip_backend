namespace epjctrip_backend.Models;

public class Activity
{
    public int Id { get; set; }
    
    public int TripadvisorId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Link { get; set; }
    
    public string ImageUrl { get; set; }
    
    public double? Price { get; set; }
    
    public double? Rating{ get; set; }   
    
    public string Street { get; set; }
    
    public float? Latitude { get; set; }
    
    public float? Longitude { get; set; }
    
    public int ReviewsNumber { get; set; }
}