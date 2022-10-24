using CarAuthShop.Data.Records;
using CarAuthShop.Models.Records;

namespace CarAuthShop.Services.Infrastructure
{
    public interface ISelectedCarService
    {
        IReadOnlyCollection<CarR> GetSelectedCar(int idCar);

        IReadOnlyCollection<CarImageR> GetSelectedImage(int idCar);

    }
}

