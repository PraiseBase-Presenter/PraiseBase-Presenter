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

using System.Text;
using System.Xml;

namespace PraiseBase.Presenter.Persistence
{
    internal class XmlWriterHelper
    {
        public XmlWriterHelper(string rootNodeName, string fileFormatVersion)
        {
            Doc = new XmlDocument();
            var xmlDeclaration = Doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            Doc.AppendChild(xmlDeclaration);
            Doc.AppendChild(Doc.CreateElement(rootNodeName));
            var xmlRoot = Doc.DocumentElement;
            xmlRoot.SetAttribute("version", fileFormatVersion);
        }

        public XmlDocument Doc { get; protected set; }

        public XmlElement Root
        {
            get { return Doc.DocumentElement; }
        }

        public void Write(string filename)
        {
            var wrtStn = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true
            };
            var wrt = XmlWriter.Create(filename, wrtStn);
            Doc.WriteTo(wrt);
            wrt.Flush();
            wrt.Close();
        }
    }
}