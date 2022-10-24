namespace CarAuthShop.Data.DatabaseObjects;

public class OrderDo
{
    public string Id { get; set; } = string.Empty; //TODO GUID DOES NOT WORK
    
    public int CarDoId { get; set; }

    public CarDo? CarDo { get; set; } = new();

    public string PhoneNumber { get; set; } = string.Empty;

    public string Details { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;
}