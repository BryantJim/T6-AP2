using Microsoft.EntityFrameworkCore;
using PedidosD.Shared.Models;

namespace PedidosD.Server
{
    public class Contexto : DbContext
    {
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Ordenes> Ordenes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = Data\Pedidos.db");
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores{ SuplidorId = 1,Nombres ="Suplidores Equipos tecnológicos"});
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores{ SuplidorId = 2,Nombres ="Suplidores Electricos"});
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores{ SuplidorId = 3,Nombres ="Suplidores Alimentarios"});

            modelBuilder.Entity<Productos>().HasData(new Productos{ ProductoId = 1,Descripcion = "Toshiba i5-3000U", Costo = 12500, Inventario = 200});
            modelBuilder.Entity<Productos>().HasData(new Productos{ ProductoId = 2,Descripcion = "Coca cola 20oz", Costo = 20, Inventario = 2500});
            modelBuilder.Entity<Productos>().HasData(new Productos{ ProductoId = 3,Descripcion = "Guantes electricos", Costo = 10, Inventario = 200});
            modelBuilder.Entity<Productos>().HasData(new Productos{ ProductoId = 1,Descripcion = "iPhone 12", Costo = 45000, Inventario = 200});
            modelBuilder.Entity<Productos>().HasData(new Productos{ ProductoId = 2,Descripcion = "Coca cola 2L", Costo = 50, Inventario = 1500});
            modelBuilder.Entity<Productos>().HasData(new Productos{ ProductoId = 3,Descripcion = "Switch", Costo = 5, Inventario = 300});
         }
    }
}