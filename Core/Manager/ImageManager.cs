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
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Util;

namespace PraiseBase.Presenter.Manager
{
    public class ImageManager
    {
        private const string ExcludeThumbDirName = "[Thumbnails]";
        private readonly string[] _imgExtensions = {"*.jpg"};

        /// <summary>
        ///     Private constructor
        /// </summary>
        public ImageManager(String imageDirPath, String thumbDirPath)
        {
            ImageDirPath = imageDirPath;
            if (!Directory.Exists(ImageDirPath))
            {
                Directory.CreateDirectory(ImageDirPath);
            }

            ThumbDirPath = thumbDirPath;
            if (!Directory.Exists(ThumbDirPath))
            {
                var di = Directory.CreateDirectory(ThumbDirPath);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            DefaultThumbSize = new Size(80, 60);
            DefaultImageSize = new Size(1024, 768);
        }

        /// <summary>
        ///     Default size for new images
        /// </summary>
        public Size DefaultImageSize { get; set; }

        /// <summary>
        ///     Default thumbnail size
        /// </summary>
        public Size DefaultThumbSize { get; set; }

        /// <summary>
        ///     Default image color for empty images
        /// </summary>
        public Color DefaultEmptyColor { get; set; }

        /// <summary>
        ///     Base path to the image directory
        /// </summary>
        public string ImageDirPath { get; protected set; }

        /// <summary>
        ///     Base path to the thumbnails directory
        /// </summary>
        public string ThumbDirPath { get; protected set; }

        /// <summary>
        ///     Check and create thumbnails if necessary
        /// </summary>
        public void CheckThumbs()
        {
            var missingThumbsSrc = new List<string>();
            var missingThumbsTrg = new List<string>();
            foreach (var ext in _imgExtensions)
            {
                var paths = Directory.GetFiles(ImageDirPath, ext, SearchOption.AllDirectories);
                foreach (var file in paths)
                {
                    if (!file.Contains(ExcludeThumbDirName) && !file.StartsWith(ThumbDirPath))
                    {
                        var relativePath = file.Substring((ImageDirPath + Path.DirectorySeparatorChar).Length);
                        var thumbPath = ThumbDirPath + Path.DirectorySeparatorChar + relativePath;
                        if (!File.Exists(thumbPath))
                        {
                            missingThumbsSrc.Add(file);
                            missingThumbsTrg.Add(thumbPath);
                        }
                    }
                }
            }

            var cnt = missingThumbsSrc.Count;
            if (cnt > 0)
            {
                for (var i = 0; i < cnt; i++)
                {
                    ImageUtils.createThumb(missingThumbsSrc[i], missingThumbsTrg[i], DefaultThumbSize);
                    if (i%10 == 0)
                    {
                        var e = new ThumbnailCreateEventArgs(i, cnt);
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

        public Image GetImage(string path)
        {
            if (path == null)
            {
                return ImageUtils.getEmptyImage(DefaultImageSize, DefaultEmptyColor);
            }
            try
            {
                var img = GetImageFromRelPath(path);
                if (img != null)
                {
                    return img;
                }
                throw new Exception("Das Bild " + path + " existiert nicht!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ImageUtils.getEmptyImage(DefaultImageSize, DefaultEmptyColor);
            }
        }

        public Image GetImage(IBackground bg)
        {
            if (bg != null)
            {
                if (bg.GetType() == typeof (ImageBackground))
                {
                    return GetImage(((ImageBackground) bg).ImagePath);
                }
                if (bg.GetType() == typeof (ColorBackground))
                {
                    return ImageUtils.getEmptyImage(DefaultImageSize, ((ColorBackground) bg).Color);
                }
            }
            return null;
        }

        public Image GetThumb(IBackground bg)
        {
            if (bg != null)
            {
                if (bg.GetType() == typeof (ImageBackground))
                {
                    var img = GetThumbFromRelPath(((ImageBackground) bg).ImagePath);
                    if (img != null)
                    {
                        return img;
                    }
                }
                else if (bg.GetType() == typeof (ColorBackground))
                {
                    return ImageUtils.getEmptyImage(DefaultThumbSize, ((ColorBackground) bg).Color);
                }
            }
            return ImageUtils.getEmptyImage(DefaultThumbSize, DefaultEmptyColor);
        }

        /// <summary>
        ///     Searches images and returns their relative paths
        /// </summary>
        /// <param name="needle"></param>
        /// <returns></returns>
        public List<string> SearchImages(string needle)
        {
            var results = new List<string>();
            var rootDir = ThumbDirPath + Path.DirectorySeparatorChar;
            var rootDirStrLen = rootDir.Length;
            foreach (var ext in _imgExtensions)
            {
                var imgFilePaths = Directory.GetFiles(rootDir, ext, SearchOption.AllDirectories);
                foreach (var ims in imgFilePaths)
                {
                    if (!ims.Contains(ExcludeThumbDirName) && !ims.StartsWith(ThumbDirPath))
                    {
                        var haystack = Path.GetFileNameWithoutExtension(ims);
                        if (haystack.ToLower().Contains(needle))
                        {
                            results.Add(ims.Substring(rootDirStrLen));
                        }
                    }
                }
            }
            return results;
        }

        #region Events

        public delegate void ThumbnailCreate(ThumbnailCreateEventArgs e);

        public event ThumbnailCreate ThumbnailCreated;

        public class ThumbnailCreateEventArgs : EventArgs
        {
            public ThumbnailCreateEventArgs(int number, int total)
            {
                Number = number;
                Total = total;
            }

            public int Number { get; set; }
            public int Total { get; set; }
        }

        protected virtual void OnThumbnailCreated(ThumbnailCreateEventArgs e)
        {
            if (ThumbnailCreated != null)
            {
                ThumbnailCreated(e);
            }
        }

        #endregion Events
    }
}