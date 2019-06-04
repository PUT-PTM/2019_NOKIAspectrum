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
            comPort.Open();
            int[] band = ConsolideBands(fftData);
            for (int i = 0; i < band.Length; i++)
            {
               
               comPort.Write(SetBand(band[i]).ToString());
            }
            comPort.Close();
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
            band[4] = (fftData[4] + fftData[5]) / 2;
            band[5] = (fftData[6] + fftData[7]) / 2;
            band[6] = (fftData[8] + fftData[9]) / 2;
            band[7] = (fftData[10] + fftData[11]) / 2;
            band[8] = (fftData[12] + fftData[13]) / 2;
            band[9] = (fftData[14] + fftData[15]) / 2;
            band[10] = (fftData[16] + fftData[17]) / 2;
            band[11] = (fftData[18] + fftData[19]) / 2;
            band[12] = (fftData[20] + fftData[21]) / 2;
            band[13] = (fftData[22] + fftData[23]) / 2;
            band[14] = (fftData[24] + fftData[25]) / 2;
            band[15] = (fftData[26] + fftData[27]) / 2;
            return band;
        }
    }
}
