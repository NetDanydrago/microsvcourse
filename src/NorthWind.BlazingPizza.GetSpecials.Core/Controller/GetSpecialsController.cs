
namespace NorthWind.BlazingPizza.GetSpecials.Core.Controller
{
    internal class GetSpecialsController(IGetSpecialsInputPort inputPort, IGetSpecialsOutPutPort presenter) : IGetSpecialsController
    {
        public async Task<IEnumerable<PizzaSpecialDto>> GetSpecialsAsync()
        {
            await inputPort.GetSpecialsAsync();
            return presenter.PizzaSpecials;
        }
    }
}
