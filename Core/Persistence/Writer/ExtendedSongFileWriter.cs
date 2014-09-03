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
using System.Xml;
using Pbp.Model;
using Pbp.Model.Song;

namespace Pbp.Persistence.Writer
{
    public class ExtendedSongFileWriter : SongFileWriter
    {
        public string GetFileExtension() { return ".ppl"; }

        public string GetFileTypeDescription() { return "PowerPraise Lied"; }

        protected const string SupportedFileFormatVersion = "3.0";

        protected const string XmlRootNodeName = "ppl";

        public void Save(string filename, Song sng)
        {
            // Fonts and colors (default values are consitent with the PowerPraise default song template)
            TextFormatting mainText = sng.MainText != null ? sng.MainText : new TextFormatting(
                PowerPraiseConstants.MainText.Font,
                PowerPraiseConstants.MainText.Color,
                new TextOutline(PowerPraiseConstants.MainText.OutlineWidth, PowerPraiseConstants.FontOutline.Color),
                new TextShadow(10, PowerPraiseConstants.MainText.ShadowDistance, PowerPraiseConstants.FontShadow.Direction, PowerPraiseConstants.FontShadow.Color),
                PowerPraiseConstants.MainLineSpacing
            );
            TextFormatting translationText = sng.TranslationText != null ? sng.TranslationText : new TextFormatting(
                PowerPraiseConstants.TranslationText.Font,
                PowerPraiseConstants.TranslationText.Color,
                new TextOutline(PowerPraiseConstants.TranslationText.OutlineWidth, PowerPraiseConstants.FontOutline.Color),
                new TextShadow(10, PowerPraiseConstants.TranslationText.ShadowDistance, PowerPraiseConstants.FontShadow.Direction, PowerPraiseConstants.FontShadow.Color),
                PowerPraiseConstants.TranslationLineSpacing
            );
            TextFormatting copyrightText = sng.CopyrightText != null ? sng.CopyrightText : new TextFormatting(
                PowerPraiseConstants.CopyrightText.Font,
                PowerPraiseConstants.CopyrightText.Color,
                new TextOutline(PowerPraiseConstants.CopyrightText.OutlineWidth, PowerPraiseConstants.FontOutline.Color),
                new TextShadow(10, PowerPraiseConstants.CopyrightText.ShadowDistance, PowerPraiseConstants.FontShadow.Direction, PowerPraiseConstants.FontShadow.Color),
                PowerPraiseConstants.MainLineSpacing
            );
            TextFormatting sourceText = sng.SourceText != null ? sng.SourceText : new TextFormatting(
                PowerPraiseConstants.SourceText.Font,
                PowerPraiseConstants.SourceText.Color,
                new TextOutline(PowerPraiseConstants.SourceText.OutlineWidth, PowerPraiseConstants.FontOutline.Color),
                new TextShadow(10, PowerPraiseConstants.SourceText.ShadowDistance, PowerPraiseConstants.FontShadow.Direction, PowerPraiseConstants.FontShadow.Color),
                PowerPraiseConstants.MainLineSpacing
            );

            XmlWriterHelper xml = new XmlWriterHelper(XmlRootNodeName, SupportedFileFormatVersion);
            XmlElement xmlRoot = xml.Root;
            XmlDocument xmlDoc = xml.Doc;

            xmlRoot.AppendChild(xmlDoc.CreateElement("general"));
            xmlRoot["general"].AppendChild(xmlDoc.CreateElement("title"));
            xmlRoot["general"]["title"].InnerText = sng.Title;
            xmlRoot["general"].AppendChild(xmlDoc.CreateElement("category"));
            xmlRoot["general"]["category"].InnerText = sng.Themes.Count > 0 ? sng.Themes[0] : "Keine Kategorie";
            xmlRoot["general"].AppendChild(xmlDoc.CreateElement("language"));
            if (sng.Language != string.Empty)
            {
                xmlRoot["general"]["language"].InnerText = sng.Language;
            }

            //
            // Non-standard meta-info
            //
            // GUID
            if (sng.GUID != null && sng.GUID != Guid.Empty)
            {
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("guid"));
                xmlRoot["general"]["guid"].InnerText = sng.GUID.ToString();
            }

            // Comment
            if (sng.Comment != string.Empty)
            {
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("comment"));
                xmlRoot["general"]["comment"].InnerText = sng.Comment;
            }
            // QA-Issues
            if (sng.QualityIssues.Count > 0)
            {
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("qualityissues"));
                foreach (SongQualityAssuranceIndicator i in sng.QualityIssues)
                {
                    XmlNode qaChld = xmlRoot["general"]["qualityissues"].AppendChild(xmlDoc.CreateElement("issue"));
                    qaChld.InnerText = Enum.GetName(typeof(SongQualityAssuranceIndicator), i);
                }
            }

            // CCLI-ID
            if (sng.CcliID != null && sng.CcliID != String.Empty)
            {
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("ccliNo"));
                xmlRoot["general"]["ccliNo"].InnerText = sng.CcliID;
            }

            // Author(s)
            if (sng.Author != null && sng.Author.Count > 0)
            {
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("author"));
                xmlRoot["general"]["author"].InnerText = sng.AuthorString;
            }
            // Publisher
            if (sng.Publisher != null && sng.Publisher != String.Empty)
            {
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("publisher"));
                xmlRoot["general"]["publisher"].InnerText = sng.Publisher;
            }
            // Rights management
            if (sng.RightsManagement != null && sng.RightsManagement != String.Empty)
            {
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("admin"));
                xmlRoot["general"]["admin"].InnerText = sng.RightsManagement;
            }

            xmlRoot.AppendChild(xmlDoc.CreateElement("songtext"));

            var usedImages = new List<string>();
            foreach (SongPart prt in sng.Parts)
            {
                XmlElement tn = xmlDoc.CreateElement("part");
                tn.SetAttribute("caption", prt.Caption);
                foreach (SongSlide sld in prt.Slides)
                {
                    if (sld.ImageNumber > 0)
                    {
                        if (!usedImages.Contains(sng.RelativeImagePaths[sld.ImageNumber - 1]))
                        {
                            usedImages.Add(sng.RelativeImagePaths[sld.ImageNumber - 1]);
                        }
                        sld.ImageNumber = usedImages.IndexOf(sng.RelativeImagePaths[sld.ImageNumber - 1]) + 1;
                    }
                }
            }
            sng.RelativeImagePaths = usedImages;

            foreach (SongPart prt in sng.Parts)
            {
                XmlElement tn = xmlDoc.CreateElement("part");
                tn.SetAttribute("caption", prt.Caption);
                foreach (SongSlide sld in prt.Slides)
                {
                    XmlElement tn2 = xmlDoc.CreateElement("slide");
                    tn2.SetAttribute("mainsize", sld.TextSize > 0 ? sld.TextSize.ToString() : mainText.Font.Size.ToString());
                    tn2.SetAttribute("backgroundnr", (sld.ImageNumber - 1).ToString());

                    foreach (string ln in sld.Lines)
                    {
                        XmlElement tn3 = xmlDoc.CreateElement("line");
                        tn3.InnerText = ln;
                        tn2.AppendChild(tn3);
                    }
                    foreach (string ln in sld.Translation)
                    {
                        XmlElement tn3 = xmlDoc.CreateElement("translation");
                        tn3.InnerText = ln;
                        tn2.AppendChild(tn3);
                    }
                    tn.AppendChild(tn2);
                }
                xmlRoot["songtext"].AppendChild(tn);
            }
            sng.UpdateSearchText();

            xmlRoot.AppendChild(xmlDoc.CreateElement("order"));
            foreach (SongPart prt in sng.Parts)
            {
                XmlElement tn = xmlDoc.CreateElement("item");
                tn.InnerText = prt.Caption;
                xmlRoot["order"].AppendChild(tn);
            }

            xmlRoot.AppendChild(xmlDoc.CreateElement("information"));

            // Copyright
            xmlRoot["information"].AppendChild(xmlDoc.CreateElement("copyright"));
            xmlRoot["information"]["copyright"].AppendChild(xmlDoc.CreateElement("position"));
            xmlRoot["information"]["copyright"]["position"].InnerText = (sng.CopyrightPosition != null ? sng.CopyrightPosition : "lastslide");
            xmlRoot["information"]["copyright"].AppendChild(xmlDoc.CreateElement("text"));
            if (sng.Copyright != null)
            {
                xmlRoot["information"]["copyright"]["text"].AppendChild(xmlDoc.CreateElement("line"));
                xmlRoot["information"]["copyright"]["text"]["line"].InnerText = sng.Copyright;
            }

            xmlRoot["information"].AppendChild(xmlDoc.CreateElement("source"));
            xmlRoot["information"]["source"].AppendChild(xmlDoc.CreateElement("position"));
            xmlRoot["information"]["source"]["position"].InnerText = (sng.SourcePosition != null ? sng.SourcePosition : "firstslide");
            xmlRoot["information"]["source"].AppendChild(xmlDoc.CreateElement("text"));
            if (sng.SongBooks != null && sng.SongBooks.Count > 0)
            {
                xmlRoot["information"]["source"]["text"].AppendChild(xmlDoc.CreateElement("line"));
                xmlRoot["information"]["source"]["text"]["line"].InnerText = sng.SongBooksString;
            }

            //
            // Formatting
            //

            Dictionary<string, TextFormatting> fmtMapping = new Dictionary<string, TextFormatting>();
            fmtMapping.Add("maintext", mainText);
            fmtMapping.Add("translationtext", translationText);
            fmtMapping.Add("copyrighttext", copyrightText);
            fmtMapping.Add("sourcetext", sourceText);

            xmlRoot.AppendChild(xmlDoc.CreateElement("formatting"));
            xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("font"));

            foreach (var f in fmtMapping)
            {
                xmlRoot["formatting"]["font"].AppendChild(xmlDoc.CreateElement(f.Key));
                xmlRoot["formatting"]["font"][f.Key].AppendChild(xmlDoc.CreateElement("name"));
                xmlRoot["formatting"]["font"][f.Key]["name"].InnerText = f.Value.Font.Name;
                xmlRoot["formatting"]["font"][f.Key].AppendChild(xmlDoc.CreateElement("size"));
                xmlRoot["formatting"]["font"][f.Key]["size"].InnerText = f.Value.Font.Size.ToString();
                xmlRoot["formatting"]["font"][f.Key].AppendChild(xmlDoc.CreateElement("bold"));
                xmlRoot["formatting"]["font"][f.Key]["bold"].InnerText = (f.Value.Font.Bold).ToString().ToLower();
                xmlRoot["formatting"]["font"][f.Key].AppendChild(xmlDoc.CreateElement("italic"));
                xmlRoot["formatting"]["font"][f.Key]["italic"].InnerText = (f.Value.Font.Italic).ToString().ToLower();
                xmlRoot["formatting"]["font"][f.Key].AppendChild(xmlDoc.CreateElement("color"));
                xmlRoot["formatting"]["font"][f.Key]["color"].InnerText = (16777216 + f.Value.Color.ToArgb()).ToString();
                xmlRoot["formatting"]["font"][f.Key].AppendChild(xmlDoc.CreateElement("outline"));
                xmlRoot["formatting"]["font"][f.Key]["outline"].InnerText = f.Value.Outline.Width.ToString();
                xmlRoot["formatting"]["font"][f.Key].AppendChild(xmlDoc.CreateElement("shadow"));
                xmlRoot["formatting"]["font"][f.Key]["shadow"].InnerText = f.Value.Shadow.Distance.ToString();
            }

            // Outline
            xmlRoot["formatting"]["font"].AppendChild(xmlDoc.CreateElement("outline"));
            xmlRoot["formatting"]["font"]["outline"].AppendChild(xmlDoc.CreateElement("enabled"));
            xmlRoot["formatting"]["font"]["outline"]["enabled"].InnerText = sng.TextOutlineEnabled ? "true" : "false";
            xmlRoot["formatting"]["font"]["outline"].AppendChild(xmlDoc.CreateElement("color"));
            xmlRoot["formatting"]["font"]["outline"]["color"].InnerText = (16777216 + mainText.Outline.Color.ToArgb()).ToString();

            // Shadow
            xmlRoot["formatting"]["font"].AppendChild(xmlDoc.CreateElement("shadow"));
            xmlRoot["formatting"]["font"]["shadow"].AppendChild(xmlDoc.CreateElement("enabled"));
            xmlRoot["formatting"]["font"]["shadow"]["enabled"].InnerText = sng.TextShadowEnabled ? "true" : "false";
            xmlRoot["formatting"]["font"]["shadow"].AppendChild(xmlDoc.CreateElement("color"));
            xmlRoot["formatting"]["font"]["shadow"]["color"].InnerText = (16777216 + mainText.Shadow.Color.ToArgb()).ToString();
            xmlRoot["formatting"]["font"]["shadow"].AppendChild(xmlDoc.CreateElement("direction"));
            xmlRoot["formatting"]["font"]["shadow"]["direction"].InnerText = mainText.Shadow.Direction.ToString();

            // Backgrounds
            xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("background"));
            foreach (string imp in usedImages)
            {
                XmlElement tn = xmlDoc.CreateElement("file");
                tn.InnerText = imp;
                xmlRoot["formatting"]["background"].AppendChild(tn);
            }

            // Linespacing
            xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("linespacing"));
            xmlRoot["formatting"]["linespacing"].AppendChild(xmlDoc.CreateElement("main"));
            xmlRoot["formatting"]["linespacing"].AppendChild(xmlDoc.CreateElement("translation"));
            xmlRoot["formatting"]["linespacing"]["main"].InnerText = mainText.LineSpacing.ToString();
            xmlRoot["formatting"]["linespacing"]["translation"].InnerText = translationText.LineSpacing.ToString();

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
            SongTextBorders borders = sng.TextBorders != null ? sng.TextBorders : new SongTextBorders(
                PowerPraiseConstants.TextBorders.TextLeft,
                PowerPraiseConstants.TextBorders.TextTop,
                PowerPraiseConstants.TextBorders.TextRight,
                PowerPraiseConstants.TextBorders.TextBottom,
                PowerPraiseConstants.TextBorders.CopyrightBottom,
                PowerPraiseConstants.TextBorders.SourceTop,
                PowerPraiseConstants.TextBorders.SourceRight
            );
            xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("borders"));
            xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("mainleft"));
            xmlRoot["formatting"]["borders"]["mainleft"].InnerText = borders.TextLeft.ToString();
            xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("maintop"));
            xmlRoot["formatting"]["borders"]["maintop"].InnerText = borders.TextTop.ToString();
            xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("mainright"));
            xmlRoot["formatting"]["borders"]["mainright"].InnerText = borders.TextRight.ToString();
            xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("mainbottom"));
            xmlRoot["formatting"]["borders"]["mainbottom"].InnerText = borders.TextBottom.ToString();
            xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("copyrightbottom"));
            xmlRoot["formatting"]["borders"]["copyrightbottom"].InnerText = borders.CopyrightBottom.ToString();
            xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("sourcetop"));
            xmlRoot["formatting"]["borders"]["sourcetop"].InnerText = borders.SourceTop.ToString();
            xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("sourceright"));
            xmlRoot["formatting"]["borders"]["sourceright"].InnerText = borders.SourceRight.ToString();
        }
    }
}