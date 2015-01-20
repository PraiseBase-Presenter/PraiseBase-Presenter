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
 *   Author:
 *      Nicolas Perrenoud <nicu_at_lavine.ch>
 *   Co-authors:
 *      ...
 *
 */

using System;
using System.Drawing;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Model.Bible;
using PraiseBase.Presenter.Util;

namespace PraiseBase.Presenter
{
    public class BibleLayer : TextLayer
    {
        public float FontSize { get; set; }

        public StringAlignment HorizontalAlign { get; set; }

        public StringAlignment VerticalAlign { get; set; }

        private BibleVerseSelection verseSelection;

        public BibleLayer(PraiseBase.Presenter.Model.Bible.BibleVerseSelection verseSelection)
        {
            this.verseSelection = verseSelection;
        }

        public override void writeOut(System.Drawing.Graphics gr, object[] args, ProjectionMode pr)
        {
            BibleVerseSelection v = verseSelection;

            string Title = v.ToString();
            string Text = v.Text;

            Font font = new Font(Settings.Default.ProjectionMasterFont.FontFamily, FontSize, Settings.Default.ProjectionMasterFont.Style);
            Font titleFont = new Font(Settings.Default.ProjectionMasterFont.FontFamily, FontSize + 10f, Settings.Default.ProjectionMasterFont.Style);
            Brush fontBrush = new SolidBrush(Settings.Default.ProjectionMasterFontColor);
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = HorizontalAlign;

            int w = (int)gr.VisibleClipBounds.Width;
            int h = (int)gr.VisibleClipBounds.Height;
            int padding = 20;

            string[] lines = Text.Split(Environment.NewLine.ToCharArray());

            SizeF coveredArea = gr.MeasureString(Text, font);
            SizeF coveredTitleArea = gr.MeasureString(Title, titleFont);
            int cHeight = (int)coveredArea.Height + (int)coveredTitleArea.Height + 20;

            int x, y;
            if (strFormat.Alignment == StringAlignment.Far)
                x = w - padding;
            else if (strFormat.Alignment == StringAlignment.Center)
                x = w / 2;
            else
                x = padding;

            if (VerticalAlign == StringAlignment.Far)
                y = h - padding - cHeight;
            else if (VerticalAlign == StringAlignment.Center)
                y = (h / 2) - (cHeight / 2);
            else
                y = padding;

            drawString(gr, Title, x, y, titleFont, fontBrush, strFormat);
            y += (int)coveredTitleArea.Height + 20;

            foreach (string l in lines)
            {
                SizeF lm = gr.MeasureString(l, font);

                if (lm.Width > (float)(w - padding))
                {
                    int nc = l.Length / ((int)Math.Ceiling(lm.Width / (float)(w - padding)));
                    string s = string.Join(Environment.NewLine, StringUtils.Wrap(l, nc)).Trim();

                    drawString(gr, s, x, y, font, fontBrush, strFormat);

                    y += (int)gr.MeasureString(s, font).Height + Settings.Default.ProjectionMasterLineSpacing;
                }
                else
                {
                    drawString(gr, l, x, y, font, fontBrush, strFormat);

                    y += (int)lm.Height + Settings.Default.ProjectionMasterLineSpacing;
                }
            }
        }
    }
}