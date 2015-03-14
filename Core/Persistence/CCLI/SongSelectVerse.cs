using System.Collections.Generic;

namespace PraiseBase.Presenter.Persistence.CCLI
{
    public class SongSelectVerse
    {
        public SongSelectVerse()
        {
            Lines = new List<string>();
        }

        /// <summary>
        ///     Caption
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        ///     Lyrics
        /// </summary>
        public List<string> Lines { get; private set; }
    }
}