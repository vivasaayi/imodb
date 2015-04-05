using Dashboard.DomainModels;
using IModBLocationInfoCollector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        AllSensorsHelper _allSensorsHelper = new AllSensorsHelper();
        AllDevicesHelper _allDevicesHelper = new AllDevicesHelper();

        public Form1()
        {
            InitializeComponent();

            textBox1.Text = IMoDBSettings.URL;
            textBox2.Text = IMoDBSettings.Port.ToString();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshSensorsTabPage();
            RefreshDevicesTabPage();
        }

        private void RefreshDevicesTabPage()
        {
            RefreshAllSensors();
        }

        private void RefreshAllSensors()
        {
            var allSensors = _allSensorsHelper.GetAllSensors();
            allSensorsListBox.DataSource = allSensors;
            allSensorsListBox.DisplayMember = "SensorId";
        }

        private void RefreshSensorsTabPage()
        {
            var allDevices = _allDevicesHelper.GetAllDevices();
            allDevicesListBox.DataSource = allDevices;
            allDevicesListBox.DisplayMember = "DeviceName";
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
