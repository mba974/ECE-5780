namespace Motor_Control_GUI
{
    partial class MotorControl
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
            this.components = new System.ComponentModel.Container();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.SerialPortLabel = new System.Windows.Forms.Label();
            this.SerialBaudrateLabel = new System.Windows.Forms.Label();
            this.SerialPortList = new System.Windows.Forms.ComboBox();
            this.SerialBaudrateList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LoadConnection = new System.Windows.Forms.ProgressBar();
            this.StatusText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.KPText = new System.Windows.Forms.Label();
            this.KIText = new System.Windows.Forms.Label();
            this.RPMText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SetKIValue = new System.Windows.Forms.TrackBar();
            this.SetKPValue = new System.Windows.Forms.TrackBar();
            this.SetRPMValue = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ReceivedText = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.SendText = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ErrorText = new System.Windows.Forms.Label();
            this.SpeedText = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ErrorBar = new System.Windows.Forms.ProgressBar();
            this.SpeedBar = new System.Windows.Forms.ProgressBar();
            this.SerialCommunicationInfo = new System.IO.Ports.SerialPort(this.components);
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightDir = new System.Windows.Forms.Button();
            this.LeftDir = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.NoDir = new System.Windows.Forms.Button();
            this.LoadData = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.DeviceIDText = new System.Windows.Forms.Label();
            this.DEVICEID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.ResetSystem = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetKIValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetKPValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetRPMValue)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(12, 263);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(370, 44);
            this.ConnectButton.TabIndex = 2;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(12, 319);
            this.DisconnectButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(370, 44);
            this.DisconnectButton.TabIndex = 3;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // SerialPortLabel
            // 
            this.SerialPortLabel.AutoSize = true;
            this.SerialPortLabel.Location = new System.Drawing.Point(6, 60);
            this.SerialPortLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SerialPortLabel.Name = "SerialPortLabel";
            this.SerialPortLabel.Size = new System.Drawing.Size(144, 30);
            this.SerialPortLabel.TabIndex = 4;
            this.SerialPortLabel.Text = "Serial Port";
            // 
            // SerialBaudrateLabel
            // 
            this.SerialBaudrateLabel.AutoSize = true;
            this.SerialBaudrateLabel.Location = new System.Drawing.Point(6, 148);
            this.SerialBaudrateLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SerialBaudrateLabel.Name = "SerialBaudrateLabel";
            this.SerialBaudrateLabel.Size = new System.Drawing.Size(125, 30);
            this.SerialBaudrateLabel.TabIndex = 5;
            this.SerialBaudrateLabel.Text = "Baudrate";
            // 
            // SerialPortList
            // 
            this.SerialPortList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerialPortList.FormattingEnabled = true;
            this.SerialPortList.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.SerialPortList.Location = new System.Drawing.Point(12, 96);
            this.SerialPortList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SerialPortList.Name = "SerialPortList";
            this.SerialPortList.Size = new System.Drawing.Size(366, 38);
            this.SerialPortList.TabIndex = 6;
            this.SerialPortList.SelectedIndexChanged += new System.EventHandler(this.SerialPortList_SelectedIndexChanged);
            // 
            // SerialBaudrateList
            // 
            this.SerialBaudrateList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerialBaudrateList.FormattingEnabled = true;
            this.SerialBaudrateList.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.SerialBaudrateList.Location = new System.Drawing.Point(12, 185);
            this.SerialBaudrateList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SerialBaudrateList.Name = "SerialBaudrateList";
            this.SerialBaudrateList.Size = new System.Drawing.Size(366, 38);
            this.SerialBaudrateList.TabIndex = 7;
            this.SerialBaudrateList.SelectedIndexChanged += new System.EventHandler(this.SerialBaudrateList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LoadConnection);
            this.groupBox1.Controls.Add(this.StatusText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SerialPortList);
            this.groupBox1.Controls.Add(this.SerialBaudrateList);
            this.groupBox1.Controls.Add(this.ConnectButton);
            this.groupBox1.Controls.Add(this.DisconnectButton);
            this.groupBox1.Controls.Add(this.SerialBaudrateLabel);
            this.groupBox1.Controls.Add(this.SerialPortLabel);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 85);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(400, 483);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Information";
            // 
            // LoadConnection
            // 
            this.LoadConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadConnection.Location = new System.Drawing.Point(12, 427);
            this.LoadConnection.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.LoadConnection.Name = "LoadConnection";
            this.LoadConnection.Size = new System.Drawing.Size(376, 44);
            this.LoadConnection.Step = 1;
            this.LoadConnection.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.LoadConnection.TabIndex = 1;
            // 
            // StatusText
            // 
            this.StatusText.AutoSize = true;
            this.StatusText.Location = new System.Drawing.Point(144, 369);
            this.StatusText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(0, 30);
            this.StatusText.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 369);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 30);
            this.label1.TabIndex = 9;
            this.label1.Text = "Status:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.KPText);
            this.groupBox2.Controls.Add(this.KIText);
            this.groupBox2.Controls.Add(this.RPMText);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.SetKIValue);
            this.groupBox2.Controls.Add(this.SetKPValue);
            this.groupBox2.Controls.Add(this.SetRPMValue);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(2016, 1146);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(894, 467);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Speed Control";
            // 
            // KPText
            // 
            this.KPText.AutoSize = true;
            this.KPText.Location = new System.Drawing.Point(808, 67);
            this.KPText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.KPText.Name = "KPText";
            this.KPText.Size = new System.Drawing.Size(0, 30);
            this.KPText.TabIndex = 18;
            // 
            // KIText
            // 
            this.KIText.AutoSize = true;
            this.KIText.Location = new System.Drawing.Point(452, 67);
            this.KIText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.KIText.Name = "KIText";
            this.KIText.Size = new System.Drawing.Size(0, 30);
            this.KIText.TabIndex = 17;
            // 
            // RPMText
            // 
            this.RPMText.AutoSize = true;
            this.RPMText.Location = new System.Drawing.Point(28, 67);
            this.RPMText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.RPMText.Name = "RPMText";
            this.RPMText.Size = new System.Drawing.Size(0, 30);
            this.RPMText.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(808, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 30);
            this.label4.TabIndex = 15;
            this.label4.Text = "KI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 30);
            this.label3.TabIndex = 14;
            this.label3.Text = "KI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 30);
            this.label2.TabIndex = 13;
            this.label2.Text = "RPM";
            // 
            // SetKIValue
            // 
            this.SetKIValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SetKIValue.LargeChange = 1;
            this.SetKIValue.Location = new System.Drawing.Point(420, 106);
            this.SetKIValue.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SetKIValue.Maximum = 111;
            this.SetKIValue.Minimum = 101;
            this.SetKIValue.Name = "SetKIValue";
            this.SetKIValue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SetKIValue.Size = new System.Drawing.Size(90, 352);
            this.SetKIValue.TabIndex = 0;
            this.SetKIValue.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.SetKIValue.Value = 101;
            this.SetKIValue.Scroll += new System.EventHandler(this.SetKIValue_Scroll);
            this.SetKIValue.ValueChanged += new System.EventHandler(this.SetKIValue_ValueChanged);
            this.SetKIValue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SetKIValue_MouseUp);
            // 
            // SetKPValue
            // 
            this.SetKPValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SetKPValue.LargeChange = 1;
            this.SetKPValue.Location = new System.Drawing.Point(784, 106);
            this.SetKPValue.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SetKPValue.Maximum = 122;
            this.SetKPValue.Minimum = 112;
            this.SetKPValue.Name = "SetKPValue";
            this.SetKPValue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SetKPValue.Size = new System.Drawing.Size(90, 352);
            this.SetKPValue.TabIndex = 0;
            this.SetKPValue.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.SetKPValue.Value = 112;
            this.SetKPValue.Scroll += new System.EventHandler(this.SetKPValue_Scroll);
            this.SetKPValue.ValueChanged += new System.EventHandler(this.SetKPValue_ValueChanged);
            this.SetKPValue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SetKPValue_MouseUp);
            // 
            // SetRPMValue
            // 
            this.SetRPMValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SetRPMValue.LargeChange = 1;
            this.SetRPMValue.Location = new System.Drawing.Point(12, 104);
            this.SetRPMValue.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SetRPMValue.Maximum = 100;
            this.SetRPMValue.Name = "SetRPMValue";
            this.SetRPMValue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SetRPMValue.Size = new System.Drawing.Size(90, 352);
            this.SetRPMValue.TabIndex = 0;
            this.SetRPMValue.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.SetRPMValue.Scroll += new System.EventHandler(this.SetRPMValue_Scroll);
            this.SetRPMValue.ValueChanged += new System.EventHandler(this.SetRPMValue_ValueChanged);
            this.SetRPMValue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SetRPMValue_MouseUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.ReceivedText);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(486, 85);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox3.Size = new System.Drawing.Size(738, 1471);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Received Data";
            // 
            // ReceivedText
            // 
            this.ReceivedText.BackColor = System.Drawing.SystemColors.Window;
            this.ReceivedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReceivedText.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ReceivedText.Location = new System.Drawing.Point(6, 36);
            this.ReceivedText.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ReceivedText.Multiline = true;
            this.ReceivedText.Name = "ReceivedText";
            this.ReceivedText.ReadOnly = true;
            this.ReceivedText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ReceivedText.Size = new System.Drawing.Size(726, 1429);
            this.ReceivedText.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.SendText);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(1236, 85);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox4.Size = new System.Drawing.Size(738, 1471);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Send Data";
            // 
            // SendText
            // 
            this.SendText.BackColor = System.Drawing.SystemColors.Window;
            this.SendText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SendText.ForeColor = System.Drawing.SystemColors.InfoText;
            this.SendText.Location = new System.Drawing.Point(6, 36);
            this.SendText.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SendText.Multiline = true;
            this.SendText.Name = "SendText";
            this.SendText.ReadOnly = true;
            this.SendText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SendText.Size = new System.Drawing.Size(726, 1429);
            this.SendText.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.ErrorText);
            this.groupBox5.Controls.Add(this.SpeedText);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.ErrorBar);
            this.groupBox5.Controls.Add(this.SpeedBar);
            this.groupBox5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(2016, 85);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox5.Size = new System.Drawing.Size(894, 729);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Live Data";
            // 
            // ErrorText
            // 
            this.ErrorText.AutoSize = true;
            this.ErrorText.Location = new System.Drawing.Point(408, 447);
            this.ErrorText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(27, 30);
            this.ErrorText.TabIndex = 13;
            this.ErrorText.Text = "0";
            // 
            // SpeedText
            // 
            this.SpeedText.AutoSize = true;
            this.SpeedText.Location = new System.Drawing.Point(408, 96);
            this.SpeedText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SpeedText.Name = "SpeedText";
            this.SpeedText.Size = new System.Drawing.Size(27, 30);
            this.SpeedText.TabIndex = 12;
            this.SpeedText.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 447);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 30);
            this.label6.TabIndex = 11;
            this.label6.Text = "Error";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 30);
            this.label5.TabIndex = 10;
            this.label5.Text = "RPM";
            // 
            // ErrorBar
            // 
            this.ErrorBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorBar.Location = new System.Drawing.Point(12, 486);
            this.ErrorBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ErrorBar.Name = "ErrorBar";
            this.ErrorBar.Size = new System.Drawing.Size(870, 44);
            this.ErrorBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ErrorBar.TabIndex = 1;
            // 
            // SpeedBar
            // 
            this.SpeedBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpeedBar.Location = new System.Drawing.Point(12, 135);
            this.SpeedBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SpeedBar.Name = "SpeedBar";
            this.SpeedBar.Size = new System.Drawing.Size(870, 44);
            this.SpeedBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.SpeedBar.TabIndex = 0;
            // 
            // SerialCommunicationInfo
            // 
            this.SerialCommunicationInfo.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialCommunicationInfo_DataReceived);
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.OldLace;
            this.MenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileItem,
            this.HelpItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(2934, 44);
            this.MenuStrip.TabIndex = 13;
            this.MenuStrip.Text = "MenuItem";
            // 
            // FileItem
            // 
            this.FileItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewItem,
            this.SaveItem,
            this.SaveToItem,
            this.ExitItem});
            this.FileItem.Name = "FileItem";
            this.FileItem.Size = new System.Drawing.Size(71, 36);
            this.FileItem.Text = "File";
            // 
            // NewItem
            // 
            this.NewItem.Name = "NewItem";
            this.NewItem.Size = new System.Drawing.Size(226, 44);
            this.NewItem.Text = "New";
            this.NewItem.Click += new System.EventHandler(this.NewItem_Click);
            // 
            // SaveItem
            // 
            this.SaveItem.Name = "SaveItem";
            this.SaveItem.Size = new System.Drawing.Size(226, 44);
            this.SaveItem.Text = "Save";
            this.SaveItem.Click += new System.EventHandler(this.SaveItem_Click);
            // 
            // SaveToItem
            // 
            this.SaveToItem.Name = "SaveToItem";
            this.SaveToItem.Size = new System.Drawing.Size(226, 44);
            this.SaveToItem.Text = "Save to";
            this.SaveToItem.Click += new System.EventHandler(this.SaveToItem_Click);
            // 
            // ExitItem
            // 
            this.ExitItem.Name = "ExitItem";
            this.ExitItem.Size = new System.Drawing.Size(226, 44);
            this.ExitItem.Text = "Exit";
            this.ExitItem.Click += new System.EventHandler(this.ExitItem_Click);
            // 
            // HelpItem
            // 
            this.HelpItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutItem});
            this.HelpItem.Name = "HelpItem";
            this.HelpItem.Size = new System.Drawing.Size(84, 36);
            this.HelpItem.Text = "Help";
            // 
            // AboutItem
            // 
            this.AboutItem.Name = "AboutItem";
            this.AboutItem.Size = new System.Drawing.Size(212, 44);
            this.AboutItem.Text = "About";
            this.AboutItem.Click += new System.EventHandler(this.AboutItem_Click);
            // 
            // RightDir
            // 
            this.RightDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RightDir.BackColor = System.Drawing.SystemColors.Control;
            this.RightDir.Location = new System.Drawing.Point(18, 58);
            this.RightDir.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.RightDir.Name = "RightDir";
            this.RightDir.Size = new System.Drawing.Size(864, 65);
            this.RightDir.TabIndex = 0;
            this.RightDir.Text = "Turn Right";
            this.RightDir.UseVisualStyleBackColor = false;
            this.RightDir.Click += new System.EventHandler(this.RightDir_Click);
            // 
            // LeftDir
            // 
            this.LeftDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LeftDir.BackColor = System.Drawing.SystemColors.Control;
            this.LeftDir.Location = new System.Drawing.Point(18, 135);
            this.LeftDir.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.LeftDir.Name = "LeftDir";
            this.LeftDir.Size = new System.Drawing.Size(864, 65);
            this.LeftDir.TabIndex = 1;
            this.LeftDir.Text = "Turn Left";
            this.LeftDir.UseVisualStyleBackColor = false;
            this.LeftDir.Click += new System.EventHandler(this.LeftDir_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.NoDir);
            this.groupBox6.Controls.Add(this.LeftDir);
            this.groupBox6.Controls.Add(this.RightDir);
            this.groupBox6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(2016, 825);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox6.Size = new System.Drawing.Size(894, 310);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Directions Control";
            // 
            // NoDir
            // 
            this.NoDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoDir.BackColor = System.Drawing.SystemColors.Control;
            this.NoDir.Location = new System.Drawing.Point(18, 212);
            this.NoDir.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.NoDir.Name = "NoDir";
            this.NoDir.Size = new System.Drawing.Size(864, 65);
            this.NoDir.TabIndex = 2;
            this.NoDir.Text = "Stop";
            this.NoDir.UseVisualStyleBackColor = false;
            this.NoDir.Click += new System.EventHandler(this.NoDir_Click);
            // 
            // LoadData
            // 
            this.LoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadData.Location = new System.Drawing.Point(1242, 1567);
            this.LoadData.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.LoadData.Name = "LoadData";
            this.LoadData.Size = new System.Drawing.Size(726, 46);
            this.LoadData.Step = 1;
            this.LoadData.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.LoadData.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(314, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 30);
            this.label7.TabIndex = 1;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.DeviceIDText);
            this.groupBox7.Controls.Add(this.DEVICEID);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(24, 594);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox7.Size = new System.Drawing.Size(400, 192);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Data";
            // 
            // DeviceIDText
            // 
            this.DeviceIDText.AutoSize = true;
            this.DeviceIDText.Location = new System.Drawing.Point(166, 87);
            this.DeviceIDText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.DeviceIDText.Name = "DeviceIDText";
            this.DeviceIDText.Size = new System.Drawing.Size(0, 30);
            this.DeviceIDText.TabIndex = 4;
            // 
            // DEVICEID
            // 
            this.DEVICEID.AutoSize = true;
            this.DEVICEID.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DEVICEID.Location = new System.Drawing.Point(12, 87);
            this.DEVICEID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.DEVICEID.Name = "DEVICEID";
            this.DEVICEID.Size = new System.Drawing.Size(141, 30);
            this.DEVICEID.TabIndex = 3;
            this.DEVICEID.Text = "Device ID:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 31);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(290, 30);
            this.label10.TabIndex = 2;
            this.label10.Text = "Motor Rotation Angle:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.ResetSystem);
            this.groupBox8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(24, 798);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox8.Size = new System.Drawing.Size(400, 192);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "System";
            // 
            // ResetSystem
            // 
            this.ResetSystem.Location = new System.Drawing.Point(12, 67);
            this.ResetSystem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ResetSystem.Name = "ResetSystem";
            this.ResetSystem.Size = new System.Drawing.Size(376, 44);
            this.ResetSystem.TabIndex = 1;
            this.ResetSystem.Text = "Reset System";
            this.ResetSystem.UseVisualStyleBackColor = true;
            this.ResetSystem.Click += new System.EventHandler(this.ResetSystem_Click);
            // 
            // MotorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(2934, 1637);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.LoadData);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MinimumSize = new System.Drawing.Size(2940, 71);
            this.Name = "MotorControl";
            this.Text = "Motor Control";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetKIValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetKPValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetRPMValue)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Label SerialPortLabel;
        private System.Windows.Forms.Label SerialBaudrateLabel;
        private System.Windows.Forms.ComboBox SerialPortList;
        private System.Windows.Forms.ComboBox SerialBaudrateList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox ReceivedText;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox SendText;
        private System.Windows.Forms.TrackBar SetKIValue;
        private System.Windows.Forms.TrackBar SetKPValue;
        private System.Windows.Forms.TrackBar SetRPMValue;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label KPText;
        private System.Windows.Forms.Label KIText;
        private System.Windows.Forms.Label RPMText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar ErrorBar;
        private System.Windows.Forms.ProgressBar SpeedBar;
        private System.Windows.Forms.Label ErrorText;
        private System.Windows.Forms.Label SpeedText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.IO.Ports.SerialPort SerialCommunicationInfo;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileItem;
        private System.Windows.Forms.ToolStripMenuItem SaveItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToItem;
        private System.Windows.Forms.ToolStripMenuItem ExitItem;
        private System.Windows.Forms.ToolStripMenuItem HelpItem;
        private System.Windows.Forms.ToolStripMenuItem AboutItem;
        private System.Windows.Forms.ToolStripMenuItem NewItem;
        private System.Windows.Forms.Button RightDir;
        private System.Windows.Forms.Button LeftDir;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button NoDir;
        private System.Windows.Forms.ProgressBar LoadConnection;
        private System.Windows.Forms.ProgressBar LoadData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button ResetSystem;
        private System.Windows.Forms.Label DeviceIDText;
        private System.Windows.Forms.Label DEVICEID;
    }
}

