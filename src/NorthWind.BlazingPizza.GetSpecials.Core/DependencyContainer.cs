using NorthWind.BlazingPizza.GetSpecials.Core.Cache;
using NorthWind.BlazingPizza.GetSpecials.Core.Controller;
using NorthWind.BlazingPizza.GetSpecials.Core.Presenters;

namespace NorthWind.BlazingPizza.GetSpecials.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetSpecialCoreServices(this IServiceCollection services, Action<GetSpecialsOptions> configureGetSpecialOptions)
        {
            services.AddScoped<IGetSpecialsInputPort, GetSpecialsInteractor>();
            services.AddScoped<IGetSpecialsOutPutPort, GetSpecialsPresenter>();
            
            services.AddScoped<IGetSpecialsController,GetSpecialsController>();

            services.AddSingleton<IGetSpecialsCache, GetSpecialCache>();
            
            services.Configure(configureGetSpecialOptions);
            return services;
        }
    }
}
