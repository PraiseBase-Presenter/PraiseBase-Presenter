using System;
using PraiseBase.Presenter.Model;

namespace PraiseBase.Presenter.Persistence.OpenLyrics
{
    public class OpenLyricsSong : ISongFile
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public OpenLyricsSong()
        {
            Comments = new ComparableList<string>();
            Verses = new ComparableOrderedList<Verse>();
        }

        public string GetTitle()
        {
            return Title;
        }

        protected bool Equals(OpenLyricsSong other)
        {
            return string.Equals(ModifiedTimestamp, other.ModifiedTimestamp) &&
                   string.Equals(CreatedIn, other.CreatedIn) && string.Equals(ModifiedIn, other.ModifiedIn) &&
                   string.Equals(Title, other.Title) && string.Equals(CcliIdentifier, other.CcliIdentifier) &&
                   string.Equals(Copyright, other.Copyright) && string.Equals(ReleaseYear, other.ReleaseYear) &&
                   Equals(Comments, other.Comments) && Equals(Verses, other.Verses);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((OpenLyricsSong) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (ModifiedTimestamp != null ? ModifiedTimestamp.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CreatedIn != null ? CreatedIn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ModifiedIn != null ? ModifiedIn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CcliIdentifier != null ? CcliIdentifier.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Copyright != null ? Copyright.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ReleaseYear != null ? ReleaseYear.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Comments != null ? Comments.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Verses != null ? Verses.GetHashCode() : 0);
                return hashCode;
            }
        }

        public class Verse : ICloneable
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            public Verse()
            {
                Lines = new ComparableOrderedList<TextLines>();
            }

            /// <summary>
            ///     Caption
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            ///     Language
            /// </summary>
            public string Language { get; set; }

            /// <summary>
            ///     Transliteration
            /// </summary>
            public string Transliteration { get; set; }

            /// <summary>
            ///     Lyrics
            /// </summary>
            public ComparableOrderedList<TextLines> Lines { get; private set; }

            public object Clone()
            {
                var v = new Verse
                {
                    Name = Name,
                    Language = Language,
                    Transliteration = Transliteration
                };
                v.Lines.AddRange(Lines);
                return v;
            }

            protected bool Equals(Verse other)
            {
                return string.Equals(Name, other.Name) && string.Equals(Language, other.Language) &&
                       string.Equals(Transliteration, other.Transliteration) && Equals(Lines, other.Lines);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((Verse) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (Name != null ? Name.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ (Language != null ? Language.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ (Transliteration != null ? Transliteration.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ (Lines != null ? Lines.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public class TextLines : ICloneable
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            public TextLines()
            {
                Text = new ComparableList<string>();
            }

            /// <summary>
            ///     Part
            /// </summary>
            public string Part { get; set; }

            /// <summary>
            ///     Text
            /// </summary>
            public ComparableList<string> Text { get; private set; }

            public object Clone()
            {
                var l = new TextLines
                {
                    Part = Part
                };
                l.Text.AddRange(Text);
                return l;
            }

            protected bool Equals(TextLines other)
            {
                return string.Equals(Part, other.Part) && Equals(Text, other.Text);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((TextLines) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((Part != null ? Part.GetHashCode() : 0)*397) ^ (Text != null ? Text.GetHashCode() : 0);
                }
            }
        }

        #region Fields

        /// <summary>
        ///     Timestamp when the song has been last modified
        /// </summary>
        public string ModifiedTimestamp { get; set; }

        /// <summary>
        ///     Application the song was created in
        /// </summary>
        public string CreatedIn { get; set; }

        /// <summary>
        ///     Application the song was modified in
        /// </summary>
        public string ModifiedIn { get; set; }

        /// <summary>
        ///     Gets or sets the song title. Usually the same as the file name
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     CCLI Song ID
        /// </summary>
        public string CcliIdentifier { get; set; }

        /// <summary>
        ///     Copyright information
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        ///     Release year
        /// </summary>
        public string ReleaseYear { get; set; }

        /// <summary>
        ///     Comments
        /// </summary>
        public ComparableList<string> Comments { get; private set; }

        /// <summary>
        ///     Verses
        /// </summary>
        public ComparableOrderedList<Verse> Verses { get; private set; }

        #endregion
    }
}