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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;
using PraiseBase.Presenter.Model;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public abstract class AbstractPowerPraiseSongFileReader<T> : ISongFileReader<T> where T : ISongFile
    {
        protected const string SupportedFileFormatVersion = "3.0";

        protected const string XmlRootNodeName = "ppl";

        public abstract T Load(string filename);

        /// <summary>
        /// Parses additional fields (hook)
        /// </summary>
        /// <param name="xmlRoot"></param>
        /// <param name="sng"></param>
        protected abstract void ParseAdditionalFields(XmlElement xmlRoot, PowerPraiseSong sng);

        protected void Parse(string filename, PowerPraiseSong sng)
        {
            // Init xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlElement xmlRoot = xmlDoc.DocumentElement;

            if (xmlRoot == null || xmlRoot.Name != XmlRootNodeName || xmlRoot.GetAttribute("version") != SupportedFileFormatVersion || xmlRoot["general"] == null || xmlRoot["general"]["title"] == null)
            {
                throw new InvalidSongSourceFileException();
            }

            // Title
            sng.Title = xmlRoot["general"]["title"].InnerText;

            // Category
            sng.Category = ParseString(xmlRoot["general"]["category"], PowerPraiseConstants.NoCategory);

            // Language
            sng.Language = ParseString(xmlRoot["general"]["language"], PowerPraiseConstants.Language);

            // Parse additional fields (hook)
            ParseAdditionalFields(xmlRoot, sng);

            // Song text
            foreach (XmlElement elem in xmlRoot["songtext"])
            {
                if (elem.Name == "part")
                {
                    sng.Parts.Add(ParseSongPart(elem, PowerPraiseConstants.SlideMainTextSize));
                }
            }

            // Order
            sng.Order.AddRange(ParseOrder(xmlRoot["order"], sng));

            // Copyright text
            if (xmlRoot["information"] != null)
            {
                XmlElement copyrightElem = xmlRoot["information"]["copyright"];

                if (copyrightElem != null)
                {
                    // Position
                    sng.CopyrightTextPosition = ParseCopyRightPosition(copyrightElem["position"], PowerPraiseConstants.CopyrightTextPosition);

                    // Text
                    sng.CopyrightText.AddRange(ParseCopyRightText(copyrightElem["text"]));
                }
            }

            // Source text
            if (xmlRoot["information"] != null)
            {
                XmlElement sourceElem = xmlRoot["information"]["source"];

                if (sourceElem != null)
                {
                    // Enabled
                    sng.SourceTextEnabled = ParseSourceEnabled(sourceElem["position"], PowerPraiseConstants.SourceTextEnabled);

                    // Text
                    sng.SourceText = ParseSourceText(sourceElem["text"]);
                }
            }

            XmlElement fontElem = xmlRoot["formatting"]["font"];

            // Font formatting
            sng.MainTextFontFormatting = ParseTextFormatting(fontElem["maintext"], PowerPraiseConstants.MainText);
            sng.TranslationTextFontFormatting = ParseTextFormatting(fontElem["translationtext"], PowerPraiseConstants.TranslationText);
            sng.CopyrightTextFontFormatting = ParseTextFormatting(fontElem["copyrighttext"], PowerPraiseConstants.CopyrightText);
            sng.SourceTextFontFormatting = ParseTextFormatting(fontElem["sourcetext"], PowerPraiseConstants.SourceText);

            // Font outline
            sng.TextOutlineFormatting = ParseFontOutline(fontElem["outline"], PowerPraiseConstants.FontOutline);

            // Font shadow
            sng.TextShadowFormatting = ParseFontShadow(fontElem["shadow"], PowerPraiseConstants.FontShadow);

            // Background images
            sng.BackgroundImages.AddRange(ParseBackgroundImages(xmlRoot["formatting"]["background"]));
            // Ensure valid background IDs are used
            EnsureValidBackgroundIDs(sng, sng.BackgroundImages.Count);

            // Line spacing
            XmlElement lineSpacingElem = xmlRoot["formatting"]["linespacing"];
            if (lineSpacingElem != null)
            {
                sng.MainLineSpacing = ParseNaturalNumber(lineSpacingElem["main"], PowerPraiseConstants.MainLineSpacing);
                sng.TranslationLineSpacing = ParseNaturalNumber(lineSpacingElem["translation"], PowerPraiseConstants.TranslationLineSpacing);
            }

            XmlElement textOrientationElem = xmlRoot["formatting"]["textorientation"];

            // Text orientation
            sng.TextOrientation = ParseOrientation(textOrientationElem, PowerPraiseConstants.TextOrientation);

            // Translation position
            sng.TranslationTextPosition = ParseTranslationPosition(textOrientationElem, PowerPraiseConstants.TranslationPosition);

            // Borders
            sng.Borders = ParseBorders(xmlRoot["formatting"]["borders"], PowerPraiseConstants.TextBorders);
        }

        /// <summary>
        /// Parses string. 
        /// 
        /// Value is only read if string is not emty.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private String ParseString(XmlElement elem, String defaultValue)
        {
            String val = defaultValue;
            if (elem != null)
            {
                String str = elem.InnerText;
                if (!String.IsNullOrEmpty(str))
                {
                    val = str;
                }
            }
            return val;
        }

        /// <summary>
        /// Parses song part.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultMainSize"></param>
        /// <returns></returns>
        private PowerPraiseSongPart ParseSongPart(XmlElement elem, int defaultMainSize)
        {
            PowerPraiseSongPart part = new PowerPraiseSongPart
            {
                // Caption
                Caption = elem.GetAttribute("caption")
            };

            // Slides
            foreach (XmlElement slideElem in elem.Cast<XmlElement>().Where(slideElem => slideElem.Name == "slide"))
            {
                part.Slides.Add(ParseSongSlide(slideElem, defaultMainSize));
            }

            return part;
        }

        /// <summary>
        /// Parses slide.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultMainSize"></param>
        /// <returns></returns>
        private PowerPraiseSongSlide ParseSongSlide(XmlElement elem, int defaultMainSize)
        {
            PowerPraiseSongSlide slide = new PowerPraiseSongSlide
            {
                MainSize = defaultMainSize
            };

            // Slide-specific text size
            if (elem.HasAttribute("mainsize"))
            {
                int trySize;
                if (int.TryParse(elem.GetAttribute("mainsize"), out trySize))
                {
                    slide.MainSize = trySize;
                }
            }

            // Image number
            slide.BackgroundNr = Convert.ToInt32(elem.GetAttribute("backgroundnr"));

            // Lyrics
            foreach (XmlElement lineElem in elem)
            {
                if (lineElem.Name == "line")
                {
                    slide.Lines.Add(lineElem.InnerText);
                }
                if (lineElem.Name == "translation")
                {
                    slide.Translation.Add(lineElem.InnerText);
                }
            }

            return slide;
        }

        /// <summary>
        /// Parses song part oder
        /// </summary>
        /// <param name="xelem"></param>
        /// <param name="sng"></param>
        /// <returns></returns>
        private List<PowerPraiseSongPart> ParseOrder(XmlElement xelem, PowerPraiseSong sng)
        {
            List<PowerPraiseSongPart> list = new List<PowerPraiseSongPart>();
            foreach (XmlElement elem in xelem)
            {
                if (elem.Name == "item")
                {
                    if (!String.IsNullOrEmpty(elem.InnerText))
                    {
                        string val = elem.InnerText.Trim();
                        foreach (var part in sng.Parts)
                        {
                            if (part.Caption == val)
                            {
                                list.Add(part);
                                break;
                            }
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Parses copyright position.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private PowerPraiseSong.CopyrightPosition ParseCopyRightPosition(XmlElement elem, PowerPraiseSong.CopyrightPosition defaultValue)
        {
            PowerPraiseSong.CopyrightPosition position = defaultValue;
            if (elem != null)
            {
                if (elem.InnerText == "firstslide")
                {
                    position = PowerPraiseSong.CopyrightPosition.FirstSlide;
                }
                else if (elem.InnerText == "lastslide")
                {
                    position = PowerPraiseSong.CopyrightPosition.LastSlide;
                }
                else if (elem.InnerText == "none")
                {
                    position = PowerPraiseSong.CopyrightPosition.None;
                }
            }
            return position;
        }

        /// <summary>
        /// Parses copyright text.
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        private List<string> ParseCopyRightText(XmlElement elem)
        {
            List<string> list = new List<string>();
            if (elem != null && elem.ChildNodes.Count > 0)
            {
                list.AddRange(from XmlNode xn in elem select xn.InnerText);
            }
            return list;
        }

        /// <summary>
        /// Parses if source text is enabled
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private bool ParseSourceEnabled(XmlElement elem, bool defaultValue)
        {
            bool enabled = defaultValue;
            if (elem != null)
            {
                if (elem.InnerText == "firstslide")
                {
                    enabled = true;
                }
                else if (elem.InnerText == "none")
                {
                    enabled = false;
                }
            }
            return enabled;
        }

        /// <summary>
        /// Parses source text.
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        private String ParseSourceText(XmlElement elem)
        {
            if (elem != null && elem.ChildNodes.Count > 0)
            {
                return elem.InnerText;
            }
            return String.Empty;
        }

        /// <summary>
        /// Parses text formatting.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private PowerPraiseSong.FontFormatting ParseTextFormatting(XmlElement elem, PowerPraiseSong.FontFormatting defaultValue)
        {
            PowerPraiseSong.FontFormatting f = defaultValue;
            if (elem != null)
            {
                // Parse font
                var nameElement = elem["name"];
                var sizeElement = elem["size"];
                var boldElement = elem["bold"];
                var italicElement = elem["italic"];
                if (nameElement != null && sizeElement != null && boldElement != null && italicElement != null)
                {
                    int fontSize;
                    int.TryParse(sizeElement.InnerText, out fontSize);
                    f.Font = new Font(
                        nameElement.InnerText,
                        fontSize > 0 ? fontSize : f.Font.Size,
                        (FontStyle)
                        ((int)(boldElement.InnerText == "true" ? FontStyle.Bold : FontStyle.Regular) +
                         (int)(italicElement.InnerText == "true" ? FontStyle.Italic : FontStyle.Regular))
                    );
                }

                // Parse color
                var colorElement = elem["color"];
                int colorNumber;
                if (colorElement != null && int.TryParse(colorElement.InnerText, out colorNumber))
                {
                    f.Color = PowerPraiseFileUtil.ConvertColor(colorNumber);
                }

                // Parse outline width
                var outlineElement = elem["outline"];
                int outlineSize;
                if (outlineElement != null && int.TryParse(outlineElement.InnerText, out outlineSize))
                {
                    f.OutlineWidth = outlineSize;
                }

                // Parse shadow width
                var shadowElement = elem["shadow"];
                int shadowDistance;
                if (shadowElement != null && int.TryParse(shadowElement.InnerText, out shadowDistance))
                {
                    f.ShadowDistance = shadowDistance;
                }
            }
            return f;
        }

        /// <summary>
        /// Parses font outline.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private PowerPraiseSong.OutlineFormatting ParseFontOutline(XmlElement elem, PowerPraiseSong.OutlineFormatting defaultValue)
        {
            PowerPraiseSong.OutlineFormatting outline = defaultValue;
            if (elem != null)
            {
                outline.Enabled = (elem["enabled"] != null && elem["enabled"].InnerText == "true");
                int tryColor;
                var xmlElement = elem["color"];
                if (xmlElement != null && int.TryParse(xmlElement.InnerText, out tryColor))
                {
                    outline.Color = PowerPraiseFileUtil.ConvertColor(tryColor);
                }
            }
            return outline;
        }

        /// <summary>
        /// Parses font shadow.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private PowerPraiseSong.ShadowFormatting ParseFontShadow(XmlElement elem, PowerPraiseSong.ShadowFormatting defaultValue)
        {
            PowerPraiseSong.ShadowFormatting shadow = defaultValue;
            if (elem != null)
            {
                shadow.Enabled = (elem["enabled"] != null && elem["enabled"].InnerText == "true");
                
                int tryColor;
                var xmlElement = elem["color"];
                if (xmlElement != null && int.TryParse(xmlElement.InnerText, out tryColor))
                {
                    shadow.Color = PowerPraiseFileUtil.ConvertColor(tryColor);
                }
                
                int shadowDirection;
                var element = elem["direction"];
                if (element != null && int.TryParse(element.InnerText, out shadowDirection))
                {
                    shadow.Direction = shadowDirection;
                }
            }
            return shadow;
        }

        /// <summary>
        /// Parses background images and colors.
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        private static List<string> ParseBackgroundImages(XmlElement elem)
        {
            return (from XmlElement e in elem where e.Name == "file" select e.InnerText).ToList();
        }

        /// <summary>
        /// Ensures valid background IDs are used.
        /// </summary>
        /// <param name="sng"></param>
        /// <param name="numBackgrounds"></param>
        private void EnsureValidBackgroundIDs(PowerPraiseSong sng, int numBackgrounds)
        {
            foreach (var part in sng.Parts)
            {
                foreach (var slide in part.Slides)
                {
                    slide.BackgroundNr = Math.Min(numBackgrounds - 1, Math.Max(0, slide.BackgroundNr));
                }
            }
        }

        /// <summary>
        /// Parses a natural number (integer, greater than 0).
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private int ParseNaturalNumber(XmlElement elem, int defaultValue)
        {
            int val = defaultValue;
            if (elem != null)
            {
                int trySize;
                if (int.TryParse(elem.InnerText, out trySize) && trySize > 0)
                {
                    val = trySize;
                }
            }
            return val;
        }

        /// <summary>
        /// Parses text orientation.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private TextOrientation ParseOrientation(XmlElement elem, TextOrientation defaultValue)
        {
            TextOrientation orientation = new TextOrientation(defaultValue.Vertical, defaultValue.Horizontal);
            if (elem != null)
            {
                if (elem["horizontal"] != null)
                {
                    switch (elem["horizontal"].InnerText)
                    {
                        case "left":
                            orientation.Horizontal = HorizontalOrientation.Left;
                            break;

                        case "center":
                            orientation.Horizontal = HorizontalOrientation.Center;
                            break;

                        case "right":
                            orientation.Horizontal = HorizontalOrientation.Right;
                            break;
                    }
                }
                if (elem["vertical"] != null)
                {
                    switch (elem["vertical"].InnerText)
                    {
                        case "top":
                            orientation.Vertical = VerticalOrientation.Top;
                            break;

                        case "center":
                            orientation.Vertical = VerticalOrientation.Middle;
                            break;

                        case "bottom":
                            orientation.Vertical = VerticalOrientation.Bottom;
                            break;
                    }
                }
            }
            return orientation;
        }

        /// <summary>
        /// Parses translation position
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private static TranslationPosition ParseTranslationPosition(XmlNode elem, TranslationPosition defaultValue)
        {
            TranslationPosition position = defaultValue;
            if (elem != null && elem["transpos"] != null)
            {
                if (elem["transpos"].InnerText == "inline")
                {
                    position = TranslationPosition.Inline;
                }
                else if (elem["transpos"].InnerText == "block")
                {
                    position = TranslationPosition.Block;
                }
            }
            return position;
        }

        /// <summary>
        /// Parses border sizes.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private static PowerPraiseSong.TextBorders ParseBorders(XmlElement elem, PowerPraiseSong.TextBorders defaultValue)
        {
            PowerPraiseSong.TextBorders borders = defaultValue;
            if (elem != null)
            {
                int trySize;
                if (elem["mainleft"] != null && int.TryParse(elem["mainleft"].InnerText, out trySize))
                {
                    borders.TextLeft = trySize;
                }
                if (elem["maintop"] != null && int.TryParse(elem["maintop"].InnerText, out trySize))
                {
                    borders.TextTop = trySize;
                }
                if (elem["mainright"] != null && int.TryParse(elem["mainright"].InnerText, out trySize))
                {
                    borders.TextRight = trySize;
                }
                if (elem["mainbottom"] != null && int.TryParse(elem["mainbottom"].InnerText, out trySize))
                {
                    borders.TextBottom = trySize;
                }
                if (elem["copyrightbottom"] != null && int.TryParse(elem["copyrightbottom"].InnerText, out trySize))
                {
                    borders.CopyrightBottom = trySize;
                }
                if (elem["sourcetop"] != null && int.TryParse(elem["sourcetop"].InnerText, out trySize))
                {
                    borders.SourceTop = trySize;
                }
                if (elem["sourceright"] != null && int.TryParse(elem["sourceright"].InnerText, out trySize))
                {
                    borders.SourceRight = trySize;
                }
            }
            return borders;
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
                XmlTextReader t = new XmlTextReader(filename);
                while (t.Read())
                {
                    if (t.NodeType == XmlNodeType.Element)
                    {
                        if (t.Name == XmlRootNodeName)
                        {
                            var attribute = t.GetAttribute("version");
                            if (attribute != null && attribute == SupportedFileFormatVersion)
                            {
                                t.Close();
                                return true;
                            }
                            t.Close();
                            return false;
                        }
                        t.Close();
                        return false;
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