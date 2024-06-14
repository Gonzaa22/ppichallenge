using Microsoft.EntityFrameworkCore;
using PPIChallengeAPI.Models;
using PPIChallengeAPI.Models.Entities;

namespace PPIChallengeAPI.Conexion
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Activo> Activos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<TipoActivo> TiposActivo { get; set; }
    }
}
