using API.Extensions;
using API.Interface;
using API.Models.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardRepository dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            this.dashboardRepository = dashboardRepository;
        }

        [Authorize(Role.USER, Role.ADMIN)]
        [Route("")]
        [HttpGet]
        public ActionResult<DashboardResponse> Get()
        {
            var identity = HttpContext.User.Identity as System.Security.Claims.ClaimsIdentity;
            var loggedUser = PrincipalExtensions.GetUser(new System.Security.Claims.ClaimsPrincipal(identity));
            Enum.TryParse(loggedUser?.RoleId.ToString(), out Role currentUserType);

            var response = new DashboardResponse(false);

            if (loggedUser != null)
            {
                response.IdClient = loggedUser.Email;
                response.Name = loggedUser.Name;
                response.Admin = currentUserType == Role.ADMIN;
                return response;
            }

            response.HasErrors = true;
            response.AddError(ErrorMessage.UserNotFound);
            return BadRequest(response);
        }
    }
}
