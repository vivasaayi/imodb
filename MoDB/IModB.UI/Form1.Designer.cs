namespace IModB.UI
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
            this.scanDevicesButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.sensorViewTabPage = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.deviceViewTabPage = new System.Windows.Forms.TabPage();
            this.devicesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.loadRoomsButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trackMeButton = new System.Windows.Forms.Button();
            this.buildingUserControl = new IModB.UI.BuildingUserControl();
            this.tabControl1.SuspendLayout();
            this.sensorViewTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.deviceViewTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scanDevicesButton
            // 
            this.scanDevicesButton.Location = new System.Drawing.Point(88, 38);
            this.scanDevicesButton.Name = "scanDevicesButton";
            this.scanDevicesButton.Size = new System.Drawing.Size(112, 23);
            this.scanDevicesButton.TabIndex = 1;
            this.scanDevicesButton.Text = "Scan Devices";
            this.scanDevicesButton.UseVisualStyleBackColor = true;
            this.scanDevicesButton.Click += new System.EventHandler(this.scanDevicesButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(537, 314);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.sensorViewTabPage);
            this.tabControl1.Controls.Add(this.deviceViewTabPage);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(551, 346);
            this.tabControl1.TabIndex = 5;
            // 
            // sensorViewTabPage
            // 
            this.sensorViewTabPage.Controls.Add(this.dataGridView1);
            this.sensorViewTabPage.Location = new System.Drawing.Point(4, 22);
            this.sensorViewTabPage.Name = "sensorViewTabPage";
            this.sensorViewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.sensorViewTabPage.Size = new System.Drawing.Size(543, 320);
            this.sensorViewTabPage.TabIndex = 0;
            this.sensorViewTabPage.Text = "Sensor\'s View";
            this.sensorViewTabPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(537, 314);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(543, 320);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data Transferred";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(543, 320);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "JSON Data";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(3, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(537, 314);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // deviceViewTabPage
            // 
            this.deviceViewTabPage.Controls.Add(this.devicesListBox);
            this.deviceViewTabPage.Location = new System.Drawing.Point(4, 22);
            this.deviceViewTabPage.Name = "deviceViewTabPage";
            this.deviceViewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.deviceViewTabPage.Size = new System.Drawing.Size(543, 320);
            this.deviceViewTabPage.TabIndex = 3;
            this.deviceViewTabPage.Text = "Device\'s View";
            this.deviceViewTabPage.UseVisualStyleBackColor = true;
            // 
            // devicesListBox
            // 
            this.devicesListBox.FormattingEnabled = true;
            this.devicesListBox.Location = new System.Drawing.Point(6, 6);
            this.devicesListBox.Name = "devicesListBox";
            this.devicesListBox.Size = new System.Drawing.Size(248, 303);
            this.devicesListBox.TabIndex = 0;
            this.devicesListBox.SelectedIndexChanged += new System.EventHandler(this.devicesListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Port";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(337, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(418, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(84, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // loadRoomsButton
            // 
            this.loadRoomsButton.Location = new System.Drawing.Point(7, 38);
            this.loadRoomsButton.Name = "loadRoomsButton";
            this.loadRoomsButton.Size = new System.Drawing.Size(75, 23);
            this.loadRoomsButton.TabIndex = 11;
            this.loadRoomsButton.Text = "Load Rooms";
            this.loadRoomsButton.UseVisualStyleBackColor = true;
            this.loadRoomsButton.Click += new System.EventHandler(this.loadRoomsButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buildingUserControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.trackMeButton);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.loadRoomsButton);
            this.splitContainer1.Panel2.Controls.Add(this.scanDevicesButton);
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(1191, 428);
            this.splitContainer1.SplitterDistance = 621;
            this.splitContainer1.TabIndex = 12;
            // 
            // trackMeButton
            // 
            this.trackMeButton.Location = new System.Drawing.Point(206, 38);
            this.trackMeButton.Name = "trackMeButton";
            this.trackMeButton.Size = new System.Drawing.Size(75, 23);
            this.trackMeButton.TabIndex = 12;
            this.trackMeButton.Text = "Track Device";
            this.trackMeButton.UseVisualStyleBackColor = true;
            this.trackMeButton.Click += new System.EventHandler(this.trackMeButton_Click);
            // 
            // buildingUserControl
            // 
            this.buildingUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buildingUserControl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buildingUserControl.Location = new System.Drawing.Point(0, 0);
            this.buildingUserControl.Name = "buildingUserControl";
            this.buildingUserControl.Size = new System.Drawing.Size(622, 425);
            this.buildingUserControl.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 428);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.sensorViewTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.deviceViewTabPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button scanDevicesButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private BuildingUserControl buildingUserControl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage sensorViewTabPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button loadRoomsButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button trackMeButton;
        private System.Windows.Forms.TabPage deviceViewTabPage;
        private System.Windows.Forms.ListBox devicesListBox;
    }
}

