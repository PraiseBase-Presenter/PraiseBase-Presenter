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

        public LiveText(string initText)
        {
            Text = initText;
            FontSize = Settings.Instance.ProjectionMasterFont.Size;
        }

        public override void writeOut(System.Drawing.Graphics gr, object[] args, ProjectionMode pr)
        {
            Font font = new Font(Settings.Instance.ProjectionMasterFont.FontFamily,FontSize,Settings.Instance.ProjectionMasterFont.Style);
            Brush fontBrush = new SolidBrush(Settings.Instance.ProjectionMasterFontColor);
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = HorizontalAlign;

            int w = (int)gr.VisibleClipBounds.Width;
            int h = (int)gr.VisibleClipBounds.Height;
            int padding = 20;

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

            gr.DrawString(Text, font, fontBrush, new Point(x, y), strFormat);

        }
    }
}
