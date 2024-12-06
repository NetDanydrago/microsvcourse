
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace NorthWind.BlazingPizza.GetSpecials.Core.Cache
{
    internal class GetSpecialCache(IDistributedCache cache, ILogger<GetSpecialCache> logger) : IGetSpecialsCache
    {
        const string CacheKey = "pizzaSpecials";

        public async Task<IEnumerable<PizzaSpecialDto>> GetSpecialsAsync()
        {
            IEnumerable<PizzaSpecialDto> Specials = null;
            try
            {
                string SpeciaJson = await cache.GetStringAsync(CacheKey);
                if (!string.IsNullOrEmpty(SpeciaJson))
                {
                    Specials = JsonSerializer.Deserialize<IEnumerable<PizzaSpecialDto>>(SpeciaJson);
                    logger.LogInformation("Get Special from cache");
                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return Specials;
        }

        public async Task SetSpecialsAsync(IEnumerable<PizzaSpecialDto> specials)
        {
            try
            {
                string SpecialsJson = JsonSerializer.Serialize(specials);
                await cache.SetStringAsync(CacheKey, SpecialsJson);
                logger.LogInformation("Set Specials in cache");

            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}
