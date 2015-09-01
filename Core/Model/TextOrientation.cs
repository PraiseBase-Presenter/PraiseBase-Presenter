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
        public TextOrientation(VerticalOrientation vertical, HorizontalOrientation horizontal)
        {
            Vertical = vertical;
            Horizontal = horizontal;
        }

        public VerticalOrientation Vertical { get; set; }
        public HorizontalOrientation Horizontal { get; set; }

        public object Clone()
        {
            return new TextOrientation(Vertical, Horizontal);
        }

        public override string ToString()
        {
            return Vertical + " " + Horizontal;
        }

        private bool Equals(TextOrientation ori)
        {
            return Vertical == ori.Vertical && Horizontal == ori.Horizontal;
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(null, o)) return false;
            if (ReferenceEquals(this, o)) return true;
            return o is TextOrientation && Equals((TextOrientation) o);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Vertical*397) ^ (int) Horizontal;
            }
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