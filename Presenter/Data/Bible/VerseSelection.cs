using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pbp.Data.Bible
{
    public class VerseSelection
    {
        public Verse StartVerse { get; private set; }

        public Verse EndVerse
        {
            get
            {
                return StartVerse.Chapter.Verses[endVerseNumber - 1];
            }
        }

        public Chapter Chapter
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
                    str += StartVerse.Chapter.Verses[i - 1] + Environment.NewLine;
                }
                return str;
            }
        }

        private int endVerseNumber = 0;

        public VerseSelection(Verse start)
        {
            StartVerse = start;
            endVerseNumber = start.Number;
        }

        public VerseSelection(Verse start, Verse end)
        {
            StartVerse = start;
            endVerseNumber = end.Number;
        }

        public VerseSelection(Verse start, int end)
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
