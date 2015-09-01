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

namespace PraiseBase.Presenter.Model.Bible
{
    public class BibleVerseSelection
    {
        private readonly int _endVerseNumber;

        public BibleVerseSelection(BibleVerse start)
        {
            StartVerse = start;
            _endVerseNumber = start.Number;
        }

        public BibleVerseSelection(BibleVerse start, BibleVerse end)
        {
            StartVerse = start;
            _endVerseNumber = end.Number;
        }

        public BibleVerseSelection(BibleVerse start, int end)
        {
            StartVerse = start;
            _endVerseNumber = end;
        }

        public BibleVerse StartVerse { get; private set; }

        public BibleVerse EndVerse
        {
            get { return StartVerse.Chapter.Verses[_endVerseNumber - 1]; }
        }

        public BibleChapter Chapter
        {
            get { return StartVerse.Chapter; }
        }

        public string Text
        {
            get
            {
                var str = "";
                for (var i = StartVerse.Number; i <= _endVerseNumber; i++)
                {
                    str += StartVerse.Chapter.Verses[i - 1] + Environment.NewLine;
                }
                return str;
            }
        }

        public override string ToString()
        {
            return StartVerse.Chapter.Book + " " + StartVerse.Chapter + "." +
                   (_endVerseNumber != 0 && StartVerse.Number != _endVerseNumber
                       ? StartVerse.Number + "-" + _endVerseNumber
                       : StartVerse.Number.ToString());
        }
    }
}