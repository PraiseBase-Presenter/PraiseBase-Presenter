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

namespace Pbp.IO
{
    class SetlistWriter
    {
        public void write(string filename, Setlist list)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.AppendChild(xmlDoc.CreateNode(XmlNodeType.XmlDeclaration, "", ""));
            xmlDoc.AppendChild(xmlDoc.CreateElement("setlist"));
            XmlElement xmlRoot = xmlDoc.DocumentElement;
            xmlRoot.AppendChild(xmlDoc.CreateElement("items"));
            for (int i = 0; i < list.Items.Count; i++)
            {
                XmlNode nd = xmlDoc.CreateElement("item");
                nd.InnerText = list.Items[i].Title;
                XmlNode ni = xmlRoot["items"].AppendChild(nd);
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
