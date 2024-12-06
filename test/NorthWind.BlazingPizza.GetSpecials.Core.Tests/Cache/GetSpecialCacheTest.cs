using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using NorthWind.BlazingPizza.GetSpecials.Core.Cache;
using NorthWind.BlazingPizza.GetSpecials.Entities.Dtos;
using NSubstitute;

namespace NorthWind.BlazingPizza.GetSpecials.Core.Tests.Cache
{
    //Todo
    public class GetSpecialCacheTest
    {
        [Fact]
        public async Task SetSpecialsAsync_Should_Save_And_GetSpecialAsync_Should_Return_Same_Value_From_Cache()
        {
            // Arrange
            IEnumerable<PizzaSpecialDto> ExpectedSpecials = new List<PizzaSpecialDto>
            {
                new PizzaSpecialDto(3,"s3",30,"d3","i3"),
                new PizzaSpecialDto(4,"s4",40,"d4","i4"),
                new PizzaSpecialDto(5,"s5",50,"d5","i5"),
            };

            var CacheOptions = Options.Create(new MemoryDistributedCacheOptions());
            IDistributedCache Cache = new MemoryDistributedCache(CacheOptions);
            ILogger<GetSpecialCache> Logger = new NullLogger<GetSpecialCache>();
            var GetSpecialCache = new GetSpecialCache(Cache, Logger);

            await GetSpecialCache.SetSpecialsAsync(ExpectedSpecials);
            //Indicar que GetSpecialAsync retorns ExpectedSpecials

            var Result = await GetSpecialCache.GetSpecialsAsync();


            
            
            var Pairs = ExpectedSpecials.Zip(Result, (Expect, Actual) => new { Expect, Actual });

            Assert.Equal(ExpectedSpecials.Count(), Result.Count());

            Assert.All(Pairs, Pair => Assert.True(Pair.Expect.Id == Pair.Actual.Id &&
                Pair.Expect.Name == Pair.Actual.Name &&
                Pair.Expect.BasePrice == Pair.Actual.BasePrice &&
                Pair.Expect.Description == Pair.Actual.Description &&
                Pair.Expect.ImageUrl == Pair.Actual.ImageUrl)); 

        }

       

    }
}
