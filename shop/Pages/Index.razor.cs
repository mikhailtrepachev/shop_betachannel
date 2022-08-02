using System;
using Microsoft.AspNetCore.Components;
using shop.Models.Records;
using shop.Services.Infrastructure;

namespace shop.Pages;

public partial class Index
{
    [Inject]

    private ICarService _carService { get; set; }

    private List<CarR> AllCars { get; set; } = new List<CarR>();

    protected override void OnInitialized()
    {
        GetAllCars();
    }

    public void GetAllCars()
    {
        AllCars = _carService.GetAllCars().ToList();
    }
}

