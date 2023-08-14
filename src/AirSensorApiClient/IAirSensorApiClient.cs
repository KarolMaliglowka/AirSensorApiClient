using System.Collections.Generic;
using AirSensorApiClient.ViewModels;

namespace AirSensorApiClient
{
    public interface IAirSensorApiClient
    {
        IEnumerable<Station> GetAllStations();
        IEnumerable<Sensor> GetSensors(int stationId);
        SensorsData GetSensorData(int sensorId);
        IndexData GetIndexData(int stationId);
    }
}