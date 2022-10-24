using System.Diagnostics.CodeAnalysis;
using CarAuthShop.Data;
using CarAuthShop.Data.DatabaseObjects;
using CarAuthShop.Data.Records;
using CarAuthShop.Models.Records;
using CarAuthShop.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarAuthShop.Services;

public class CarService : ICarService
{
    private readonly ApplicationDbContext _dbContext;

    public CarService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<bool> AddNewCar(string carLabel, string carModel,
        string carDescription, int carCost, string currentUserId, List<string> images64)
    {
        var newCar = new CarDo();

        newCar.Cost = carCost;
        newCar.Label = carLabel;
        newCar.Model = carModel;
        newCar.Description = carDescription;
        newCar.CreationDate = DateTime.Now;

        if (newCar.Label == string.Empty)
        {
            return false;
        }

        await _dbContext.Cars.AddAsync(newCar);

        await _dbContext.SaveChangesAsync();
        

        var currentlyCreationDate = newCar.CreationDate;
        
        var carId = await AddNewUserCarInfo(currentUserId, currentlyCreationDate);

        var state = await UploadImagesToDatabase(images64, carId);

        if (state == false && carId == 0)
        {
            return false;
        }

        await _dbContext.SaveChangesAsync();

        var bug = carId + 1;

        var ee = await _dbContext.Cars
            .FirstOrDefaultAsync(bc => bc.Id == bug);
        
        
        if (ee != default)
        {
            _dbContext.Cars.Remove(ee);
            
            await _dbContext.SaveChangesAsync();
        }
        
        return true;
    }


    public IReadOnlyCollection<CarR> GetAllCars()
    {

        var task = _dbContext.Cars
            .Select(car =>
                new CarR
                {
                    Id = car.Id,
                    Label = car.Label,
                    Model = car.Model,
                    Description = car.Description,
                    CreationDate = car.CreationDate,
                    Cost = car.Cost
                })
            .ToList()
            .AsReadOnly();

        return task;

    }


    public async Task<int> AddNewUserCarInfo(string currentUserId, DateTimeOffset currentlyCreationDate)
    {
        var newCarUser = new CarUserDo();
        var currentlyCar = await _dbContext.Cars
            .FirstOrDefaultAsync(currentlyCar => currentlyCar.CreationDate == currentlyCreationDate);

        if (currentlyCar == null) { return 0; };

        newCarUser.UserDoId = currentUserId;
        newCarUser.CarDoId = currentlyCar.Id;

        await _dbContext.CarUser.AddAsync(newCarUser);
        return newCarUser.CarDoId;
    }

    
    public async Task<bool> UploadImagesToDatabase(List<string> images64, int carId)
    {
        try
        {
            foreach (var image in images64)
            {
                var carImage = new CarImagesDo();

                carImage.CarId = carId;
                carImage.ImageData64 = image;
                carImage.ImageName = System.Guid.NewGuid().ToString();

                await _dbContext.CarImages.AddAsync(carImage);
            }
        }
        catch
        {
            return false;
        }

        return true;
    }

    
    //TODO: FIX MEMORY TRAFFIC IN LOH in GetAllImages()
    [SuppressMessage("ReSharper.DPA", "DPA0003: Excessive memory allocations in LOH", MessageId = "type: System.Char[]")]
    public IReadOnlyCollection<CarImageR> GetAllImages()
    {
        var task = _dbContext.CarImages
            .Select(image =>
                new CarImageR
                {
                    Id = image.Id,
                    CarId = image.CarId,
                    ImageName = image.ImageName,
                    ImageData64 = image.ImageData64
                })
            .ToList()
            .AsReadOnly();

        return task;
    }
}