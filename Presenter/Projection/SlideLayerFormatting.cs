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
        /// True of the text should be outlined
        /// </summary>
        public bool OutlineEnabled { get; set; }

        /// <summary>
        /// True if the text should have a shadow
        /// </summary>
        public bool ShadowEnabled { get; set; }

        /// <summary>
        /// If true, font size will be scaled down if the text does not fit on the slide
        /// </summary>
        public Boolean ScaleFontSize { get; set; }

        /// <summary>
        /// Gets or sets the text font and color for the main text
        /// </summary>
        public TextFormatting MainText { get; set; }

        /// <summary>
        /// Gets or sets the font of tanslation text
        /// </summary>
        public TextFormatting SubText { get; set; }

        /// <summary>
        /// Text orientation
        /// </summary>
        public TextOrientation TextOrientation { get; set; }

        /// <summary>
        /// Vertical text padding
        /// </summary>
        public int VerticalTextPadding { get; set; }

        /// <summary>
        /// Horizontal text padding
        /// </summary>
        public int HorizontalTextPadding { get; set; }

        /// <summary>
        /// Gets or sets the font for the source text
        /// </summary>
        public TextFormatting HeaderText { get; set; }

        /// <summary>
        /// Text orientation
        /// </summary>
        public HorizontalOrientation HeaderTextOrientation { get; set; }

        /// <summary>
        /// Vertical header padding
        /// </summary>
        public int VerticalHeaderPadding { get; set; }

        /// <summary>
        /// Horizontal header padding
        /// </summary>
        public int HorizontalHeaderPadding { get; set; }

        /// <summary>
        /// Gets or sets the font for the copyright text
        /// </summary>
        public TextFormatting FooterText { get; set; }

        /// <summary>
        /// Text orientation
        /// </summary>
        public HorizontalOrientation FooterTextOrientation { get; set; }
       
        /// <summary>
        /// Vertical footer padding
        /// </summary>
        public int VerticalFooterPadding { get; set; }

        /// <summary>
        /// Horizontal footer padding 
        /// </summary>
        public int HorizontalFooterPadding { get; set; }
    }
}
