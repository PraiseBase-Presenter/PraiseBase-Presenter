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
using System.Xml;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise.Extended
{
    public class ExtendedPowerPraiseSongFileWriter : AbstractPowerPraiseSongFileWriter<ExtendedPowerPraiseSong>
    {
        public override void Save(string filename, ExtendedPowerPraiseSong sng)
        {
            Write(filename, sng);
        }

        protected override void writeAdditionalFields(XmlDocument xmlDoc, XmlElement xmlRoot, PowerPraiseSong ppl)
        {
            var sng = (ExtendedPowerPraiseSong) ppl;

            //
            // Non-standard meta-info
            //
            // GUID
            if (sng.Guid != null && sng.Guid != Guid.Empty)
            {
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("guid"));
                xmlRoot["general"]["guid"].InnerText = sng.Guid.ToString();
            }

            // Comment
            if (sng.Comment != string.Empty)
            {
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("comment"));
                xmlRoot["general"]["comment"].InnerText = sng.Comment;
            }
            // QA-Issues
            if (sng.QualityIssues.Count > 0)
            {
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("qualityissues"));
                foreach (var i in sng.QualityIssues)
                {
                    var qaChld = xmlRoot["general"]["qualityissues"].AppendChild(xmlDoc.CreateElement("issue"));
                    qaChld.InnerText = Enum.GetName(typeof (SongQualityAssuranceIndicator), i);
                }
            }

            // CCLI-ID
            if (sng.CcliIdentifier != null && sng.CcliIdentifier != String.Empty)
            {
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("ccliNo"));
                xmlRoot["general"]["ccliNo"].InnerText = sng.CcliIdentifier;
            }

            // Author(s)
            if (sng.Author != null && sng.Author.Count > 0)
            {
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("author"));
                xmlRoot["general"]["author"].InnerText = writeAuthors(sng);
            }
            // Publisher
            if (sng.Publisher != null && sng.Publisher != String.Empty)
            {
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("publisher"));
                xmlRoot["general"]["publisher"].InnerText = sng.Publisher;
            }
            // Rights management
            if (sng.RightsManagement != null && sng.RightsManagement != String.Empty)
            {
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("admin"));
                xmlRoot["general"]["admin"].InnerText = sng.RightsManagement;
            }
        }

        private String writeAuthors(ExtendedPowerPraiseSong sng)
        {
            var autstr = string.Empty;
            foreach (var aut in sng.Author)
            {
                if (autstr != string.Empty)
                {
                    autstr += ";";
                }
                autstr += aut.Name;
            }
            return autstr;
        }
    }
}