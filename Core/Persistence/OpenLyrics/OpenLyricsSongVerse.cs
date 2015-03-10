using System.Collections.Generic;

namespace PraiseBase.Presenter.Persistence.OpenLyrics
{
    public class OpenLyricsSongVerse
    {
        /// <summary>
        /// Caption
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Transliteration
        /// </summary>
        public string Transliteration { get; set; }

        /// <summary>
        /// Lyrics
        /// </summary>
        public List<OpenLyricsSongLines> Lines { get; private set; }

        public OpenLyricsSongVerse()
        {
            Lines = new List<OpenLyricsSongLines>();
        }
    }
}
