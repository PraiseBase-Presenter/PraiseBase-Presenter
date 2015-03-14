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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Util;

namespace PraiseBase.Presenter.Projection
{
    public class TextLayer : BaseLayer
    {
        private SlideTextFormatting _formatting;

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

        /// <summary>
        /// If set to true, will draw text box borders for debugging purposes
        /// </summary>
        public bool DrawBordersForDebugging { get; set; }

        public TextLayer(SlideTextFormatting formatting)
        {
            _formatting = formatting;
        }

        public override void WriteOut(Graphics gr, object[] args)
        {
            float canvasWidth = gr.VisibleClipBounds.Width;
            float canvasHeight = gr.VisibleClipBounds.Height;

            //
            // Main text
            //
            if (MainText.Length > 0)
            {
                TextFormatting mainTextFormat = (TextFormatting)_formatting.Text.MainText.Clone();
                TextFormatting subTextFormat = (TextFormatting)_formatting.Text.SubText.Clone();

                // Width and height of text box
                float usableWidth = canvasWidth - (_formatting.Text.HorizontalPadding + _formatting.Text.HorizontalPadding);
                float usableHeight = canvasHeight - (_formatting.Text.VerticalPadding + _formatting.Text.VerticalPadding);

                // Draw borders of usable area
                if (DrawBordersForDebugging)
                {
                    gr.DrawRectangle(Pens.Red, new Rectangle(_formatting.Text.HorizontalPadding, _formatting.Text.VerticalPadding, (int)usableWidth, (int)usableHeight));
                }

                // Line spacing
                int mainTextLineSpacing = mainTextFormat.LineSpacing;
                int subTextLineSpacing = subTextFormat.LineSpacing;

                // Wrap long lines
                if (_formatting.LineWrap)
                {
                    List<String> wrappedLines = new List<string>();
                    foreach (String l in MainText)
                    {
                        SizeF lm = gr.MeasureString(l, mainTextFormat.Font);
                        if (lm.Width > usableWidth)
                        {
                            int nc = l.Length / ((int)Math.Ceiling(lm.Width / usableWidth));
                            wrappedLines.AddRange(StringUtils.Wrap(l, nc));
                        }
                        else
                        {
                            wrappedLines.Add(l);
                        }
                    }
                    MainText = wrappedLines.ToArray();
                }

                // Numer of lines (always use greater value)
                int numberOfLines = MainText.Length;
                int numberOfSubTextLines = SubText != null ? SubText.Length : 0;
                numberOfLines = Math.Max(numberOfLines, numberOfSubTextLines);

                // True if sub text is set
                bool hasSubText = (SubText != null && numberOfSubTextLines > 0);

                // Measure main text
                SizeF strMeasureMain = gr.MeasureString(String.Join(Environment.NewLine, MainText), mainTextFormat.Font);
                float mainTextBlockWidth = strMeasureMain.Width;
                float mainTextBlockHeight = strMeasureMain.Height;
                float mainTextLineHeight = mainTextBlockHeight / numberOfLines;

                // Measure sub text
                float subTextBlockWidth = 0f;
                float subTextBlockHeight = 0f;
                float subTextLineHeight = 0f;
                if (hasSubText)
                {
                    SizeF strMeasureSub = gr.MeasureString(String.Join(Environment.NewLine, SubText), subTextFormat.Font);
                    subTextBlockWidth = strMeasureSub.Width;
                    subTextBlockHeight = strMeasureSub.Height;
                    subTextLineHeight = subTextBlockHeight / numberOfLines;
                }

                // Calculate used width
                float usedWidth = Math.Max(mainTextBlockWidth, subTextBlockWidth);

                // Calculate used height (text block + spacing beween lines)
                float usedHeight = mainTextBlockHeight + ((numberOfLines - 1) * mainTextLineSpacing);
                if (hasSubText)
                {
                    // Add one sub text line height with spacing)
                    usedHeight += subTextBlockHeight + (numberOfLines  * subTextLineSpacing);
                }

                // Scale text
                if (_formatting.ScaleFontSize && (usedWidth > usableWidth || usedHeight > usableHeight))
                {
                    // Calculate scaling factor
                    var scalingFactor = Math.Min(usableWidth / usedWidth, usableHeight / usedHeight);
                    
                    // Adapt main text format
                    mainTextFormat.Font = new Font(mainTextFormat.Font.FontFamily, mainTextFormat.Font.Size * scalingFactor, mainTextFormat.Font.Style);
                    mainTextFormat.LineSpacing = (int)(mainTextFormat.LineSpacing * scalingFactor);
                    mainTextLineSpacing = mainTextFormat.LineSpacing;
                    
                    // Adapt sub text format
                    subTextFormat.Font = new Font(subTextFormat.Font.FontFamily, subTextFormat.Font.Size * scalingFactor, subTextFormat.Font.Style);
                    subTextFormat.LineSpacing = (int)(subTextFormat.LineSpacing * scalingFactor);
                    subTextLineSpacing = subTextFormat.LineSpacing;

                    // Adapt used width and height
                    usedWidth *= scalingFactor;
                    usedHeight *= scalingFactor;

                    // Adapt line height
                    mainTextLineHeight *= scalingFactor;
                    subTextLineHeight *= scalingFactor;
                }

                // Set horizontal starting position
                float textStartX = _formatting.Text.HorizontalPadding;
                if (_formatting.Text.Orientation.Horizontal == HorizontalOrientation.Center)
                {
                    textStartX = canvasWidth / 2;
                }
                else if (_formatting.Text.Orientation.Horizontal == HorizontalOrientation.Right)
                {
                    textStartX = textStartX + usableWidth;
                }

                // Set vertical starting position
                float textStartY = _formatting.Text.VerticalPadding;
                if (_formatting.Text.Orientation.Vertical == VerticalOrientation.Middle)
                {
                    textStartY = textStartY + (usableHeight / 2) - (usedHeight / 2);
                }
                else if (_formatting.Text.Orientation.Vertical == VerticalOrientation.Bottom)
                {
                    textStartY = textStartY + usableHeight - usedHeight;
                }

                // Sub text starting position
                float subTextStartX = textStartX;
                if (_formatting.Text.Orientation.Horizontal == HorizontalOrientation.Left)
                {
                    subTextStartX += _formatting.Text.HorizontalSubTextOffset;
                }
                else if (_formatting.Text.Orientation.Horizontal == HorizontalOrientation.Right)
                {
                    subTextStartX -= _formatting.Text.HorizontalSubTextOffset;
                }
                float subTextStartY = textStartY + (mainTextLineHeight + subTextLineSpacing);

                // Total line heights
                float lineHeight = mainTextLineHeight + mainTextLineSpacing;
                if (hasSubText)
                {
                    lineHeight += subTextLineSpacing + subTextLineHeight;
                }

                // Draw borders of used area
                if (DrawBordersForDebugging)
                {
                    gr.DrawRectangle(Pens.Pink, new Rectangle((int)textStartX, (int)textStartY, (int)usedWidth, (int)usedHeight));
                }

                // Draw main text
                DrawLines(gr, MainText, textStartX, textStartY, mainTextFormat, _formatting.Text.Orientation.Horizontal, lineHeight);

                // Sub-text (translation)
                if (hasSubText)
                {
                    DrawLines(gr, SubText, subTextStartX, subTextStartY, subTextFormat, _formatting.Text.Orientation.Horizontal, lineHeight);
                }
            }

            //
            // Header text (source)
            //
            if (HeaderText != null && HeaderText.Length > 0)
            {
                // Get X
                float x = GetXPosition(_formatting.Header, canvasWidth);

                // Get Y
                float y = _formatting.Header.VerticalPadding;

                // Draw
                DrawTextBox(gr, HeaderText, x, y, _formatting.Header, false);
            }

            //
            // Footer text (copyright)
            //
            if (FooterText != null && FooterText.Length > 0)
            {
                // Get X
                float x = GetXPosition(_formatting.Footer, canvasWidth);

                // Get Y
                float y = canvasHeight - _formatting.Footer.VerticalPadding;

                // Draw
                DrawTextBox(gr, FooterText, x, y, _formatting.Footer, true);
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
        private void DrawTextBox(Graphics gr, String[] text, float x, float y, SlideTextFormatting.TextBoxFormatting formatting, bool upwards)
        {
            int numberOfLines = text.Length;
            int lineSpacing = formatting.Text.LineSpacing;

            // Measure text height
            float textBlockHeight = gr.MeasureString(String.Join(Environment.NewLine, text), formatting.Text.Font).Height;

            // Calculate y starting position if measuring upwards
            if (upwards)
            {
                int lineSpacingHeight = ((numberOfLines - 1) * lineSpacing);
                y -= textBlockHeight + lineSpacingHeight;
            }

            // Text height
            float textLineHeight = (textBlockHeight / numberOfLines);
            float lineHeight = textLineHeight + lineSpacing;

            // Draw lines
            DrawLines(gr, text, x, y, formatting.Text, formatting.HorizontalOrientation, lineHeight);
        }

        /// <summary>
        /// Get X position on canvas based on canvas width, padding and horizontal orientation
        /// </summary>
        /// <param name="formatting"></param>
        /// <param name="canvasWidth"></param>
        /// <returns></returns>
        private static float GetXPosition(SlideTextFormatting.TextBoxFormatting formatting, float canvasWidth)
        {
            float x = formatting.HorizontalPadding;
            if (formatting.HorizontalOrientation == HorizontalOrientation.Center)
            {
                x = canvasWidth / 2f;
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
        private void DrawLines(Graphics gr, String[] lines, float textStartX, float textStartY,
            TextFormatting textFormatting, HorizontalOrientation orientation, float lineHeight)
        {
            float textX = textStartX;
            float textY = textStartY;

            // Set string format
            StringFormat strFormat = new StringFormat();
            MapStringFormatAlignment(orientation, strFormat);

            // Shadow
            if (_formatting.ShadowEnabled)
            {
                int size = textFormatting.Shadow.Size;
                int distance = textFormatting.Shadow.Distance;

                float shadowX = textX - (distance * (float)Math.Cos(Math.PI * (90 + textFormatting.Shadow.Direction) / 180));
                float shadowY = textY - (distance * (float)Math.Sin(Math.PI * (90 + textFormatting.Shadow.Direction) / 180));

                Brush shadodBrush = new SolidBrush(Color.FromArgb(15, textFormatting.Shadow.Color));
                if (_formatting.SmoothShadow)
                {
                    gr.SmoothingMode = SmoothingMode.HighQuality;
                    gr.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                }

                foreach (string s in lines)
                {
                    for (float x = shadowX - size; x <= shadowX + size; x++)
                    {
                        for (float y = shadowY - size; y <= shadowY + size; y++)
                        {
                            gr.DrawString(s, textFormatting.Font, shadodBrush, x, y, strFormat);
                        }
                    }
                    shadowY += lineHeight;
                }
            }

            // Outline
            if (_formatting.OutlineEnabled)
            {
                int outLineThickness = textFormatting.Outline.Width;
                if (outLineThickness > 0)
                {
                    float outlineX = textX;
                    float outlineY = textY;

                    gr.SmoothingMode = SmoothingMode.None;
                    gr.InterpolationMode = InterpolationMode.Low;
                    gr.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                    Brush br = new SolidBrush(textFormatting.Outline.Color);

                    foreach (string s in lines)
                    {
                        for (float x = outlineX - outLineThickness * 2; x <= outlineX + outLineThickness * 2; x += 2)
                        {
                            for (float y = outlineY - outLineThickness * 2; y <= outlineY + outLineThickness * 2; y += 2)
                            {
                                gr.DrawString(s, textFormatting.Font, br, x, y, strFormat);
                            }
                        }
                        outlineY += lineHeight;
                    }
                }
            }

            // Text
            foreach (string s in lines)
            {
                gr.DrawString(s, textFormatting.Font, new SolidBrush(textFormatting.Color), textX, textY, strFormat);
                textY += lineHeight;
            }
        }
    }
}