using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System;

namespace WeatherAnalytics.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    public class HistoricalDataController : ControllerBase
    {
        private static readonly HttpClient client = new();
        public HistoricalDataController()
        {
        }

        /// <summary>
        ///  Get all historic weather data in a specific location in a range of dates with a granularity of an hour. It uses Europe/Berlin timezone.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.Polizze.GetAll)]
        public async Task<ActionResult<HistoricalData>> Get([FromQuery]HistoricalDataRequest request)
        {
            try
            {
                string url = $"{Globals.OpenMeteoApiUrl}{request.Version}/era5?latitude={request.Latitude}&longitude={request.Longitude}&start_date={request.StartDate.ToString("yyyy-MM-dd")}&end_date={request.EndDate.ToString("yyyy-MM-dd")}&hourly=temperature_2m&timezone={request.Timezone}";
                var historicalData = new HistoricalData();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            historicalData = JsonConvert.DeserializeObject<HistoricalData>(result);
                            return Ok(historicalData);
                        }
                        else return BadRequest();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}