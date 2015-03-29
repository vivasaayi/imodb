using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IModBLocationInfoCollector
{
    public class Utils
    {
        public static double CalculateDistance(int X1, int Y1, int X2, int Y2)
        {
            return Math.Sqrt(Math.Pow((X2 - X1), 2) + Math.Pow((Y2 - Y1), 2));
        }
    }
}
