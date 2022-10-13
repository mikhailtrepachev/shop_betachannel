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

    public string IdUser { get; set; } = string.Empty;

    public string SelectedRoleName { get; set; } = string.Empty;

    public string FindUserWithName { get; set; } = string.Empty;

    private List<UserR> FindedUser { get; set; } = new();

    protected override void OnInitialized()
    {
        GetAllRoles();
        GetAllUserRole();
    }

    public void GetAllRoles()
    {
        AllRoles = _roleManagerService.GetAllRoles().ToList();
    }

    public async void ChangeRoleUsers(string SelectedRoleName, string IdUser)
    {
        await _roleManagerService.UpdateRoleUsers(SelectedRoleName, IdUser);
        SelectedRoleName = string.Empty;
        IdUser = string.Empty;
        GetAllUserRole();
        StateHasChanged();

    }

    public void FindCurrentlyUser(string findUserWithName)
    {
        FindedUser = _roleManagerService.FindCurrentlyUser(findUserWithName).ToList();
    }

    public void GetAllUserRole()
    {
        AllUserRole = _roleManagerService.GetAllUserRole().ToList();
    }
}

