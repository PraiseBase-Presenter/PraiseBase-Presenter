using System;
using System.Drawing;
using Pbp.Properties;

namespace Pbp
{
    public class BibleLayer : TextLayer
    {
        public float FontSize { get; set; }

        public StringAlignment HorizontalAlign { get; set; }

        public StringAlignment VerticalAlign { get; set; }

        private XMLBible.VerseSelection verseSelection;

        public BibleLayer(XMLBible.VerseSelection verseSelection)
        {
            this.verseSelection = verseSelection;
        }

        public override void writeOut(System.Drawing.Graphics gr, object[] args, ProjectionMode pr)
        {
            XMLBible.VerseSelection v = verseSelection;

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
                    string s = string.Join(Environment.NewLine, Util.Wrap(l, nc)).Trim();

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