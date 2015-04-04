using IModBLocationInfoCollector;
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

        public string DeviceId
        {
            get
            {
                return id.ToString();
            }
        }

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

        List<ApCircle> _circles = new List<ApCircle>();
        
        internal void Track(IEnumerable<Sensor> allSensors)
        {
            
            foreach (var sensor in allSensors)
            {
                var distance = Utils.CalculateDistance(this.Left, this.Top, sensor.Coordinates.X, sensor.Coordinates.Y);

                if (distance < 170)
                {
                    ApCircle circle = new ApCircle();
                    circle.X = sensor.Coordinates.X;
                    circle.Y = sensor.Coordinates.Y;
                    circle.Radius = (int)distance;
                    _circles.Add(circle);
                }
            }

        }



        internal void Position(Graphics graphics)
        {
            foreach (var circle in _circles)
            {
                graphics.DrawEllipse(Pens.Black, circle.X - circle.Radius, circle.Y - circle.Radius, 2 * circle.Radius, 2 * circle.Radius);
            }

            var triangulator = new Triangulator();
            var _allIntersectingPoints = triangulator.GetAllIntersectingPoints(_circles);
            var location = triangulator.GetCentroidForPoints(_allIntersectingPoints);

            foreach (var point in _allIntersectingPoints)
            {
                graphics.DrawEllipse(Pens.Blue, point.X - 10, point.Y - 10, 20, 20);
            }

            graphics.FillEllipse(Brushes.Violet, location.X - 10, location.Y - 10, 20, 20);
        }
    }
}
