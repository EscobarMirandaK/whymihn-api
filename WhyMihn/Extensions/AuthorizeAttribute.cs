using API.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace API.Extensions
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Role> _roles;

        public AuthorizeAttribute(params Role[] roles)
        {
            _roles = roles ?? new Role[] { };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = PrincipalExtensions.GetUser(context.HttpContext.User);
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault().Split(" ")[1];
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);

            Enum.TryParse(user?.UserType.ToString(), out Role currentUserType);

            if (jsonToken.ValidTo < DateTime.UtcNow || user == null || (!currentUserType.Equals(Role.ADMIN) && _roles.Any() && !_roles.Any(c => c.Equals(currentUserType))))
            {
                var response = new BaseResponse(true);
                response.AddError(ErrorMessage.Unauthorized);
                context.Result = new JsonResult(response) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
