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

        private enum CcliSongFileSection {
            NONE,
            FILE,
            CONTENT
        }

        public SongSelectFile Load(string filename)
        {
            SongSelectFile sng = new SongSelectFile();
            
            List<String> fields = new List<string>();
            List<String> words = new List<string>();

            CcliSongFileSection section = CcliSongFileSection.NONE;

            string[] lines = File.ReadAllLines(@filename);
            foreach (string l in lines)
            {
                string li = l.Trim();
                string[] s = li.Split(new[] { "=" }, StringSplitOptions.None);
                if (s.Length > 1)
                {
                    string k = s[0];
                    string v = s[1];

                    if (section == CcliSongFileSection.CONTENT)
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
                                foreach (var t in v.Split(new[] { "/t" }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    sng.Themes.Add(t.Trim());
                                }
                                break;

                            case "Keys":
                                sng.Key = v;
                                break;

                            case "Fields":
                                foreach (var t in v.Split(new[] { "/t" }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    fields.Add(t);
                                }
                                break;

                            case "Words":
                                foreach (var t in v.Split(new[] { "/t" }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    words.Add(t);
                                }
                                break;
                        }
                    }
                }
                else
                {
                    if (li == "[File]")
                    {
                        section = CcliSongFileSection.FILE;
                    }
                    else
                    {
                        Match m = Regex.Match(li, "^\\[S A([0-9]+)\\]$");
                        if (m.Success)
                        {
                            sng.ID = m.Groups[1].Value;
                            section = CcliSongFileSection.CONTENT;
                        }
                    }
                }
            }

            if (fields.Count == 0 || fields.Count != words.Count || sng.Title == null)
            {
                throw new IncompleteSongSourceFileException();
            }

            for (int fx = 0; fx < fields.Count; fx++)
            {
                SongSelectVerse p = new SongSelectVerse();
                p.Caption = fields[fx];
                foreach (var l in words[fx].Split(new[] { "/n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    p.Lines.Add(l);
                }
                sng.Verses.Add(p);
            }


            return sng;
        }

        /// <summary>
        /// Reads the title of a song from a file
        /// </summary>
        /// <param name="filename">Absolute path to the song file</param>
        /// <returns></returns>
        public String ReadTitle(string filename)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    return null;
                }

                CcliSongFileSection section = CcliSongFileSection.NONE;
                using (StreamReader sr = new StreamReader(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        string l = sr.ReadLine();
                        string li = l.Trim();
                        string[] s = li.Split(new[] { "=" }, StringSplitOptions.None);
                        if (s.Length > 1)
                        {
                            string k = s[0];
                            string v = s[1];

                            if (section == CcliSongFileSection.CONTENT && k == "Title")
                            {
                                sr.Close();
                                return v;
                            }
                        }
                        else
                        {
                            if (li == "[File]")
                            {
                                section = CcliSongFileSection.FILE;
                            }
                            else
                            {
                                Match m = Regex.Match(li, "^\\[S A([0-9]+)\\]$");
                                if (m.Success)
                                {
                                    section = CcliSongFileSection.CONTENT;
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
        /// Tests if a given file is supported by this reader
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool IsFileSupported(string filename)
        {
            try
            {
                bool versionOk = false;
                bool typeOk = false;

                using (StreamReader sr = new StreamReader(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        String l = sr.ReadLine();
                        string[] s = l.Split(new[] { "=" }, StringSplitOptions.None);
                        if (s.Length > 1)
                        {
                            string k = s[0];
                            string v = s[1].Trim();
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
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}