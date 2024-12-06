namespace NorhWind.BlazingPizza.GetSpecials.BussinesObjects.Interfaces
{
    public interface IGetSpecialsCache
    {
        Task<IEnumerable<PizzaSpecialDto>> GetSpecialsAsync();
        Task SetSpecialsAsync(IEnumerable<PizzaSpecialDto> specials);
    }
}
