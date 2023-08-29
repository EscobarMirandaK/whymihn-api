using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

    }
}
