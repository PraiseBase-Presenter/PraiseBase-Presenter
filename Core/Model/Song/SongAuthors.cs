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

namespace PraiseBase.Presenter.Model.Song
{
    /// <summary>
    ///     Provides a list of all authors in the song
    /// </summary>
    public class SongAuthors : ComparableList<SongAuthor>
    {
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

        public void FromString(string value)
        {
            Clear();
            if (value != null)
            {
                var i = 0;
                foreach (var s in value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var author = new SongAuthor
                    {
                        Name = s.Trim(),
                        Type = (i++ == 0) ? SongAuthorType.Words : SongAuthorType.Music
                    };
                    Add(author);
                }
            }
        }

        /// <summary>
        ///     All authors as semicolon-separated string
        /// </summary>
        public override string ToString()
        {
            var autstr = string.Empty;
            for (var i = 0; i < Count; i++)
            {
                if (autstr != string.Empty)
                {
                    autstr += "; ";
                }
                autstr += this[i].Name;
            }
            return autstr;
        }
    }
}