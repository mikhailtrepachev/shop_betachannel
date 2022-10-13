using System;
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

    protected override void OnInitialized()
    {
        GetSelectedCar(Id);
    }

    public void GetSelectedCar(int idCar)
    {
        AllCars = _selectedCarService.GetSelectedCar(Id).ToList();
    }


}

