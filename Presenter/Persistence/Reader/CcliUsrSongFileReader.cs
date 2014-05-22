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
using System.Drawing;
using System.Xml;
using Pbp.Properties;
using Pbp.Model.Song;
using System.IO;
using System.Text.RegularExpressions;
using Pbp.Model;

namespace Pbp.Persistence.Reader
{
    public class CcliUsrSongFileReader : SongFileReader
    {
        public override string FileExtension { get { return ".usr"; } }

        public override string FileTypeDescription { get { return "SongSelect Import File"; } }

        protected const string SupportedFileFormatVersion = "3.0";

        protected const string TypeString = "SongSelect Import File";

        public override Song Load(string filename)
        {
            Song sng = new Song();

            // Default font settings if values in xml invalid
            sng.MainText = new TextFormatting(
                Settings.Default.ProjectionMasterFont,
                Settings.Default.ProjectionMasterFontColor,
                new TextOutline(30, Color.Black),
                new TextShadow(10, 20, 125, Color.Black),
                Settings.Default.ProjectionMasterLineSpacing);

            sng.TranslationText = new TextFormatting(
                Settings.Default.ProjectionMasterFontTranslation,
                Settings.Default.ProjectionMasterTranslationColor,
                new TextOutline(30, Color.Black),
                new TextShadow(10, 20, 125, Color.Black),
                Settings.Default.ProjectionMasterLineSpacing);

            sng.CopyrightText = new TextFormatting(
                Settings.Default.ProjectionMasterFontTranslation,
                Settings.Default.ProjectionMasterTranslationColor,
                new TextOutline(30, Color.Black),
                new TextShadow(10, 20, 125, Color.Black),
                Settings.Default.ProjectionMasterLineSpacing);

            sng.SourceText = new TextFormatting(
               Settings.Default.ProjectionMasterFontTranslation,
               Settings.Default.ProjectionMasterTranslationColor,
               new TextOutline(30, Color.Black),
               new TextShadow(10, 20, 125, Color.Black),
               Settings.Default.ProjectionMasterLineSpacing);

            List<String> fields = new List<string>();
            List<String> words = new List<string>();

            String section = string.Empty;

            string[] lines = System.IO.File.ReadAllLines(@filename);
            foreach (string l in lines)
            {
                string li = l.Trim();
                string[] s = li.Split(new [] { "="}, StringSplitOptions.None);
                if (s.Length > 1)
                {
                    string k = s[0];
                    string v = s[1];

                    if (section == "content")
                    {
                        switch (k)
                        {
                            case "Title":
                                sng.Title = v;
                                break;
                            case "Author":
                                var a = new SongAuthor();
                                a.Name = v;
                                sng.Author = new List<SongAuthor>();
                                sng.Author.Add(a);
                                break;
                            case "Copyright":
                                sng.Copyright = v;
                                break;
                            case "Admin":
                                sng.RightsManagement = v;
                                break;
                            case "Themes":
                                foreach (var t in v.Split(new[] { "/t" }, StringSplitOptions.None))
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
                        section = "file";
                    }
                    else
                    {
                        Match m = Regex.Match(li, "^\\[S A([0-9]+)\\]$");
                        if (m.Success)
                        {
                            sng.CcliID = m.Groups[1].Value;
                            sng.CCliIDReadonly = true;
                            section = "content";
                        }
                    }
                }
            }

            if (fields.Count == 0 || fields.Count != words.Count || sng.Title == null)
            {
                throw new IncompleteSongSourceFileException();
            }

            for (int fx=0; fx < fields.Count; fx++)
            {
                SongPart p = new SongPart();
                p.Caption = fields[fx];
                SongSlide s = new SongSlide(sng);
                foreach (var l in words[fx].Split(new[] { "/n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    s.Lines.Add(l);
                }
                p.Slides.Add(s);
                sng.Parts.Add(p);
            }

            sng.UpdateSearchText();
            return sng;
        }

        /// <summary>
        /// Tests if a given file is supported by this reader
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public override bool IsFileSupported(string filename)
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
                                        return false;
                                    }
                                    versionOk = true;
                                    break;
                                case "Type":
                                    if (v != TypeString)
                                    {
                                        return false;
                                    }
                                    typeOk = true;
                                    break;
                                default:
                                    if (versionOk && typeOk)
                                    {
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