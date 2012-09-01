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
using System.Windows.Forms;

namespace Pbp
{
    /// <summary>
    /// Keeps and manages all song related data loaded form an xml file
    ///
    /// Author: Nicolas Perrenoud, nicu_at_lavine.ch
    /// </summary>
    public class Song
    {
        #region Fields

        /// <summary>
        /// Unique identifier of this song
        /// </summary>
        public Guid GUID { get; protected set; }

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
        /// Copyright information
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// Gets or sets a list of tags (like categories) which describe the type of the song
        /// </summary>
        public TagList Tags { get; set; }

        /// <summary>
        /// Gets or sets a user defined comment for quality assurance information or presentation issues
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets the whole songtext improved for full-text search
        /// </summary>
        public string SearchText { get; protected set; }

        /// <summary>
        /// Gets or sets the text font
        /// </summary>
        public Font TextFont { get; set; }

        /// <summary>
        /// Gets or sets the text color
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// Gets or sets the font of tanslation text
        /// </summary>
        public Font TranslationFont { get; set; }

        /// <summary>
        /// Gets or sets the color of translation text
        /// </summary>
        public Color TranslationColor { get; set; }

        /// <summary>
        /// Gets or sets the additional height between lines
        /// </summary>
        public int TextLineSpacing { get; set; }

        /// <summary>
        /// Gets or sets the additional height between a line and its translation
        /// </summary>
        public int TranslationLineSpacing { get; set; }

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
        /// Default horizontal text aligning
        /// </summary>
        public SongTextHorizontalAlign DefaultHorizAlign { get; set; }

        /// <summary>
        /// Default vertical text aligning
        /// </summary>
        public SongTextVerticalAlign DefaultVertAlign { get; set; }

        /// <summary>
        /// Quality assurance indicators
        /// </summary>
        public List<QualityAssuranceIndicators> QualityIssues { get; set; }

        #endregion Fields

        #region Enums

        #region SongTextHorizontalAlign enum

        /// <summary>
        /// Horizontal aligning of slide text
        /// </summary>
        public enum SongTextHorizontalAlign
        {
            /// <summary>
            /// Text is aligned horizontally to the left
            /// </summary>
            Left,

            /// <summary>
            /// Text is horizontally centered
            /// </summary>
            Center,

            /// <summary>
            /// Text is aligned horizontally to the right
            /// </summary>
            Right
        }

        #endregion SongTextHorizontalAlign enum

        #region SongTextVerticalAlign enum

        /// <summary>
        /// Vertical aligning of slide text
        /// </summary>
        public enum SongTextVerticalAlign
        {
            /// <summary>
            /// Text is aligned vertically to the top of the page
            /// </summary>
            Top,

            /// <summary>
            /// Text is aligned to the center
            /// </summary>
            Center,

            /// <summary>
            /// Text is aligned vertically to the bottom of the page
            /// </summary>
            Bottom
        }

        #endregion SongTextVerticalAlign enum

        #region TextAlign enum

        public enum TextAlign
        {
            TopLeft,
            TopCenter,
            TopRight,
            MittleLeft,
            MiddleCenter,
            MiddleRight,
            BottomLeft,
            BottomCenter,
            BottomRight
        }

        #endregion TextAlign enum

        #endregion Enums

        /// <summary>
        /// The song constructor
        /// </summary>
        public Song()
        {
            GUID = Guid.NewGuid();

            Tags = new TagList();
            DefaultHorizAlign = SongTextHorizontalAlign.Center;
            DefaultVertAlign = SongTextVerticalAlign.Center;
            Slides = new SongSlideList();
            Parts = new SongPartList();
            RelativeImagePaths = new List<string>();
            SearchText = String.Empty;

            Comment = String.Empty;

            QualityIssues = new List<QualityAssuranceIndicators>();
        }

        public void updateSearchText()
        {
            string _text = String.Empty;
            foreach (SongPart prt in Parts)
            {
                foreach (SongSlide sld in prt.Slides)
                {
                    foreach (string ln in sld.Lines)
                    {
                        _text += ln;
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

        public string getImage(int nr)
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
        public void setQA(QualityAssuranceIndicators quai)
        {
            QualityIssues.Add(quai);
        }

        /// <summary>
        /// Removes a specific quality assurance indicator
        /// </summary>
        /// <param name="quai">The indicator to be removed</param>
        public void remQA(QualityAssuranceIndicators quai)
        {
            QualityIssues.Remove(quai);
        }

        /// <summary>
        /// Returns if a specific quality assurance indicator is set
        /// </summary>
        /// <param name="quai">The desired indicator</param>
        public bool getQA(QualityAssuranceIndicators quai)
        {
            return QualityIssues.IndexOf(quai) >= 0;
        }

        /// <summary>
        /// Indicates îf the song has quality issues
        /// </summary>
        /// <returns></returns>
        public bool hasQA()
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
                       ^ QualityIssues.GetHashCode()
                       ^ TextFont.GetHashCode()
                       ^ TextColor.GetHashCode()
                       ^ TranslationColor.GetHashCode()
                       ^ TranslationFont.GetHashCode()
                       ^ Language.GetHashCode()
                       ^ Comment.GetHashCode()
                       ^ TextLineSpacing.GetHashCode()
                       ^ Tags.GetHashCode()
                       ^ Parts.GetHashCode();

            return code;
        }
    }
}