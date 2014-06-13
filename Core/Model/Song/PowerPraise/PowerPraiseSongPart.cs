using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp.Model.Song.PowerPraise
{
    public class PowerPraiseSongTextPart
    {
        public string Caption { get; set; }
        public List<PowerPraiseSongTextSlide> Slides { get; private set; }

        public PowerPraiseSongTextPart()
        {
            Slides = new List<PowerPraiseSongTextSlide>();
        }
    }
}
