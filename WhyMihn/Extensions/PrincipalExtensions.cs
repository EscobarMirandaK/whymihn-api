using API.Entities;
using System.Security.Claims;
using System.Text.Json;

namespace API.Extensions
{
    public static class PrincipalExtensions
    {
        public static User GetUser(this ClaimsPrincipal claimsPrincipal)
        {
            var userClaim = claimsPrincipal?.FindFirstValue(Jwt.User);
            var user = userClaim != null ? JsonSerializer.Deserialize<User>(userClaim) : null;
            return user;
        }
    }
}
