using API.Extensions;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Login
{
    public class LoginRequest
    {
        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(250, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Password { get; set; }
    }
}
