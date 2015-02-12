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
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using PraiseBase.Presenter.Model;
using System.Collections.Generic;
using PraiseBase.Presenter.Projection;

namespace PraiseBase.Presenter
{
    internal class SongSlideLayer : TextLayer
    {
        private SongSlideLayerFormatting formatting;

        public String[] MainText { get; set; }
        public String[] SubText { get; set; }
        public String[] HeaderText { get; set; }
        public String[] FooterText { get; set; }

        public SongSlideLayer(SongSlideLayerFormatting formatting)
        {
            this.formatting = formatting;
        }

        public override void writeOut(System.Drawing.Graphics gr, object[] args)
        {
            int w = (int)gr.VisibleClipBounds.Width;
            int h = (int)gr.VisibleClipBounds.Height;

            if (MainText.Length > 0)
            {
                int padding = formatting.TextBorders.TextLeft;

                int usableWidth = w - (2 * padding);
                int usableHeight = h - (2 * padding);

                int textStartX = padding;
                int textStartY = padding;

                SizeF strMeasureTrans;

                int endSpacing = 0;
                if (SubText != null && SubText.Length > 0)
                {
                    strMeasureTrans = gr.MeasureString(String.Join(Environment.NewLine, SubText), formatting.SubText.Font);
                    formatting.MainText.LineSpacing += (int)(strMeasureTrans.Height / SubText.Length) + formatting.SubText.LineSpacing;
                    endSpacing = (int)(strMeasureTrans.Height / SubText.Length) + formatting.SubText.LineSpacing;
                }

                SizeF strMeasure = gr.MeasureString(String.Join(Environment.NewLine, MainText), formatting.MainText.Font);
                Brush shadodBrush = Brushes.Transparent;
                int usedWidth = (int)strMeasure.Width;
                int usedHeight = (int)strMeasure.Height + (formatting.MainText.LineSpacing * (MainText.Length - 1)) + endSpacing;

                float scalingFactor = 1.0f;
                if (formatting.ScaleFontSize && (usedWidth > usableWidth || usedHeight > usableHeight))
                {
                    scalingFactor = Math.Min((float)usableWidth / (float)usedWidth, (float)usableHeight / (float)usedHeight);
                    formatting.MainText.Font = new Font(formatting.MainText.Font.FontFamily, formatting.MainText.Font.Size * scalingFactor, formatting.MainText.Font.Style);
                    strMeasure = gr.MeasureString(String.Join(Environment.NewLine, MainText), formatting.MainText.Font);
                    usedWidth = (int)strMeasure.Width;
                    usedHeight = (int)strMeasure.Height + (formatting.MainText.LineSpacing * (MainText.Length - 1));
                }
                int lineHeight = (int)(strMeasure.Height / MainText.Length);

                // Adapt horizontal starting position
                if (formatting.TextOrientation.Horizontal == HorizontalOrientation.Center)
                {
                    textStartX = w / 2;
                }
                else if (formatting.TextOrientation.Horizontal == HorizontalOrientation.Right)
                {
                    textStartX = textStartX + usableWidth;
                }

                // Adapt vertical starting position
                if (formatting.TextOrientation.Vertical == VerticalOrientation.Middle)
                {
                    textStartY = textStartY + (usableHeight / 2) - (usedHeight / 2);
                }
                else if (formatting.TextOrientation.Vertical == VerticalOrientation.Bottom)
                {
                    textStartY = textStartY + usableHeight - usedHeight;
                }
                
                //int textX = textStartX;
                //int textY = textStartY;

                // Define string format
                StringFormat strFormat = new StringFormat();
                MapStringFormatAlignment(formatting.TextOrientation, strFormat);

                // Draw main text
                DrawLines(gr, MainText, textStartX, textStartY, strFormat, formatting.MainText, formatting.TextOutlineEnabled, formatting.TextShadowEnabled, lineHeight);

                // Sub-text (translation)
                if (SubText != null && SubText.Length > 0)
                {
                    DrawLines(gr, SubText, textStartX + 10, textStartY + lineHeight, strFormat, formatting.SubText, formatting.TextOutlineEnabled, formatting.TextShadowEnabled, lineHeight);
                }
            }

            //
            // Header text (source)
            //
            if (HeaderText != null && HeaderText.Length > 0)
            {
                SizeF headerMeasure = gr.MeasureString(String.Join(Environment.NewLine, HeaderText), formatting.HeaderText.Font);
                int headerPosX = w - formatting.TextBorders.SourceRight;
                int headerPoxY = formatting.TextBorders.SourceTop;
                int lineHeight = (int)(headerMeasure.Height / HeaderText.Length);
                StringFormat headerStrFormat = new StringFormat();
                headerStrFormat.Alignment = StringAlignment.Far;
                DrawLines(gr, HeaderText, headerPosX, headerPoxY, headerStrFormat, formatting.HeaderText, formatting.TextOutlineEnabled, formatting.TextShadowEnabled, lineHeight);
            }

            //
            // Footer text (copyright)
            //
            if (FooterText != null && FooterText.Length > 0)
            {
                SizeF footerMeasure = gr.MeasureString(String.Join(Environment.NewLine, FooterText), formatting.FooterText.Font);
                int footerPosX = w / 2;
                int footerPosY = h - formatting.TextBorders.CopyrightBottom - (int)footerMeasure.Height;
                int lineHeight = (int)(footerMeasure.Height / FooterText.Length);
                StringFormat footerStrFormat = new StringFormat();
                footerStrFormat.Alignment = StringAlignment.Center;
                DrawLines(gr, FooterText, footerPosX, footerPosY, footerStrFormat, formatting.FooterText, formatting.TextOutlineEnabled, formatting.TextShadowEnabled, lineHeight);
            }
        }

        private static void MapStringFormatAlignment(TextOrientation to, StringFormat strFormat) 
        {
            switch (to.Horizontal)
            {
                case HorizontalOrientation.Left:
                    strFormat.Alignment = StringAlignment.Near;
                    break;
                case HorizontalOrientation.Center:
                    strFormat.Alignment = StringAlignment.Center;
                    break;
                case HorizontalOrientation.Right:
                    strFormat.Alignment = StringAlignment.Far;
                    break;
            }
        }

        private static void DrawLines(Graphics gr, String[] lines, int textStartX, int textStartY,
            StringFormat strFormat, TextFormatting textFormatting, bool outline, bool shadow, int lineHeight)
        {
            int textX = textStartX;
            int textY = textStartY;

            // Shadow
            if (shadow)
            {
                Brush shadodBrush = Brushes.Transparent;

                int shadowThickness = textFormatting.Shadow.Distance;
                if (shadowThickness > 0)
                {
                    shadodBrush = new SolidBrush(Color.FromArgb(15, textFormatting.Shadow.Color));
                    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    foreach (string s in lines)
                    {
                        for (int x = textX; x <= textX + shadowThickness; x++)
                        {
                            for (int y = textY; y <= textY + shadowThickness; y++)
                            {
                                gr.DrawString(s, textFormatting.Font, shadodBrush, new Point(x, y), strFormat);
                            }
                        }
                        textY += lineHeight + textFormatting.LineSpacing;
                    }
                    textY = textStartY;
                }
            }

            // Outline
            if (outline)
            {
                int outLineThickness = textFormatting.Outline.Width;
                if (outLineThickness > 0)
                {
                    gr.SmoothingMode = SmoothingMode.None;
                    gr.InterpolationMode = InterpolationMode.Low;
                    gr.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                    Brush br = new SolidBrush(textFormatting.Outline.Color);

                    foreach (string s in lines)
                    {
                        for (int x = textX - outLineThickness * 2; x <= textX + outLineThickness * 2; x += 2)
                        {
                            for (int y = textY - outLineThickness * 2; y <= textY + outLineThickness * 2; y += 2)
                            {
                                gr.DrawString(s, textFormatting.Font, br, new Point(x, y), strFormat);
                            }
                        }
                        textY += lineHeight + textFormatting.LineSpacing;
                    }
                    textY = textStartY;
                }
            }

            // Text
            foreach (string s in lines)
            {
                gr.DrawString(s, textFormatting.Font, new SolidBrush(textFormatting.Color), new Point(textX, textY), strFormat);
                textY += lineHeight + textFormatting.LineSpacing;
            }
        }
    }
}