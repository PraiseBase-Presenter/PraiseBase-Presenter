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
using System.IO;
using Pbp.Properties;
using Pbp.IO;
using Pbp.Data.Song;

namespace Pbp
{
    /// <summary>
    /// Holds a list of all songs and provides
    /// searching in the songlist
    /// </summary>
    internal class SongManager
    {
        /// <summary>
        /// Song item structure
        /// </summary>
        public struct SongItem
        {
            public Song Song { get; set; }
            public string Filename { get; set; }
        }

        /// <summary>
        /// Singleton variable
        /// </summary>
        private static SongManager _instance;

        /// <summary>
        /// List of all availabe songs
        /// </summary>
        public Dictionary<Guid, SongItem> SongList { get; protected set; }

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
        /// Gets the current slide
        /// </summary>
        public SongSlide CurrentSlide
        {
            get { return CurrentSong.Song.Parts[CurrentPartNr].Slides[CurrentSlideNr]; }
        }

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
                this.Number = number;
                this.Total = total;
            }
        }

        #endregion Events

        /// <summary>
        /// Gets the singleton of this class (field alternative)
        /// </summary>
        public static SongManager Instance
        {
            get { return _instance ?? (_instance = new SongManager()); }
        }

        /// <summary>
        /// The constructor
        /// </summary>
        private SongManager()
        {
            CurrentPartNr = 0;
            CurrentSlideNr = 0;

            SongDirPath = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SongDir;
            if (!Directory.Exists(SongDirPath))
            {
                Directory.CreateDirectory(SongDirPath);
            }
        }

        /// <summary>
        /// Reloads all songs from the song direcory
        /// specified in the application settings
        /// </summary>
        public void Reload()
        {
            // Find song files
            var songPaths = new List<string>();
            foreach (string ext in SongFileReaderFactory.Instance.SupportedExtensions)
            {
                string[] songFilePaths = Directory.GetFiles(SongDirPath, "*" + ext, SearchOption.AllDirectories);
                songPaths.AddRange(songFilePaths);
            }
            int cnt = songPaths.Count;

            // Load songs into list
            int i = 0;
            SongList = new Dictionary<Guid, SongItem>();
            foreach (string path in songPaths)
            {
                try
                {
                    SongItem si = new SongItem();
                    SongFileReader sfr = SongFileReaderFactory.Instance.CreateFactoryByFile(path);
                    si.Song = sfr.Load(path);
                    si.Filename = path;

                    SongList.Add(si.Song.GUID, si);
                    if (i % 25 == 0)
                    {
                        SongLoadEventArgs e = new SongLoadEventArgs(i, cnt);
                        OnSongLoaded(e);
                    }
                    i++;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to load song file " + path + " (" + e.Message + ")");
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        protected virtual void OnSongLoaded(SongLoadEventArgs e)
        {
            if (SongLoaded != null)
            {
                SongLoaded(e);
            }
        }

        /// <summary>
        /// Returns the list id of the song with specified title
        /// </summary>
        /// <param name="title">The title of the song</param>
        /// <returns>Returns the position in the songlist</returns>
        public Guid GetGuidByTitle(string title)
        {
            foreach (var kvp in SongList)
            {
                if (kvp.Value.Song.Title == title)
                {
                    return kvp.Key;
                }
            }
            return Guid.Empty;
        }

        /// <summary>
        /// Reloads the song at the specified position
        /// </summary>
        public void ReloadSong(Guid g)
        {
            // TODO Check for inexistent items
            string path = SongList[g].Filename;
            try
            {
                SongItem si = new SongItem();
                SongFileReader sfr = SongFileReaderFactory.Instance.CreateFactoryByFile(path);
                si.Song = sfr.Load(path);
                si.Filename = path;

                // TODO
                if (g == si.Song.GUID)
                {
                    SongList[g] = si;
                }
                else
                {
                    SongList.Remove(g);
                    SongList[si.Song.GUID] = si;

                    // TODO Inform others that guid has changed
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to load song file " + path + " (" + e.Message + ")");
            }
        }

        /// <summary>
        /// Reloads the song with the specified path
        /// </summary>
        /// <param name="path">Path to the song file</param>
        public void ReloadSongByPath(string path)
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
                        ReloadSong(kvp.Key);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the song with the specified path
        /// </summary>
        /// <param name="path">Path to the song file</param>
        public Song GetSongByPath(string path)
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
                        return kvp.Value.Song;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Search the songlist for a given pattern and returns the matching songs
        /// </summary>
        /// <param name="needle">The search pattern</param>
        /// <param name="mode">If set to 1, the sogtext is also searched for the pattern. If set to 0, only the song title will be used</param>
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
                    (searchMode == SongSearchMode.TitleAndText && SongList[kvp.Key].Song.SearchText.Contains(needle)))
                {
                    tmpList.Add(SongList[kvp.Key]);
                }
            }
            return tmpList;
        }

        public void SaveCurrentSong()
        {
            SongFileWriter sfw = SongFileWriterFactory.Instance.CreateFactoryByFile(CurrentSong.Filename);
            sfw.Save(CurrentSong.Filename, CurrentSong.Song);
        }
    }

    /// <summary>
    /// Search options
    /// </summary>
    public enum SongSearchMode
    {
        Title,
        TitleAndText
    }
}