﻿/*
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
 *   Author:
 *      Nicolas Perrenoud <nicu_at_lavine.ch>
 *   Co-authors:
 *      ...
 *
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise.Extended
{
    public class ExtendedPowerPraiseSongFileMapper : PowerPraiseSongFileMapper, ISongFileMapper<ExtendedPowerPraiseSong>
    {
        /// <summary>
        /// Maps a PowerPraise song to a Song object
        /// </summary>
        /// <param name="ppl"></param>
        /// <returns></returns>
        public Song map(ExtendedPowerPraiseSong ppl)
        {
            Song song = this.map((PowerPraiseSong)ppl);

            song.Comment = ppl.Comment;
            song.QualityIssues.AddRange(ppl.QualityIssues);
            song.CcliID = ppl.CcliID;
            song.Author.AddRange(ppl.Author);
            song.RightsManagement = ppl.RightsManagement;
            song.Publisher = ppl.Publisher;
            song.GUID = ppl.GUID;

            return song;
        }

        /// <summary>
        /// Maps a song to a PowerPraise song object
        /// </summary>
        /// <param name="song"></param>
        /// <param name="ppl"></param>
        public void map(Song song, ExtendedPowerPraiseSong ppl)
        {
            this.map(song, (PowerPraiseSong)ppl);
            
            ppl.Comment = song.Comment;
            ppl.QualityIssues.AddRange(song.QualityIssues);
            ppl.CcliID = song.CcliID;
            ppl.Author.AddRange(song.Author);
            ppl.RightsManagement = song.RightsManagement;
            ppl.Publisher = song.Publisher;
            ppl.GUID = song.GUID;
        }
    }
}