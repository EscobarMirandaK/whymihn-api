using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Client
    {
        [Key]
        [Column("tenant_id")]
        public string TenantId { get; set; }

        [Column("client_id")]
        public string ClientId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
