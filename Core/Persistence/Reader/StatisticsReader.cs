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
using System.Xml;
using Pbp.Model.Statistics;

namespace Pbp.Persistence.Reader
{
    public class StatisticsReader
    {
        public Statistics read(string filename)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlElement xmlRoot = xmlDoc.DocumentElement;

            if (xmlRoot.Name != "statistics" || (xmlRoot.Attributes["version"] == null || xmlRoot.Attributes["version"].Value != "1.0"))
            {
                throw new Exception("Ungültige Statistikdatei!");
            }
            Statistics sl = new Statistics();
            for (int i = 0; i < xmlRoot.ChildNodes.Count; i++)
            {
                var node = xmlRoot.ChildNodes[i];
                if (node.Name == "date")
                {
                    int year = Int32.Parse(node.Attributes["year"].Value);
                    int month = Int32.Parse(node.Attributes["month"].Value);
                    int day = Int32.Parse(node.Attributes["day"].Value);
                    var date = new StatisticsDate(year, month, day);
                    sl.Dates.Add(date.ID, date);

                    for (int j = 0; j < node.ChildNodes.Count; j++)
                    {
                        var cnode = node.ChildNodes[j];
                        if (cnode.Name == "song")
                        {
                            var item = new StatisticsItem();
                            item.Type = StatisticsItemType.Song;
                            item.Title = cnode.Attributes["title"].Value;
                            item.CcliID = cnode.Attributes["ccli"].Value;
                            item.Copyright = cnode.Attributes["copyright"].Value;
                            item.Count = Int32.Parse(cnode.Attributes["count"].Value);
                            date.Items.Add(item.ID, item);
                        }
                    }
                }
            }
            return sl;
        }
    }
}