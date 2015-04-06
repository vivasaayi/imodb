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

        Sensor selectedSensor;
        private void allSensorsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allSensorsListBox.SelectedItems.Count > 0 && allSensorsListBox.SelectedIndex >= 0)
            {
                selectedSensor = (Sensor)allSensorsListBox.SelectedItems[0];
                var sensorId = selectedSensor.SensorId;
                locationUpdatesBySensorsGridView.DataSource = _allSensorsHelper.LocationUpdatesBySensor(sensorId);
            }
        }

        private void sensorStartDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void FilterSensorsBasedOnDate()
        {
            var fromDate = sensorStartDate.Value;
            var endDate = sensorEndDate.Value;
            locationUpdatesBySensorsGridView.DataSource = _allSensorsHelper.LocationUpdatesBySensor(selectedSensor.SensorId, fromDate, endDate);
        }

        private void FilterDevicesBasedOnDate()
        {
            var fromDate = deviceStartDate.Value;
            var endDate = deviceEndDate.Value;
            deviceTagDataGridView.DataSource = _allDevicesHelper.LocationUpdatesBySensor(selectedDevice.DeviceId, fromDate, endDate);
        }

        private void sensorEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void filterSensorsButton_Click(object sender, EventArgs e)
        {
            FilterSensorsBasedOnDate();
        }

        Device selectedDevice;
        private void allDevicesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allDevicesListBox.SelectedItems.Count > 0 && allDevicesListBox.SelectedIndex >= 0)
            {
                selectedDevice = (Device)allDevicesListBox.SelectedItems[0];
                var deviceId = selectedDevice.DeviceId;
                deviceTagDataGridView.DataSource = _allDevicesHelper.LocationUpdatesByDevice(deviceId);
            }
        }

        private void filterDevicesButton_Click(object sender, EventArgs e)
        {
            FilterDevicesBasedOnDate();
        }
    }
}
