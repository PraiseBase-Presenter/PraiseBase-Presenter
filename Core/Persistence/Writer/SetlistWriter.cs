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

using System.Xml;
using PraiseBase.Presenter.Model;

namespace PraiseBase.Presenter.Persistence.Writer
{
    public class SetlistWriter
    {
        public void Write(string filename, Setlist list)
        {
            XmlWriterHelper xml = new XmlWriterHelper("setlist", "1.0");

            xml.Root.AppendChild(xml.Doc.CreateElement("items"));
            for (int i = 0; i < list.Items.Count; i++)
            {
                XmlNode nd = xml.Doc.CreateElement("item");
                nd.InnerText = list.Items[i];
                XmlNode ni = xml.Root["items"].AppendChild(nd);
            }

            xml.Write(filename);
        }
    }
}