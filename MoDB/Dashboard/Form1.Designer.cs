namespace Dashboard
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.sensorsTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.allSensorsListBox = new System.Windows.Forms.ListBox();
            this.devicesTabPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.allDevicesListBox = new System.Windows.Forms.ListBox();
            this.settingsTabPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.locationUpdatesBySensorsGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.sensorStartDate = new System.Windows.Forms.DateTimePicker();
            this.sensorEndDate = new System.Windows.Forms.DateTimePicker();
            this.filterSensorsButton = new System.Windows.Forms.Button();
            this.filterDevicesButton = new System.Windows.Forms.Button();
            this.deviceEndDate = new System.Windows.Forms.DateTimePicker();
            this.deviceStartDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.deviceTagDataGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.sensorsTabPage.SuspendLayout();
            this.devicesTabPage.SuspendLayout();
            this.settingsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locationUpdatesBySensorsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceTagDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.sensorsTabPage);
            this.tabControl1.Controls.Add(this.devicesTabPage);
            this.tabControl1.Controls.Add(this.settingsTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(879, 396);
            this.tabControl1.TabIndex = 0;
            // 
            // sensorsTabPage
            // 
            this.sensorsTabPage.Controls.Add(this.filterSensorsButton);
            this.sensorsTabPage.Controls.Add(this.sensorEndDate);
            this.sensorsTabPage.Controls.Add(this.sensorStartDate);
            this.sensorsTabPage.Controls.Add(this.label5);
            this.sensorsTabPage.Controls.Add(this.locationUpdatesBySensorsGridView);
            this.sensorsTabPage.Controls.Add(this.label1);
            this.sensorsTabPage.Controls.Add(this.allSensorsListBox);
            this.sensorsTabPage.Location = new System.Drawing.Point(4, 22);
            this.sensorsTabPage.Name = "sensorsTabPage";
            this.sensorsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.sensorsTabPage.Size = new System.Drawing.Size(871, 370);
            this.sensorsTabPage.TabIndex = 0;
            this.sensorsTabPage.Text = "Sensors";
            this.sensorsTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "All Sensors";
            // 
            // allSensorsListBox
            // 
            this.allSensorsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.allSensorsListBox.FormattingEnabled = true;
            this.allSensorsListBox.Location = new System.Drawing.Point(17, 34);
            this.allSensorsListBox.Name = "allSensorsListBox";
            this.allSensorsListBox.Size = new System.Drawing.Size(296, 316);
            this.allSensorsListBox.TabIndex = 0;
            this.allSensorsListBox.SelectedIndexChanged += new System.EventHandler(this.allSensorsListBox_SelectedIndexChanged);
            // 
            // devicesTabPage
            // 
            this.devicesTabPage.Controls.Add(this.filterDevicesButton);
            this.devicesTabPage.Controls.Add(this.deviceEndDate);
            this.devicesTabPage.Controls.Add(this.deviceStartDate);
            this.devicesTabPage.Controls.Add(this.label6);
            this.devicesTabPage.Controls.Add(this.deviceTagDataGridView);
            this.devicesTabPage.Controls.Add(this.label2);
            this.devicesTabPage.Controls.Add(this.allDevicesListBox);
            this.devicesTabPage.Location = new System.Drawing.Point(4, 22);
            this.devicesTabPage.Name = "devicesTabPage";
            this.devicesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.devicesTabPage.Size = new System.Drawing.Size(871, 370);
            this.devicesTabPage.TabIndex = 1;
            this.devicesTabPage.Text = "Devices";
            this.devicesTabPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "All Devices";
            // 
            // allDevicesListBox
            // 
            this.allDevicesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.allDevicesListBox.FormattingEnabled = true;
            this.allDevicesListBox.Location = new System.Drawing.Point(9, 21);
            this.allDevicesListBox.Name = "allDevicesListBox";
            this.allDevicesListBox.Size = new System.Drawing.Size(293, 316);
            this.allDevicesListBox.TabIndex = 2;
            this.allDevicesListBox.SelectedIndexChanged += new System.EventHandler(this.allDevicesListBox_SelectedIndexChanged);
            // 
            // settingsTabPage
            // 
            this.settingsTabPage.Controls.Add(this.label3);
            this.settingsTabPage.Controls.Add(this.textBox2);
            this.settingsTabPage.Controls.Add(this.textBox1);
            this.settingsTabPage.Controls.Add(this.label4);
            this.settingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.settingsTabPage.Name = "settingsTabPage";
            this.settingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTabPage.Size = new System.Drawing.Size(1046, 370);
            this.settingsTabPage.TabIndex = 2;
            this.settingsTabPage.Text = "Settings";
            this.settingsTabPage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "URL";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(422, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(84, 20);
            this.textBox2.TabIndex = 14;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(337, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Port";
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(812, 415);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // locationUpdatesBySensorsGridView
            // 
            this.locationUpdatesBySensorsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locationUpdatesBySensorsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.locationUpdatesBySensorsGridView.Location = new System.Drawing.Point(319, 50);
            this.locationUpdatesBySensorsGridView.Name = "locationUpdatesBySensorsGridView";
            this.locationUpdatesBySensorsGridView.Size = new System.Drawing.Size(546, 300);
            this.locationUpdatesBySensorsGridView.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(319, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "All Updates by this sensor";
            // 
            // sensorStartDate
            // 
            this.sensorStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorStartDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.sensorStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.sensorStartDate.Location = new System.Drawing.Point(469, 28);
            this.sensorStartDate.Name = "sensorStartDate";
            this.sensorStartDate.Size = new System.Drawing.Size(128, 20);
            this.sensorStartDate.TabIndex = 4;
            this.sensorStartDate.ValueChanged += new System.EventHandler(this.sensorStartDate_ValueChanged);
            // 
            // sensorEndDate
            // 
            this.sensorEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorEndDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.sensorEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.sensorEndDate.Location = new System.Drawing.Point(603, 27);
            this.sensorEndDate.Name = "sensorEndDate";
            this.sensorEndDate.Size = new System.Drawing.Size(119, 20);
            this.sensorEndDate.TabIndex = 5;
            this.sensorEndDate.ValueChanged += new System.EventHandler(this.sensorEndDate_ValueChanged);
            // 
            // filterSensorsButton
            // 
            this.filterSensorsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterSensorsButton.Location = new System.Drawing.Point(728, 25);
            this.filterSensorsButton.Name = "filterSensorsButton";
            this.filterSensorsButton.Size = new System.Drawing.Size(75, 23);
            this.filterSensorsButton.TabIndex = 6;
            this.filterSensorsButton.Text = "Filter";
            this.filterSensorsButton.UseVisualStyleBackColor = true;
            this.filterSensorsButton.Click += new System.EventHandler(this.filterSensorsButton_Click);
            // 
            // filterDevicesButton
            // 
            this.filterDevicesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterDevicesButton.Location = new System.Drawing.Point(717, 12);
            this.filterDevicesButton.Name = "filterDevicesButton";
            this.filterDevicesButton.Size = new System.Drawing.Size(75, 23);
            this.filterDevicesButton.TabIndex = 11;
            this.filterDevicesButton.Text = "Filter";
            this.filterDevicesButton.UseVisualStyleBackColor = true;
            this.filterDevicesButton.Click += new System.EventHandler(this.filterDevicesButton_Click);
            // 
            // deviceEndDate
            // 
            this.deviceEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceEndDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.deviceEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.deviceEndDate.Location = new System.Drawing.Point(592, 14);
            this.deviceEndDate.Name = "deviceEndDate";
            this.deviceEndDate.Size = new System.Drawing.Size(119, 20);
            this.deviceEndDate.TabIndex = 10;
            // 
            // deviceStartDate
            // 
            this.deviceStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceStartDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.deviceStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.deviceStartDate.Location = new System.Drawing.Point(458, 15);
            this.deviceStartDate.Name = "deviceStartDate";
            this.deviceStartDate.Size = new System.Drawing.Size(128, 20);
            this.deviceStartDate.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Where this device is Tagged?";
            // 
            // deviceTagDataGridView
            // 
            this.deviceTagDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceTagDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deviceTagDataGridView.Location = new System.Drawing.Point(308, 37);
            this.deviceTagDataGridView.Name = "deviceTagDataGridView";
            this.deviceTagDataGridView.Size = new System.Drawing.Size(546, 300);
            this.deviceTagDataGridView.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 450);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MoDB - Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.sensorsTabPage.ResumeLayout(false);
            this.sensorsTabPage.PerformLayout();
            this.devicesTabPage.ResumeLayout(false);
            this.devicesTabPage.PerformLayout();
            this.settingsTabPage.ResumeLayout(false);
            this.settingsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locationUpdatesBySensorsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceTagDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage sensorsTabPage;
        private System.Windows.Forms.TabPage devicesTabPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox allSensorsListBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox allDevicesListBox;
        private System.Windows.Forms.TabPage settingsTabPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView locationUpdatesBySensorsGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker sensorEndDate;
        private System.Windows.Forms.DateTimePicker sensorStartDate;
        private System.Windows.Forms.Button filterSensorsButton;
        private System.Windows.Forms.Button filterDevicesButton;
        private System.Windows.Forms.DateTimePicker deviceEndDate;
        private System.Windows.Forms.DateTimePicker deviceStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView deviceTagDataGridView;
    }
}

