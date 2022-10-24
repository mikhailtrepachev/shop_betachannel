namespace CarAuthShop.Data.Records;

public record CarImageR
{
    public int Id { get; set; }
    
    public int CarId { get; set; }

    public string ImageName { get; set; } = string.Empty;

    public string ImageData64 { get; set; } = string.Empty;
}