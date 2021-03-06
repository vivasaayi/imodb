﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IModBLocationInfoCollector
{
    public class NetworkHelper
    {
        private string GetBaseUrl()
        {
            return IMoDBSettings.URL + ":" + IMoDBSettings.Port + "/";
        }

        public void PostData(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return;
            }

            try
            {
                var url = GetBaseUrl() + "location/";

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
                    Console.WriteLine(resultdata);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteData(string ids)
        {
            try
            {
                var url = GetBaseUrl() + "location/" + ids;
                Console.WriteLine("Deleting Data:" + url);

                //url = "http://localhost:1853/home/about";

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url); ;
                request.Method = "DELETE";

                var response = request.GetResponse();

                var resultdata = "";
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    resultdata = sr.ReadToEnd();
                }

                Console.WriteLine("Data deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when deleting data..");
                Console.WriteLine(ex.ToString());
            }
        }

        public void GetRecenteData()
        {
            try
            {
                var url = this.GetBaseUrl() + "location/recent";

                //url = "http://localhost:4142/home/about";
                Console.WriteLine("Fetching from:" + url);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url); ;
                request.Method = "GET";

                var response = request.GetResponse();

                List<LocationInfo> locationInfoList = new List<LocationInfo>();
                Dictionary<string, string> docs = new Dictionary<string, string>();

                Console.WriteLine("Response Received");
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

                            var deviceId = locationInfo["DeviceId"].Value<string>();
                            var deviceName = locationInfo["DeviceName"].Value<string>();
                            var sensorId = locationInfo["SensorId"].Value<string>();
                            var distance = locationInfo["Distance"].Value<Decimal>();
                            var time = locationInfo["TimeStamp"].Value<DateTime>();

                            var loc = new LocationInfo();

                            loc.DeviceId = deviceId;
                            loc.DeviceName = deviceName;
                            loc.SensorId = sensorId;
                            loc.Distance = distance;
                            loc.TimeStamp = time;

                            locationInfoList.Add(loc);
                        }
                    }


                }

                if (locationInfoList.Count > 0)
                {
                    Console.WriteLine("Updating downloaded data to database");
                    UpdateLocationsInDB(locationInfoList);
                    Console.WriteLine("Database updated");

                    var docIdsToDeleteArray = docs.Keys.ToArray();


                    DeleteData(string.Join(",", docIdsToDeleteArray));
                }
                else
                {
                    Console.WriteLine("No data retrived from server");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when getitng recent data..");
                Console.WriteLine(ex.ToString());
            }
        }

        string _connectionString = "Server=localhost;Database=imodb;Trusted_Connection=True";

        public void UpdateProcessedDocuments(string documentId, string details)
        {

        }

        public void UpdateLocationsInDB(List<LocationInfo> locationInfo)
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn("DeviceId", typeof(string)));
            table.Columns.Add(new DataColumn("DeviceName", typeof(string)));
            table.Columns.Add(new DataColumn("SensorId", typeof(string)));
            table.Columns.Add(new DataColumn("Timestamp", typeof(DateTime)));
            table.Columns.Add(new DataColumn("Distance", typeof(decimal)));

            foreach (var loc in locationInfo)
            {
                var row = table.NewRow();

                row["DeviceId"] = loc.DeviceId;
                row["DeviceName"] = loc.DeviceName;
                row["SensorId"] = loc.SensorId;
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

        public JObject GetDataFromRemote(string path)
        {
            JObject returnData = new JObject();
            try
            {
                var url = this.GetBaseUrl() + path;

                //url = "http://localhost:4142/home/about";
                Console.WriteLine("Fetching from:" + url);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url); ;
                request.Method = "GET";

                var response = request.GetResponse();

                List<LocationInfo> locationInfoList = new List<LocationInfo>();
                Dictionary<string, string> docs = new Dictionary<string, string>();

                Console.WriteLine("Response Received");
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    var resultdata = sr.ReadToEnd();

                    returnData = JObject.Parse(resultdata);                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when getitng recent data..");
                Console.WriteLine(ex.ToString());
            }

            return returnData;
        }
    }

    public class LocationInfo
    {
        public string DeviceId { get; set; }
        public string SensorId { get; set; }
        public decimal Distance { get; set; }
        public DateTime TimeStamp { get; set; }

        public string DeviceName { get; set; }
    }
}
