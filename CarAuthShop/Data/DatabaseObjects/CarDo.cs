namespace CarAuthShop.Data.DatabaseObjects;

public class CarDo
{
    public int Id { get; set; }

    public string Label { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public int Cost { get; set; }

    public string LabelAndModel { get; set; } = string.Empty;  

    public DateTimeOffset CreationDate { get; set; }

    public CarUserDo? CarUserDo { get; set; } = null!;

    public List<OrderDo> OrderDo { get; set; } = new();

    public List<CarImagesDo> CarImagesDos { get; set; } = new();
}
