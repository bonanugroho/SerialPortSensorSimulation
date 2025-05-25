using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortSensorSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBoxSensors.Enabled = false;
            btnClose.Enabled = false;
            btnOpen.Enabled = true;
            checkBoxSimultaneousData.Enabled = false;
            btnSendAllData.Enabled = false;

            string[] ports = SerialPort.GetPortNames();
            cbComPort.Items.Clear();
            cbComPort.Items.AddRange(ports);

            cbBaud.Text = "9600";

        }


        private void btnSendAllData_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cbComPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(cbBaud.Text);
                serialPort1.Open();

                groupBoxSensors.Enabled = true;
                btnClose.Enabled = true;
                btnOpen.Enabled = false;
                checkBoxSimultaneousData.Enabled = true;
                btnSendAllData.Enabled = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    groupBoxSensors.Enabled = false;
                    btnClose.Enabled = false;
                    btnOpen.Enabled = true;
                    checkBoxSimultaneousData.Enabled = false;
                    btnSendAllData.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
    }
}