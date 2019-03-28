using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MusicPlayer
{
     public class Playlist
    {
        List<string[]> listOfFiles;

        public byte Size() //Return number of files
        {
            byte size = (byte)listOfFiles.Count();
            return size;
        }
        public string GetSongName(string filePath)
        {
            Regex songName = new Regex(@"[^\\]*(mp3|flac|wav|mp4|wma)");
            Match match = songName.Match(filePath);
            return match.Value;
        }
        public void AddFile(string[] filePath)
        {
            string[] file = new string[2];//[0] - URL [1] - name
            file[0] = filePath[0];
            file[1] = GetSongName(filePath[0]);
            listOfFiles.Add(file);
        }
    }

}
