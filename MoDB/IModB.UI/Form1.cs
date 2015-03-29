using IModB.UI.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IModB.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.Text = IMoDBSettings.URL;
            textBox2.Text = IMoDBSettings.Port.ToString();
        }

        private void scanDevicesButton_Click(object sender, EventArgs e)
        {
            List<ScanResult> scanResults = buildingUserControl.getScanResult();

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<ScanResult>));
            MemoryStream ms = new MemoryStream();
            jsonSerializer.WriteObject(ms, scanResults);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            var jsonToBePosted = sr.ReadToEnd();

            StringBuilder sb = new StringBuilder();
            foreach (var result in scanResults)
            {
                sb.Append("\"ReaderId\":\"").Append(result.SensorId.ToString()).Append("\",")
                    .Append("\"DeviceId\":\"").Append(result.DeviceId.ToString()).Append("\",")
                    .Append("\"TimeStamp\":\"").Append(result.TimeStamp).Append("\",")
                    .Append("\"Distance\":\"").Append(result.Distance).Append("\",");
                sb.AppendLine();
            }

            dataGridView1.DataSource = scanResults;
            richTextBox1.Text = sb.ToString();
            richTextBox2.Text = jsonToBePosted;

            new NetworkHelper().PostData(jsonToBePosted);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            var readerId = row.Cells[0].Value.ToString();
            var deviceId = row.Cells[1].Value.ToString();


            buildingUserControl.HighLight(readerId, deviceId);

        }

        private void fetchDataButton_Click(object sender, EventArgs e)
        {
            new NetworkHelper().GetRecenteData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            IMoDBSettings.URL = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int port;

            if (int.TryParse(textBox2.Text, out port))
            {
                IMoDBSettings.Port = port;
            }
        }

        private void loadRoomsButton_Click(object sender, EventArgs e)
        {
            InitializeBuildingStructure();
        }

        private void InitializeBuildingStructure()
        {
            var building = new Building();
            building.Initialize();
            buildingUserControl.LoadData(building);
        }

        private void trackMeButton_Click(object sender, EventArgs e)
        {
            buildingUserControl.TrackAllDevices();
        }
    }
}
