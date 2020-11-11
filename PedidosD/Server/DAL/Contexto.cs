using Microsoft.EntityFrameworkCore;
using PedidosD.Shared.Models;

namespace PedidosD.Server
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = Data\Pedidos.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personas>(entity =>
            {
                entity.HasKey(e => e.PersonaId).HasName("PK_PersonaId");
            });

            modelBuilder.Entity<Prestamos>(entity =>
            {
                entity.HasKey(e => e.PrestamoId).HasName("PK_PrestamoId");
            });
        }
    }
}