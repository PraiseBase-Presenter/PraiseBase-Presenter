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
        static private string[] extensions = { "*.ppl", "*.pbpl" };

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
                setting.dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal).ToString() + Path.DirectorySeparatorChar + setting.dataDirDefaultName;
                setting.Save();
                Console.WriteLine("Data dir set to " + setting.dataDirectory);
            }

            string searchDir = setting.dataDirectory +  Path.DirectorySeparatorChar + setting.songDir;

            validSongs = new List<Song>();

            int i=0;
            if (Directory.Exists(searchDir))
            {
                foreach (string ext in extensions)
                {
                    string[] songFilePaths = Directory.GetFiles(searchDir, ext, SearchOption.AllDirectories);
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

        /// <summary>
        /// Search the songlist for a given pattern and returns the matching songs
        /// </summary>
        /// <param name="needle">The search pattern</param>
        /// <param name="mode">If set to 1, the sogtext is also searched for the pattern. If set to 0, only the song title will be used</param>
        /// <returns>Returns a list of matches songs</returns>
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
