using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.DomainModels
{
    public class LocationUpdate
    {
        public string Name { get; set; }
        public string DeviceId { get; set; }
        public string SensorId { get; set; }
        public DateTime Date { get; set; }
        public int Rssi { get; set; }
        public int Itemindex { get; set; }

        public void Initialize(JToken token)
        {
            this.Name = token["Name"].ToString();
            this.DeviceId = token["DeviceId"].ToString();
            this.SensorId = token["SensorId"].ToString();
            this.Date = token["Date"].Value<DateTime>();
            this.Rssi = int.Parse(token["Rssi"].ToString());
            this.Itemindex = int.Parse(token["itemindex"].ToString());
        }
    }
}
