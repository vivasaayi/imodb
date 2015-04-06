using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.DomainModels
{
    public class AllSensorsHelper : BaseHelper
    {
        public List<Sensor> GetAllSensors()
        {
            var sensors = new List<Sensor>();

            var data = GetDataFromRemote("sensors");

            var sensorsRows = data["result"];

            if (sensorsRows != null)
            {
                foreach (var sensor in sensorsRows)
                {
                    var s = new Sensor();
                    s.SensorId = sensor["SensorId"].ToString();
                    sensors.Add(s);
                }
            }


            return sensors;
        }

        public List<LocationUpdate> LocationUpdatesBySensor(string sensorId)
        {
            var lus = new List<LocationUpdate>();

            var data = GetDataFromRemote("sensors/" + sensorId);

            return ConvertToLocationUpdates(lus, data);
        }

        internal object LocationUpdatesBySensor(string sensorId, DateTime fromDate, DateTime endDate)
        {
            var lus = new List<LocationUpdate>();
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            var fromTicks = fromDate.ToString("yyyy-MM-ddTHH:mm:ss");
            var toTicks = endDate.ToString("yyyy-MM-ddTHH:mm:ss"); 

            var data = GetDataFromRemote("filtersensors?id=" + sensorId + "&from=" + fromTicks + "&to=" + toTicks);

            return ConvertToLocationUpdates(lus, data);
        }


    }
}
