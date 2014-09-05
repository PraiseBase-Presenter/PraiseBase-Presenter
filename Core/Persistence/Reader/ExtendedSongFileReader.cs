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
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.Reader
{
    public class ExtendedSongFileReader : SongFileReader
    {
        public string GetFileExtension() { return ".ppl"; }

        public string GetFileTypeDescription() { return "PowerPraise Lied"; }

        protected const string SupportedFileFormatVersion = "3.0";

        protected const string XmlRootNodeName = "ppl";

        public Song Load(string filename)
        {
            Song sng = new Song();

            // Init xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlElement xmlRoot = xmlDoc.DocumentElement;

            if (xmlRoot.Name != XmlRootNodeName || xmlRoot.GetAttribute("version") != SupportedFileFormatVersion)
            {
                throw new InvalidSongSourceFileException();
            }

            //
            // General stuff
            //

            // Title
            sng.Title = xmlRoot["general"]["title"].InnerText;

            // Language
            if (xmlRoot["general"]["language"] != null)
            {
                sng.Language = xmlRoot["general"]["language"].InnerText;
            }
            else
            {
                sng.Language = "Deutsch";
            }

            // Category (Tag)
            if (xmlRoot["general"]["category"] != null)
            {
                sng.Themes.Add(xmlRoot["general"]["category"].InnerText);
            }

            // Comment
            if (xmlRoot["general"]["comment"] != null)
            {
                sng.Comment = xmlRoot["general"]["comment"].InnerText;
            }
            else
            {
                sng.Comment = "";
            }

            // Quality issues
            if (xmlRoot["general"]["qualityissues"] != null)
            {
                foreach (XmlElement elem in xmlRoot["general"]["qualityissues"])
                {
                    if (elem.Name == "issue")
                    {
                        foreach (SongQualityAssuranceIndicator i in sng.QualityIssues)
                        {
                            if (elem.InnerText == Enum.GetName(typeof(SongQualityAssuranceIndicator), i))
                            {
                                sng.QualityIssues.Add(i);
                            }
                        }
                    }
                }
            }

            // CCLI Song ID
            if (xmlRoot["general"]["ccliNo"] != null)
            {
                sng.CcliID = xmlRoot["general"]["ccliNo"].InnerText;
            }

            // Author(s)
            if (xmlRoot["general"]["author"] != null)
            {
                sng.AuthorString = xmlRoot["general"]["author"].InnerText;
            }
            // Publisher
            if (xmlRoot["general"]["publisher"] != null)
            {
                sng.Publisher = xmlRoot["general"]["publisher"].InnerText;
            }
            // Rights management
            if (xmlRoot["general"]["admin"] != null)
            {
                sng.RightsManagement = xmlRoot["general"]["admin"].InnerText;
            }

            // Guid
            if (xmlRoot["general"]["guid"] != null)
            {
                sng.GUID = new Guid(xmlRoot["general"]["guid"].InnerText);
            }

            //
            // Formatting
            //

            // Text orientation
            sng.TextOrientation = new TextOrientation(VerticalOrientation.Middle, HorizontalOrientation.Center);
            if (xmlRoot["formatting"]["textorientation"] != null
                && xmlRoot["formatting"]["textorientation"]["horizontal"] != null 
                && xmlRoot["formatting"]["textorientation"]["vertical"] != null)
            {
                    switch (xmlRoot["formatting"]["textorientation"]["horizontal"].InnerText)
                    {
                        case "left":
                            sng.TextOrientation.Horizontal = HorizontalOrientation.Left;
                            break;

                        case "center":
                            sng.TextOrientation.Horizontal = HorizontalOrientation.Center;
                            break;

                        case "right":
                            sng.TextOrientation.Horizontal = HorizontalOrientation.Right;
                            break;
                    }
                    switch (xmlRoot["formatting"]["textorientation"]["vertical"].InnerText)
                    {
                        case "top":
                            sng.TextOrientation.Vertical = VerticalOrientation.Top;
                            break;

                        case "center":
                            sng.TextOrientation.Vertical = VerticalOrientation.Middle;
                            break;

                        case "bottom":
                            sng.TextOrientation.Vertical = VerticalOrientation.Bottom;
                            break;
                    }
            }

            // Default font settings if values in xml invalid
            sng.MainText = new TextFormatting(
                PowerPraiseConstants.MainText.Font,
                PowerPraiseConstants.MainText.Color,
                new TextOutline(PowerPraiseConstants.MainText.OutlineWidth, PowerPraiseConstants.FontOutline.Color),
                new TextShadow(10, PowerPraiseConstants.MainText.ShadowDistance, PowerPraiseConstants.FontShadow.Direction, PowerPraiseConstants.FontShadow.Color),
                PowerPraiseConstants.MainLineSpacing
            );
            sng.TranslationText = new TextFormatting(
                PowerPraiseConstants.TranslationText.Font,
                PowerPraiseConstants.TranslationText.Color,
                new TextOutline(PowerPraiseConstants.TranslationText.OutlineWidth, PowerPraiseConstants.FontOutline.Color),
                new TextShadow(10, PowerPraiseConstants.TranslationText.ShadowDistance, PowerPraiseConstants.FontShadow.Direction, PowerPraiseConstants.FontShadow.Color),
                PowerPraiseConstants.TranslationLineSpacing
            );
            sng.CopyrightText = new TextFormatting(
                PowerPraiseConstants.CopyrightText.Font,
                PowerPraiseConstants.CopyrightText.Color,
                new TextOutline(PowerPraiseConstants.CopyrightText.OutlineWidth, PowerPraiseConstants.FontOutline.Color),
                new TextShadow(10, PowerPraiseConstants.CopyrightText.ShadowDistance, PowerPraiseConstants.FontShadow.Direction, PowerPraiseConstants.FontShadow.Color),
                PowerPraiseConstants.MainLineSpacing
            );
            sng.SourceText = new TextFormatting(
                PowerPraiseConstants.SourceText.Font,
                PowerPraiseConstants.SourceText.Color,
                new TextOutline(PowerPraiseConstants.SourceText.OutlineWidth, PowerPraiseConstants.FontOutline.Color),
                new TextShadow(10, PowerPraiseConstants.SourceText.ShadowDistance, PowerPraiseConstants.FontShadow.Direction, PowerPraiseConstants.FontShadow.Color),
                PowerPraiseConstants.MainLineSpacing
            );

            Dictionary<string, TextFormatting> fmtMapping = new Dictionary<string, TextFormatting>();
            fmtMapping.Add("maintext", sng.MainText);
            fmtMapping.Add("translationtext", sng.TranslationText);
            fmtMapping.Add("copyrighttext", sng.CopyrightText);
            fmtMapping.Add("sourcetext", sng.SourceText);

            int tryColor;
            Color outlineColor = Color.Black;
            if (int.TryParse(xmlRoot["formatting"]["font"]["outline"]["color"].InnerText, out tryColor))
            {
                outlineColor = Color.FromArgb(255, Color.FromArgb(tryColor));
            }
            Color shadowColor = Color.Black;
            if (int.TryParse(xmlRoot["formatting"]["font"]["shadow"]["color"].InnerText, out tryColor))
            {
                shadowColor = Color.FromArgb(255, Color.FromArgb(tryColor));
            }
            int shadowDirection = 125;
            int.TryParse(xmlRoot["formatting"]["font"]["shadow"]["direction"].InnerText, out shadowDirection);

            // Iterate over all font formatting definitions
            foreach (var f in fmtMapping)
            {
                if (xmlRoot["formatting"]["font"][f.Key] != null)
                {
                    int trySize;
                    XmlElement tmpElem = xmlRoot["formatting"]["font"];

                    // Parse font
                    int.TryParse(tmpElem[f.Key]["size"].InnerText, out trySize);
                    f.Value.Font = new Font(
                        tmpElem[f.Key]["name"].InnerText,
                        trySize > 0 ? trySize : f.Value.Font.Size,
                        (FontStyle)
                        ((int)(tmpElem[f.Key]["bold"].InnerText == "true" ? FontStyle.Bold : FontStyle.Regular) +
                         (int)(tmpElem[f.Key]["italic"].InnerText == "true" ? FontStyle.Italic : FontStyle.Regular)));

                    // Parse color
                    int.TryParse(tmpElem[f.Key]["color"].InnerText, out trySize);
                    f.Value.Color = Color.FromArgb(255, Color.FromArgb(trySize));

                    // Parse outline width
                    if (int.TryParse(tmpElem[f.Key]["outline"].InnerText, out trySize))
                    {
                        f.Value.Outline.Width = trySize;
                    }
                    // Parse shadow width
                    if (int.TryParse(tmpElem[f.Key]["shadow"].InnerText, out trySize))
                    {
                        f.Value.Shadow.Distance = trySize;
                    }
                    f.Value.Outline.Color = outlineColor;
                    f.Value.Shadow.Color = shadowColor;
                    f.Value.Shadow.Direction = shadowDirection;
                }
            }

            // Enable or disable outline/shadow
            sng.TextOutlineEnabled = (xmlRoot["formatting"]["font"]["outline"]["enabled"] != null && xmlRoot["formatting"]["font"]["outline"]["enabled"].InnerText == "true");
            sng.TextShadowEnabled = (xmlRoot["formatting"]["font"]["shadow"]["enabled"] != null && xmlRoot["formatting"]["font"]["shadow"]["enabled"].InnerText == "true");

            // Linespacing
            if (xmlRoot["formatting"]["linespacing"]["main"] != null)
            {
                int trySize;
                if (int.TryParse(xmlRoot["formatting"]["linespacing"]["main"].InnerText, out trySize) && trySize > 0)
                {
                    sng.MainText.LineSpacing = trySize;
                }
            }
            if (xmlRoot["formatting"]["linespacing"]["translation"] != null)
            {
                int trySize;
                if (int.TryParse(xmlRoot["formatting"]["linespacing"]["translation"].InnerText, out trySize) && trySize > 0)
                {
                    sng.TranslationText.LineSpacing = trySize;
                }
            }

            sng.TextBorders = new SongTextBorders(
                PowerPraiseConstants.TextBorders.TextLeft,
                PowerPraiseConstants.TextBorders.TextTop,
                PowerPraiseConstants.TextBorders.TextRight,
                PowerPraiseConstants.TextBorders.TextBottom,
                PowerPraiseConstants.TextBorders.CopyrightBottom,
                PowerPraiseConstants.TextBorders.SourceTop,
                PowerPraiseConstants.TextBorders.SourceRight
            );
            if (xmlRoot["formatting"]["borders"] != null)
            {
                int trySize;
                if (xmlRoot["formatting"]["borders"]["mainleft"] != null && int.TryParse(xmlRoot["formatting"]["borders"]["mainleft"].InnerText, out trySize))
                {
                    sng.TextBorders.TextLeft = trySize;
                }
                if (xmlRoot["formatting"]["borders"]["maintop"] != null && int.TryParse(xmlRoot["formatting"]["borders"]["maintop"].InnerText, out trySize))
                {
                    sng.TextBorders.TextTop = trySize;
                }
                if (xmlRoot["formatting"]["borders"]["mainright"] != null && int.TryParse(xmlRoot["formatting"]["borders"]["mainright"].InnerText, out trySize))
                {
                    sng.TextBorders.TextRight = trySize;
                }
                if (xmlRoot["formatting"]["borders"]["mainbottom"] != null && int.TryParse(xmlRoot["formatting"]["borders"]["mainbottom"].InnerText, out trySize))
                {
                    sng.TextBorders.TextBottom = trySize;
                }
                if (xmlRoot["formatting"]["borders"]["copyrightbottom"] != null && int.TryParse(xmlRoot["formatting"]["borders"]["copyrightbottom"].InnerText, out trySize))
                {
                    sng.TextBorders.CopyrightBottom = trySize;
                }
                if (xmlRoot["formatting"]["borders"]["sourcetop"] != null && int.TryParse(xmlRoot["formatting"]["borders"]["sourcetop"].InnerText, out trySize))
                {
                    sng.TextBorders.SourceTop = trySize;
                }
                if (xmlRoot["formatting"]["borders"]["sourceright"] != null && int.TryParse(xmlRoot["formatting"]["borders"]["sourceright"].InnerText, out trySize))
                {
                    sng.TextBorders.SourceRight = trySize;
                }
            }

            //
            // ... and the images
            //

            foreach (XmlElement elem in xmlRoot["formatting"]["background"])
            {
                if (elem.Name == "file")
                {
                    sng.RelativeImagePaths.Add(elem.InnerText);
                }
            }

            //
            // Information
            //

            if (xmlRoot["information"] != null)
            {
                // Read copyright text
                if (xmlRoot["information"]["copyright"] != null)
                {
                    if (xmlRoot["information"]["copyright"]["text"] != null && xmlRoot["information"]["copyright"]["text"].ChildNodes.Count > 0)
                    {
                        sng.Copyright = String.Empty;
                        foreach (XmlNode xn in xmlRoot["information"]["copyright"]["text"])
                        {
                            if (sng.Copyright != String.Empty)
                            {
                                sng.Copyright += " ";
                            }
                            sng.Copyright += xn.InnerText;
                        }
                    }
                    if (xmlRoot["information"]["copyright"]["position"] != null)
                    {
                        sng.CopyrightPosition = xmlRoot["information"]["copyright"]["position"].InnerText;
                    }
                }

                // Read sourcesource text
                if (xmlRoot["information"]["source"] != null)
                {
                    if (xmlRoot["information"]["source"]["text"] != null && xmlRoot["information"]["source"]["text"].ChildNodes.Count > 0)
                    {
                        sng.SongBooksString = xmlRoot["information"]["source"]["text"].InnerText;
                    }
                    if (xmlRoot["information"]["source"]["position"] != null)
                    {
                        sng.SourcePosition = xmlRoot["information"]["source"]["position"].InnerText;
                    }
                }
            }

            //
            // Now the song text ...
            //
            foreach (XmlElement elem in xmlRoot["songtext"])
            {
                if (elem.Name == "part")
                {
                    var tmpPart = new SongPart();
                    tmpPart.Caption = elem.GetAttribute("caption");
                    foreach (XmlElement slideElem in elem)
                    {
                        if (slideElem.Name == "slide")
                        {
                            var tmpSlide = new SongSlide(sng);
                            tmpSlide.Lines = new List<string>();

                            // Image number
                            int bgNr = Convert.ToInt32(slideElem.GetAttribute("backgroundnr")) + 1;
                            bgNr = bgNr < 0 ? 0 : bgNr;
                            bgNr = bgNr > sng.RelativeImagePaths.Count ? sng.RelativeImagePaths.Count : bgNr;
                            tmpSlide.ImageNumber = bgNr;

                            // Lyrics
                            foreach (XmlElement lineElem in slideElem)
                            {
                                if (lineElem.Name == "line")
                                {
                                    tmpSlide.Lines.Add(lineElem.InnerText);
                                }
                                if (lineElem.Name == "translation")
                                {
                                    tmpSlide.Translation.Add(lineElem.InnerText);
                                }
                            }

                            // Slide-specific text size
                            tmpSlide.TextSize = sng.MainText.Font.Size;
                            if (slideElem.HasAttribute("mainsize"))
                            {
                                float trySize;
                                if (float.TryParse(slideElem.GetAttribute("mainsize"), out trySize))
                                {
                                    tmpSlide.TextSize = trySize;
                                }
                            }

                            sng.Slides.Add(tmpSlide);
                            tmpPart.Slides.Add(tmpSlide);
                        }
                    }
                    sng.Parts.Add(tmpPart);
                }
            }
            sng.UpdateSearchText();
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
                        else if (parentNode == XmlRootNodeName && t.Name == "general")
                        {
                            parentNode = t.Name;
                        }
                        else if (parentNode == "general" && t.Name == "title")
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