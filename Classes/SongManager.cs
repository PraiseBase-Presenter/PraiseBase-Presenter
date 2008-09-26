using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pbp.Properties;
using System.IO;

namespace Pbp
{
    class SongManager
    {
        static private SongManager instance;
        private List<Song> validSongs;

        private SongManager()
        {
            loadSongs();
        }

        public void loadSongs()
        {
            Settings setting = new Settings();

            validSongs = new List<Song>();
            string[] songFilePaths = Directory.GetFiles(setting.dataDirectory + "\\Songs", "*.ppl", SearchOption.AllDirectories);
            foreach (string file in songFilePaths)
            {
                Song tmpSong = new Song(file);
                if (tmpSong.isValid())
                {
                    validSongs.Add(tmpSong);
                }
            }
        }

        static public SongManager getInstance()
        {
            if (instance == null)
            {
                instance = new SongManager();
            }
            return instance;
        }

        public List<Song> getAll()
        {
            return validSongs;
        }

        public List<Song> getSearchResults(string needle, int mode)
        {
            List<Song> tmpList = new List<Song>();
            for (int i=0;i<validSongs.Count;i++)
            {
                if (validSongs[i].title().ToLower().Contains(needle.ToLower()) ||
                    (mode==1 && validSongs[i].text().ToLower().Contains(needle.ToLower())))
                {
                    tmpList.Add(validSongs[i]);
                }
            }
            return tmpList;
        }
    }
}
