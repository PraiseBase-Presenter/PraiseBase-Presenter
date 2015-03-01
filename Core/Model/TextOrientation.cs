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
namespace PraiseBase.Presenter.Model
{
    public sealed class TextOrientation : ICloneable
    {
        public VerticalOrientation Vertical { get; set; }
        public HorizontalOrientation Horizontal { get; set; }

        public TextOrientation(VerticalOrientation vertical, HorizontalOrientation horizontal) 
        {
            this.Vertical = vertical;
            this.Horizontal = horizontal;
        }

        public override string ToString()
        {
            return this.Vertical.ToString() + " " + this.Horizontal.ToString();
        }

        public bool Equals(TextOrientation ori)
        {
            if ((object)ori == null)
            {
                return false;
            }
            return this.Horizontal == ori.Horizontal && this.Vertical == ori.Vertical;
        }

        public override bool Equals(System.Object o)
        {
            if (o == null)
            {
                return false;
            }
            TextOrientation ori = o as TextOrientation;
            if ((System.Object)ori == null)
            {
                return false;
            }
            return this.Horizontal == ori.Horizontal && this.Vertical == ori.Vertical;
        }

        public override int GetHashCode()
        {
            return this.Horizontal.GetHashCode() ^ (17 * this.Vertical.GetHashCode());
        }

        public object Clone()
        {
            return new TextOrientation(Vertical, Horizontal);
        }
    }

    public enum VerticalOrientation
    {
        Top,
        Middle,
        Bottom
    }

    public enum HorizontalOrientation
    {
        Left,
        Center,
        Right
    }
}