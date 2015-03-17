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
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public abstract class AbstractPowerPraiseSongFileReader<T> : ISongFileReader<T> where T : ISongFile
    {
        protected const string SupportedFileFormatVersion = "3.0";
        protected const string XmlRootNodeName = "ppl";
        public abstract T Load(string filename);

        private List<IBackground> _backgrounds;

        /// <summary>
        ///     Reads the title of a song from a file
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
                var parentNode = String.Empty;
                var t = new XmlTextReader(filename);
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
                        var title = t.ReadContentAsString();
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
        ///     Tests if a given file is supported by this reader
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool IsFileSupported(string filename)
        {
            try
            {
                var t = new XmlTextReader(filename);
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

        /// <summary>
        ///     Parses additional fields (hook)
        /// </summary>
        /// <param name="xmlRoot"></param>
        /// <param name="sng"></param>
        protected abstract void ParseAdditionalFields(XmlElement xmlRoot, PowerPraiseSong sng);

        protected void Parse(string filename, PowerPraiseSong sng)
        {
            // Init xml
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            var xmlRoot = xmlDoc.DocumentElement;

            if (xmlRoot == null || xmlRoot.Name != XmlRootNodeName ||
                xmlRoot.GetAttribute("version") != SupportedFileFormatVersion || xmlRoot["general"] == null ||
                xmlRoot["general"]["title"] == null)
            {
                throw new InvalidSongSourceFileException("Song header missing");
            }

            // Title
            sng.Title = xmlRoot["general"]["title"].InnerText;

            // Category
            sng.Category = ParseString(xmlRoot["general"]["category"], PowerPraiseConstants.NoCategory);

            // Language
            sng.Language = ParseString(xmlRoot["general"]["language"], PowerPraiseConstants.Language);

            // Parse additional fields (hook)
            ParseAdditionalFields(xmlRoot, sng);

            // Background images
            if (xmlRoot["formatting"] != null && xmlRoot["formatting"]["background"] != null)
            {
                _backgrounds = ParseBackgroundImages(xmlRoot["formatting"]["background"]);
            }
            else
            {
                _backgrounds = new List<IBackground>();
            }

            //
            // Song text and part order
            //

            if (xmlRoot["songtext"] == null)
            {
                throw new InvalidSongSourceFileException("Song parts missing");
            }

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

            //
            // Information
            //

            if (xmlRoot["information"] != null)
            {
                // Copyright text
                var copyrightElem = xmlRoot["information"]["copyright"];
                if (copyrightElem != null)
                {
                    // Position
                    sng.CopyrightTextPosition = ParseCopyRightPosition(copyrightElem["position"],
                        PowerPraiseConstants.CopyrightTextPosition);

                    // Text
                    sng.CopyrightText.AddRange(ParseCopyRightText(copyrightElem["text"]));
                }

                // Source text
                var sourceElem = xmlRoot["information"]["source"];
                if (sourceElem != null)
                {
                    // Enabled
                    sng.SourceTextEnabled = ParseSourceEnabled(sourceElem["position"],
                        PowerPraiseConstants.SourceTextEnabled);

                    // Text
                    sng.SourceText = ParseSourceText(sourceElem["text"]);
                }
            }

            //
            // Formatting
            //

            var formatting = xmlRoot["formatting"];
            if (formatting == null)
            {
                throw new InvalidSongSourceFileException("Formatting definition missing");
            }
            
            var fontElem = formatting["font"];
            var lineSpacingElem = formatting["linespacing"];
            var textOrientationElem = formatting["textorientation"];
            var borderElem = formatting["borders"];
            if (fontElem == null || lineSpacingElem == null || textOrientationElem == null || borderElem == null)
            {
                throw new InvalidSongSourceFileException("Formatting definition incomplete");
            }

            sng.Formatting = new PowerPraiseSongFormatting
            {
                // Font formatting
                MainText = ParseTextFormatting(fontElem["maintext"], PowerPraiseConstants.Format.MainText),
                TranslationText = ParseTextFormatting(fontElem["translationtext"], PowerPraiseConstants.Format.TranslationText),
                CopyrightText = ParseTextFormatting(fontElem["copyrighttext"], PowerPraiseConstants.Format.CopyrightText),
                SourceText = ParseTextFormatting(fontElem["sourcetext"], PowerPraiseConstants.Format.SourceText),

                // Font outline
                Outline = ParseFontOutline(fontElem["outline"], PowerPraiseConstants.Format.Outline),

                // Font shadow
                Shadow = ParseFontShadow(fontElem["shadow"], PowerPraiseConstants.Format.Shadow),

                // Line spacing
                MainLineSpacing = ParseNaturalNumber(lineSpacingElem["main"], PowerPraiseConstants.Format.MainLineSpacing),
                TranslationLineSpacing = ParseNaturalNumber(lineSpacingElem["translation"], PowerPraiseConstants.Format.TranslationLineSpacing),

                // Text orientation
                TextOrientation = ParseOrientation(textOrientationElem, PowerPraiseConstants.Format.TextOrientation),

                // Translation position
                TranslationPosition = ParseTranslationPosition(textOrientationElem, PowerPraiseConstants.Format.TranslationPosition),

                // Borders
                Borders = ParseBorders(borderElem)
            };
        }

        /// <summary>
        ///     Parses string.
        ///     Value is only read if string is not emty.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private String ParseString(XmlElement elem, String defaultValue)
        {
            var val = defaultValue;
            if (elem != null)
            {
                var str = elem.InnerText;
                if (!String.IsNullOrEmpty(str))
                {
                    val = str;
                }
            }
            return val;
        }

        /// <summary>
        ///     Parses song part.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultMainSize"></param>
        /// <returns></returns>
        private PowerPraiseSong.Part ParseSongPart(XmlElement elem, int defaultMainSize)
        {
            var part = new PowerPraiseSong.Part
            {
                // Caption
                Caption = elem.GetAttribute("caption")
            };

            // Slides
            foreach (var slideElem in elem.Cast<XmlElement>().Where(slideElem => slideElem.Name == "slide"))
            {
                part.Slides.Add(ParseSongSlide(slideElem, defaultMainSize));
            }

            return part;
        }

        /// <summary>
        ///     Parses slide.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultMainSize"></param>
        /// <returns></returns>
        private PowerPraiseSong.Slide ParseSongSlide(XmlElement elem, int defaultMainSize)
        {
            var slide = new PowerPraiseSong.Slide
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
            int num = Convert.ToInt32(elem.GetAttribute("backgroundnr"));
            if (num >= 0 && num < _backgrounds.Count)
            {
                slide.Background = _backgrounds[num];
            }

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
        ///     Parses song part oder
        /// </summary>
        /// <param name="xelem"></param>
        /// <param name="sng"></param>
        /// <returns></returns>
        private List<PowerPraiseSong.Part> ParseOrder(XmlElement xelem, PowerPraiseSong sng)
        {
            var list = new List<PowerPraiseSong.Part>();
            if (xelem != null && xelem.ChildNodes.Count > 0)
            {
                foreach (XmlElement elem in xelem)
                {
                    if (elem.Name == "item")
                    {
                        if (!String.IsNullOrEmpty(elem.InnerText))
                        {
                            var val = elem.InnerText.Trim();
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
            }
            else
            {
                list.AddRange(sng.Parts);
            }
            return list;
        }

        /// <summary>
        ///     Parses copyright position.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private PowerPraiseSong.CopyrightPosition ParseCopyRightPosition(XmlElement elem,
            PowerPraiseSong.CopyrightPosition defaultValue)
        {
            var position = defaultValue;
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
        ///     Parses copyright text.
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        private List<string> ParseCopyRightText(XmlElement elem)
        {
            var list = new List<string>();
            if (elem != null && elem.ChildNodes.Count > 0)
            {
                list.AddRange(from XmlNode xn in elem select xn.InnerText);
            }
            return list;
        }

        /// <summary>
        ///     Parses if source text is enabled
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private bool ParseSourceEnabled(XmlElement elem, bool defaultValue)
        {
            var enabled = defaultValue;
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
        ///     Parses source text.
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
        ///     Parses text formatting.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private PowerPraiseSongFormatting.FontFormatting ParseTextFormatting(XmlElement elem,
            PowerPraiseSongFormatting.FontFormatting defaultValue)
        {
            var f = defaultValue;
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
                            ((int) (boldElement.InnerText == "true" ? FontStyle.Bold : FontStyle.Regular) +
                             (int) (italicElement.InnerText == "true" ? FontStyle.Italic : FontStyle.Regular))
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
        ///     Parses font outline.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private PowerPraiseSongFormatting.OutlineFormatting ParseFontOutline(XmlElement elem,
            PowerPraiseSongFormatting.OutlineFormatting defaultValue)
        {
            var outline = defaultValue;
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
        ///     Parses font shadow.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private PowerPraiseSongFormatting.ShadowFormatting ParseFontShadow(XmlElement elem,
            PowerPraiseSongFormatting.ShadowFormatting defaultValue)
        {
            var shadow = defaultValue;
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
        ///     Parses background images and colors.
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        private static List<IBackground> ParseBackgroundImages(XmlElement elem)
        {
            List<IBackground> list = new ComparableList<IBackground>();
            list.AddRange(from XmlElement e in elem where e.Name == "file" select PowerPraiseFileUtil.ParseBackground(e.InnerText));
            return list;
        }

        /// <summary>
        ///     Parses a natural number (integer, greater than 0).
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private int ParseNaturalNumber(XmlElement elem, int defaultValue)
        {
            var val = defaultValue;
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
        ///     Parses text orientation.
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private TextOrientation ParseOrientation(XmlElement elem, TextOrientation defaultValue)
        {
            var orientation = new TextOrientation(defaultValue.Vertical, defaultValue.Horizontal);
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
        ///     Parses translation position
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private static TranslationPosition ParseTranslationPosition(XmlNode elem, TranslationPosition defaultValue)
        {
            var position = defaultValue;
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
        ///     Parses border sizes.
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        private static PowerPraiseSongFormatting.TextBorders ParseBorders(XmlElement elem)
        {
            return new PowerPraiseSongFormatting.TextBorders
            {
                TextLeft = elem["mainleft"] != null ? ParseIntValue(elem["mainleft"]) : 0,
                TextTop = elem["maintop"] != null ? ParseIntValue(elem["maintop"]) : 0,
                TextRight = elem["mainright"] != null ? ParseIntValue(elem["mainright"]) : 0,
                TextBottom = elem["mainbottom"] != null ? ParseIntValue(elem["mainbottom"]) : 0,
                CopyrightBottom = elem["copyrightbottom"] != null ? ParseIntValue(elem["copyrightbottom"]) : 0,
                SourceTop = elem["sourcetop"] != null ? ParseIntValue(elem["sourcetop"]) : 0,
                SourceRight = elem["sourceright"] != null ? ParseIntValue(elem["sourceright"]) : 0
            };
        }

        private static int ParseIntValue(XmlElement elem, int defaultValue = 0)
        {
            int trySize;
            if (int.TryParse(elem.InnerText, out trySize))
            {
                return trySize;
            }
            return defaultValue;
        }
    }
}