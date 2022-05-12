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

namespace UB482
{
    public partial class Form1 : Form
    {
        //object defining
        SerialPortManager serialPortManager;
        Data data;
        public TextBox[] textBoxes;

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            //object instantiating
            serialPortManager = new SerialPortManager(serialPort1);
            data = new Data();

            textBoxes = new TextBox[]
            {
                //no header first byte
                gnssTextBox, msgLenTextBox, yearTextBox, monthTextBox,
                dayTextBox, minTextBox, secTextBox, rtkStatTextBox,
                headingStatTextBox, gpsStatTextBox, gloStatTextBox,
                bdsStatTextBox, baselineNTextBox, baselineETextBox,
                baselineUTextBox, baselineNStdTextBox, baselineEStdTextBox,
                baselineUStdTextBox, headingTextBox, gpsPitchTextBox, gpsRollTextBox,
                gpsSpeedTextBox, velNTextBox, velETextBox, velUpTextBox, 
                xigVxTextBox, xigVyTextBox, xigVzTextBox, latTextBox, lonTextBox,
                roverHeiTextBox, ecefXTextBox, ecefYTextBox, ecefZTextBox, xigLatTextBox,
                xigLonTextBox, xigAltTextBox, xigEcefXTextBox, xigEcefYTextBox,
                xigEcefZTextBox, /*baseline konumu yok*/secLatTextBox, secLonTextBox,
                secAltTextBox, gpsWeekSecTextBox, diffageTextBox, speedHeadingTextBox, 
                undulationTextBox, /*remain float yok*/galStatTextBox
            };

            serialPortManager.textBoxes = textBoxes;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(serialPortManager.CheckSerialPort());
            comboBox1.SelectedIndex = 0;
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPortManager.readBuffer = serialPort1.ReadLine();
                rawByteMonitor.Text += serialPortManager.readBuffer + "\n";
                serialPortManager.SplitBuffer(data);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!serialPortManager.isEnabled)
            {
                serialPortManager.comboBox = comboBox1;
                serialPortManager.OpenConnection();
            }
            else
            {
                serialPortManager.CloseConnection();
                comboBox1.Items.AddRange(serialPortManager.CheckSerialPort());
            }

        }
    }
}
