using System;
using CarAuthShop.Data;
using CarAuthShop.Data.Records;
using CarAuthShop.Models.Records;
using CarAuthShop.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarAuthShop.Services
{
    public class SelectedCarService : ISelectedCarService
    {
        private readonly ApplicationDbContext _dbContext;

        public SelectedCarService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IReadOnlyCollection<CarR> GetSelectedCar(int idCar)
    => _dbContext.Cars
        .Select(car =>
            new CarR()
            {
                Id = car.Id,
                Description = car.Description,
                CreationDate = car.CreationDate,
                Cost = car.Cost,
                Label = car.Label,
                Model = car.Label
            })
        .Where(car => car.Id == idCar)
        .ToList()
        .AsReadOnly();
    }
}

