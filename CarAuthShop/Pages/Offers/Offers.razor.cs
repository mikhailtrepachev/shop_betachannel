using System;
using CarAuthShop.Data.DatabaseObjects;
using CarAuthShop.Data.Records;
using CarAuthShop.Models.Records;
using CarAuthShop.Services.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CarAuthShop.Pages.Offers;

public partial class Offers
{
    [Inject] private IOfferService _offerService { get; set; } = null!;

    private List<CarR> AllCars { get; set; } = new();
    
    private IReadOnlyCollection<CarImageR> AllImages64 { get; set; } = null!;

    private string CurrentImageData { get; set; } = string.Empty;

    [CascadingParameter]
    private Task<AuthenticationState>? AuthenticationState { get; set; }

    [Inject] private UserManager<UserDo> UserManager { get; set; } = null!;

    private string CurrentUserId { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        var user = (await AuthenticationState!).User;

        if (user.Identity!.IsAuthenticated)
        {
            var currentUser = await UserManager.GetUserAsync(user);
            CurrentUserId = currentUser.Id;
        }

        GetAllCars(CurrentUserId);
    }

    public void GetAllCars(string currentUserId)
    {
        AllCars = _offerService.GetCurrentlyCars(currentUserId).ToList();

        AllImages64 = _offerService.GetCurrentlyImages(currentUserId).ToList();
    }

    public async void DeleteCurrentCar(int id)
    {
        await _offerService.DeleteCurrentCar(id);

        AllCars.Remove(AllCars.FirstOrDefault(car => car.Id == id)!);

        StateHasChanged();
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

