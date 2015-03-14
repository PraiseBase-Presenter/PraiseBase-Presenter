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

namespace PraiseBase.Presenter.Model.Song
{
    public class SongTextBorders : ICloneable
    {
        public int TextLeft { get; set; }

        public int TextTop { get; set; }

        public int TextRight { get; set; }

        public int TextBottom { get; set; }

        public int CopyrightBottom { get; set; }

        public int SourceTop { get; set; }

        public int SourceRight { get; set; }

        public SongTextBorders(int textLeft, int textTop, int textRight, int textBottom, int copyrightBottom, int sourceTop, int sourceRight)
        {
            TextLeft = textLeft;
            TextTop = textTop;
            TextRight = textRight;
            TextBottom = textBottom;
            CopyrightBottom = copyrightBottom;
            SourceTop = sourceTop;
            SourceRight = sourceRight;
        }

        /// <summary>
        /// Returns a hashcode of the text formatting object, used for example in the
        /// editor to check if the file was changed
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = TextLeft;
                hashCode = (hashCode*397) ^ TextTop;
                hashCode = (hashCode*397) ^ TextRight;
                hashCode = (hashCode*397) ^ TextBottom;
                hashCode = (hashCode*397) ^ CopyrightBottom;
                hashCode = (hashCode*397) ^ SourceRight;
                hashCode = (hashCode*397) ^ SourceTop;
                return hashCode;
            }
        }

        protected bool Equals(SongTextBorders other)
        {
            return TextLeft == other.TextLeft && TextTop == other.TextTop && TextRight == other.TextRight && TextBottom == other.TextBottom && CopyrightBottom == other.CopyrightBottom && SourceRight == other.SourceRight && SourceTop == other.SourceTop;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SongTextBorders) obj);
        }

        public object Clone()
        {
            return new SongTextBorders(TextLeft, TextTop, TextRight, TextBottom, CopyrightBottom, SourceTop, SourceRight);
        }
    }
}