using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IModB.UI.DomainModel;

namespace IModB.UI
{
    public partial class BuildingUserControl : UserControl
    {
        List<Device> _devices = new List<Device>();

        public BuildingUserControl()
        {
            InitializeComponent();
        }


        private void Draw(Graphics g)
        {
            g.Clear(Color.Cornsilk);

            foreach (var room in _building.Rooms.Values)
            {
                room.Draw(g);
            }

            foreach (var device in _devices)
            {
                device.Draw(g);
            }
        }

        internal void HighLight(string sensorId, string deviceId)
        {
            var g = this.CreateGraphics();

            Draw(g);

            Sensor selectedSensor = null;
            Device selectedDevice = null;

            foreach (var room in _building.Rooms.Values)
            {
                foreach (var sensor in room.Sensors.Values)
                {
                    if (sensor.Id == sensorId)
                    {
                        sensor.HighLight(g, true);
                        selectedSensor = sensor;
                    }
                    else
                    {
                        sensor.HighLight(g, false);
                    }
                }
            }

            foreach (var device in _devices)
            {
                if (device.getMac() == deviceId)
                {
                    device.HighLight(g, true);
                    selectedDevice = device;
                }
                else
                {
                    device.HighLight(g, false);
                }
            }

            if (selectedDevice != null && selectedSensor != null)
            {
                g.DrawLine(Pens.Blue, selectedSensor.Coordinates.Location, selectedDevice.GetCoordinates());
            }
        }

        Building _building = new Building();
        internal void LoadData(Building building)
        {
            _building = building;
            var graphics = this.CreateGraphics();
            Draw(graphics);
        }

        private void BuildingUserControl_DoubleClick(object sender, EventArgs e)
        {
            var me = (MouseEventArgs)e;

            var device = new Device();
            device.Top = me.Y;
            device.Left = me.X;
            _devices.Add(device);

            Draw(this.CreateGraphics());
        }

        internal List<ScanResult> getScanResult()
        {
            var scanResult = new List<ScanResult>();

            foreach (var room in _building.Rooms.Values)
            {
                foreach (var sensor in room.Sensors.Values)
                {
                    scanResult.AddRange(sensor.Scan(_devices));
                }
            }

            return scanResult;
        }

        internal IEnumerable<Device> TrackAllDevices()
        {
            List<Sensor> allSensors = new List<Sensor>();
            foreach (var room in _building.Rooms.Values)
            {
                foreach (var sensor in room.Sensors.Values)
                {
                    allSensors.Add(sensor);
                }
            }

            foreach (var device in _devices)
            {
                device.Track(allSensors);
            }

            return _devices;
        }

        internal void PositionDevice(Device selectedDevice)
        {
            var g = this.CreateGraphics();
            this.Draw(g);
            selectedDevice.Position(g);
        }
    }
}
