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
using System.IO;
using System.Diagnostics;
namespace Motor_Control_GUI
{
    public partial class MotorControl : Form
    {
        private readonly ILogger<MotorControl> _logger;
        private bool ButtonStatus = false;
        private bool SetRPMDone = false;
        private bool SetKIDone = false;
        private bool SetKPDone = false;
        private bool StartSerial = false;
        private int i;
        private int j;
        private int k;
        private string ReadSerialData;
        private string ReadSpeed;
        private string ReadError;
        private string ReadRo;

        private DateTime LastReceive;
        private const int FreqLimit = 20;
        private UInt32 NewSpeedValue;
        private UInt32 NewErrorValue;
        public  MotorControl(ILogger<MotorControl> logger)
        {
            _logger = logger;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ConnectButton.Enabled = false;
            DisconnectButton.Enabled = false;
            ResetSystem.Enabled = false;
            SetRPMValue.Enabled = false;
            SetKIValue.Enabled = false;
            SetKPValue.Enabled = false;
            SendText.Enabled = false;
            ReceivedText.Enabled = false;
            LeftDir.Enabled = false;
            RightDir.Enabled = false;
            NoDir.Enabled = false;
            StatusText.ForeColor = Color.Red;
            StatusText.Text = "Unconnect";
            LoadConnection.ForeColor = Color.Green;
            LoadData.ForeColor = Color.Red;
        }
        
            private  void GetConnectionInfo()
        {
                SerialCommunicationInfo.PortName = SerialPortList.Text;
                SerialCommunicationInfo.BaudRate = Convert.ToInt32(SerialBaudrateList.Text);
                SerialCommunicationInfo.Open();
        }
        private void SerialCommunicationInfo_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                ReadSerialData = SerialCommunicationInfo.ReadLine();
                this.BeginInvoke(new EventHandler(ReadReceivedData));

            }
            catch
            {
 

            }
        }
        private void ReadReceivedData(object sender, EventArgs e)
        {
            try
            {
             
                if (StartSerial) {
                    if (ReadSerialData.Any())
                    {
                        TimeSpan Interval = (DateTime.Now - LastReceive);
                        LastReceive = DateTime.Now;
                        sbyte DeleteSpeed = (sbyte)ReadSerialData.IndexOf("speed:");
                        sbyte DeleteError = (sbyte)ReadSerialData.IndexOf("error:");
                        sbyte Deletero = (sbyte)ReadSerialData.IndexOf("ro:");


                        ReadSpeed = (DeleteSpeed >= 0) ? ReadSerialData.Substring(0, DeleteSpeed) : ReadSerialData;
                        ReadError = (DeleteError >= 0) ? ReadSerialData.Substring(DeleteSpeed + 6, (DeleteError - DeleteSpeed) - 6) : ReadSerialData;
                        ReadRo = (Deletero >= 0) ? ReadSerialData.Substring(DeleteError + 6, (Deletero - DeleteError) - 6) : ReadSerialData;

                        _ = UInt32.TryParse(ReadSpeed, out NewSpeedValue);
                        _ = UInt32.TryParse(ReadError, out NewErrorValue);
                        if (Interval.Milliseconds > 50)
                        {
                            Thread.Sleep(Interval.Milliseconds > FreqLimit ? FreqLimit : Interval.Milliseconds);
                        }
                        UpdateReceivedText($"Speed: {ReadSpeed}");
                        UpdateReceivedText($"Error: {ReadError}");
                        SpeedBar.Value = (int)NewSpeedValue;
                        ErrorBar.Value = (int)NewErrorValue;
                        SpeedText.Text = NewSpeedValue.ToString();
                        ErrorText.Text = NewErrorValue.ToString();
                        label7.Text = ReadRo+"°";
                        SpeedBar.ForeColor = NewSpeedValue > 50 ? Color.DarkGreen : Color.Green;
                        ErrorBar.ForeColor = NewErrorValue > 5 ? Color.Red : Color.Green;
                    }
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            catch (Exception ex)
            {
                UpdateReceivedText(ex.ToString());
            }
        }
        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoadConnection.ForeColor = Color.Green;
                UpdateReceivedText($"Try To Connecting...");
                LoadConnection.Value = 100;
                await Task.Delay(500);
                GetConnectionInfo();
                LoadConnection.Value = 0;
                if (SerialCommunicationInfo.IsOpen)
                {
                    UpdateReceivedText($"Connected");
                    UpdateFileText($"Connected");
                    StatusText.ForeColor = Color.Green;
                    StatusText.Text = "Connected";
                    RightDir.BackColor = Color.Red;
                    LeftDir.BackColor = Color.Red;
                    NoDir.BackColor = Color.YellowGreen;
                    StartSerial = true;
                    DisconnectButton.Enabled = true;
                    SetRPMValue.Enabled = true;
                    SetKIValue.Enabled = true;
                    SetKPValue.Enabled = true;
                    SendText.Enabled = true;
                    ReceivedText.Enabled = true;
                    LeftDir.Enabled = true;
                    RightDir.Enabled = true;
                    NoDir.Enabled = true;
                    ResetSystem.Enabled = true;
                    ConnectButton.Enabled = false;
                    SerialPortList.Enabled = false;
                    SerialBaudrateList.Enabled = false;
                }
            }
            catch
            {
                LoadConnection.ForeColor = Color.Red;
                LoadConnection.Value = 100;
                await Task.Delay(200);
                LoadConnection.Value = 0;
                UpdateReceivedText("Error couldn't connect to the serial");
            }
            }
        private async void DisconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoadConnection.ForeColor = Color.Red;
                StartSerial = false;
                UpdateReceivedText($"Try To Disconnecting...");
                SendToStm32(Convert.ToChar(0).ToString());
                LoadConnection.Value = 100;
                await Task.Delay(100);
                SendToStm32(Convert.ToChar(102).ToString());
                await Task.Delay(400);
                LoadConnection.Value = 0;
                SerialCommunicationInfo.Close();
                if (!SerialCommunicationInfo.IsOpen)
                {
                    UpdateReceivedText($"Disconnected");
                    UpdateFileText($"Disconnected");
                    StatusText.ForeColor = Color.Red;
                    StatusText.Text = "Unconnect";
                    RightDir.BackColor = SystemColors.Control;
                    LeftDir.BackColor = SystemColors.Control;
                    NoDir.BackColor = SystemColors.Control;
                    ConnectButton.Enabled = true;
                    SerialPortList.Enabled = true;
                    SerialBaudrateList.Enabled = true;
                    DisconnectButton.Enabled = false;
                    SetRPMValue.Enabled = false;
                    SetKIValue.Enabled = false;
                    SetKPValue.Enabled = false;
                    LeftDir.Enabled = false;
                    RightDir.Enabled = false;
                    NoDir.Enabled = false;
                    ResetSystem.Enabled = false;
                    SetRPMValue.Value = 0;
                    SetKIValue.Value = 101;
                    SetKPValue.Value = 112;
                    SpeedText.Text = "0";
                    ErrorText.Text = "0";
                    SpeedBar.Value = 0;
                    ErrorBar.Value = 0;
                    RPMBar.Value = 0;
                    KIBar.Value = 0;
                    KPBar.Value = 0;
                }
            }
            catch
            {
                UpdateReceivedText("Error check the correct port");
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
        private void SendToStm32(string IncomeData) => this.Invoke((MethodInvoker)async delegate
        {
           
                LoadData.Value = 100;
                SerialCommunicationInfo.Write(IncomeData);
                LoadData.Value = 0;
            
       
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
                UpdateSendText("Set RPM to: " + (i - 0x1).ToString());
                UpdateFileText($"Set RPM to: {i - 0x1}");
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
                UpdateFileText($"Set KI to: {j - 0x66}");
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
                UpdateFileText($"Set KP to: {k - 0x71}");
            }
        }
        private void RightDir_Click(object sender, EventArgs e)
        {
            SendToStm32(Convert.ToChar(0x7B).ToString());
            UpdateSendText("Set direction to right");
            UpdateFileText($"Set direction to right");
            RightDir.BackColor = Color.YellowGreen;
            LeftDir.BackColor  = Color.Red;
            NoDir.BackColor    = Color.Red;
        }
        private void LeftDir_Click(object sender, EventArgs e)
        {
            SendToStm32(Convert.ToChar(0x7C).ToString());
            UpdateSendText("Set direction to left");
            UpdateFileText($"Set direction to left");
            RightDir.BackColor = Color.Red;
            NoDir.BackColor    = Color.Red;
            LeftDir.BackColor = Color.YellowGreen;
        }
        private void NoDir_Click(object sender, EventArgs e)
        {
            SendToStm32(Convert.ToChar(0x7D).ToString());
            UpdateSendText("Set direction to stop");
            UpdateFileText($"Set direction to stop");
            RightDir.BackColor = Color.Red;
            LeftDir.BackColor  = Color.Red;
            NoDir.BackColor    = Color.YellowGreen;
        }
        private void ResetSystem_Click(object sender, EventArgs e)
        {
            ResetSystem.BackColor = Color.Red;
            SendToStm32(Convert.ToChar(0x7E).ToString());
            UpdateSendText("Reset System");
            UpdateFileText($"Reset System");
            ResetSystem.BackColor = SystemColors.Control;
        }
        private async void NewItem_Click(object sender, EventArgs e)
        {
            if (SerialCommunicationInfo.IsOpen)
            {
                StartSerial = false;
                UpdateReceivedText($"Try To Disconnecting...");
                SendToStm32(Convert.ToChar(0).ToString());
                await Task.Delay(100);
                SendToStm32(Convert.ToChar(102).ToString());
                await Task.Delay(100);
                SerialCommunicationInfo.Close();
                Application.Restart();
                Environment.Exit(0);
            }
            else
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }
        private void SaveItem_Click(object sender, EventArgs e)
        {
        }
        private async void ExitItem_Click(object sender, EventArgs e)
        {
            if (SerialCommunicationInfo.IsOpen)
            {
                SendToStm32(Convert.ToChar(0x7D).ToString());
                await Task.Delay(00);
                SerialCommunicationInfo.Close();
                await Task.Delay(100);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
        private void SaveToItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog()
            {
                Filter = "Spreadsheet Files (*.txt)|*.txt|All Files (*.*)|*.*"
                ,
                FileName = "SaveIncomeData"
            };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter SaveTo = new StreamWriter(saveFile.FileName))
                {
                    SaveTo.Write($"{DateTime.Now}: {ReceivedText.Text}");
                }
            }
        }
        private void AboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This GUI program allows a user to enter a motor values, target-speed," +
                " or direction of motor spain and PI control," +
              "\rusaer will be able to read live data coming from the hardware through a serial port." +
              "\r\rMotor Control GUI " +
              "\rVersion 1.0\rMohammed Al-heidous\rU1188594\r2022");
        }

    }
}