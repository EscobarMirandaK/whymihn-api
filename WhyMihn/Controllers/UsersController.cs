using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Base;
using API.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository usersRepository;
        private readonly IEmailHelper emailHelper;

        public UsersController(IUsersRepository usersRepository, IEmailHelper emailHelper)
        {
            this.usersRepository = usersRepository;
            this.emailHelper = emailHelper;
        }

        [Authorize(Role.ADMIN)]
        [Route("user/{IKNumber}")]
        [HttpGet]
        public async Task<ActionResult<User>> Get(string IKNumber)
        {
            return await this.usersRepository.GetUser(IKNumber);
        }
    }
}
