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

            foreach (var sensor in sensorsRows)
            {
                var s = new Sensor();
                s.SensorId = sensor["SensorId"].ToString();
                sensors.Add(s);
            }

            return sensors;
        }
    }
}
