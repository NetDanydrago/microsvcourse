using NorhWind.BlazingPizza.GetSpecials.BussinesObjects.Interfaces;
using NorthWind.BlazingPizza.GetSpecials.Core.Controller;
using NorthWind.BlazingPizza.GetSpecials.Entities.Dtos;
using NSubstitute;

namespace NorthWind.BlazingPizza.GetSpecials.Core.Tests.Controllers
{
    public class GetSpecialsControllerTest
    {
        [Fact]
        public async Task GetSpecialsAsync_ShouldInvokeInputPortAndReturnPizzaSpecials()
        {
            //Arrage
            var InputPort = NSubstitute.Substitute.For<IGetSpecialsInputPort>();
            var OutPort = NSubstitute.Substitute.For<IGetSpecialsOutPutPort>();

            var ExpectedSpecials = new List<PizzaSpecialDto>
            {
                new PizzaSpecialDto(3,"s3",30,"d3","i3"),
                new PizzaSpecialDto(4,"s4",40,"d4","i4"),
                new PizzaSpecialDto(5,"s5",50,"d5","i5"),
            };

            OutPort.PizzaSpecials.Returns(ExpectedSpecials);
            InputPort.GetSpecialsAsync().Returns(Task.CompletedTask);

            var Controller = new GetSpecialsController(InputPort, OutPort);

            //Act
            var ReturndSpecials = await Controller.GetSpecialsAsync();

            await InputPort.Received(1).GetSpecialsAsync();
            Assert.Equal(ExpectedSpecials, ReturndSpecials);
        } 
    }
}
