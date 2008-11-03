/*
 *   PraiseBase Presenter 
 *   The open source lyrics and image projection software for churches
 *   
 *   http://code.google.com/p/praisebasepresenter
 *
 *   This program is free software; you can redistribute it and/or
 *   modify it under the terms of the GNU General Public License
 *   as published by the Free Software Foundation; either version 2
 *   of the License, or (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program; if not, write to the Free Software
 *   Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 *   Author:
 *      Nicolas Perrenoud <nicu_at_lavine.ch>
 *   Co-authors:
 *      ...
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pbp.Properties;
using System.IO;
using System.Windows.Forms;

namespace Pbp
{
	/// <summary>
	/// Holds a list of all songs and provides
	/// searching in the songlist
	/// </summary>
    class SongManager
    {
		/// <summary>
		/// Singleton variable
		/// </summary>
        static private SongManager _instance;

        /// <summary>
        /// List of all availabe songs
        /// </summary>
		public List<Song> Songs {get; private set;}
		/// <summary>
		/// Gets or sets the current song object
		/// </summary>
        public Song CurrentSong {get;set;}


		/// <summary>
		/// The constructor
		/// </summary>
        private SongManager()
        {
            reload();
        }

		/// <summary>
		/// Gets the singleton of this class
		/// </summary>
		/// <returns>Returns an unique instance of the song manager</returns>
		static public SongManager getInstance()
		{
			if (_instance == null)
			{
				_instance = new SongManager();
			}
			return _instance;
		}

		/// <summary>
		/// Reloads all songs from the song direcory
		/// specified in the application settings
		/// </summary>
        public void reload()
        {
            Settings setting = new Settings();

            if (setting.DataDirectory == "")
            {
				// Todo: check and create
                setting.DataDirectory =  Environment.GetFolderPath(Environment.SpecialFolder.Personal).ToString() + Path.DirectorySeparatorChar + setting.DataDirDefaultName;
                setting.Save();
            }

            string searchDir = setting.DataDirectory +  Path.DirectorySeparatorChar + setting.SongDir;

			Songs = new List<Song>();
            int i=0;
            if (Directory.Exists(searchDir))
            {
                foreach (string ext in Song.fileType.getAllExtensions())
                {
                    string[] songFilePaths = Directory.GetFiles(searchDir, ext, SearchOption.AllDirectories);
                    foreach (string file in songFilePaths)
                    {
                        Song tmpSong = new Song(file);
                        if (tmpSong.IsValid)
                        {
                            tmpSong.ID = i;
                            Songs.Add(tmpSong);
                            i++;
                        }
                    }
                }
            }            
        }

		/// <summary>
		/// Returns the list id of the song with specified title
		/// </summary>
		/// <param name="title">The title of the song</param>
		/// <returns>Returns the position in the songlist</returns>
		public int getIdByTitle(string title)
		{
			for (int i = 0; i < Songs.Count; i++)
			{
				if (Songs[i].Title == title)
				{
					return i;
				}
			}
			return -1;			
		}

		/// <summary>
		/// Reloads the song at the specified position
		/// </summary>
		/// <param name="i">The song position</param>
		public void reloadSong(int i)
		{
			Songs[i] = new Song(Songs[i].FilePath);
		}

		/// <summary>
		/// Reloads the song with the specified path
		/// </summary>
		/// <param name="path">Path to the song file</param>
		public void reloadSong(string path)
		{
			if (path != String.Empty && path != null)
			{
				for (int i = 0; i < Songs.Count; i++)
				{
					if (Songs[i].FilePath.ToLower() == path.ToLower())
					{
						Songs[i] = new Song(Songs[i].FilePath);
						return;
					}
				}
			}
		}

		/// <summary>
		/// Search the songlist for a given pattern and returns the matching songs
		/// </summary>
		/// <param name="needle">The search pattern</param>
		/// <param name="mode">If set to 1, the sogtext is also searched for the pattern. If set to 0, only the song title will be used</param>
		/// <returns>Returns a list of matches songs</returns>
		public List<Song> getSearchResults(string needle, int mode)
        {
			needle = needle.Trim().ToLower();
			needle = needle.Replace(",", "");
			needle = needle.Replace(".", "");
			needle = needle.Replace(";", "");
			needle = needle.Replace(Environment.NewLine, "");
			needle = needle.Replace("  ", " ");

            List<Song> tmpList = new List<Song>();
            for (int i=0;i<Songs.Count;i++)
            {
                if (Songs[i].Title.ToLower().Contains(needle) ||
					(mode == 1 && Songs[i].SearchText.Contains(needle)))
                {
                    tmpList.Add(Songs[i]);
                }
            }
            return tmpList;
        }
    }
}
