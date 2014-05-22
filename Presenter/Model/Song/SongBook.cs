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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp.Model.Song
{
    /// <summary>
    /// Most songs come from some sort of collection of songs, be it a book or a 
    /// folder of some sort. It may be useful to track where the song comes from
    /// </summary>
    public class SongBook
    {
        /// <summary>
        /// The name of a song book
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The index of the song
        /// </summary>
        public string Entry { get; set; }
    }
}
