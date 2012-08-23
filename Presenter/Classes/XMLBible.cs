using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Pbp
{
    /// <summary>
    /// XML bible reader based on Zefania XML format
    ///
    /// Author: Nicolas Perrenoud<nicu@lavine.ch>
    ///
    /// Zefania XML Project Website: http://sourceforge.net/projects/zefania-sharp/
    /// Wikipedia: http://de.wikipedia.org/wiki/Zefania_XML
    /// Docs: http://bgfdb.de/zefaniaxml/bml/
    /// </summary>
    public class XMLBible
    {
        public string Title { get; private set; }

        public bool isValid { get; private set; }

        public string FileName { get; private set; }

        public static string[] bookMap = { "1. Mose", "2. Mose", "3. Mose", "4. Mose", "5. Mose", "Josua", "Richter", "Rut", "1. Samuel", "2. Samuel", "1. Könige", "2. Könige", "1. Chronik", "2. Chronik", "Esra", "Nehemia", "Ester", "Hiob", "Psalm", "Sprüche", "Prediger", "Hohelied", "Jesaja", "Jeremia", "Klagelieder", "Hesekiel", "Daniel", "Hosea", "Joel", "Amos", "Obadja", "Jona", "Micha", "Nahum", "Habakuk", "Zephanja", "Haggai", "Sacharja", "Maleachi", "Matthäus", "Markus", "Lukas", "Johannes", "Apostelgeschichte", "Römer", "1. Korinther", "2. Korinther", "Galater", "Epheser", "Philipper", "Kolosser", "1. Thessalonicher", "2. Thessalonicher", "1. Timotheus", "2. Timotheus", "Titus", "Philemon", "Hebräer", "Jakobus", "1. Petrus", "2. Petrus", "1. Johannes", "2. Johannes", "3. Johannes", "Judas", "Offenbarung", "Judit", "Weisheit", "Tobia", "Sirach", "Baruch", "1 Makkabäer", "2 Makkabäer", "xDaniel", "xEster", "Manasse" };

        private XmlDocument xmlDoc;
        private XmlElement xmlRoot;

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

        public override string ToString()
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
                        ret.Add(new Book(bookNode, this));
                    }
                }
            }
            return ret;
        }

        static public List<string> getBibleFiles()
        {
            List<string> res = new List<string>();
            DirectoryInfo di = new DirectoryInfo(Pbp.Properties.Settings.Default.DataDirectory + Path.DirectorySeparatorChar + "Bibles");
            if (!di.Exists)
            {
                di.Create();
            }
            FileInfo[] rgFiles = di.GetFiles("*.xml");
            foreach (FileInfo fi in rgFiles)
            {
                res.Add(fi.FullName);
            }
            return res;
        }

        public class Book
        {
            public int Number { get; private set; }

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

            public override string ToString()
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
            public int Number { get; private set; }

            public XMLBible.Book Book { get; private set; }

            private XmlNode node;

            public Chapter(XmlNode chapterNode, XMLBible.Book owner)
            {
                this.Book = owner;
                this.node = chapterNode;
                Number = int.Parse(chapterNode.Attributes["cnumber"].InnerText);
            }

            public override string ToString()
            {
                return Number.ToString();
            }

            public List<XMLBible.Verse> getVerses()
            {
                List<XMLBible.Verse> ret = new List<Verse>();

                foreach (XmlNode versNode in node.ChildNodes)
                {
                    if (versNode.Name.ToLower() == "vers")
                    {
                        ret.Add(new Verse(versNode, this));
                    }
                }
                return ret;
            }
        }

        public class Verse
        {
            public int Number { get; private set; }

            public string Text { get; private set; }

            public XMLBible.Chapter Chapter { get; private set; }

            private XmlNode node;

            public Verse(XmlNode verseNode, XMLBible.Chapter owner)
            {
                this.Chapter = owner;
                this.node = verseNode;
                Number = int.Parse(verseNode.Attributes["vnumber"].InnerText);
                Text = verseNode.InnerText;
            }

            public override string ToString()
            {
                return Number.ToString() + ": " + Text;
            }
        }

        public class VerseSelection
        {
            public XMLBible.Verse StartVerse { get; private set; }

            public XMLBible.Verse EndVerse
            {
                get
                {
                    return StartVerse.Chapter.getVerses()[endVerseNumber - 1];
                }
            }

            public XMLBible.Chapter Chapter
            {
                get
                {
                    return StartVerse.Chapter;
                }
            }

            public string Text
            {
                get
                {
                    string str = "";
                    for (int i = StartVerse.Number; i <= endVerseNumber; i++)
                    {
                        str += StartVerse.Chapter.getVerses()[i - 1] + Environment.NewLine;
                    }
                    return str;
                }
            }

            private int endVerseNumber = 0;

            public VerseSelection(XMLBible.Verse start)
            {
                StartVerse = start;
                endVerseNumber = start.Number;
            }

            public VerseSelection(XMLBible.Verse start, XMLBible.Verse end)
            {
                StartVerse = start;
                endVerseNumber = end.Number;
            }

            public VerseSelection(XMLBible.Verse start, int end)
            {
                StartVerse = start;
                endVerseNumber = end;
            }

            public override string ToString()
            {
                return StartVerse.Chapter.Book + " " + StartVerse.Chapter + "." + (endVerseNumber != 0 && StartVerse.Number != endVerseNumber ? StartVerse.Number.ToString() + "-" + endVerseNumber : StartVerse.Number.ToString());
            }
        }
    }
}