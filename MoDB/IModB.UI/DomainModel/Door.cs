using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IModB.UI.DomainModel
{
    public class Door
    {
        public string RoomId { get; set; }
        public string Id { get; set; }
        public string Orientation { get; set; }
        public string Alignment { get; set; }
        public Rectangle Coordinates { get; set; }

        internal void Draw(System.Drawing.Graphics g)
        {
            g.FillRectangle(Brushes.Violet, Coordinates);
        }
    }
}
