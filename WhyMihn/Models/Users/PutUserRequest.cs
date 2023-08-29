using API.Extensions;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Users
{
    public class PutUserRequest
    {
        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string FirstName { get; set; }

        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string SecondLastName { get; set; }

        public byte? IdType { get; set; }

        [MaxLength(25, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Identification { get; set; }

        [MaxLength(250, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Email { get; set; }

        [MaxLength(8, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Phone { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }

        public string Canton { get; set; }

        public string District { get; set; }

        public string DeliveryAddress { get; set; }
    }

}
