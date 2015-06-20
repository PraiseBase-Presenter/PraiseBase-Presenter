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
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.OpenLyrics
{
    public class OpenLyricsSongFileMapper : ISongFileMapper<OpenLyricsSong>
    {
        public Song Map(OpenLyricsSong source)
        {
            var sng = new Song
            {
                // Modified date
                ModifiedTimestamp = source.ModifiedTimestamp,
                // Application the song was created in
                CreatedIn = source.CreatedIn,
                // Application the song was modified in
                ModifiedIn = source.ModifiedIn,
                // Title
                Title = source.Title,
                // CCLI
                CcliIdentifier = source.CcliIdentifier,
                // Copyright
                Copyright = source.Copyright,
                // Application the song was modified in
                ReleaseYear = source.ReleaseYear
            };

            //
            // Lyrics
            //

            foreach (var verse in source.Verses)
            {
                var part = new SongPart
                {
                    Caption = verse.Name,
                    Language = verse.Language
                };

                foreach (var line in verse.Lines)
                {
                    var slide = new SongSlide
                    {
                        PartName = line.Part
                    };
                    slide.Lines.AddRange(line.Text);
                    part.Slides.Add(slide);
                }
                sng.Parts.Add(part);
            }

            return sng;
        }

        public void Map(Song source, OpenLyricsSong target)
        {
            throw new NotImplementedException("Not implemented yet");
        }
    }
}