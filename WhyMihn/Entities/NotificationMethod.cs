using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class NotificationMethod
    {
        [Key]
        [Column("tenant_id")]
        public string TenantId { get; set; }

        [Key]
        [Column("client_id")]
        public string ClientId { get; set; }

        [Key]
        [Column("notification_method_id")]
        public string NotificationMethodId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
