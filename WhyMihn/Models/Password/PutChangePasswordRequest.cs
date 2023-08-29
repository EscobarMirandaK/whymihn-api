using API.Extensions;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Password
{
    public class PutChangePasswordRequest
    {
        //[Required(ErrorMessage = ErrorMessage.RequiredField)]
        //[MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Password { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [Compare(nameof(Password), ErrorMessage = ErrorMessage.PassowrdMismatch)]
        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Password2 { get; set; }

        public string Email { get; set; }
    }
}
