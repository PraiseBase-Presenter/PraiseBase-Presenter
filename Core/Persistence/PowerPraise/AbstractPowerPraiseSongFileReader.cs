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

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public abstract class AbstractPowerPraiseSongFileReader<T> : ISongFileReader<T> where T : PersistentSong
    {
        public string GetFileExtension() { return ".ppl"; }

        public string GetFileTypeDescription() { return "PowerPraise Lied"; }

        protected const string SupportedFileFormatVersion = "3.0";

        protected const string XmlRootNodeName = "ppl";

        public abstract T Load(string filename);

        /// <summary>
        /// Parses additional fields (hook)
        /// </summary>
        /// <param name="xmlRoot"></param>
        /// <param name="sng"></param>
        protected abstract void parseAdditionalFields(XmlElement xmlRoot, PowerPraiseSong sng);

        protected void parse(string filename, PowerPraiseSong sng)
        {
            // Init xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlElement xmlRoot = xmlDoc.DocumentElement;

            if (xmlRoot.Name != XmlRootNodeName || xmlRoot.GetAttribute("version") != SupportedFileFormatVersion || xmlRoot["general"]["title"] == null)
            {
                throw new InvalidSongSourceFileException();
            }

            // Title
            sng.Title = xmlRoot["general"]["title"].InnerText;

            // Category
            sng.Category = parseString(xmlRoot["general"]["category"], PowerPraiseConstants.Category);

            // Language
            sng.Language = parseString(xmlRoot["general"]["language"], PowerPraiseConstants.Language);

            // Parse additional fields (hook)
            parseAdditionalFields(xmlRoot, sng);

            // Song text
            foreach (XmlElement elem in xmlRoot["songtext"])
            {
                if (elem.Name == "part")
                {
                    sng.Parts.Add(parseSongPart(elem, PowerPraiseConstants.SlideMainTextSize));
                }
            }

            // Order
            sng.Order.AddRange(parseOrder(xmlRoot["order"], sng));

            // Copyright text
            if (xmlRoot["information"] != null)
            {
                XmlElement copyrightElem = xmlRoot["information"]["copyright"];

                // Position
                sng.CopyrightTextPosition = parseCopyRightPosition(copyrightElem["position"], PowerPraiseConstants.CopyrightTextPosition);

                // Text
                sng.CopyrightText.AddRange(parseCopyRightText(copyrightElem["text"]));
            }

            // Source text
            if (xmlRoot["information"] != null)
            {
                XmlElement sourceElem = xmlRoot["information"]["source"];

                // Enabled
                sng.SourceTextEnabled = parseSourceEnabled(sourceElem["position"], PowerPraiseConstants.SourceTextEnabled);

                // Text
                sng.SourceText = parseSourceText(sourceElem["text"]);
            }

            XmlElement fontElem = xmlRoot["formatting"]["font"];

            // Font formatting
            sng.MainTextFontFormatting = parseTextFormatting(fontElem["maintext"], PowerPraiseConstants.MainText);
            sng.TranslationTextFontFormatting = parseTextFormatting(fontElem["translationtext"], PowerPraiseConstants.TranslationText);
            sng.CopyrightTextFontFormatting = parseTextFormatting(fontElem["copyrighttext"], PowerPraiseConstants.CopyrightText);
            sng.SourceTextFontFormatting = parseTextFormatting(fontElem["sourcetext"], PowerPraiseConstants.SourceText);

            // Font outline
            sng.TextOutlineFormatting = parseFontOutline(fontElem["outline"], PowerPraiseConstants.FontOutline);

            // Font shadow
            sng.TextShadowFormatting = parseFontShadow(fontElem["shadow"], PowerPraiseConstants.FontShadow);

            // Background images
            sng.BackgroundImages.AddRange(parseBackgroundImages(xmlRoot["formatting"]["background"]));
            // Ensure valid background IDs are used
            ensureValidBackgroundIDs(sng, sng.BackgroundImages.Count);

            // Line spacing
            XmlElement lineSpacingElem = xmlRoot["formatting"]["linespacing"];
            sng.MainLineSpacing = parseNaturalNumber(lineSpacingElem["main"], PowerPraiseConstants.MainLineSpacing);
            sng.TranslationLineSpacing = parseNaturalNumber(lineSpacingElem["translation"], PowerPraiseConstants.TranslationLineSpacing);

            XmlElement textOrientationElem = xmlRoot["formatting"]["textorientation"];

            // Text orientation
            sng.TextOrientation = parseOrientation(textOrientationElem, PowerPraiseConstants.TextOrientation);

            // Translation position
            sng.TranslationTextPosition = parseTranslationPosition(textOrientationElem, PowerPraiseConstants.TranslationPosition);

            // Borders
            sng.Borders = parseBorders(xmlRoot["formatting"]["borders"], PowerPraiseConstants.TextBorders);
        }

        /// <summary>
        /// Parses string. 
        /// 
        /// Value is only read if string is not emty.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private String parseString(XmlElement elem, String defaultValue)
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
        /// <returns></returns>
        private PowerPraiseSongPart parseSongPart(XmlElement elem, int defaultMainSize)
        {
            PowerPraiseSongPart part = new PowerPraiseSongPart();

            // Caption
            part.Caption = elem.GetAttribute("caption");

            // Slides
            foreach (XmlElement slideElem in elem)
            {
                if (slideElem.Name == "slide")
                {
                    part.Slides.Add(parseSongSlide(slideElem, defaultMainSize));
                }
            }

            return part;
        }

        /// <summary>
        /// Parses slide.
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        private PowerPraiseSongSlide parseSongSlide(XmlElement elem, int defaultMainSize)
        {
            PowerPraiseSongSlide slide = new PowerPraiseSongSlide();

            // Slide-specific text size
            slide.MainSize = defaultMainSize;
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
        private List<PowerPraiseSongPart> parseOrder(XmlElement xelem, PowerPraiseSong sng)
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
        private PowerPraiseSong.CopyrightPosition parseCopyRightPosition(XmlElement elem, PowerPraiseSong.CopyrightPosition defaultValue)
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
        private List<string> parseCopyRightText(XmlElement elem)
        {
            List<string> list = new List<string>();
            if (elem != null && elem.ChildNodes.Count > 0)
            {
                foreach (XmlNode xn in elem)
                {
                    list.Add(xn.InnerText);
                }
            }
            return list;
        }

        /// <summary>
        /// Parses if source text is enabled
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private bool parseSourceEnabled(XmlElement elem, bool defaultValue)
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
        private String parseSourceText(XmlElement elem)
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
        private PowerPraiseSong.FontFormatting parseTextFormatting(XmlElement elem, PowerPraiseSong.FontFormatting defaultValue)
        {
            PowerPraiseSong.FontFormatting f = defaultValue;
            if (elem != null)
            {
                int trySize;

                // Parse font
                int.TryParse(elem["size"].InnerText, out trySize);
                f.Font = new Font(
                    elem["name"].InnerText,
                    trySize > 0 ? trySize : f.Font.Size,
                    (FontStyle)
                    ((int)(elem["bold"].InnerText == "true" ? FontStyle.Bold : FontStyle.Regular) +
                     (int)(elem["italic"].InnerText == "true" ? FontStyle.Italic : FontStyle.Regular)));

                // Parse color
                int.TryParse(elem["color"].InnerText, out trySize);
                f.Color = Color.FromArgb(255, Color.FromArgb(trySize));

                // Parse outline width
                if (int.TryParse(elem["outline"].InnerText, out trySize))
                {
                    f.OutlineWidth = trySize;
                }

                // Parse shadow width
                if (int.TryParse(elem["shadow"].InnerText, out trySize))
                {
                    f.ShadowDistance = trySize;
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
        private PowerPraiseSong.OutlineFormatting parseFontOutline(XmlElement elem, PowerPraiseSong.OutlineFormatting defaultValue)
        {
            PowerPraiseSong.OutlineFormatting outline = defaultValue;
            if (elem != null)
            {
                outline.Enabled = (elem["enabled"] != null && elem["enabled"].InnerText == "true");
                int tryColor;
                if (int.TryParse(elem["color"].InnerText, out tryColor))
                {
                    outline.Color = Color.FromArgb(255, Color.FromArgb(tryColor));
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
        private PowerPraiseSong.ShadowFormatting parseFontShadow(XmlElement elem, PowerPraiseSong.ShadowFormatting defaultValue)
        {
            PowerPraiseSong.ShadowFormatting shadow = defaultValue;
            if (elem != null)
            {
                shadow.Enabled = (elem["enabled"] != null && elem["enabled"].InnerText == "true");
                int tryColor;
                if (int.TryParse(elem["color"].InnerText, out tryColor))
                {
                    shadow.Color = Color.FromArgb(255, Color.FromArgb(tryColor));
                }
                int shadowDirection;
                int.TryParse(elem["direction"].InnerText, out shadowDirection);
            }
            return shadow;
        }

        /// <summary>
        /// Parses background images and colors.
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        private List<string> parseBackgroundImages(XmlElement elem)
        {
            List<string> list = new List<string>();
            foreach (XmlElement e in elem)
            {
                if (e.Name == "file")
                {
                    list.Add(e.InnerText);
                }
            }
            return list;
        }

        /// <summary>
        /// Ensures valid background IDs are used.
        /// </summary>
        /// <param name="sng"></param>
        /// <param name="numBackgrounds"></param>
        private void ensureValidBackgroundIDs(PowerPraiseSong sng, int numBackgrounds)
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
        private int parseNaturalNumber(XmlElement elem, int defaultValue)
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
        private TextOrientation parseOrientation(XmlElement elem, TextOrientation defaultValue)
        {
            TextOrientation orientation = PowerPraiseConstants.TextOrientation;
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
        private PowerPraiseSong.TranslationPosition parseTranslationPosition(XmlElement elem, PowerPraiseSong.TranslationPosition defaultValue)
        {
            PowerPraiseSong.TranslationPosition position = PowerPraiseConstants.TranslationPosition;
            if (elem != null && elem["transpos"] != null)
            {
                if (elem["transpos"].InnerText == "inline")
                {
                    position = PowerPraiseSong.TranslationPosition.Inline;
                }
                else if (elem["transpos"].InnerText == "block")
                {
                    position = PowerPraiseSong.TranslationPosition.Block;
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
        private PowerPraiseSong.TextBorders parseBorders(XmlElement elem, PowerPraiseSong.TextBorders defaultValue)
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