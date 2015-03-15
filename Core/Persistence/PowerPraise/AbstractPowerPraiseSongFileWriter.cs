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
using System.Xml;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Persistence.PowerPraise
{
    public abstract class AbstractPowerPraiseSongFileWriter<T> : ISongFileWriter<T> where T : ISongFile
    {
        protected const string SupportedFileFormatVersion = "3.0";
        protected const string XmlRootNodeName = "ppl";

        public string GetFileExtension()
        {
            return ".ppl";
        }

        public string GetFileTypeDescription()
        {
            return "PowerPraise Lied";
        }

        public abstract void Save(string filename, T sng);

        /// <summary>
        ///     Parses additional fields (hook)
        /// </summary>
        /// <param name="xmlRoot"></param>
        /// <param name="sng"></param>
        protected abstract void writeAdditionalFields(XmlDocument xmlDoc, XmlElement xmlRoot, PowerPraiseSong sng);

        public void Write(string filename, PowerPraiseSong sng)
        {
            var xml = new XmlWriterHelper(XmlRootNodeName, SupportedFileFormatVersion);
            var xmlRoot = xml.Root;
            var xmlDoc = xml.Doc;

            xmlRoot.AppendChild(xmlDoc.CreateElement("general"));

            // Title
            xmlRoot["general"].AppendChild(xmlDoc.CreateElement("title"));
            xmlRoot["general"]["title"].InnerText = sng.Title;

            // Category
            xmlRoot["general"].AppendChild(xmlDoc.CreateElement("category"));
            xmlRoot["general"]["category"].InnerText = !String.IsNullOrEmpty(sng.Category)
                ? sng.Category
                : PowerPraiseConstants.NoCategory;

            // Language
            xmlRoot["general"].AppendChild(xmlDoc.CreateElement("language"));
            xmlRoot["general"]["language"].InnerText = !String.IsNullOrEmpty(sng.Language)
                ? sng.Language
                : PowerPraiseConstants.Language;

            // Write additional fields
            writeAdditionalFields(xmlDoc, xmlRoot, sng);

            xmlRoot.AppendChild(xmlDoc.CreateElement("songtext"));

            // Dictionary of backgrouns
            var bgIndex = 0;
            var backgrounds = new Dictionary<string, int>();

            // Song parts
            foreach (var prt in sng.Parts)
            {
                var tn = xmlDoc.CreateElement("part");

                // Caption
                tn.SetAttribute("caption", prt.Caption);

                foreach (var sld in prt.Slides)
                {
                    var tn2 = xmlDoc.CreateElement("slide");

                    // Slide-specific text size
                    var mainsize = sld.MainSize > 0 ? sld.MainSize : (int) sng.MainTextFontFormatting.Font.Size;
                    tn2.SetAttribute("mainsize", mainsize.ToString());

                    // Backgound number
                    var bg = MapBackground(sld.Background) ?? PowerPraiseConstants.DefaultBackground;
                    int backgroundNr;
                    if (!backgrounds.ContainsKey(bg))
                    {
                        backgroundNr = bgIndex;
                        backgrounds.Add(bg, bgIndex++);
                    }
                    else
                    {
                        backgroundNr = backgrounds[bg];
                    }
                    tn2.SetAttribute("backgroundnr", backgroundNr.ToString());

                    // Lyrics
                    foreach (var ln in sld.Lines)
                    {
                        var tn3 = xmlDoc.CreateElement("line");
                        tn3.InnerText = ln;
                        tn2.AppendChild(tn3);
                    }
                    foreach (var ln in sld.Translation)
                    {
                        var tn3 = xmlDoc.CreateElement("translation");
                        tn3.InnerText = ln;
                        tn2.AppendChild(tn3);
                    }
                    tn.AppendChild(tn2);
                }
                xmlRoot["songtext"].AppendChild(tn);
            }

            // Order
            xmlRoot.AppendChild(xmlDoc.CreateElement("order"));
            foreach (var prt in sng.Order)
            {
                var tn = xmlDoc.CreateElement("item");
                tn.InnerText = prt.Caption;
                xmlRoot["order"].AppendChild(tn);
            }

            xmlRoot.AppendChild(xmlDoc.CreateElement("information"));

            // Copyright
            xmlRoot["information"].AppendChild(xmlDoc.CreateElement("copyright"));

            // Copyright position
            xmlRoot["information"]["copyright"].AppendChild(xmlDoc.CreateElement("position"));
            var pos = "firstslide";
            switch (sng.CopyrightTextPosition)
            {
                case PowerPraiseSong.CopyrightPosition.FirstSlide:
                    pos = "firstslide";
                    break;
                case PowerPraiseSong.CopyrightPosition.LastSlide:
                    pos = "lastslide";
                    break;
                case PowerPraiseSong.CopyrightPosition.None:
                    pos = "none";
                    break;
            }
            xmlRoot["information"]["copyright"]["position"].InnerText = pos;

            // Copyright text
            xmlRoot["information"]["copyright"].AppendChild(xmlDoc.CreateElement("text"));
            if (sng.CopyrightText != null)
            {
                foreach (var l in sng.CopyrightText)
                {
                    var n = xmlRoot["information"]["copyright"]["text"].AppendChild(xmlDoc.CreateElement("line"));
                    n.InnerText = l;
                }
            }

            // Source
            xmlRoot["information"].AppendChild(xmlDoc.CreateElement("source"));

            // Source enabled
            xmlRoot["information"]["source"].AppendChild(xmlDoc.CreateElement("position"));
            xmlRoot["information"]["source"]["position"].InnerText = (sng.SourceTextEnabled ? "firstslide" : "none");

            // Source text
            xmlRoot["information"]["source"].AppendChild(xmlDoc.CreateElement("text"));
            xmlRoot["information"]["source"]["text"].AppendChild(xmlDoc.CreateElement("line"));
            xmlRoot["information"]["source"]["text"]["line"].InnerText = !String.IsNullOrEmpty(sng.SourceText)
                ? sng.SourceText
                : null;

            xmlRoot.AppendChild(xmlDoc.CreateElement("formatting"));
            xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("font"));

            // Font formatting
            applyFormatting(xmlDoc, xmlRoot["formatting"]["font"], "maintext", sng.MainTextFontFormatting);
            applyFormatting(xmlDoc, xmlRoot["formatting"]["font"], "translationtext", sng.TranslationTextFontFormatting);
            applyFormatting(xmlDoc, xmlRoot["formatting"]["font"], "copyrighttext", sng.CopyrightTextFontFormatting);
            applyFormatting(xmlDoc, xmlRoot["formatting"]["font"], "sourcetext", sng.SourceTextFontFormatting);

            // Outline
            xmlRoot["formatting"]["font"].AppendChild(xmlDoc.CreateElement("outline"));
            xmlRoot["formatting"]["font"]["outline"].AppendChild(xmlDoc.CreateElement("enabled"));
            xmlRoot["formatting"]["font"]["outline"]["enabled"].InnerText = sng.TextOutlineFormatting.Enabled
                ? "true"
                : "false";
            xmlRoot["formatting"]["font"]["outline"].AppendChild(xmlDoc.CreateElement("color"));
            xmlRoot["formatting"]["font"]["outline"]["color"].InnerText =
                PowerPraiseFileUtil.ConvertColor(sng.TextOutlineFormatting.Color).ToString();

            // Shadow
            xmlRoot["formatting"]["font"].AppendChild(xmlDoc.CreateElement("shadow"));
            xmlRoot["formatting"]["font"]["shadow"].AppendChild(xmlDoc.CreateElement("enabled"));
            xmlRoot["formatting"]["font"]["shadow"]["enabled"].InnerText = sng.TextShadowFormatting.Enabled
                ? "true"
                : "false";
            xmlRoot["formatting"]["font"]["shadow"].AppendChild(xmlDoc.CreateElement("color"));
            xmlRoot["formatting"]["font"]["shadow"]["color"].InnerText =
                PowerPraiseFileUtil.ConvertColor(sng.TextShadowFormatting.Color).ToString();
            xmlRoot["formatting"]["font"]["shadow"].AppendChild(xmlDoc.CreateElement("direction"));
            xmlRoot["formatting"]["font"]["shadow"]["direction"].InnerText =
                sng.TextShadowFormatting.Direction.ToString();

            // Backgrounds
            xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("background"));
            if (backgrounds.Count == 0)
            {
                backgrounds.Add(PowerPraiseConstants.DefaultBackground, 0);
            }
            foreach (string bg in backgrounds.Keys)
            {
                var tn = xmlDoc.CreateElement("file");
                tn.InnerText = bg;
                xmlRoot["formatting"]["background"].AppendChild(tn);
            }

            // Linespacing
            xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("linespacing"));
            xmlRoot["formatting"]["linespacing"].AppendChild(xmlDoc.CreateElement("main"));
            xmlRoot["formatting"]["linespacing"].AppendChild(xmlDoc.CreateElement("translation"));
            xmlRoot["formatting"]["linespacing"]["main"].InnerText =
                (sng.MainLineSpacing > 0 ? sng.MainLineSpacing : PowerPraiseConstants.MainLineSpacing).ToString();
            xmlRoot["formatting"]["linespacing"]["translation"].InnerText =
                (sng.MainLineSpacing > 0 ? sng.TranslationLineSpacing : PowerPraiseConstants.TranslationLineSpacing)
                    .ToString();

            // Orientation
            xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("textorientation"));

            xmlRoot["formatting"]["textorientation"].AppendChild(xmlDoc.CreateElement("horizontal"));
            switch (sng.TextOrientation != null ? sng.TextOrientation.Horizontal : HorizontalOrientation.Center)
            {
                case HorizontalOrientation.Left:
                    xmlRoot["formatting"]["textorientation"]["horizontal"].InnerText = "left";
                    break;

                case HorizontalOrientation.Center:
                    xmlRoot["formatting"]["textorientation"]["horizontal"].InnerText = "center";
                    break;

                case HorizontalOrientation.Right:
                    xmlRoot["formatting"]["textorientation"]["horizontal"].InnerText = "right";
                    break;
            }

            xmlRoot["formatting"]["textorientation"].AppendChild(xmlDoc.CreateElement("vertical"));
            switch (sng.TextOrientation != null ? sng.TextOrientation.Vertical : VerticalOrientation.Middle)
            {
                case VerticalOrientation.Top:
                    xmlRoot["formatting"]["textorientation"]["vertical"].InnerText = "top";
                    break;

                case VerticalOrientation.Middle:
                    xmlRoot["formatting"]["textorientation"]["vertical"].InnerText = "center";
                    break;

                case VerticalOrientation.Bottom:
                    xmlRoot["formatting"]["textorientation"]["vertical"].InnerText = "bottom";
                    break;
            }
            xmlRoot["formatting"]["textorientation"].AppendChild(xmlDoc.CreateElement("transpos"));
            xmlRoot["formatting"]["textorientation"]["transpos"].InnerText = "inline";

            // Borders
            xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("borders"));
            xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("mainleft"));
            xmlRoot["formatting"]["borders"]["mainleft"].InnerText = sng.Borders.TextLeft.ToString();
            xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("maintop"));
            xmlRoot["formatting"]["borders"]["maintop"].InnerText = sng.Borders.TextTop.ToString();
            xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("mainright"));
            xmlRoot["formatting"]["borders"]["mainright"].InnerText = sng.Borders.TextRight.ToString();
            xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("mainbottom"));
            xmlRoot["formatting"]["borders"]["mainbottom"].InnerText = sng.Borders.TextBottom.ToString();
            xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("copyrightbottom"));
            xmlRoot["formatting"]["borders"]["copyrightbottom"].InnerText = sng.Borders.CopyrightBottom.ToString();
            xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("sourcetop"));
            xmlRoot["formatting"]["borders"]["sourcetop"].InnerText = sng.Borders.SourceTop.ToString();
            xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("sourceright"));
            xmlRoot["formatting"]["borders"]["sourceright"].InnerText = sng.Borders.SourceRight.ToString();

            xml.Write(filename);
        }

        private void applyFormatting(XmlDocument xmlDoc, XmlElement elem, String key, PowerPraiseSong.FontFormatting f)
        {
            elem.AppendChild(xmlDoc.CreateElement(key));
            elem[key].AppendChild(xmlDoc.CreateElement("name"));
            elem[key]["name"].InnerText = f.Font.Name;
            elem[key].AppendChild(xmlDoc.CreateElement("size"));
            elem[key]["size"].InnerText = ((int) f.Font.Size).ToString();
            elem[key].AppendChild(xmlDoc.CreateElement("bold"));
            elem[key]["bold"].InnerText = (f.Font.Bold).ToString().ToLower();
            elem[key].AppendChild(xmlDoc.CreateElement("italic"));
            elem[key]["italic"].InnerText = (f.Font.Italic).ToString().ToLower();
            elem[key].AppendChild(xmlDoc.CreateElement("color"));
            elem[key]["color"].InnerText = PowerPraiseFileUtil.ConvertColor(f.Color).ToString();
            elem[key].AppendChild(xmlDoc.CreateElement("outline"));
            elem[key]["outline"].InnerText = f.OutlineWidth.ToString();
            elem[key].AppendChild(xmlDoc.CreateElement("shadow"));
            elem[key]["shadow"].InnerText = f.ShadowDistance.ToString();
        }

        private static string MapBackground(IBackground bg)
        {
            if (bg != null)
            {
                if (bg.GetType() == typeof(ImageBackground))
                {
                    return ((ImageBackground)bg).ImagePath;
                }
                if (bg.GetType() == typeof(ColorBackground))
                {
                    return PowerPraiseFileUtil.ConvertColor(((ColorBackground)bg).Color).ToString();
                }
            }
            return null;
        }
    }
}