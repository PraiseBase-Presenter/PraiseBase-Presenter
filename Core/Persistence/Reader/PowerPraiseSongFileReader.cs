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
using Pbp.Model.Song;
using Pbp.Model;

namespace Pbp.Persistence.Reader
{
    public class PowerPraiseSongFileReader : SongFileReader
    {
        public override string FileExtension { get { return ".ppl"; } }

        public override string FileTypeDescription { get { return "PowerPraise Lied"; } }

        protected const string SupportedFileFormatVersion = "3.0";

        protected const string XmlRootNodeName = "ppl";

        public override Song Load(string filename)
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
            sng.HorizontalTextOrientation = PowerPraiseConstants.HorizontalTextOrientation;
            sng.VerticalTextOrientation = PowerPraiseConstants.VerticalTextOrientation;
            if (xmlRoot["formatting"]["textorientation"] != null)
            {
                if (xmlRoot["formatting"]["textorientation"]["horizontal"] != null)
                {
                    switch (xmlRoot["formatting"]["textorientation"]["horizontal"].InnerText)
                    {
                        case "left":
                            sng.HorizontalTextOrientation = TextOrientationHorizontal.Left;
                            break;

                        case "center":
                            sng.HorizontalTextOrientation = TextOrientationHorizontal.Center;
                            break;

                        case "right":
                            sng.HorizontalTextOrientation = TextOrientationHorizontal.Right;
                            break;
                    }
                }
                if (xmlRoot["formatting"]["textorientation"]["vertical"] != null)
                {
                    switch (xmlRoot["formatting"]["textorientation"]["vertical"].InnerText)
                    {
                        case "top":
                            sng.VerticalTextOrientation = TextOrientationVertical.Top;
                            break;

                        case "center":
                            sng.VerticalTextOrientation = TextOrientationVertical.Middle;
                            break;

                        case "bottom":
                            sng.VerticalTextOrientation = TextOrientationVertical.Bottom;
                            break;
                    }
                }
            }

            // Default font settings if values in xml invalid
            sng.MainText = PowerPraiseConstants.MainText;
            sng.TranslationText = PowerPraiseConstants.TranslationText;
            sng.CopyrightText = PowerPraiseConstants.CopyrightText;
            sng.SourceText = PowerPraiseConstants.SourceText;

            Dictionary<string, TextFormatting> fmtMapping = new Dictionary<string,TextFormatting>();
            fmtMapping.Add("maintext", sng.MainText);
            fmtMapping.Add("translationtext", sng.TranslationText);
            fmtMapping.Add("copyrighttext", sng.CopyrightText);
            fmtMapping.Add("sourcetext", sng.SourceText);

            int tryColor;
            Color outlineColor = sng.MainText.Outline.Color;
            if (int.TryParse(xmlRoot["formatting"]["font"]["outline"]["color"].InnerText, out tryColor))
            {
                outlineColor = Color.FromArgb(255, Color.FromArgb(tryColor));
            }
            Color shadowColor = sng.MainText.Shadow.Color;
            if (int.TryParse(xmlRoot["formatting"]["font"]["shadow"]["color"].InnerText, out tryColor))
            {
                shadowColor = Color.FromArgb(255, Color.FromArgb(tryColor));
            }
            int shadowDirection = sng.MainText.Shadow.Direction;
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

            sng.TextBorders = PowerPraiseConstants.TextBorders;
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
        /// Tests if a given file is supported by this reader
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public override bool IsFileSupported(string filename)
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
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
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