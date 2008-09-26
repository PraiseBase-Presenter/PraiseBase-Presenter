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
    class Song
    {
        static private string imageDirectory = "Backgrounds";
        private bool _isValid;
        private string _path;
        private string _title;
        private string _language;
        private string _category;
        protected string _wholeText;
        public struct part
        {
            public string caption;
            public List<slide> slides;
        };
        public List<part> parts;
        public struct slide
        {
            public string text;
            public int imageNumber;
            public List<string> lines;
        };
        public List<string> images;

        public Song(string filePath)
        {
            XmlElement root;

            _isValid = false;
            bool err = false;

            try
            {
                // 
                // Init xml
                //
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                root = doc.DocumentElement;

                _path = filePath;

                //
                // General stuff
                //
                _title = root["general"]["title"].InnerText;
                _language = root["general"]["language"].InnerText;
                _category = root["general"]["category"].InnerText;

                _wholeText = root["songtext"].InnerText;

                //
                // Now the song text ... 
                //
                parts = new List<part>();
                foreach (XmlElement elem in root["songtext"])
                {
                    if (elem.Name == "part")
                    {
                        part tempPart = new part();
                        tempPart.caption = elem.GetAttribute("caption");
                        tempPart.slides = new List<slide>();
                        foreach (XmlElement slideElem in elem)
                        {
                            if (slideElem.Name == "slide")
                            {
                                slide tmpSlide = new slide();
                                tmpSlide.lines = new List<string>();
                                tmpSlide.text = "";
                                tmpSlide.imageNumber = System.Convert.ToInt32(slideElem.GetAttribute("backgroundnr"));
                                foreach (XmlElement lineElem in slideElem)
                                {
                                    if (lineElem.Name == "line")
                                    {
                                        tmpSlide.lines.Add(lineElem.InnerText);
                                        tmpSlide.text += lineElem.InnerText + " ";
                                    }
                                }
                                tempPart.slides.Add(tmpSlide);
                            }
                        }
                        parts.Add(tempPart);
                    }
                }

                //
                // ... and the images
                //
                Settings setting = new Settings();
                images = new List<string>();
                foreach (XmlElement elem in root["formatting"]["background"])
                {
                    if (elem.Name == "file")
                    {
                        images.Add( setting.dataDirectory + "/" + imageDirectory + "/" + elem.InnerText);
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
        public string title()
        {
            return _title;
        }

        public string text()
        {
            return _wholeText;
        }

        public ImageList getImageList()
        {
            ImageList imageList;
            imageList = new ImageList();

            foreach (String path in images)
            {
                if (File.Exists(path))
                {
                    Image img = Image.FromFile(path);
                    imageList.Images.Add(img);
                }
                else
                {
                    Console.WriteLine("Image " + path + " does not exist!");
                    Image img = new Bitmap(800, 600);
                    Graphics graph = Graphics.FromImage(img);
                    graph.FillRectangle(new SolidBrush(Color.Black), 0, 0, img.Width, img.Height);
                    
                    imageList.Images.Add(img);

                }
            }
          

            return imageList;
        }


    }
}
