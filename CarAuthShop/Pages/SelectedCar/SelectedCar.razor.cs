using System;
using CarAuthShop.Data.Records;
using CarAuthShop.Models.Records;
using CarAuthShop.Services.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace CarAuthShop.Pages.SelectedCar;

public partial class SelectedCar
{
    [Parameter]
    public int Id { get; set; }

    [Inject] private ISelectedCarService _selectedCarService { get; set; } = null!;

    private List<CarR> AllCars { get; set; } = new();

    private string CurrentImageData { get; set; } = string.Empty;

    private IReadOnlyCollection<CarImageR> AllImages64 { get; set; } = null!;

    protected override void OnInitialized()
    {
        GetSelectedCar();
    }

    private void GetSelectedCar()
    {
        AllCars = _selectedCarService.GetSelectedCar(Id).ToList();

        AllImages64 = _selectedCarService.GetSelectedImage(Id).ToList();
    }
    
    private string GetCurrentlyImage(int carId)
    {
        var currentImageTemp = AllImages64.FirstOrDefault(image => image.CarId == carId);

        if (currentImageTemp == null)
        {
            return string.Empty;
        }
        
        CurrentImageData = currentImageTemp.ImageData64;

        return string.Empty;
    }

}

