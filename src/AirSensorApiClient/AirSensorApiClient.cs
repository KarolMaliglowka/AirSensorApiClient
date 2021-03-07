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
        private const string url = "http://api.gios.gov.pl/pjp-api/rest/";


        public List<Station> GetAllStations()
        {
            const string path = url + "station/findAll";
            try
            {
                var content = new WebClient().DownloadString(path);
                var result = JsonConvert.DeserializeObject<Station[]>(content).ToList();
                return result;
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }

        public List<Sensor> GetSensors(int stationId)
        {
            var path = url + "/station/sensors/" + stationId;
            try
            {
                var content = new WebClient().DownloadString(path);
                var result = JsonConvert.DeserializeObject<Sensor[]>(content).ToList();
                return result;
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }
    }
}