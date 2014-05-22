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
using System.IO;
using Pbp.Properties;
using Pbp.Model.Bible;
using System.Text.RegularExpressions;

namespace Pbp
{
    /// <summary>
    /// Holds a list of all songs and provides
    /// searching in the songlist
    /// </summary>
    internal class BibleManager
    {
        /// <summary>
        /// Song item structure
        /// </summary>
        public struct BibleItem
        {
            public Bible Bible { get; set; }

            public string Filename { get; set; }

            public override string ToString()
            {
                return Bible.Title;
            }
        }

        public enum BiblePassageSearchStatus
        {
            Ongoing,
            Found,
            NotFound
        } 

        public struct BiblePassageSearchResult
        {
            public BiblePassage Passage { get; set; }
            public BiblePassageSearchStatus Status { get; set; }
        }

        public class BiblePassage
        {
            public BibleBook Book { get; set; }
            public BibleChapter Chapter { get; set; }
            public BibleVerse Verse { get; set; }
        }

        /// <summary>
        /// Singleton variable
        /// </summary>
        private static BibleManager _instance;

        /// <summary>
        /// List of all availabe songs
        /// </summary>
        public Dictionary<string, BibleItem> BibleList { get; protected set; }

        /// <summary>
        /// Gets or sets the current song object
        /// </summary>
        public BibleItem CurrentBible { get; set; }

        /// <summary>
        /// Gets the singleton of this class (field alternative)
        /// </summary>
        public static BibleManager Instance
        {
            get { return _instance ?? (_instance = new BibleManager()); }
        }

        /// <summary>
        /// The constructor
        /// </summary>
        private BibleManager()
        {
        }

        public List<string> GetBibleFiles()
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

        public void LoadBibleInfo()
        {
            BibleList = new Dictionary<string, BibleItem>();
            foreach (string file in GetBibleFiles())
            {
                Pbp.Persistence.Reader.XMLBibleReader rdr = new Pbp.Persistence.Reader.XMLBibleReader();
                try
                {
                    BibleItem bi = new BibleItem();
                    bi.Bible = rdr.LoadMeta(file);
                    bi.Filename = file;
                    BibleList.Add(bi.Bible.Identifier != null ? bi.Bible.Identifier : bi.Filename, bi);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void LoadBibleData(string key)
        {
            Pbp.Persistence.Reader.XMLBibleReader rdr = new Pbp.Persistence.Reader.XMLBibleReader();
            try
            {
                rdr.LoadContent(BibleList[key].Filename, BibleList[key].Bible);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private List<BibleBook> SearchBookCandiates(Bible bible, string needle)
        {
            var bkCandidates = new List<Pbp.Model.Bible.BibleBook>();
            foreach (Pbp.Model.Bible.BibleBook bk in bible.Books)
            {
                if (needle.Length <= bk.Name.Length && needle == bk.Name.ToLower().Substring(0, needle.Length))
                {
                    bkCandidates.Add(bk);
                }
            }
            return bkCandidates;
        }

        public BiblePassageSearchResult SearchPassage(Bible bible, string needle)
        {
            BiblePassageSearchResult result = new BiblePassageSearchResult();
            result.Status = BiblePassageSearchStatus.Ongoing;
            result.Passage = new BiblePassage();

            Match match;

            // Book only
            match = Regex.Match(needle, @"^(.*[a-z])$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                List<BibleBook> bkCandidates = SearchBookCandiates(bible, match.Groups[1].Value);
                if (bkCandidates.Count == 1)
                {
                    result.Passage.Book = bkCandidates[0];
                    result.Status = BiblePassageSearchStatus.Found;
                }
                else if (bkCandidates.Count == 0)
                {
                    result.Status = BiblePassageSearchStatus.NotFound;
                }
                return result;
            }

            // Book and chapter
            match = Regex.Match(needle, @"^(.*[a-z]) ([0-9]+)$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                List<BibleBook> bkCandidates = SearchBookCandiates(bible, match.Groups[1].Value);
                if (bkCandidates.Count == 1)
                {
                    result.Passage.Book = bkCandidates[0];

                    int chapterNumber = int.Parse(match.Groups[2].Value);
                    if (chapterNumber > 0 && chapterNumber <= result.Passage.Book.Chapters.Count)
                    {
                        result.Passage.Chapter = result.Passage.Book.Chapters[chapterNumber - 1];
                        result.Status = BiblePassageSearchStatus.Found;
                    }
                    else
                    {
                        result.Status = BiblePassageSearchStatus.NotFound;
                    }
                }
                else if (bkCandidates.Count == 0)
                {
                    result.Status = BiblePassageSearchStatus.NotFound;
                }
                return result;
            }

            // Book and chapter and verse
            match = Regex.Match(needle, @"^(.*[a-z]) ([0-9]+),([0-9]+)$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                List<BibleBook> bkCandidates = SearchBookCandiates(bible, match.Groups[1].Value);
                if (bkCandidates.Count == 1)
                {
                    result.Passage.Book = bkCandidates[0];

                    int chapterNumber = int.Parse(match.Groups[2].Value);
                    if (chapterNumber > 0 && chapterNumber <= result.Passage.Book.Chapters.Count)
                    {
                        result.Passage.Chapter = result.Passage.Book.Chapters[chapterNumber - 1];

                        int verseNumber = int.Parse(match.Groups[3].Value);
                        if (verseNumber > 0 && verseNumber <= result.Passage.Chapter.Verses.Count)
                        {
                            result.Passage.Verse = result.Passage.Chapter.Verses[verseNumber - 1];
                            result.Status = BiblePassageSearchStatus.Found;
                        }
                        else
                        {
                            result.Status = BiblePassageSearchStatus.NotFound;
                        }
                    }
                    else
                    {
                        result.Status = BiblePassageSearchStatus.NotFound;
                    }
                }
                else if (bkCandidates.Count == 0)
                {
                    result.Status = BiblePassageSearchStatus.NotFound;
                }
                return result;
            }

            return result;
        }
    }
}