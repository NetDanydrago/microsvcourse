using Microsoft.Extensions.Logging;
using NorthWind.BlazingPizza.GetSpecials.Entities.Dtos;
using NorthWind.BlazingPizza.GetSpecials.Entities.ValueObjects;
using System.Net.Http.Json;

namespace NorthWind.BlazingPizza.Proxies
{
    public class GetSpecialProxy(HttpClient client, ILogger<GetSpecialProxy> logger)
    {
        public async Task<IEnumerable<PizzaSpecialDto>> GetPizzaSpecialsAsync()
        {
            IEnumerable<PizzaSpecialDto> Specials = null;
            try
            {
                var Response = await client.GetAsync(Endpoints.GetSpecials);
                var ResponseText = await Response.Content.ReadAsStringAsync();
                logger.LogInformation("HTTP Status Code: {code}", Response.StatusCode);
                logger.LogInformation("HTTP Response Content: {content}", ResponseText);
                if (Response.IsSuccessStatusCode)
                {
                    Specials = await Response.Content.ReadFromJsonAsync<IEnumerable<PizzaSpecialDto>>();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error getting Pizza Specials");
            }
            return Specials ?? new List<PizzaSpecialDto>();
        }

    }
}
