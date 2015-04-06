using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.DomainModels
{
    public class AllDevicesHelper : BaseHelper
    {
        public List<Device> GetAllDevices()
        {
            var devices = new List<Device>();
            var data = GetDataFromRemote("devices");
            var devicesRows = data["result"];

            if (devicesRows != null)
            {
                foreach (var device in devicesRows)
                {
                    var d = new Device();
                    d.DeviceId = device["DeviceId"].ToString();
                    d.DeviceName = device["Name"].ToString();
                    devices.Add(d);
                }
            }

            return devices;
        }

        internal List<LocationUpdate> LocationUpdatesByDevice(string deviceId)
        {
            var lus = new List<LocationUpdate>();

            var data = GetDataFromRemote("devices/" + deviceId);

            return ConvertToLocationUpdates(lus, data);
        }

        internal object LocationUpdatesBySensor(string deviceId, DateTime fromDate, DateTime endDate)
        {
            var lus = new List<LocationUpdate>();
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            var fromTicks = fromDate.ToString("yyyy-MM-ddTHH:mm:ss");
            var toTicks = endDate.ToString("yyyy-MM-ddTHH:mm:ss");

            var data = GetDataFromRemote("filterdevices?id=" + deviceId + "&from=" + fromTicks + "&to=" + toTicks);

            return ConvertToLocationUpdates(lus, data);
        }
    }
}
