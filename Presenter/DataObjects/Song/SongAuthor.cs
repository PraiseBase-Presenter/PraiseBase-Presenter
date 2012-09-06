using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp.Data.Song
{
    public enum SongAuthorType
    {
        words,
        music,
        translation
    }

    public class SongAuthor
    {
        public string Name { get; set; }
        public SongAuthorType Type { get; set; }
    }
}
