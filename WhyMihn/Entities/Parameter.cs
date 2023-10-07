using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Parameter
    {
        [Key]
        [Column("tenant_id")]
        public string TenantId { get; set; }

        [Key]
        [Column("client_id")]
        public string ClientId { get; set; }

        [Key]
        [Column("parameter_id")]
        public string ParameterId { get; set; }

        [Key]
        [Column("table_name")]
        public string TableName { get; set; }

        [Column("parameter_value")]
        public string ParameterName { get; set; }

    }
}
