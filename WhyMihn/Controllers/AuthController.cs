using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Base;
using API.Models.Login;
using API.Models.Register;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IAuthRepository authRepository;
        private readonly IEmailHelper emailHelper;

        public AuthController(IConfiguration config, IAuthRepository authRepository, IEmailHelper emailHelper)
        {
            _configuration = config;
            this.authRepository = authRepository;
            this.emailHelper = emailHelper;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginRequest != null && loginRequest.Email != null && loginRequest.Password != null)
            {
                var user = await GetUser(loginRequest);

                if (user != null && user.Result == 0)
                {
                    Enum.TryParse(user?.RoleId.ToString(), out Role currentUserType);
                    JwtSecurityToken token = GetToken(user);
                    var response = new LoginResponse { AccessToken = new JwtSecurityTokenHandler().WriteToken(token) };
                    
                    return Ok(response);
                }
                else
                {
                    var response = new LoginResponse(true);
                    response.AddError(ErrorMessage.InvalidCredentials);
                    return Unauthorized(response);
                }
            }
            else
            {
                var response = new LoginResponse(true);
                response.AddError(ErrorMessage.InvalidData);
                return BadRequest(response);
            }
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var result = await this.authRepository.Register(registerRequest);
            var response = new BaseResponse(false);
            
            if (result != null && result.Result == 0)
            {
                this.emailHelper.SendWelcomeEmail(result);
                this.emailHelper.SendNewRegstrationEmail(result);
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
                            response.AddError(ErrorMessage.UserAlreadyExists);
                            break;
                        case 3:
                            response.AddError(ErrorMessage.InvalidContactType);
                            break;
                        case 4:
                            response.AddError(ErrorMessage.InvalidUserType);
                            break;
                        case 5:
                            response.AddError(ErrorMessage.InvalidIdType);
                            break;
                        case 8:
                            response.AddError(ErrorMessage.InvalidInterestGroup);
                            break;
                        case 11:
                            response.AddError(ErrorMessage.ErrorGettingTheMLNumber);
                            break;
                        default:
                            response.AddError(ErrorMessage.ErrorCreatingUser);
                            break;
                    }
                }
                
                return BadRequest(response);
            }
            
        }

        private async Task<User> GetUser(LoginRequest loginRequest)
        {
            return await this.authRepository.Login(loginRequest);
        }

        private JwtSecurityToken GetToken(User user)
        {
            //create claims details based on the user information
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration[Jwt.Subject]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(Jwt.User, JsonSerializer.Serialize(user))
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[Jwt.Key]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration[Jwt.Issuer],
                _configuration[Jwt.Audience],
                claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration[Jwt.ExpirationMinutes])),
                signingCredentials: signIn);
            return token;
        }
    }
}
