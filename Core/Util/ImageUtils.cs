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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PraiseBase.Presenter.Util
{
    public class ImageUtils
    {
        /// <summary>
        /// Resizes a given image to new dimensions
        /// </summary>
        /// <param name="sourceImage"></param>
        /// <param name="newSize"></param>
        /// <returns></returns>
        public static Bitmap ResizeBitmap(Image sourceImage, Size newSize)
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
        public static void createThumb(string inFile, string outFile, Size thumbSize)
        {
            Image img;
            try
            {
                img = Image.FromFile(inFile);
                Image imgPhoto = ImageUtils.ResizeBitmap(img, thumbSize);

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
        /// Creates an empty image with the specified size and background color
        /// </summary>
        /// <returns></returns>
        public static Image getEmptyImage(Size size, Color backColor)
        {
            Image img = new Bitmap(size.Width, size.Height);
            Graphics graph = Graphics.FromImage(img);
            graph.FillRectangle(new SolidBrush(backColor), 0, 0, img.Width, img.Height);
            graph.Dispose();
            return img;
        }
    }
}