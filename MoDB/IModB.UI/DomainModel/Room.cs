using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IModB.UI.DomainModel
{
    public class Room
    {
        public string Id { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Dictionary<string, Door> Doors { get; set; }
        public Dictionary<string, Sensor> Sensors { get; set; }

        public Room()
        {
            Doors = new Dictionary<string, Door>();
            Sensors = new Dictionary<string, Sensor>();
        }
    }
}
