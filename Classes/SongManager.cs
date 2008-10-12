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
        private Song _currentSong;

        public Song currentSong
        {
            get
            {
                return _currentSong;
            }
            set
            {
                _currentSong = value;
            }
        }

        private SongManager()
        {
            loadSongs();
        }

        public void loadSongs()
        {
            Settings setting = new Settings();

            if (setting.dataDirectory == "")
            {
                setting.dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal).ToString()+ "\\Praisebase Presenter";
                setting.Save();
                Console.WriteLine("Data dir set to " + setting.dataDirectory);
            }

            string searchDir = setting.dataDirectory + "\\Songs";

            validSongs = new List<Song>();

            int i=0;
            if (Directory.Exists(searchDir))
            {
                string[] songFilePaths = Directory.GetFiles(searchDir, "*.ppl", SearchOption.AllDirectories);
                foreach (string file in songFilePaths)
                {
                    Song tmpSong = new Song(file);
                    if (tmpSong.isValid())
                    {
                        tmpSong.id = i;
                        validSongs.Add(tmpSong);
                        i++;
                    }
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

        public Song get(int id)
        {
            return validSongs[id];
        }

        public List<Song> getSearchResults(string needle, int mode)
        {
            List<Song> tmpList = new List<Song>();
            for (int i=0;i<validSongs.Count;i++)
            {
                if (validSongs[i].title.ToLower().Contains(needle.ToLower()) ||
                    (mode==1 && validSongs[i].text.ToLower().Contains(needle.ToLower())))
                {
                    tmpList.Add(validSongs[i]);
                }
            }
            return tmpList;
        }
    }
}
