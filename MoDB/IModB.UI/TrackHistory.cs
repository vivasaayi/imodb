﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IModB.UI.DomainModel;
using IModBLocationInfoCollector;

namespace IModB.UI
{
    public partial class TrackHistory : UserControl
    {
        //int c1Radius = 120;
        //Point c1Center = new Point(200, 200);

        //int c2Radius = 110;
        //Point c2Center = new Point(350, 350);

        List<ApCircle> _circles = new List<ApCircle>();

        public TrackHistory()
        {
            InitializeComponent();

            _circles.Add(new ApCircle
            {
                X = 295,
                Y = 390,
                Radius = 100
            });

            _circles.Add(new ApCircle
            {
                X = 295,
                Y = 200,
                Radius = 98
            });

            _circles.Add(new ApCircle
            {
                X = 200,
                Y = 295,
                Radius = 65
            });

        }

        private void TrackHistory_Paint(object sender, PaintEventArgs e)
        {
            foreach (var circle in _circles)
            {
                e.Graphics.DrawEllipse(Pens.Black, circle.X - circle.Radius, circle.Y - circle.Radius, 2 * circle.Radius, 2 * circle.Radius);
            }

            var triangulator = new Triangulator();
            var _allIntersectingPoints = triangulator.GetAllIntersectingPoints(_circles);
            var location = triangulator.GetCentroidForPoints(_allIntersectingPoints);

            foreach (var point in _allIntersectingPoints)
            {
                e.Graphics.DrawEllipse(Pens.Blue, point.X - 10, point.Y - 10, 20, 20);
            }

            e.Graphics.FillEllipse(Brushes.Violet, location.X - 10, location.Y - 10, 20, 20);
        }

        

        //private void TrackHistory_Paint1(object sender, PaintEventArgs e)
        //{
        //    e.Graphics.DrawEllipse(Pens.Black, c1Center.X - c1Radius, c1Center.Y - c1Radius, 2 * c1Radius, 2 * c1Radius);
        //    e.Graphics.DrawEllipse(Pens.Red, c2Center.X - c2Radius, c2Center.Y - c2Radius, 2 * c2Radius, 2 * c2Radius);

        //    var d = Utils.CalculateDistance(c1Center.X, c1Center.Y, c2Center.X, c2Center.Y);

        //    var a = (Math.Pow(d, 2) - Math.Pow(c2Radius, 2) + Math.Pow(c1Radius, 2)) / (2 * d);
        //    var h = Math.Sqrt(Math.Pow(c1Radius, 2) - Math.Pow(a, 2));
        //    //e.Graphics.DrawLine(Pens.Green, (int)x + c1Center.X, 0, (int)x + c1Center.X, Height);

        //    //var x1 = (int)(d - x);

        //    //e.Graphics.DrawEllipse(Pens.Yellow, c1Center.X - (int)x, c1Center.Y - (int)x, 2 * (int)x, 2 * (int)x);
        //    // e.Graphics.DrawEllipse(Pens.Yellow, c2Center.X - x1, c2Center.Y - x1, 2 * x1, 2 * x1);

        //    //var a = Math.Sqrt((-d + c2Radius - c1Radius) * (-d - c2Radius + c1Radius) * (-d + c2Radius + c1Radius) * (d + c2Radius + c1Radius)) / d;

        //    // var y = a / 2;

        //    //e.Graphics.DrawLine(Pens.Magenta, c1Center, c2Center);
        //    var scale = a / d;
        //    var newPoint = new Point((int)((c2Center.X - c1Center.X) * scale), (int)((c2Center.Y - c1Center.Y) * scale));
        //    e.Graphics.DrawEllipse(Pens.Goldenrod, c1Center.X + newPoint.X - 10, c1Center.Y + newPoint.Y - 10, 20, 20);

        //    var x3 = (int)(newPoint.X + h * (c2Center.Y - c1Center.Y) / d);
        //    var y3 = (int)(newPoint.Y - h * (c2Center.X - c1Center.X) / d);
        //    var x4 = (int)(newPoint.X - h * (c2Center.Y - c1Center.Y) / d);
        //    var y4 = (int)(newPoint.Y + h * (c2Center.X - c1Center.X) / d);

        //    e.Graphics.DrawEllipse(Pens.Goldenrod, c1Center.X + x3 - 10, c1Center.X + y3 - 10, 20, 20);
        //    e.Graphics.DrawEllipse(Pens.Goldenrod, c1Center.X + x4 - 10, c1Center.X + y4 - 10, 20, 20);
        //}
    }

    
}
