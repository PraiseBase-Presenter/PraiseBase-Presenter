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
using System.Linq;

namespace PraiseBase.Presenter.Model.Song
{
    /// <summary>
    ///     Provides a list of all authors in the song
    /// </summary>
    public class QualityIssues : HashSet<SongQualityAssuranceIndicator>
    {
        public override int GetHashCode()
        {
            unchecked
            {
                return this.Aggregate(19, (current, e) => current*31 + e.GetHashCode());
            }
        }

        protected bool Equals(QualityIssues other)
        {
            if (Count != other.Count) return false;
            if (this.Any(e => !other.Contains(e)))
            {
                return false;
            }
            return other.All(Contains);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((QualityIssues) obj);
        }

        public bool Set(SongQualityAssuranceIndicator qa, bool set)
        {
            if (set)
            {
                return Add(qa);
            }
            return Remove(qa);
        }
    }
}