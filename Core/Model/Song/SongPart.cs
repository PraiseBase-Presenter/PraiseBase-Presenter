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
using System.Runtime.Serialization;

namespace PraiseBase.Presenter.Model.Song
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
            unchecked
            {
                var hashCode = (Caption != null ? Caption.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Language != null ? Language.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Slides != null ? Slides.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(SongPart other)
        {
            return string.Equals(Caption, other.Caption) && string.Equals(Language, other.Language) && Equals(Slides, other.Slides);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SongPart) obj);
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