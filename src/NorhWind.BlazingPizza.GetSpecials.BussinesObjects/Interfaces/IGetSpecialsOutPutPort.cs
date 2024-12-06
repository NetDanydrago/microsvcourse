namespace NorhWind.BlazingPizza.GetSpecials.BussinesObjects.Interfaces
{
    public interface IGetSpecialsOutPutPort
    {
        IEnumerable<PizzaSpecialDto> PizzaSpecials { get; }

        Task HandleResultAsync(IEnumerable<PizzaSpecialDto> pizzaSpecials);
    }
}
