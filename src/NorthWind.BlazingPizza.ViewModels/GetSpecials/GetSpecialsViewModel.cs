using NorthWind.BlazingPizza.GetSpecials.Entities.Dtos;
using NorthWind.BlazingPizza.Proxies;

namespace NorthWind.BlazingPizza.ViewModels.GetSpecials
{
    public class GetSpecialsViewModel(GetSpecialProxy proxy)
    {
        public IEnumerable<PizzaSpecialDto> Specials { get; private set; }
        public async Task GetSpecialsAsync()
        {
            Specials = await proxy.GetPizzaSpecialsAsync();
        }
    }
}
