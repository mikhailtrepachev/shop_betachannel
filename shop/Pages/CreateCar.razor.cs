using System;
using Microsoft.AspNetCore.Components;
using shop.Services.Infrastructure;

namespace shop.Pages;

public partial class CreateCar
{
    [Inject]

    private ICarService _carService { get; set; }

    public string CarLabel { get; set; } = string.Empty;

    public string CarModel { get; set; } = string.Empty;

    public string CarDescription { get; set; } = string.Empty;

    public void AddNewCar()
    {
        _carService.AddNewCar(CarLabel, CarModel, CarDescription);

        CarLabel = string.Empty;
        CarModel = string.Empty;
        CarDescription = string.Empty;
    }

}

