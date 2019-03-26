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
        bool isMusicPlay = false;
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush tempImg = new ImageBrush();
            if (!isMusicPlay)
            {
                tempImg.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Assets/pauseButton.png"));
                playButton.Name = "pauseButton";
                isMusicPlay = true;
            }
            else
            {
                tempImg.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Assets/playButton.png"));
                playButton.Name = "playButton";
                isMusicPlay = false;
            }
            playButton.Background = tempImg;
        }
        private void mouseOver(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            ImageBrush tempImg = new ImageBrush();
            string tempURL = "pack://application:,,,/Assets/" + button.Name + "2.png";
            tempImg.ImageSource = new BitmapImage(new Uri(@tempURL));
            button.Background = tempImg;
            button.Height = 51;
            button.Width = 51;
        }

        private void mouseLeave(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            ImageBrush tempImg = new ImageBrush();
            string tempURL = "pack://application:,,,/Assets/" + button.Name + ".png";
            tempImg.ImageSource = new BitmapImage(new Uri(@tempURL));
            button.Background = tempImg;
            button.Height = 45;
            button.Width = 45;
        }
    }
}
