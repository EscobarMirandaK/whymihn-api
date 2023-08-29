using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Base
    {
        [Column("Result")]
        public int Result { get; set; }
    }
}
