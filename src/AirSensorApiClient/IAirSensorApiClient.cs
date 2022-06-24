using System.Collections.Generic;
using AirSensorApiClient.ViewModels;

namespace AirSensorApiClient
{
    public interface IAirSensorApiClient
    {
        List<Station> GetAllStations();
        List<Sensor> GetSensors(int stationId);
        SensorsData GetSensorData(int sensorId);
        IndexData GetIndexData(int stationId);
    }
}