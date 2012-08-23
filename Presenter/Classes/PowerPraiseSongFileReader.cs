using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Drawing;
using Pbp.Properties;

namespace Pbp
{
    public class PowerPraiseSongFileReader : SongFileReader
    {
        public const string FileFormatVersion = "3.0";

        public override Song load(string filename)
        {
            Song sng = new Song();

            // Init xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlElement xmlRoot = xmlDoc.DocumentElement;

            if (xmlRoot.Name != "ppl" || xmlRoot.GetAttribute("version") != "3.0")
            {
                throw new Exception("Invalid file type!");
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
                sng.Tags.Add(xmlRoot["general"]["category"].InnerText);
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
                        foreach (QualityAssuranceIndicators i in sng.QualityIssues)
                        {
                            if (elem.InnerText == Enum.GetName(typeof(QualityAssuranceIndicators), i))
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

            //
            // Formatting
            //

            // Text orientation
            if (xmlRoot["formatting"]["textorientation"] != null)
            {
                if (xmlRoot["formatting"]["textorientation"]["horizontal"] != null)
                {
                    switch (xmlRoot["formatting"]["textorientation"]["horizontal"].InnerText)
                    {
                        case "left":
                            sng.DefaultHorizAlign = Song.SongTextHorizontalAlign.Left;
                            break;
                        case "center":
                            sng.DefaultHorizAlign = Song.SongTextHorizontalAlign.Center;
                            break;
                        case "right":
                            sng.DefaultHorizAlign = Song.SongTextHorizontalAlign.Right;
                            break;
                    }
                }
                if (xmlRoot["formatting"]["textorientation"]["vertical"] != null)
                {
                    switch (xmlRoot["formatting"]["textorientation"]["vertical"].InnerText)
                    {
                        case "top":
                            sng.DefaultVertAlign = Song.SongTextVerticalAlign.Top;
                            break;
                        case "center":
                            sng.DefaultVertAlign = Song.SongTextVerticalAlign.Center;
                            break;
                        case "bottom":
                            sng.DefaultVertAlign = Song.SongTextVerticalAlign.Bottom;
                            break;
                    }
                }
            }

            // Fonts
            if (xmlRoot["formatting"]["font"]["maintext"] != null)
            {
                int trySize;
                XmlElement tmpElem = xmlRoot["formatting"]["font"];

                int.TryParse(tmpElem["maintext"]["size"].InnerText, out trySize);
                sng.TextFont = new Font(
                    tmpElem["maintext"]["name"].InnerText,
                    trySize > 0 ? trySize : Settings.Default.ProjectionMasterFont.Size,
                    (FontStyle)
                    ((int)(tmpElem["maintext"]["bold"].InnerText == "true" ? FontStyle.Bold : FontStyle.Regular) +
                     (int)(tmpElem["maintext"]["italic"].InnerText == "true" ? FontStyle.Italic : FontStyle.Regular)));

                int.TryParse(tmpElem["translationtext"]["size"].InnerText, out trySize);
                sng.TranslationFont = new Font(
                    tmpElem["translationtext"]["name"].InnerText,
                    trySize > 0 ? trySize : Settings.Default.ProjectionMasterFont.Size,
                    (FontStyle)
                    ((int)(tmpElem["translationtext"]["bold"].InnerText == "true" ? FontStyle.Bold : FontStyle.Regular) +
                     (int)
                     (tmpElem["translationtext"]["italic"].InnerText == "true" ? FontStyle.Italic : FontStyle.Regular)));

                int.TryParse(tmpElem["maintext"]["color"].InnerText, out trySize);
                sng.TextColor = Color.FromArgb(255, Color.FromArgb(trySize));

                int.TryParse(tmpElem["translationtext"]["color"].InnerText, out trySize);
                sng.TranslationColor = Color.FromArgb(255, Color.FromArgb(trySize));
            }
            if (xmlRoot["formatting"]["linespacing"]["main"] != null)
            {
                int trySize;
                int.TryParse(xmlRoot["formatting"]["linespacing"]["main"].InnerText, out trySize);
                sng.TextLineSpacing = trySize > 0 ? trySize : Settings.Default.ProjectionMasterLineSpacing;
            }

            //
            // ... and the images
            //

            foreach (XmlElement elem in xmlRoot["formatting"]["background"])
            {
                if (elem.Name == "file")
                {
                    if (ImageManager.Instance.imageExists(elem.InnerText))
                        sng.RelativeImagePaths.Add(elem.InnerText);
                }
            }

            // Read copyright text
            if (xmlRoot["information"]["Copyright"] != null && xmlRoot["information"]["Copyright"]["text"] != null)
            {
                sng.Copyright = xmlRoot["information"]["Copyright"]["text"].InnerText;
            }

            //
            // Now the song text ... 
            //
            foreach (XmlElement elem in xmlRoot["songtext"])
            {
                if (elem.Name == "part")
                {
                    string caption = elem.GetAttribute("caption");
                    var tmpPart = new SongPart(caption);
                    foreach (XmlElement slideElem in elem)
                    {
                        if (slideElem.Name == "slide")
                        {
                            var tmpSlide = new SongSlide(sng);
                            tmpSlide.Lines = new List<string>();
                            tmpSlide.HorizontalAlign = sng.DefaultHorizAlign;
                            tmpSlide.VerticalAlign = sng.DefaultVertAlign;

                            int bgNr = Convert.ToInt32(slideElem.GetAttribute("backgroundnr")) + 1;
                            bgNr = bgNr < 0 ? 0 : bgNr;
                            bgNr = bgNr > sng.RelativeImagePaths.Count ? sng.RelativeImagePaths.Count : bgNr;
                            tmpSlide.ImageNumber = bgNr;
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
                            sng.Slides.Add(tmpSlide);
                            tmpPart.Slides.Add(tmpSlide);
                        }
                    }
                    sng.Parts.Add(tmpPart);
                }
            }
            return sng;
        }
    }
}
