using CarAuthShop.Data.DatabaseObjects;
using CarAuthShop.Models.Records;
using Microsoft.AspNetCore.Components.Forms;

namespace CarAuthShop.Services.Infrastructure;

public interface ICarService
{
    Task<bool> AddNewCar(string carLabel, string carModel, string carDescription, int carCost, string currentUserId, List<string> images64);

    IReadOnlyCollection<CarR> GetAllCars();

    Task<int> AddNewUserCarInfo(string currentUserId, DateTimeOffset currentlyCreationDate);

    Task<bool> UploadImagesToDatabase(List<string> images64, int carId);

    List<CarImagesDo> GetAllImages();

}

