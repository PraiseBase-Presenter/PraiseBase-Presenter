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

namespace Pbp.Data
{
    public class SongTextBorders
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
            return TextLeft.GetHashCode()
                 ^ TextTop.GetHashCode()
                 ^ TextRight.GetHashCode()
                 ^ TextBottom.GetHashCode()
                 ^ CopyrightBottom.GetHashCode()
                 ^ SourceTop.GetHashCode()
                 ^ SourceRight.GetHashCode();
        }
    }
}