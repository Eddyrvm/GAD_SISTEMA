using System.Data.Entity;

namespace GAD_SISTEMA.Models
{
    public class GadSistemaDbContext : DbContext
    {
        public GadSistemaDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}