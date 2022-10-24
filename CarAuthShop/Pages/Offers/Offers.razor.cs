using System;
using CarAuthShop.Data.DatabaseObjects;
using CarAuthShop.Data.Records;
using CarAuthShop.Models.Records;
using CarAuthShop.Services.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MudBlazor;

namespace CarAuthShop.Pages.Offers;

public partial class Offers
{
    [Inject] private IOfferService _offerService { get; set; } = null!;
    
    [Inject] private ISnackbar _snackBar { get; set; } = null!;

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

    private void GetAllCars(string currentUserId)
    {
        AllCars = _offerService.GetCurrentlyCars(currentUserId).ToList();

        AllImages64 = _offerService.GetCurrentlyImages(currentUserId).ToList();
    }

    private async void DeleteCurrentCar(int id)
    {
        var state = await _offerService.DeleteCurrentCar(id);
        
        AllCars.Remove(AllCars.FirstOrDefault(car => car.Id == id)!);
        
        StateMessenger(state);

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

    private void StateMessenger(bool state)
    {
        if (state == false)
        {
            _snackBar.Configuration.SnackbarVariant = Variant.Outlined;
            _snackBar.Configuration.MaxDisplayedSnackbars = 5;
            _snackBar.Add("Car has not been deleted!", Severity.Error);
        }
        else
        {
            _snackBar.Configuration.SnackbarVariant = Variant.Outlined;
            _snackBar.Configuration.MaxDisplayedSnackbars = 5;
            _snackBar.Add("Car has been deleted!", Severity.Success);
        }
    }
}

