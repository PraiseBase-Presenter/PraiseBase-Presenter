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
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using PraiseBase.Presenter.Model.Bible;
using PraiseBase.Presenter.Persistence.ZefaniaXML;

namespace PraiseBase.Presenter.Manager
{
    /// <summary>
    ///     Holds a list of all songs and provides
    ///     searching in the songlist
    /// </summary>
    public class BibleManager
    {
        // Here is the once-per-class call to initialize the log object
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        ///     Status of bible passage search
        /// </summary>
        public enum BiblePassageSearchStatus
        {
            /// <summary>
            ///     Search ongoing
            /// </summary>
            Ongoing,

            /// <summary>
            ///     Result found
            /// </summary>
            Found,

            /// <summary>
            ///     No result found
            /// </summary>
            NotFound
        }

        /// <summary>
        ///     The constructor
        /// </summary>
        public BibleManager(string bibleDirectory)
        {
            BibleDirectory = bibleDirectory;
        }

        /// <summary>
        ///     Directory where bible files are stored
        /// </summary>
        public string BibleDirectory { get; set; }

        /// <summary>
        ///     List of all availabe songs
        /// </summary>
        public Dictionary<string, BibleItem> BibleList { get; protected set; }

        /// <summary>
        ///     Gets or sets the current song object
        /// </summary>
        public BibleItem CurrentBible { get; set; }

        /// <summary>
        ///     Returns a list of bible files
        /// </summary>
        /// <returns></returns>
        public List<string> GetBibleFiles()
        {
            var di = new DirectoryInfo(BibleDirectory);
            if (!di.Exists)
            {
                di.Create();
            }
            var rgFiles = di.GetFiles("*.xml");
            return rgFiles.Select(fi => fi.FullName).ToList();
        }

        /// <summary>
        ///     Loads information of all bibles
        /// </summary>
        public void LoadBibleInfo()
        {
            BibleList = new Dictionary<string, BibleItem>();
            foreach (var file in GetBibleFiles())
            {
                var rdr = new XmlBibleReader();
                try
                {
                    var bi = new BibleItem
                    {
                        Bible = rdr.LoadMeta(file),
                        Filename = file
                    };
                    BibleList.Add(bi.Bible.Identifier ?? bi.Filename, bi);
                }
                catch (Exception e)
                {
                    log.Error(e.Message);
                }
            }
        }

        /// <summary>
        ///     Loads the content of a bible
        /// </summary>
        /// <param name="key">Bible key</param>
        public void LoadBibleData(string key)
        {
            var rdr = new XmlBibleReader();
            try
            {
                rdr.LoadContent(BibleList[key].Filename, BibleList[key].Bible);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
        }

        /// <summary>
        ///     Search book candidates
        /// </summary>
        /// <param name="bible">Bible</param>
        /// <param name="needle">Search criteria</param>
        /// <returns></returns>
        private List<BibleBook> SearchBookCandiates(Bible bible, string needle)
        {
            return bible.Books.Where(bk => needle.Length <= bk.Name.Length && needle == bk.Name.ToLower().Substring(0, needle.Length)).ToList();
        }

        /// <summary>
        ///     Searches a bible passages
        /// </summary>
        /// <param name="bible">Bible</param>
        /// <param name="needle">Search criteria</param>
        /// <returns></returns>
        public BiblePassageSearchResult SearchPassage(Bible bible, string needle)
        {
            var result = new BiblePassageSearchResult
            {
                Status = BiblePassageSearchStatus.Ongoing,
                Passage = new BiblePassage()
            };

            // Book only
            var match = Regex.Match(needle, @"^(.*[a-z])$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                var bkCandidates = SearchBookCandiates(bible, match.Groups[1].Value);
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
                var bkCandidates = SearchBookCandiates(bible, match.Groups[1].Value);
                if (bkCandidates.Count == 1)
                {
                    result.Passage.Book = bkCandidates[0];

                    var chapterNumber = int.Parse(match.Groups[2].Value);
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
            match = Regex.Match(needle, @"^(.*[a-z]) ([0-9]+)(?:,|.)([0-9]+)$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                var bkCandidates = SearchBookCandiates(bible, match.Groups[1].Value);
                if (bkCandidates.Count == 1)
                {
                    result.Passage.Book = bkCandidates[0];

                    var chapterNumber = int.Parse(match.Groups[2].Value);
                    if (chapterNumber > 0 && chapterNumber <= result.Passage.Book.Chapters.Count)
                    {
                        result.Passage.Chapter = result.Passage.Book.Chapters[chapterNumber - 1];

                        var verseNumber = int.Parse(match.Groups[3].Value);
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

        /// <summary>
        /// Import bible file
        /// </summary>
        /// <param name="sourcePath">Source path</param>
        /// <exception cref="Exception">If the file is not a valid XML Bible</exception>
        public void ImportFile(string sourcePath)
        {
            new XmlBibleReader().LoadMeta(sourcePath);
            string targetPath = BibleDirectory + "\\" + Path.GetFileName(sourcePath);
            File.Copy(sourcePath, targetPath, true);
        }

        /// <summary>
        ///     Song item structure
        /// </summary>
        public struct BibleItem
        {
            /// <summary>
            ///     Bible
            /// </summary>
            public Bible Bible { get; set; }

            /// <summary>
            ///     File name
            /// </summary>
            public string Filename { get; set; }

            public override string ToString()
            {
                return Bible.Title;
            }
        }

        /// <summary>
        ///     Bible search result
        /// </summary>
        public struct BiblePassageSearchResult
        {
            /// <summary>
            ///     Bible passage
            /// </summary>
            public BiblePassage Passage { get; set; }

            /// <summary>
            ///     Search status
            /// </summary>
            public BiblePassageSearchStatus Status { get; set; }
        }

        /// <summary>
        ///     Bible passage
        /// </summary>
        public class BiblePassage
        {
            /// <summary>
            ///     Book
            /// </summary>
            public BibleBook Book { get; set; }

            /// <summary>
            ///     Chapter
            /// </summary>
            public BibleChapter Chapter { get; set; }

            /// <summary>
            ///     Verse
            /// </summary>
            public BibleVerse Verse { get; set; }
        }
    }
}