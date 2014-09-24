using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraiseBase.Presenter.Persistence.CCLI
{
    public class SongSelectFile : PersistentSong
    {
        /// <summary>
        /// CCLI ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Title of the song
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Copyright owner
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// Rights Administrator
        /// </summary>
        public string Admin { get; set; }

        /// <summary>
        /// Themes
        /// </summary>
        public List<string> Themes { get; private set; }

        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Verses
        /// </summary>
        public List<SongSelectVerse> Verses { get; private set; }

        public SongSelectFile()
        {
            Themes = new List<string>();
            Verses = new List<SongSelectVerse>();
        }
    }
}
