using System.Collections.Generic;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public class PowerPraiseSongPart
    {
        public PowerPraiseSongPart()
        {
            Slides = new List<PowerPraiseSongSlide>();
        }

        /// <summary>
        ///     Caption
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        ///     Slides
        /// </summary>
        public List<PowerPraiseSongSlide> Slides { get; private set; }
    }
}