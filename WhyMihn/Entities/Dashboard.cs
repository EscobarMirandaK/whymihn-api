using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Dashboard
    {
        [Column("ID")]
        public string IdClient { get; set; }

        [Column("Name")]
        public string Name { get; set; }
    }
}
