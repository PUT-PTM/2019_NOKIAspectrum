using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
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
        List<string[]> listOfFiles = new List<string[]>();
        string[] files;
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            ImageBrush tempImg = new ImageBrush();
            if (!isMusicPlay)
            {
                tempImg.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Assets/pauseButton2.png"));
                button.Name = "pauseButton";
                isMusicPlay = true;
            }
            else
            {
                tempImg.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Assets/playButton2.png"));
                button.Name = "playButton";
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

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private System.Windows.Media.MediaPlayer _player;
        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                files = (string[])e.Data.GetData(DataFormats.FileDrop);
                listOfFiles.Add(files);
                currentPlay.Text = files[0];
                if (listOfFiles.Count() == 1)
                {
                    _player = new System.Windows.Media.MediaPlayer();
                    Uri uri = new Uri(files[0]);
                    _player.Open(uri);
                    _player.Play();
                }
            }
        }
    }
}
