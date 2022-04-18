using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;


namespace Motor_Control_GUI
{
    public partial class MotorControl : Form
    {
        private readonly ILogger<MotorControl> _logger;
        private bool ButtonStatus = false;
        private bool gg = false;
        public MotorControl(ILogger<MotorControl> logger)
        {
            _logger = logger;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ConnectButton.Enabled = false;
            DisconnectButton.Enabled = false;
        }
        private void GetConnection()
        {
            try
            {
               
                SerialCommunicationInfo.PortName = SerialPortList.Text;
                SerialCommunicationInfo.BaudRate = Convert.ToInt32(SerialBaudrateList.Text);
                UpdateReceivedText($"Try To Connecting... ");
                Thread.Sleep(500);
                SerialCommunicationInfo.Open();
                if (SerialCommunicationInfo.IsOpen)
                {
                    UpdateReceivedText($"Connected");
                    StatusText.ForeColor = Color.Green;
                    StatusText.Text = "Connected";
                    ConnectButton.Enabled = false;
                    DisconnectButton.Enabled = true;
                }
            }
            catch
            {
                UpdateReceivedText($"Error can't connect to serial");
                StatusText.ForeColor = Color.Red;
                StatusText.Text = "Unconnected";
            }

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
       
            GetConnection();
        }
        private void UpdateReceivedText(string dData) => this.Invoke((MethodInvoker)delegate
        {
            ReceivedText.AppendText($"{dData}{Environment.NewLine}");
            //_logger.LogDebug($" {dData}");
        });
        private void UpdateSendText(string dData) => this.Invoke((MethodInvoker)delegate
        {
            SendText.AppendText($"{dData}{Environment.NewLine}");
            _logger.LogDebug($"{dData}");
        });

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            UpdateReceivedText($"Try To Disconnecting... ");
            Thread.Sleep(500);
            SerialCommunicationInfo.Close();
            if (!SerialCommunicationInfo.IsOpen)
            {
                UpdateReceivedText($"Disconnected");
                StatusText.ForeColor = Color.Red;
                StatusText.Text = "Disconnected";
                ConnectButton.Enabled = true;
                DisconnectButton.Enabled = false;
            }
        }
        private void SerialPortList_SelectedIndexChanged(object sender, EventArgs e)
        
        =>ButtonStatus= SerialPortList.SelectedItem != null && !string.IsNullOrEmpty(SerialPortList.SelectedItem.ToString());
        //ConnectButton.Enabled

        private void SerialBaudrateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ButtonStatus)
            {
                ConnectButton.Enabled = true;
            }
        }
        //   => gg = SerialBaudrateList.SelectedItem != null && !string.IsNullOrEmpty(SerialBaudrateList.SelectedItem.ToString());



        private void SetRPMValue_Scroll(object sender, EventArgs e)
        {
            for (int i = 0; i <= SetRPMValue.Value; i++)
            {
                SerialCommunicationInfo.Write(Convert.ToChar(i).ToString());
            }
        }

        private void SetKIValue_Scroll(object sender, EventArgs e)
        {
            for (int i = 101; i <= SetKIValue.Value; i++)
            {
                SerialCommunicationInfo.Write(Convert.ToChar(i).ToString());
            }
        }

        private void SetKPValue_Scroll(object sender, EventArgs e)
        {
            for (int i = 112; i <= SetKPValue.Value; i++)
            {
                SerialCommunicationInfo.Write(Convert.ToChar(i).ToString());
            }
        }
    }
}