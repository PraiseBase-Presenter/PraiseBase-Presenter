using System;
using System.Collections.Generic;

namespace Pbp
{
    public abstract class SongFileReader
    {
        public static readonly Dictionary<String, SongFileType> SupportedFileTypes = new Dictionary<string, SongFileType>{
            { "ppl", new SongFileType("PowerPraise Lied", "ppl")},
            //{ "openlyrics", new SongFileType("OpenLyrics", "xml")},
            //{ "pbps", new SongFileType("PraiseBase-Presenter Song", "pbps")}
        };

        abstract public Song load(string filename);

        public static SongFileReader createFactory(string type)
        {
            if (type == "ppl")
            {
                return new PowerPraiseSongFileReader();
            }

            throw new NotImplementedException();
        }

        public static SongFileReader createFactoryByFile(string filename)
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

        public static HashSet<string> getSupportedExtensions()
        {
            HashSet<string> l = new HashSet<string>();
            foreach (var t in SupportedFileTypes)
            {
                l.Add(t.Value.Extension);
            }
            return l;
        }
    }
}