using System.Collections.Generic;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public class PowerPraiseSongSlide
    {
        public PowerPraiseSongSlide()
        {
            Lines = new List<string>();
            Translation = new List<string>();
        }

        /// <summary>
        ///     Font size of the main text
        /// </summary>
        public int MainSize { get; set; }

        /// <summary>
        ///     Background number (starting from 0)
        /// </summary>
        public int BackgroundNr { get; set; }

        /// <summary>
        ///     Song text lines
        /// </summary>
        public List<string> Lines { get; private set; }

        /// <summary>
        ///     Translation text lines
        /// </summary>
        public List<string> Translation { get; private set; }
    }
}