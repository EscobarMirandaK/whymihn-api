using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Profile
    {
        [Column("IDNumber")]
        public string IdValue { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("IDType")]
        public byte? IdType { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Phone")]
        public string Phone { get; set; }

        [Column("Country")]
        public string Country { get; set; }

        [Column("Province")]
        public string Province { get; set; }

        [Column("Canton")]
        public string Canton { get; set; }

        [Column("District")]
        public string District { get; set; }

        [Column("Address")]
        public string DeliveryAddress { get; set; }

        [Column("IKNumber")]
        public string IKNumber { get; set; }
    }
}
