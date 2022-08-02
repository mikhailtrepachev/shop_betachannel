using System;
using shop.Models;
using shop.Models.DatabaseObjects;
using shop.Models.Records;
using shop.Services.Infrastructure;

namespace shop.Services;

public class CarService:ICarService
{
    private readonly AppDbContext _DbContext;

    public CarService(AppDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public void AddNewCar(string carLabel, string carModel, string carDescription)
    {
        var newCar = new CarDo();

        newCar.Label = carLabel;
        newCar.Model = carModel;
        newCar.Description = carDescription;

        if (newCar.Label == string.Empty)
        {
            return;
        }

        _DbContext.Cars.Add(newCar);
        _DbContext.SaveChanges();
    }

    public IReadOnlyCollection<CarR> GetAllCars()

        => _DbContext.Cars
            .Select(car =>
                new CarR
                {
                    Id = car.Id,
                    Label = car.Label,
                    Model = car.Model,
                    Description = car.Description
                })
            .ToList()
            .AsReadOnly();
}

