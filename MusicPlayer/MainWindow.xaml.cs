using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicPlayer
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            PrzyciskStop.Background = Brushes.Orange;
            PrzyciskPlay.Background = Brushes.Orange;
            PrzyciskPause.Background = Brushes.Orange;
            PrzyciskNext.Background = Brushes.Orange;
            PrzyciskPrevious.Background = Brushes.Orange;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            PrzyciskStop.Background = Brushes.White;
            PrzyciskPlay.Background = Brushes.White;
            PrzyciskPause.Background = Brushes.White;
            PrzyciskNext.Background = Brushes.White;
            PrzyciskPrevious.Background = Brushes.White;
        }
    }
}
