using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IModB.UI.UI;

namespace IModB.UI
{
    public partial class Room : UserControl
    {
        List<Reader> _readers = new List<Reader>();
        List<Device> _devices = new List<Device>();

        public event ReaderSelected OnReaderSelected;

        public Room()
        {
            InitializeComponent();
            AddReaders();
        }

        public void AddReaders()
        {
            AddReader(ReaderOrientation.HorizontalTop);
            AddReader(ReaderOrientation.HorizontalBottom);
            AddReader(ReaderOrientation.VerticalLeft);
            AddReader(ReaderOrientation.VerticalRight);
        }

        public void AddReader(ReaderOrientation orientation)
        {
            var reader = new Reader();
            reader.Initialize(orientation, this);
            reader.OnReaderSelected += reader_OnReaderSelected;
            _readers.Add(reader);
        }

        public void reader_OnReaderSelected(Reader reader)
        {
            var g = this.CreateGraphics();

            var readerIsInThisRoom = false;
            foreach (var r in _readers)
            {
                if (r.getId() != reader.getId())
                {
                    r.HighLight(g, false);
                }
                else {
                    readerIsInThisRoom = true;
                }
            }

            if (readerIsInThisRoom)
            {
                if (this.OnReaderSelected != null)
                {
                    this.OnReaderSelected(reader);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void Draw(Graphics g)
        {
            g.Clear(Color.AliceBlue);

            foreach (var reader in _readers)
            {
                reader.Draw(g);
            }

            foreach (var device in _devices)
            {
                device.Draw(g);
            }
        }

        private void Room_Load(object sender, EventArgs e)
        {

        }

        private void Room_DoubleClick(object sender, EventArgs e)
        {
            var me = (MouseEventArgs)e;

            var device = new Device();
            device.Top = me.Y;
            device.Left = me.X;
            _devices.Add(device);

            device.OnDeviceSelected += device_OnDeviceSelected;

            Draw(this.CreateGraphics());
        }

        void device_OnDeviceSelected(Device device)
        {
            device.Draw(this.CreateGraphics());

            foreach (var d in _devices)
            {
                d.setSelected(false, this.CreateGraphics());
            }
        }

        private void Room_Click(object sender, EventArgs e)
        {
            var me = (MouseEventArgs)e;

            foreach (var device in _devices)
            {
                device.checkClicked(me.Location);
            }
        }

        internal List<Reader> getAllReaders()
        {
            return this._readers;
        }

        internal List<Device> getAllDevices()
        {
            return this._devices;
        }

        internal void HighLight(Guid readerId, Guid deviceId)
        {
            var g = this.CreateGraphics();

            Draw(g);

            Reader selectedReader = null;
            Device selectedDevice = null;

            foreach (var reader in _readers)
            {
                if (reader.getId() == readerId)
                {
                    reader.HighLight(g, true);
                    selectedReader = reader;
                }
                else
                {
                    reader.HighLight(g, false);
                }
            }

            foreach (var device in _devices)
            {
                if (device.getMac() == deviceId )
                {
                    device.HighLight(g, true);
                    selectedDevice = device;
                }
                else
                {
                    device.HighLight(g, false);
                }
            }

            if (selectedDevice != null && selectedReader != null)
            {
                g.DrawLine(Pens.Blue, selectedReader.GetCoordinates(), selectedDevice.GetCoordinates());
            }
        }
    }
}
