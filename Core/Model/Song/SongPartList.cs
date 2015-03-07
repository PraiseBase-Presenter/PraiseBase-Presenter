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
    /// Provides a list of all parts in the song
    /// </summary>
    public class SongPartList : List<SongPart>
    {
        /// <summary>
        /// Swaps the part with the previous one
        /// </summary>
        /// <param name="partId">Index of the part</param>
        /// <returns></returns>
        public bool SwapWithUpper(int partId)
        {
            if (partId > 0 && partId < Count)
            {
                SongPart tmpPrt = this[partId - 1];
                RemoveAt(partId - 1);
                Insert(partId, tmpPrt);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Swaps the part with the next one
        /// </summary>
        /// <param name="partId">Index of the part</param>
        /// <returns></returns>
        public bool SwapWithLower(int partId)
        {
            if (partId >= 0 && partId < Count - 1)
            {
                SongPart tmpPrt = this[partId + 1];
                RemoveAt(partId + 1);
                Insert(partId, tmpPrt);
                return true;
            }
            return false;
        }

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
    }
}