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
using PraiseBase.Presenter.Properties;

namespace PraiseBase.Presenter
{
    public class ImageLayer : BaseLayer
    {
        public Image Image { get; set; }

        public override void writeOut(System.Drawing.Graphics gr, Object[] args)
        {
            int w = (int)gr.VisibleClipBounds.Width;
            int h = (int)gr.VisibleClipBounds.Height;

            gr.FillRectangle(new SolidBrush(Settings.Default.ProjectionBackColor), 0, 0, w, h);
            if (this.Image != null)
            {
                gr.DrawImage(this.Image, new Rectangle(0, 0, w, h), 0, 0, this.Image.Width, this.Image.Height, GraphicsUnit.Pixel);
            }
        }

    }
}