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
        ReaderOrientation _orientation;
        Room _container;
        Rectangle _coordinates = new Rectangle();

        public Reader()
        {
            InitializeComponent();
        }


        internal void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Black, _coordinates);
        }

        internal void Initialize(ReaderOrientation orientation, Room room)
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
    }

    public enum ReaderOrientation
    {
        VerticalRight,
        VerticalLeft,
        HorizontalTop,
        HorizontalBottom
    }
}
