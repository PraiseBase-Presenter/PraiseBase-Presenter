using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pbp.Components
{
    [DefaultEvent("ColorPicked")]
    public partial class ColorPicker : UserControl
    {
        List<Panel> colorpanels = new List<Panel>();

        public delegate void colorPick(object sender, ColorPickEventArgs e);
        public new event colorPick ColorPicked;


        public ColorPicker()
        {
            InitializeComponent();
        }

        private void ColorPicker_Load(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(ColorPicker_Paint);
        }

        void ColorPicker_Paint(object sender, PaintEventArgs e)
        {
            int i=0;
            int sx=10,sy=10,x=0, y=0;
            foreach (System.Reflection.PropertyInfo p in typeof(Color).GetProperties())
            {
                Color c = new Color();
                if (p.PropertyType == typeof(Color))
                {
                    if (colorpanels.Count > i)
                    {
                        colorpanels[i].Location = new Point(sx + x, sy + y);
                    }
                    else
                    {
                        Panel pnl = new Panel();
                        pnl.Click += new EventHandler(pnl_Click);
                        pnl.Location = new Point(sx + x, sy + y);
                        pnl.Size = new Size(20, 20);
                        pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                        pnl.BackColor = (Color)p.GetValue(c, null);
                        colorpanels.Add(pnl);
                        Controls.Add(pnl);
                    }
                    i++;

                    x += 20;
                    if (x > this.Width-30)
                    {
                        x = 0;
                        y += 20;
                    }
                }
            }   

        }

        void pnl_Click(object sender, EventArgs e)
        {
            if (ColorPicked != null)
            {
                ColorPickEventArgs ea = new ColorPickEventArgs(((Panel)sender).BackColor);
                ColorPicked(this, ea);
            }
        }
    }

    public class ColorPickEventArgs : EventArgs
    {
        public ColorPickEventArgs(Color clr)
		{
            this.Color = clr;
		}
		public Color Color {get;set;}
    }
}
