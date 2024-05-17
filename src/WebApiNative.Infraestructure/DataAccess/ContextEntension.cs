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
                           options.UseSqlServer("Server=tcp:carlosdlctest.database.windows.net,1433;Initial Catalog=bdnative;Persist Security Info=False;User ID=carlosdlc;Password=Thepower1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

            return services;
        }
    }
}
