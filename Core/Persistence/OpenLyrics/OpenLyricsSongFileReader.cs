﻿/*
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
 *   Author:
 *      Nicolas Perrenoud <nicu_at_lavine.ch>
 *   Co-authors:
 *      ...
 *
 */

using System;
using System.Xml;

namespace PraiseBase.Presenter.Persistence.OpenLyrics
{
    public class OpenLyricsSongFileReader : ISongFileReader<OpenLyricsSong>
    {
        protected const string SupportedFileFormatVersion = "0.8";

        protected const string XmlRootNodeName = "song";

        public OpenLyricsSong Load(string filename)
        {
            OpenLyricsSong sng = new OpenLyricsSong();

            // Init xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlElement xmlRoot = xmlDoc.DocumentElement;

            // Check for correct root node and version
            if (xmlRoot.Name != XmlRootNodeName || xmlRoot.GetAttribute("version") != SupportedFileFormatVersion)
            {
                throw new InvalidSongSourceFileException();
            }

            //
            // File attributes
            //

            // Modified date
            if (xmlRoot.Attributes["modifiedDate"] != null)
            {
                sng.ModifiedTimestamp = xmlRoot.Attributes["modifiedDate"].InnerText;
            }

            // Application the song was created in
            if (xmlRoot.Attributes["createdIn"] != null)
            {
                sng.CreatedIn = xmlRoot.Attributes["createdIn"].InnerText;
            }

            // Application the song was modified in
            if (xmlRoot.Attributes["modifiedIn"] != null)
            {
                sng.ModifiedIn = xmlRoot.Attributes["modifiedIn"].InnerText;
            }

            //
            // Properties
            //

            // Check if properties sections exists
            if (xmlRoot["properties"] == null
                || xmlRoot["properties"]["titles"] == null
                || xmlRoot["properties"]["titles"]["title"] == null)
            {
                throw new IncompleteSongSourceFileException();
            }

            // Title
            sng.Title = xmlRoot["properties"]["titles"]["title"].InnerText;

            // Application the song was modified in
            if (xmlRoot["properties"]["ccliNo"] != null)
            {
                sng.CcliID = xmlRoot["properties"]["ccliNo"].InnerText;
            }

            // Application the song was modified in
            if (xmlRoot["properties"]["copyright"] != null)
            {
                sng.Copyright = xmlRoot["properties"]["copyright"].InnerText;
            }

            // Application the song was modified in
            if (xmlRoot["properties"]["released"] != null)
            {
                sng.ReleaseYear = xmlRoot["properties"]["released"].InnerText;
            }

            // Comments
            if (xmlRoot["properties"]["comments"] != null)
            {
                foreach (XmlNode commentNode in xmlRoot["properties"]["comments"])
                {
                    if (commentNode.Name == "comment")
                    {
                        sng.Comments.Add(commentNode.InnerText);
                    }
                }
            }

            //
            // Lyrics
            //

            // Check if lyrics sections exists
            if (xmlRoot["lyrics"] == null)
            {
                throw new IncompleteSongSourceFileException();
            }

            foreach (XmlNode verseNode in xmlRoot["lyrics"])
            {
                if (verseNode.Name == "verse")
                {
                    OpenLyricsSongVerse verse = new OpenLyricsSongVerse();
                    if (verseNode.Attributes["name"] != null)
                    {
                        verse.Name = verseNode.Attributes["name"].InnerText;
                    }
                    if (verseNode.Attributes["lang"] != null)
                    {
                        verse.Language = verseNode.Attributes["lang"].InnerText;
                    }

                    foreach (XmlNode linesNode in verseNode.ChildNodes)
                    {
                        if (linesNode.Name == "lines")
                        {
                            OpenLyricsSongLines line = new OpenLyricsSongLines();
                            if (linesNode.Attributes["part"] != null)
                            {
                                line.Part = linesNode.Attributes["part"].InnerText;
                            }
                            string lineText = string.Empty;
                            foreach (XmlNode l in linesNode)
                            {
                                if (l.NodeType == XmlNodeType.Text)
                                {
                                    lineText += l.InnerText;
                                }
                                else if (l.NodeType == XmlNodeType.Element && l.Name == "br")
                                {
                                    line.Text.Add(lineText);
                                    lineText = string.Empty;
                                }
                            }
                            line.Text.Add(lineText);
                            verse.Lines.Add(line);
                        }
                    }
                    if (verse.Lines.Count > 0)
                    {
                        sng.Verses.Add(verse);
                    }
                }
            }

            // Check if at leas one part exists
            if (sng.Verses.Count == 0)
            {
                throw new IncompleteSongSourceFileException();
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
                if (!System.IO.File.Exists(filename))
                {
                    return null;
                }
                string parentNode = String.Empty;
                XmlTextReader t = new XmlTextReader(filename);
                while (t.Read())
                {
                    if (t.NodeType == XmlNodeType.Element)
                    {
                        if (t.Name == XmlRootNodeName)
                        {
                            parentNode = t.Name;
                        }
                        else if (parentNode == XmlRootNodeName && t.Name == "properties")
                        {
                            parentNode = t.Name;
                        }
                        else if (parentNode == "properties" && t.Name == "titles")
                        {
                            parentNode = t.Name;
                        }
                        else if (parentNode == "titles" && t.Name == "title")
                        {
                            parentNode = t.Name;
                        }
                    }
                    else if (t.NodeType == XmlNodeType.Text && parentNode == "title")
                    {
                        string title = t.ReadContentAsString();
                        t.Close();
                        return title;
                    }
                }
                t.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
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
                XmlTextReader t = new XmlTextReader(filename);
                while (t.Read())
                {
                    if (t.NodeType == XmlNodeType.Element)
                    {
                        if (t.Name == XmlRootNodeName)
                        {
                            if (t.GetAttribute("version").ToString() == SupportedFileFormatVersion)
                            {
                                t.Close();
                                return true;
                            }
                            else
                            {
                                t.Close();
                                return false;
                            }
                        }
                        else
                        {
                            t.Close();
                            return false;
                        }
                    }
                }
                t.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}