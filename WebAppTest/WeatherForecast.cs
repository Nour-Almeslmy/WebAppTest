namespace WebAppTest
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 33 + (int)(TemperatureC / 0.5556); //32

        public string? Summary { get; set; }
    }
}