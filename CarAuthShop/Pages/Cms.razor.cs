using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace CarAuthShop.Pages;

[Authorize(Roles = "Admin")]
public partial class Cms
{
    [Inject] public NavigationManager Navigationmanager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {

    }

    public void RouteToDeleteCarCms()
    {
        Navigationmanager.NavigateTo("/cms/delete_car");
    }
}

