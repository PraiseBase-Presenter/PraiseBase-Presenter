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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Pbp.Forms;
using Pbp.Properties;

namespace Pbp
{
    internal class ImageManager
    {
        /// <summary>
        /// The singleton holder
        /// </summary>
        static private ImageManager _instance;

        /// <summary>
        /// Current image
        /// </summary>
        public Image currentImage { get; set; }

        /// <summary>
        /// Private constructor
        /// </summary>
        private ImageManager()
        {
        }

        /// <summary>
        /// Returns the singleton instance of this class
        /// </summary>
        /// <returns></returns>
        static public ImageManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ImageManager();
                return _instance;
            }
        }

        /// <summary>
        /// Resizes a given image to new dimensions
        /// </summary>
        /// <param name="sourceImage"></param>
        /// <param name="newSize"></param>
        /// <returns></returns>
        public Bitmap ResizeBitmap(Image sourceImage, Size newSize)
        {
            Bitmap result = new Bitmap(newSize.Width, newSize.Height);
            using (Graphics g = Graphics.FromImage((Image)result))
                g.DrawImage(sourceImage, 0, 0, newSize.Width, newSize.Height);
            return result;
        }

        /// <summary>
        /// Creates a resized version of the given file and stores it
        /// </summary>
        /// <param name="inFile"></param>
        /// <param name="outFile"></param>
        /// <param name="size"></param>
        public void createThumb(string inFile, string outFile)
        {
            Image img;
            try
            {
                img = Image.FromFile(inFile);
                Image imgPhoto = ResizeBitmap(img, Settings.Default.ThumbSize);

                string dir = Path.GetDirectoryName(outFile);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                imgPhoto.Save(outFile, ImageFormat.Jpeg);
                imgPhoto.Dispose();
                img.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("Image Error: " + e);
            }
        }

        /// <summary>
        /// Check and create thumbnails if necessary
        /// </summary>
        public void checkThumbs()
        {
            checkThumbs(null);
        }

        /// <summary>
        /// Check and create thumbnails if necessary
        /// </summary>
        /// <param name="ldg"></param>
        public void checkThumbs(LoadingScreen ldg)
        {
            string imageRootDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.ImageDir;
            string thumbDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.ThumbDir;

            if (!Directory.Exists(imageRootDir))
            {
                Directory.CreateDirectory(imageRootDir);
            }
            if (!Directory.Exists(thumbDir))
            {
                Directory.CreateDirectory(thumbDir);
            }

            string[] imgExtensions = { "*.jpg" };

            if (Directory.Exists(imageRootDir))
            {
                List<string> missingThumbsSrc = new List<string>();
                List<string> missingThumbsTrg = new List<string>();
                foreach (string ext in imgExtensions)
                {
                    string[] paths = Directory.GetFiles(imageRootDir, ext, SearchOption.AllDirectories);
                    foreach (string file in paths)
                    {
                        string relativePath = file.Substring((imageRootDir + Path.DirectorySeparatorChar).Length);
                        string thumbPath = thumbDir + Path.DirectorySeparatorChar + relativePath;
                        if (!File.Exists(thumbPath))
                        {
                            missingThumbsSrc.Add(file);
                            missingThumbsTrg.Add(thumbPath);
                        }
                    }
                }

                int cnt = missingThumbsSrc.Count;
                if (cnt > 0)
                {
                    if (ldg == null)
                    {
                        ProgressWindow wnd = new ProgressWindow("Erstelle Miniaturbilder...", cnt);
                        wnd.Show();

                        for (int i = 0; i < cnt; i++)
                        {
                            createThumb(missingThumbsSrc[i], missingThumbsTrg[i]);
                            if (i % 5 == 0)
                            {
                                wnd.UpdateStatus("Erstelle Miniaturbilder " + i.ToString() + "/" + cnt.ToString(), i);
                                if (wnd.Cancelled)
                                {
                                    wnd.Close();
                                    Application.DoEvents();
                                    break;
                                }
                            }
                        }
                        wnd.Close();
                    }
                    else
                    {
                        //ldg.setProgBarMax(cnt);
                        for (int i = 0; i < cnt; i++)
                        {
                            createThumb(missingThumbsSrc[i], missingThumbsTrg[i]);
                            if (i % 5 == 0)
                            {
                                ldg.setLabel("Erstelle Miniaturbilder " + i.ToString() + "/" + cnt.ToString());

                                //ldg.setProgBarValue(i);
                                Application.DoEvents();
                            }
                        }
                    }
                }
            }
        }

        public bool imageExists(string relativePath)
        {
            if (File.Exists(Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.ImageDir + Path.DirectorySeparatorChar + relativePath))
            {
                return true;
            }
            return false;
        }

        public Image getThumbFromRelPath(string relativePath)
        {
            string imPath = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.ThumbDir + Path.DirectorySeparatorChar + relativePath;
            if (File.Exists(imPath))
            {
                return Image.FromFile(imPath);
            }
            return null;
        }

        public Image getImageFromRelPath(string relativePath)
        {
            string imPath = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.ImageDir + Path.DirectorySeparatorChar + relativePath;
            if (File.Exists(imPath))
            {
                return Image.FromFile(imPath);
            }
            return null;
        }

        public Image getEmptyThumb()
        {
            Image img = new Bitmap(Settings.Default.ThumbSize.Width, Settings.Default.ThumbSize.Height);
            Graphics graph = Graphics.FromImage(img);
            graph.FillRectangle(new SolidBrush(Settings.Default.ProjectionBackColor), 0, 0, img.Width, img.Height);
            graph.Dispose();
            return img;
        }

        public Image getEmptyImage()
        {
            Image img = new Bitmap(1024, 768);
            Graphics graph = Graphics.FromImage(img);
            graph.FillRectangle(new SolidBrush(Settings.Default.ProjectionBackColor), 0, 0, img.Width, img.Height);
            graph.Dispose();
            return img;
        }
    }
}