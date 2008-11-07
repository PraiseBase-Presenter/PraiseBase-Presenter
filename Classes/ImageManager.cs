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
using System.Linq;
using System.Text;
using Pbp.Properties;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using Pbp.Forms;

namespace Pbp
{
    class ImageManager
    {
        static private ImageManager instance;
        private Image _currentImage;
		private bool _createThumbs;

        public Image currentImage
        {
            get
            {
                return _currentImage;
            }
            set
            {
                _currentImage = value;
            }
        }

        private ImageManager()
        {

        }

        static public ImageManager getInstance()
        {
            if (instance == null)
            {
                instance = new ImageManager();
            }
            return instance;
        }


		Image FixedSize(Image imgPhoto, int Width, int Height)
		{
			int sourceWidth = imgPhoto.Width;
			int sourceHeight = imgPhoto.Height;
			int sourceX = 0;
			int sourceY = 0;
			int destX = 0;
			int destY = 0;

			float nPercent = 0;
			float nPercentW = 0;
			float nPercentH = 0;

			nPercentW = ((float)Width / (float)sourceWidth);
			nPercentH = ((float)Height / (float)sourceHeight);
			if (nPercentH < nPercentW)
			{
				nPercent = nPercentH;
				destX = System.Convert.ToInt16((Width -
							  (sourceWidth * nPercent)) / 2);
			}
			else
			{
				nPercent = nPercentW;
				destY = System.Convert.ToInt16((Height -
							  (sourceHeight * nPercent)) / 2);
			}

			int destWidth = (int)(sourceWidth * nPercent);
			int destHeight = (int)(sourceHeight * nPercent);

			Bitmap bmPhoto = new Bitmap(Width, Height,
							  PixelFormat.Format24bppRgb);
			bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
							 imgPhoto.VerticalResolution);

			Graphics grPhoto = Graphics.FromImage(bmPhoto);
			grPhoto.Clear(Color.Black);
			grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			
			grPhoto.DrawImage(imgPhoto,
				new Rectangle(destX, destY, destWidth, destHeight),
				new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
				GraphicsUnit.Pixel);

			grPhoto.Dispose();
			return bmPhoto;
		}

		public Bitmap ResizeBitmap(Image b, int nWidth, int nHeight)
		{
			Bitmap result = new Bitmap(nWidth, nHeight);
			using (Graphics g = Graphics.FromImage((Image)result))
				g.DrawImage(b, 0, 0, nWidth, nHeight);
			return result;
		}

		public void createThumb(string inFile, string outFile, Size size)
		{
			Image img;
			try
			{
				img = Image.FromFile(inFile);
				//Image imgPhoto = FixedSize(img, size.Width, size.Height);
				Image imgPhoto = ResizeBitmap(img, size.Width, size.Height);

				string dir = Path.GetDirectoryName(outFile);
				if (!Directory.Exists(dir))
				{
					Directory.CreateDirectory(dir);
				}
				imgPhoto.Save(outFile, ImageFormat.Jpeg);
				imgPhoto.Dispose();
				img.Dispose();
			}
			catch (Exception e)
			{
				Console.WriteLine("Image Error: " + e);
			}
		}


		public void checkThumbs()
		{
			checkThumbs(null);
		}

		public void checkThumbs(Loading ldg)
		{
			Settings setting = new Settings();
			string imageRootDir = setting.DataDirectory + Path.DirectorySeparatorChar + setting.ImageDir;
			string thumbDir = setting.DataDirectory + Path.DirectorySeparatorChar + setting.ThumbDir;

			if (!Directory.Exists(thumbDir))
			{
				Directory.CreateDirectory(thumbDir);
			}

			string[] imgExtensions = { "*.jpg"};

			if (Directory.Exists(imageRootDir))
			{
				List<string> missingThumbsSrc = new List<string>();
				List<string> missingThumbsTrg = new List<string>();
				foreach (string ext in imgExtensions)
				{
					string[] paths = Directory.GetFiles(imageRootDir, ext, SearchOption.AllDirectories);
					foreach (string file in paths)
					{
						string relativePath = file.Substring((imageRootDir + Path.DirectorySeparatorChar).Length);
						string thumbPath = thumbDir + Path.DirectorySeparatorChar + relativePath;
						if (!File.Exists(thumbPath))
						{
							missingThumbsSrc.Add(file);
							missingThumbsTrg.Add(thumbPath);
						}
						
					}
				}

				int cnt = missingThumbsSrc.Count;
				if (cnt > 0)
				{
					if (ldg == null)
					{
						Form frm = new Form();
						frm.Text = "Erstelle Miniaturbilder...";
						frm.Width = 450;
						frm.Height = 100;
						frm.ShowIcon = false;
						frm.StartPosition = FormStartPosition.CenterScreen;
						frm.ShowInTaskbar = false;
						frm.MaximizeBox = false;
						frm.MinimizeBox = false;

						ProgressBar prBr = new ProgressBar();
						prBr.Minimum = 0;
						prBr.Maximum = cnt;
						prBr.Height = 20;
						prBr.Width = 260;
						prBr.Style = ProgressBarStyle.Continuous;
						prBr.Location = new Point(15, 25);
						frm.Controls.Add(prBr);

						Label lbl = new Label();
						lbl.Location = new Point(prBr.Right + 5, prBr.Top + 3);
						frm.Controls.Add(lbl);
						lbl.Width = 50;

						Button btn = new Button();
						btn.Text = "Abbrechen";
						btn.Location = new Point(lbl.Right + 5, prBr.Top);
						btn.Click += new EventHandler(btn_Click);
						btn.Width = 80;
						frm.Controls.Add(btn);
						frm.Show();

						Settings stn = new Settings();
						_createThumbs = true;
						for (int i = 0; i < cnt; i++)
						{
							createThumb(missingThumbsSrc[i], missingThumbsTrg[i], stn.ThumbSize);
							if (i % 5 == 0)
							{
								prBr.Value = i;
								lbl.Text = i.ToString() + "/" + cnt.ToString();
								if (!_createThumbs)
								{
									frm.Close();
									Application.DoEvents();
									break;
								}
								Application.DoEvents();
							}
						}
						frm.Hide();
					}
					else
					{
						Settings stn = new Settings();
						ldg.setProgBarMax(cnt);
						for (int i = 0; i < cnt; i++)
						{
							createThumb(missingThumbsSrc[i], missingThumbsTrg[i], stn.ThumbSize);
							if (i % 5 == 0)
							{
								ldg.setLabel("Erstelle Miniaturbilder " + i.ToString() + "/" + cnt.ToString());
								ldg.setProgBarValue(i);
								Application.DoEvents();
							}
						}
					}


				}
			}
		}

		void btn_Click(object sender, EventArgs e)
		{
			_createThumbs = false;
		}

    }
}
