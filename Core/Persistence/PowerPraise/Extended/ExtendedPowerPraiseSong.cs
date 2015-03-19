using System;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise.Extended
{
    public class ExtendedPowerPraiseSong : PowerPraiseSong
    {
        public ExtendedPowerPraiseSong()
        {
            QualityIssues = new QualityIssues();
            Author = new SongAuthors();
        }

        /// <summary>
        ///     Gets or sets a user defined comment for quality assurance information or presentation issues
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        ///     Quality assurance indicators
        /// </summary>
        public QualityIssues QualityIssues { get; set; }

        /// <summary>
        ///     CCLI Song ID
        /// </summary>
        public string CcliIdentifier { get; set; }

        /// <summary>
        ///     Authors of the song
        /// </summary>
        public SongAuthors Author { get; set; }

        /// <summary>
        ///     Admin
        /// </summary>
        public string RightsManagement { get; set; }

        /// <summary>
        ///     Publisher
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        ///     Unique identifier of this song
        /// </summary>
        public Guid Guid { get; set; }
    }
}