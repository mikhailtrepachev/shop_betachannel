using System;
using CarAuthShop.Data.Records;


namespace CarAuthShop.Services.Infrastructure;

public interface IRoleManagerService
{
    void AddNewRole(string roleName);

    IReadOnlyCollection<RoleR> GetAllRoles();

    IReadOnlyCollection<UserRoleR> GetAllUserRole();

    Task<bool> DeleteRole(string id);

    Task UpdateRoleUsers(string selectedRoleName, string idUser);

    IReadOnlyCollection<UserR> FindCurrentlyUser(string findCurrentlyUser);

    Task<bool> DeleteCar(int idCar);
}

