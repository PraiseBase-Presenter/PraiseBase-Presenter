using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using Pbp.Properties; 

namespace Pbp
{
    /// <summary>
    /// Keeps and manages all song related data loaded form an xml file
    /// 
    /// Author: Nicolas Perrenoud <nicolape@ee.ethz.ch>
    /// </summary>
    public partial class Song
	{
		#region Variables

		/// <summary>
		/// Indicates if this is a valid song file. Do not use this class if this
		/// variable is set to false after loading!
		/// </summary>
		public bool isValid { get; private set; }
		/// <summary>
		/// Path of the song xml file
		/// </summary>
		public string path  { get; private set; }
		/// <summary>
		/// Song number used by the song manager
		/// </summary>
		public int id { get; set; }
        /// <summary>
        /// The song title. Usually the same as the file name
        /// </summary>
		public string title { get; protected set; }
        /// <summary>
        /// Main language of the song
        /// </summary>
		public string language { get; protected set; }
         /// <summary>
        /// A list of tags (like categories) which describe the type of the song
        /// </summary>
		public Tags tags;
		/// <summary>
        /// User defined comment for quality assurance information or presentation issues
        /// </summary>
		public string comment { get; set; }
		/// <summary>
		/// The whole songtext, which is used for a quick search by the song manager
		/// </summary>
		private string text;
        /// <summary>
        /// Allows searching in the whole songtext
        /// </summary>
		public string searchText
		{
			get { return text; }
			private set
			{
				text = value;
				text = text.Trim().ToLower();
				text = text.Replace(",", String.Empty);
				text = text.Replace(".", String.Empty);
				text = text.Replace(";", String.Empty);
				text = text.Replace(Environment.NewLine, String.Empty);
				text = text.Replace("  ", " ");
			}
		}
        /// <summary>
        /// Text font
        /// </summary>
        public Font font;
        /// <summary>
        /// Text color
        /// </summary>
        public Color fontColor;
        /// <summary>
        /// Font of tanslation text
        /// </summary>
        public Font fontTranslation;
        /// <summary>
        /// Color of translation text
        /// </summary>
        public Color fontColorTranslation;
        /// <summary>
        /// Additional height between lines
        /// </summary>
        public int lineSpacing;
        /// <summary>
        /// Additional height between a line and its translation
        /// </summary>
        public int lineSpacingTranslation;
        /// <summary>
        /// Quality assurance indicator for spelling errors
        /// </summary>
        public bool QASpelling;
        /// <summary>
        /// Quality assurance indicator for missing or wrong translation
        /// </summary>
        public bool QATranslation;
        /// <summary>
        /// Quality assurance indicator for missing or wrong images
        /// </summary>
        public bool QAImage;
        /// <summary>
        /// Qualiti assurance indicator for improper segmentation of slide text
        /// </summary>
        public bool QASegmentation;
        /// <summary>
        /// The file type of this song
        /// </summary>
        private fileType originFileType;
        /// <summary>
        /// The list of all parts in the song
        /// </summary>
        public List<Part> parts;
        /// <summary>
        /// A list containing a sequence of part numbers indicating 
        /// the real sequence the song is song
        /// </summary>
        public List<int> partSequence;
        /// <summary>
        /// List of all slides. Used in the presenter song detail overview.
        /// </summary>
        public List<Slide> slides;
        /// <summary>
        /// Indicates the current slide
        /// </summary>
        public int currentSlide;
        /// <summary>
        /// List of the paths to all images
        /// </summary>
        public List<string> imagePaths;
        /// <summary>
        /// Thumbnails of all images
        /// </summary>
        private ImageList imageThumbs;

		#endregion

		/// <summary>
        /// The song constructor
        /// </summary>
        /// <param name="filePath">Full path to the song xml file</param>
        public Song(string filePath)
        {
            isValid = false;
            path = filePath;

            bool err = false;

			Settings setting = new Settings();

			tags = new Tags();
			SongTextHorizontalAlign defaultHorizAlign = SongTextHorizontalAlign.center;
			SongTextVerticalAlign defaultVertAlign = SongTextVerticalAlign.center;
			slides = new List<Slide>();
			parts = new List<Part>();
			imagePaths = new List<string>();

			// Default font settings if values in xml invalid
			font = setting.projectionMasterFont;
			fontColor = setting.projectionMasterFontColor;
			fontTranslation = setting.projectionMasterFontTranslation;
			fontColorTranslation = setting.projectionMasterTranslationColor;
			lineSpacing = setting.projectionMasterLineSpacing;

			#region File loader
			if (filePath != null)
			{
				try
				{
					XmlDocument xmlDoc;
					XmlElement xmlRoot;

					// Init xml
					xmlDoc = new XmlDocument();
					xmlDoc.Load(filePath);
					xmlRoot = xmlDoc.DocumentElement;

					// Detect format
					originFileType = fileType.createFactory(xmlRoot.Name, xmlRoot.GetAttribute("version"));

					
					// PraiseBase Presenter Song Format
					if (originFileType.GetType() == typeof(fileTypePBPS))
					{
						
					}
					// PowerPraise Song Format
					else if (originFileType.GetType() == typeof(fileTypePPL))
					{
						//
						// General stuff
						//
						title = xmlRoot["general"]["title"].InnerText;

						if (xmlRoot["general"]["language"] != null)
							language = xmlRoot["general"]["language"].InnerText;
						else
							language = "Deutsch";

						if (xmlRoot["general"]["category"] != null)
						{
							tags.Add(xmlRoot["general"]["category"].InnerText);
						}

						if (xmlRoot["general"]["comment"] != null)
							comment = xmlRoot["general"]["comment"].InnerText;
						else
							comment = "";


						if (xmlRoot["formatting"]["textorientation"] != null)
						{
							if (xmlRoot["formatting"]["textorientation"]["horizontal"] != null)
							{
								switch (xmlRoot["formatting"]["textorientation"]["horizontal"].InnerText)
								{
									case "left":
										defaultHorizAlign = SongTextHorizontalAlign.left;
										break;
									case "center":
										defaultHorizAlign = SongTextHorizontalAlign.center;
										break;
									case "right":
										defaultHorizAlign = SongTextHorizontalAlign.right;
										break;
								}
							}
							if (xmlRoot["formatting"]["textorientation"]["vertical"] != null)
							{
								switch (xmlRoot["formatting"]["textorientation"]["vertical"].InnerText)
								{
									case "top":
										defaultVertAlign = SongTextVerticalAlign.top;
										break;
									case "center":
										defaultVertAlign = SongTextVerticalAlign.center;
										break;
									case "bottom":
										defaultVertAlign = SongTextVerticalAlign.bottom;
										break;
								}
							}
						}

						if (xmlRoot["formatting"]["font"]["maintext"] != null)
						{
							int trySize;
							XmlElement tmpElem = xmlRoot["formatting"]["font"];

							int.TryParse(tmpElem["maintext"]["size"].InnerText, out trySize);
							font = new Font(
								tmpElem["maintext"]["name"].InnerText, 
								trySize>0 ? trySize : setting.projectionMasterFont.Size,
								(FontStyle)((int)(tmpElem["maintext"]["bold"].InnerText == "true" ? FontStyle.Bold : FontStyle.Regular) + (int)(tmpElem["maintext"]["italic"].InnerText == "true" ? FontStyle.Italic : FontStyle.Regular)));

							int.TryParse(tmpElem["translationtext"]["size"].InnerText, out trySize);
							fontTranslation = new Font(
								tmpElem["translationtext"]["name"].InnerText,
								trySize > 0 ? trySize : setting.projectionMasterFont.Size,
								(FontStyle)((int)(tmpElem["translationtext"]["bold"].InnerText == "true" ? FontStyle.Bold : FontStyle.Regular) + (int)(tmpElem["translationtext"]["italic"].InnerText == "true" ? FontStyle.Italic : FontStyle.Regular)));

							int.TryParse(tmpElem["maintext"]["color"].InnerText, out trySize);
							fontColor = Color.FromArgb(255,Color.FromArgb(trySize));
							
							int.TryParse(tmpElem["translationtext"]["color"].InnerText, out trySize);
							fontColorTranslation = Color.FromArgb(255,Color.FromArgb(trySize));


						}
						if (xmlRoot["formatting"]["linespacing"]["main"] != null)
						{
							int trySize;
							int.TryParse(xmlRoot["formatting"]["linespacing"]["main"].InnerText, out trySize);
							lineSpacing = trySize > 0 ? trySize: setting.projectionMasterLineSpacing;
						}

						//
						// ... and the images
						//
						string imPath = setting.dataDirectory + Path.DirectorySeparatorChar + setting.imageDir + Path.DirectorySeparatorChar;
						foreach (XmlElement elem in xmlRoot["formatting"]["background"])
						{
							if (elem.Name == "file")
							{
								if (File.Exists(imPath + elem.InnerText))
									imagePaths.Add(elem.InnerText);
							}
						}

						//
						// Now the song text ... 
						//
						text = xmlRoot["songtext"].InnerText;
						foreach (XmlElement elem in xmlRoot["songtext"])
						{
							if (elem.Name == "part")
							{
								string caption = elem.GetAttribute("caption");
								Part tmpPart = new Part(caption);
								tmpPart.slides = new List<Slide>();
								foreach (XmlElement slideElem in elem)
								{
									if (slideElem.Name == "slide")
									{
										Slide tmpSlide = new Slide(this);
										tmpSlide.lines = new List<string>();
										tmpSlide.horizAlign = defaultHorizAlign;
										tmpSlide.vertAlign = defaultVertAlign;
										int bgNr = System.Convert.ToInt32(slideElem.GetAttribute("backgroundnr")) + 1;
										bgNr = bgNr<0 ? 0 : bgNr;
										bgNr = bgNr>imagePaths.Count ? imagePaths.Count : bgNr;
										//tmpSlide.image = imagePaths[bgNr];
										tmpSlide.imageNumber = bgNr;
										foreach (XmlElement lineElem in slideElem)
										{
											if (lineElem.Name == "line")
											{
												tmpSlide.lines.Add(lineElem.InnerText);
											}
											if (lineElem.Name == "translation")
											{
												tmpSlide.hasTranslation = true;
												tmpSlide.translation.Add(lineElem.InnerText);
											}
										}
										slides.Add(tmpSlide);
										tmpPart.slides.Add(tmpSlide);
									}
								}
								parts.Add(tmpPart);
							}
						}




					}
					else
					{
						throw new Exception("Ungültiges Dateiformat (" + xmlRoot.Name + ")!");
					}

				}
				catch (Exception e)
				{
					err = true;
					Console.WriteLine("ERROR loading song " + filePath + " : " + e.Message);
				}
			}
			#endregion
			else
			{
				title = "Neues Lied";
				Part tmpPart = new Part(null);
				tmpPart.slides.Add(new Slide(this));
				parts.Add(tmpPart);
				originFileType = new fileTypePBPS();
			}

			if (!err)
            {
                isValid = true;
            }
        }

        private void loadImageThumbs()
        {
            imageThumbs = new ImageList();
            imageThumbs.ImageSize = new Size(64, 48);
            imageThumbs.ColorDepth = ColorDepth.Depth32Bit;
			Settings setting = new Settings();

			Image img = new Bitmap(64, 48);
			Graphics graph = Graphics.FromImage(img);
			graph.FillRectangle(new SolidBrush(Color.Magenta), 0, 0, img.Width, img.Height);
			imageThumbs.Images.Add(img);
			graph.Dispose();

			foreach (String path in imagePaths)
            {
				string imPath = setting.dataDirectory + Path.DirectorySeparatorChar + setting.imageDir + Path.DirectorySeparatorChar + path;

				if (File.Exists(imPath))
                {
                    imageThumbs.Images.Add(Image.FromFile(imPath));
                }
            }
        }

		public ImageList getThumbs()
		{
			if (imageThumbs == null)
			{
				loadImageThumbs();
			}
			return imageThumbs;
		}

        public Image getImage(int nr)
        {
			try
			{
				if (nr < 1)
				{
					throw new Exception("Ungültige Bildnummer!");
				}

				if (imagePaths[nr-1] == null)
				{
					throw new Exception("Das Bild mit der Nummer " + nr + " existiert nicht!");
				}

				Settings setting = new Settings();
				string path = setting.dataDirectory + Path.DirectorySeparatorChar + setting.imageDir + Path.DirectorySeparatorChar + imagePaths[nr-1];

				if (File.Exists(path))
				{
					return Image.FromFile(path);
				}
				else
				{
					throw new Exception("Das Bild " + path + " existiert nicht!");
				}
			}
			catch 
			{
				Image img = new Bitmap(800, 600);
				Graphics graph = Graphics.FromImage(img);
				graph.FillRectangle(new SolidBrush(Color.Cyan), 0, 0, img.Width, img.Height);
				return img;
			}
        }



        /// <summary>
        /// Saves the song to an xml file
        /// </summary>
        /// <param name="fileName">The target filename. Use null to save it back to its original file</param>
        public void save(string fileName)
        {
			if (fileName == null)
			{
				fileName = path;
			}
			else
			{
				string ext = Path.GetExtension(fileName);
				originFileType = fileType.createFactory(ext);
				if (originFileType == null)
					originFileType = new fileTypePBPS();
			}


			
			XmlDocument xmlDoc = new XmlDocument();
            
            
            if (originFileType.GetType() == typeof(fileTypePPL))
            {
				XmlNode xmlnode = xmlDoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
				xmlDoc.AppendChild(xmlnode);

                xmlDoc.AppendChild(xmlDoc.CreateElement("ppl"));
                XmlElement xmlRoot = xmlDoc.DocumentElement;
                xmlRoot.SetAttribute("version", "3.0");

                xmlRoot.AppendChild(xmlDoc.CreateElement("general"));
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("title"));
                xmlRoot["general"]["title"].InnerText = title;
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("category"));
                xmlRoot["general"]["category"].InnerText = tags.Count > 0 ? tags[0] : "Keine Kategorie";
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("language"));
				if (language != string.Empty)
				{
					xmlRoot["general"]["language"].InnerText = language;
				}
				if (comment != string.Empty)
				{
					xmlRoot["general"].AppendChild(xmlDoc.CreateElement("comment"));
					xmlRoot["general"]["comment"].InnerText = comment;
				}

                xmlRoot.AppendChild(xmlDoc.CreateElement("songtext"));

				List<string> usedImages = new List<string>();
				foreach (Part prt in parts)
				{
					XmlElement tn = xmlDoc.CreateElement("part");
					tn.SetAttribute("caption", prt.caption);
					foreach (Slide sld in prt.slides)
					{
						if (sld.imageNumber > 0)
						{
							if (!usedImages.Contains(imagePaths[sld.imageNumber - 1]))
							{
								usedImages.Add(imagePaths[sld.imageNumber - 1]);
							}
							sld.imageNumber = usedImages.IndexOf(imagePaths[sld.imageNumber - 1]) + 1;
						}
					}
				}
				imagePaths = usedImages;

                foreach (Part prt in parts)
                {
                    XmlElement tn = xmlDoc.CreateElement("part");
                    tn.SetAttribute("caption", prt.caption);
                    foreach (Slide sld in prt.slides)
                    {
                        XmlElement tn2 = xmlDoc.CreateElement("slide");
						tn2.SetAttribute("mainsize", font.Size.ToString());
						tn2.SetAttribute("backgroundnr", (sld.imageNumber-1).ToString());

                        foreach (string ln in sld.lines)
                        {
                            XmlElement tn3 = xmlDoc.CreateElement("line");
                            tn3.InnerText = ln;
                            tn2.AppendChild(tn3);
                        }
						foreach (string ln in sld.translation)
						{
							XmlElement tn3 = xmlDoc.CreateElement("translation");
							tn3.InnerText = ln;
							tn2.AppendChild(tn3);
						}
                        tn.AppendChild(tn2);
                    }
                    xmlRoot["songtext"].AppendChild(tn);
                }

                xmlRoot.AppendChild(xmlDoc.CreateElement("order"));
                foreach (Part prt in parts)
                {
                    XmlElement tn = xmlDoc.CreateElement("item");
                    tn.InnerText = prt.caption;
                    xmlRoot["order"].AppendChild(tn);
                }

                xmlRoot.AppendChild(xmlDoc.CreateElement("information"));
                xmlRoot["information"].AppendChild(xmlDoc.CreateElement("copyright"));
                xmlRoot["information"]["copyright"].AppendChild(xmlDoc.CreateElement("position"));
                xmlRoot["information"]["copyright"]["position"].InnerText = "lastslide";
                xmlRoot["information"]["copyright"].AppendChild(xmlDoc.CreateElement("text"));
                xmlRoot["information"].AppendChild(xmlDoc.CreateElement("source"));
                xmlRoot["information"]["source"].AppendChild(xmlDoc.CreateElement("position"));
                xmlRoot["information"]["source"]["position"].InnerText = "firstslide";
                xmlRoot["information"]["source"].AppendChild(xmlDoc.CreateElement("text"));

                xmlRoot.AppendChild(xmlDoc.CreateElement("formatting"));

                xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("font"));
				xmlRoot["formatting"]["font"].AppendChild(xmlDoc.CreateElement("maintext"));
				xmlRoot["formatting"]["font"]["maintext"].AppendChild(xmlDoc.CreateElement("name"));
				xmlRoot["formatting"]["font"]["maintext"]["name"].InnerText = font.Name.ToString();
				xmlRoot["formatting"]["font"]["maintext"].AppendChild(xmlDoc.CreateElement("size"));
				xmlRoot["formatting"]["font"]["maintext"]["size"].InnerText = font.Size.ToString();
				xmlRoot["formatting"]["font"]["maintext"].AppendChild(xmlDoc.CreateElement("bold"));
				xmlRoot["formatting"]["font"]["maintext"]["bold"].InnerText = (font.Bold).ToString().ToLower();
				xmlRoot["formatting"]["font"]["maintext"].AppendChild(xmlDoc.CreateElement("italic"));
				xmlRoot["formatting"]["font"]["maintext"]["italic"].InnerText = (font.Italic).ToString().ToLower();
				xmlRoot["formatting"]["font"]["maintext"].AppendChild(xmlDoc.CreateElement("color"));
				xmlRoot["formatting"]["font"]["maintext"]["color"].InnerText = (16777216 + fontColor.ToArgb()).ToString();
				xmlRoot["formatting"]["font"]["maintext"].AppendChild(xmlDoc.CreateElement("outline"));
				xmlRoot["formatting"]["font"]["maintext"]["outline"].InnerText = "25";
				xmlRoot["formatting"]["font"]["maintext"].AppendChild(xmlDoc.CreateElement("shadow"));
				xmlRoot["formatting"]["font"]["maintext"]["shadow"].InnerText = "20";

				xmlRoot["formatting"]["font"].AppendChild(xmlDoc.CreateElement("translationtext"));
				xmlRoot["formatting"]["font"]["translationtext"].AppendChild(xmlDoc.CreateElement("name"));
				xmlRoot["formatting"]["font"]["translationtext"]["name"].InnerText = fontTranslation.Name.ToString();
				xmlRoot["formatting"]["font"]["translationtext"].AppendChild(xmlDoc.CreateElement("size"));
				xmlRoot["formatting"]["font"]["translationtext"]["size"].InnerText = fontTranslation.Size.ToString();
				xmlRoot["formatting"]["font"]["translationtext"].AppendChild(xmlDoc.CreateElement("bold"));
				xmlRoot["formatting"]["font"]["translationtext"]["bold"].InnerText = (fontTranslation.Bold).ToString().ToLower();
				xmlRoot["formatting"]["font"]["translationtext"].AppendChild(xmlDoc.CreateElement("italic"));
				xmlRoot["formatting"]["font"]["translationtext"]["italic"].InnerText = (fontTranslation.Italic).ToString().ToLower();
				xmlRoot["formatting"]["font"]["translationtext"].AppendChild(xmlDoc.CreateElement("color"));
				xmlRoot["formatting"]["font"]["translationtext"]["color"].InnerText = (16777216 +fontColorTranslation.ToArgb()).ToString();
				xmlRoot["formatting"]["font"]["translationtext"].AppendChild(xmlDoc.CreateElement("outline"));
				xmlRoot["formatting"]["font"]["translationtext"]["outline"].InnerText = "25";
				xmlRoot["formatting"]["font"]["translationtext"].AppendChild(xmlDoc.CreateElement("shadow"));
				xmlRoot["formatting"]["font"]["translationtext"]["shadow"].InnerText = "20";

				xmlRoot["formatting"]["font"].AppendChild(xmlDoc.CreateElement("copyrighttext"));
				xmlRoot["formatting"]["font"]["copyrighttext"].AppendChild(xmlDoc.CreateElement("name"));
				xmlRoot["formatting"]["font"]["copyrighttext"]["name"].InnerText = fontTranslation.Name.ToString();
				xmlRoot["formatting"]["font"]["copyrighttext"].AppendChild(xmlDoc.CreateElement("size"));
				xmlRoot["formatting"]["font"]["copyrighttext"]["size"].InnerText = fontTranslation.Size.ToString();
				xmlRoot["formatting"]["font"]["copyrighttext"].AppendChild(xmlDoc.CreateElement("bold"));
				xmlRoot["formatting"]["font"]["copyrighttext"]["bold"].InnerText = (fontTranslation.Bold).ToString().ToLower();
				xmlRoot["formatting"]["font"]["copyrighttext"].AppendChild(xmlDoc.CreateElement("italic"));
				xmlRoot["formatting"]["font"]["copyrighttext"]["italic"].InnerText = (fontTranslation.Italic).ToString().ToLower();
				xmlRoot["formatting"]["font"]["copyrighttext"].AppendChild(xmlDoc.CreateElement("color"));
				xmlRoot["formatting"]["font"]["copyrighttext"]["color"].InnerText = (16777216 + fontColorTranslation.ToArgb()).ToString();
				xmlRoot["formatting"]["font"]["copyrighttext"].AppendChild(xmlDoc.CreateElement("outline"));
				xmlRoot["formatting"]["font"]["copyrighttext"]["outline"].InnerText = "25";
				xmlRoot["formatting"]["font"]["copyrighttext"].AppendChild(xmlDoc.CreateElement("shadow"));
				xmlRoot["formatting"]["font"]["copyrighttext"]["shadow"].InnerText = "20";

				xmlRoot["formatting"]["font"].AppendChild(xmlDoc.CreateElement("sourcetext"));
				xmlRoot["formatting"]["font"]["sourcetext"].AppendChild(xmlDoc.CreateElement("name"));
				xmlRoot["formatting"]["font"]["sourcetext"]["name"].InnerText = fontTranslation.Name.ToString();
				xmlRoot["formatting"]["font"]["sourcetext"].AppendChild(xmlDoc.CreateElement("size"));
				xmlRoot["formatting"]["font"]["sourcetext"]["size"].InnerText = fontTranslation.Size.ToString();
				xmlRoot["formatting"]["font"]["sourcetext"].AppendChild(xmlDoc.CreateElement("bold"));
				xmlRoot["formatting"]["font"]["sourcetext"]["bold"].InnerText = (fontTranslation.Bold).ToString().ToLower();
				xmlRoot["formatting"]["font"]["sourcetext"].AppendChild(xmlDoc.CreateElement("italic"));
				xmlRoot["formatting"]["font"]["sourcetext"]["italic"].InnerText = (fontTranslation.Italic).ToString().ToLower();
				xmlRoot["formatting"]["font"]["sourcetext"].AppendChild(xmlDoc.CreateElement("color"));
				xmlRoot["formatting"]["font"]["sourcetext"]["color"].InnerText = (16777216 + fontColorTranslation.ToArgb()).ToString();
				xmlRoot["formatting"]["font"]["sourcetext"].AppendChild(xmlDoc.CreateElement("outline"));
				xmlRoot["formatting"]["font"]["sourcetext"]["outline"].InnerText = "25";
				xmlRoot["formatting"]["font"]["sourcetext"].AppendChild(xmlDoc.CreateElement("shadow"));
				xmlRoot["formatting"]["font"]["sourcetext"]["shadow"].InnerText = "20";


				xmlRoot["formatting"]["font"].AppendChild(xmlDoc.CreateElement("outline"));
				xmlRoot["formatting"]["font"]["outline"].AppendChild(xmlDoc.CreateElement("enabled"));
				xmlRoot["formatting"]["font"]["outline"]["enabled"].InnerText = "true";
				xmlRoot["formatting"]["font"]["outline"].AppendChild(xmlDoc.CreateElement("color"));
				xmlRoot["formatting"]["font"]["outline"]["color"].InnerText = "0";

				xmlRoot["formatting"]["font"].AppendChild(xmlDoc.CreateElement("shadow"));
				xmlRoot["formatting"]["font"]["shadow"].AppendChild(xmlDoc.CreateElement("enabled"));
				xmlRoot["formatting"]["font"]["shadow"]["enabled"].InnerText = "true";
				xmlRoot["formatting"]["font"]["shadow"].AppendChild(xmlDoc.CreateElement("color"));
				xmlRoot["formatting"]["font"]["shadow"]["color"].InnerText = "0";
				xmlRoot["formatting"]["font"]["shadow"].AppendChild(xmlDoc.CreateElement("direction"));
				xmlRoot["formatting"]["font"]["shadow"]["direction"].InnerText = "125";

                xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("background"));
				foreach (string imp in usedImages)
                {
						XmlElement tn = xmlDoc.CreateElement("file");
						tn.InnerText = imp;
						xmlRoot["formatting"]["background"].AppendChild(tn);
                }
                xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("linespacing"));
                
                xmlRoot["formatting"]["linespacing"].AppendChild(xmlDoc.CreateElement("main"));
                xmlRoot["formatting"]["linespacing"].AppendChild(xmlDoc.CreateElement("translation"));
                xmlRoot["formatting"]["linespacing"]["main"].InnerText = lineSpacing.ToString();
                xmlRoot["formatting"]["linespacing"]["translation"].InnerText = lineSpacing.ToString();

                xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("textorientation"));
                xmlRoot["formatting"]["textorientation"].AppendChild(xmlDoc.CreateElement("horizontal"));
				if (parts[0].slides[0].horizAlign == SongTextHorizontalAlign.left)
					xmlRoot["formatting"]["textorientation"]["horizontal"].InnerText = "left";
				else if (parts[0].slides[0].horizAlign == SongTextHorizontalAlign.right)
					xmlRoot["formatting"]["textorientation"]["horizontal"].InnerText = "right";
				else
					xmlRoot["formatting"]["textorientation"]["horizontal"].InnerText = "center";
				xmlRoot["formatting"]["textorientation"].AppendChild(xmlDoc.CreateElement("vertical"));
				if (parts[0].slides[0].vertAlign == SongTextVerticalAlign.top)
					xmlRoot["formatting"]["textorientation"]["vertical"].InnerText = "top";
				else if (parts[0].slides[0].vertAlign == SongTextVerticalAlign.bottom)
					xmlRoot["formatting"]["textorientation"]["vertical"].InnerText = "bottom";
				else
					xmlRoot["formatting"]["textorientation"]["vertical"].InnerText = "center";
				xmlRoot["formatting"]["textorientation"].AppendChild(xmlDoc.CreateElement("transpos"));
				xmlRoot["formatting"]["textorientation"]["transpos"].InnerText = "inline";

                xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("borders"));
				xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("mainleft"));
				xmlRoot["formatting"]["borders"]["mainleft"].InnerText = "40";
				xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("maintop"));
				xmlRoot["formatting"]["borders"]["maintop"].InnerText = "70";
				xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("mainright"));
				xmlRoot["formatting"]["borders"]["mainright"].InnerText = "40";
				xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("mainbottom"));
				xmlRoot["formatting"]["borders"]["mainbottom"].InnerText = "80";
				xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("copyrightbottom"));
				xmlRoot["formatting"]["borders"]["copyrightbottom"].InnerText = "30";
				xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("sourcetop"));
				xmlRoot["formatting"]["borders"]["sourcetop"].InnerText = "20";
				xmlRoot["formatting"]["borders"].AppendChild(xmlDoc.CreateElement("sourceright"));
				xmlRoot["formatting"]["borders"]["sourceright"].InnerText = "40";



				XmlWriter wrt = new XmlTextWriter(fileName, Encoding.UTF8);
				xmlDoc.WriteTo(wrt);
				wrt.Flush();
				wrt.Close();

				path = fileName;
			
			}
        }


        public void setPartCaption(string text, int partId)
        {
            parts[partId].caption = text;
        }

		public bool swapPartWithUpperPart(int partId)
		{
			if (partId > 0 && partId < parts.Count)
			{
				Part tmpPrt = parts[partId - 1];
				parts.RemoveAt(partId - 1);
				parts.Insert(partId, tmpPrt);
				return true;
			}
			return false;
		}

		public bool swapPartWithLowerPart(int partId)
		{
			if (partId >= 0 && partId < parts.Count-1)
			{
				Part tmpPrt = parts[partId + 1];
				parts.RemoveAt(partId + 1);
				parts.Insert(partId, tmpPrt);
				return true;
			}
			return false;
		}
    }
}
