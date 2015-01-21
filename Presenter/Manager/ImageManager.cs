/*
 *   PraiseBase Presenter
 *   The open source lyrics and image projection software for churches
 *
 *   http://praisebase.org
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
using PraiseBase.Presenter.Forms;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Util;

namespace PraiseBase.Presenter
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
        public string ImageDirPath { get; protected set; }

        /// <summary>
        /// Base path to the thumbnails directory
        /// </summary>
        public string ThumbDirPath { get; protected set; }

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
            ImageDirPath = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + 
                Settings.Default.ImageDir;
            if (!Directory.Exists(ImageDirPath))
            {
                Directory.CreateDirectory(ImageDirPath);
            }

            ThumbDirPath = Settings.Default.DataDirectory + Path.DirectorySeparatorChar +
                Settings.Default.ThumbDir;
            if (!Directory.Exists(ThumbDirPath))
            {
                Directory.CreateDirectory(ThumbDirPath);
            }
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
        public void CheckThumbs()
        {
            string[] imgExtensions = { "*.jpg" };

            List<string> missingThumbsSrc = new List<string>();
            List<string> missingThumbsTrg = new List<string>();
            foreach (string ext in imgExtensions)
            {
                string[] paths = Directory.GetFiles(ImageDirPath, ext, SearchOption.AllDirectories);
                foreach (string file in paths)
                {
                    if (!file.Contains("[Thumbnails]"))
                    {
                        string relativePath = file.Substring((ImageDirPath + Path.DirectorySeparatorChar).Length);
                        string thumbPath = ThumbDirPath + Path.DirectorySeparatorChar + relativePath;
                        if (!File.Exists(thumbPath))
                        {
                            missingThumbsSrc.Add(file);
                            missingThumbsTrg.Add(thumbPath);
                        }
                    }
                }
            }

            int cnt = missingThumbsSrc.Count;
            if (cnt > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    ImageUtils.createThumb(missingThumbsSrc[i], missingThumbsTrg[i], Settings.Default.ThumbSize);
                    if (i % 10 == 0)
                    {
                        ThumbnailCreateEventArgs e = new ThumbnailCreateEventArgs(i, cnt);
                        OnThumbnailCreated(e);
                    }
                }
            }
        }

        public Image GetThumbFromRelPath(string relativePath)
        {
            if (File.Exists(ThumbDirPath + Path.DirectorySeparatorChar + relativePath))
            {
                return Image.FromFile(ThumbDirPath + Path.DirectorySeparatorChar + relativePath);
            }
            return null;
        }

        public Image GetImageFromRelPath(string relativePath)
        {
            if (File.Exists(ImageDirPath + Path.DirectorySeparatorChar + relativePath))
            {
                return Image.FromFile(ImageDirPath + Path.DirectorySeparatorChar + relativePath);
            }
            return null;
        }

        public Dictionary<int, Image> GetThumbsFromList(List<string> imageList)
        {
            var thumbList = new Dictionary<int, Image>();
            //thumbList.ImageSize = Settings.Default.ThumbSize;
            //thumbList.ColorDepth = ColorDepth.Depth32Bit;

            int i = 0;
            Image th = ImageUtils.getEmptyImage(Settings.Default.ThumbSize, Settings.Default.ProjectionBackColor);
            thumbList.Add(i++, th);
            foreach (String relPath in imageList)
            {
                Image img = GetThumbFromRelPath(relPath);
                if (img != null)
                {
                    thumbList.Add(i++, img);
                }
            }
            return thumbList;
        }

        public Image GetImage(string path)
        {
            if (path == null)
            {
                return ImageUtils.getEmptyImage(DefaultImageSize, Settings.Default.ProjectionBackColor);
            }
            try
            {
                Image img = GetImageFromRelPath(path);
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

        /// <summary>
        /// Searches images and returns their relative paths
        /// </summary>
        /// <param name="needle"></param>
        /// <returns></returns>
        public List<string> SearchImages(string needle) {
            List<string> results = new List<string>();
            string rootDir = ImageManager.Instance.ThumbDirPath + Path.DirectorySeparatorChar;
            int rootDirStrLen = rootDir.Length;
            string[] imgFilePaths = Directory.GetFiles(rootDir, "*.jpg", SearchOption.AllDirectories);
            foreach (string ims in imgFilePaths)
            {
                if (!ims.Contains("[Thumbnails]"))
                {
                    string haystack = Path.GetFileNameWithoutExtension(ims);
                    if (haystack.ToLower().Contains(needle))
                    {
                        results.Add(ims.Substring(rootDirStrLen));
                    }
                }
            }
            return results;
        }
    }
}