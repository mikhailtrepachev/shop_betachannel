using CarAuthShop.Data.DatabaseObjects;
using CarAuthShop.Services.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using MudBlazor;

namespace CarAuthShop.Pages;

public partial class CreateCar
{
    [Inject] private ICarService _carService { get; set; } = null!;

    [Inject] private ISnackbar _snackBar { get; set; } = null!;

    [CascadingParameter] private Task<AuthenticationState> AuthenticationState { get; set; } = null!;

    [Inject] public NavigationManager Navigationmanager { get; set; } = null!;

    [Inject] private UserManager<UserDo> UserManager { get; set; } = null!;

    List<string> Images64 { get; set; } = new();

    private string CarLabel { get; set; } = string.Empty;

    private string CarModel { get; set; } = string.Empty;

    private string CarDescription { get; set; } = string.Empty;

    private string CurrentUserId { get; set; } = string.Empty;

    private int CarCost { get; set; }

    private bool IsCompleted { get; set; }

    public async Task AddNewCar()
    {
        try
        {
            IsCompleted = await _carService.AddNewCar(CarLabel, CarModel, CarDescription, CarCost, CurrentUserId, Images64);
        }
        catch (Exception ex)
        {
            _snackBar.Add($"{ex.Message}", Severity.Error);
        }

        if (IsCompleted != true)
        {
            _snackBar.Add("Car has not been added", Severity.Error);
        }

        CarLabel = string.Empty;
        CarModel = string.Empty;
        CarDescription = string.Empty;

        _snackBar.Configuration.SnackbarVariant = Variant.Outlined;
        _snackBar.Configuration.MaxDisplayedSnackbars = 5;
        _snackBar.Add("Car has been added", Severity.Success);

        Navigationmanager.NavigateTo("/");
    }

    protected override async Task OnInitializedAsync()
    {
        var user = (await AuthenticationState).User;

        if (user.Identity!.IsAuthenticated)
        {
            var currentUser = await UserManager.GetUserAsync(user);
            CurrentUserId = currentUser.Id;
        }
    }

    private async Task UploadFiles(InputFileChangeEventArgs e)
    {
        var files = e.GetMultipleFiles();

        try
        {

            foreach (var file in files)
            {
                var correctSizeImage = await file.RequestImageFileAsync("jpeg", 320, 480);

                using (var ms = new MemoryStream())
                {
                    await correctSizeImage.OpenReadStream().CopyToAsync(ms);

                    var buffer = ms.ToArray();

                    Images64.Add(Convert.ToBase64String(buffer));
                }
            }
        }
        catch (Exception ex)
        {
            _snackBar.Add($"{ex.Message}", Severity.Error);
        }
    }
}

