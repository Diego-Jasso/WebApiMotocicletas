using Microsoft.EntityFrameworkCore;

using WebApiMotocicletas.Entidades;

namespace WebApiMotocicletas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<motocicletas> Motocicletas { get; set; }
        public DbSet<proveedor> Proveedor { get; set;}
    }
}
