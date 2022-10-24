using CarAuthShop.Data.Records;
using CarAuthShop.Models.Records;

namespace CarAuthShop.Services.Infrastructure;

public interface IOfferService
{
    IReadOnlyCollection<CarR> GetCurrentlyCars(string currentUserId);

    Task<bool> DeleteCurrentCar(int id);

    IReadOnlyCollection<CarImageR> GetCurrentlyImages(string currentUserId);
}

