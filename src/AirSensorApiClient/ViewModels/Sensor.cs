namespace AirSensorApiClient.ViewModels
{
    public class Sensor
    {
        public int id { get; set; }
        public int stationId { get; set; }
        public Param param { get; set; }
    }
}