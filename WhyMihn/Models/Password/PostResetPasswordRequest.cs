using API.Extensions;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Password
{
    public class PostResetPasswordRequest
    {
        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(250, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Email { get; set; }
    }
}
