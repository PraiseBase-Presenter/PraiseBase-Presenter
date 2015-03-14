/*
 *   PraiseBase Presenter
 *   The open source lyrics and image projection software for churches
 *
 *   http://praisebase.org
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
 */

using System;
using System.Collections.Generic;
using System.IO;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Persistence;

namespace PraiseBase.Presenter.Manager
{
    /// <summary>
    /// Holds a list of all songs and provides
    /// searching in the songlist
    /// </summary>
    public class SongManager
    {
        /// <summary>
        /// List of all availabe songs
        /// </summary>
        public Dictionary<string, SongItem> SongList { get; protected set; }

        /// <summary>
        /// Gets or sets the current song object
        /// </summary>
        public SongItem CurrentSong { get; set; }

        /// <summary>
        /// Gets or sets the current part number
        /// </summary>
        public int CurrentPartNr { get; set; }

        /// <summary>
        /// Gets or sets the current slide number
        /// </summary>
        public int CurrentSlideNr { get; set; }

        /// <summary>
        /// Path to the song root directory
        /// </summary>
        public string SongDirPath { get; protected set; }

        #region Events

        public delegate void SongLoad(SongLoadEventArgs e);

        public event SongLoad SongLoaded;

        public class SongLoadEventArgs : EventArgs
        {
            public int Number { get; set; }

            public int Total { get; set; }

            public SongLoadEventArgs(int number, int total)
            {
                Number = number;
                Total = total;
            }
        }

        #endregion Events

        /// <summary>
        /// The constructor
        /// </summary>
        public SongManager(string songDirPath)
        {
            CurrentPartNr = -1;
            CurrentSlideNr = -1;
            SongDirPath = songDirPath;
            SongList = new Dictionary<string, SongItem>();

            // Ensure song directory exists
            if (!Directory.Exists(SongDirPath))
            {
                Directory.CreateDirectory(SongDirPath);
            }
        }
        
        /// <summary>
        /// Gets the current slide
        /// </summary>
        public SongSlide GetCurrentSlide()
        {
            return CurrentSong.Song.Parts[CurrentPartNr].Slides[CurrentSlideNr];
        }

        /// <summary>
        /// Reloads all songs from the song direcory
        /// specified in the application settings
        /// </summary>
        public void Reload()
        {
            // Find song files
            var songPaths = new List<string>();
            foreach (string ext in SongFilePluginFactory.SupportedExtensions)
            {
                string[] songFilePaths = Directory.GetFiles(SongDirPath, "*" + ext, SearchOption.AllDirectories);
                songPaths.AddRange(songFilePaths);
            }
            int cnt = songPaths.Count;

            // Load songs into list
            int i = 0;
            SongList = new Dictionary<string, SongItem>();
            foreach (string path in songPaths)
            {
                try
                {
                    var plugin = SongFilePluginFactory.Create(path);
                    SongItem si = new SongItem
                    {
                        Plugin = plugin,
                        Filename = path,
                        Song = plugin.Load(path)
                    };
                    SongList.Add(path, si);
                    if (i % 25 == 0)
                    {
                        SongLoadEventArgs e = new SongLoadEventArgs(i, cnt);
                        if (SongLoaded != null)
                        {
                            SongLoaded(e);
                        }
                    }
                    i++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(@"Unable to load song file " + path + @" (" + e.Message + @")");
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        /// <summary>
        /// Returns the list id of the song with specified title
        /// </summary>
        /// <param name="title">The title of the song</param>
        /// <returns>Returns the position in the songlist</returns>
        public string GetKeyByTitle(string title)
        {
            foreach (var kvp in SongList)
            {
                if (kvp.Value.Song.Title == title)
                {
                    return kvp.Key;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the song with the specified path
        /// </summary>
        /// <param name="path">Path to the song file</param>
        public SongItem GetSongItemByPath(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                foreach (var kvp in SongList)
                {
                    if (String.Compare(
                        Path.GetFullPath(kvp.Value.Filename).TrimEnd('\\'),
                        Path.GetFullPath(path).TrimEnd('\\'),
                        StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        return kvp.Value;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Reloads the song with the specified path
        /// </summary>
        /// <param name="path">Path to the song file</param>
        public void ReloadSongByPath(string path)
        {
            SongItem si = GetSongItemByPath(path);
            if (si != null)
            {
                try
                {
                    si.Song = si.Plugin.Load(si.Filename);
                }
                catch (Exception e)
                {
                    Console.WriteLine(@"Unable to load song file " + path + @" (" + e.Message + @")");
                }
            }
        }

        /// <summary>
        /// Search the songlist for a given pattern and returns the matching songs
        /// </summary>
        /// <param name="needle">The search pattern</param>
        /// <param name="searchMode">If set to 1, the sogtext is also searched for the pattern. If set to 0, only the song title will be used</param>
        /// <returns>Returns a list of matches songs</returns>
        public List<SongItem> GetSearchResults(string needle, SongSearchMode searchMode)
        {
            needle = needle.Trim().ToLower();
            needle = needle.Replace(",", "");
            needle = needle.Replace(".", "");
            needle = needle.Replace(";", "");
            needle = needle.Replace(Environment.NewLine, "");
            needle = needle.Replace("  ", " ");

            var tmpList = new List<SongItem>();
            foreach (var kvp in SongList)
            {
                if (SongList[kvp.Key].Song.Title.ToLower().Contains(needle) ||
                    (searchMode == SongSearchMode.TitleAndText && SongList[kvp.Key].SearchText.Contains(needle)))
                {
                    tmpList.Add(SongList[kvp.Key]);
                }
            }
            return tmpList;
        }

        /// <summary>
        /// Saves the currently active song
        /// </summary>
        public void SaveCurrentSong()
        {
            if (CurrentSong == null) return;

            if (CurrentSong.Plugin.IsWritingSupported())
            {
                CurrentSong.Plugin.Save(CurrentSong.Song, CurrentSong.Filename);
            }
            else
            {
                throw new Exception("Das Speichern der Lieddatei " + CurrentSong.Filename + " wird von diesem Dateiformat leider nicht unterstützt!");
            }
        }
    }
}