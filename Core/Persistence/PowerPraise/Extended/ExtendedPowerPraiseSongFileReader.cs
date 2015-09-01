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
using System.Linq;
using System.Xml;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise.Extended
{
    public class ExtendedPowerPraiseSongFileReader : AbstractPowerPraiseSongFileReader<ExtendedPowerPraiseSong>
    {
        public override ExtendedPowerPraiseSong Load(string filename)
        {
            var sng = new ExtendedPowerPraiseSong();
            Parse(filename, sng);
            return sng;
        }

        protected override void ParseAdditionalFields(XmlElement xmlRoot, PowerPraiseSong sng)
        {
            var song = (ExtendedPowerPraiseSong) sng;

            // Comment
            if (xmlRoot["general"] != null && xmlRoot["general"]["comment"] != null)
            {
                song.Comment = xmlRoot["general"]["comment"].InnerText;
            }
            else
            {
                song.Comment = "";
            }

            // Quality issues
            if (xmlRoot["general"] != null && xmlRoot["general"]["qualityissues"] != null)
            {
                ParseQualityIssues(song, xmlRoot["general"]["qualityissues"]);
            }

            // CCLI Song ID
            if (xmlRoot["general"] != null && xmlRoot["general"]["ccliNo"] != null)
            {
                song.CcliIdentifier = xmlRoot["general"]["ccliNo"].InnerText;
            }

            // Author(s)
            if (xmlRoot["general"] != null && xmlRoot["general"]["author"] != null)
            {
                song.Author = ParseAuthors(xmlRoot["general"]["author"].InnerText);
            }

            // Publisher
            if (xmlRoot["general"] != null && xmlRoot["general"]["publisher"] != null)
            {
                song.Publisher = xmlRoot["general"]["publisher"].InnerText;
            }

            // Rights management
            if (xmlRoot["general"] != null && xmlRoot["general"]["admin"] != null)
            {
                song.RightsManagement = xmlRoot["general"]["admin"].InnerText;
            }

            // Guid
            if (xmlRoot["general"] != null && xmlRoot["general"]["guid"] != null)
            {
                song.Guid = new Guid(xmlRoot["general"]["guid"].InnerText);
            }
        }

        private void ParseQualityIssues(ExtendedPowerPraiseSong song, XmlElement xmlElement)
        {
            foreach (XmlElement elem in xmlElement)
            {
                if (elem.Name == "issue")
                {
                    foreach (
                        SongQualityAssuranceIndicator i in Enum.GetValues(typeof (SongQualityAssuranceIndicator)))
                    {
                        if (elem.InnerText == Enum.GetName(typeof (SongQualityAssuranceIndicator), i))
                        {
                            song.QualityIssues.Add(i);
                        }
                    }
                }
            }
        }

        private SongAuthors ParseAuthors(string value)
        {
            var list = new SongAuthors();
            var i = 0;
            list.AddRange(
                value.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => ParseAuthorFromString(i++, s)));
            return list;
        }

        private static SongAuthor ParseAuthorFromString(int i, string s)
        {
            return new SongAuthor
            {
                Name = s.Trim(),
                Type = (i == 0) ? SongAuthorType.Words : SongAuthorType.Music
            };
        }
    }
}