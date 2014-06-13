using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pbp.Model.Song.PowerPraise
{
    public class PowerPraiseSong
    {
        public struct TextFormatting
        {
            public Font Font { get; set; }
            public Color Color { get; set; }
            public int OutlineWidth { get; set; }
            public int ShadowDistance { get; set; }
        }

        public struct TextOutline
        {
            public Boolean Enabled { get; set; }
            public Color Color { get; set; }
        }

        public struct TextShadow
        {
            public Boolean Enabled { get; set; }
            public Color Color { get; set; }
            public int Direction { get; set; }
        }

        public struct TextBorders
        {
            public int TextLeft { get; set; }
            public int TextTop { get; set; }
            public int TextRight { get; set; }
            public int TextBottom { get; set; }
            public int CopyrightBottom { get; set; }
            public int SourceTop { get; set; }
            public int SourceRight { get; set; }
        }

        public enum AnnotationTextPosition
        {
            FirstSlide,
            LastSlide,
            None
        }

        public enum TextDisplayMode
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
        public List<PowerPraiseSongTextPart> SongTextParts { get; private set; }

        /// <summary>
        /// Song text order
        /// </summary>
        public List<PowerPraiseSongTextPart> SongTextOrder { get; private set; }

        /// <summary>
        /// Copyright text
        /// </summary>
        public List<string> CopyrightText { get; private set; }

        /// <summary>
        /// Position of the copyright text
        /// </summary>
        public AnnotationTextPosition CopyrightTextPosition { get; set; }

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
        public TextFormatting MainTextFormatting { get; set; }

        /// <summary>
        /// Font, color, outline and shadow of the tanslation text
        /// </summary>
        public TextFormatting TranslationTextFormatting { get; set; }

        /// <summary>
        /// Font, color, outline and shadow of the copyright text
        /// </summary>
        public TextFormatting CopyrightTextFormatting { get; set; }

        /// <summary>
        /// Font, color, outline and shadow of the source text
        /// </summary>
        public TextFormatting SourceTextFormatting { get; set; }

        /// <summary>
        /// True of the text should be outlined
        /// </summary>
        public TextOutline TextOutlineFormatting { get; set; }

        /// <summary>
        /// True if the text should have a shadow
        /// </summary>
        public TextShadow TextShadowFormatting { get; set; }
        
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
        public TextDisplayMode TranslationPosition { get; set; }

        /// <summary>
        /// Borders
        /// </summary>
        public TextBorders SongTextBorders { get; set; }

        public PowerPraiseSong()
        {
            SongTextParts = new List<PowerPraiseSongTextPart>();
            SongTextOrder = new List<PowerPraiseSongTextPart>();
            CopyrightText = new List<string>();
            BackgroundImages = new List<string>();
        }
    }
}
