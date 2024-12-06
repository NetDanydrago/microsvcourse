using Microsoft.EntityFrameworkCore;
using NorhWind.BlazingPizza.GetSpecials.BussinesObjects.Interfaces;
using NorthWind.BlazingPizza.GetSpecials.Entities.Dtos;
using NorthWind.BlazingPizza.GetSpecials.Repositories.DataContext;

namespace NorthWind.BlazingPizza.GetSpecials.Repositories
{
    internal class GetSpecialRepository(GetSpecialsContext context) : IGetSpecialsRepository
    {
        public async Task<IEnumerable<PizzaSpecialDto>> GetSpecialsSortedByDescendingPriceAsync()
        {
            var Specials = await context.PizzaSpecials
                .OrderByDescending(s => s.BasePrice)
                .Select(s => new PizzaSpecialDto(s.Id, s.Name, s.BasePrice, s.Description, s.ImageUrl))
                .ToListAsync();
            return Specials;
        }
    }
}
