using Ecommerce.API.Models;
using System.Security.Claims;

namespace Ecommerce.API.Service
{
    public interface IApplicationUserService
    {
        Task<List<Claim>> Login(LoginModel model);

    }
}
