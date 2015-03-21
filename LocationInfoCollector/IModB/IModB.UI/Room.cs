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
    public partial class Room : UserControl
    {
        List<Reader> _readers = new List<Reader>();

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
            _readers.Add(reader);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void Draw(Graphics g)
        {
            foreach (var reader in _readers)
            {
                reader.Draw(g);
            }
        }

        private void Room_Load(object sender, EventArgs e)
        {

        }

        private void Room_Click(object sender, EventArgs e)
        {
            var g = this.CreateGraphics();
            g.Clear(Color.AliceBlue);
            Draw(g);

            var mes = e as MouseEventArgs;            
            g.DrawRectangle(Pens.Goldenrod, mes.X, mes.Y, 10, 10);
        }
    }
}
