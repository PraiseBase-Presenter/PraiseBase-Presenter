using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

using Pbp.Properties; 

namespace Pbp
{
    public class Song
    {
        private bool _isValid;
        private string _path;
        private int _id;
        public int id { get {return _id; } set { _id=value; } }

        public string _title;
        public string title { get { return _title; } set { _title = value; } }

        public string _language;
        public string language { get { return _language; } set { _language = value; } }

        private List<string> _tags;
        public List<string> tags { get { return _tags; } }

        private string _comment;
        public string comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                saveBack();
            }
        }

        protected string _text;
        public string text { get { return _text; } set { _text = value; } }

        /// <summary>
        /// Defines the song file format
        /// </summary>
        public enum FileType
        {
            /// <summary>
            ///  The PBP default format
            /// </summary>
            pbpl,
            /// <summary>
            /// PowerPraise 3.0 format (deprecated)
            /// </summary>
            ppl
        }
        private FileType _fileType;

        /// <summary>
        /// Horizontal aligning of slide text
        /// </summary>
        public enum SongTextHorizontalAlign
        {
            left,
            center,
            right
        }

        /// <summary>
        /// Vertical aligning of slide text
        /// </summary>
        public enum SongTextVerticalAlign
        {
            top,
            center,
            bottom
        }
        public SongTextHorizontalAlign defaultHorizAlign;
        public SongTextVerticalAlign defaultVertAlign;

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
            public List<Slide> partSlides;

            public Part()
            {
                partSlides = new List<Slide>();
            }
        };
        public List<Part> parts;

        /// <summary>
        /// A single slide with songtext and/or a background image
        /// </summary>
        public class Slide
        {
            public List<string> lines;
            public int imageNumber;

            public SongTextHorizontalAlign horizAlign;
            public SongTextVerticalAlign vertAlign;

            public Slide()
            {
                lines = new List<string>();
            }

            public string lineBreakText()
            {
                string txt = "";
                foreach (string str in lines)
                {
                    txt += str + "\r\n";
                }
                return txt;

            }
            public string oneLineText()
            {
                string txt = "";
                foreach (string str in lines)
                {
                    txt += str + " ";
                }
                return txt;
            }
        };
        public List<Slide> slides;

        public int currentSlide;
        private List<string> imagePaths;
        private List<Image> imageObjects;
        private ImageList imageThumbs;


        public Song(string filePath)
        {
            _isValid = false;
            _path = filePath;

            bool err = false;

            try
            {
                XmlDocument xmlDoc;
                XmlElement xmlRoot;

                // 
                // Init xml
                //

                xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
                xmlRoot = xmlDoc.DocumentElement;

                //
                // Detect format
                //

                // PraiseBase Presenter Song Format
                if (xmlRoot.Name == "pbpl" && xmlRoot.GetAttribute("version") == "1.0")
                {
                    _fileType = FileType.pbpl;
                }
                // PowerPraise Version 3 (www.powerpraise.ch)
                else if (xmlRoot.Name == "ppl" && xmlRoot.GetAttribute("version") == "3.0")
                {
                    _fileType = FileType.ppl;



                    //
                    // General stuff
                    //
                    _title = xmlRoot["general"]["title"].InnerText;

                    if (xmlRoot["general"]["language"] != null)
                        _language = xmlRoot["general"]["language"].InnerText;
                    else
                        _language = "Deutsch";

                    _tags = new List<string>();
                    if (xmlRoot["general"]["category"] != null)
                    {
                        _tags.Add(xmlRoot["general"]["category"].InnerText);
                    }

                    if (xmlRoot["general"]["comment"] != null)
                        _comment = xmlRoot["general"]["comment"].InnerText;
                    else
                        _comment = "";

                    _text = xmlRoot["songtext"].InnerText;

                    defaultHorizAlign = SongTextHorizontalAlign.center;
                    defaultVertAlign = SongTextVerticalAlign.center;
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

                    //
                    // Now the song text ... 
                    //
                    slides = new List<Slide>();
                    parts = new List<Part>();
                    foreach (XmlElement elem in xmlRoot["songtext"])
                    {
                        if (elem.Name == "part")
                        {
                            string caption = elem.GetAttribute("caption");
                            Part tmpPart = new Part();
                            tmpPart.caption = caption;
                            tmpPart.partSlides = new List<Slide>();
                            foreach (XmlElement slideElem in elem)
                            {
                                if (slideElem.Name == "slide")
                                {
                                    Slide tmpSlide = new Slide();
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
                                    }
                                    slides.Add(tmpSlide);
                                    tmpPart.partSlides.Add(tmpSlide);
                                }
                            }
                            parts.Add(tmpPart);
                        }
                    }

                    //
                    // ... and the images
                    //
                    Settings setting = new Settings();
                    imagePaths = new List<string>();
                    foreach (XmlElement elem in xmlRoot["formatting"]["background"])
                    {
                        if (elem.Name == "file")
                        {
                            imagePaths.Add(setting.dataDirectory + Path.DirectorySeparatorChar + setting.imageDir + Path.DirectorySeparatorChar + elem.InnerText);
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
                Console.WriteLine("ERROR loading song "+filePath+" : " +e.Message);
            }
            if (!err)
            {
                _isValid = true;
            }
        }

        public bool isValid()
        {
            return _isValid;
        }

        private void loadImages()
        {
            imageObjects = new List<Image>();

            foreach (String path in imagePaths)
            {
                if (File.Exists(path))
                {
                    Image img = Image.FromFile(path);
                    imageObjects.Add(img);
                }
                else
                {
                    Console.WriteLine("Image " + path + " does not exist!");
                    Image img = new Bitmap(800, 600);
                    Graphics graph = Graphics.FromImage(img);
                    graph.FillRectangle(new SolidBrush(Color.Black), 0, 0, img.Width, img.Height);
                    imageObjects.Add(img);
                }
            }
        }

        private void loadImageThumbs()
        {
            imageThumbs = new ImageList();
            imageThumbs.ImageSize = new Size(64, 48);
            imageThumbs.ColorDepth = ColorDepth.Depth32Bit;
            foreach (String path in imagePaths)
            {
                if (File.Exists(path))
                {
                    Image img = Image.FromFile(path);
                    imageThumbs.Images.Add(img);
                }
                else
                {
                    Console.WriteLine("Image " + path + " does not exist!");
                    Image img = new Bitmap(64, 48);
                    Graphics graph = Graphics.FromImage(img);
                    graph.FillRectangle(new SolidBrush(Color.Black), 0, 0, img.Width, img.Height);
                    imageThumbs.Images.Add(img);
                }
            }
        }

        public List<Image> getImages()
        {
            if (imageObjects == null)
            {
                loadImages();
            }
            return imageObjects;
        }

        public Image getImage(int nr)
        {
            if (imageObjects == null)
            {
                loadImages();
            }
            return imageObjects[nr];
        }

       public ImageList getThumbs()
        {
            if (imageThumbs == null)
            {
                loadImageThumbs();
            }
            return imageThumbs;
        }

        public void saveBack()
        {
            XmlDocument xmlDoc = new XmlDocument();
            
            
            if (_fileType == FileType.ppl)
            {
                xmlDoc.AppendChild(xmlDoc.CreateElement("ppl"));
                XmlElement xmlRoot = xmlDoc.DocumentElement;
                xmlRoot.SetAttribute("version", "3.0");

                xmlRoot.AppendChild(xmlDoc.CreateElement("general"));
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("title"));
                xmlRoot["general"]["title"].InnerText = _title;
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("category"));
                xmlRoot["general"]["category"].InnerText = _tags.Count > 0 ? _tags[0] : "Keine Kategorie";
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("language"));
                xmlRoot["general"]["language"].InnerText = _language;
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("comment"));
                xmlRoot["general"]["comment"].InnerText = _comment;

                xmlRoot.AppendChild(xmlDoc.CreateElement("songtext"));
                foreach (Part prt in parts)
                {
                    XmlElement tn = xmlDoc.CreateElement("part");
                    tn.SetAttribute("caption", prt.caption);
                    foreach (Slide sld in prt.partSlides)
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
                xmlRoot["formatting"]["linespacing"]["main"].InnerText = "30";
                xmlRoot["formatting"]["linespacing"]["translation"].InnerText = "20";

                xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("textorientation"));
                xmlRoot["formatting"]["textorientation"].AppendChild(xmlDoc.CreateElement("horizontal"));
                xmlRoot["formatting"]["textorientation"].AppendChild(xmlDoc.CreateElement("vertical"));
                xmlRoot["formatting"]["textorientation"].AppendChild(xmlDoc.CreateElement("transpos"));

                xmlRoot["formatting"].AppendChild(xmlDoc.CreateElement("borders"));

                xmlDoc.Save("c:\\test.ppl");
                //xmlDoc.Save(_path);
            }
        }


        public void setSlideText(string text, int partId, int slideId)
        {
            parts[partId].partSlides[slideId].lines = new List<string>();
            string[] lines = text.Split(new char[] { '\n' });
            foreach (string sl in lines)
            {
                parts[partId].partSlides[slideId].lines.Add(sl);
            }
        }

        public void setPartCaption(string text, int partId)
        {
            parts[partId].caption = text;
        }

        public void resetTags()
        {
            _tags.Clear();
        }

        public void addTag(string str)
        {
            if (!_tags.Contains(str))
            _tags.Add(str);
        }
    }
}
