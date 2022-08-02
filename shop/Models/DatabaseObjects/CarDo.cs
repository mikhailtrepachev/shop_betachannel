using System;
namespace shop.Models.DatabaseObjects
{
    public class CarDo
    {
        public int Id { get; set; }

        public string Label { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}

