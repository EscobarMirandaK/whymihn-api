using API.Extensions;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Register
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(250, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        public int IdType { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(25, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string IdValue { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Name { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string LastName { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string SecondLastName { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Password { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [Compare(nameof(Password), ErrorMessage = ErrorMessage.PassowrdMismatch)]
        public string Password2 { get; set; }

        public int Genre { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(8, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        public string Province { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        public string Canton { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        public string District { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        public string AddressArea { get; set; }
    }

}
