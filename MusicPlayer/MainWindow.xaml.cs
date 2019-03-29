﻿using System;
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
        Playlist x = new Playlist();
        private System.Windows.Media.MediaPlayer _player;

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
                if (listOfFiles.Count() > 0)
                {
                    _player.Play();
                    isMusicPlay = true;
                }
            }
            else
            {
                tempImg.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Assets/playButton2.png"));
                button.Name = "playButton";
                if (isMusicPlay)
                {
                    _player.Pause();
                    isMusicPlay = false;
                }
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
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                files = (string[])e.Data.GetData(DataFormats.FileDrop);
                listOfFiles.Add(files);
                if (listOfFiles.Count() == 1)
                {
                    currentPlay.Text = x.GetSongName(files[0]);
                    _player = new System.Windows.Media.MediaPlayer();
                    Uri uri = new Uri(files[0]);
                    _player.Open(uri);
                    _player.Play();
                    isMusicPlay = true;
                }
            }
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            _player.Stop();
            isMusicPlay = false;
        }

        private void Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_player != null)
                _player.Volume = e.NewValue;
        }

        private void Volume_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (_player != null && e.Delta > 0)
            {
                _player.Volume += 0.02;
            }
            else if(_player != null && e.Delta < 0)
            {
                _player.Volume -= 0.02;
            }
            this.Volume.Value = _player.Volume;
        }
    }
}
