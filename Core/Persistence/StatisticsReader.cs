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
using PraiseBase.Presenter.Model.Statistics;

namespace PraiseBase.Presenter.Persistence
{
    public class StatisticsReader
    {
        public Statistics read(string filename)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            var xmlRoot = xmlDoc.DocumentElement;

            if (xmlRoot.Name != "statistics" ||
                (xmlRoot.Attributes["version"] == null || xmlRoot.Attributes["version"].Value != "1.0"))
            {
                throw new Exception("Ungültige Statistikdatei!");
            }
            var sl = new Statistics();
            for (var i = 0; i < xmlRoot.ChildNodes.Count; i++)
            {
                var node = xmlRoot.ChildNodes[i];
                if (node.Name == "date")
                {
                    var year = int.Parse(node.Attributes["year"].Value);
                    var month = int.Parse(node.Attributes["month"].Value);
                    var day = int.Parse(node.Attributes["day"].Value);
                    var date = new StatisticsDate(year, month, day);
                    sl.Dates.Add(date.Identifier, date);

                    for (var j = 0; j < node.ChildNodes.Count; j++)
                    {
                        var cnode = node.ChildNodes[j];
                        if (cnode.Name == "song")
                        {
                            var item = new StatisticsItem
                            {
                                Type = StatisticsItemType.Song,
                                Title = cnode.Attributes["title"].Value,
                                CcliId = cnode.Attributes["ccli"].Value,
                                Copyright = cnode.Attributes["copyright"].Value,
                                Count = int.Parse(cnode.Attributes["count"].Value)
                            };
                            date.Items.Add(item.Identifier, item);
                        }
                    }
                }
            }
            return sl;
        }
    }
}