using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiNative.Domain.Entities;
using WebApiNative.Infraestructure.DataAccess.Seeds;

namespace WebApiNative
{
    public class NativeDBContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public virtual DbSet<Producto> Productos { get; set; }
            
        public NativeDBContext(DbContextOptions<NativeDBContext> options)
      : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ProductoSeed());
            //modelBuilder.ApplyConfiguration(new AuthSeed());

            base.OnModelCreating(modelBuilder);
        }

    }
}
