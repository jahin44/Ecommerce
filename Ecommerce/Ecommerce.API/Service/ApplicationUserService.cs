using Ecommerce.API.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Ecommerce.API.Service
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
         private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationUserService(UserManager<IdentityUser> userManager,
                                        RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<Claim>> Login(LoginModel model)
        {
            if (model == null)
            {
                throw new FileNotFoundException("model can not be empty");
            }
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("UserId",user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                return authClaims;
            }
            else
            {
                return null;
            }


        }
    }
}
