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
        private StringFormat strFormat;

        public LiveText(string initText)
        {
            Text = initText;
            strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Near;
        }

        public override void writeOut(System.Drawing.Graphics gr, object[] args, ProjectionMode pr)
        {
            Font font = Settings.Instance.ProjectionMasterFont;
            Brush fontBrush = new SolidBrush(Settings.Instance.ProjectionMasterFontColor);

            gr.DrawString(Text, font, fontBrush, new Point(5, 5), strFormat);

        }
    }
}
