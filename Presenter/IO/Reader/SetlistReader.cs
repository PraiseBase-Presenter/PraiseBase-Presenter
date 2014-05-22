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
using Pbp.Data;

namespace Pbp.IO.Reader
{
    public class SetlistReader
    {
        public Setlist read(string filename)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlElement xmlRoot = xmlDoc.DocumentElement;

            if (xmlRoot.Name != "setlist")
            {
                throw new Exception("Ungültige Setlist!");
            }
            Setlist sl = new Setlist();
            if (xmlRoot["items"] != null)
            {
                sl.Items.Clear();
                for (int i = 0; i < xmlRoot["items"].ChildNodes.Count; i++)
                {
                    if (xmlRoot["items"].ChildNodes[i].Name == "item")
                    {
                        Guid g = SongManager.Instance.GetGuidByTitle(xmlRoot["items"].ChildNodes[i].InnerText);
                        if (g != Guid.Empty)
                        {
                            sl.Items.Add(SongManager.Instance.SongList[g].Song);
                        }
                    }
                }
            }
            return sl;
        }
    }
}
