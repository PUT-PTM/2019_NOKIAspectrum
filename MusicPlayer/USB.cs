using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class USB
    {
        SerialPort comPort = new SerialPort();
        public USB()
        {
            comPort.PortName = "COM8"; // to check
            comPort.BaudRate = 9600;
            comPort.DataBits = 8;
            comPort.WriteTimeout = 100;
            comPort.Open();
        }
        public void WriteData(int[] fftData)
        {
            for (int i = 0; i < fftData.Length; i++)
            {
               comPort.Write(fftData[i].ToString());
            }
        }
        ~USB()
        {
            comPort.Close();
        }
    }
}
