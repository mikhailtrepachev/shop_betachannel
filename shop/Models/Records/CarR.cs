using System;
namespace shop.Models.Records;

public record CarR
{
    public int Id { get; set; }

    public string Label { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}

