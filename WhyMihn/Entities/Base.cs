using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Base
    {
        [Column("tenant_id")]
        public string TenantId { get; set; }

        [Column("client_id")]
        public string ClientId { get; set; }

        [Column("Result")]
        public int Result { get; set; }
    }
}
