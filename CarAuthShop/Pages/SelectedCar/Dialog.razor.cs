
using CarAuthShop.Services.Infrastructure;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CarAuthShop.Pages.SelectedCar;

public partial class Dialog
{
    [Inject] private IOrderService _orderService { get; set; } = null!;

    [Inject] private ISnackbar _snackBar { get; set; } = null!;
    
    private string PhoneNumber { get; set; } = string.Empty;

    private string Details { get; set; } = string.Empty;

    private string Location { get; set; } = string.Empty;

    private async Task UploadOrderToDatabase()
    {
        var state = await _orderService.UploadOrderToDatabase(PhoneNumber, Details, Location);
        
        StateMessenger(state);
        
        StateHasChanged();
        
        Submit();
    }
    
    private void StateMessenger(bool state)
    {
        if (state == false)
        {
            _snackBar.Configuration.SnackbarVariant = Variant.Outlined;
            _snackBar.Configuration.MaxDisplayedSnackbars = 5;
            _snackBar.Add("Order has not been added!", Severity.Error);
        }
        else
        {
            _snackBar.Configuration.SnackbarVariant = Variant.Outlined;
            _snackBar.Configuration.MaxDisplayedSnackbars = 5;
            _snackBar.Add("Order has been added!", Severity.Success);
        }
    }
}
