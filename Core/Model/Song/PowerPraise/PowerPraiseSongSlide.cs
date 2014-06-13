using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp.Model.Song.PowerPraise
{
    public class PowerPraiseSongTextSlide
    {
        public int MainSize { get; set; }
        public int BackgroundNr { get; set; }
        public List<string> Lines { get; private set; }
        public List<string> TranslatedLines { get; private set; }

        public PowerPraiseSongTextSlide()
        {
            Lines = new List<string>();
            TranslatedLines = new List<string>();
        }
    }
}
