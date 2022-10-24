using Microsoft.AspNetCore.Identity;

namespace CarAuthShop.Data.DatabaseObjects;

public class UserDo:IdentityUser
{
    public CarUserDo? CarUserDo { get; set; } = null!; //collection cars
}

