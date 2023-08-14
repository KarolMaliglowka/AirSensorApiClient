namespace AirSensorApiClient.ViewModels
{
    public class Station
    {
        public int id { get; set; }
        public string stationName { get; set; }
        public string gegrLat { get; set; }
        public string gegrLon { get; set; }
        public City city { get; set; }
        public string addressStreet { get; set; }
    }
}