using System.Reflection;

namespace WebApiNative.Extensions
{
    public static class MediatrExtension
    {
        public static IServiceCollection AddMediatorExtension(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
