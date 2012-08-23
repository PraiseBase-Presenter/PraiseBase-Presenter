using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp
{
    /// <summary>
    /// Different flags for indicating problems with the song 
    /// whichs needs to be revised
    /// </summary>
    public enum QualityAssuranceIndicators
    {
        /// <summary>
        /// Indicates wether spelling of the songtext is incorrect
        /// </summary>
        Spelling = 1,
        /// <summary>
        /// Indicates wether images are broken or incomplete
        /// </summary>
        Images = 2,
        /// <summary>
        /// Indicates wether the translation is missing or incomplete
        /// </summary>
        Translation = 4,
        /// <summary>
        /// Indicates wether the layout of the slides needs optimization
        /// </summary>
        Segmentation = 8
    }
}
