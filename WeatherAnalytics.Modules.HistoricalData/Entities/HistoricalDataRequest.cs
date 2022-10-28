using System.Text.Json.Serialization;

namespace WeatherAnalytics
{
    public class HistoricalDataRequest
    {
        public string Version { get; set; } = "v1";
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Timezone { get; set; } = "Europe/Berlin";
    }
}