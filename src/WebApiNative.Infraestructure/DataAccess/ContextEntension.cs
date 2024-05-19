using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiNative.Domain.Entities;

namespace WebApiNative.Infraestructure.DataAccess
{
    public static class ContextEntension
    {
        public static IServiceCollection AddContextExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<NativeDBContext>(options => options.UseSqlServer(configuration["ConnectionStrings:ProductsConnection"]))
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<NativeDBContext>()
                .AddDefaultTokenProviders()
                .AddApiEndpoints();
            return services;
        }
    }
}
