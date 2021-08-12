using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AirSensorApiClient.ViewModels;
using Newtonsoft.Json;

namespace AirSensorApiClient
{
    public class AirSensorApiClient
    {
        private const string Url = "http://api.gios.gov.pl/pjp-api/rest/";

        public List<Station> GetAllStations()
        {
            var path = $"{Url}/station/findAll";
            try
            {
               return JsonConvert.DeserializeObject<Station[]>(GetContext(path)).ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public List<Sensor> GetSensors(int stationId)
        {
            var path = $"{Url}/station/sensors/" + stationId;
            try
            {
                return JsonConvert.DeserializeObject<Sensor[]>(GetContext(path)).ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public SensorsData GetSensorData(int sensorId)
        {
            var path = $"{Url}/data/getData/{sensorId}";
            try
            {
                return JsonConvert.DeserializeObject<SensorsData>(GetContext(path));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IndexData GetIndexData(int StationId)
        {
            var path = $"{Url}/aqindex/getIndex/{StationId}";
            try
            {
                return JsonConvert.DeserializeObject<IndexData>(GetContext(path));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        private static string GetContext(string path)
        {
            return new WebClient().DownloadString(path);
        }
    }
}