using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace MusicPlayer
{
     public class Playlist
    {
        public List<string[]> listOfFiles = new List<string[]>();
        public byte playlistSize;

        public void Size() //Return number of files
        {
            playlistSize = (byte)listOfFiles.Count();
        }
        public string GetSongName(string filePath)
        {
            Regex songName = new Regex(@"[^\\]*(mp3|flac|wav|mp4|wma)");
            Match match = songName.Match(filePath);
            return match.Value;
        }
        public string GetSongExtension(string songName)
        {
            Regex songExtension = new Regex(@".(mp3|wav|flac)");
            Match match = songExtension.Match(songName);
            return match.Value;
        }
        public void AddFile(string[] filePath)
        {
            string[] file = new string[3];//[0] - URL [1] - name [2] - extension
            file[0] = filePath[0];
            file[1] = GetSongName(filePath[0]);
            file[2] = GetSongExtension(file[1]);
            listOfFiles.Add(file);
            Size();
        }
        public void RemoveFile(string[] file)
        {
            listOfFiles.Remove(file);
            Size();
        }
    }

}
