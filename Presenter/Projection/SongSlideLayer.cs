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

        /// <summary>
        /// Main text
        /// </summary>
        public String[] MainText { get; set; }

        /// <summary>
        /// Sub text (below main text)
        /// </summary>
        public String[] SubText { get; set; }

        /// <summary>
        /// Header text
        /// </summary>
        public String[] HeaderText { get; set; }

        /// <summary>
        /// Footer text
        /// </summary>
        public String[] FooterText { get; set; }

        public SongSlideLayer(SlideTextFormatting formatting)
        {
            this.formatting = formatting;
        }

        public override void writeOut(System.Drawing.Graphics gr, object[] args)
        {
            int canvasWidth = (int)gr.VisibleClipBounds.Width;
            int canvasHeight = (int)gr.VisibleClipBounds.Height;

            //
            // Main text
            //
            if (MainText.Length > 0)
            {
                int usableWidth = canvasWidth - (2 * formatting.Text.HorizontalPadding);
                int usableHeight = canvasHeight - (2 * formatting.Text.VerticalPadding);

                SizeF strMeasureMain;
                SizeF strMeasureSub;

                int endSpacing = 0;
                if (SubText != null && SubText.Length > 0)
                {
                    strMeasureSub = gr.MeasureString(String.Join(Environment.NewLine, SubText), formatting.Text.SubText.Font);
                    
                    formatting.Text.MainText.LineSpacing += (int)(strMeasureSub.Height / SubText.Length) + formatting.Text.SubText.LineSpacing;
                    endSpacing = (int)(strMeasureSub.Height / SubText.Length) + formatting.Text.SubText.LineSpacing;
                }

                strMeasureMain = gr.MeasureString(String.Join(Environment.NewLine, MainText), formatting.Text.MainText.Font);

                int usedWidth = (int)strMeasureMain.Width;
                int usedHeight = (int)strMeasureMain.Height + (formatting.Text.MainText.LineSpacing * (MainText.Length - 1)) + endSpacing;

                float scalingFactor = 1.0f;
                if (formatting.ScaleFontSize && (usedWidth > usableWidth || usedHeight > usableHeight))
                {
                    scalingFactor = Math.Min((float)usableWidth / (float)usedWidth, (float)usableHeight / (float)usedHeight);
                    formatting.Text.MainText.Font = new Font(formatting.Text.MainText.Font.FontFamily, formatting.Text.MainText.Font.Size * scalingFactor, formatting.Text.MainText.Font.Style);
                    strMeasureMain = gr.MeasureString(String.Join(Environment.NewLine, MainText), formatting.Text.MainText.Font);
                    usedWidth = (int)strMeasureMain.Width;
                    usedHeight = (int)strMeasureMain.Height + (formatting.Text.MainText.LineSpacing * (MainText.Length - 1));
                }

                int lineHeight = (int)(strMeasureMain.Height / MainText.Length);

                // Set horizontal starting position
                int textStartX = formatting.Text.HorizontalPadding;
                if (formatting.Text.Orientation.Horizontal == HorizontalOrientation.Center)
                {
                    textStartX = canvasWidth / 2;
                }
                else if (formatting.Text.Orientation.Horizontal == HorizontalOrientation.Right)
                {
                    textStartX = textStartX + usableWidth;
                }

                // Set vertical starting position
                int textStartY = formatting.Text.VerticalPadding;
                if (formatting.Text.Orientation.Vertical == VerticalOrientation.Middle)
                {
                    textStartY = textStartY + (usableHeight / 2) - (usedHeight / 2);
                }
                else if (formatting.Text.Orientation.Vertical == VerticalOrientation.Bottom)
                {
                    textStartY = textStartY + usableHeight - usedHeight;
                }

                // Sub text starting position
                int subTextStartX = textStartX;
                if (formatting.Text.Orientation.Horizontal == HorizontalOrientation.Left)
                {
                    subTextStartX += formatting.Text.HorizontalSubTextOffset;
                }
                else if (formatting.Text.Orientation.Horizontal == HorizontalOrientation.Right)
                {
                    subTextStartX -= formatting.Text.HorizontalSubTextOffset;
                }
                int subTextStartY = textStartY + lineHeight;

                // Draw main text
                DrawLines(gr, MainText, textStartX, textStartY, formatting.Text.MainText, formatting.Text.Orientation.Horizontal, lineHeight + formatting.Text.MainText.LineSpacing);

                // Sub-text (translation)
                if (SubText != null && SubText.Length > 0)
                {
                    DrawLines(gr, SubText, subTextStartX, subTextStartY, formatting.Text.SubText, formatting.Text.Orientation.Horizontal, lineHeight + formatting.Text.MainText.LineSpacing);
                }
            }

            //
            // Header text (source)
            //
            if (HeaderText != null && HeaderText.Length > 0)
            {
                // Get X
                int x = GetXPosition(formatting.Header, canvasWidth);

                // Get Y
                int y = formatting.Header.VerticalPadding;

                // Draw
                DrawTextBox(gr, HeaderText, x, y, formatting.Header, false);
            }

            //
            // Footer text (copyright)
            //
            if (FooterText != null && FooterText.Length > 0)
            {
                // Get X
                int x = GetXPosition(formatting.Footer, canvasWidth);

                // Get Y
                int y = canvasHeight - formatting.Footer.VerticalPadding;

                // Draw
                DrawTextBox(gr, FooterText, x, y, formatting.Footer, true);
            }
        }

        /// <summary>
        /// Draws a text box at the given coordinates
        /// </summary>
        /// <param name="gr">Graphics area to draw on</param>
        /// <param name="text">Text (array element per line)</param>
        /// <param name="x">Horizontal starting position</param>
        /// <param name="y">Vertical starting position</param>
        /// <param name="formatting">Formatting</param>
        /// <param name="upwards">Calculate upwards from vertical starting position</param>
        private void DrawTextBox(Graphics gr, String[] text, int x, int y, SlideTextFormatting.TextBoxFormatting formatting, bool upwards)
        {
            // Measure text height
            SizeF sizeMeasure = gr.MeasureString(String.Join(Environment.NewLine, text), formatting.Text.Font);

            // Calculate y starting position if measuring upwards
            if (upwards)
            {
                y -= (int)sizeMeasure.Height + ((text.Length -1) * formatting.Text.LineSpacing);
            }

            // Line height
            int lineHeight = (int)(sizeMeasure.Height / text.Length);

            // Draw lines
            DrawLines(gr, text, x, y, formatting.Text, formatting.HorizontalOrientation, lineHeight + formatting.Text.LineSpacing);
        }

        /// <summary>
        /// Get X position on canvas based on canvas width, padding and horizontal orientation
        /// </summary>
        /// <param name="formatting"></param>
        /// <param name="canvasWidth"></param>
        /// <returns></returns>
        private static int GetXPosition(SlideTextFormatting.TextBoxFormatting formatting, int canvasWidth)
        {
            int x = formatting.HorizontalPadding;
            if (formatting.HorizontalOrientation == HorizontalOrientation.Center)
            {
                x = canvasWidth / 2;
            }
            else if (formatting.HorizontalOrientation == HorizontalOrientation.Right)
            {
                x = canvasWidth - formatting.HorizontalPadding;
            }
            return x;
        }

        /// <summary>
        /// Maps horizontal text orientation to string format alignment
        /// </summary>
        /// <param name="to"></param>
        /// <param name="strFormat"></param>
        private static void MapStringFormatAlignment(HorizontalOrientation to, StringFormat strFormat) 
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

        /// <summary>
        /// Draws lines onto the graphics area
        /// </summary>
        /// <param name="gr">Graphics area</param>
        /// <param name="lines">Lines</param>
        /// <param name="textStartX">Horizontal starting position</param>
        /// <param name="textStartY">Vertical starting position</param>
        /// <param name="textFormatting">Formatting</param>
        /// <param name="orientation">Horizontal orientation</param>
        /// <param name="lineHeight">Line height (text + spacing)</param>
        private void DrawLines(Graphics gr, String[] lines, int textStartX, int textStartY,
            TextFormatting textFormatting, HorizontalOrientation orientation, int lineHeight)
        {
            int textX = textStartX;
            int textY = textStartY;

            // Set string format
            StringFormat strFormat = new StringFormat();
            MapStringFormatAlignment(orientation, strFormat);

            // Shadow
            if (formatting.ShadowEnabled)
            {
                int size = textFormatting.Shadow.Size;
                int distance = textFormatting.Shadow.Distance;

                int shadowX = textX - (int)(distance * Math.Cos(Math.PI * (90 + textFormatting.Shadow.Direction) / 180));
                int shadowY = textY - (int)(distance * Math.Sin(Math.PI * (90 + textFormatting.Shadow.Direction) / 180));

                Brush shadodBrush = new SolidBrush(Color.FromArgb(15, textFormatting.Shadow.Color));
                if (formatting.SmoothShadow)
                {
                    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                }

                foreach (string s in lines)
                {
                    for (int x = shadowX - size; x <= shadowX + size; x++)
                    {
                        for (int y = shadowY - size; y <= shadowY + size; y++)
                        {
                            gr.DrawString(s, textFormatting.Font, shadodBrush, new Point(x, y), strFormat);
                        }
                    }
                    shadowY += lineHeight;
                }
            }

            // Outline
            if (formatting.OutlineEnabled)
            {
                int outLineThickness = textFormatting.Outline.Width;
                if (outLineThickness > 0)
                {
                    int outlineX = textX;
                    int outlineY = textY;

                    gr.SmoothingMode = SmoothingMode.None;
                    gr.InterpolationMode = InterpolationMode.Low;
                    gr.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                    Brush br = new SolidBrush(textFormatting.Outline.Color);

                    foreach (string s in lines)
                    {
                        for (int x = outlineX - outLineThickness * 2; x <= outlineX + outLineThickness * 2; x += 2)
                        {
                            for (int y = outlineY - outLineThickness * 2; y <= outlineY + outLineThickness * 2; y += 2)
                            {
                                gr.DrawString(s, textFormatting.Font, br, new Point(x, y), strFormat);
                            }
                        }
                        outlineY += lineHeight;
                    }
                }
            }

            // Text
            foreach (string s in lines)
            {
                gr.DrawString(s, textFormatting.Font, new SolidBrush(textFormatting.Color), new Point(textX, textY), strFormat);
                textY += lineHeight;
            }
        }
    }
}