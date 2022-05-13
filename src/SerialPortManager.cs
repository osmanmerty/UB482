using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UB482
{
    class SerialPortManager
    {
        public ComboBox comboBox { get; set; }
        public TextBox[] textBoxes { get; set; }
        private SerialPort _serialPort;
        
        public bool isEnabled = false;
        public string readBuffer;
        public SerialPortManager(SerialPort serialPort)
        {
            _serialPort = serialPort;
        }
    
        public string[] CheckSerialPort()
        {
            return SerialPort.GetPortNames();
        }

        public void OpenConnection()
        {
            isEnabled = true;
            _serialPort.BaudRate = 230400;
            _serialPort.PortName = comboBox.Text;
            _serialPort.Open();
        }

        public void CloseConnection()
        {
            isEnabled = false;
            _serialPort.Close();
        }
        
        public void SplitBuffer(Data data)
        {
            string[] dataWithHeader = readBuffer.Split(';');
            Data.header = dataWithHeader[0];

            string[] splittedData = dataWithHeader[1].Split(',');

            int i = 0;
            
            foreach (var rawData in splittedData)
            {
                data.datas[i] = splittedData[i];

                i++;
            }
        }

        public async void ViewData(Data data)
        {
            await Task.Run(() =>
            {
                int i;
                for (i = 0; i < 49; i++)
                {
                    if (i < 41)
                    {
                        textBoxes[i].Text = Convert.ToString(i);
                    }
                    else if (i < 48) //7 tane gidicez
                    {

                        textBoxes[i].Text = data.datas[i + 2];
                    }
                    else // 2 tane atladik 1 tane aldik
                    {
                        textBoxes[i].Text = data.datas[i + 4];
                    }
                }
            });
            
        }
    }   
}
