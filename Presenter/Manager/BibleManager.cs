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
using Pbp.Data.Bible;

namespace Pbp
{
    /// <summary>
    /// Holds a list of all songs and provides
    /// searching in the songlist
    /// </summary>
    internal class BibleManager
    {
        /// <summary>
        /// Song item structure
        /// </summary>
        public struct BibleItem
        {
            public Bible Bible { get; set; }

            public string Filename { get; set; }

            public override string ToString()
            {
                return Bible.Title;
            }
        }

        /// <summary>
        /// Singleton variable
        /// </summary>
        private static BibleManager _instance;

        /// <summary>
        /// List of all availabe songs
        /// </summary>
        public Dictionary<string, BibleItem> BibleList { get; protected set; }

        /// <summary>
        /// Gets or sets the current song object
        /// </summary>
        public BibleItem CurrentBible { get; set; }

        /// <summary>
        /// Gets the singleton of this class (field alternative)
        /// </summary>
        public static BibleManager Instance
        {
            get { return _instance ?? (_instance = new BibleManager()); }
        }

        /// <summary>
        /// The constructor
        /// </summary>
        private BibleManager()
        {
        }

        public List<string> getBibleFiles()
        {
            List<string> res = new List<string>();
            DirectoryInfo di = new DirectoryInfo(Pbp.Properties.Settings.Default.DataDirectory + Path.DirectorySeparatorChar + "Bibles");
            if (!di.Exists)
            {
                di.Create();
            }
            FileInfo[] rgFiles = di.GetFiles("*.xml");
            foreach (FileInfo fi in rgFiles)
            {
                res.Add(fi.FullName);
            }
            return res;
        }

        public void loadBibleInfo()
        {
            BibleList = new Dictionary<string, BibleItem>();
            foreach (string file in getBibleFiles())
            {
                Pbp.IO.XMLBibleReblader rdr = new Pbp.IO.XMLBibleReblader();
                try
                {
                    BibleItem bi = new BibleItem();
                    bi.Bible = rdr.loadMeta(file);
                    bi.Filename = file;
                    BibleList.Add(bi.Bible.Identifier != null ? bi.Bible.Identifier : bi.Filename, bi);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void loadBibleData(string key)
        {
            Pbp.IO.XMLBibleReblader rdr = new Pbp.IO.XMLBibleReblader();
            try
            {
                rdr.loadContent(BibleList[key].Filename, BibleList[key].Bible);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}