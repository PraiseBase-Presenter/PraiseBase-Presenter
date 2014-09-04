using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp.Model.Song.PowerPraise
{
    public class PowerPraiseSongSlide
    {
        /// <summary>
        /// Font size of the main text
        /// </summary>
        public int MainSize { get; set; }

        /// <summary>
        /// Background number (starting from 0)
        /// </summary>
        public int BackgroundNr { get; set; }

        /// <summary>
        /// Song text lines
        /// </summary>
        public List<string> Lines { get; private set; }

        /// <summary>
        /// Translation text lines
        /// </summary>
        public List<string> Translation { get; private set; }

        public PowerPraiseSongSlide()
        {
            Lines = new List<string>();
            Translation = new List<string>();
        }
    }
}
