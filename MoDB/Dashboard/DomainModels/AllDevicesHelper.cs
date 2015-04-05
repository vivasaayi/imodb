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
    }
}
