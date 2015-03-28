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
        List<Room> _rooms = new List<Room>();

        public Form1()
        {
            InitializeComponent();
            _rooms.Add(room1);
            _rooms.Add(room2);

            room1.OnReaderSelected += room1_OnReaderSelected;
            room2.OnReaderSelected += room2_OnReaderSelected;

            textBox1.Text = IMoDBSettings.URL;
            textBox2.Text = IMoDBSettings.Port.ToString();
        }

        void room2_OnReaderSelected(Reader reader)
        {
            room1.reader_OnReaderSelected(reader);
        }

        void room1_OnReaderSelected(Reader reader)
        {
            room2.reader_OnReaderSelected(reader);
        }

        private void room1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void room1_Load(object sender, EventArgs e)
        {

        }

        private void scanDevicesButton_Click(object sender, EventArgs e)
        {
            var allReaders = new List<Reader>();

            foreach (var room in _rooms)
            {
                allReaders.AddRange(room.getAllReaders());
            }

            List<ScanResult> scanResults = new List<ScanResult>();
            foreach (var reader in allReaders)
            {
                var results = reader.ScanDevices();
                scanResults.AddRange(results);
                
            }
            

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<ScanResult>));
            MemoryStream ms = new MemoryStream();
            jsonSerializer.WriteObject(ms, scanResults);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            var jsonToBePosted = sr.ReadToEnd();

            StringBuilder sb = new StringBuilder();
            foreach (var result in scanResults)
            {
                sb.Append("\"ReaderId\":\"").Append(result.ReaderId.ToString()).Append("\",")
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
            var readerId = (Guid)row.Cells[0].Value;
            var deviceId = (Guid)row.Cells[1].Value;

            foreach (var room in _rooms)
            {
                room.HighLight(readerId, deviceId);
            }
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
    }
}
