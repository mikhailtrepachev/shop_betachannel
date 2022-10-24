using CarAuthShop.Data.Models;

namespace CarAuthShop.Data.DatabaseObjects;

public class CarImagesDo
{
	public int Id { get; set; }
	
    public string ImageName { get; set; } = string.Empty;

    public string ImageData64 { get; set; } = string.Empty;
    
    public int CarId { get; set; }
    
    public CarDo? CarDo { get; set; } = new();
}
	
