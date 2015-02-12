using PraiseBase.Presenter.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PraiseBase.Presenter.Projection
{
    public struct SlideLayerFormatting
    {
        /// <summary>
        /// Gets or sets the text font and color for the main text
        /// </summary>
        public TextFormatting MainText { get; set; }

        /// <summary>
        /// Gets or sets the font of tanslation text
        /// </summary>
        public TextFormatting SubText { get; set; }

        /// <summary>
        /// Gets or sets the font for the copyright text
        /// </summary>
        public TextFormatting FooterText { get; set; }

        /// <summary>
        /// Gets or sets the font for the source text
        /// </summary>
        public TextFormatting HeaderText { get; set; }

        public TextOrientation TextOrientation;

        /// <summary>
        /// True of the text should be outlined
        /// </summary>
        public bool TextOutlineEnabled { get; set; }

        /// <summary>
        /// True if the text should have a shadow
        /// </summary>
        public bool TextShadowEnabled { get; set; }

        public Boolean ScaleFontSize;

        public int VerticalTextPadding { get; set; }

        public int HorizontalTextPadding { get; set; }
        
        public int VerticalHeaderPadding { get; set; }

        public int HorizontalHeaderPadding { get; set; }
        
        public int VerticalFooterPadding { get; set; }

        public int HorizontalFooterPadding { get; set; }
    }
}
