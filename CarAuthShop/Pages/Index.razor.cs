using CarAuthShop.Data.Records;
using CarAuthShop.Models.Records;
using CarAuthShop.Services.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace CarAuthShop.Pages;

public partial class Index
{
    [Inject] public NavigationManager Navigationmanager { get; set; } = null!;

    [Inject] private ICarService _carService { get; set; } = null!;

    private IReadOnlyCollection<CarR> AllCars { get; set; } = null!;

    private IReadOnlyCollection<CarImageR> AllImages64 { get; set; } = null!;

    private string CurrentImageData { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        GetAllCars();
    }

    private void GetAllCars()
    {
        AllCars = _carService.GetAllCars();

        AllImages64 = _carService.GetAllImages();
    }

    private void RouteWithId(int id)
    {
        Navigationmanager.NavigateTo("/sc/" + id);
    }


}

