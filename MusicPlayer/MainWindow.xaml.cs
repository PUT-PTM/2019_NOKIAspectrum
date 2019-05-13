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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace MusicPlayer
{
    public partial class MainWindow : Window
    {

        public string isMusicPlay = "stopped";
        Playlist playlist = new Playlist();
        Player player = new Player();
        public MainWindow()
        {
            InitializeComponent();
            _window.AllowDrop = true;
            playButton.Click += ClickEvent;
            playButton.MouseEnter += MouseOverButton;
            playButton.MouseLeave += MouseLeaveButton;
            stopButton.Click += ClickEvent;
            stopButton.MouseEnter += MouseOverButton;
            stopButton.MouseLeave += MouseLeaveButton;
            nextButton.Click += ClickEvent;
            nextButton.MouseEnter += MouseOverButton;
            nextButton.MouseLeave += MouseLeaveButton;
            previousButton.Click += ClickEvent;
            previousButton.MouseEnter += MouseOverButton;
            previousButton.MouseLeave += MouseLeaveButton;
            closeButton.Click += ClickEvent;
            closeButton.MouseEnter += MouseOverButton;
            closeButton.MouseLeave += MouseLeaveButton;
            spectrum.Click += delegate { Thread thr = new Thread(new ThreadStart(AsynchronousSocketListener.StartListening)); thr.Start(); };
            _window.Drop += DropFile;
            _window.MouseLeftButtonDown += WindowDrag;
            _window.MouseWheel += VolumeChange;
        }

        public void ClickEvent(object sender, RoutedEventArgs e)
        {
            var tempBtn = (Button)sender;
            ImageBrush tempImg = new ImageBrush();
            switch (tempBtn.Name)
            {
                case "playButton": //play
                    if(playlist.playlistSize > 0)
                    {
                        tempImg.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Assets/pauseButton2.png"));
                        tempBtn.Background = tempImg;
                        tempBtn.Name = "pauseButton";
                        player.Play();
                        isMusicPlay = "playing";
                    }
                    break;
                case "pauseButton": //pause
                    tempImg.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Assets/playButton2.png"));
                    tempBtn.Background = tempImg;
                    tempBtn.Name = "playButton";
                    player.Pause();
                    isMusicPlay = "paused";
                    break;
                case "stopButton": //stop
                    if(isMusicPlay == "playing" || isMusicPlay == "paused")
                    {
                        player.Stop(progress);
                        tempImg.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Assets/playButton.png"));
                        playButton.Background = tempImg;
                        playButton.Name = "playButton";
                        isMusicPlay = "stopped";
                    }
                        
                    break;
                case "nextButton": //next
                    if (playlist.playlistSize !=0)
                    {
                        player.NextSong(playlist, txtKron, progress);
                        tempImg.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Assets/pauseButton.png"));
                        playButton.Background = tempImg;
                        playButton.Name = "pauseButton";
                        isMusicPlay = "playing";
                    }
                    break;
                case "previousButton": //previous
                    if (playlist.playlistSize != 0)
                    {
                        player.PreviousSong(playlist, txtKron, progress);
                        tempImg.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Assets/pauseButton.png"));
                        playButton.Background = tempImg;
                        playButton.Name = "pauseButton";
                        isMusicPlay = "playing";
                    }
                    break;
                case "closeButton": //close
                    this.Close();
                    break;
            }

        }
        public void MouseOverButton(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            ImageBrush tempImg = new ImageBrush();
            string tempURL = "pack://application:,,,/Assets/" + button.Name + "2.png";
            tempImg.ImageSource = new BitmapImage(new Uri(@tempURL));
            button.Background = tempImg;
            button.Height = 50;
            button.Width = 50;
        }
        public void MouseLeaveButton(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            ImageBrush tempImg = new ImageBrush();
            string tempURL = "pack://application:,,,/Assets/" + button.Name + ".png";
            tempImg.ImageSource = new BitmapImage(new Uri(@tempURL));
            button.Background = tempImg;
            button.Height = 45;
            button.Width = 45;
        }
        private void DropFile(object sender, DragEventArgs e)
        {
            string[] tempFile;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                tempFile = (string[])e.Data.GetData(DataFormats.FileDrop);
                playlist.AddFile(tempFile);
                if (isMusicPlay == "stopped")
                {
                    player.Play(txtKron, playlist, progress);
                    isMusicPlay = "playing";
                    ImageBrush tempImg = new ImageBrush();
                    tempImg.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Assets/pauseButton.png"));
                    playButton.Background = tempImg;
                    playButton.Name = "pauseButton";
                }
            }
        }
        private void WindowDrag(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void VolumeChange(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                player.Volume(0.02, volume, volumeValue, isMusicPlay);
            }
            else player.Volume(-0.02, volume, volumeValue, isMusicPlay);
        }
    }
}

