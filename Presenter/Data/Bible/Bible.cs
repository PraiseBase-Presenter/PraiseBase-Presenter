using System;
using System.Collections.Generic;

namespace Pbp.Data.Bible
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
    public class Bible
    {
        public readonly static string[] bookMap = { "1. Mose", "2. Mose", "3. Mose", "4. Mose", "5. Mose", "Josua", "Richter", "Rut", "1. Samuel", "2. Samuel", "1. Könige", "2. Könige", "1. Chronik", "2. Chronik", "Esra", "Nehemia", "Ester", "Hiob", "Psalm", "Sprüche", "Prediger", "Hohelied", "Jesaja", "Jeremia", "Klagelieder", "Hesekiel", "Daniel", "Hosea", "Joel", "Amos", "Obadja", "Jona", "Micha", "Nahum", "Habakuk", "Zephanja", "Haggai", "Sacharja", "Maleachi", "Matthäus", "Markus", "Lukas", "Johannes", "Apostelgeschichte", "Römer", "1. Korinther", "2. Korinther", "Galater", "Epheser", "Philipper", "Kolosser", "1. Thessalonicher", "2. Thessalonicher", "1. Timotheus", "2. Timotheus", "Titus", "Philemon", "Hebräer", "Jakobus", "1. Petrus", "2. Petrus", "1. Johannes", "2. Johannes", "3. Johannes", "Judas", "Offenbarung", "Judit", "Weisheit", "Tobia", "Sirach", "Baruch", "1 Makkabäer", "2 Makkabäer", "xDaniel", "xEster", "Manasse" };

        public string Title { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Contributors { get; set; }
        public string Date { get; set; }
        public string Source { get; set; }
        public string Language { get; set; }
        public string Identifier { get; set; }

        public List<Book> Books { get; set; }

        public Bible()
        {

        }

        public override string ToString()
        {
            return Title;
        }
    }
}