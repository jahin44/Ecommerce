using Autofac;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.API.Models
{
    public class DataSeed
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public DataSeed()
        {

        }

        public void Resolve(ILifetimeScope scope)
        {
            _userManager = scope.Resolve<UserManager<IdentityUser>>();
            _roleManager = scope.Resolve<RoleManager<IdentityRole>>();

        }

        public async Task SeedAdminAsync()
        {
            var user = new IdentityUser
            {
                Email = "@admin.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Admin",
            };
            var Password = "Admin1@";

            var userExists = await _userManager.FindByNameAsync("Admin");
            if (userExists == null)
            {
                await _userManager.CreateAsync(user, Password);

                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }

                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }

                if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                }
                if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.User);
                }

            }

        }
    }
}

