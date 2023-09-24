using API.Extensions;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Client
{
    public class ClientRequest
    {
        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string TenantId { get; set; }

        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string ClientId { get; set; }

        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Name { get; set; }
    }

}
