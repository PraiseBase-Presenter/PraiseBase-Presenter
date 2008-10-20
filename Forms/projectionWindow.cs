using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms.Integration;


using Pbp;
using Pbp.Properties;

namespace Pbp.Forms
{
    public partial class projectionWindow : Form
    {
        private int h;
        private int w;
        private Screen projScreen;
        private Settings setting;
        private Image currentImage;

        static private projectionWindow _instance;

        private projectionWindow()
        {
            setting = new Settings();
            InitializeComponent();

            h = 1;
            w = 1;


            this.pictureBoxCommon.BackColor = setting.projectionBackColor;

            scanScreens(0);
            this.Location = projScreen.WorkingArea.Location;
            this.Size = new Size(projScreen.WorkingArea.Width, projScreen.WorkingArea.Height);
            h = this.Height;
            w = this.Width;
            Console.WriteLine("Projection window has dimensions " + w + "*" + h);
        }

        static public projectionWindow getInstance()
        {
            if (_instance == null)
            {
                _instance = new projectionWindow();
            }
            return _instance;
        }

        private void projectionWindow_Load(object sender, EventArgs e)
        {
            scanScreens(0);
            this.Location = projScreen.WorkingArea.Location;
            this.Size = new Size(projScreen.WorkingArea.Width, projScreen.WorkingArea.Height);
            h = this.Height;
            w = this.Width;
            Console.WriteLine("Projection window has dimensions "+w+"*"+h);
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
                string msg = "Projektionsbildschirm gefunden!" + Environment.NewLine;
                msg += "Name: " + ConvertString(projScreen.DeviceName) + Environment.NewLine;
                msg += "Auflösung: " + projScreen.WorkingArea.Width.ToString() + "x" + projScreen.WorkingArea.Height.ToString() + " Pixel" + Environment.NewLine;
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

        public Image showSlide(Song.Slide slide, Image background, bool simluate)
        {
            setting.Reload();

            Application.DoEvents();

            Bitmap bmp = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(bmp);

            // Background color
            gr.FillRectangle(new SolidBrush(setting.projectionBackColor), 0, 0, w, h);
            
            // Background image
            if (background != null)
            {
                gr.DrawImage(background, new Rectangle(0, 0, w, h), 0, 0, background.Width, background.Height, GraphicsUnit.Pixel);
                currentImage = background;
            }
            else if (currentImage!=null)
            {
                gr.DrawImage(currentImage, new Rectangle(0, 0, w, h), 0, 0, currentImage.Width, currentImage.Height, GraphicsUnit.Pixel);
            }

            // Text
            if (slide.lines.Count > 0)
            {
                StringFormat strFormat = new StringFormat();
                Font font = setting.projectionMasterFont;
                Font fontTr = setting.projectionMasterFontTranslation;
                int padding = setting.projectionPadding;
                int lineSpacing = setting.projectionMasterLineSpacing;
                int shadowThickness = setting.projectionShadowSize;
                int outLineThickness = setting.projectionOutlineSize;
                String str = String.Empty;

                int usableWidth = w - (2 * padding);
                int usableHeight = h - (2 * padding);

                int textStartX = padding;
                int textStartY = padding;

                //gr.DrawRectangle(Pens.BlueViolet, padding, padding, usableWidth, usableHeight);

                SizeF strMeasureTrans;

                if (slide.hasTranslation && false)
                {
                    strMeasureTrans = gr.MeasureString(slide.lineBreakTranslation(), fontTr);
                    lineSpacing +=  (int)(strMeasureTrans.Height / slide.translation.Count) + lineSpacing;
                }

                SizeF strMeasure = gr.MeasureString(slide.lineBreakText(), font);
                Brush shadodBrush = Brushes.Transparent;
                int usedWidth = (int)strMeasure.Width;
                int usedHeight = (int)strMeasure.Height + (lineSpacing * (slide.lines.Count - 1));

                float scalingFactor = 1.0f;
                if (setting.projectionFontScaling  && (usedWidth > usableWidth || usedHeight > usableHeight))
                {
                    scalingFactor = Math.Min((float)usableWidth / (float)usedWidth, (float)usableHeight / (float)usedHeight);
                    font = new Font(font.FontFamily, font.Size * scalingFactor, font.Style);
                    strMeasure = gr.MeasureString(slide.lineBreakText(), font);
                    usedWidth = (int)strMeasure.Width;
                    usedHeight = (int)strMeasure.Height + (lineSpacing * (slide.lines.Count - 1));
                }
                int lineHeight = (int)(strMeasure.Height / slide.lines.Count);

                // Horizontal stuff
                switch (slide.horizAlign)
                {
                    case Song.SongTextHorizontalAlign.left:
                        strFormat.Alignment = StringAlignment.Near;
                        break;
                    case Song.SongTextHorizontalAlign.center:
                        textStartX = w / 2;
                        strFormat.Alignment = StringAlignment.Center;
                        break;
                    case Song.SongTextHorizontalAlign.right:
                        textStartX = textStartX + usableWidth;
                        strFormat.Alignment = StringAlignment.Far;
                        break;
                }

                // Vertical stuff
                switch (slide.vertAlign)
                {
                    case Song.SongTextVerticalAlign.top:
                        break;
                    case Song.SongTextVerticalAlign.center:
                        textStartY = textStartY + (usableHeight / 2) - (usedHeight / 2);
                        break;
                    case Song.SongTextVerticalAlign.bottom:
                        textStartY = textStartY + usableHeight - usedHeight;
                        break;
                }

                int transStartX = textStartX + 10;
                int transStartY = textStartY + lineHeight;



                int textX = textStartX;
                int textY = textStartY;

                if (!simluate && shadowThickness > 0)
                {
                    shadodBrush = new SolidBrush(Color.FromArgb(15, setting.projectionShadowColor));
                    gr.SmoothingMode = SmoothingMode.HighQuality;
                    gr.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    foreach (string s in slide.lines)
                    {
                        for (int x = textX; x <= textX + shadowThickness; x++)
                        {
                            for (int y = textY; y <= textY + shadowThickness; y++)
                            {
                                gr.DrawString(s, font, shadodBrush, new Point(x, y), strFormat);
                            }
                        }
                        textY += lineHeight + lineSpacing;
                    }
                    textY = textStartY;
                }
                if (!simluate && outLineThickness > 0)
                {
                    gr.SmoothingMode = SmoothingMode.None;
                    gr.InterpolationMode = InterpolationMode.Low;
                    gr.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                    Brush br = new SolidBrush(setting.projectionOutlineColor);

                    foreach (string s in slide.lines)
                    {
                        for (int x = textX - outLineThickness*2; x <= textX + outLineThickness*2; x+=2)
                        {
                            for (int y = textY - outLineThickness*2; y <= textY + outLineThickness*2; y+=2)
                            {
                                gr.DrawString(s, font, br, new Point(x, y), strFormat);
                            }
                        }
                        textY += lineHeight + lineSpacing;
                    }
                    textY = textStartY;
                }

                foreach (string s in slide.lines)
                {
                    gr.DrawString(s, font, new SolidBrush(setting.projectionMasterFontColor), new Point(textX, textY), strFormat);
                    textY += lineHeight + lineSpacing;
                }

                /*
                foreach (string s in slide.translation)
                {
                    gr.DrawString(s, fonttrans, new SolidBrush(setting.projectionMasterFontColor), new Point(textX, textY), strFormat);
                    textY += lineHeight + lineSpacing;
                }       */           
              

            }

            if (!simluate)
                pictureBoxCommon.Image = bmp;

            gr.Dispose();
            return bmp;
        }



        public void showImage(Image background)
        {
            Application.DoEvents();
            pictureBoxCommon.Image = background;
            currentImage = background;
        }

        public void showNone()
        {
            Application.DoEvents();
            Bitmap bmp = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(bmp);
            Font font = setting.projectionMasterFont;
            gr.FillRectangle(new SolidBrush(setting.projectionBackColor), 0, 0, w, h);
            pictureBoxCommon.Image = bmp;
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
