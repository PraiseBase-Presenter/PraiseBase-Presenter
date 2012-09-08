using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp.Data.Song
{
    /// <summary>
    /// Most songs come from some sort of collection of songs, be it a book or a 
    /// folder of some sort. It may be useful to track where the song comes from
    /// </summary>
    public class SongBook
    {
        /// <summary>
        /// The name of a song book
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The index of the song
        /// </summary>
        public string Entry { get; set; }
    }
}
