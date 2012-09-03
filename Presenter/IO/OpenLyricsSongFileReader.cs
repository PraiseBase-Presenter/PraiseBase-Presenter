using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Pbp.Properties;

namespace Pbp
{
    class OpenLyricsSongFileReader : SongFileReader
    {
        public override Song load(string filename)
        {
            Song sng = new Song();

            // Default font settings if values in xml invalid
            sng.TextFont = Settings.Default.ProjectionMasterFont;
            sng.TextColor = Settings.Default.ProjectionMasterFontColor;
            sng.TranslationFont = Settings.Default.ProjectionMasterFontTranslation;
            sng.TranslationColor = Settings.Default.ProjectionMasterTranslationColor;
            sng.TextLineSpacing = Settings.Default.ProjectionMasterLineSpacing;

            // Init xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlElement xmlRoot = xmlDoc.DocumentElement;

            if (xmlRoot.Name != "song" || xmlRoot.GetAttribute("version") != "0.8")
            {
                throw new Exception("Invalid file type!");
            }

            if (xmlRoot["properties"] == null || xmlRoot["properties"] == null)
            {
                throw new Exception("Incomplete file!");
            }

            // Title
            sng.Title = xmlRoot["properties"]["titles"]["title"].InnerText;

            sng.updateSearchText();
            return sng;
        }
    }
}
