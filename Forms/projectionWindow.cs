using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace Pbp.Forms
{
    public partial class projectionWindow : Form
    {
        private Screen projScreen;
        private int h;
        private int w;

        public projectionWindow()
        {
            InitializeComponent();
        }

        private void projectionWindow_Load(object sender, EventArgs e)
        {
            scanScreens(0);
            this.Location = projScreen.WorkingArea.Location;
            this.Size = new Size(projScreen.WorkingArea.Width, projScreen.WorkingArea.Height);
            h = this.Height;
            w = this.Width;
        }

        /**
         * Scans for suitable secondary screens. If none is found, an
         * error message is displayed and the primary screen is chosen
         * for projection.
         */
        public void scanScreens(int success)
        {
            bool allowProjection = false;
            Screen[] screenList = System.Windows.Forms.Screen.AllScreens;
            for (int i = 0; i < screenList.Length; i++)
            {
                if (!screenList[i].Primary)
                {
                    projScreen = screenList[i];
                    allowProjection = true;
                    break;
                }
            }
            if (!allowProjection)
            {
                projScreen = System.Windows.Forms.Screen.PrimaryScreen;
                MessageBox.Show("Kein zweiter Bildschirm gefunden! Der Primärbildschirm wird stattdessen verwendet.", "Projektion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (success == 1)
            {
                string msg = "Projektionsbildschirm gefunden!\n";
                msg += "Name: " + ConvertString(projScreen.DeviceName) + "\n";
                msg += "Auflösung: " + projScreen.WorkingArea.Width.ToString() + "x" + projScreen.WorkingArea.Height.ToString() + " Pixel\n";
                MessageBox.Show(msg, "Projektion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void blackout(int val)
        {
            if (val > 0)
                pictureBoxBlackout.Visible = true;
            else
                pictureBoxBlackout.Visible = false;
        }

        public void showText(string str, Font font, Image background)
        {
            Application.DoEvents();

            Bitmap bmp = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(bmp);

            gr.FillRectangle(Brushes.Black, 0, 0, w, h);
            if (background != null)
            {
                gr.DrawImage(background, new Rectangle(0, 0, w, h), 0, 0, background.Width, background.Height, GraphicsUnit.Pixel);
            }
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            strFormat.LineAlignment = StringAlignment.Center;
            gr.DrawString(str, font, Brushes.White,
                          pictureBoxCommon.Width / 2,
                          pictureBoxCommon.Height / 2, strFormat);

            pictureBoxCommon.Image = bmp;
            
            gr.Dispose();
            Application.DoEvents();
        }





        public string ConvertString(string unicode)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in unicode)
                if (c >= 32 && c <= 255)
                    sb.Append(c);
            return sb.ToString();
        }

        private void projectionWindow_Paint(object sender, PaintEventArgs e)
        {
            pictureBoxCommon.Top = 0;
            pictureBoxCommon.Left = 0;
            pictureBoxCommon.Width = this.Width;
            pictureBoxCommon.Height = this.Height;

            pictureBoxBlackout.Top = 0;
            pictureBoxBlackout.Left = 0;
            pictureBoxBlackout.Width = this.Width;
            pictureBoxBlackout.Height = this.Height;

        }


    }
}
