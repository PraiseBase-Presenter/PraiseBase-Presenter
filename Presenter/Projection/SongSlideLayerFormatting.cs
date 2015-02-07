using PraiseBase.Presenter.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PraiseBase.Presenter.Projection
{
    public struct SongSlideLayerFormatting
    {
        /// <summary>
        /// Gets or sets the text font and color for the main text
        /// </summary>
        public TextFormatting MainText { get; set; }

        /// <summary>
        /// Gets or sets the font of tanslation text
        /// </summary>
        public TextFormatting TranslationText { get; set; }

        /// <summary>
        /// Gets or sets the font for the copyright text
        /// </summary>
        public TextFormatting CopyrightText { get; set; }

        /// <summary>
        /// Gets or sets the font for the source text
        /// </summary>
        public TextFormatting SourceText { get; set; }

        public TextOrientation TextOrientation;

        public SongTextBorders TextBorders;

        public Boolean ScaleFontSize;
    }
}
