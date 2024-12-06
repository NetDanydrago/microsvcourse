namespace NorhWind.BlazingPizza.GetSpecials.BussinesObjects.Interfaces
{
    public interface IGetSpecialsController
    {
        Task<IEnumerable<PizzaSpecialDto>> GetSpecialsAsync();
    }
}
