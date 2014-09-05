using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraiseBase.Presenter.Model.Song.PowerPraise
{
    public class PowerPraiseSongPart
    {
        /// <summary>
        /// Caption
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Slides
        /// </summary>
        public List<PowerPraiseSongSlide> Slides { get; private set; }

        public PowerPraiseSongPart()
        {
            Slides = new List<PowerPraiseSongSlide>();
        }
    }
}
