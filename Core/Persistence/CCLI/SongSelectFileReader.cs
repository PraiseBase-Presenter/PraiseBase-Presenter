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
using System.Text.RegularExpressions;

namespace PraiseBase.Presenter.Persistence.CCLI
{
    public class SongSelectFileReader : ISongFileReader<SongSelectFile>
    {
        protected const string SupportedFileFormatVersion = "3.0";
        protected const string TypeString = "SongSelect Import File";

        public SongSelectFile Load(string filename)
        {
            var sng = new SongSelectFile();

            var fields = new List<string>();
            var words = new List<string>();

            var section = CcliSongFileSection.None;

            var lines = File.ReadAllLines(@filename);
            foreach (var l in lines)
            {
                var li = l.Trim();
                var s = li.Split(new[] {"="}, StringSplitOptions.None);
                if (s.Length > 1)
                {
                    var k = s[0];
                    var v = s[1];

                    if (section == CcliSongFileSection.Content)
                    {
                        switch (k)
                        {
                            case "Title":
                                sng.Title = v;
                                break;

                            case "Author":
                                sng.Author = v;
                                break;

                            case "Copyright":
                                sng.Copyright = v;
                                break;

                            case "Admin":
                                sng.Admin = v;
                                break;

                            case "Themes":
                                foreach (var t in v.Split(new[] {"/t"}, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    sng.Themes.Add(t.Trim());
                                }
                                break;

                            case "Keys":
                                sng.Key = v;
                                break;

                            case "Fields":
                                fields.AddRange(v.Split(new[] {"/t"}, StringSplitOptions.RemoveEmptyEntries));
                                break;

                            case "Words":
                                words.AddRange(v.Split(new[] {"/t"}, StringSplitOptions.RemoveEmptyEntries));
                                break;
                        }
                    }
                }
                else
                {
                    if (li == "[File]")
                    {
                        section = CcliSongFileSection.File;
                    }
                    else
                    {
                        var m = Regex.Match(li, "^\\[S A([0-9]+)\\]$");
                        if (m.Success)
                        {
                            sng.CcliIdentifier = m.Groups[1].Value;
                            section = CcliSongFileSection.Content;
                        }
                    }
                }
            }

            if (fields.Count == 0 || fields.Count != words.Count || sng.Title == null)
            {
                throw new IncompleteSongSourceFileException();
            }

            for (var fx = 0; fx < fields.Count; fx++)
            {
                var p = new SongSelectFile.Verse
                {
                    Caption = fields[fx]
                };
                foreach (var l in words[fx].Split(new[] {"/n"}, StringSplitOptions.RemoveEmptyEntries))
                {
                    p.Lines.Add(l);
                }
                sng.Verses.Add(p);
            }


            return sng;
        }

        /// <summary>
        ///     Reads the title of a song from a file
        /// </summary>
        /// <param name="filename">Absolute path to the song file</param>
        /// <returns></returns>
        public string ReadTitle(string filename)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    return null;
                }

                var section = CcliSongFileSection.None;
                using (var sr = new StreamReader(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        var l = sr.ReadLine();
                        if (l != null)
                        {
                            var li = l.Trim();
                            var s = li.Split(new[] {"="}, StringSplitOptions.None);
                            if (s.Length > 1)
                            {
                                var k = s[0];
                                var v = s[1];

                                if (section == CcliSongFileSection.Content && k == "Title")
                                {
                                    sr.Close();
                                    return v;
                                }
                            }
                            else
                            {
                                if (li == "[File]")
                                {
                                    section = CcliSongFileSection.File;
                                }
                                else
                                {
                                    var m = Regex.Match(li, "^\\[S A([0-9]+)\\]$");
                                    if (m.Success)
                                    {
                                        section = CcliSongFileSection.Content;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        /// <summary>
        ///     Tests if a given file is supported by this reader
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool IsFileSupported(string filename)
        {
            try
            {
                var versionOk = false;
                var typeOk = false;

                using (var sr = new StreamReader(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        var l = sr.ReadLine();
                        if (l != null)
                        {
                            var s = l.Split(new[] {"="}, StringSplitOptions.None);
                            if (s.Length > 1)
                            {
                                var k = s[0];
                                var v = s[1].Trim();
                                switch (k)
                                {
                                    case "Version":
                                        if (v != SupportedFileFormatVersion)
                                        {
                                            sr.Close();
                                            return false;
                                        }
                                        versionOk = true;
                                        break;

                                    case "Type":
                                        if (v != TypeString)
                                        {
                                            sr.Close();
                                            return false;
                                        }
                                        typeOk = true;
                                        break;

                                    default:
                                        if (versionOk && typeOk)
                                        {
                                            sr.Close();
                                            return true;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private enum CcliSongFileSection
        {
            None,
            File,
            Content
        }
    }
}