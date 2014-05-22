/*
 *   PraiseBase Presenter
 *   The open source lyrics and image projection software for churches
 *
 *   http://code.google.com/p/praisebasepresenter
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
 *   Author:
 *      Nicolas Perrenoud <nicu_at_lavine.ch>
 *   Co-authors:
 *      ...
 *
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;

namespace Pbp.Model.Song
{
    /// <summary>
    /// Keeps and manages all song related data loaded form an xml file
    ///
    /// Author: Nicolas Perrenoud, nicu_at_lavine.ch
    /// </summary>
    [Serializable()]
    public class Song : ISerializable
    {
        #region Fields

        /// <summary>
        /// Unique identifier of this song
        /// </summary>
        public Guid GUID { get; set; }

        /// <summary>
        /// Timestamp when the song has been last modified
        /// </summary>
        public string ModifiedTimestamp { get; set; }

        /// <summary>
        /// Application the song was created in
        /// </summary>
        public string CreatedIn { get; set; }

        /// <summary>
        /// Application the song was modified in
        /// </summary>
        public string ModifiedIn { get; set; }

        /// <summary>
        /// Gets or sets the song title. Usually the same as the file name
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the main language of the song
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// CCLI Song ID
        /// </summary>
        public string CcliID { get; set; }

        /// <summary>
        /// Should the CCLI ID be readonly?
        /// </summary>
        public bool CCliIDReadonly { get; set; }

        /// <summary>
        /// Copyright information
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// Copyright position (PowerPraise)
        /// </summary>
        public string CopyrightPosition { get; set; }
        
        /// <summary>
        /// Source position (PowerPraise)
        /// </summary>
        public string SourcePosition { get; set; }

        /// <summary>
        /// Release year
        /// </summary>
        public string ReleaseYear { get; set; }

        /// <summary>
        /// Authors of the song
        /// </summary>
        public List<SongAuthor> Author { get; set; }

        /// <summary>
        /// All authors as semicolon-separated string
        /// </summary>
        public String AuthorString { 
            get 
            {
                string autstr = string.Empty;
                foreach (var aut in Author)
                {
                    if (autstr != string.Empty)
                    {
                        autstr += ";";
                    }
                    autstr += aut.Name;
                }
                return autstr;
            } 
            set
            {
                int i = 0;
                foreach (String s in value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    SongAuthor author = new SongAuthor();
                    author.Name = s.Trim();
                    author.Type = (i++ == 0) ? SongAuthorType.words : SongAuthorType.music;
                    Author.Add(author);
                }
            } 
        }

        /// <summary>
        /// Admin
        /// </summary>
        public string RightsManagement { get; set; }

        /// <summary>
        /// Publisher
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Transposition
        /// </summary>
        public int Transposition { get; set; }

        /// <summary>
        /// Tempo
        /// </summary>
        public SongTempo Tempo  { get; set; }

        /// <summary>
        /// Variant
        /// </summary>
        public string Variant  { get; set; }
    
        /// <summary>
        /// Gets or sets a list of tags (like categories) which describe the type of the song
        /// </summary>
        public TagList Themes { get; set; }

        /// <summary>
        /// Gets or sets a user defined comment for quality assurance information or presentation issues
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Songbooks the song appears in
        /// </summary>
        public List<SongBook> SongBooks { get; set; }

        /// <summary>
        /// All songbooks as semicolon-separated string
        /// </summary>
        public String SongBooksString
        {
            get
            {
                string autstr = string.Empty;
                foreach (var aut in SongBooks)
                {
                    if (autstr != string.Empty)
                    {
                        autstr += ";";
                    }
                    autstr += aut.Name;
                }
                return autstr;
            }
            set
            {
                foreach (String s in value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    SongBook sb = new SongBook();
                    sb.Name= s.Trim();
                    SongBooks.Add(sb);
                }
            }
        }

        /// <summary>
        /// Gets the whole songtext improved for full-text search
        /// </summary>
        public string SearchText { get; protected set; }

        /// <summary>
        /// Gets or sets the list of all parts in the song
        /// </summary>
        public SongPartList Parts { get; set; }

        /// <summary>
        /// Gets or sets a sequence of part numbers indicating
        /// the real order in which the song is sung
        /// </summary>
        public List<int> PartSequence { get; set; }

        /// <summary>
        /// Gets a list of all slides. Used in the presenter song detail overview.
        /// </summary>
        public SongSlideList Slides { get; protected set; }

        /// <summary>
        /// Gets or sets the current slide index
        /// </summary>
        public int CurrentSlide { get; set; }

        /// <summary>
        /// List of the paths to all images
        /// </summary>
        public List<string> RelativeImagePaths { get; set; }

        /// <summary>
        /// Quality assurance indicators
        /// </summary>
        public List<SongQualityAssuranceIndicator> QualityIssues { get; set; }

        /// <summary>
        /// Gets or sets the text font and color for the main text
        /// </summary>
        public TextFormatting MainText { get; set; }

        /// <summary>
        /// Gets or sets the font of tanslation text
        /// </summary>
        public TextFormatting TranslationText { get; set; }

        /// <summary>
        /// Gets or sets the font for the copyright text
        /// </summary>
        public TextFormatting CopyrightText { get; set; }

        /// <summary>
        /// Gets or sets the font for the source text
        /// </summary>
        public TextFormatting SourceText { get; set; }

        /// <summary>
        /// Horizontal text orientation
        /// </summary>
        public TextOrientationHorizontal HorizontalTextOrientation { get; set; }

        /// <summary>
        /// Vertical text orientation
        /// </summary>
        public TextOrientationVertical VerticalTextOrientation { get; set; }

        /// <summary>
        /// True of the text should be outlined
        /// </summary>
        public bool TextOutlineEnabled { get; set; }

        /// <summary>
        /// True if the text should have a shadow
        /// </summary>
        public bool TextShadowEnabled { get; set; }

        /// <summary>
        /// Text borders (used by PowerPraise)
        /// </summary>
        public SongTextBorders TextBorders { get; set; }

        public bool HasTranslation
        {
            get
            {
                bool translated = false;
                foreach (SongSlide s in Slides)
                {
                    if (s.Translated)
                    {
                        translated = true;
                        break;
                    }

                }
                return translated;
            }
        }

        #endregion Fields

        /// <summary>
        /// The song constructor
        /// </summary>
        public Song()
        {
            Themes = new TagList();
            Slides = new SongSlideList();
            Parts = new SongPartList();
            RelativeImagePaths = new List<string>();
            SearchText = String.Empty;
            SongBooks = new List<SongBook>();
            Author = new List<SongAuthor>();
            Comment = String.Empty;
            QualityIssues = new List<SongQualityAssuranceIndicator>();
        }

        /// <summary>
        /// Updates the search text
        /// </summary>
        public void UpdateSearchText()
        {
            string _text = this.Title + " ";
            foreach (SongPart prt in Parts)
            {
                foreach (SongSlide sld in prt.Slides)
                {
                    foreach (string ln in sld.Lines)
                    {
                        _text += ln + " ";
                    }
                }
            }

            _text = _text.Trim().ToLower();
            _text = _text.Replace(",", String.Empty);
            _text = _text.Replace(".", String.Empty);
            _text = _text.Replace(";", String.Empty);
            _text = _text.Replace(Environment.NewLine, String.Empty);
            _text = _text.Replace("  ", " ");

            SearchText = _text;
        }

        /// <summary>
        /// Returns the path of the image at the specified index
        /// </summary>
        /// <param name="nr"></param>
        /// <returns></returns>
        public string GetImage(int nr)
        {
            try
            {
                if (nr < 1)
                {
                    return null;
                }
                if (RelativeImagePaths[nr - 1] == null)
                {
                    throw new Exception("Das Bild mit der Nummer " + nr + " existiert nicht!");
                }
                return RelativeImagePaths[nr - 1];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Sets a specific quality assurance indicator
        /// </summary>
        /// <param name="quai">The indicator to be added</param>
        public void SetQA(SongQualityAssuranceIndicator quai)
        {
            QualityIssues.Add(quai);
        }

        /// <summary>
        /// Removes a specific quality assurance indicator
        /// </summary>
        /// <param name="quai">The indicator to be removed</param>
        public void RemQA(SongQualityAssuranceIndicator quai)
        {
            QualityIssues.Remove(quai);
        }

        /// <summary>
        /// Returns if a specific quality assurance indicator is set
        /// </summary>
        /// <param name="quai">The desired indicator</param>
        public bool GetQA(SongQualityAssuranceIndicator quai)
        {
            return QualityIssues.IndexOf(quai) >= 0;
        }

        /// <summary>
        /// Indicates îf the song has quality issues
        /// </summary>
        /// <returns></returns>
        public bool HasQA()
        {
            return QualityIssues.Count > 0;
        }

        /// <summary>
        /// Returns a hashcode of the song, used for example in the
        /// editor to check if the file was changed
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int code = Title.GetHashCode()
                       ^ Parts.GetHashCode()
                       ^ QualityIssues.GetHashCode()
                       ^ MainText.GetHashCode()
                       ^ TranslationText.GetHashCode()
                       ^ CopyrightText.GetHashCode()
                       ^ SourceText.GetHashCode()
                       ^ Themes.GetHashCode();

            if (Language != null)
            {
                code ^= Language.GetHashCode();
            }
            if (Comment != null)
            {
                code ^= Comment.GetHashCode();
            }
            if (CcliID != null)
            {
                code ^= CcliID.GetHashCode();
            }
            if (Copyright != null)
            {
                code ^= Copyright.GetHashCode();
            }
            return code;
        }

        /// <summary>
        /// Serialize song object
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Parts", this.Parts);
            info.AddValue("Title", this.Title);
            info.AddValue("QualityIssues", this.QualityIssues);
            info.AddValue("MainText", this.MainText.ToString());
            info.AddValue("TranslationText", this.TranslationText.ToString());
            info.AddValue("CopyrightText", this.CopyrightText.ToString());
            info.AddValue("SourceText", this.SourceText.ToString());
            info.AddValue("Language", this.Language);
            info.AddValue("Comment", this.Comment);
            info.AddValue("Tags", this.Themes);
            info.AddValue("CcliID", this.CcliID);
            info.AddValue("Copyright", this.Copyright);
        }

    }
}