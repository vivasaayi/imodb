using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IModB.UI.DomainModel
{
    public delegate void DeviceSelected(Device device);

    public class Device
    {
        Guid id = Guid.NewGuid();

        public int Top, Left, Width = 20, Height = 20;

        bool selected = false;
        public event DeviceSelected OnDeviceSelected;

        public void Draw(Graphics g)
        {
            var pen = HighLighted ? Pens.Green : Pens.Red;


            g.DrawLine(pen, Left + (Width / 2), Top, Left + (Width / 2), Top + Height);
            g.DrawLine(pen, Left, Top + (Height / 2), Left + Width, Top + (Height / 2));
        }


        internal void checkClicked(Point point)
        {
            if (point.X >= this.Left && point.X < (this.Left + this.Width) &&
                point.Y > this.Top && point.Y < (this.Top + this.Height))
            {
                selected = true;
                
                if (this.OnDeviceSelected != null)
                {
                    this.OnDeviceSelected(this);
                }
            }
        }

        internal void setSelected(bool p, Graphics graphics)
        {
            if (selected)
            {
                selected = false;
                Draw(graphics);
            }
        }

        internal string getMac()
        {
            return id.ToString();
        }

        bool HighLighted;

        internal void HighLight(Graphics g, bool p)
        {
            HighLighted = p;
            Draw(g);
        }

        internal Point GetCoordinates()
        {
            return new Point(this.Left, this.Top);
        }

        internal void Track(IEnumerable<Sensor> allSensors)
        {
            List<Sensor> validSensors = new List<Sensor>();
            foreach (var sensor in allSensors)
            {
                var distance = Utils.CalculateDistance(this.Left, this.Top, sensor.Coordinates.Top, sensor.Coordinates.Left);

                if (distance < 170)
                {
                    validSensors.Add(sensor);
                }
            }
        }
    }
}
