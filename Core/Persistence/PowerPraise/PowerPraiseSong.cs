using System;
using System.Collections.Generic;
using System.Drawing;
using PraiseBase.Presenter.Model;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public class PowerPraiseSong : ISongFile
    {
        public PowerPraiseSong()
        {
            Parts = new List<Part>();
            Order = new List<Part>();
            CopyrightText = new List<string>();
            BackgroundImages = new List<string>();
        }

        /// <summary>
        ///     Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        ///     Language of the main text
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     Song text parts
        /// </summary>
        public List<Part> Parts { get; private set; }

        /// <summary>
        ///     Song text order
        /// </summary>
        public List<Part> Order { get; private set; }

        /// <summary>
        ///     Copyright text
        /// </summary>
        public List<string> CopyrightText { get; private set; }

        /// <summary>
        ///     Position of the copyright text
        /// </summary>
        public CopyrightPosition CopyrightTextPosition { get; set; }

        /// <summary>
        ///     Source text
        /// </summary>
        public string SourceText { get; set; }

        /// <summary>
        ///     Set to true if the source text should be displayed
        /// </summary>
        public bool SourceTextEnabled { get; set; }

        /// <summary>
        ///     Font, color, outline and shadow of the main text
        /// </summary>
        public FontFormatting MainTextFontFormatting { get; set; }

        /// <summary>
        ///     Font, color, outline and shadow of the tanslation text
        /// </summary>
        public FontFormatting TranslationTextFontFormatting { get; set; }

        /// <summary>
        ///     Font, color, outline and shadow of the copyright text
        /// </summary>
        public FontFormatting CopyrightTextFontFormatting { get; set; }

        /// <summary>
        ///     Font, color, outline and shadow of the source text
        /// </summary>
        public FontFormatting SourceTextFontFormatting { get; set; }

        /// <summary>
        ///     True of the text should be outlined
        /// </summary>
        public OutlineFormatting TextOutlineFormatting { get; set; }

        /// <summary>
        ///     True if the text should have a shadow
        /// </summary>
        public ShadowFormatting TextShadowFormatting { get; set; }

        /// <summary>
        ///     Background image paths (relative)
        /// </summary>
        public List<string> BackgroundImages { get; private set; }

        /// <summary>
        ///     Main text line spacing
        /// </summary>
        public int MainLineSpacing { get; set; }

        /// <summary>
        ///     Translation text line spacing
        /// </summary>
        public int TranslationLineSpacing { get; set; }

        /// <summary>
        ///     Text orientation
        /// </summary>
        public TextOrientation TextOrientation { get; set; }

        /// <summary>
        ///     Position of the translation
        /// </summary>
        public TranslationPosition TranslationTextPosition { get; set; }

        /// <summary>
        ///     Borders
        /// </summary>
        public TextBorders Borders { get; set; }

        public enum CopyrightPosition
        {
            FirstSlide,
            LastSlide,
            None
        }

        public class Part
        {
            public Part()
            {
                Slides = new List<Slide>();
            }

            /// <summary>
            ///     Caption
            /// </summary>
            public string Caption { get; set; }

            /// <summary>
            ///     Slides
            /// </summary>
            public List<Slide> Slides { get; private set; }
        }

        public class Slide
        {
            public Slide()
            {
                Lines = new List<string>();
                Translation = new List<string>();
            }

            /// <summary>
            ///     Font size of the main text
            /// </summary>
            public int MainSize { get; set; }

            /// <summary>
            ///     Background number (starting from 0)
            /// </summary>
            public int BackgroundNr { get; set; }

            /// <summary>
            ///     Song text lines
            /// </summary>
            public List<string> Lines { get; private set; }

            /// <summary>
            ///     Translation text lines
            /// </summary>
            public List<string> Translation { get; private set; }
        }

        /// <summary>
        ///     Font formatting (Font, Color, Outline, Shadow)
        /// </summary>
        public struct FontFormatting
        {
            /// <summary>
            ///     Text font
            /// </summary>
            public Font Font { get; set; }

            /// <summary>
            ///     Text color
            /// </summary>
            public Color Color { get; set; }

            /// <summary>
            ///     Outline width (percent)
            /// </summary>
            public int OutlineWidth { get; set; }

            /// <summary>
            ///     Shadow distance (percent)
            /// </summary>
            public int ShadowDistance { get; set; }

            #region Equality members

            public bool Equals(FontFormatting other)
            {
                return Equals(Font, other.Font) && Color.Equals(other.Color) && OutlineWidth == other.OutlineWidth && ShadowDistance == other.ShadowDistance;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is FontFormatting && Equals((FontFormatting) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (Font != null ? Font.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ Color.GetHashCode();
                    hashCode = (hashCode*397) ^ OutlineWidth;
                    hashCode = (hashCode*397) ^ ShadowDistance;
                    return hashCode;
                }
            }

            #endregion
        }

        /// <summary>
        ///     Outline formatting
        /// </summary>
        public struct OutlineFormatting
        {
            /// <summary>
            ///     Enabled
            /// </summary>
            public Boolean Enabled { get; set; }

            /// <summary>
            ///     Color
            /// </summary>
            public Color Color { get; set; }

            #region Equality members

            public bool Equals(OutlineFormatting other)
            {
                return Enabled.Equals(other.Enabled) && Color.Equals(other.Color);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is OutlineFormatting && Equals((OutlineFormatting) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (Enabled.GetHashCode()*397) ^ Color.GetHashCode();
                }
            }

            #endregion
        }

        /// <summary>
        ///     Shadow formatting
        /// </summary>
        public struct ShadowFormatting
        {
            /// <summary>
            ///     Enabled
            /// </summary>
            public Boolean Enabled { get; set; }

            /// <summary>
            ///     Color
            /// </summary>
            public Color Color { get; set; }

            /// <summary>
            ///     Direction (0-359)
            /// </summary>
            public int Direction { get; set; }

            #region Equality members

            public bool Equals(ShadowFormatting other)
            {
                return Enabled.Equals(other.Enabled) && Direction == other.Direction && Color.Equals(other.Color);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is ShadowFormatting && Equals((ShadowFormatting) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = Enabled.GetHashCode();
                    hashCode = (hashCode*397) ^ Direction;
                    hashCode = (hashCode*397) ^ Color.GetHashCode();
                    return hashCode;
                }
            }

            #endregion
        }

        /// <summary>
        ///     Borders
        /// </summary>
        public struct TextBorders
        {
            /// <summary>
            ///     Distance of text to left
            /// </summary>
            public int TextLeft { get; set; }

            /// <summary>
            ///     Distance of text to top
            /// </summary>
            public int TextTop { get; set; }

            /// <summary>
            ///     Distance of text to right
            /// </summary>
            public int TextRight { get; set; }

            /// <summary>
            ///     Distance of text to bottom
            /// </summary>
            public int TextBottom { get; set; }

            /// <summary>
            ///     Distance of copyright text to bottom
            /// </summary>
            public int CopyrightBottom { get; set; }

            /// <summary>
            ///     Distance of source text to top
            /// </summary>
            public int SourceTop { get; set; }

            /// <summary>
            ///     Distance of source text to right
            /// </summary>
            public int SourceRight { get; set; }

            #region Equality members

            public bool Equals(TextBorders other)
            {
                return TextLeft == other.TextLeft && TextTop == other.TextTop && TextBottom == other.TextBottom && CopyrightBottom == other.CopyrightBottom && SourceTop == other.SourceTop && SourceRight == other.SourceRight && TextRight == other.TextRight;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is TextBorders && Equals((TextBorders) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = TextLeft;
                    hashCode = (hashCode*397) ^ TextTop;
                    hashCode = (hashCode*397) ^ TextBottom;
                    hashCode = (hashCode*397) ^ CopyrightBottom;
                    hashCode = (hashCode*397) ^ SourceTop;
                    hashCode = (hashCode*397) ^ SourceRight;
                    hashCode = (hashCode*397) ^ TextRight;
                    return hashCode;
                }
            }

            #endregion
        }
    }
}