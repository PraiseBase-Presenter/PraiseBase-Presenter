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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

using Pbp.Properties;

namespace Pbp.Forms
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	/// 

	public partial class UserControl1 : UserControl
	{
		DispatcherTimer tmr;
		static UserControl1 instance;
		private int fadeSteps;
		float opCounter;

        bool isBlackout = false;

        int pbi = 0;

		private UserControl1()
		{
			InitializeComponent();
			tmr = new DispatcherTimer();
            setFadeSteps(Settings.Instance.ProjectionFadeTime);
		}

		static public UserControl1 getInstance()
		{
			if (instance == null)
				instance = new UserControl1();
			return instance;
		}

		private void projectionControl_Loaded(object sender, RoutedEventArgs e)
		{
			System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1);
			System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
			gr.FillRectangle(new System.Drawing.SolidBrush(Settings.Instance.ProjectionBackColor), 0, 0, 1, 1);
			blackoutImage.Source = loadBitmap(bmp);
            gr.Dispose();
            blackoutImage.Opacity = isBlackout ? 100f : 0f;
		}

		public static BitmapSource loadBitmap(System.Drawing.Bitmap source)
		{
			return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(source.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty,
				System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
		}

		public void setFadeSteps(int steps)
		{
			steps = steps >= 0 ? steps : 0;

            if (steps == 3)
                fadeSteps = 100;
            else if (steps == 2)
                fadeSteps = 20;
            else if (steps == 1)
                fadeSteps = 3;
            else
                fadeSteps = 0;

		}

		public void setProjectionImage(System.Drawing.Bitmap img)
		{
			projectionImage.Opacity = 0f;
			projectionImage.Source = loadBitmap(img);
			opCounter = 0f;

			if (tmr.IsEnabled)
			{
				tmr.Stop();
			}
			tmr = new DispatcherTimer();
			tmr.Dispatcher.Thread.Priority = System.Threading.ThreadPriority.AboveNormal;
			tmr.Interval = TimeSpan.FromMilliseconds(fadeSteps);
			tmr.Tick += new EventHandler(tmr_Tick);
			tmr.Start();
		}

		void tmr_Tick(object sender, EventArgs e)
		{
			if (projectionImage.Opacity < 1.0f)
			{
				opCounter += 0.02f;
				projectionImage.Opacity = opCounter;
                int x = (int)(opCounter * 100);
                if (pbi++ % 10 == 0)
                {
                    MainWindow.getInstance().setProgessBarTransitionValue(x);
                }
            }
			else
			{
				projectionImage.Opacity = 1f;
				projectionImageBack.Source = projectionImage.Source;
				MainWindow.getInstance().setProgessBarTransitionValue(0);
                pbi = 0;
				tmr.Stop();
			}
		}

		public void blackOut(bool val,bool fade)
		{
            isBlackout = val;
            if (fade)
            {
                if (tmr.IsEnabled)
                {
                    tmr.Stop();
                }
                tmr = new DispatcherTimer();
                tmr.Dispatcher.Thread.Priority = System.Threading.ThreadPriority.AboveNormal;
                tmr.Interval = TimeSpan.FromMilliseconds(fadeSteps);
                tmr.Tick += new EventHandler(tmr_blTick);

                if (val)
                {
                    opCounter = 0f;
                    blackoutImage.Opacity = 0f;
                    tmr.Tag = 0.02f;
                }
                else
                {
                    opCounter = 1f;
                    blackoutImage.Opacity = 1f;
                    tmr.Tag = -0.02f;
                }
                tmr.Start();
            }
            else
            {
                blackoutImage.Opacity = val ? 100 : 0;
            }
		}

		void tmr_blTick(object sender, EventArgs e)
		{
			if ((float)tmr.Tag > 0f && blackoutImage.Opacity <= 1.0f
				|| (float)tmr.Tag < 0f && blackoutImage.Opacity >= 0.0f )
			{
				opCounter += (float)tmr.Tag;
				blackoutImage.Opacity = opCounter;
			}
			else
			{
				tmr.Stop();
			}
		}

        private void blackoutImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }






	}
}

