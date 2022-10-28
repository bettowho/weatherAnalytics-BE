using System.Text.Json.Serialization;

namespace WeatherAnalytics
{
    public class HistoricalData
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double GenerationTime_Ms { get; set; }
        public int Utc_Offset_Seconds { get; set; }
        public string Timezone { get; set; }
        public string Timezone_Abbreviation { get; set; }
        public double Elevation { get; set; }
        public TemperatureUnit Hourly_Units { get; set; }
        public TemperatureMeasurement Hourly { get; set; }
    }

    public class TemperatureMeasurement
    {
        public List<DateTime> Time { get; set; }
        public List<double> Temperature_2m { get; set; }
    }
    public class TemperatureUnit
    {
        public string Time { get; set; }
        public string Temperature_2m { get; set; }
    }
}