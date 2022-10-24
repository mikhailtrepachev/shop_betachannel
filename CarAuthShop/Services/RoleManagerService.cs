using CarAuthShop.Data;
using CarAuthShop.Data.Records;
using CarAuthShop.Services.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarAuthShop.Services
{
    public class RoleManagerService : IRoleManagerService
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleManagerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddNewRole(string roleName)
        {
            var newRole = new IdentityRole();

            newRole.Name = roleName;
            newRole.NormalizedName = roleName.Normalize();

            if (newRole.Name == string.Empty)
            {
                return;
            }

            _dbContext.Add(newRole);
            _dbContext.SaveChanges();
        }

        public IReadOnlyCollection<RoleR> GetAllRoles()
            => _dbContext.Roles
                .Select(role =>
                    new RoleR
                    {
                        Id = role.Id,
                        RoleName = role.Name,
                        NormalizedRoleName = role.NormalizedName,
                        ConcurrencyStamp = role.ConcurrencyStamp
                    })
                .ToList()
                .AsReadOnly();

        public IReadOnlyCollection<UserRoleR> GetAllUserRole()
            => _dbContext.UserRoles
                .Select(userRole =>
                    new UserRoleR()
                    {
                        UserId = userRole.UserId,
                        RoleId = userRole.RoleId
                    })
                .ToList()
                .AsReadOnly();

        public async Task<bool> DeleteRole(string id)
        {
            var role = _dbContext.Roles
                .FirstOrDefault(role => role.Id == id);

            if (role == null)
            {
                return false;
            }

            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task UpdateRoleUsers(string selectedRoleName, string idUser)
        {
            var newUserRole = new IdentityUserRole<string>();

            var role = _dbContext.Roles
                .FirstOrDefault(role => role.Name == selectedRoleName);

            var user = _dbContext.Users
                .FirstOrDefault(user => user.Id == idUser);

            if (role == null || user == null)
            {
                return;
            }

            newUserRole.RoleId = role.Id;
            newUserRole.UserId = user.Id;

            var checkedUserRole = _dbContext.UserRoles
                .FirstOrDefault(userRole => userRole.UserId == idUser);

            if (checkedUserRole == null)
            {
                await _dbContext.UserRoles.AddAsync(newUserRole);
                await _dbContext.SaveChangesAsync();
            }
            else
            {

                _dbContext.UserRoles.Remove(checkedUserRole);
                await _dbContext.UserRoles.AddAsync(newUserRole);
                await _dbContext.SaveChangesAsync();
            }
        }

        public IReadOnlyCollection<UserR> FindCurrentlyUser(string currentlyUserEmail)
            => _dbContext.Users
                .Select(user =>
                    new UserR()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Name = user.UserName
                    })
                .Where(user => user.Email == currentlyUserEmail)
                .ToList()
                .AsReadOnly();

        public async Task<bool> DeleteCar (int idCar)
        {
            try
            {
                var car = _dbContext.Cars
                    .FirstOrDefault(car => car.Id == idCar);

                if (car == null)
                {
                    return false;
                }
                
                _dbContext.Cars.Remove(car);
                await _dbContext.SaveChangesAsync();

            }
            catch (DbUpdateException e)
            {
                var deleteCarWithReference = await _dbContext.Cars
                    .Include(ci => ci.CarImagesDos)
                    .Include(cu => cu.CarUserDo)
                    .FirstOrDefaultAsync(c => c.Id == idCar);

                if (deleteCarWithReference == default)
                {
                    return false;
                }
                
                _dbContext.Cars.Remove(deleteCarWithReference);

                await _dbContext.SaveChangesAsync();
            }

            return true;
        }
    }
}

