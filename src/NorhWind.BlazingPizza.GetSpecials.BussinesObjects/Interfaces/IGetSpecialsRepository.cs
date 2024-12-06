namespace NorhWind.BlazingPizza.GetSpecials.BussinesObjects.Interfaces
{
    public interface IGetSpecialsRepository
    {
        Task<IEnumerable<PizzaSpecialDto>> GetSpecialsSortedByDescendingPriceAsync();
    }
}
