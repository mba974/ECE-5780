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
        private bool SetRPMDone = false;
        private bool SetKIDone = false;
        private bool SetKPDone = false;
        private int i;
        private int j;
        private int k;
        private string ReadSerialData;
        private DateTime _lastReceive;
        private const int freqCriticalLimit = 20;
        private string ReadSpeed;
        private string ReadError;
        private UInt32 NewSpeedValue;
        private UInt32 NewErrorValue;
        public MotorControl(ILogger<MotorControl> logger)
        {
            _logger = logger;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ConnectButton.Enabled = false;
            DisconnectButton.Enabled = false;
            SetRPMValue.Enabled = false;
            SetKIValue.Enabled = false;
            SetKPValue.Enabled = false;
            SendText.Enabled = false;
            ReceivedText.Enabled = false;
            StatusText.ForeColor = Color.Red;
            StatusText.Text = "Unconnect";
            Thread.Sleep(200);
        }
        private void GetConnection()
        {
            try
            {
                SerialCommunicationInfo.PortName = SerialPortList.Text;
                SerialCommunicationInfo.BaudRate = Convert.ToInt32(SerialBaudrateList.Text);
                UpdateReceivedText($"Try To Connecting...");
                Thread.Sleep(500);
                SerialCommunicationInfo.Open();
                if (SerialCommunicationInfo.IsOpen)
                {
                    UpdateReceivedText($"Connected");
                    StatusText.ForeColor = Color.Green;
                    StatusText.Text = "Connected";
                    ConnectButton.Enabled = false;
                    DisconnectButton.Enabled = true;
                    SetRPMValue.Enabled = true;
                    SetKIValue.Enabled = true;
                    SetKPValue.Enabled = true;
                    SendText.Enabled = true;
                    ReceivedText.Enabled = true;
                }
            }
            catch
            {
                UpdateReceivedText($"Error can't connect to serial");
                StatusText.ForeColor = Color.Red;
                StatusText.Text = "Unconnected";
            }
        }
        private void SerialCommunicationInfo_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReadSerialData = SerialCommunicationInfo.ReadLine();
            this.BeginInvoke(new EventHandler(ReadReceivedData));
        }
        private void ReadReceivedData(object sender, EventArgs e)
        {
            try
            {
                if (ReadSerialData.Any())
                {
                    TimeSpan tmpInterval = (DateTime.Now - _lastReceive);
                    _lastReceive = DateTime.Now;
                    sbyte DeleteSpeed = (sbyte)ReadSerialData.IndexOf("speed:");
                    sbyte DeleteError = (sbyte)ReadSerialData.IndexOf("error:");
                    sbyte c = (sbyte)ReadSerialData.IndexOf("setRPM:");
                    ReadSpeed = (DeleteSpeed >= 0) ? ReadSerialData.Substring(0, DeleteSpeed) : ReadSerialData;
                    ReadError = (DeleteError >= 0) ? ReadSerialData.Substring(DeleteSpeed + 6, (DeleteError - DeleteSpeed) - 6) : ReadSerialData;
                    _ = UInt32.TryParse(ReadSpeed, out NewSpeedValue);
                    _ = UInt32.TryParse(ReadError, out NewErrorValue);
                    if (tmpInterval.Milliseconds > 0)
                        Thread.Sleep(tmpInterval.Milliseconds > freqCriticalLimit ? freqCriticalLimit : tmpInterval.Milliseconds);

                    SpeedBar.Value = (int)NewSpeedValue;
                    ErrorBar.Value = (int)NewErrorValue;
                    SpeedText.Text = NewSpeedValue.ToString();
                    ErrorText.Text = NewErrorValue.ToString();
                    SpeedBar.ForeColor = NewSpeedValue > 50 ? Color.DarkGreen : Color.Green;
                    ErrorBar.ForeColor = NewErrorValue > 5 ? Color.Red : Color.Green;
                }
            }
            catch (Exception ex)
            {
                UpdateReceivedText(ex.ToString());
            }
        }
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            GetConnection();
        }
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            UpdateReceivedText($"Try To Disconnecting...");
            Thread.Sleep(500);
            SerialCommunicationInfo.Close();
            if (!SerialCommunicationInfo.IsOpen)
            {
                UpdateReceivedText($"Disconnected");
                StatusText.ForeColor = Color.Red;
                StatusText.Text = "Unconnect";
                ConnectButton.Enabled = true;
                DisconnectButton.Enabled = false;
                SetRPMValue.Enabled = false;
                SetKIValue.Enabled = false;
                SetKPValue.Enabled = false;
                SetRPMValue.Value = 0;
                SetKIValue.Value = 101;
                SetKPValue.Value = 112;
                SpeedBar.Value = 0;
                ErrorBar.Value = 0;
                RPMBar.Value = 0;
                KIBar.Value = 0;
                KPBar.Value = 0;
            }
        }
        private void UpdateReceivedText(string IncomeData) => this.Invoke((MethodInvoker)delegate
        {
            ReceivedText.AppendText($"{IncomeData}{Environment.NewLine}");
        });
        private void UpdateSendText(string IncomeData) => this.Invoke((MethodInvoker)delegate
        {
            SendText.AppendText($"{IncomeData}{Environment.NewLine}");
        });
        private void UpdateFileText(string IncomeData) => this.Invoke((MethodInvoker)delegate
        {
            _logger.LogDebug($" {IncomeData}");
        });
        private void SendToStm32(string IncomeData) => this.Invoke((MethodInvoker)delegate
        {
            SerialCommunicationInfo.Write(IncomeData);
        });
        private void SerialPortList_SelectedIndexChanged(object sender, EventArgs e)
        => ButtonStatus = SerialPortList.SelectedItem != null && !string.IsNullOrEmpty(SerialPortList.SelectedItem.ToString());
        private void SerialBaudrateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ButtonStatus)
            {
                ConnectButton.Enabled = true;
            }
        }
        private void SetRPMValue_Scroll(object sender, EventArgs e)
        {
            RPMText.Text = SetRPMValue.Value.ToString();
        }
        private void SetRPMValue_ValueChanged(object sender, EventArgs e)
        {
            SetRPMDone = true;
        }
        private void SetRPMValue_MouseUp(object sender, MouseEventArgs e)
        {
            if (SetRPMDone)
            {
                SetRPMDone = false;
                for (i = 0; i <= SetRPMValue.Value; i++)
                {
                    SendToStm32(Convert.ToChar(i).ToString());
                }
                UpdateSendText("Set RPM to: " + (i - 1).ToString());
            }
        }
        private void SetKIValue_Scroll(object sender, EventArgs e)
        {
            KIText.Text = (SetKIValue.Value - 0x65).ToString();
        }
        private void SetKIValue_ValueChanged(object sender, EventArgs e)
        {
            SetKIDone = true;
        }
        private void SetKIValue_MouseUp(object sender, MouseEventArgs e)
        {
            if (SetKIDone)
            {
                for (j = 101; j <= SetKIValue.Value; j++)
                {
                    SendToStm32(Convert.ToChar(j).ToString());
                }
                UpdateSendText("Set KI to: " + (j - 0x66).ToString());
            }
        }
        private void SetKPValue_Scroll(object sender, EventArgs e)
        {
            KPText.Text = (SetKPValue.Value - 0x70).ToString();
        }
        private void SetKPValue_ValueChanged(object sender, EventArgs e)
        {
            SetKPDone = true;
        }
        private void SetKPValue_MouseUp(object sender, MouseEventArgs e)
        {
            if (SetKPDone)
            {
                for (k = 112; k <= SetKPValue.Value; k++)
                {
                    SendToStm32(Convert.ToChar(k).ToString());
                }
                UpdateSendText("Set KP to: " + (k - 0x71).ToString());
            }
        }
        private void RightDir_Click(object sender, EventArgs e)
        {
            SendToStm32(Convert.ToChar(0x7B).ToString());
            UpdateSendText("Set direction to right");
        }
        private void LeftDir_Click(object sender, EventArgs e)
        {
            SendToStm32(Convert.ToChar(0x7C).ToString());
            UpdateSendText("Set direction to left");
        }
    }
}