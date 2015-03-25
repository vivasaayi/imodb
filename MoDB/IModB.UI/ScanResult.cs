using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IModB.UI
{
    [DataContract]
    public class ScanResult
    {
        [DataMember]
        public Guid ReaderId {get;set;}
        [DataMember]
        public Guid DeviceId { get; set; }
        [DataMember]
        public double Distance { get; set; }
        [DataMember]
        public DateTime TimeStamp { get; set; }
    }
}
