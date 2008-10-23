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
    public class Song
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
        private List<string> imagePaths;
        /// <summary>
        /// Thumbnails of all images
        /// </summary>
        private ImageList imageThumbs;

		#endregion

		#region Enums and structs

		/// <summary>
        /// Horizontal aligning of slide text
        /// </summary>
        public enum SongTextHorizontalAlign
        {
            /// <summary>
            /// Text is aligned horizontally to the left
            /// </summary>
            left,
            /// <summary>
            /// Text is horizontally centered
            /// </summary>
            center,
            /// <summary>
            /// Text is aligned horizontally to the right
            /// </summary>
            right
        }

        /// <summary>
        /// Vertical aligning of slide text
        /// </summary>
        public enum SongTextVerticalAlign
        {
            /// <summary>
            /// Text is aligned vertically to the top of the page
            /// </summary>
            top,
            /// <summary>
            /// Text is aligned to the center
            /// </summary>
            center,
            /// <summary>
            /// Text is aligned vertically to the bottom of the page
            /// </summary>
            bottom
		}

		#endregion

		#region Subclasses

		public class Tags : List<string>
		{
			public new void Add(string tagName)
			{
				if (!Contains(tagName))
				{
					Console.WriteLine(tagName);
					base.Add(tagName);
				}
				
			}
		}

		/// <summary>
        /// A song part with a given name and one or more slides
        /// </summary>
        public class Part
        {
            /// <summary>
            /// Song part name like chorus, bridge, part 1 ...
            /// </summary>
            public string caption;
            /// <summary>
            /// A list of containing slides. Each part has one slide at minimum
            /// </summary>
            public List<Slide> slides;
			/// <summary>
			/// Pointer to the song object who owns this part
			/// </summary>
			private Song ownerSong;

            /// <summary>
            /// Part constructor
            /// </summary>
            public Part(Song owner, string caption)
            {
				ownerSong = owner;
                slides = new List<Slide>();
				if (caption != null && caption!= String.Empty)
					this.caption = caption;
				else
					this.caption = "Neuer Liedteil";
            }

			public bool swapSlideWithUpperSlide(int slideId)
			{
				if (slideId > 0 && slideId < slides.Count)
				{
					Slide tmpPrt = slides[slideId - 1];
					slides.RemoveAt(slideId - 1);
					slides.Insert(slideId, tmpPrt);
					return true;
				}
				return false;
			}

			public bool swapSlideWithLowerSlide(int slideId)
			{
				if (slideId >= 0 && slideId < slides.Count - 1)
				{
					Slide tmpPrt = slides[slideId + 1];
					slides.RemoveAt(slideId + 1);
					slides.Insert(slideId, tmpPrt);
					return true;
				}
				return false;
			}

			public void duplicateSlide(int slideId)
			{
				slides.Insert(slideId, (Slide)slides[slideId].Clone());
			}

			public void splitSlide(int slideId)
			{
				Slide sld = (Slide)slides[slideId].Clone();

				int totl = sld.lines.Count;
				int rem = totl/2;
				slides[slideId].lines.RemoveRange(0, rem);
				sld.lines.RemoveRange(rem, totl-rem);

				totl = sld.translation.Count;
				rem = totl / 2;
				slides[slideId].translation.RemoveRange(0, rem);
				sld.translation.RemoveRange(rem, totl - rem);			


				slides.Insert(slideId, sld);
			}
        };

        /// <summary>
        /// A single slide with songtext and/or a background image
        /// </summary>
        public class Slide : ICloneable
        {
            /// <summary>
            /// All text lines of this slide
            /// </summary>
            public List<string> lines;
            /// <summary>
            /// All translation lines of this slide
            /// </summary>
            public List<string> translation;
            /// <summary>
            /// Number of the slide image. If set to -1, no image is used
            /// </summary>
            public int imageNumber;
            /// <summary>
            /// Indicates wether this slide has a translation
            /// </summary>
            public bool hasTranslation;
            /// <summary>
            /// Horizonztal text alignment
            /// </summary>
            public SongTextHorizontalAlign horizAlign;
            /// <summary>
            /// Vertical text alignment
            /// </summary>
            public SongTextVerticalAlign vertAlign;
            /// <summary>
            /// Pointer to the song object who owns this slide
            /// </summary>
            private Song ownerSong;

			public Font font { get { return ownerSong.font; } }

			public Font fontTranslation {get { return ownerSong.fontTranslation; }}
			public Color fontColor { get { return ownerSong.fontColor;} }
			public Color fontColorTranslation { get { return ownerSong.fontColorTranslation; } }
			public int lineSpacint {get { return ownerSong.lineSpacing; } }
			
            /// <summary>
            /// The slide constructor
            /// </summary>
            public Slide(Song ownerSong)
            {
                lines = new List<string>();
                translation = new List<string>();
                hasTranslation = false;
                horizAlign = SongTextHorizontalAlign.center;
                vertAlign = SongTextVerticalAlign.center;
                this.ownerSong = ownerSong;
            }

			public void setSlideText(string text)
			{
				this.lines = new List<string>();
				string[] ln = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
				foreach (string sl in ln)
				{
					this.lines.Add(sl.Trim());
				}
			}

			public void setSlideTextTranslation(string text)
			{
				this.translation = new List<string>();
				string[] tr = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
				foreach (string sl in tr)
				{
					this.translation.Add(sl.Trim());
				}
			}

            /// <summary>
            /// Returns a string of the wrapped text
            /// </summary>
            /// <returns>Wrapped text</returns>
            public string lineBreakText()
            {
                string txt = "";
                foreach (string str in lines)
                {
                    txt += str + Environment.NewLine;
                }
                return txt;

            }

            /// <summary>
            /// Returns the wrapped translation text
            /// </summary>
            /// <returns>Wrapped translation</returns>
            public string lineBreakTranslation()
            {
                string txt = "";
                foreach (string str in translation)
                {
                    txt += str + Environment.NewLine;
                }
                return txt;

            }

            /// <summary>
            /// Returns the text on one line. This is mainly used 
            /// in the song detail overview in the presenter.
            /// </summary>
            /// <returns>Text on one line</returns>
            public string oneLineText()
            {
                string txt = "";
                foreach (string str in lines)
                {
                    txt += str + " ";
                }
                return txt;
            }

			public object Clone()
			{
				Slide res = new Slide(this.ownerSong);
				res.hasTranslation = hasTranslation;
				res.horizAlign = horizAlign;
				res.imageNumber = imageNumber;
				foreach (string obj in lines)
					res.lines.Add(obj);
				foreach (string obj in translation)
					res.translation.Add(obj);
				res.vertAlign = vertAlign;
				return res;
			}

        };

		public abstract class fileType
		{
			static public fileType createFactory(string ext, string version)
			{
				if (ext == fileTypePBPS.extension && version == fileTypePBPS.version)
				{
					return new fileTypePBPS();
				}
				else if (ext == fileTypePPL.extension && version == fileTypePPL.version)
				{
					return new fileTypePPL();
				}
				return null;
			}

			public static string getFilter()
			{
				String fltr = String.Empty;
				fltr += fileTypePBPS.name + " (*." + fileTypePBPS.extension + ")|*." + fileTypePBPS.extension + "|";
				fltr += fileTypePPL.name + " (*." + fileTypePPL.extension + ")|*." + fileTypePPL.extension + "|";
				fltr += "Alle Dateien (*.*)|*.*";
				return fltr;
			}

			public static string[] getAllExtensions()
			{
				return new string[] { 
					"*."+fileTypePBPS.extension, 
					"*."+fileTypePPL.extension };
			}
		}

		protected class fileTypePBPS : fileType
		{
			static public string name = "PraiseBase-Presenter Song";
			static public string extension = "pbps";
			static public string version = "1.0";
			static public bool isDefault = true;
		}

		protected class fileTypePPL : fileType
		{
			static public string name = "PowerPraise Lied (veraltet)";
			static public string extension = "ppl";
			static public string version = "3.0";
			static public bool isDefault = false;
		}



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
						// Now the song text ... 
						//
						text = xmlRoot["songtext"].InnerText;
						foreach (XmlElement elem in xmlRoot["songtext"])
						{
							if (elem.Name == "part")
							{
								string caption = elem.GetAttribute("caption");
								Part tmpPart = new Part(this,caption);
								tmpPart.slides = new List<Slide>();
								foreach (XmlElement slideElem in elem)
								{
									if (slideElem.Name == "slide")
									{
										Slide tmpSlide = new Slide(this);
										tmpSlide.lines = new List<string>();
										tmpSlide.horizAlign = defaultHorizAlign;
										tmpSlide.vertAlign = defaultVertAlign;
										tmpSlide.imageNumber = System.Convert.ToInt32(slideElem.GetAttribute("backgroundnr"));
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

						//
						// ... and the images
						//
						foreach (XmlElement elem in xmlRoot["formatting"]["background"])
						{
							if (elem.Name == "file")
							{
								imagePaths.Add(elem.InnerText);
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
				Part tmpPart = new Part(this,null);
				tmpPart.slides.Add(new Slide(this));
				parts.Add(tmpPart);
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
			foreach (String path in imagePaths)
            {
				string imPath = setting.dataDirectory + Path.DirectorySeparatorChar + setting.imageDir + Path.DirectorySeparatorChar + path;

				if (File.Exists(imPath))
                {
                    imageThumbs.Images.Add(Image.FromFile(imPath));
                }
                else
                {
                    //Console.WriteLine("Image " + path + " does not exist!");
                    Image img = new Bitmap(64, 48);
                    Graphics graph = Graphics.FromImage(img);
                    graph.FillRectangle(new SolidBrush(Color.Black), 0, 0, img.Width, img.Height);
                    imageThumbs.Images.Add(img);
                }
            }
        }

        public Image getImage(int nr)
        {
			try
			{
				if (nr < 0)
				{
					throw new Exception("Ungültige Bildnummer!");
				}

				if (imagePaths[nr] == null)
				{
					throw new Exception("Das Bild mit der Nummer " + nr + " existiert nicht!");
				}

				Settings setting = new Settings();
				string path = setting.dataDirectory + Path.DirectorySeparatorChar + setting.imageDir + Path.DirectorySeparatorChar + imagePaths[nr];

				if (File.Exists(path))
				{
					return Image.FromFile(path);
				}
				else
				{
					throw new Exception("Das Bild " + path + " existiert nicht!");
				}
			}
			catch (Exception e)
			{
				//MessageBox.Show(e.Message, "Lied", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Console.WriteLine("Fehler im Lied "+title+": " + e.Message);
				Image img = new Bitmap(800, 600);
				Graphics graph = Graphics.FromImage(img);
				graph.FillRectangle(new SolidBrush(Color.Black), 0, 0, img.Width, img.Height);
				return img;
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

        /// <summary>
        /// Saves the song to an xml file
        /// </summary>
        /// <param name="fileName">The target filename. Use null to save it back to its original file</param>
        public void save(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            
            
            if (originFileType.GetType() == typeof(fileTypePPL))
            {
                xmlDoc.AppendChild(xmlDoc.CreateElement("ppl"));
                XmlElement xmlRoot = xmlDoc.DocumentElement;
                xmlRoot.SetAttribute("version", "3.0");

                xmlRoot.AppendChild(xmlDoc.CreateElement("general"));
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("title"));
                xmlRoot["general"]["title"].InnerText = title;
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("category"));
                xmlRoot["general"]["category"].InnerText = tags.Count > 0 ? tags[0] : "Keine Kategorie";
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("language"));
                xmlRoot["general"]["language"].InnerText = language;
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("comment"));
                xmlRoot["general"]["comment"].InnerText = comment;

                xmlRoot.AppendChild(xmlDoc.CreateElement("songtext"));
                foreach (Part prt in parts)
                {
                    XmlElement tn = xmlDoc.CreateElement("part");
                    tn.SetAttribute("caption", prt.caption);
                    foreach (Slide sld in prt.slides)
                    {
                        XmlElement tn2 = xmlDoc.CreateElement("slide");
                        tn2.SetAttribute("backgroundnr", sld.imageNumber.ToString());
                        tn2.SetAttribute("mainsize", "26"); // Todo
                        foreach (string ln in sld.lines)
                        {
                            XmlElement tn3 = xmlDoc.CreateElement("line");
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
                
                xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("background"));
                foreach (string imp in imagePaths)
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
                xmlRoot["formatting"]["textorientation"].AppendChild(xmlDoc.CreateElement("vertical"));
                xmlRoot["formatting"]["textorientation"].AppendChild(xmlDoc.CreateElement("transpos"));

                xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("borders"));

                if (fileName != null)
                {
                    xmlDoc.Save(fileName);
                }
                else
                {
                    //xmlDoc.Save(_path);
                    xmlDoc.Save("c:\\test.ppl");
                }
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
