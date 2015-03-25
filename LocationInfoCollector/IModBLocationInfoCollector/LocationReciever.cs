using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IModBLocationInfoCollector
{
    public class LocationReciever
    {
        bool _stopped = false;

        public void Start()
        {
            _stopped = false;
            Thread downloadThread = new Thread(new ThreadStart(Download));
            downloadThread.Start();
        }

        public void Stop()
        {
            _stopped = true;
        }

        private void Download()
        {
            while (!_stopped)
            {
                try
                {

                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
