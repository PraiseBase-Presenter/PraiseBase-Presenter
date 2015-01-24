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
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Model;
using System.Collections.Generic;

namespace PraiseBase.Presenter
{
    internal class SongSlideLayer : TextLayer
    {
        private SongSlide slide;

        public bool SwitchTextAndTranslation { get; set; }

        public SongSlideLayer(SongSlide slide)
        {
            this.slide = slide;
        }

        public override void writeOut(System.Drawing.Graphics gr, object[] args, ProjectionMode pr)
        {
            int w = (int)gr.VisibleClipBounds.Width;
            int h = (int)gr.VisibleClipBounds.Height;

            List<String> mainText;
            List<String> subText;
            if (slide.Translated && SwitchTextAndTranslation)
            {
                mainText = slide.Translation;
                subText = slide.Lines;
            }
            else
            {
                mainText = slide.Lines;
                subText = slide.Translation;
            }

            if (mainText.Count > 0)
            {
                StringFormat strFormat = new StringFormat();

                Font font;
                Font fontTr;
                int lineSpacing;
                Brush fontBrush;
                Brush fontTranslationBrush;

                if (Settings.Default.ProjectionUseMaster && pr != ProjectionMode.Simulate)
                {
                    font = Settings.Default.ProjectionMasterFont;
                    fontTr = Settings.Default.ProjectionMasterFontTranslation;
                    lineSpacing = Settings.Default.ProjectionMasterLineSpacing;
                    fontBrush = new SolidBrush(Settings.Default.ProjectionMasterFontColor);
                    fontTranslationBrush = new SolidBrush(Settings.Default.ProjectionMasterTranslationColor);
                }
                else
                {
                    font = slide.MainTextFormatting.Font;
                    fontTr = slide.TranslationTextFormatting.Font;
                    lineSpacing = slide.MainTextFormatting.LineSpacing;
                    fontBrush = new SolidBrush(slide.MainTextFormatting.Color);
                    fontTranslationBrush = new SolidBrush(slide.TranslationTextFormatting.Color);
                }

                int padding = Settings.Default.ProjectionPadding;
                int shadowThickness = Settings.Default.ProjectionShadowSize;
                int outLineThickness = Settings.Default.ProjectionOutlineSize;
                String str = String.Empty;

                int usableWidth = w - (2 * padding);
                int usableHeight = h - (2 * padding);

                int textStartX = padding;
                int textStartY = padding;

                SizeF strMeasureTrans;

                int endSpacing = 0;
                if (slide.Translated)
                {
                    strMeasureTrans = gr.MeasureString(slide.TranslationText, fontTr);
                    lineSpacing += (int)(strMeasureTrans.Height / subText.Count) + lineSpacing;
                    endSpacing = (int)(strMeasureTrans.Height / subText.Count) + lineSpacing;
                }

                SizeF strMeasure = gr.MeasureString(slide.Text, font);
                Brush shadodBrush = Brushes.Transparent;
                int usedWidth = (int)strMeasure.Width;
                int usedHeight = (int)strMeasure.Height + (lineSpacing * (mainText.Count - 1)) + endSpacing;

                float scalingFactor = 1.0f;
                if (Settings.Default.ProjectionFontScaling && (usedWidth > usableWidth || usedHeight > usableHeight))
                {
                    scalingFactor = Math.Min((float)usableWidth / (float)usedWidth, (float)usableHeight / (float)usedHeight);
                    font = new Font(font.FontFamily, font.Size * scalingFactor, font.Style);
                    strMeasure = gr.MeasureString(slide.Text, font);
                    usedWidth = (int)strMeasure.Width;
                    usedHeight = (int)strMeasure.Height + (lineSpacing * (mainText.Count - 1));
                }
                int lineHeight = (int)(strMeasure.Height / mainText.Count);

                // Horizontal stuff
                switch (slide.TextOrientation.Horizontal)
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
                switch (slide.TextOrientation.Vertical)
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

                // TODO
                /*
                if (pr != ProjectionMode.Simulate && shadowThickness > 0)
                {
                    shadodBrush = new SolidBrush(Color.FromArgb(15, Settings.Default.ProjectionShadowColor));
                    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    foreach (string s in mainText)
                    {
                        for (int x = textX; x <= textX + shadowThickness; x++)
                        {
                            for (int y = textY; y <= textY + shadowThickness; y++)
                            {
                                gr.DrawString(s, font, shadodBrush, new Point(x, y), strFormat);
                            }
                        }
                        textY += lineHeight + lineSpacing;
                    }
                    textY = textStartY;
                }*/
                if (pr != ProjectionMode.Simulate && outLineThickness > 0)
                {
                    gr.SmoothingMode = SmoothingMode.None;
                    gr.InterpolationMode = InterpolationMode.Low;
                    gr.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                    Brush br = new SolidBrush(Settings.Default.ProjectionOutlineColor);

                    foreach (string s in mainText)
                    {
                        for (int x = textX - outLineThickness * 2; x <= textX + outLineThickness * 2; x += 2)
                        {
                            for (int y = textY - outLineThickness * 2; y <= textY + outLineThickness * 2; y += 2)
                            {
                                gr.DrawString(s, font, br, new Point(x, y), strFormat);
                            }
                        }
                        textY += lineHeight + lineSpacing;
                    }
                    textY = textStartY;
                }

                foreach (string s in mainText)
                {
                    gr.DrawString(s, font, fontBrush, new Point(textX, textY), strFormat);
                    textY += lineHeight + lineSpacing;
                }

                if (slide.Translated)
                {
                    int transStartX = textStartX + 10;
                    int transStartY = textStartY + lineHeight;
                    textX = transStartX;
                    textY = transStartY;

                    /*
                    if (pr != ProjectionMode.Simulate && shadowThickness > 0)
                    {
                        shadodBrush = new SolidBrush(Color.FromArgb(15, Settings.Default.ProjectionShadowColor));
                        gr.SmoothingMode = SmoothingMode.HighQuality;
                        gr.InterpolationMode = InterpolationMode.HighQualityBilinear;
                        gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                        foreach (string s in subText)
                        {
                            for (int x = textX; x <= textX + shadowThickness; x++)
                            {
                                for (int y = textY; y <= textY + shadowThickness; y++)
                                {
                                    gr.DrawString(s, fontTr, shadodBrush, new Point(x, y), strFormat);
                                }
                            }
                            textY += lineHeight + lineSpacing;
                        }
                        textY = transStartY;
                    }*/
                    if (pr != ProjectionMode.Simulate && outLineThickness > 0)
                    {
                        gr.SmoothingMode = SmoothingMode.None;
                        gr.InterpolationMode = InterpolationMode.Low;
                        gr.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                        Brush br = new SolidBrush(Settings.Default.ProjectionOutlineColor);

                        foreach (string s in subText)
                        {
                            for (int x = textX - outLineThickness * 2; x <= textX + outLineThickness * 2; x += 2)
                            {
                                for (int y = textY - outLineThickness * 2; y <= textY + outLineThickness * 2; y += 2)
                                {
                                    gr.DrawString(s, fontTr, br, new Point(x, y), strFormat);
                                }
                            }
                            textY += lineHeight + lineSpacing;
                        }
                        textY = transStartY;
                    }

                    foreach (string s in subText)
                    {
                        gr.DrawString(s, fontTr, fontTranslationBrush, new Point(textX, textY), strFormat);
                        textY += lineHeight + lineSpacing;
                    }
                }
            }
        }
    }
}