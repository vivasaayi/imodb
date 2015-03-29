using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IModBLocationInfoCollector
{
    public class Triangulator
    {
        public List<Point> GetAllIntersectingPoints(List<ApCircle> _circles)
        {
            List<Point> _allIntersectingPoints = new List<Point>();

            for (int i = 0; i < _circles.Count; i++)
            {
                for (int j = i + 1; j < _circles.Count; j++)
                {
                    var points = GetIntersectionPoints(_circles[i], _circles[j]);
                    var pointFound = false;

                    foreach (var circle in _circles)
                    {
                        if (circle != _circles[i] && circle != _circles[j] && !pointFound)
                        {
                            var point1Distance = Utils.CalculateDistance(points[0].X, points[0].Y, circle.X, circle.Y);
                            var point2Distance = Utils.CalculateDistance(points[1].X, points[1].Y, circle.X, circle.Y);

                            if (point1Distance < point2Distance)
                            {
                                _allIntersectingPoints.Add(points[0]);
                            }
                            else
                            {
                                _allIntersectingPoints.Add(points[1]);
                            }
                        }
                    }
                }
            }

            return _allIntersectingPoints;
        }

        private List<Point> GetIntersectionPoints(ApCircle c1, ApCircle c2)
        {
            var d = Utils.CalculateDistance(c1.X, c1.Y, c2.X, c2.Y);
            var a = (Math.Pow(c1.Radius, 2) - Math.Pow(c2.Radius, 2) + Math.Pow(d, 2)) / (2 * d);
            var h = Math.Sqrt(Math.Pow(c1.Radius, 2) - Math.Pow(a, 2));

            if (a > c1.Radius)
            {
                h = Math.Sqrt(Math.Pow(a, 2) - Math.Pow(c1.Radius, 2));
            }

            var scale = a / d;
            var newPoint = new Point((int)((c2.X - c1.X) * scale), (int)((c2.Y - c1.Y) * scale));

            var x3 = (int)(newPoint.X + h * (c2.Y - c1.Y) / d) + c1.X;
            var y3 = (int)(newPoint.Y - h * (c2.X - c1.X) / d) + c1.Y;
            var x4 = (int)(newPoint.X - h * (c2.Y - c1.Y) / d) + c1.X;
            var y4 = (int)(newPoint.Y + h * (c2.X - c1.X) / d) + c1.Y;

            List<Point> points = new List<Point>();
            points.Add(new Point(x3, y3));
            points.Add(new Point(x4, y4));

            return points;
        }
    }
}
