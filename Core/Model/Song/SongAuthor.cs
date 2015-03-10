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

namespace PraiseBase.Presenter.Model.Song
{
    /// <summary>
    /// Describes the author of a song
    /// </summary>
    public class SongAuthor
    {
        /// <summary>
        /// Author name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Author type
        /// </summary>
        public SongAuthorType Type { get; set; }

        protected bool Equals(SongAuthor other)
        {
            return Type == other.Type && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SongAuthor) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Type*397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }
}