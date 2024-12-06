using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NorthWind.BlazingPizza.GetSpecials.Repositories.Configuration;
using NorthWind.BlazingPizza.GetSpecials.Repositories.Entities;
using NorthWind.BlazingPizza.GetSpecials.Repositories.Options;

namespace NorthWind.BlazingPizza.GetSpecials.Repositories.DataContext
{
    internal class GetSpecialsContext : DbContext
    {

        readonly IOptions<GetSpecialsDbOptions> Options;

        public GetSpecialsContext(IOptions<GetSpecialsDbOptions> options)
        {
            Options = options;
            //Optimizacion para solo lecturar
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Options.Value.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PizzaSpecialConfiguration).Assembly);
        }

        public DbSet<PizzaSpecial> PizzaSpecials { get; set; }


    }
}
