﻿/*
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
using System.Linq;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Util;

namespace PraiseBase.Presenter.Manager
{
    public class ImageManager
    {
        // Here is the once-per-class call to initialize the log object
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string ExcludeThumbDirName = "[Thumbnails]";
        private readonly string[] _imgExtensions = {"*.jpg", ".jpeg"};

        /// <summary>
        ///     Private constructor
        /// </summary>
        public ImageManager(string imageDirPath, string thumbDirPath)
        {
            ImageDirPath = imageDirPath;
            ThumbDirPath = thumbDirPath;

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
        public string ImageDirPath { get; set; }

        /// <summary>
        ///     Base path to the thumbnails directory
        /// </summary>
        public string ThumbDirPath { get; set; }

        /// <summary>
        ///     Check and create thumbnails if necessary
        /// </summary>
        /// <param name="cleanup">If set to true, will cleanup images of which no original file exists</param>
        public void CheckThumbs(bool cleanup)
        {
            // Cleanup
            if (cleanup)
            {
                CleanupThumbs();
            }

            // Update thumbnails
            List<string> paths = new List<string>();
            foreach (var ext in _imgExtensions)
            {
                paths.AddRange(Directory.GetFiles(ImageDirPath, ext, SearchOption.AllDirectories));
            }
            CheckThumbnailFiles(paths.ToArray());
        }

        /// <summary>
        /// Cleanup thumbnail images
        /// </summary>
        private void CleanupThumbs()
        {
            // Cleanup images of which no original file exists
            foreach (var ext in _imgExtensions)
            {
                var tumbPaths = Directory.GetFiles(ThumbDirPath, ext, SearchOption.AllDirectories);
                foreach (var file in tumbPaths)
                {
                    var realImage = file.Replace(ThumbDirPath, ImageDirPath);
                    if (!File.Exists(realImage))
                    {
                        File.Delete(file);
                    }
                }
            }

            // Cleanup empty directories
            FileUtils.RemoveEmptySubdirectories(ThumbDirPath);
        }

        private void CheckThumbnailFiles(string[] paths) {
            var missingThumbsSrc = new List<string>();
            var missingThumbsTrg = new List<string>();
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
            var cnt = missingThumbsSrc.Count;
            if (cnt > 0)
            {
                for (var i = 0; i < cnt; i++)
                {
                    ImageUtils.CreateThumb(missingThumbsSrc[i], missingThumbsTrg[i], DefaultThumbSize);
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
                return ImageUtils.GetEmptyImage(DefaultImageSize, DefaultEmptyColor);
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
                log.Error(e.Message);
                return ImageUtils.GetEmptyImage(DefaultImageSize, DefaultEmptyColor);
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
                    return ImageUtils.GetEmptyImage(DefaultImageSize, ((ColorBackground) bg).Color);
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
                    return ImageUtils.GetEmptyImage(DefaultThumbSize, ((ColorBackground) bg).Color);
                }
            }
            return ImageUtils.GetEmptyImage(DefaultThumbSize, DefaultEmptyColor);
        }

        /// <summary>
        ///     Searches images and returns their relative paths
        /// </summary>
        /// <param name="needle"></param>
        /// <returns></returns>
        public List<string> SearchImages(string needle)
        {
            var rootDir = ImageDirPath + Path.DirectorySeparatorChar;
            var rootDirStrLen = rootDir.Length;
            return (from ext in _imgExtensions from ims in Directory.GetFiles(rootDir, ext, SearchOption.AllDirectories) where !ims.Contains(ExcludeThumbDirName) && !ims.StartsWith(ThumbDirPath) let haystack = Path.GetFileNameWithoutExtension(ims) where haystack.ToLower().Contains(needle) select ims.Substring(rootDirStrLen)).ToList();
        }

        public void ImportImage(string sourcePath)
        {
            ImportImage(sourcePath, null);
        }

        public void ImportImage(string sourcePath, string relativeTargetPath)
        {
            string target = ImageDirPath;
            if (relativeTargetPath != null)
            {
                target += "\\" + relativeTargetPath;
            }
            if (Directory.Exists(target))
            {
                target += "\\" + Path.GetFileName(sourcePath);
                File.Copy(sourcePath, target, true);
                CheckThumbnailFiles(new string[] { target });
                ImageImported?.Invoke(target);
            }
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
            ThumbnailCreated?.Invoke(e);
        }

        public delegate void ImageImport(string path);

        public event ImageImport ImageImported;

        #endregion Events
    }
}