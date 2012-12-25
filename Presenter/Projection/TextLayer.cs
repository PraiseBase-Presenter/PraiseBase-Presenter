using System;
using System.Drawing;
using Pbp.Properties;

namespace Pbp
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