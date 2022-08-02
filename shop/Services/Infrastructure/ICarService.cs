using System;
using shop.Models.Records;

namespace shop.Services.Infrastructure;

public interface ICarService
{
    void AddNewCar(string carLabel, string carModel, string carDescription);

    IReadOnlyCollection<CarR> GetAllCars();
}

