using System;
using PraiseBase.Presenter.Model;

namespace PraiseBase.Presenter.Persistence.CCLI
{
    public class SongSelectFile : ISongFile
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public SongSelectFile()
        {
            Themes = new ComparableList<string>();
            Verses = new ComparableOrderedList<Verse>();
        }

        public string GetTitle()
        {
            return Title;
        }

        #region Object definitions

        public class Verse : ICloneable
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            public Verse()
            {
                Lines = new ComparableList<string>();
            }

            /// <summary>
            ///     Caption
            /// </summary>
            public string Caption { get; set; }

            /// <summary>
            ///     Lyrics
            /// </summary>
            public ComparableList<string> Lines { get; private set; }

            public object Clone()
            {
                var v = new Verse
                {
                    Caption = Caption
                };
                v.Lines.AddRange(Lines);
                return v;
            }

            #region Equality members

            protected bool Equals(Verse other)
            {
                return string.Equals(Caption, other.Caption) && Equals(Lines, other.Lines);
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
                    return ((Caption != null ? Caption.GetHashCode() : 0)*397) ^
                           (Lines != null ? Lines.GetHashCode() : 0);
                }
            }

            #endregion
        }

        #endregion

        #region Fields

        /// <summary>
        ///     CCLI ID
        /// </summary>
        public string CcliIdentifier { get; set; }

        /// <summary>
        ///     Title of the song
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        ///     Copyright owner
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        ///     Rights Administrator
        /// </summary>
        public string Admin { get; set; }

        /// <summary>
        ///     Themes
        /// </summary>
        public ComparableList<string> Themes { get; private set; }

        /// <summary>
        ///     Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Verses
        /// </summary>
        public ComparableOrderedList<Verse> Verses { get; private set; }

        #endregion

        #region Equality members

        protected bool Equals(SongSelectFile other)
        {
            return string.Equals(CcliIdentifier, other.CcliIdentifier) && string.Equals(Title, other.Title) &&
                   string.Equals(Author, other.Author) && string.Equals(Copyright, other.Copyright) &&
                   string.Equals(Admin, other.Admin) && Equals(Themes, other.Themes) && string.Equals(Key, other.Key) &&
                   Equals(Verses, other.Verses);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SongSelectFile) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (CcliIdentifier != null ? CcliIdentifier.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Author != null ? Author.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Copyright != null ? Copyright.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Admin != null ? Admin.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Themes != null ? Themes.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Key != null ? Key.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Verses != null ? Verses.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion
    }
}