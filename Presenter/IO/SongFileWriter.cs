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
using Pbp.Data.Song;

namespace Pbp.IO
{
    public abstract class SongFileWriter
    {
        public const string PreferredType = "ppl";

        public static readonly Dictionary<String, SongFileType> SupportedFileTypes = new Dictionary<string, SongFileType>{
            { "ppl", new SongFileType("PowerPraise Lied", "ppl")},
            //{ "openlyrics", new SongFileType("OpenLyrics", "xml")},
            //{ "pbps", new SongFileType("PraiseBase-Presenter Song", "pbps")}
        };

        abstract public void save(string filename, Song sng);

        public static SongFileWriter createFactory(string type)
        {
            if (type == "ppl")
            {
                return new PowerPraiseSongFileWriter();
            }
            throw new NotImplementedException();
        }

        public static SongFileWriter createFactoryByFile(string filename)
        {
            string ext = System.IO.Path.GetExtension(filename);
            if (ext == ".ppl")
            {
                return createFactory("ppl");
            }
            throw new NotImplementedException();
        }

        public static string getFileBoxFilter()
        {
            String fltr = String.Empty;
            foreach (var t in SupportedFileTypes)
            {
                fltr += t.Value.Name + " (*." + t.Value.Extension + ")|*." + t.Value.Extension + "|";
            }
            fltr += "Alle Dateien (*.*)|*.*";
            return fltr;
        }
    }
}