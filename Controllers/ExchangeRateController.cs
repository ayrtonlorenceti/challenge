using Microsoft.AspNetCore.Mvc;

namespace AfterShip_challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRateController : ControllerBase
    {
        private static readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://openexchangerates.org/api"),
        };

        private readonly ILogger<ExchangeRateController> _logger;

        public ExchangeRateController(ILogger<ExchangeRateController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ExchangeRate> GetAsync()
        {
            try
            {
                using HttpResponseMessage response = await httpClient.GetAsync("/latest.json?app_id=REQUIRED&prettyprint=false&show_alternative=false");

                return await response.Content.ReadFromJsonAsync<ExchangeRate>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }

        }
    }
}
