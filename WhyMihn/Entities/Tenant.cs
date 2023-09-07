using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Tenant
    {
        [Key]
        [Column("tenant_id")]
        public string TenantId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
