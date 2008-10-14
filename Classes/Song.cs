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
        static private string imageDirectory = "Backgrounds";
        private bool _isValid;
        private string _path;
        XmlDocument xmlDoc;
        XmlElement xmlRoot;

        public string _title;
        public string title { get { return _title; } set { _title = value; } }

        public string _language;
        public string language { get { return _language; } set { _language = value; } }

        private string _comment;
        public string comment { 
            get { return _comment; } 
            set { 
                _comment = value;
                saveBack(); } }

        private List<string> _tags;
        public List<string> tags { get { return _tags; } }

        public List<Slide> slides;

        public class Slide
        {
            public string caption;
            public string text;
            public string nlText;
            public int imageNumber;
            public SongTextAlign vertAlign;
            public SongTextAlign horizAlign;
        };

        public class Part
        {
            public string caption;
            public List<Slide> partSlides;
        };
        public List<Part> parts;

        public int id;

        public int currentSlide;

        private List<string> imagePaths;
        private List<Image> imageObjects;
        private ImageList imageThumbs;

        public enum SongTextAlign {
            left,
            center,
            right,
            top,
            bottom
        }

        public SongTextAlign vertAlign;
        public SongTextAlign horizAlign;

        protected string _wholeText;
        public string text { get { return _wholeText; } set { _wholeText = value; } }

        public Song(string filePath)
        {
            _isValid = false;
            bool err = false;

            try
            {
                // 
                // Init xml
                //
                xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
                xmlRoot = xmlDoc.DocumentElement;

                _path = filePath;

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

                _wholeText = xmlRoot["songtext"].InnerText;

                horizAlign = SongTextAlign.center;
                vertAlign = SongTextAlign.center;
                if (xmlRoot["formatting"]["textorientation"] != null)
                {
                    if (xmlRoot["formatting"]["textorientation"]["horizontal"] != null)
                    {
                        switch (xmlRoot["formatting"]["textorientation"]["horizontal"].InnerText)
                        {
                            case "left":
                                horizAlign = SongTextAlign.left;
                                break;
                            case "center":
                                horizAlign = SongTextAlign.center;
                                break;
                            case "right":
                                horizAlign = SongTextAlign.right;
                                break;
                        }
                    }
                    if (xmlRoot["formatting"]["textorientation"]["vertical"] != null)
                    {
                        switch (xmlRoot["formatting"]["textorientation"]["vertical"].InnerText)
                        {
                            case "top":
                                vertAlign = SongTextAlign.top;
                                break;
                            case "center":
                                vertAlign = SongTextAlign.center;
                                break;
                            case "bottom":
                                vertAlign = SongTextAlign.bottom;
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
                                tmpSlide.caption = caption;
                                tmpSlide.text = "";
                                tmpSlide.nlText = "";
                                tmpSlide.horizAlign = horizAlign;
                                tmpSlide.vertAlign = vertAlign;
                                tmpSlide.imageNumber = System.Convert.ToInt32(slideElem.GetAttribute("backgroundnr"));
                                foreach (XmlElement lineElem in slideElem)
                                {
                                    if (lineElem.Name == "line")
                                    {
                                        tmpSlide.text += lineElem.InnerText + " ";
                                        tmpSlide.nlText += lineElem.InnerText + "\r\n";
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
                        imagePaths.Add( setting.dataDirectory + "/" + imageDirectory + "/" + elem.InnerText);
                    }
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
            if (xmlRoot["general"]["comment"] == null)
                xmlRoot["general"].AppendChild(xmlDoc.CreateElement("comment"));
            xmlRoot["general"]["comment"].InnerText = _comment;


            xmlDoc.Save(_path);
        }


        public void setSlideText(string text, int partId, int slideId)
        {
            parts[partId].partSlides[slideId].nlText = text;
            parts[partId].partSlides[slideId].text = text.Replace("\r\n","");
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
