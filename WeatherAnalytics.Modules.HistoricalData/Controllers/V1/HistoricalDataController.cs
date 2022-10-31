using WeatherAnalytics.Modules.HistoricalData.Entities;
using WeatherAnalytics.Modules.HistoricalData.Services;

namespace WeatherAnalytics.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    public class HistoricalDataController : ControllerBase
    {
        private readonly IHistoricalDataService _historicalDataService;
        public HistoricalDataController(IHistoricalDataService historicalDataService)
        {
            _historicalDataService = historicalDataService;
        }

        /// <summary>
        ///  Get all historic weather data in a specific location in a range of dates with a granularity of an hour. It uses Europe/Berlin timezone.
        /// </summary>
        /// <param name="request></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.Polizze.GetAll)]
        public async Task<ActionResult<HistoricalData>> Get([FromQuery]HistoricalDataRequest request)
        {
            try
            {
                var historicalData = new HistoricalData();
                historicalData = await _historicalDataService.GetHistoricalData(request);
                if (historicalData != null) return Ok(historicalData);
                else return BadRequest("No data.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}