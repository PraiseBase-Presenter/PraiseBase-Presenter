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
using System.Collections.Generic;
using System.Xml;
using PraiseBase.Presenter.Model.Bible;

namespace PraiseBase.Presenter.Persistence.ZefaniaXML
{
    public class XMLBibleReader
    {
        private bool GetNodeText(XmlTextReader textReader, string name, ref Bible target, string fieldName)
        {
            if (textReader.NodeType == XmlNodeType.Element && textReader.Name.ToString().ToLower() == name)
            {
                textReader.Read();
                if (textReader.NodeType == XmlNodeType.Text)
                {
                    Type myType = typeof(Bible);
                    System.Reflection.PropertyInfo myFields = myType.GetProperty(fieldName);
                    myFields.SetValue(target, textReader.Value, null);
                }
            }
            return false;
        }

        public Bible LoadMeta(string fileName)
        {
            Bible b = new Bible();

            // Read a document
            XmlTextReader textReader = new XmlTextReader(fileName);

            // Read until end of file
            while (textReader.Read())
            {
                if (textReader.NodeType == XmlNodeType.Element && textReader.Name.ToString().ToLower() == "xmlbible")
                {
                    while (textReader.Read())
                    {
                        if (textReader.NodeType == XmlNodeType.Element)
                        {
                            if (GetNodeText(textReader, "title", ref b, "Title")) continue;
                            if (GetNodeText(textReader, "description", ref b, "Description")) continue;
                            if (GetNodeText(textReader, "contributors", ref b, "Contributors")) continue;
                            if (GetNodeText(textReader, "language", ref b, "Language")) continue;
                            if (GetNodeText(textReader, "publisher", ref b, "Publisher")) continue;
                            if (GetNodeText(textReader, "date", ref b, "Source")) continue;
                            if (GetNodeText(textReader, "source", ref b, "Date")) continue;
                            if (GetNodeText(textReader, "identifier", ref b, "Identifier")) continue;
                        }
                    }
                    break;
                }
            }
            return b;
        }

        public Bible LoadContent(string fileName, Bible b)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlElement xmlRoot = xmlDoc.DocumentElement;
            if (xmlRoot.Name == "XMLBIBLE")
            {
                b.Books = new List<BibleBook>();
                foreach (XmlNode bookNode in xmlRoot.ChildNodes)
                {
                    if (bookNode.Name.ToLower() == "biblebook")
                    {
                        BibleBook bo = new BibleBook();
                        bo.Bible = b;
                        bo.Number = int.Parse(bookNode.Attributes["bnumber"].InnerText);
                        bo.Name = bookNode.Attributes["bname"] != null ? bookNode.Attributes["bname"].InnerText : Bible.bookMap[bo.Number - 1];
                        bo.ShortName = bookNode.Attributes["bsname"] != null ? bookNode.Attributes["bsname"].InnerText : bo.Name;
                        bo.Chapters = new List<BibleChapter>();
                        foreach (XmlNode chapNode in bookNode.ChildNodes)
                        {
                            if (chapNode.Name.ToLower() == "chapter")
                            {
                                BibleChapter ch = new BibleChapter();
                                ch.Book = bo;
                                ch.Number = int.Parse(chapNode.Attributes["cnumber"].InnerText);
                                ch.Verses = new List<BibleVerse>();
                                foreach (XmlNode verseNode in chapNode.ChildNodes)
                                {
                                    if (verseNode.Name.ToLower() == "vers")
                                    {
                                        BibleVerse v = new BibleVerse();
                                        v.Chapter = ch;
                                        v.Number = int.Parse(verseNode.Attributes["vnumber"].InnerText);
                                        v.Text = verseNode.InnerText;
                                        ch.Verses.Add(v);
                                    }
                                }
                                bo.Chapters.Add(ch);
                            }
                        }
                        b.Books.Add(bo);
                    }
                }
            }
            return b;
        }
    }
}