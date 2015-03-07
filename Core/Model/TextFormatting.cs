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
using System.Drawing;

namespace PraiseBase.Presenter.Model
{
    public class TextFormatting : ICloneable
    {
        public Font Font { get; set; }

        public Color Color { get; set; }

        public TextOutline Outline { get; set; }

        public TextShadow Shadow { get; set; }

        public int LineSpacing { get; set; }

        public TextFormatting(Font font, Color color, TextOutline outline, TextShadow shadow, int lineSpacing)
        {
            Font = font;
            Color = color;
            Outline = outline;
            Shadow = shadow;
            LineSpacing = lineSpacing;
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
                var hashCode = (Font != null ? Font.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Color.GetHashCode();
                hashCode = (hashCode*397) ^ (Outline != null ? Outline.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Shadow != null ? Shadow.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ LineSpacing;
                return hashCode;
            }
        }

        protected bool Equals(TextFormatting other)
        {
            return Equals(Font, other.Font) && Color.Equals(other.Color) && Equals(Outline, other.Outline) && Equals(Shadow, other.Shadow) && LineSpacing == other.LineSpacing;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TextFormatting) obj);
        }

        public object Clone()
        {
            return new TextFormatting(Font, Color, (TextOutline)Outline.Clone(), (TextShadow)Shadow.Clone(), LineSpacing);
        }
    }
}