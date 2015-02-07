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
using PraiseBase.Presenter.Projection;

namespace PraiseBase.Presenter
{
    internal class SongSlideLayer : TextLayer
    {
        private SongSlide slide;
        private SongSlideLayerFormatting formatting;

        public bool SwitchTextAndTranslation { get; set; }
        public String HeaderText { get; set; }
        public String FooterText { get; set; }

        public SongSlideLayer(SongSlide slide, SongSlideLayerFormatting formatting)
        {
            this.slide = slide;
            this.formatting = formatting;
            // TODO respect slide text size
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
                    strMeasureTrans = gr.MeasureString(slide.TranslationText, formatting.TranslationFont);
                    formatting.LineSpacing += (int)(strMeasureTrans.Height / subText.Count) + formatting.LineSpacing;
                    endSpacing = (int)(strMeasureTrans.Height / subText.Count) + formatting.LineSpacing;
                }

                SizeF strMeasure = gr.MeasureString(slide.Text, formatting.TextFont);
                Brush shadodBrush = Brushes.Transparent;
                int usedWidth = (int)strMeasure.Width;
                int usedHeight = (int)strMeasure.Height + (formatting.LineSpacing * (mainText.Count - 1)) + endSpacing;

                float scalingFactor = 1.0f;
                if (Settings.Default.ProjectionFontScaling && (usedWidth > usableWidth || usedHeight > usableHeight))
                {
                    scalingFactor = Math.Min((float)usableWidth / (float)usedWidth, (float)usableHeight / (float)usedHeight);
                    formatting.TextFont = new Font(formatting.TextFont.FontFamily, formatting.TextFont.Size * scalingFactor, formatting.TextFont.Style);
                    strMeasure = gr.MeasureString(slide.Text, formatting.TextFont);
                    usedWidth = (int)strMeasure.Width;
                    usedHeight = (int)strMeasure.Height + (formatting.LineSpacing * (mainText.Count - 1));
                }
                int lineHeight = (int)(strMeasure.Height / mainText.Count);

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
                                gr.DrawString(s, formatting.TextFont, br, new Point(x, y), strFormat);
                            }
                        }
                        textY += lineHeight + formatting.LineSpacing;
                    }
                    textY = textStartY;
                }

                foreach (string s in mainText)
                {
                    gr.DrawString(s, formatting.TextFont, formatting.TextBrush, new Point(textX, textY), strFormat);
                    textY += lineHeight + formatting.LineSpacing;
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
                                    gr.DrawString(s, formatting.TranslationFont, br, new Point(x, y), strFormat);
                                }
                            }
                            textY += lineHeight + formatting.LineSpacing;
                        }
                        textY = transStartY;
                    }

                    foreach (string s in subText)
                    {
                        gr.DrawString(s, formatting.TranslationFont, formatting.TranslationBrush, new Point(textX, textY), strFormat);
                        textY += lineHeight + formatting.LineSpacing;
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
                gr.DrawString(HeaderText, formatting.TextFont, formatting.TextBrush, new Point(headerPosX, headerPoxY), headerStrFormat);
            }

            //
            // Footer text (copyright)
            //
            if (FooterText != null && FooterText != String.Empty)
            {
                SizeF footerMeasure = gr.MeasureString(FooterText, formatting.TextFont);
                int footerPosX = w / 2;
                int footerPosY = h - formatting.TextBorders.CopyrightBottom - (int)footerMeasure.Height;
                StringFormat footerStrFormat = new StringFormat();
                footerStrFormat.Alignment = StringAlignment.Center;
                gr.DrawString(FooterText, formatting.TextFont, formatting.TextBrush, new Point(footerPosX, footerPosY), footerStrFormat);
            }
        }
    }
}