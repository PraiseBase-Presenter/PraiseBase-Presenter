using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public class ExtendedPowerPraiseSong : PowerPraiseSong
    {
        /// <summary>
        /// Gets or sets a user defined comment for quality assurance information or presentation issues
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Quality assurance indicators
        /// </summary>
        public List<SongQualityAssuranceIndicator> QualityIssues { get; set; }

        /// <summary>
        /// CCLI Song ID
        /// </summary>
        public string CcliID { get; set; }

        /// <summary>
        /// Authors of the song
        /// </summary>
        public List<SongAuthor> Author { get; set; }

        /// <summary>
        /// Admin
        /// </summary>
        public string RightsManagement { get; set; }

        /// <summary>
        /// Publisher
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Unique identifier of this song
        /// </summary>
        public Guid GUID { get; set; }

        public ExtendedPowerPraiseSong()
        {
            QualityIssues = new List<SongQualityAssuranceIndicator>();
            Author = new List<SongAuthor>();
        }
    }
}
