using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Base;
using API.Models.Profile;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository profileRepository;

        public ProfileController(IProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }

        [Authorize(Role.USER, Role.ADMIN)]
        [Route("")]
        [HttpGet]
        public async Task<ActionResult<Profile>> Get()
        {
            var identity = HttpContext.User.Identity as System.Security.Claims.ClaimsIdentity;
            var loggedUser = PrincipalExtensions.GetUser(new System.Security.Claims.ClaimsPrincipal(identity));
            var response = new BaseResponse(false);

            if (loggedUser != null)
            {
                return await this.profileRepository.GetProfile(loggedUser);
            }

            response.HasErrors = true;
            response.AddError(ErrorMessage.UserNotFound);
            return BadRequest(response);
        }

        [Authorize(Role.USER, Role.ADMIN)]
        [HttpPut("")]
        public async Task<ActionResult<Profile>> Put([FromBody] PutProfileRequest profileRequest)
        {
            var identity = HttpContext.User.Identity as System.Security.Claims.ClaimsIdentity;
            var loggedUser = PrincipalExtensions.GetUser(new System.Security.Claims.ClaimsPrincipal(identity));
            var response = new BaseResponse(false);

            if (loggedUser != null)
            {
                var result = await this.profileRepository.PutProfile(profileRequest, loggedUser.IKNumber);
                
                if (result != null && result.Result == 0)
                {
                    return await this.profileRepository.GetProfile(loggedUser);
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
                            case 2:
                                response.AddError(ErrorMessage.InvalidEmail);
                                break;
                            case 5:
                                response.AddError(ErrorMessage.InvalidIdType);
                                break;
                            case 6:
                                response.AddError(ErrorMessage.InvalidIdentification);
                                break;
                            case 7:
                                response.AddError(ErrorMessage.InvalidPhone);
                                break;
                            case 9:
                                response.AddError(ErrorMessage.InvalidDeliveryType);
                                break;
                            default:
                                response.AddError(ErrorMessage.ErrorUpdatingProfile);
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
