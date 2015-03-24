using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IModB.UI
{
    public class NetworkHelper
    {
        public void PostData(string data)
        {
            var url = "http://localhost:1422/location/";

            //url = "http://localhost:4142/home/about";

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url); ;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            var outputStream = request.GetRequestStream();

            StreamWriter sw = new StreamWriter(outputStream);
            sw.Write(data);
            sw.Close();
            outputStream.Close();

            var response = request.GetResponse();

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                var resultdata = sr.ReadToEnd();
            }
        }
    }
}
