using Microsoft.Extensions.DependencyInjection;
using NorthWind.BlazingPizza.ViewModels.GetSpecials;

namespace NorthWind.BlazingPizza.ViewModels
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddViewModel(this IServiceCollection services)
        {
            services.AddScoped<GetSpecialsViewModel>();
            return services;
        }
    }
}
