using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AirSensorApiClient.ViewModels;
using Newtonsoft.Json;

namespace AirSensorApiClient
{
    public class AirSensorApiClient : IAirSensorApiClient
    {
        private const string Url = "https://api.gios.gov.pl/pjp-api/rest/";

        public List<Station> GetAllStations()
        {
            var path = $"{Url}station/findAll";
            try
            {
                var content = new WebClient().DownloadString(path);
                var result = JsonConvert.DeserializeObject<Station[]>(content).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public List<Sensor> GetSensors(int stationId)
        {
            var path = $"{Url}station/sensors/{stationId}";
            try
            {
                var content = new WebClient().DownloadString(path);
                return JsonConvert.DeserializeObject<Sensor[]>(content).ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static SensorsData GetSensorData(int sensorId)
        {
            var path = $"{Url}data/getData/{sensorId}";
            try
            {
                var content = new WebClient().DownloadString(path);
                return JsonConvert.DeserializeObject<SensorsData>(content);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static IndexData GetIndexData(int stationId)
        {
            var path = $"{Url}aqindex/getIndex/{stationId}";
            try
            {
                var context = new WebClient().DownloadString(path);
                return JsonConvert.DeserializeObject<IndexData>(context);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}