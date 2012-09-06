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

namespace Pbp.Data.Song
{
    /// <summary>
    /// Provides a list of all slides
    /// </summary>
    public class SongSlideList : List<SongSlide>
    {
        /// <summary>
        /// Swaps the given slide with it's predecessor
        /// </summary>
        /// <param name="slideId">The slide index</param>
        /// <returns>Returns true is swapping was successfull</returns>
        public bool SwapWithUpper(int slideId)
        {
            if (slideId > 0 && slideId < Count)
            {
                SongSlide tmpPrt = this[slideId - 1];
                RemoveAt(slideId - 1);
                Insert(slideId, tmpPrt);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Swaps the given slide with it's successor
        /// </summary>
        /// <param name="slideId">The slide index</param>
        /// <returns>Returns true is swapping was successfull</returns>
        public bool SwapWithLower(int slideId)
        {
            if (slideId >= 0 && slideId < Count - 1)
            {
                SongSlide tmpPrt = this[slideId + 1];
                RemoveAt(slideId + 1);
                Insert(slideId, tmpPrt);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Duplicates a given slide
        /// </summary>
        /// <param name="slideId">The slide index</param>
        public void Duplicate(int slideId)
        {
            Insert(slideId, (SongSlide)this[slideId].Clone());
        }

        /// <summary>
        /// Duplicates a slide and cuts it's text in half,
        /// assigning the first part to the original slide
        /// and the second part to the copy
        /// </summary>
        /// <param name="slideId">The slide index</param>
        public void Split(int slideId)
        {
            var sld = (SongSlide)this[slideId].Clone();

            int totl = sld.Lines.Count;
            int rem = totl / 2;
            this[slideId].Lines.RemoveRange(0, rem);
            sld.Lines.RemoveRange(rem, totl - rem);

            totl = sld.Translation.Count;
            rem = totl / 2;
            this[slideId].Translation.RemoveRange(0, rem);
            sld.Translation.RemoveRange(rem, totl - rem);

            Insert(slideId, sld);
        }

        /// <summary>
        /// Returns the slidelist's hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int res = 0;
            for (int i = 0; i < Count; i++)
            {
                res = (res ^ this[i].GetHashCode()) ^ i.GetHashCode();
            }
            return res;
        }
    }
}