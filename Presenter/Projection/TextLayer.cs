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
    public abstract class TextLayer : BaseLayer
    {
        protected void drawString(Graphics gr, string str, int x, int y, Font font, Brush fontBrush, StringFormat strFormat)
        {
            int shadowThickness = Settings.Default.ProjectionShadowSize;
            int outLineThickness = Settings.Default.ProjectionOutlineSize;

            Brush outlineBrush = new SolidBrush(Settings.Default.ProjectionOutlineColor);
            Brush shadowBrush = new SolidBrush(Color.FromArgb(15, Settings.Default.ProjectionShadowColor));

            /*
            if (shadowThickness > 0)
            {
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                for (int ox = x; ox <= x + shadowThickness; ox++)
                {
                    for (int oy = y; oy <= y + shadowThickness; oy++)
                    {
                        gr.DrawString(str, font, shadowBrush, new Point(ox, oy), strFormat);
                    }
                }
                gr.SmoothingMode = SmoothingMode.None;
                gr.InterpolationMode = InterpolationMode.Low;
                gr.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            }*/

            if (outLineThickness > 0)
            {
                for (int ox = x - outLineThickness * 2; ox <= x + outLineThickness * 2; ox += 2)
                {
                    for (int oy = y - outLineThickness * 2; oy <= y + outLineThickness * 2; oy += 2)
                    {
                        gr.DrawString(str, font, outlineBrush, new Point(ox, oy), strFormat);
                    }
                }
            }
            gr.DrawString(str, font, fontBrush, new Point(x, y), strFormat);
        }
    }
}