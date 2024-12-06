using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWind.BlazingPizza.GetSpecials.Repositories.Entities;

namespace NorthWind.BlazingPizza.GetSpecials.Repositories.Configuration
{
    internal class PizzaSpecialConfiguration : IEntityTypeConfiguration<PizzaSpecial>
    {
        public void Configure(EntityTypeBuilder<PizzaSpecial> builder)
        {
            builder.Property(s => s.BasePrice).HasPrecision(8, 2);
            builder.HasData([
                 new PizzaSpecial{
                     Id = 1,
               Name = "Pizza clásica de queso",
               BasePrice = 89.99,
               Description = "Es de queso y delicioso. ¿Por qué no querrías una?",
               ImageUrl = "cheese.jpg"
           },
           new PizzaSpecial
           {
               Id = 2,
               Name = "Tocinator",
               BasePrice = 127.99,
               Description = "Tiene TODO tipo de tocino",
               ImageUrl = "bacon.jpg"
           },
           new PizzaSpecial
           {
               Id = 3,
               Name = "Clásica de pepperoni",
               BasePrice = 99.50,
               Description = "Es la pizza con la que creciste, ¡pero ardientemente deliciosa!",
               ImageUrl = "pepperoni.jpg"
           },
           new PizzaSpecial
           {
               Id = 4,
               Name = "Pollo búfalo",
               BasePrice = 128.75,
               Description = "Pollo picante, salsa picante y queso azul, garantizado que entrarás en calor",
               ImageUrl = "meaty.jpg"
           },
           new PizzaSpecial
           {
               Id = 5,
               Name = "Amantes del champiñón",
               BasePrice = 109.00,
               Description = "Tiene champiñones. ¿No es obvio?",
               ImageUrl = "mushroom.jpg"
           },
           new PizzaSpecial
           {
               Id = 6,
               Name = "Hawaiana",
               BasePrice = 90.25,
               Description = "De piña, jamón y queso...",
               ImageUrl = "hawaiian.jpg"
           },
           new PizzaSpecial
           {
               Id = 7,
               Name = "Delicia vegetariana",
               BasePrice = 118.50,
               Description = "Es como una ensalada, pero en una pizza",
               ImageUrl = "salad.jpg"
           },
           new PizzaSpecial
           {
               Id = 8,
               Name = "Margarita",
               BasePrice = 89.99,
               Description = "Pizza italiana tradicional con tomates y albahaca",
               ImageUrl = "margherita.jpg"
           },
           new PizzaSpecial
           {
               Id = 9,
               Name = "Margarita Especial",
               BasePrice = 160.00,
               Description = "Con la recete especial de la casa",
               ImageUrl = "margherita.jpg"
           }
            ]);
        }
    }
}
