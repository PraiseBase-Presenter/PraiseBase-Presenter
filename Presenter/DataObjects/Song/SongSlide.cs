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
using System.Linq;
using System.Runtime.Serialization;

namespace Pbp.Data.Song
{
    /// <summary>
    /// A single slide with songtext and/or a background image
    /// </summary>
    [Serializable()]
    public class SongSlide : ICloneable, ISerializable 
    {
        /// <summary>
        /// Pointer to the song object who owns this slide
        /// </summary>
        private readonly Song _ownerSong;

        /// <summary>
        /// All text lines of this slide
        /// </summary>
        public List<string> Lines { get; set; }

        /// <summary>
        /// All translation lines of this slide
        /// </summary>
        public List<string> Translation { get; set; }

        /// <summary>
        /// Number of the slide image. If set to -1, no image is used
        /// </summary>
        public int ImageNumber { get; set; }

        /// <summary>
        /// Size of the main text. This is used to maintain compatibility with PowerPraise
        /// </summary>
        public float TextSize { get; set; }

        /// <summary>
        /// Part name
        /// </summary>
        public string PartName { get; set; }

        /// <summary>
        /// Indicates wether this slide has a translation
        /// </summary>
        public bool Translated
        {
            get { return Translation.Count > 0 ? true : false; }
        }

        /// <summary>
        /// The font object of this slide
        /// </summary>
        public TextFormatting MainTextFormatting
        {
            get { return _ownerSong.MainText; }
        }

        /// <summary>
        /// The font object of the translation
        /// </summary>
        public TextFormatting TranslationTextFormatting
        {
            get { return _ownerSong.TranslationText; }
        }

        /// <summary>
        /// The font object of the translation
        /// </summary>
        public TextOrientationVertical VerticalTextOrientation
        {
            get { return _ownerSong.VerticalTextOrientation; }
        }

        /// <summary>
        /// The font object of the translation
        /// </summary>
        public TextOrientationHorizontal HorizontalTextOrientation
        {
            get { return _ownerSong.HorizontalTextOrientation; }
        }


        /// <summary>
        /// Gets or sets the text of this slide
        /// </summary>
        /// <param name="text"></param>
        public String Text
        {
            get {
                string txt = "";
                int i = 1;
                foreach (string str in Lines)
                {
                    txt += str;
                    if (i < Lines.Count)
                        txt += Environment.NewLine;
                    i++;
                }
                return txt;                
            }
            set {
                Lines = new List<string>();
                string[] ln = value.Trim().Split(new[] { Environment.NewLine, "<br/>" }, StringSplitOptions.None);
                foreach (string sl in ln)
                {
                    Lines.Add(sl.Trim());
                }            
            }
        }

        /// <summary>
        /// Gets or sets the translation of this slide
        /// </summary>
        /// <param name="text"></param>
        public String TranslationText
        {
            get
            {
                string txt = "";
                int i = 1;
                foreach (string str in Translation)
                {
                    txt += str;
                    if (i < Translation.Count)
                        txt += Environment.NewLine;
                    i++;
                }
                return txt;
            }
            set
            {
                Translation = new List<string>();
                string[] tr = value.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (string sl in tr)
                {
                    Translation.Add(sl.Trim());
                }
            }
        }

        /// <summary>
        /// The slide constructor
        /// </summary>
        public SongSlide(Song ownerSong)
        {
            Lines = new List<string>();
            Translation = new List<string>();
            ImageNumber = 0;
            _ownerSong = ownerSong;
        }

        #region ICloneable Members

        /// <summary>
        /// Clones this slide
        /// </summary>
        /// <returns>A duplicate of this slide</returns>
        public object Clone()
        {
            var res = new SongSlide(_ownerSong);
            res.Text = Text;
            res.TranslationText = TranslationText;
            res.PartName = PartName;
            res.TextSize = TextSize;
            res.ImageNumber = ImageNumber;
            return res;
        }

        #endregion ICloneable Members

        /// <summary>
        /// Returns the text on one line. This is mainly used
        /// in the song detail overview in the presenter.
        /// </summary>
        /// <returns>Text on one line</returns>
        public string GetOneLineText()
        {
            return Lines.Aggregate("", (current, str) => current + (str + " "));
        }

        /// <summary>
        /// Gets the translation on one line
        /// </summary>
        /// <returns></returns>
        public string GetOneLineTranslation()
        {
            return Translation.Aggregate("", (current, str) => current + (str + " "));
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int res = ImageNumber.GetHashCode() + TextSize.GetHashCode();
            for (int i = 0; i < Lines.Count; i++)
            {
                res = res ^ Lines[i].GetHashCode();
            }
            for (int i = 0; i < Translation.Count; i++)
            {
                res = res ^ Translation[i].GetHashCode();
            }
            return res;
        }

        /// <summary>
        /// Gets the object data for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ImageNumber", this.ImageNumber);
            info.AddValue("TextSize", this.TextSize);
            info.AddValue("PartName", this.PartName);
            info.AddValue("Lines", this.Lines);
            info.AddValue("Translation", this.Translation);
        }
    } ;
}