using API.Extensions;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Profile
{
    public class PutProfileRequest
    {
        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Name { get; set; }

        //[Required(ErrorMessage = ErrorMessage.RequiredField)]
        //[MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string LastName { get; set; }

        //[Required(ErrorMessage = ErrorMessage.RequiredField)]
        //[MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string SecondLastName { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        public byte? IdType { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(25, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string IdValue { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(250, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(8, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Phone { get; set; }

        public string Country { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        public string Province { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        public string Canton { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        public string District { get; set; }

        [Required(ErrorMessage = ErrorMessage.RequiredField)]
        public string Address { get; set; }
    }
}
