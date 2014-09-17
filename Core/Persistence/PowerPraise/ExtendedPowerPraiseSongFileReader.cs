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
using System.Drawing;
using System.Xml;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public class ExtendedPowerPraiseSongFileReader : AbstractPowerPraiseSongFileReader<ExtendedPowerPraiseSong>
    {
        public new string GetFileTypeDescription() { return "PowerPraise Lied (erweitert)"; }

        public override ExtendedPowerPraiseSong Load(string filename)
        {
            ExtendedPowerPraiseSong sng = new ExtendedPowerPraiseSong();
            parse(filename, sng);
            return sng;
        }

        protected override void parseAdditionalFields(XmlElement xmlRoot, PowerPraiseSong sng)
        {
            ExtendedPowerPraiseSong song = (ExtendedPowerPraiseSong)sng;

            // Comment
            if (xmlRoot["general"]["comment"] != null)
            {
                song.Comment = xmlRoot["general"]["comment"].InnerText;
            }
            else
            {
                song.Comment = "";
            }

            // Quality issues
            if (xmlRoot["general"]["qualityissues"] != null)
            {
                foreach (XmlElement elem in xmlRoot["general"]["qualityissues"])
                {
                    if (elem.Name == "issue")
                    {
                        foreach (SongQualityAssuranceIndicator i in Enum.GetValues(typeof(SongQualityAssuranceIndicator)))
                        {
                            if (elem.InnerText == Enum.GetName(typeof(SongQualityAssuranceIndicator), i))
                            {
                                song.QualityIssues.Add(i);
                            }
                        }
                    }
                }
            }

            // CCLI Song ID
            if (xmlRoot["general"]["ccliNo"] != null)
            {
                song.CcliID = xmlRoot["general"]["ccliNo"].InnerText;
            }

            // Author(s)
            if (xmlRoot["general"]["author"] != null)
            {
                song.Author = parseAuthors(xmlRoot["general"]["author"].InnerText);
            }
            // Publisher
            if (xmlRoot["general"]["publisher"] != null)
            {
                song.Publisher = xmlRoot["general"]["publisher"].InnerText;
            }
            // Rights management
            if (xmlRoot["general"]["admin"] != null)
            {
                song.RightsManagement = xmlRoot["general"]["admin"].InnerText;
            }

            // Guid
            if (xmlRoot["general"]["guid"] != null)
            {
                song.GUID = new Guid(xmlRoot["general"]["guid"].InnerText);
            }
        }

        private List<SongAuthor> parseAuthors(String value)
        {
            List<SongAuthor> list = new List<SongAuthor>();
            int i = 0;
            foreach (String s in value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                SongAuthor author = new SongAuthor();
                author.Name = s.Trim();
                author.Type = (i++ == 0) ? SongAuthorType.words : SongAuthorType.music;
                list.Add(author);
            }
            return list;
        }
    }
}