using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class User : Base
    {
        [Key]
        [Column("email")]
        public string Email { get; set; }

        [Column("role_id")]
        public string RoleId { get; set; }

        [Column("TipoCuenta")]
        public string Username { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("password")]
        public string Password { get; set; }
    }
}
