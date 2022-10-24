using System;
using CarAuthShop.Data.Records;
using CarAuthShop.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace CarAuthShop.Pages.CmsFolder;

[Authorize(Roles = "Admin")]
public partial class CmsManageUsers
{
    [Inject] private IRoleManagerService _roleManagerService { get; set; } = null!;

    private List<RoleR> AllRoles { get; set; } = new();

    private List<UserRoleR> AllUserRole { get; set; } = new();

    private string IdUser { get; set; } = string.Empty;

    private string SelectedRoleName { get; set; } = string.Empty;

    private string FindUserWithName { get; set; } = string.Empty;

    private List<UserR> FindedUser { get; set; } = new();

    protected override void OnInitialized()
    {
        GetAllRoles();
        GetAllUserRole();
    }

    private void GetAllRoles()
    {
        AllRoles = _roleManagerService.GetAllRoles().ToList();
    }

    private async void ChangeRoleUsers(string SelectedRoleName, string IdUser)
    {
        await _roleManagerService.UpdateRoleUsers(SelectedRoleName, IdUser);
        SelectedRoleName = string.Empty;
        IdUser = string.Empty;
        GetAllUserRole();
        StateHasChanged();

    }

    private void FindCurrentlyUser(string currentlyUserEmail)
    {
        FindedUser = _roleManagerService.FindCurrentlyUser(currentlyUserEmail).ToList();
    }

    private void GetAllUserRole()
    {
        AllUserRole = _roleManagerService.GetAllUserRole().ToList();
    }
}

