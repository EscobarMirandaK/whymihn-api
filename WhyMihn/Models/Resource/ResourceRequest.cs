using API.Extensions;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Resource
{
    public class ResourceRequest
    {
        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string TenantId { get; set; }

        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string ClientId { get; set; }

        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Key { get; set; }

        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Value { get; set; }

        [MaxLength(100, ErrorMessage = ErrorMessage.MaximumLenghtAllowed)]
        public string Language { get; set; }
    }

}
