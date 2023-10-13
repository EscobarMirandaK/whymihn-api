using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class User : Base
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("lastname")]
        public string Lastname { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("role_id")]
        public string RoleId { get; set; }

        [Column("password")]
        public string Password { get; set; }
    }
}
