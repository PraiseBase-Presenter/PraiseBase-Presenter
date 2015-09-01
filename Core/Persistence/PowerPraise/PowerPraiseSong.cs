using System;
using System.Linq;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public class PowerPraiseSong : ISongFile
    {
        public PowerPraiseSong()
        {
            Parts = new ComparableOrderedList<Part>();
            Order = new ComparableOrderedList<Part>();
            CopyrightText = new ComparableList<string>();
            Formatting = new PowerPraiseSongFormatting();
        }

        public string GetTitle()
        {
            return Title;
        }

        /// <summary>
        ///     Returns the number of background images
        /// </summary>
        public int GetNumberOfBackgroundImages()
        {
            return
                Parts.SelectMany(t => t.Slides)
                    .Count(t1 => t1.Background != null && t1.Background.GetType() == typeof (ImageBackground));
        }

        #region Fields

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
        public ComparableOrderedList<Part> Parts { get; private set; }

        /// <summary>
        ///     Song text order
        /// </summary>
        public ComparableOrderedList<Part> Order { get; private set; }

        /// <summary>
        ///     Copyright text
        /// </summary>
        public ComparableList<string> CopyrightText { get; private set; }

        /// <summary>
        ///     Source text
        /// </summary>
        public string SourceText { get; set; }

        /// <summary>
        ///     Formatting (Fonts, Colors, Margins, Effects, ...)
        /// </summary>
        public PowerPraiseSongFormatting Formatting { get; set; }

        #endregion

        #region Equality members

        protected bool Equals(PowerPraiseSong other)
        {
            return string.Equals(Title, other.Title) && string.Equals(Category, other.Category) &&
                   string.Equals(Language, other.Language) && Equals(Parts, other.Parts) && Equals(Order, other.Order) &&
                   Equals(CopyrightText, other.CopyrightText) && string.Equals(SourceText, other.SourceText) &&
                   Formatting.Equals(other.Formatting);
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
                hashCode = (hashCode*397) ^ (SourceText != null ? SourceText.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Formatting.GetHashCode();
                return hashCode;
            }
        }

        #endregion

        #region Object definitions

        public class Part : ICloneable
        {
            public Part()
            {
                Slides = new ComparableOrderedList<Slide>();
            }

            /// <summary>
            ///     Caption
            /// </summary>
            public string Caption { get; set; }

            /// <summary>
            ///     Slides
            /// </summary>
            public ComparableOrderedList<Slide> Slides { get; private set; }

            public object Clone()
            {
                var p = new Part
                {
                    Caption = Caption
                };
                foreach (var s in Slides)
                {
                    p.Slides.Add((Slide) s.Clone());
                }
                return p;
            }

            /// <summary>
            ///     Duplicates a slide and cuts it's text in half,
            ///     assigning the first part to the original slide
            ///     and the second part to the copy
            /// </summary>
            /// <param name="slideId">The slide index</param>
            public void SplitSlide(int slideId)
            {
                var sld = (Slide) Slides[slideId].Clone();

                var totl = sld.Lines.Count;
                var rem = totl/2;
                Slides[slideId].Lines.RemoveRange(0, rem);
                sld.Lines.RemoveRange(rem, totl - rem);

                totl = sld.Translation.Count;
                rem = totl/2;
                Slides[slideId].Translation.RemoveRange(0, rem);
                sld.Translation.RemoveRange(rem, totl - rem);

                Slides.Insert(slideId, sld);
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
                    return ((Caption != null ? Caption.GetHashCode() : 0)*397) ^
                           (Slides != null ? Slides.GetHashCode() : 0);
                }
            }

            #endregion
        }

        public class Slide : ICloneable
        {
            public Slide()
            {
                Lines = new ComparableList<string>();
                Translation = new ComparableList<string>();
            }

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

            public object Clone()
            {
                var s = new Slide
                {
                    MainSize = MainSize,
                    Background = Background
                };
                s.Lines.AddRange(Lines);
                s.Translation.AddRange(Translation);
                return s;
            }

            #region Equality members

            protected bool Equals(Slide other)
            {
                return MainSize == other.MainSize && Equals(Background, other.Background) && Equals(Lines, other.Lines) &&
                       Equals(Translation, other.Translation);
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

        #endregion
    }
}