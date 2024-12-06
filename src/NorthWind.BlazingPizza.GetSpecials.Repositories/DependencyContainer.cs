using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NorhWind.BlazingPizza.GetSpecials.BussinesObjects.Interfaces;
using NorthWind.BlazingPizza.GetSpecials.Repositories.DataContext;
using NorthWind.BlazingPizza.GetSpecials.Repositories.Options;

namespace NorthWind.BlazingPizza.GetSpecials.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, Action<GetSpecialsDbOptions> configureDbOptions)
        {
            services.AddDbContext<GetSpecialsContext>();
            services.AddScoped<IGetSpecialsRepository, GetSpecialRepository>();
            services.Configure(configureDbOptions);
            return services;
        }

        public static IHost InitializeDB(this IHost app)
        {
            using IServiceScope serviceScope = app.Services.CreateScope();
            var Context = serviceScope.ServiceProvider.GetRequiredService<GetSpecialsContext>();
            Context.Database.EnsureCreated();
            return app;
        }  
    }
}
