using System.Collections.Generic;

namespace PraiseBase.Presenter.Persistence.OpenLyrics
{
    public class OpenLyricsSongLines
    {
        public OpenLyricsSongLines()
        {
            Text = new List<string>();
        }

        /// <summary>
        ///     Part
        /// </summary>
        public string Part { get; set; }

        /// <summary>
        ///     Text
        /// </summary>
        public List<string> Text { get; private set; }
    }
}