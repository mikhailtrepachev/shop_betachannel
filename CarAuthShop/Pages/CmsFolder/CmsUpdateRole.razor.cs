using System;
using CarAuthShop.Data.Records;
using CarAuthShop.Pages.CmsFolder;
using CarAuthShop.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CarAuthShop.Pages.CmsFolder;

[Authorize(Roles = "Admin")]
public partial class CmsUpdateRole
{
    [Inject] private IRoleManagerService _roleManagerService { get; set; } = null!;

    [Inject] private ISnackbar _snackBar { get; set; } = null!;

    private List<RoleR> AllRoles { get; set; } = new List<RoleR>();

    public string RoleName { get; set; } = string.Empty;

    public void AddNewRole()
    {
        _roleManagerService.AddNewRole(RoleName);

        RoleName = string.Empty;

        GetAllRoles();
    }

    protected override void OnInitialized()
    {
        GetAllRoles();
    }

    public void GetAllRoles()
    {
        AllRoles = _roleManagerService.GetAllRoles().ToList();
    }

    public async void DeleteRole(string id)
    {
        var state = await _roleManagerService.DeleteRole(id);

        if (state == true)
        {
            _snackBar.Configuration.SnackbarVariant = Variant.Outlined;
            _snackBar.Configuration.MaxDisplayedSnackbars = 5;
            _snackBar.Add("Role has been deleted", Severity.Success);
        }
        else
        {
            _snackBar.Configuration.SnackbarVariant = Variant.Outlined;
            _snackBar.Configuration.MaxDisplayedSnackbars = 5;
            _snackBar.Add("Role has not beed deleted", Severity.Error);
        }

        AllRoles.Remove(AllRoles.FirstOrDefault(role => role.Id == id)!);
        StateHasChanged();
    }
}

