using System;
using System.Collections.Generic;
using System.Net;
using AirSensorApiClient.ViewModels;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AirSensorApiClient
{
    public class AirSensorApiClient : IAirSensorApiClient
    {
        private const string Url = "https://api.gios.gov.pl/pjp-api/rest/";

        public IEnumerable<Station> GetAllStations()
        {
            var path = $"{Url}station/findAll";
            try
            {
                var content = new WebClient().DownloadString(path);
                return JsonSerializer.Deserialize<List<Station>>(content)!;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<Sensor> GetSensors(int stationId)
        {
            var path = $"{Url}station/sensors/{stationId}";
            try
            {
                var content = new WebClient().DownloadString(path);
                return JsonSerializer.Deserialize<List<Sensor>>(content);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public SensorsData GetSensorData(int sensorId)
        {
            var path = $"{Url}data/getData/{sensorId}";
            try
            {
                var content = new WebClient().DownloadString(path);
                return JsonSerializer.Deserialize<SensorsData>(content);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IndexData GetIndexData(int stationId)
        {
            var path = $"{Url}aqindex/getIndex/{stationId}";
            try
            {
                var context = new WebClient().DownloadString(path);
                return JsonSerializer.Deserialize<IndexData>(context);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}