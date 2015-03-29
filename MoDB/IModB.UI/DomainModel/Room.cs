using System;
using System.Collections.Generic;
using System.Drawing;
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

        public void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Black, new Rectangle(Left, Top, Width, Height));

            foreach (var door in Doors.Values)
            {
                door.Draw(g);
            }

            foreach (var sensor in Sensors.Values)
            {
                sensor.Draw(g);
            }
        }

        internal void AddDoor(Door door)
        {
            Rectangle coordinates = GetCoordinates(door.Orientation, door.Alignment, 5, 20);

            door.Coordinates = coordinates;
            Doors.Add(door.Id, door);
        }
        internal void AddSensor(Sensor sensor)
        {
            Rectangle coordinates = GetCoordinates(sensor.Orientation, sensor.Alignment, 10, 10);

            sensor.Coordinates = coordinates;
            Sensors.Add(sensor.Id, sensor);
        }

        private Rectangle GetCoordinates(string orientation, string alignment, int itemWidth, int itemHeight)
        {
            Rectangle coordinates = new Rectangle();

            var yCenter = GetYCoordinate(alignment, itemHeight) + Top;
            var xCenter = GetXCoordinate(alignment, itemHeight) + Left;

            if (orientation == Orientation.VerticalRight.ToString())
            {
                coordinates = new Rectangle((Left + Width) - itemWidth, yCenter, itemWidth, itemHeight);
            }
            else if (orientation == Orientation.VerticalLeft.ToString())
            {
                coordinates = new Rectangle(Left, yCenter, itemWidth, itemHeight);
            }
            else if (orientation == Orientation.HorizontalTop.ToString())
            {
                coordinates = new Rectangle(xCenter, Top, itemHeight, itemWidth);
            }
            else if (orientation == Orientation.HorizontalBottom.ToString())
            {
                coordinates = new Rectangle(xCenter, (Top + Height) - itemWidth, itemHeight, itemWidth);
            }

            return coordinates;
        }

        private int GetXCoordinate(string alignment, int itemWidth)
        {
            if (alignment == Alignment.Center.ToString())
            {
                return ((Width) / 2) - (itemWidth / 2);
            }

            return 0;
        }

        private int GetYCoordinate(string alignment, int itemHeight)
        {
            if (alignment == Alignment.Center.ToString())
            {
                return ((Height) / 2) - (itemHeight/2);
            }
            else if (alignment == Alignment.Top.ToString())
            {
                return 0;
            }

            return 0;
        }
    }

}
