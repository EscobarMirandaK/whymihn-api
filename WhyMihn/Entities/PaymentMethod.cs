using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class PaymentMethod
    {
        [Key]
        [Column("tenant_id")]
        public string TenantId { get; set; }

        [Key]
        [Column("client_id")]
        public string ClientId { get; set; }

        [Key]
        [Column("payment_method_id")]
        public string PaymentMethodId { get; set; }

        [Column("name")]
        public string Name { get; set; }

    }
}
