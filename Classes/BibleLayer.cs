using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Pbp.Properties;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Pbp
{
    public class BibleLayer : TextLayer
    {
        public float FontSize { get; set; }
        public StringAlignment HorizontalAlign { get; set; }
        public StringAlignment VerticalAlign { get; set; }

        public BibleLayer()
        {
            
        }

        public override void writeOut(System.Drawing.Graphics gr, object[] args, ProjectionMode pr)
        {
            XMLBible.Vers v = (XMLBible.Vers)args[0];
            XMLBible.Vers v2 = (XMLBible.Vers)args[1];

            string Title = v.getTitle(v2.Number);

            string Text = "";
            for (int i = v.Number; i <= v2.Number; i++)
            {
                Text += v.Chapter.getVerses()[i - 1] + Environment.NewLine;
            }


            Font font = new Font(Settings.Instance.ProjectionMasterFont.FontFamily, FontSize, Settings.Instance.ProjectionMasterFont.Style);
            Font titleFont = new Font(Settings.Instance.ProjectionMasterFont.FontFamily, FontSize+10f, Settings.Instance.ProjectionMasterFont.Style);
            Brush fontBrush = new SolidBrush(Settings.Instance.ProjectionMasterFontColor);
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

            gr.DrawString(Title, titleFont, fontBrush, new Point(x, y), strFormat);
            y += (int)coveredTitleArea.Height + 20;
            
            foreach (string l in lines)
            {
                SizeF lm = gr.MeasureString(l, font);

                if (lm.Width > (float)(w - padding))
                {
                    int nc = l.Length / ((int)Math.Ceiling(lm.Width / (float)(w - padding)));
                    string s = string.Join(Environment.NewLine, Util.Wrap(l, nc)).Trim();
                    gr.DrawString(s, font, fontBrush, new Point(x, y), strFormat);
                    y += (int)gr.MeasureString(s, font).Height + Settings.Instance.ProjectionMasterLineSpacing;
                }
                else
                {
                    gr.DrawString(l, font, fontBrush, new Point(x, y), strFormat);
                    y += (int)lm.Height + Settings.Instance.ProjectionMasterLineSpacing;
                }
            }

        }

    }




}
