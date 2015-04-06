using IModBLocationInfoCollector;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.DomainModels
{
    public class BaseHelper
    {
        NetworkHelper _networkHelper = new NetworkHelper();

        public JObject GetDataFromRemote(string url)
        {
            return _networkHelper.GetDataFromRemote(url);
        }

        public static List<LocationUpdate> ConvertToLocationUpdates(List<LocationUpdate> lus, Newtonsoft.Json.Linq.JObject data)
        {
            var senlocationUpdatesRows = data["result"];

            if (senlocationUpdatesRows != null)
            {
                foreach (var locationUpdate in senlocationUpdatesRows)
                {
                    var lu = new LocationUpdate();
                    lu.Initialize(locationUpdate);
                    lus.Add(lu);
                }
            }


            return lus;
        }
    }
}
