using Microsoft.Extensions.DependencyInjection;

namespace NorthWind.BlazingPizza.Proxies
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddProxies(this IServiceCollection services, Action<HttpClient> configureSpecialsProxi)
        {
            services.AddHttpClient<GetSpecialProxy>(configureSpecialsProxi);
            return services;
        }
    }
}
