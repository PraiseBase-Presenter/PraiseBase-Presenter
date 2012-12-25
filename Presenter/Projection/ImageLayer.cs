using System;
using System.Drawing;
using Pbp.Properties;

namespace Pbp
{
    public class ImageLayer : BaseLayer
    {
        public Image Image { get; set; }

        public override void writeOut(System.Drawing.Graphics gr, Object[] args, ProjectionMode pm)
        {
            int w = (int)gr.VisibleClipBounds.Width;
            int h = (int)gr.VisibleClipBounds.Height;

            gr.FillRectangle(new SolidBrush(Settings.Default.ProjectionBackColor), 0, 0, w, h);
            if (this.Image != null)
            {
                gr.DrawImage(this.Image, new Rectangle(0, 0, w, h), 0, 0, this.Image.Width, this.Image.Height, GraphicsUnit.Pixel);
            }
        }

    }
}