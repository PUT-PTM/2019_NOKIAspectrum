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
        /*
        ~0-120
        >40     <- send 8
        35-39   <- send 7
        30-34   <- send 6
        25-29   <- send 5
        20-24   <- send 4
        15-19   <- send 3
        10-14   <- send 2 
        1-9     <- send 1
        0       <- send 0
        */
        public void WriteData(int[] fftData)
        {
            int[] band = ConsolideBands(fftData);
            for (int i = 0; i < fftData.Length; i++)
            {
               
               comPort.Write(SetBand(band[i]).ToString());
            }
        }
        private int SetBand(int value)
        {
            int tmp = 0;
            if (value > 0 && value < 10) tmp = 1;
            else if (value > 9 && value < 15) tmp = 2;
            else if (value > 14 && value < 20) tmp = 3;
            else if (value > 19 && value < 25) tmp = 4;
            else if (value > 24 && value < 30) tmp = 5;
            else if (value > 29 && value < 35) tmp = 6;
            else if (value > 34 && value < 40) tmp = 7;
            else if (value > 39) tmp = 8;
            return tmp;
        }
        private int[] ConsolideBands(int[] fftData)
        {
            int[] band = new int[16];
            band[0] = fftData[0];
            band[1] = fftData[1];
            band[2] = fftData[2];
            band[3] = fftData[3];
            for (int i = 4; i < 32; i += 2)
            {
                band[i] = (fftData[i] + fftData[i + 1]) / 2;
            }
            return band;
        }
        ~USB()
        {
            comPort.Close();
        }
    }
}
