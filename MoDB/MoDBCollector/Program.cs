using IModBLocationInfoCollector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoDBCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            var networkHelper = new NetworkHelper();
            while (true)
            {
                networkHelper.GetRecenteData();
                Thread.Sleep(2000);
            }
            Console.WriteLine("Press any key to quit..");
            Console.ReadLine();
        }
    }
}
