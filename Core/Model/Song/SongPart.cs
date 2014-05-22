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
using System.Runtime.Serialization;

namespace Pbp.Model.Song
{
    /// <summary>
    /// A song part with a given name and one or more slides
    /// </summary>
    [Serializable()]
    public class SongPart : ISerializable
    {
        /// <summary>
        /// Part constructor
        /// </summary>
        public SongPart()
        {
            Slides = new SongSlideList();
        }

        /// <summary>
        /// Song part name like chorus, bridge, part 1 ...
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// A list of containing slides. Each part has one slide at minimum
        /// </summary>
        public SongSlideList Slides { get; set; }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Caption.GetHashCode() ^ Slides.GetHashCode();
        }

        /// <summary>
        /// Gets the object data for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Caption", this.Caption);
            info.AddValue("Language", this.Language);
            info.AddValue("Slides", this.Slides);
        }
    }
}