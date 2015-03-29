using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IModB.UI
{
    public partial class Reader : UserControl
    {
        Guid id = Guid.NewGuid();

        public event ReaderSelected OnReaderSelected;

        ReaderOrientation _orientation;
        RoomUserControl _container;
        Rectangle _coordinates = new Rectangle();

        bool highlighted = false;

        public Reader()
        {
            InitializeComponent();
        }


        internal void Draw(Graphics graphics)
        {
            if (highlighted)
            {
                graphics.FillRectangle(Brushes.Red, _coordinates);
            }
            else
            {
                graphics.FillRectangle(Brushes.Black, _coordinates);
            }            
        }

        internal void Initialize(ReaderOrientation orientation, RoomUserControl room)
        {
            _orientation = orientation;
            _container = room;

            var horizontalCenter = room.Width / 2;
            var verticalCenter = room.Height / 2;

            if (orientation == ReaderOrientation.HorizontalTop)
            {
                _coordinates = new Rectangle(horizontalCenter - 10, 0, 20, 10);
            }
            else if (orientation == ReaderOrientation.HorizontalBottom)
            {
                _coordinates = new Rectangle(horizontalCenter - 10, _container.Height - 11, 20, 10);
            }
            else if (orientation == ReaderOrientation.VerticalLeft)
            {
                _coordinates = new Rectangle(0, verticalCenter - 10, 10, 20);
            }
            else if (orientation == ReaderOrientation.VerticalRight)
            {
                _coordinates = new Rectangle(_container.Width - 11, verticalCenter - 10, 10, 20);
            }
        }

        internal List<ScanResult> ScanDevices()
        {
            List<ScanResult> results = new List<ScanResult>();

            foreach (var device in this._container.getAllDevices())
            {
                var scanResult = new ScanResult();
                scanResult.ReaderId = this.id;
                scanResult.DeviceId = device.getMac();
                scanResult.TimeStamp = DateTime.Now;
                scanResult.Distance = CalculateDistance(device);
                results.Add(scanResult);
            }

            return results;
        }

        private double CalculateDistance(UI.Device device)
        {
            return Math.Sqrt(Math.Pow((device.Left - this._coordinates.X), 2) + Math.Pow((device.Top - this._coordinates.Y), 2));

        }

        internal Guid getId()
        {
            return id;
        }

        internal void HighLight(Graphics g, bool highlight)
        {
            highlighted = highlight;
            Draw(g);

            if (highlighted)
            {
                if (this.OnReaderSelected != null)
                {
                    this.OnReaderSelected(this);
                }
            }
        }

        internal Point GetCoordinates()
        {
            return new Point(this._coordinates.X, this._coordinates.Y);
        }
    }

    public delegate void ReaderSelected(Reader reader);

    public enum ReaderOrientation
    {
        VerticalRight,
        VerticalLeft,
        HorizontalTop,
        HorizontalBottom
    }
}
