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

namespace MusicPlayer
{
    public class Player
    {
        private System.Windows.Media.MediaPlayer _player;
        
        public void SongNameLabel(Label txtKron, string content)
        {
            txtKron.Content = content;
        }
        public void Play(Label txtKron, Playlist playlist)
        {
            _player = new System.Windows.Media.MediaPlayer();
            SongNameLabel(txtKron, playlist.listOfFiles[0][1]);
            Uri uri = new Uri(playlist.listOfFiles[0][0]);
            _player.Open(uri);
            _player.Play();
        }

        public void Play()
        {
            _player.Play();
        }

        public void Pause()
        {
            _player.Pause();
        }

        public void Stop()
        {
            _player.Stop();
        }
        //badaj stan odtwarzacza (jezeli skonczyl piosenke, zmienia zmienna isMusicPlay na false)
    }
}
