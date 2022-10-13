using System;
using CarAuthShop.Models.Records;

namespace CarAuthShop.Services.Infrastructure;

public interface IOfferService
{
    IReadOnlyCollection<CarR> GetCurrentlyCars(string currentUserId);

    Task DeleteCurrentCar(int id);
}

