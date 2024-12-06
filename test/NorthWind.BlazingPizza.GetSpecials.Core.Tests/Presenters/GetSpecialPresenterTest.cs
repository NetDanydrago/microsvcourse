using Microsoft.Extensions.Options;
using NorhWind.BlazingPizza.GetSpecials.BussinesObjects.Options;
using NorthWind.BlazingPizza.GetSpecials.Core.Presenters;
using NorthWind.BlazingPizza.GetSpecials.Entities.Dtos;

namespace NorthWind.BlazingPizza.GetSpecials.Core.Tests.Presenters
{
    public class GetSpecialPresenterTest
    {
        //TDD Phases
        [Fact]
        public async Task HandlerResultAsync_Should_Set_PizzaSpecial()
        {
            // Arrange
            var options = Options.Create(new GetSpecialsOptions { ImageUrlBase = "http://example.com/" });
            var presenter = new GetSpecialsPresenter(options);

            var expectedSpecials = new List<PizzaSpecialDto>
                {
                    new PizzaSpecialDto(1, "Special 1", 10.0, "Description 1", "image1.jpg"),
                    new PizzaSpecialDto(2, "Special 2", 20.0, "Description 2", "image2.jpg"),
                    new PizzaSpecialDto(3, "Special 3", 30.0, "Description 3", "image3.jpg")
                };

            // Act
            await presenter.HandleResultAsync(expectedSpecials);

            // Assert
            Assert.Equal(expectedSpecials.Count, presenter.PizzaSpecials.Count());
            Assert.All(presenter.PizzaSpecials, special => Assert.StartsWith($"{ options.Value.ImageUrlBase}/", special.ImageUrl));

        }
    }
}
