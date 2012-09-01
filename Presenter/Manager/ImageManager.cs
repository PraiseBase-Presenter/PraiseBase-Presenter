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
using Pbp.Utils;

namespace Pbp
{
    internal class ImageManager
    {
        /// <summary>
        /// Default size for new images
        /// </summary>
        protected readonly static Size DefaultImageSize = new Size(1024, 768);

        /// <summary>
        /// The singleton holder
        /// </summary>
        static private ImageManager _instance;

        /// <summary>
        /// Current image
        /// </summary>
        public Image currentImage { get; set; }

        /// <summary>
        /// Base path to the image directory
        /// </summary>
        protected string imageDirPath;

        /// <summary>
        /// Base path to the thumbnails directory
        /// </summary>
        protected string thumbDirPath;

        #region Events

        public delegate void ThumbnailCreate(ThumbnailCreateEventArgs e);

        public event ThumbnailCreate ThumbnailCreated;

        public class ThumbnailCreateEventArgs : EventArgs
        {
            public int Number { get; set; }

            public int Total { get; set; }

            public ThumbnailCreateEventArgs(int number, int total)
            {
                this.Number = number;
                this.Total = total;
            }
        }

        protected virtual void OnThumbnailCreated(ThumbnailCreateEventArgs e)
        {
            if (ThumbnailCreated != null)
            {
                ThumbnailCreated(e);
            }
        }

        #endregion Events

        /// <summary>
        /// Private constructor
        /// </summary>
        protected ImageManager()
        {
            imageDirPath = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + 
                Settings.Default.ImageDir + Path.DirectorySeparatorChar;
            thumbDirPath = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + 
                Settings.Default.ThumbDir + Path.DirectorySeparatorChar;
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
        /// Check and create thumbnails if necessary
        /// </summary>
        /// <param name="ldg"></param>
        public void checkThumbs()
        {
            if (!Directory.Exists(imageDirPath))
            {
                Directory.CreateDirectory(imageDirPath);
            }
            if (!Directory.Exists(thumbDirPath))
            {
                Directory.CreateDirectory(thumbDirPath);
            }

            string[] imgExtensions = { "*.jpg" };

            List<string> missingThumbsSrc = new List<string>();
            List<string> missingThumbsTrg = new List<string>();
            foreach (string ext in imgExtensions)
            {
                string[] paths = Directory.GetFiles(imageDirPath, ext, SearchOption.AllDirectories);
                foreach (string file in paths)
                {
                    string relativePath = file.Substring((imageDirPath + Path.DirectorySeparatorChar).Length);
                    string thumbPath = thumbDirPath + relativePath;
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
                for (int i = 0; i < cnt; i++)
                {
                    ImageUtils.createThumb(missingThumbsSrc[i], missingThumbsTrg[i], Settings.Default.ThumbSize);
                    if (i % 5 == 0)
                    {
                        ThumbnailCreateEventArgs e = new ThumbnailCreateEventArgs(i, cnt);
                        OnThumbnailCreated(e);
                    }
                }
            }
        }

        public bool imageExists(string relativePath)
        {
            return File.Exists(imageDirPath + relativePath);
        }

        public Image getThumbFromRelPath(string relativePath)
        {
            if (File.Exists(thumbDirPath + relativePath))
            {
                return Image.FromFile(thumbDirPath + relativePath);
            }
            return null;
        }

        public Image getImageFromRelPath(string relativePath)
        {
            if (File.Exists(imageDirPath + relativePath))
            {
                return Image.FromFile(imageDirPath + relativePath);
            }
            return null;
        }

        public ImageList getThumbsFromList(List<string> imageList)
        {
            var thumbList = new ImageList();
            thumbList.ImageSize = Settings.Default.ThumbSize;
            thumbList.ColorDepth = ColorDepth.Depth32Bit;

            Image th = ImageUtils.getEmptyImage(Settings.Default.ThumbSize, Settings.Default.ProjectionBackColor);
            thumbList.Images.Add(th);
            foreach (String relPath in imageList)
            {
                Image img = getThumbFromRelPath(relPath);
                if (img != null)
                    thumbList.Images.Add(img);
            }
            return thumbList;
        }

        public Image getImage(string path)
        {
            if (path == null)
            {
                return ImageUtils.getEmptyImage(DefaultImageSize, Settings.Default.ProjectionBackColor);
            }
            try
            {
                Image img = getImageFromRelPath(path);
                if (img != null)
                {
                    return img;
                }
                else
                {
                    throw new Exception("Das Bild " + path + " existiert nicht!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ImageUtils.getEmptyImage(DefaultImageSize, Settings.Default.ProjectionBackColor);
            }
        }
    }
}