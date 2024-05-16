using System.Reflection;

namespace WebApiNative
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
