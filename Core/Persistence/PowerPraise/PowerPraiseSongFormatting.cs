using System;
using System.Drawing;
using PraiseBase.Presenter.Model;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public class PowerPraiseSongFormatting : ICloneable
    {
        /// <summary>
        ///     Font, color, outline and shadow of the main text
        /// </summary>
        public FontFormatting MainText { get; set; }

        /// <summary>
        ///     Font, color, outline and shadow of the tanslation text
        /// </summary>
        public FontFormatting TranslationText { get; set; }

        /// <summary>
        ///     Font, color, outline and shadow of the copyright text
        /// </summary>
        public FontFormatting CopyrightText { get; set; }

        /// <summary>
        ///     Font, color, outline and shadow of the source text
        /// </summary>
        public FontFormatting SourceText { get; set; }

        /// <summary>
        ///     True of the text should be outlined
        /// </summary>
        public OutlineFormatting Outline { get; set; }

        /// <summary>
        ///     True if the text should have a shadow
        /// </summary>
        public ShadowFormatting Shadow { get; set; }

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
        public TranslationPosition TranslationPosition { get; set; }

        /// <summary>
        ///     Borders
        /// </summary>
        public TextBorders Borders { get; set; }

        public object Clone()
        {
            return new PowerPraiseSongFormatting
            {
                MainText = MainText,
                TranslationText = TranslationText,
                CopyrightText = CopyrightText,
                SourceText = SourceText,
                Outline = Outline,
                Shadow = Shadow,
                TextOrientation = TextOrientation,
                TranslationPosition = TranslationPosition,
                MainLineSpacing = MainLineSpacing,
                TranslationLineSpacing = TranslationLineSpacing,
                Borders = Borders
            };
        }

        #region Equality members

        protected bool Equals(PowerPraiseSongFormatting other)
        {
            return MainText.Equals(other.MainText) && TranslationText.Equals(other.TranslationText) && CopyrightText.Equals(other.CopyrightText) && SourceText.Equals(other.SourceText) && Outline.Equals(other.Outline) && Shadow.Equals(other.Shadow) && MainLineSpacing == other.MainLineSpacing && TranslationLineSpacing == other.TranslationLineSpacing && Equals(TextOrientation, other.TextOrientation) && TranslationPosition == other.TranslationPosition && Borders.Equals(other.Borders);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PowerPraiseSongFormatting)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = MainText.GetHashCode();
                hashCode = (hashCode * 397) ^ TranslationText.GetHashCode();
                hashCode = (hashCode * 397) ^ CopyrightText.GetHashCode();
                hashCode = (hashCode * 397) ^ SourceText.GetHashCode();
                hashCode = (hashCode * 397) ^ Outline.GetHashCode();
                hashCode = (hashCode * 397) ^ Shadow.GetHashCode();
                hashCode = (hashCode * 397) ^ MainLineSpacing;
                hashCode = (hashCode * 397) ^ TranslationLineSpacing;
                hashCode = (hashCode * 397) ^ (TextOrientation != null ? TextOrientation.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)TranslationPosition;
                hashCode = (hashCode * 397) ^ Borders.GetHashCode();
                return hashCode;
            }
        }

        #endregion

        #region Object definitions

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
                return obj is FontFormatting && Equals((FontFormatting)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (Font != null ? Font.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ Color.GetHashCode();
                    hashCode = (hashCode * 397) ^ OutlineWidth;
                    hashCode = (hashCode * 397) ^ ShadowDistance;
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
                return obj is OutlineFormatting && Equals((OutlineFormatting)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (Enabled.GetHashCode() * 397) ^ Color.GetHashCode();
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
                return obj is ShadowFormatting && Equals((ShadowFormatting)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = Enabled.GetHashCode();
                    hashCode = (hashCode * 397) ^ Direction;
                    hashCode = (hashCode * 397) ^ Color.GetHashCode();
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
                return obj is TextBorders && Equals((TextBorders)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = TextLeft;
                    hashCode = (hashCode * 397) ^ TextTop;
                    hashCode = (hashCode * 397) ^ TextBottom;
                    hashCode = (hashCode * 397) ^ CopyrightBottom;
                    hashCode = (hashCode * 397) ^ SourceTop;
                    hashCode = (hashCode * 397) ^ SourceRight;
                    hashCode = (hashCode * 397) ^ TextRight;
                    return hashCode;
                }
            }

            #endregion
        }

        #endregion
    }
}
