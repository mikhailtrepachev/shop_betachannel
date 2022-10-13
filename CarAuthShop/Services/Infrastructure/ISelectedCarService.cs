using System;
using CarAuthShop.Models.Records;

namespace CarAuthShop.Services.Infrastructure
{
    public interface ISelectedCarService
    {
        IReadOnlyCollection<CarR> GetSelectedCar(int idCar);

    }
}

