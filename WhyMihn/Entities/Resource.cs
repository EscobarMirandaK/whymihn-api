using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Resource
    {
        [Key]
        [Column("tenant_id")]
        public string TenantId { get; set; }

        [Column("client_id")]
        public string ClientId { get; set; }

        [Column("key")]
        public string Key { get; set; }

        [Column("value")]
        public string Value { get; set; }

        [Column("language")]
        public string Language { get; set; }
    }
}
