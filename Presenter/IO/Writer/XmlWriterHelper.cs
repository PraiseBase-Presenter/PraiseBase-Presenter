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

namespace Pbp.IO.Writer
{
    class XmlWriterHelper
    {
        public XmlDocument Doc { get; protected set; }

        public XmlElement Root { 
            get {
                return  Doc.DocumentElement;
            }  
        }

        public XmlWriterHelper(string rootNodeName, string fileFormatVersion)
        {
            Doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = Doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            Doc.AppendChild(xmlDeclaration);
            Doc.AppendChild(Doc.CreateElement(rootNodeName));
            XmlElement xmlRoot = Doc.DocumentElement;
            xmlRoot.SetAttribute("version", fileFormatVersion);
        }

        public void Write(string filename)
        {
            XmlWriterSettings wrtStn = new XmlWriterSettings();
            wrtStn.Encoding = Encoding.UTF8;
            wrtStn.Indent = true;
            XmlWriter wrt = XmlTextWriter.Create(filename, wrtStn);
            Doc.WriteTo(wrt);
            wrt.Flush();
            wrt.Close();
        }
    }
}
