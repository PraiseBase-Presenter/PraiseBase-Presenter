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
        public Image Image { get; set; }

        private readonly Color _backgroundColor;

        public ImageLayer(Color backgroundColor)
        {
            _backgroundColor = backgroundColor;
        }

        public override void WriteOut(Graphics gr, Object[] args)
        {
            int w = (int)gr.VisibleClipBounds.Width;
            int h = (int)gr.VisibleClipBounds.Height;

            gr.FillRectangle(new SolidBrush(_backgroundColor), 0, 0, w, h);
            if (Image != null)
            {
                gr.DrawImage(Image, new Rectangle(0, 0, w, h), 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel);
            }
        }

    }
}