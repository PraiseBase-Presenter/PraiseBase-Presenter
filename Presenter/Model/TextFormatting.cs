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

using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Pbp.Model
{
    public class TextFormatting
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
            int code = Font.GetHashCode()
                       ^ Color.GetHashCode()
                       ^ Outline.GetHashCode()
                       ^ Shadow.GetHashCode()
                       ^ LineSpacing.GetHashCode();
            return code;
        }
    }
}