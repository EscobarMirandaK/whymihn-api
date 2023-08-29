using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class User : Base
    {
        [Column("Identificacion")]
        public string Id { get; set; }

        [Column("TipoCuenta")]
        public byte? UserType { get; set; }

        [Column("Usuario")]
        public string Username { get; set; }

        [Column("Nombre")]
        public string Name { get; set; }

        [Column("TipoId")]
        public string IdType { get; set; }

        [Column("Genero")]
        public byte? Genre { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Celular")]
        public string MobilePhone { get; set; }

        [Column("Telefono")]
        public string Phone { get; set; }

        [Column("GrupoInteres")]
        public string InterestGroup { get; set; }

        [Column("LocalizacionEntrega")]
        public string DeliveryAddress { get; set; }

        [Column("DireccionMiami")]
        public string MiamiAddress { get; set; }

        [Column("DireccionPostal")]
        public string PostalAddress { get; set; }

        [Column("TipoContacto")]
        public byte? ContactType { get; set; }

        [Column("AceptarNoticias")]
        public byte? AllowNotifications { get; set; }

        [Column("MontoPendiente")]
        public decimal? PendingAmount { get; set; }

        [Column("NumeroIK")]
        public string IKNumber { get; set; }

        [Column("Country")]
        public string Country { get; set; }

        [Column("Province")]
        public string Province { get; set; }

        [Column("Canton")]
        public string Canton { get; set; }

        [Column("District")]
        public string District { get; set; }

        [Column("State")]
        public string State { get; set; }

        public bool Admin { get; set; }
    }
}
