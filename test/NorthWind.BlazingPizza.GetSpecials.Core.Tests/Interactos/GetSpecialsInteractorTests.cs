using NorhWind.BlazingPizza.GetSpecials.BussinesObjects.Interfaces;
using NorthWind.BlazingPizza.GetSpecials.Core.Interactors;
using NorthWind.BlazingPizza.GetSpecials.Entities.Dtos;
using NSubstitute;

namespace NorthWind.BlazingPizza.GetSpecials.Core.Tests.Interactos
{
    public class GetSpecialsInteractorTests
    {
        //TDD Phases
        [Fact]
        public async Task GetSpecialsAsync_ShouldInvokeHandlerResultAsync_WithPizzaSpecial()
        {
            //Arrange
            var Repository = Substitute.For<IGetSpecialsRepository>();
            var Presenter = Substitute.For<IGetSpecialsOutPutPort>();
            var Cache = Substitute.For<IGetSpecialsCache>();

            var Interactor = new GetSpecialsInteractor(Repository, Presenter,Cache);

            var ExpectedSpecials = new List<PizzaSpecialDto>
            {
                new PizzaSpecialDto(3,"s3",30,"d3","i3"),
                new PizzaSpecialDto(4,"s4",40,"d4","i4"),
                new PizzaSpecialDto(5,"s5",50,"d5","i5"),
            };

            Cache.GetSpecialsAsync().Returns(ExpectedSpecials);

            Repository.GetSpecialsSortedByDescendingPriceAsync().Returns(ExpectedSpecials);
            //Act
            await Interactor.GetSpecialsAsync();
            //Assert
            await Presenter.Received(1).HandleResultAsync(Arg.Is<IEnumerable<PizzaSpecialDto>>(specials => specials == ExpectedSpecials));

        }

        [Fact]
        public async Task GetSpecialAsync_Should_GetFromCache_When_CacheData()
        {
            //Arrange
            var ExpectedSpecials = new List<PizzaSpecialDto>
            {
                new PizzaSpecialDto(3,"s3",30,"d3","i3"),
                new PizzaSpecialDto(4,"s4",40,"d4","i4"),
                new PizzaSpecialDto(5,"s5",50,"d5","i5"),
            };

            var Repository = Substitute.For<IGetSpecialsRepository>();
            var Presenter = Substitute.For<IGetSpecialsOutPutPort>();
            var Cache = Substitute.For<IGetSpecialsCache>();

            Cache.GetSpecialsAsync().Returns(ExpectedSpecials);
            
            var Interactor = new GetSpecialsInteractor(Repository, Presenter, Cache);
            //Act
            await Interactor.GetSpecialsAsync();

            //
            await Cache.Received(1).GetSpecialsAsync();
            await Repository.DidNotReceive().GetSpecialsSortedByDescendingPriceAsync();

        }

        [Fact]
        public async Task GetSpecialAsync_Should_GetFromRepository_When_CacheIsEmpty()
        {
            //Arrange
            var ExpectedSpecials = new List<PizzaSpecialDto>
            {
                new PizzaSpecialDto(3,"s3",30,"d3","i3"),
                new PizzaSpecialDto(4,"s4",40,"d4","i4"),
                new PizzaSpecialDto(5,"s5",50,"d5","i5"),
            };

            var Repository = Substitute.For<IGetSpecialsRepository>();
            var Presenter = Substitute.For<IGetSpecialsOutPutPort>();
            var Cache = Substitute.For<IGetSpecialsCache>();

            Cache.GetSpecialsAsync().Returns((IEnumerable<PizzaSpecialDto>)null);
            Repository.GetSpecialsSortedByDescendingPriceAsync().Returns(ExpectedSpecials);

            var Interactor = new GetSpecialsInteractor(Repository, Presenter, Cache);

            //Act

            await Interactor.GetSpecialsAsync();

            //Assert

            await Cache.Received(1).GetSpecialsAsync();
            await Repository.Received(1).GetSpecialsSortedByDescendingPriceAsync();
            await Cache.Received(1).SetSpecialsAsync(ExpectedSpecials);

        }
    }
}
