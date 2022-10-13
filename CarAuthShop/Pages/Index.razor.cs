using CarAuthShop.Data.DatabaseObjects;
using CarAuthShop.Models.Records;
using CarAuthShop.Services.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace CarAuthShop.Pages;

public partial class Index
{
    [Inject] public NavigationManager Navigationmanager { get; set; } = null!;

    [Inject] private ICarService _carService { get; set; } = null!;

    private IReadOnlyCollection<CarR> AllCars { get; set; } = null!;

    private List<CarImagesDo> AllImages64 { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        GetAllCars();
    }

    public void GetAllCars()
    {
        AllCars = _carService.GetAllCars();

        AllImages64 = _carService.GetAllImages();
    }

    public void RouteWithId(int id)
    {
        Navigationmanager.NavigateTo("/sc/" + id);
    }
}

