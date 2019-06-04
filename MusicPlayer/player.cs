using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Diagnostics;
using System.Threading;
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
using System.Timers;

namespace MusicPlayer
{
    public class Player
    {
        public System.Windows.Media.MediaPlayer _player;
        public int currentSongID =-1;
        public double volume = 0.1;
        System.Timers.Timer sync;
        public bool test;
        double i = 0;
        public System.Diagnostics.Process unity = new System.Diagnostics.Process();

        public void SongNameLabel(Label txtKron, string content)
        {
            txtKron.Content = content;
        }
        public void Play(Label txtKron, Playlist playlist, ProgressBar progress, bool isSpectrumOn)
        {
            _player = new System.Windows.Media.MediaPlayer();
            _player.MediaEnded += delegate { NextSong(playlist, txtKron, progress, isSpectrumOn); };
            SongNameLabel(txtKron, playlist.listOfFiles[0][1]);
            if (playlist.listOfFiles[0][2] == ".wav" && isSpectrumOn == true)
            {
                //UnityLaunch();
                //Thread.Sleep(2150);
                //Thread.Sleep(2485);
                AsynchronousClient.StartClient(playlist.listOfFiles[0][0]);
            }
            Uri uri = new Uri(playlist.listOfFiles[0][0]);
            _player.Open(uri);
            _player.MediaOpened += delegate {SetMax(progress); };
            currentSongID = 0;
            _player.Play();
            SetTimer(progress);
            _player.Volume = volume;
        }

        public void Play() //resume
        {
            _player.Volume = volume;
            _player.Play();
            sync.Start();
        }
        public void Pause()
        {
            _player.Pause();
            sync.Stop();
        }

        public void Stop(ProgressBar progress)
        {
            _player.Stop();
            i = 0;
            progress.Value = 0;
            sync.Stop();
        }
        public void NextSong(Playlist playlist, Label txtKron, ProgressBar progress, bool isSpectrumOn)
        {
            i = 0;
            if (currentSongID != -1)
            {
                if (currentSongID < playlist.playlistSize - 1)
                {
                    SongNameLabel(txtKron, playlist.listOfFiles[++currentSongID][1]);
                    if(playlist.listOfFiles[currentSongID][2] == ".wav" && isSpectrumOn == true) AsynchronousClient.StartClient(playlist.listOfFiles[currentSongID][0]);
                    _player.Stop();
                    Uri uri = new Uri(playlist.listOfFiles[currentSongID][0]);
                    _player.Open(uri);
                    _player.Play();

                }
                else if (currentSongID == playlist.playlistSize - 1)
                {
                    SongNameLabel(txtKron, playlist.listOfFiles[0][1]);
                    _player.Stop();
                    if (playlist.listOfFiles[0][2] == ".wav" && isSpectrumOn == true) AsynchronousClient.StartClient(playlist.listOfFiles[0][0]);
                    Uri uri = new Uri(playlist.listOfFiles[0][0]);
                    currentSongID = 0;
                    _player.Open(uri);
                    _player.Play();
                }
            }
        }
        public void PreviousSong(Playlist playlist, Label txtKron, ProgressBar progress, bool isSpectrumOn)
        {
            i = 0;
            if (currentSongID != -1)
            {
                if (currentSongID == 0)
                {
                    SongNameLabel(txtKron, playlist.listOfFiles[playlist.playlistSize - 1][1]);
                    _player.Stop();
                    Uri uri = new Uri(playlist.listOfFiles[playlist.playlistSize - 1][0]);
                    if (playlist.listOfFiles[playlist.playlistSize - 1][2] == ".wav" && isSpectrumOn == true) AsynchronousClient.StartClient(playlist.listOfFiles[playlist.playlistSize - 1][0]);
                    currentSongID = playlist.playlistSize - 1;
                    _player.Open(uri);
                    _player.Play();
                }
                else if (currentSongID > 0)
                {
                    SongNameLabel(txtKron, playlist.listOfFiles[--currentSongID][1]);
                    _player.Stop();
                    Uri uri = new Uri(playlist.listOfFiles[currentSongID][0]);
                    if (playlist.listOfFiles[currentSongID][2] == ".wav" && isSpectrumOn == true) AsynchronousClient.StartClient(playlist.listOfFiles[currentSongID][0]);
                    _player.Open(uri);
                    _player.Play();
                }
            }
        }
        public void Volume(double change, ProgressBar volumeBar, TextBlock volumeValue, string isMusicPlay)
        {
            if (volume >= 1 && change > 0)
            {
                //Do nothing
            }
            else if (volume <= 0 && change < 0)
            {
                //Do nothing
            }
            else
            {
                volume += change;
                if (isMusicPlay == "playing")
                {
                    _player.Volume = volume;
                    volumeBar.Value = volume * 100;
                    volumeValue.Text = (Math.Round(volume, 2) * 100) + "%";
                }
                else
                {
                    volumeBar.Value = volume * 100;
                    volumeValue.Text = (Math.Round(volume, 2) * 100) + "%";
                }
            }   
        }
        public void SetTimer(ProgressBar progress)
        {
            sync = new System.Timers.Timer(1000);
            sync.Elapsed += delegate { UpdateProgressBar(progress); };
            sync.AutoReset = true;
            sync.Enabled = true;
        }
        private void UpdateProgressBar(ProgressBar progress)
        {
            progress.Dispatcher.BeginInvoke(new Action(() => { progress.Value = i; }));
            i++;
        }
        private void SetMax(ProgressBar progress)
        {
            progress.Maximum = _player.NaturalDuration.TimeSpan.TotalSeconds;
        }
        private void UnityLaunch()
        {
            // unity.StartInfo.FileName = @"C:\Users\cwkoka\Desktop\ConsoleApp1.exe"; //ustawienia dla aplikacji konsolowej
            // unity.StartInfo.UseShellExecute = false;
            // unity.StartInfo.CreateNoWindow = true;
            //unity.StartInfo.FileName = @"D:\PTM - Projekt\Spectrum_Unity\Equalizer Unity.exe";
            ////unity.StartInfo.FileName = @"‪‪D:\PTM - Projekt\SpectrumUnity\Equalizer Unity.exe";
            //unity.StartInfo.CreateNoWindow = true;
            //unity.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            //unity.StartInfo.UseShellExecute = true;
            //unity.Start();
        }
        public void UnityClose()
        {
            //unity.Kill();
            //unity.WaitForExit();
        }
    }
}
