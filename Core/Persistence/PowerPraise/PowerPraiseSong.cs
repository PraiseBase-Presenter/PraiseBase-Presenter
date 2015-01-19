using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PraiseBase.Presenter.Model;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public class PowerPraiseSong : ISongFile
    {
        /// <summary>
        /// Font formatting (Font, Color, Outline, Shadow)
        /// </summary>
        public struct FontFormatting
        {
            /// <summary>
            /// Text font
            /// </summary>
            public Font Font { get; set; }

            /// <summary>
            /// Text color
            /// </summary>
            public Color Color { get; set; }

            /// <summary>
            /// Outline width (percent)
            /// </summary>
            public int OutlineWidth { get; set; }

            /// <summary>
            /// Shadow distance (percent)
            /// </summary>
            public int ShadowDistance { get; set; }
        }

        /// <summary>
        /// Outline formatting
        /// </summary>
        public struct OutlineFormatting
        {
            /// <summary>
            /// Enabled
            /// </summary>
            public Boolean Enabled { get; set; }

            /// <summary>
            /// Color
            /// </summary>
            public Color Color { get; set; }
        }

        /// <summary>
        /// Shadow formatting
        /// </summary>
        public struct ShadowFormatting
        {
            /// <summary>
            /// Enabled
            /// </summary>
            public Boolean Enabled { get; set; }

            /// <summary>
            /// Color
            /// </summary>
            public Color Color { get; set; }

            /// <summary>
            /// Direction (0-359)
            /// </summary>
            public int Direction { get; set; }
        }

        /// <summary>
        /// Borders
        /// </summary>
        public struct TextBorders
        {
            /// <summary>
            /// Distance of text to left
            /// </summary>
            public int TextLeft { get; set; }

            /// <summary>
            /// Distance of text to top
            /// </summary>
            public int TextTop { get; set; }

            /// <summary>
            /// Distance of text to right
            /// </summary>
            public int TextRight { get; set; }

            /// <summary>
            /// Distance of text to bottom
            /// </summary>
            public int TextBottom { get; set; }

            /// <summary>
            /// Distance of copyright text to bottom
            /// </summary>
            public int CopyrightBottom { get; set; }

            /// <summary>
            /// Distance of source text to top
            /// </summary>
            public int SourceTop { get; set; }

            /// <summary>
            /// Distance of source text to right
            /// </summary>
            public int SourceRight { get; set; }
        }

        public enum CopyrightPosition
        {
            FirstSlide,
            LastSlide,
            None
        }

        public enum TranslationPosition
        {
            Inline,
            Block
        }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Language of the main text
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Song text parts
        /// </summary>
        public List<PowerPraiseSongPart> Parts { get; private set; }

        /// <summary>
        /// Song text order
        /// </summary>
        public List<PowerPraiseSongPart> Order { get; private set; }

        /// <summary>
        /// Copyright text
        /// </summary>
        public List<string> CopyrightText { get; private set; }

        /// <summary>
        /// Position of the copyright text
        /// </summary>
        public CopyrightPosition CopyrightTextPosition { get; set; }

        /// <summary>
        /// Source text
        /// </summary>
        public string SourceText { get; set; }

        /// <summary>
        /// Set to true if the source text should be displayed
        /// </summary>
        public bool SourceTextEnabled { get; set; }
        
        /// <summary>
        /// Font, color, outline and shadow of the main text
        /// </summary>
        public FontFormatting MainTextFontFormatting { get; set; }

        /// <summary>
        /// Font, color, outline and shadow of the tanslation text
        /// </summary>
        public FontFormatting TranslationTextFontFormatting { get; set; }

        /// <summary>
        /// Font, color, outline and shadow of the copyright text
        /// </summary>
        public FontFormatting CopyrightTextFontFormatting { get; set; }

        /// <summary>
        /// Font, color, outline and shadow of the source text
        /// </summary>
        public FontFormatting SourceTextFontFormatting { get; set; }

        /// <summary>
        /// True of the text should be outlined
        /// </summary>
        public OutlineFormatting TextOutlineFormatting { get; set; }

        /// <summary>
        /// True if the text should have a shadow
        /// </summary>
        public ShadowFormatting TextShadowFormatting { get; set; }
        
        /// <summary>
        /// Background image paths (relative)
        /// </summary>
        public List<string> BackgroundImages { get; private set; }

        /// <summary>
        /// Main text line spacing
        /// </summary>
        public int MainLineSpacing { get; set; }

        /// <summary>
        /// Translation text line spacing
        /// </summary>
        public int TranslationLineSpacing { get; set; }

        /// <summary>
        /// Text orientation
        /// </summary>
        public TextOrientation TextOrientation { get; set; }

        /// <summary>
        /// Position of the translation
        /// </summary>
        public TranslationPosition TranslationTextPosition { get; set; }

        /// <summary>
        /// Borders
        /// </summary>
        public TextBorders Borders { get; set; }

        public PowerPraiseSong()
        {
            Parts = new List<PowerPraiseSongPart>();
            Order = new List<PowerPraiseSongPart>();
            CopyrightText = new List<string>();
            BackgroundImages = new List<string>();
        }
    }
}
