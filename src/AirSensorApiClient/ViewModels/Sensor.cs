namespace AirSensorApiClient.ViewModels
{
    public class Sensor
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public Param Param { get; set; }
    }
}