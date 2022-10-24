using CarAuthShop.Data;
using CarAuthShop.Data.Records;
using CarAuthShop.Models.Records;
using CarAuthShop.Services.Infrastructure;

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


        public IReadOnlyCollection<CarImageR> GetSelectedImage(int idCar)
            => _dbContext.CarImages
                .Select(image =>
                    new CarImageR()
                    {
                        Id = image.Id,
                        ImageData64 = image.ImageData64,
                        CarId = image.CarId,
                        ImageName = image.ImageName
                    })
                .Where(image => image.CarId == idCar)
                .ToList()
                .AsReadOnly();
    }
}

