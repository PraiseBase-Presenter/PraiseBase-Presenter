using System;
using System.Drawing;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public class PowerPraiseSong : ISongFile
    {
        #region General

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

        #endregion

        #region Song text and order

        /// <summary>
        ///     Song text parts
        /// </summary>
        public ComparableList<Part> Parts { get; private set; }

        /// <summary>
        ///     Song text order
        /// </summary>
        public ComparableList<Part> Order { get; private set; }

        #endregion

        #region Information

        /// <summary>
        ///     Copyright text
        /// </summary>
        public ComparableList<string> CopyrightText { get; private set; }

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

        #endregion

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

        public PowerPraiseSong()
        {
            Parts = new ComparableList<Part>();
            Order = new ComparableList<Part>();
            CopyrightText = new ComparableList<string>();
        }

        #region Equality members

        protected bool Equals(PowerPraiseSong other)
        {
            return string.Equals(Title, other.Title) && string.Equals(Category, other.Category) && string.Equals(Language, other.Language) && Equals(Parts, other.Parts) && Equals(Order, other.Order) && Equals(CopyrightText, other.CopyrightText) && CopyrightTextPosition == other.CopyrightTextPosition && string.Equals(SourceText, other.SourceText) && SourceTextEnabled.Equals(other.SourceTextEnabled) && MainTextFontFormatting.Equals(other.MainTextFontFormatting) && TranslationTextFontFormatting.Equals(other.TranslationTextFontFormatting) && CopyrightTextFontFormatting.Equals(other.CopyrightTextFontFormatting) && SourceTextFontFormatting.Equals(other.SourceTextFontFormatting) && TextOutlineFormatting.Equals(other.TextOutlineFormatting) && TextShadowFormatting.Equals(other.TextShadowFormatting) && MainLineSpacing == other.MainLineSpacing && TranslationLineSpacing == other.TranslationLineSpacing && Equals(TextOrientation, other.TextOrientation) && TranslationTextPosition == other.TranslationTextPosition && Borders.Equals(other.Borders);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PowerPraiseSong) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Category != null ? Category.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Language != null ? Language.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Parts != null ? Parts.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Order != null ? Order.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CopyrightText != null ? CopyrightText.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) CopyrightTextPosition;
                hashCode = (hashCode*397) ^ (SourceText != null ? SourceText.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ SourceTextEnabled.GetHashCode();
                hashCode = (hashCode*397) ^ MainTextFontFormatting.GetHashCode();
                hashCode = (hashCode*397) ^ TranslationTextFontFormatting.GetHashCode();
                hashCode = (hashCode*397) ^ CopyrightTextFontFormatting.GetHashCode();
                hashCode = (hashCode*397) ^ SourceTextFontFormatting.GetHashCode();
                hashCode = (hashCode*397) ^ TextOutlineFormatting.GetHashCode();
                hashCode = (hashCode*397) ^ TextShadowFormatting.GetHashCode();
                hashCode = (hashCode*397) ^ MainLineSpacing;
                hashCode = (hashCode*397) ^ TranslationLineSpacing;
                hashCode = (hashCode*397) ^ (TextOrientation != null ? TextOrientation.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) TranslationTextPosition;
                hashCode = (hashCode*397) ^ Borders.GetHashCode();
                return hashCode;
            }
        }

        #endregion

        public enum CopyrightPosition
        {
            FirstSlide,
            LastSlide,
            None
        }

        public class Part
        {
            /// <summary>
            ///     Caption
            /// </summary>
            public string Caption { get; set; }

            /// <summary>
            ///     Slides
            /// </summary>
            public ComparableList<Slide> Slides { get; private set; }

            public Part()
            {
                Slides = new ComparableList<Slide>();
            }

            #region Equality members

            protected bool Equals(Part other)
            {
                return string.Equals(Caption, other.Caption) && Equals(Slides, other.Slides);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((Part) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((Caption != null ? Caption.GetHashCode() : 0)*397) ^ (Slides != null ? Slides.GetHashCode() : 0);
                }
            }

            #endregion
        }

        public class Slide
        {
            /// <summary>
            ///     Font size of the main text
            /// </summary>
            public int MainSize { get; set; }

            /// <summary>
            ///     Background number (starting from 0)
            /// </summary>
            public IBackground Background { get; set; }

            /// <summary>
            ///     Song text lines
            /// </summary>
            public ComparableList<string> Lines { get; private set; }

            /// <summary>
            ///     Translation text lines
            /// </summary>
            public ComparableList<string> Translation { get; private set; }

            public Slide()
            {
                Lines = new ComparableList<string>();
                Translation = new ComparableList<string>();
            }

            #region Equality members

            protected bool Equals(Slide other)
            {
                return MainSize == other.MainSize && Equals(Background, other.Background) && Equals(Lines, other.Lines) && Equals(Translation, other.Translation);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((Slide) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = MainSize;
                    hashCode = (hashCode*397) ^ (Background != null ? Background.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ (Lines != null ? Lines.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ (Translation != null ? Translation.GetHashCode() : 0);
                    return hashCode;
                }
            }

            #endregion
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