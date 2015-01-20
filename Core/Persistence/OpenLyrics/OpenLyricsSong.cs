using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraiseBase.Presenter.Persistence.OpenLyrics
{
    public class OpenLyricsSong : ISongFile
    {
        /// <summary>
        /// Timestamp when the song has been last modified
        /// </summary>
        public string ModifiedTimestamp { get; set; }

        /// <summary>
        /// Application the song was created in
        /// </summary>
        public string CreatedIn { get; set; }

        /// <summary>
        /// Application the song was modified in
        /// </summary>
        public string ModifiedIn { get; set; }

        /// <summary>
        /// Gets or sets the song title. Usually the same as the file name
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// CCLI Song ID
        /// </summary>
        public string CcliID { get; set; }

        /// <summary>
        /// Copyright information
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// Release year
        /// </summary>
        public string ReleaseYear { get; set; }

        /// <summary>
        /// Comments
        /// </summary>
        public List<string> Comments { get; private set; }

        /// <summary>
        /// Verses
        /// </summary>
        public List<OpenLyricsSongVerse> Verses { get; private set; }

        public OpenLyricsSong()
        {
            Comments = new List<string>();
            Verses = new List<OpenLyricsSongVerse>();
        }
    }
}
