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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PraiseBase.Presenter.Model.Song
{
    /// <summary>
    ///     A single slide with songtext and/or a background image
    /// </summary>
    [Serializable]
    public class SongSlide : ICloneable, ISerializable
    {
        /// <summary>
        ///     The slide constructor
        /// </summary>
        public SongSlide()
        {
            Lines = new List<string>();
            Translation = new List<string>();
        }

        /// <summary>
        ///     All text lines of this slide
        /// </summary>
        public List<string> Lines { get; set; }

        /// <summary>
        ///     All translation lines of this slide
        /// </summary>
        public List<string> Translation { get; set; }

        /// <summary>
        ///     Number of the slide background image
        /// </summary>
        public IBackground Background { get; set; }

        /// <summary>
        ///     Size of the main text. This is used to maintain compatibility with PowerPraise
        /// </summary>
        public float TextSize { get; set; }

        /// <summary>
        ///     Part name
        /// </summary>
        public string PartName { get; set; }

        /// <summary>
        ///     Indicates wether this slide has a translation
        /// </summary>
        public bool Translated
        {
            get { return Translation.Count > 0; }
        }

        /// <summary>
        ///     Gets or sets the text of this slide
        /// </summary>
        public String Text
        {
            get
            {
                var txt = "";
                var i = 1;
                foreach (var str in Lines)
                {
                    txt += str;
                    if (i < Lines.Count)
                        txt += Environment.NewLine;
                    i++;
                }
                return txt;
            }
            set
            {
                Lines = new List<string>();
                var ln = value.Trim().Split(new[] {Environment.NewLine, "<br/>"}, StringSplitOptions.None);
                foreach (var sl in ln)
                {
                    Lines.Add(sl.Trim());
                }
            }
        }

        /// <summary>
        ///     Gets or sets the translation of this slide
        /// </summary>
        public String TranslationText
        {
            get
            {
                var txt = "";
                var i = 1;
                foreach (var str in Translation)
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
                var tr = value.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
                foreach (var sl in tr)
                {
                    Translation.Add(sl.Trim());
                }
            }
        }

        #region ICloneable Members

        /// <summary>
        ///     Clones this slide
        /// </summary>
        /// <returns>A duplicate of this slide</returns>
        public object Clone()
        {
            var res = new SongSlide
            {
                Text = Text,
                TranslationText = TranslationText,
                PartName = PartName,
                TextSize = TextSize,
                Background = Background
            };
            return res;
        }

        #endregion ICloneable Members

        /// <summary>
        ///     Gets the object data for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Background", Background);
            info.AddValue("TextSize", TextSize);
            info.AddValue("PartName", PartName);
            info.AddValue("Lines", Lines);
            info.AddValue("Translation", Translation);
        }

        /// <summary>
        ///     Returns the text on one line. This is mainly used
        ///     in the song detail overview in the presenter.
        /// </summary>
        /// <returns>Text on one line</returns>
        public string GetOneLineText()
        {
            return Lines.Aggregate("", (current, str) => current + (str + " "));
        }

        /// <summary>
        ///     Gets the translation on one line
        /// </summary>
        /// <returns></returns>
        public string GetOneLineTranslation()
        {
            return Translation.Aggregate("", (current, str) => current + (str + " "));
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (TranslationText != null ? TranslationText.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Text != null ? Text.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Background != null ? Background.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ TextSize.GetHashCode();
                hashCode = (hashCode*397) ^ (PartName != null ? PartName.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(SongSlide other)
        {
            return Equals(TranslationText, other.TranslationText) && Equals(Text, other.Text) &&
                   Equals(Background, other.Background) && TextSize.Equals(other.TextSize) &&
                   string.Equals(PartName, other.PartName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SongSlide) obj);
        }
    };
}