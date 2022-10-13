using System;
namespace CarAuthShop.Data.Records;

public record RoleR
{
    public string Id { get; set; } = string.Empty;

    public string RoleName { get; set; } = string.Empty;

    public string NormalizedRoleName { get; set; } = string.Empty;

    public string ConcurrencyStamp { get; set; } = string.Empty;
}

