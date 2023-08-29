using API.Models.Base;

namespace API.Models.Login
{
    public class LoginResponse : BaseResponse
    {
        public LoginResponse()
        {
        }

        public LoginResponse(bool hasErrors) : base(hasErrors)
        {
        }

        public string AccessToken { get; set; }
    }
}
