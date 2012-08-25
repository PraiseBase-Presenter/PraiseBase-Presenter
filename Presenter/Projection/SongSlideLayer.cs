using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Pbp.Properties;

namespace Pbp
{
    internal class SongSlideLayer : TextLayer
    {
        private SongSlide slide;

        public SongSlideLayer(SongSlide slide)
        {
            this.slide = slide;
        }

        public override void writeOut(System.Drawing.Graphics gr, object[] args, ProjectionMode pr)
        {
            int w = (int)gr.VisibleClipBounds.Width;
            int h = (int)gr.VisibleClipBounds.Height;

            if (slide.Lines.Count > 0)
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
                    font = slide.TextFont;
                    fontTr = slide.TranslationFont;
                    lineSpacing = slide.TextLineSpacing;
                    fontBrush = new SolidBrush(slide.TextColor);
                    fontTranslationBrush = new SolidBrush(slide.TranslationColor);
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
                    strMeasureTrans = gr.MeasureString(slide.LineBreakTranslation(), fontTr);
                    lineSpacing += (int)(strMeasureTrans.Height / slide.Translation.Count) + lineSpacing;
                    endSpacing = (int)(strMeasureTrans.Height / slide.Translation.Count) + lineSpacing;
                }

                SizeF strMeasure = gr.MeasureString(slide.LineBreakText(), font);
                Brush shadodBrush = Brushes.Transparent;
                int usedWidth = (int)strMeasure.Width;
                int usedHeight = (int)strMeasure.Height + (lineSpacing * (slide.Lines.Count - 1)) + endSpacing;

                float scalingFactor = 1.0f;
                if (Settings.Default.ProjectionFontScaling && (usedWidth > usableWidth || usedHeight > usableHeight))
                {
                    scalingFactor = Math.Min((float)usableWidth / (float)usedWidth, (float)usableHeight / (float)usedHeight);
                    font = new Font(font.FontFamily, font.Size * scalingFactor, font.Style);
                    strMeasure = gr.MeasureString(slide.LineBreakText(), font);
                    usedWidth = (int)strMeasure.Width;
                    usedHeight = (int)strMeasure.Height + (lineSpacing * (slide.Lines.Count - 1));
                }
                int lineHeight = (int)(strMeasure.Height / slide.Lines.Count);

                // Horizontal stuff
                switch (slide.HorizontalAlign)
                {
                    case Song.SongTextHorizontalAlign.Left:
                        strFormat.Alignment = StringAlignment.Near;
                        break;

                    case Song.SongTextHorizontalAlign.Center:
                        textStartX = w / 2;
                        strFormat.Alignment = StringAlignment.Center;
                        break;

                    case Song.SongTextHorizontalAlign.Right:
                        textStartX = textStartX + usableWidth;
                        strFormat.Alignment = StringAlignment.Far;
                        break;
                }

                // Vertical stuff
                switch (slide.VerticalAlign)
                {
                    case Song.SongTextVerticalAlign.Top:
                        break;

                    case Song.SongTextVerticalAlign.Center:
                        textStartY = textStartY + (usableHeight / 2) - (usedHeight / 2);
                        break;

                    case Song.SongTextVerticalAlign.Bottom:
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

                    foreach (string s in slide.Lines)
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

                    foreach (string s in slide.Lines)
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

                foreach (string s in slide.Lines)
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

                        foreach (string s in slide.Translation)
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

                        foreach (string s in slide.Translation)
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

                    foreach (string s in slide.Translation)
                    {
                        gr.DrawString(s, fontTr, fontTranslationBrush, new Point(textX, textY), strFormat);
                        textY += lineHeight + lineSpacing;
                    }
                }
            }
        }
    }
}