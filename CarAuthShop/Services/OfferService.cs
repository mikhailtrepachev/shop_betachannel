using System;
using System.Collections.ObjectModel;
using CarAuthShop.Data;
using CarAuthShop.Data.DatabaseObjects;
using CarAuthShop.Data.Models;
using CarAuthShop.Data.Records;
using CarAuthShop.Models.Records;
using CarAuthShop.Services.Infrastructure;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CarAuthShop.Services
{
    public class OfferService:IOfferService
    {
        private readonly ApplicationDbContext _dbContext;

        public OfferService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IReadOnlyCollection<CarR> GetCurrentlyCars (string currentUserId)
        {
            var temp = _dbContext.CarUser
                .Select(carUser =>
                    new UsersOffersR()
                    {
                        CarsId = carUser.CarDoId,
                        UserId = carUser.UserDoId
                    })
                .Where(id => id.UserId == currentUserId);


            var temp2 = (
                from cu in temp
                join c in _dbContext.Cars on cu.CarsId equals c.Id
                select new CarR()
                {
                    Id = c.Id,
                    Label = c.Label,
                    Model = c.Model,
                    Description = c.Description,
                    CreationDate = c.CreationDate,
                    Cost = c.Cost
                })
                .ToList()
                .AsReadOnly();

            return temp2;
        }

        public async Task DeleteCurrentCar(int id)
        {
            var taskDeleteCar = _dbContext.Cars
                .FirstOrDefault(car => car.Id == id);

            var taskDeleteUserCar = _dbContext.CarUser
                .FirstOrDefault(userCar => userCar.CarDoId == id);

            if (taskDeleteCar == null || taskDeleteUserCar == null)
                return;

            _dbContext.Cars.Remove(taskDeleteCar);
            _dbContext.CarUser.Remove(taskDeleteUserCar);

            await _dbContext.SaveChangesAsync();
        }
    }
}

