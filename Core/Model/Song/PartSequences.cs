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

using System.Collections.Generic;

namespace PraiseBase.Presenter.Model.Song
{
    /// <summary>
    /// Provides a list of all authors in the song
    /// </summary>
    public class PartSequences : List<SongPart>
    {
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                for (int i = 0; i < Count; i++)
                {
                    hash = hash * 31 + this[i].GetHashCode();
                }
                return hash;
            }
        }

        protected bool Equals(PartSequences other)
        {
            if (Count != other.Count) return false;
            for (int i = 0; i < Count; i++)
            {
                if (!Equals(this[i], other[i])) return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PartSequences)obj);
        }
    }
}