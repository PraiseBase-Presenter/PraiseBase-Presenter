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
    class LiveText : TextLayer
    {
        public string Text {get;set;}
        public StringAlignment HorizontalAlign { get; set; }
        public StringAlignment VerticalAlign { get; set; }
        public float FontSize { get; set; }

        public LiveText() : this("")
        {
            
        }

        public override List<TextBlock> getTextBlocks(Object[] args)
        {
            List<TextBlock> blocks = new List<TextBlock>();

            TextBlock tb = new TextBlock();
            tb.Margin = 50;
            tb.Alignment = TextAlignment.MiddleCenter;
            TextLine tl = new TextLine();
            tl.Text = "Lorem ipsum dolor sit amet!";
            tl.Font = Pbp.Properties.Settings.Default.ProjectionMasterFont;
            tl.FontBrush = Brushes.Green;
            tb.Lines.Add(tl);
            blocks.Add(tb);
            return blocks;
        }

        public LiveText(string initText)
        {
            Text = initText;
            FontSize = Settings.Default.ProjectionMasterFont.Size;
        }

        public override void writeOut(System.Drawing.Graphics gr, object[] args, ProjectionMode pr)
        {
            Font font = new Font(Settings.Default.ProjectionMasterFont.FontFamily,FontSize,Settings.Default.ProjectionMasterFont.Style);
            Brush fontBrush = new SolidBrush(Settings.Default.ProjectionMasterFontColor);
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = HorizontalAlign;

            int w = (int)gr.VisibleClipBounds.Width;
            int h = (int)gr.VisibleClipBounds.Height;
            int padding = 20;

            string[] lines = Text.Split(Environment.NewLine.ToCharArray());

            SizeF coveredArea = gr.MeasureString(Text, font);
                        
            int x, y;
            if (strFormat.Alignment == StringAlignment.Far)
                x = w - padding;
            else if (strFormat.Alignment == StringAlignment.Center)
                x = w/2;
            else
                x = padding;

            if (VerticalAlign == StringAlignment.Far)
                y = h - padding - (int)coveredArea.Height;
            else if (VerticalAlign == StringAlignment.Center)
                y = (h / 2) - (int)(coveredArea.Height/2);
            else
                y = padding;


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
