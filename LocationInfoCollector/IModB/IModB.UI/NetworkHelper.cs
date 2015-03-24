﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IModB.UI
{
    public class NetworkHelper
    {
        string baseUrl = "http://localhost:1853/";

        public void PostData(string data)
        {
            var url = baseUrl + "location/";

            //url = "http://localhost:1853/home/about";

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

        public void GetRecenteData()
        {
            var url = this.baseUrl + "location/recent";

            //url = "http://localhost:4142/home/about";

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url); ;
            request.Method = "GET";
            
            var response = request.GetResponse();

            List<LocationInfo> locationInfoList = new List<LocationInfo>();
            Dictionary<string, string> docs = new Dictionary<string, string>();

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                var resultdata = sr.ReadToEnd();

                JObject o = JObject.Parse(resultdata);

                for (int i = 0; i < o["result"].Count(); i++)
                {
                    var dataSet = o["result"][i];
                    var data = dataSet["data"];

                    docs.Add(dataSet["_id"].Value<string>(), "");

                    for (int j = 0; j < data.Count(); j++)
                    {
                        var locationInfo = data[j];

                        var deviceId = new Guid(locationInfo["DeviceId"].Value<string>());
                        var readerId = new Guid(locationInfo["ReaderId"].Value<string>());
                        var distance = locationInfo["Distance"].Value<Decimal>();
                        var time = locationInfo["TimeStamp"].Value<DateTime>();

                        var loc = new LocationInfo();

                        loc.DeviceId = deviceId;
                        loc.ReaderId = readerId;
                        loc.Distance = distance;
                        loc.TimeStamp = time;

                        locationInfoList.Add(loc);
                    }
                }

                
            }
            UpdateLocationsInDB(locationInfoList);
        }

        string _connectionString = "Server=localhost;Database=test;Trusted_Connection=True";

        public void UpdateProcessedDocuments(string documentId, string details)
        {
            
        }

        public void UpdateLocationsInDB(List<LocationInfo> locationInfo)
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn("DeviceId", typeof(Guid)));
            table.Columns.Add(new DataColumn("ReaderId", typeof(Guid)));
            table.Columns.Add(new DataColumn("Timestamp", typeof(DateTime)));
            table.Columns.Add(new DataColumn("Distance", typeof(decimal)));

            foreach (var loc in locationInfo)
            {
                var row = table.NewRow();

                row["DeviceId"] = loc.DeviceId;
                row["ReaderId"] = loc.ReaderId;
                row["TimeStamp"] = loc.TimeStamp;
                row["Distance"] = loc.Distance;

                table.Rows.Add(row);
            }

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(_connectionString))
            {
                bulkCopy.DestinationTableName = "LocationInfo";

                bulkCopy.WriteToServer(table);
            }
        }
    }

    public class LocationInfo
    {
        public Guid DeviceId { get; set; }
        public Guid ReaderId { get; set; }
        public decimal Distance { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}