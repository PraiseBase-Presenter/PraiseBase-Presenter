/*
 *   PraiseBase Presenter 
 *   The open source lyrics and image projection software for churches
 *   
 *   http://code.google.com/p/praisebasepresenter
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
        private Image currentImage;

        static private projectionWindow _instance;

        private projectionWindow()
        {
            InitializeComponent();

            h = 1;
            w = 1;

            scanScreens(0);
            this.Location = projScreen.WorkingArea.Location;
            this.Size = new Size(projScreen.WorkingArea.Width, projScreen.WorkingArea.Height);
            h = this.Height;
            w = this.Width;
			projectionControlHost.Child = UserControl1.getInstance();
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
			//showNone();
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
                //MessageBox.Show("Kein zweiter Bildschirm gefunden! Der Primärbildschirm wird stattdessen verwendet.", "Projektion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (success == 1)
            {
                string msg = "Projektionsbildschirm gefunden!" + Environment.NewLine;
                msg += "Name: " + ConvertString(projScreen.DeviceName) + Environment.NewLine;
                msg += "Auflösung: " + projScreen.WorkingArea.Width.ToString() + "x" + projScreen.WorkingArea.Height.ToString() + " Pixel" + Environment.NewLine;
                MessageBox.Show(msg, "Projektion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public Image showSlide(Song.Slide slide, Image background, bool simluate)
        {
            Application.DoEvents();

            Bitmap bmp = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(bmp);

            // Background color
			gr.FillRectangle(new SolidBrush(Settings.Instance.ProjectionBackColor), 0, 0, w, h);
            
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
            if (slide.Lines.Count > 0)
            {
                StringFormat strFormat = new StringFormat();

                Font font;
                Font fontTr;
                int lineSpacing;
                Brush fontBrush;
                Brush fontTranslationBrush;

				if (Settings.Instance.ProjectionUseMaster && !simluate)
                {
					font = Settings.Instance.ProjectionMasterFont;
					fontTr = Settings.Instance.ProjectionMasterFontTranslation;
					lineSpacing = Settings.Instance.ProjectionMasterLineSpacing;
					fontBrush = new SolidBrush(Settings.Instance.ProjectionMasterFontColor);
					fontTranslationBrush = new SolidBrush(Settings.Instance.ProjectionMasterTranslationColor);
                }
                else
                {
                    font = slide.TextFont;
                    fontTr = slide.TranslationFont;
                    lineSpacing = slide.TextLineSpacing;
                    fontBrush = new SolidBrush(slide.TextColor);
                    fontTranslationBrush = new SolidBrush(slide.TranslationColor);
                }


				int padding = Settings.Instance.ProjectionPadding;
				int shadowThickness = Settings.Instance.ProjectionShadowSize;
				int outLineThickness = Settings.Instance.ProjectionOutlineSize;
                String str = String.Empty;

                int usableWidth = w - (2 * padding);
                int usableHeight = h - (2 * padding);

                int textStartX = padding;
                int textStartY = padding;

                SizeF strMeasureTrans;

				int endSpacing = 0;
                if (slide.Translated)
                {
                    strMeasureTrans = gr.MeasureString(slide.lineBreakTranslation(), fontTr);
                    lineSpacing +=  (int)(strMeasureTrans.Height / slide.Translation.Count) + lineSpacing;
					endSpacing = (int)(strMeasureTrans.Height / slide.Translation.Count) + lineSpacing;
                }

                SizeF strMeasure = gr.MeasureString(slide.lineBreakText(), font);
                Brush shadodBrush = Brushes.Transparent;
                int usedWidth = (int)strMeasure.Width;
				int usedHeight = (int)strMeasure.Height + (lineSpacing * (slide.Lines.Count - 1)) + endSpacing;

                float scalingFactor = 1.0f;
				if (Settings.Instance.ProjectionFontScaling && (usedWidth > usableWidth || usedHeight > usableHeight))
                {
                    scalingFactor = Math.Min((float)usableWidth / (float)usedWidth, (float)usableHeight / (float)usedHeight);
                    font = new Font(font.FontFamily, font.Size * scalingFactor, font.Style);
                    strMeasure = gr.MeasureString(slide.lineBreakText(), font);
                    usedWidth = (int)strMeasure.Width;
                    usedHeight = (int)strMeasure.Height + (lineSpacing * (slide.Lines.Count - 1));
                }
                int lineHeight = (int)(strMeasure.Height / slide.Lines.Count);

                // Horizontal stuff
                switch (slide.HorizontalAlign)
                {
                    case Song.SongTextHorizontalAlign.Left:
                        strFormat.Alignment = StringAlignment.Near;
                        break;
                    case Song.SongTextHorizontalAlign.Center:
                        textStartX = w / 2;
                        strFormat.Alignment = StringAlignment.Center;
                        break;
                    case Song.SongTextHorizontalAlign.Right:
                        textStartX = textStartX + usableWidth;
                        strFormat.Alignment = StringAlignment.Far;
                        break;
                }

                // Vertical stuff
                switch (slide.VerticalAlign)
                {
                    case Song.SongTextVerticalAlign.Top:
                        break;
                    case Song.SongTextVerticalAlign.Center:
                        textStartY = textStartY + (usableHeight / 2) - (usedHeight / 2);
                        break;
                    case Song.SongTextVerticalAlign.Bottom:
                        textStartY = textStartY + usableHeight - usedHeight;
                        break;
                }

                int textX = textStartX;
                int textY = textStartY;

                if (!simluate && shadowThickness > 0)
                {
					shadodBrush = new SolidBrush(Color.FromArgb(15, Settings.Instance.ProjectionShadowColor));
                    gr.SmoothingMode = SmoothingMode.HighQuality;
                    gr.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    foreach (string s in slide.Lines)
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

					Brush br = new SolidBrush(Settings.Instance.ProjectionOutlineColor);

                    foreach (string s in slide.Lines)
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

                foreach (string s in slide.Lines)
                {
                    gr.DrawString(s, font,fontBrush, new Point(textX, textY), strFormat);
                    textY += lineHeight + lineSpacing;
                }

				if (slide.Translated)
				{
					int transStartX = textStartX + 10;
					int transStartY = textStartY + lineHeight;
					textX = transStartX;
					textY = transStartY;

					if (!simluate && shadowThickness > 0)
					{
						shadodBrush = new SolidBrush(Color.FromArgb(15, Settings.Instance.ProjectionShadowColor));
						gr.SmoothingMode = SmoothingMode.HighQuality;
						gr.InterpolationMode = InterpolationMode.HighQualityBilinear;
						gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

						foreach (string s in slide.Translation)
						{
							for (int x = textX; x <= textX + shadowThickness; x++)
							{
								for (int y = textY; y <= textY + shadowThickness; y++)
								{
									gr.DrawString(s, fontTr, shadodBrush, new Point(x, y), strFormat);
								}
							}
							textY += lineHeight + lineSpacing;
						}
						textY = transStartY;
					}
					if (!simluate && outLineThickness > 0)
					{
						gr.SmoothingMode = SmoothingMode.None;
						gr.InterpolationMode = InterpolationMode.Low;
						gr.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

						Brush br = new SolidBrush(Settings.Instance.ProjectionOutlineColor);

						foreach (string s in slide.Translation)
						{
							for (int x = textX - outLineThickness * 2; x <= textX + outLineThickness * 2; x += 2)
							{
								for (int y = textY - outLineThickness * 2; y <= textY + outLineThickness * 2; y += 2)
								{
									gr.DrawString(s, fontTr, br, new Point(x, y), strFormat);
								}
							}
							textY += lineHeight + lineSpacing;
						}
						textY = transStartY;
					}
					
					foreach (string s in slide.Translation)
					{
						gr.DrawString(s, fontTr,fontTranslationBrush,new Point(textX, textY), strFormat);
						textY += lineHeight + lineSpacing;
					}
				}
              

            }

            if (!simluate)
				UserControl1.getInstance().setProjectionImage(bmp);

            gr.Dispose();
            return bmp;
        }



        public Image showImage(Image background)
        {
            Application.DoEvents();
			UserControl1.getInstance().setProjectionImage(new Bitmap(background));
			currentImage = background;
			return background;
        }

        public Image showNone()
        {
            Application.DoEvents();
            Bitmap bmp = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(bmp);
			gr.FillRectangle(new SolidBrush(Settings.Instance.ProjectionBackColor), 0, 0, w, h);
			UserControl1.getInstance().setProjectionImage(bmp);
			currentImage = bmp;
			return bmp;
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
			projectionControlHost.Top = 0;
			projectionControlHost.Left = 0;
			projectionControlHost.Width = this.Width;
			projectionControlHost.Height = this.Height;
			projectionControlHost.Visible = true;
        }


    }
}
