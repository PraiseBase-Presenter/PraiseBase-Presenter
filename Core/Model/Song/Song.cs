/*
 *   PraiseBase Presenter
 *   The open source lyrics and image projection software for churches
 *
 *   http://praisebase.org
 *
 *   This program is free software; you can redistribute it and/or
 *   modify it under the terms of the GNU General Public License
 *   as published by the Free Software Foundation; either version 2
 *   of the License, or (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program; if not, write to the Free Software
 *   Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 */

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;

namespace PraiseBase.Presenter.Model.Song
{
    /// <summary>
    ///     Keeps and manages all song related data loaded form an xml file
    /// </summary>
    [Serializable]
    public class Song : ISerializable
    {
        /// <summary>
        ///     The song constructor
        /// </summary>
        public Song()
        {
            Themes = new TagList();
            Parts = new ComparableOrderedList<SongPart>();
            PartSequence = new ComparableOrderedList<SongPart>();
            SongBooks = new SongBooks();
            Authors = new SongAuthors();
            Comment = string.Empty;
            QualityIssues = new QualityIssues();
        }

        /// <summary>
        ///     Serialize song object
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Parts", Parts);
            info.AddValue("Title", Title);
            info.AddValue("QualityIssues", QualityIssues);
            info.AddValue("Language", Language);
            info.AddValue("Comment", Comment);
            info.AddValue("Themes", Themes);
            info.AddValue("CcliIdentifier", CcliIdentifier);
            info.AddValue("Copyright", Copyright);
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

        /// <summary>
        ///     Returns true if any slide has a translation
        /// </summary>
        /// <returns></returns>
        public bool HasTranslation()
        {
            return Parts.SelectMany(p => p.Slides).Any(s => s.Translated);
        }

        /// <summary>
        ///     Returns a hashcode of the song, used for example in the
        ///     editor to check if the file was changed
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "FunctionComplexityOverflow")]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (ModifiedTimestamp != null ? ModifiedTimestamp.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CreatedIn != null ? CreatedIn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ModifiedIn != null ? ModifiedIn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Language != null ? Language.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CcliIdentifier != null ? CcliIdentifier.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Copyright != null ? Copyright.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ReleaseYear != null ? ReleaseYear.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Authors != null ? Authors.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (RightsManagement != null ? RightsManagement.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Publisher != null ? Publisher.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Version != null ? Version.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Key != null ? Key.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Transposition;
                hashCode = (hashCode*397) ^ (Tempo != null ? Tempo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Variant != null ? Variant.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Themes != null ? Themes.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Comment != null ? Comment.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (SongBooks != null ? SongBooks.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Parts != null ? Parts.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (PartSequence != null ? PartSequence.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (QualityIssues != null ? QualityIssues.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(Song other)
        {
            return string.Equals(ModifiedTimestamp, other.ModifiedTimestamp) &&
                   string.Equals(CreatedIn, other.CreatedIn) && string.Equals(ModifiedIn, other.ModifiedIn) &&
                   string.Equals(Title, other.Title) && string.Equals(Language, other.Language) &&
                   string.Equals(CcliIdentifier, other.CcliIdentifier) &&
                   string.Equals(Copyright, other.Copyright) && string.Equals(ReleaseYear, other.ReleaseYear) &&
                   Equals(Authors, other.Authors) && string.Equals(RightsManagement, other.RightsManagement) &&
                   string.Equals(Publisher, other.Publisher) && string.Equals(Version, other.Version) &&
                   string.Equals(Key, other.Key) && Transposition == other.Transposition && Equals(Tempo, other.Tempo) &&
                   string.Equals(Variant, other.Variant) && Equals(Themes, other.Themes) &&
                   string.Equals(Comment, other.Comment) && Equals(SongBooks, other.SongBooks) &&
                   Equals(Parts, other.Parts) && Equals(PartSequence, other.PartSequence) &&
                   Equals(QualityIssues, other.QualityIssues);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Song) obj);
        }

        #region Fields

        /// <summary>
        ///     Unique identifier of this song
        /// </summary>
        public Guid Guid { get; set; }

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
        ///     Gets or sets the main language of the song
        /// </summary>
        public string Language { get; set; }

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
        ///     Authors of the song
        /// </summary>
        public SongAuthors Authors { get; set; }

        /// <summary>
        ///     Admin
        /// </summary>
        public string RightsManagement { get; set; }

        /// <summary>
        ///     Publisher
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        ///     Version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///     Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Transposition
        /// </summary>
        public int Transposition { get; set; }

        /// <summary>
        ///     Tempo
        /// </summary>
        public SongTempo Tempo { get; set; }

        /// <summary>
        ///     Variant
        /// </summary>
        public string Variant { get; set; }

        /// <summary>
        ///     Gets or sets a list of tags (like categories) which describe the type of the song
        /// </summary>
        public TagList Themes { get; set; }

        /// <summary>
        ///     Gets or sets a user defined comment for quality assurance information or presentation issues
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        ///     Songbooks the song appears in
        /// </summary>
        public SongBooks SongBooks { get; set; }

        /// <summary>
        ///     Gets or sets the list of all parts in the song
        /// </summary>
        public ComparableOrderedList<SongPart> Parts { get; set; }

        /// <summary>
        ///     Gets or sets a sequence of part numbers indicating
        ///     the real order in which the song is sung
        /// </summary>
        public ComparableOrderedList<SongPart> PartSequence { get; set; }

        /// <summary>
        ///     Quality assurance indicators
        /// </summary>
        public QualityIssues QualityIssues { get; set; }

        /// <summary>
        ///     Formatting
        /// </summary>
        public SongFormatting Formatting { get; set; }

        #endregion Fields
    }
}