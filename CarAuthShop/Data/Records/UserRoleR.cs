using System;
namespace CarAuthShop.Data.Records;

public record UserRoleR
{
    public string UserId { get; set; } = string.Empty;

    public string RoleId { get; set; } = string.Empty;
}

