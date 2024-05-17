using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiNative.Infraestructure.DataAccess
{
    public static class ContextEntension
    {
        public static IServiceCollection AddContextExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NativeDBContext>(options =>
                           options.UseSqlServer("Server=CARCARLOSDELAC\\SQLEXPRESS;Database=productos;Trusted_Connection=True;Trust Server Certificate=True;"));

            return services;
        }
    }
}
