using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IModB.UI.DomainModel
{
    public class Sensor
    {
        public string Id {get;set;}
        public string RoomId { get; set; }
        public string Orientation { get; set; }
        public string Alignment { get; set; }
        public System.Drawing.Rectangle Coordinates { get; set; }

        bool highlighted = false;

        internal void Draw(System.Drawing.Graphics g)
        {
            if (!highlighted)
            {
                g.FillRectangle(Brushes.Blue, Coordinates);
            }
            else
            {
                g.FillRectangle(Brushes.Green, Coordinates);
            }
        }

        internal IEnumerable<ScanResult> Scan(List<Device> _devices)
        {
            List<ScanResult> _scanResult = new List<ScanResult>();

            foreach (var device in _devices)
            {
                var distance = Utils.CalculateDistance(this.Coordinates.X, this.Coordinates.Y, device.Left, device.Top);
                if (distance <= 180)
                {
                    var scanResult = new ScanResult();
                    scanResult.SensorId = this.Id;
                    scanResult.DeviceId = device.getMac();
                    scanResult.TimeStamp = DateTime.Now;
                    scanResult.Distance = distance;
                    _scanResult.Add(scanResult);
                }
            }

            return _scanResult;
        }


        internal void HighLight(Graphics g, bool highlight)
        {
            highlighted = highlight;

            Draw(g);
        }
    }
}
