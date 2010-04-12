using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Documents;

namespace Pbp
{
    public class Bible : TextLayer
    {
        List<BibleBook> books;
        public string Name {get;private set;}
        public string Language { get; private set; }
        string filePath;

        public Bible(string filePath)
        {
            this.filePath = filePath;
            loadXML();
        }

        bool loadXML()
        {
            try
            {
                XmlDocument xmlDoc;
                XmlElement xmlRoot;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
                xmlRoot = xmlDoc.DocumentElement;

                Name = xmlRoot.GetAttribute("name");
                Language = xmlRoot.GetAttribute("lang");

                books = new List<BibleBook>();

                foreach (XmlElement tn in xmlRoot.ChildNodes)
                {
                    if (tn.Name == "book")
                    {
                        BibleBook tb = new BibleBook(tn.GetAttribute("name"));
                        foreach (XmlElement cn in xmlRoot.ChildNodes)
                        {
                            if (cn.Name == "chapter")
                            {
                                BibleChapter cp = new BibleChapter(int.Parse(cn.GetAttribute("nr")));


                                tb.Add(cp);
                            }
                        }
                        books.Add(tb);
                    }
                }
                return true;
            }
            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        bool saveXML()
        {
            return true;
        }


    }

   public class BibleBook : List<BibleChapter>
    {
        public string Name { get; private set; }

        public BibleBook(string name)
        {
            Name = name;
        }


    }

    public class BibleChapter : List<List>
    {
        public int Number;
        public BibleChapter(int nr)
        {
            Number = nr;
        }
    }

}
