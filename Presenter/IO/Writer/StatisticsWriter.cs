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
using System.Xml;
using Pbp.Data.Statistics;

namespace Pbp.IO
{
    class StatisticsWriter
    {
        protected const string XmlRootNodeName = "statistics";
        protected const string FileFormatVersion = "1.0";

        public void write(string filename, Statistics stat)
        {
            var xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(xmlDeclaration);
            xmlDoc.AppendChild(xmlDoc.CreateElement(XmlRootNodeName));
            XmlElement xmlRoot = xmlDoc.DocumentElement;
            xmlRoot.SetAttribute("version", FileFormatVersion);

            XmlElement node;
            foreach (var date in stat.Dates)
            {
                node = xmlDoc.CreateElement("date");
                node.SetAttribute("year", date.Value.Year.ToString());
                node.SetAttribute("month", date.Value.Month.ToString());
                node.SetAttribute("day", date.Value.Day.ToString());
                XmlNode dateNode = xmlRoot.AppendChild(node);
                foreach (var item in date.Value.Items)
                {
                    if (item.Value.Type == StatisticsItemType.Song)
                    {
                        node = xmlDoc.CreateElement("song");
                        node.SetAttribute("title", item.Value.Title);
                        node.SetAttribute("copyright", item.Value.Copyright);
                        node.SetAttribute("ccli", item.Value.CcliID);
                        node.SetAttribute("count", item.Value.Count.ToString());
                        dateNode.AppendChild(node);
                    }
                }
            }

            XmlWriterSettings wrtStn = new XmlWriterSettings();
            wrtStn.Encoding = Encoding.UTF8;
            wrtStn.Indent = true;
            XmlWriter wrt = XmlTextWriter.Create(filename, wrtStn);
            xmlDoc.WriteTo(wrt);
            wrt.Flush();
            wrt.Close();
        }
    }
}
