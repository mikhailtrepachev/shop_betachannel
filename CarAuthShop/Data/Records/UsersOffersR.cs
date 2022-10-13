using System;
namespace CarAuthShop.Data.Records
{
    public record UsersOffersR
    {
        public int Id { get; set; }

        public int CarsId { get; set; }

        public string UserId { get; set; } = string.Empty;
    }
}

