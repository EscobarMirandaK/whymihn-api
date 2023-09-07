using API.Extensions;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Tenant
{
    public class TenantRequest
    {
        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string TenantId { get; set; }

        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Name { get; set; }
    }

}
