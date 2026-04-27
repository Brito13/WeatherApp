namespace CityWeather.Model
{
    public class WeatherCity
    {
        public Guid id = Guid.NewGuid(); 
        public string CityUniqueCode { get; set; }
        public string CityName { get; set; }
        public DateTime DateAndTime { get; set; }
        public int TemperatureFah { get; set; }


    }
}
