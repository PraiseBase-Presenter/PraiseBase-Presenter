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

        public List<String> MainText { get; set; }
        public List<String> SubText { get; set; }
        public String HeaderText { get; set; }
        public String FooterText { get; set; }

        public SongSlideLayer(SongSlideLayerFormatting formatting)
        {
            this.formatting = formatting;
        }

        public override void writeOut(System.Drawing.Graphics gr, object[] args)
        {
            int w = (int)gr.VisibleClipBounds.Width;
            int h = (int)gr.VisibleClipBounds.Height;

            if (MainText.Count > 0)
            {
                StringFormat strFormat = new StringFormat();

                int padding = formatting.TextBorders.TextLeft;
                int shadowThickness = formatting.MainText.Shadow.Distance;
                int outLineThickness = formatting.MainText.Outline.Width;
                String str = String.Empty;

                int usableWidth = w - (2 * padding);
                int usableHeight = h - (2 * padding);

                int textStartX = padding;
                int textStartY = padding;

                SizeF strMeasureTrans;

                int endSpacing = 0;
                if (SubText != null && SubText.Count > 0)
                {
                    strMeasureTrans = gr.MeasureString(ListToString(SubText), formatting.TranslationText.Font);
                    formatting.MainText.LineSpacing += (int)(strMeasureTrans.Height / SubText.Count) + formatting.TranslationText.LineSpacing;
                    endSpacing = (int)(strMeasureTrans.Height / SubText.Count) + formatting.TranslationText.LineSpacing;
                }

                SizeF strMeasure = gr.MeasureString(ListToString(MainText), formatting.MainText.Font);
                Brush shadodBrush = Brushes.Transparent;
                int usedWidth = (int)strMeasure.Width;
                int usedHeight = (int)strMeasure.Height + (formatting.MainText.LineSpacing * (MainText.Count - 1)) + endSpacing;

                float scalingFactor = 1.0f;
                if (formatting.ScaleFontSize && (usedWidth > usableWidth || usedHeight > usableHeight))
                {
                    scalingFactor = Math.Min((float)usableWidth / (float)usedWidth, (float)usableHeight / (float)usedHeight);
                    formatting.MainText.Font = new Font(formatting.MainText.Font.FontFamily, formatting.MainText.Font.Size * scalingFactor, formatting.MainText.Font.Style);
                    strMeasure = gr.MeasureString(ListToString(MainText), formatting.MainText.Font);
                    usedWidth = (int)strMeasure.Width;
                    usedHeight = (int)strMeasure.Height + (formatting.MainText.LineSpacing * (MainText.Count - 1));
                }
                int lineHeight = (int)(strMeasure.Height / MainText.Count);

                // Horizontal stuff
                switch (formatting.TextOrientation.Horizontal)
                {
                    case HorizontalOrientation.Left:
                        strFormat.Alignment = StringAlignment.Near;
                        break;
                    case HorizontalOrientation.Center:
                        textStartX = w / 2;
                        strFormat.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalOrientation.Right:
                        textStartX = textStartX + usableWidth;
                        strFormat.Alignment = StringAlignment.Far;
                        break;
                }

                // Vertical stuff
                switch (formatting.TextOrientation.Vertical)
                {
                    case VerticalOrientation.Top:
                        // Nothing to do
                        break;
                    case VerticalOrientation.Middle:
                        textStartY = textStartY + (usableHeight / 2) - (usedHeight / 2);
                        break;
                    case VerticalOrientation.Bottom:
                        textStartY = textStartY + usableHeight - usedHeight;
                        break;
                }

                int textX = textStartX;
                int textY = textStartY;

                if (shadowThickness > 0)
                {
                    shadodBrush = new SolidBrush(Color.FromArgb(15, formatting.MainText.Shadow.Color));
                    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    foreach (string s in MainText)
                    {
                        for (int x = textX; x <= textX + shadowThickness; x++)
                        {
                            for (int y = textY; y <= textY + shadowThickness; y++)
                            {
                                gr.DrawString(s, formatting.MainText.Font, shadodBrush, new Point(x, y), strFormat);
                            }
                        }
                        textY += lineHeight + formatting.MainText.LineSpacing;
                    }
                    textY = textStartY;
                }
                if (outLineThickness > 0)
                {
                    gr.SmoothingMode = SmoothingMode.None;
                    gr.InterpolationMode = InterpolationMode.Low;
                    gr.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                    Brush br = new SolidBrush(formatting.MainText.Outline.Color);

                    foreach (string s in MainText)
                    {
                        for (int x = textX - outLineThickness * 2; x <= textX + outLineThickness * 2; x += 2)
                        {
                            for (int y = textY - outLineThickness * 2; y <= textY + outLineThickness * 2; y += 2)
                            {
                                gr.DrawString(s, formatting.MainText.Font, br, new Point(x, y), strFormat);
                            }
                        }
                        textY += lineHeight + formatting.MainText.LineSpacing;
                    }
                    textY = textStartY;
                }

                foreach (string s in MainText)
                {
                    gr.DrawString(s, formatting.MainText.Font, new SolidBrush(formatting.MainText.Color), new Point(textX, textY), strFormat);
                    textY += lineHeight + formatting.MainText.LineSpacing;
                }

                if (SubText != null && SubText.Count > 0)
                {
                    int transStartX = textStartX + 10;
                    int transStartY = textStartY + lineHeight;
                    textX = transStartX;
                    textY = transStartY;

                    if (shadowThickness > 0)
                    {
                        shadodBrush = new SolidBrush(Color.FromArgb(15, formatting.TranslationText.Shadow.Color));
                        gr.SmoothingMode = SmoothingMode.HighQuality;
                        gr.InterpolationMode = InterpolationMode.HighQualityBilinear;
                        gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                        foreach (string s in SubText)
                        {
                            for (int x = textX; x <= textX + shadowThickness; x++)
                            {
                                for (int y = textY; y <= textY + shadowThickness; y++)
                                {
                                    gr.DrawString(s, formatting.TranslationText.Font, shadodBrush, new Point(x, y), strFormat);
                                }
                            }
                            textY += lineHeight + formatting.TranslationText.LineSpacing;
                        }
                        textY = transStartY;
                    }
                    if (outLineThickness > 0)
                    {
                        gr.SmoothingMode = SmoothingMode.None;
                        gr.InterpolationMode = InterpolationMode.Low;
                        gr.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                        Brush br = new SolidBrush(formatting.TranslationText.Outline.Color);

                        foreach (string s in SubText)
                        {
                            for (int x = textX - outLineThickness * 2; x <= textX + outLineThickness * 2; x += 2)
                            {
                                for (int y = textY - outLineThickness * 2; y <= textY + outLineThickness * 2; y += 2)
                                {
                                    gr.DrawString(s, formatting.TranslationText.Font, br, new Point(x, y), strFormat);
                                }
                            }
                            textY += lineHeight + formatting.TranslationText.LineSpacing;
                        }
                        textY = transStartY;
                    }

                    foreach (string s in SubText)
                    {
                        gr.DrawString(s, formatting.TranslationText.Font, new SolidBrush(formatting.TranslationText.Color), new Point(textX, textY), strFormat);
                        textY += lineHeight + formatting.TranslationText.LineSpacing;
                    }
                }
            }

            //
            // Header text (source)
            //
            if (HeaderText != null && HeaderText != String.Empty)
            {
                int headerPosX = w - formatting.TextBorders.SourceRight;
                int headerPoxY = formatting.TextBorders.SourceTop;
                StringFormat headerStrFormat = new StringFormat();
                headerStrFormat.Alignment = StringAlignment.Far;
                gr.DrawString(HeaderText, formatting.SourceText.Font, new SolidBrush(formatting.SourceText.Color), new Point(headerPosX, headerPoxY), headerStrFormat);
            }

            //
            // Footer text (copyright)
            //
            if (FooterText != null && FooterText != String.Empty)
            {
                SizeF footerMeasure = gr.MeasureString(FooterText, formatting.CopyrightText.Font);
                int footerPosX = w / 2;
                int footerPosY = h - formatting.TextBorders.CopyrightBottom - (int)footerMeasure.Height;
                StringFormat footerStrFormat = new StringFormat();
                footerStrFormat.Alignment = StringAlignment.Center;
                gr.DrawString(FooterText, formatting.CopyrightText.Font, new SolidBrush(formatting.CopyrightText.Color), new Point(footerPosX, footerPosY), footerStrFormat);
            }
        }

        private static String ListToString(List<String> lines) {
            string txt = "";
            int i = 1;
            foreach (string str in lines)
            {
                txt += str;
                if (i < lines.Count)
                    txt += Environment.NewLine;
                i++;
            }
            return txt;
        }
    }
}