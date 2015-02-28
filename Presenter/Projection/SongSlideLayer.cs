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
        private SlideTextFormatting formatting;

        public String[] MainText { get; set; }
        public String[] SubText { get; set; }
        public String[] HeaderText { get; set; }
        public String[] FooterText { get; set; }

        public SongSlideLayer(SlideTextFormatting formatting)
        {
            this.formatting = formatting;
        }

        public override void writeOut(System.Drawing.Graphics gr, object[] args)
        {
            int w = (int)gr.VisibleClipBounds.Width;
            int h = (int)gr.VisibleClipBounds.Height;

            if (MainText.Length > 0)
            {
                int usableWidth = w - (2 * formatting.Text.HorizontalPadding);
                int usableHeight = h - (2 * formatting.Text.VerticalPadding);

                int textStartX = formatting.Text.HorizontalPadding;
                int textStartY = formatting.Text.VerticalPadding;

                SizeF strMeasureTrans;

                int endSpacing = 0;
                if (SubText != null && SubText.Length > 0)
                {
                    strMeasureTrans = gr.MeasureString(String.Join(Environment.NewLine, SubText), formatting.Text.SubText.Font);
                    formatting.Text.MainText.LineSpacing += (int)(strMeasureTrans.Height / SubText.Length) + formatting.Text.SubText.LineSpacing;
                    endSpacing = (int)(strMeasureTrans.Height / SubText.Length) + formatting.Text.SubText.LineSpacing;
                }

                SizeF strMeasure = gr.MeasureString(String.Join(Environment.NewLine, MainText), formatting.Text.MainText.Font);
                Brush shadodBrush = Brushes.Transparent;
                int usedWidth = (int)strMeasure.Width;
                int usedHeight = (int)strMeasure.Height + (formatting.Text.MainText.LineSpacing * (MainText.Length - 1)) + endSpacing;

                float scalingFactor = 1.0f;
                if (formatting.ScaleFontSize && (usedWidth > usableWidth || usedHeight > usableHeight))
                {
                    scalingFactor = Math.Min((float)usableWidth / (float)usedWidth, (float)usableHeight / (float)usedHeight);
                    formatting.Text.MainText.Font = new Font(formatting.Text.MainText.Font.FontFamily, formatting.Text.MainText.Font.Size * scalingFactor, formatting.Text.MainText.Font.Style);
                    strMeasure = gr.MeasureString(String.Join(Environment.NewLine, MainText), formatting.Text.MainText.Font);
                    usedWidth = (int)strMeasure.Width;
                    usedHeight = (int)strMeasure.Height + (formatting.Text.MainText.LineSpacing * (MainText.Length - 1));
                }
                int lineHeight = (int)(strMeasure.Height / MainText.Length);

                // Adapt horizontal starting position
                if (formatting.Text.Orientation.Horizontal == HorizontalOrientation.Center)
                {
                    textStartX = w / 2;
                }
                else if (formatting.Text.Orientation.Horizontal == HorizontalOrientation.Right)
                {
                    textStartX = textStartX + usableWidth;
                }

                // Adapt vertical starting position
                if (formatting.Text.Orientation.Vertical == VerticalOrientation.Middle)
                {
                    textStartY = textStartY + (usableHeight / 2) - (usedHeight / 2);
                }
                else if (formatting.Text.Orientation.Vertical == VerticalOrientation.Bottom)
                {
                    textStartY = textStartY + usableHeight - usedHeight;
                }

                // Define string format
                StringFormat strFormat = new StringFormat();
                mapStringFormatAlignment(formatting.Text.Orientation.Horizontal, strFormat);

                // Draw main text
                drawLines(gr, MainText, textStartX, textStartY, strFormat, formatting.Text.MainText, formatting.OutlineEnabled, formatting.ShadowEnabled, lineHeight);

                // Sub-text (translation)
                if (SubText != null && SubText.Length > 0)
                {
                    drawLines(gr, SubText, textStartX + 10, textStartY + lineHeight, strFormat, formatting.Text.SubText, formatting.OutlineEnabled, formatting.ShadowEnabled, lineHeight);
                }
            }

            //
            // Header text (source)
            //
            if (HeaderText != null && HeaderText.Length > 0)
            {
                SizeF headerMeasure = gr.MeasureString(String.Join(Environment.NewLine, HeaderText), formatting.Header.Text.Font);
                int headerPosX = formatting.Header.HorizontalPadding;
                if (formatting.Header.HorizontalOrientation == HorizontalOrientation.Center)
                {
                    headerPosX = w / 2;
                }
                else if (formatting.Header.HorizontalOrientation == HorizontalOrientation.Right)
                {
                    headerPosX = w - formatting.Header.HorizontalPadding;
                }
                int headerPoxY = formatting.Header.VerticalPadding;
                int lineHeight = (int)(headerMeasure.Height / HeaderText.Length);
                StringFormat headerStrFormat = new StringFormat();
                mapStringFormatAlignment(formatting.Header.HorizontalOrientation, headerStrFormat);
                drawLines(gr, HeaderText, headerPosX, headerPoxY, headerStrFormat, formatting.Header.Text, formatting.OutlineEnabled, formatting.ShadowEnabled, lineHeight);
            }

            //
            // Footer text (copyright)
            //
            if (FooterText != null && FooterText.Length > 0)
            {
                SizeF footerMeasure = gr.MeasureString(String.Join(Environment.NewLine, FooterText), formatting.Footer.Text.Font);
                int footerPosX = formatting.Footer.HorizontalPadding;
                if (formatting.Footer.HorizontalOrientation == HorizontalOrientation.Center)
                {
                    footerPosX = w / 2;
                }
                else if (formatting.Footer.HorizontalOrientation == HorizontalOrientation.Right)
                {
                    footerPosX = w - formatting.Footer.HorizontalPadding;
                }
                int footerPosY = h - formatting.Footer.VerticalPadding - (int)footerMeasure.Height;
                int lineHeight = (int)(footerMeasure.Height / FooterText.Length);
                StringFormat footerStrFormat = new StringFormat();
                mapStringFormatAlignment(formatting.Footer.HorizontalOrientation, footerStrFormat);
                drawLines(gr, FooterText, footerPosX, footerPosY, footerStrFormat, formatting.Footer.Text, formatting.OutlineEnabled, formatting.ShadowEnabled, lineHeight);
            }
        }

        private static void mapStringFormatAlignment(HorizontalOrientation to, StringFormat strFormat) 
        {
            switch (to)
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

        private static void drawLines(Graphics gr, String[] lines, int textStartX, int textStartY,
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