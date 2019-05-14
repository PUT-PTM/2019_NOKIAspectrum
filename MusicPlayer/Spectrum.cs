using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MusicPlayer
{
    public class Spectrum
    {
       public static void Start(ProgressBar[] bars, float[] spectrumData) //dodać tablice
        {
                //bars[i].Value = spectrumData[i];
                bars[0].Dispatcher.BeginInvoke(new Action(() => { for (int i = 0; i <= 31; i++) bars[i].Value = spectrumData[i]; }));
        }
    }
}
