using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace Pbp
{
    /// <summary>
    /// XML bible reader based on Zefania XML format
    /// 
    /// Author: Nicolas Perrenoud<nicu@lavine.ch>
    /// 
    /// Project Website: http://sourceforge.net/projects/zefania-sharp/
    /// Wikipedia: http://de.wikipedia.org/wiki/Zefania_XML
    /// Docs: http://bgfdb.de/zefaniaxml/bml/
    /// </summary>
    class XMLBible
    {
        public string Title { get; private set; }
        public bool isValid { get; private set; }
        public string FileName { get; private set; }

        public static string[] bookMap = { "1 Mose", "2 Mose", "3 Mose", "4 Mose", "5 Mose", "Josua", "Richter", "Rut", "1 Samuel", "2 Samuel", "1 Könige", "2 Könige", "1 Chronik", "2 Chronik", "Esra", "Nehemia", "Ester", "Hiob", "Psalm", "Sprüche", "Prediger", "Hohelied", "Jesaja", "Jeremia", "Klagelieder", "Hesekiel", "Daniel", "Hosea", "Joel", "Amos", "Obadja", "Jona", "Micha", "Nahum", "Habakuk", "Zephanja", "Haggai", "Sacharja", "Maleachi", "Matthäus", "Markus", "Lukas", "Johannes", "Apostelgeschichte", "Römer", "1 Korinther", "2 Korinther", "Galater", "Epheser", "Philipper", "Kolosser", "1 Thessalonicher", "2 Thessalonicher", "1 Timotheus", "2 Timotheus", "Titus", "Philemon", "Hebräer", "Jakobus", "1 Petrus", "2 Petrus", "1 Johannes", "2 Johannes", "3 Johannes", "Judas", "Offenbarung", "Judit", "Weisheit", "Tobia", "Sirach", "Baruch", "1 Makkabäer", "2 Makkabäer", "xDaniel", "xEster", "Manasse"};

        XmlDocument xmlDoc;
        XmlElement xmlRoot;

        public XMLBible(string fileName)
        {
            isValid = false;

            // Read a document
            XmlTextReader textReader = new XmlTextReader(fileName);
            // Read until end of file
            while (textReader.Read())
            {
                if (textReader.NodeType == XmlNodeType.Element && textReader.Name.ToString().ToLower() == "xmlbible")
                {
                    while (textReader.Read())
                    {
                        if (textReader.NodeType == XmlNodeType.Element && textReader.Name.ToString().ToLower() == "title")
                        {
                            textReader.Read();
                            if (textReader.NodeType == XmlNodeType.Text)
                            {
                                Title = textReader.Value;
                                FileName = fileName;
                                isValid = true;                                
                            }
                            break;
                        }
                    }
                    break;
                }
            }
        }

        public string toString()
        {
            return Title;
        }

        private void loadBible()
        {
            if (xmlDoc == null && xmlRoot == null)
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(FileName);
                xmlRoot = xmlDoc.DocumentElement;
            }
        }

        public List<XMLBible.Book> getBooks()
        {
            loadBible();

            List<XMLBible.Book> ret = new List<Book>();
            if (xmlRoot.Name == "XMLBIBLE")
            {
                foreach (XmlNode bookNode in xmlRoot.ChildNodes)
                {
                    if (bookNode.Name.ToLower() == "biblebook")
                    {
                        ret.Add(new Book(bookNode,this));                        
                    }
                }
            }
            return ret;
        }


        static public List<string> getBibleFiles()
        {
            List<string> res = new List<string>();
            DirectoryInfo di = new DirectoryInfo(Pbp.Properties.Settings.Instance.DataDirectory + Path.DirectorySeparatorChar + "Bibles");
            FileInfo[] rgFiles = di.GetFiles("*.xml");
            foreach (FileInfo fi in rgFiles)
            {
                res.Add(fi.FullName);
            }
            return res;
        }

        public class Book
        {
            public int Number {get;private set;}
            public string Name { get; private set; }
            public string SName { get; private set; }
            public XMLBible Bible { get; private set; }

            private XmlNode node;

            public Book(XmlNode bookNode, XMLBible owner)
            {
                this.Bible = owner;
                this.node = bookNode;
                Number = int.Parse(bookNode.Attributes["bnumber"].InnerText);
                Name = bookNode.Attributes["bname"] != null ? bookNode.Attributes["bname"].InnerText : XMLBible.bookMap[Number - 1];
                SName = bookNode.Attributes["bsname"] != null ? bookNode.Attributes["bsname"].InnerText : Name;
            }

            public string toString()
            {
                return Name;
            }

            public List<XMLBible.Chapter> getChapters()
            {
                List<XMLBible.Chapter> ret = new List<Chapter>();

                foreach (XmlNode chapNode in node.ChildNodes)
                {
                    if (chapNode.Name.ToLower() == "chapter")
                    {
                        ret.Add(new Chapter(chapNode, this));
                    }
                }
                return ret;
            }

        }

        public class Chapter
        {
            public int Number {get;private set;}
            public XMLBible.Book Book { get; private set; }

            private XmlNode node;

            public Chapter(XmlNode chapterNode, XMLBible.Book owner)
            {
                this.Book = owner;
                this.node = chapterNode;
                Number = int.Parse(chapterNode.Attributes["cnumber"].InnerText);
            }

            public string toString()
            {
                return Number.ToString();
            }

            public List<XMLBible.Vers> getVerses()
            {
                List<XMLBible.Vers> ret = new List<Vers>();

                foreach (XmlNode versNode in node.ChildNodes)
                {
                    if (versNode.Name.ToLower() == "vers")
                    {
                        ret.Add(new Vers(versNode, this));
                    }
                }
                return ret;
            }

        }

        public class Vers
        {
            public int Number { get; private set; }
            public string Text { get; private set; }
            public XMLBible.Chapter Chapter { get; private set; }

            private XmlNode node;

            public Vers(XmlNode verseNode, XMLBible.Chapter owner)
            {
                this.Chapter = owner;
                this.node = verseNode;
                Number = int.Parse(verseNode.Attributes["vnumber"].InnerText);
                Text = verseNode.InnerText;
            }

            public string toString()
            {
                return Number.ToString();
            }
        }

    }
}
