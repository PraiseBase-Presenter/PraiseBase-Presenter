using System;
using System.Collections.Generic;

namespace Pbp
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