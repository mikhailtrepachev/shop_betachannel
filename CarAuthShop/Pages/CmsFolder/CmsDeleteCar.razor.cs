using System;
using CarAuthShop.Services.Infrastructure;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CarAuthShop.Pages.CmsFolder;

public partial class CmsDeleteCar
{
    public int IdCar { get; set; }

    [Inject] private IRoleManagerService _roleManagerService { get; set; } = null!;

    [Inject] private ISnackbar _snackBar { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {

    }

    public async void DeleteCar(int idCar)
    {
        var state = await _roleManagerService.DeleteCar(idCar);

        if (state == true)
        {
            _snackBar.Configuration.SnackbarVariant = Variant.Outlined;
            _snackBar.Configuration.MaxDisplayedSnackbars = 5;
            _snackBar.Add("Item has been deleted", Severity.Info);
        }

        else
        {
            _snackBar.Configuration.SnackbarVariant = Variant.Outlined;
            _snackBar.Configuration.MaxDisplayedSnackbars = 5;
            _snackBar.Add("Item has not been deleted", Severity.Error);
        }

        StateHasChanged();
    }


}

