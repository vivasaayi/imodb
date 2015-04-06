using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IModB.UI.DomainModel
{
    [DataContract]
    public class ScanResult
    {
        [DataMember]
        public string DeviceName { get; set; }
        [DataMember]
        public string DeviceId { get; set; }
        [DataMember]
        public string SensorId {get;set;}
        [DataMember]
        public double Rssi { get; set; }
        [DataMember]
        public double DistanceFromDevice { get; set; }
        [DataMember]
        public DateTime TimeStamp { get; set; }

        public ScanResult()
        {
            DeviceName = "DN-" + DeviceId;
        }
    }
}
