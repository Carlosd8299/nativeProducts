using Microsoft.EntityFrameworkCore;
using WebApiNative.Domain.Entities;

namespace WebApiNative
{
    public class NativeDBContext : DbContext
    {
        public virtual DbSet<Producto> Productos { get; set; }

        public NativeDBContext(DbContextOptions<NativeDBContext> options)
      : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Insertar registros iniciales
            modelBuilder.Entity<Producto>().HasData(
                new Producto("Medias", "Media Azul", "Ropa Interior", 12.80, 100),
                new Producto("Medias veladas", "Media Roja", "Ropa Interior", 12.80, 100),
                new Producto("Jeans Cargo", "Tipo militar", "Prendas Superiores", 120, 100),
                new Producto("Jeans Oversized", "Unisex", "Prendas Superiores", 120, 1000),
                new Producto("FaldaShort", "FaldaShort Azul", "Prendas Superiores", 30, 1000),
                new Producto("Vestido", "Vestido Azul", "Prenda Liviana", 50, 1000)
            );
        }

    }
}
