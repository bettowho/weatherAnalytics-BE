namespace WeatherAnalytics.Modules.HistoricalData.V1;

public static class ApiRoutes
{
    public const string Domain = "api";
    public const string Version = "v{version:apiVersion}";
    public const string Base = Domain + "/" + Version;


    public static class Polizze
    {
        public const string GetAll = Base + "/historicaldata";
    }

}