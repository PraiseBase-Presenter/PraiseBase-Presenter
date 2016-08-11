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
using System.Drawing;

namespace PraiseBase.Presenter.Projection
{
    public class ImageLayer : BaseLayer
    {
        private readonly Color _backgroundColor;

        public ImageLayer(Color backgroundColor)
        {
            _backgroundColor = backgroundColor;
        }

        public Image Image { get; set; }

        public BackgroundImageFit ImageFit { get; set; } = BackgroundImageFit.Stretch;

        public override void WriteOut(Graphics gr, object[] args)
        {
            var w = (int) gr.VisibleClipBounds.Width;
            var h = (int) gr.VisibleClipBounds.Height;

            gr.FillRectangle(new SolidBrush(_backgroundColor), 0, 0, w, h);
            if (Image != null)
            {
                var rect = new Rectangle(0, 0, w, h);

                if (ImageFit != BackgroundImageFit.Stretch)
                {
                    double xFactor = w / (double)Image.Width;
                    double yFactor = h / (double)Image.Height;

                    if (xFactor != 1 || yFactor != 1)
                    {
                        double factor = 1d;
                        if (ImageFit == BackgroundImageFit.Fill)
                        {
                            factor = Math.Max(xFactor, yFactor);
                        }
                        else if (ImageFit == BackgroundImageFit.Fit)
                        {
                            factor = Math.Min(xFactor, yFactor);
                        }
                        rect.Width = (int)(Image.Width * factor);
                        rect.Height = (int)(Image.Height * factor);

                        int sign = 1;
                        if (ImageFit == BackgroundImageFit.Fill)
                        {
                            sign = -1;
                        }
                        if (rect.Width != w)
                        {
                            rect.X = sign * Math.Sign(rect.Width - w) * ((rect.Width - w) / 2);
                        }
                        if (rect.Height != h)
                        {
                            rect.Y = sign * Math.Sign(rect.Height - h) * ((rect.Height - h) / 2);
                        }
                    }
                }

                gr.DrawImage(Image, rect, 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel);
            }
        }
    }
}