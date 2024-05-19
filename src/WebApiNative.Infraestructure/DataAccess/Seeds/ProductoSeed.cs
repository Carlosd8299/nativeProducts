using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using WebApiNative.Domain.Entities;

namespace WebApiNative.Infraestructure.DataAccess.Seeds
{
    public class ProductoSeed : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            // Insertar registros iniciales
            builder.HasData(
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
