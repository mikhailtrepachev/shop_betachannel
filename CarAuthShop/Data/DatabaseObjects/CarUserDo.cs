using System.ComponentModel.DataAnnotations.Schema;

namespace CarAuthShop.Data.DatabaseObjects;

public class CarUserDo
{

    public int Id { get; set; }
    public int CarDoId { get; set; }
    
    public List<CarDo> CarDo { get; set; } = new();
    
    [ForeignKey("User_Id")]
    public string UserDoId { get; set; } = string.Empty;

    public List<UserDo> UserDo { get; set; } = new();
}

