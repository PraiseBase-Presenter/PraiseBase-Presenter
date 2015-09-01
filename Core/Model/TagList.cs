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

using System.Linq;

namespace PraiseBase.Presenter.Model
{
    /// <summary>
    ///     Tag class. It allows only unique items
    /// </summary>
    public class TagList : ComparableList<string>
    {
        /// <summary>
        ///     Adds an unique tag to the taglist
        /// </summary>
        /// <param name="tagName"></param>
        public new void Add(string tagName)
        {
            if (!Contains(tagName))
            {
                base.Add(tagName);
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 19;
                for (var i = 0; i < Count; i++)
                {
                    hash = hash*31 + this[i].GetHashCode();
                }
                return hash;
            }
        }

        /// <summary>
        ///     Returns a comma separated string of all tags
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var res = string.Empty;
            for (var i = 0; i < Count; i++)
            {
                res += this.ElementAt(i);
                if (i < Count - 1)
                    res += ", ";
            }
            return res;
        }
    }
}