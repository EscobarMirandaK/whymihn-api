using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Base;
using API.Models.Password;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("password")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordRepository passwordRepository;

        private readonly IEmailHelper emailHelper;

        public PasswordController(IPasswordRepository passwordRepository, IEmailHelper emailHelper)
        {
            this.passwordRepository = passwordRepository;
            this.emailHelper = emailHelper;
        }

        [HttpPost("reset")]
        public async Task<ActionResult<Base>> ResetPassword(PostResetPasswordRequest request)
        {
            var response = new BaseResponse(false);

            if (request != null)
            {
                int length = 10;
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
                var random = new Random();
                string password = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
                var result = await this.passwordRepository.ResetPassword(request.Email, password);

                if (result != null && result.Result == 0)
                {
                    this.emailHelper.SendPasswordResetEmail(request.Email, password);


                    return Ok(response);
                }
                else
                {
                    response.HasErrors = true;

                    if (result != null)
                    {
                        switch (result.Result)
                        {
                            case 1:
                                response.AddError(ErrorMessage.UserNotFound);
                                break;
                            default:
                                response.AddError(ErrorMessage.ErrorResetingPassword);
                                break;
                        }
                    }

                    return BadRequest(response);
                }
            }
            else
            {
                response.AddError(ErrorMessage.UserNotFound);
                return BadRequest(response);
            }
        }

        [Authorize(Role.USER, Role.ADMIN)]
        [Route("change/{IKNumber?}")]
        [HttpPut]
        public async Task<ActionResult<Base>> ChangePassword([FromBody] PutChangePasswordRequest changePasswordRequest, string IKNumber)
        {
            var identity = HttpContext.User.Identity as System.Security.Claims.ClaimsIdentity;
            var loggedUser = PrincipalExtensions.GetUser(new System.Security.Claims.ClaimsPrincipal(identity));
            Enum.TryParse(loggedUser?.UserType.ToString(), out Role currentUserType);
            var response = new BaseResponse(false);

            if (loggedUser != null)
            {
                var result = new Base();

                switch (currentUserType)
                {
                    case Role.USER:
                        result = await this.passwordRepository.ChangePassword(changePasswordRequest, loggedUser.IKNumber);
                        break;
                    case Role.ADMIN:

                        if (string.IsNullOrEmpty(IKNumber))
                        {
                            response.HasErrors = true;
                            response.AddError(ErrorMessage.InvalidIKNumber);
                            return BadRequest(response);
                        }

                        result = await this.passwordRepository.ChangePassword(changePasswordRequest, IKNumber);
                        break;
                    default:
                        response.HasErrors = true;
                        response.AddError(ErrorMessage.UserNotFound);
                        return BadRequest(response);
                }

                if (result != null && result.Result == 0)
                {
                    return Ok(response);
                }
                else
                {
                    response.HasErrors = true;

                    if (result != null)
                    {
                        switch (result.Result)
                        {
                            case 1:
                                response.AddError(ErrorMessage.IncorrectUserPassword);
                                break;
                            default:
                                response.AddError(ErrorMessage.ErrorUpdatingPassword);
                                break;
                        }
                    }

                    return BadRequest(response);
                }


            }
            else
            {
                response.AddError(ErrorMessage.UserNotFound);
                return BadRequest(response);
            }
        }
    }
}
