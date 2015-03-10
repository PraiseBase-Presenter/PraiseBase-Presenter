using System.Collections.Generic;

namespace PraiseBase.Presenter.Persistence.OpenLyrics
{
    public class OpenLyricsSongLines
    {
        /// <summary>
        /// Part
        /// </summary>
        public string Part { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        public List<string> Text { get; private set; }

        public OpenLyricsSongLines()
        {
            Text = new List<string>();
        }
    }
}
