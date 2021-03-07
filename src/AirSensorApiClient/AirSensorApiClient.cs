using System;
using System.Collections.Generic;
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
            var stationsList = new List<Station>();
            try
            {
                var content = new WebClient().DownloadString(path);
                var result = JsonConvert.DeserializeObject<Station[]>(content);
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        stationsList.Add(new Station
                        {
                            Id = item.Id,
                            StationName = item.StationName,
                            GegrLat = item.GegrLat,
                            GegrLon = item.GegrLon,
                            AddressStreet = item.AddressStreet,
                            City = item.City
                        });
                    }
                }
                return stationsList;
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }

        public List<Sensor> GetSensors(int StationId)
        {
            var sensorsList = new List<Sensor>();
            var path = url + "/station/sensors/" + StationId;
            try
            {
                var content = new WebClient().DownloadString(path);

                var result = JsonConvert.DeserializeObject<Sensor[]>(content);
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        sensorsList.Add(new Sensor
                        {
                            id = item.id,
                            stationId = item.stationId,
                            param = item.param
                        });
                    }
                }

                return sensorsList;
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }


    }


}
