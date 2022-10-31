namespace WeatherAnalytics.Modules.HistoricalData.Services
{
    public interface IHistoricalDataService
    {
        Task<Entities.HistoricalData> GetHistoricalData(Entities.HistoricalDataRequest historicalData);
    }

    public class HistoricalDataService : IHistoricalDataService
    {
        public HistoricalDataService() { }

        public async Task<Entities.HistoricalData> GetHistoricalData(Entities.HistoricalDataRequest request)
        {
            string url = $"{Globals.OpenMeteoApiUrl}{request.Version}/era5?latitude={request.Latitude}&longitude={request.Longitude}&start_date={request.StartDate.ToString("yyyy-MM-dd")}&end_date={request.EndDate.ToString("yyyy-MM-dd")}&hourly=temperature_2m&timezone={request.Timezone}";
            var historicalData = new Entities.HistoricalData();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        historicalData = JsonConvert.DeserializeObject<Entities.HistoricalData>(result);
                    }
                }
            }
            return historicalData;
        }
    }
}
