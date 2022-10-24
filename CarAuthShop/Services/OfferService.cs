using CarAuthShop.Data;
using CarAuthShop.Data.Records;
using CarAuthShop.Models.Records;
using CarAuthShop.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace CarAuthShop.Services
{
    public class OfferService:IOfferService
    {
        private readonly ApplicationDbContext _dbContext;
        
        private IQueryable<UsersOffersR> CarUserRow = null!;

        public OfferService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IReadOnlyCollection<CarR> GetCurrentlyCars (string currentUserId)
        {
            CarUserRow = _dbContext.CarUser
                .Select(carUser =>
                    new UsersOffersR()
                    {
                        CarsId = carUser.CarDoId,
                        UserId = carUser.UserDoId
                    })
                .Where(id => id.UserId == currentUserId);


            var carsOffer = (
                from cu in CarUserRow
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

            return carsOffer;
        }

        public async Task<bool> DeleteCurrentCar(int id)
        {
            var taskDeleteCar = await _dbContext.Cars
                .FirstOrDefaultAsync(car => car.Id == id);

            var taskDeleteUserCar = await _dbContext.CarUser
                .FirstOrDefaultAsync(userCar => userCar.CarDoId == id);

            if (taskDeleteCar == null || taskDeleteUserCar == null)
                return false;

            _dbContext.Cars.Remove(taskDeleteCar);
            _dbContext.CarUser.Remove(taskDeleteUserCar);

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public IReadOnlyCollection<CarImageR> GetCurrentlyImages(string currentlyUserId)
        {
            var imagesOffer = (
                    from cu in CarUserRow
                    join ci in _dbContext.CarImages on cu.CarsId equals ci.CarId
                    select new CarImageR()
                    {
                        Id = ci.Id,
                        ImageData64 = ci.ImageData64,
                        ImageName = ci.ImageName,
                        CarId = ci.CarId
                    })
                .ToList()
                .AsReadOnly();

            return imagesOffer;
        }
    }
}

