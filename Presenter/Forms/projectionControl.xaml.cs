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
using System.Windows.Media.Animation;

namespace Pbp.Forms
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	/// 

	public partial class WPFProjectionControl : UserControl
	{
        public System.Drawing.Color ProjectionBackgroundColor {get;set;}

        public delegate void animationFinish(object sender, EventArgs e);
        public event animationFinish AnimationFinished;

        public WPFProjectionControl()
		{
			InitializeComponent();
            ProjectionBackgroundColor = System.Drawing.Color.Black;
        }

		private void projectionControl_Loaded(object sender, RoutedEventArgs e)
		{
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1);
			System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
            gr.FillRectangle(new System.Drawing.SolidBrush(ProjectionBackgroundColor), 0, 0, 1, 1);
			blackoutImage.Source = loadBitmap(bmp);
            gr.Dispose();
            blackoutImage.Opacity = 0f;
		}

        /// <summary>
        /// Load a bitmap and convert it to a WPF image source
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
		protected static BitmapSource loadBitmap(System.Drawing.Bitmap source)
		{
			return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(source.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty,
				System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
		}

        /// <summary>
        /// Set a new image
        /// </summary>
        /// <param name="img">Image that will be shown</param>
        /// <param name="fadeTime">Animation time in miliseconds</param>
		public void setProjectionImage(System.Drawing.Bitmap img, int fadeTime)
		{
            if (fadeTime > 0)
            {
                projectionImage.Opacity = 0f;
                projectionImage.Source = loadBitmap(img);
                Storyboard ImageAnimation = (Storyboard)FindResource("imageAnimation");
                ImageAnimation.SpeedRatio = 1000f / (float)fadeTime;
                ImageAnimation.Begin(this);
            }
            else
            {
                projectionImage.Source = loadBitmap(img);
                projectionImageBack.Source = projectionImage.Source;
            }
		}

        public void setProjectionText(System.Drawing.Bitmap img, int fadeTime)
        {
            if (fadeTime > 0)
            {
                textImage.Opacity = 0f;
                textImage.Source = loadBitmap(img);

                Storyboard ImageAnimation2 = (Storyboard)FindResource("textAnimation2");
                ImageAnimation2.SpeedRatio = 1000f / (float)fadeTime;
                ImageAnimation2.Begin(this);

                Storyboard ImageAnimation = (Storyboard)FindResource("textAnimation");
                ImageAnimation.SpeedRatio = 1000f / (float)fadeTime;
                ImageAnimation.Begin(this);
            }
            else
            {
                textImage.Source = loadBitmap(img);
                textImageBack.Source = textImage.Source;
                textImageBack.Opacity = 1f;
            }
        }

        /// <summary>
        /// Fired when the animation is finished
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            projectionImageBack.Source = projectionImage.Source;
            if (AnimationFinished != null)
            {
                AnimationFinished(this, new EventArgs());
            }
        }

        private void DoubleAnimation_Completed2(object sender, EventArgs e)
        {
            textImageBack.Source = textImage.Source;
            textImageBack.Opacity = 1f;
            if (AnimationFinished != null)
            {
                AnimationFinished(this, new EventArgs());
            }
        }

        /// <summary>
        /// Toggle blackout mode
        /// </summary>
        /// <param name="val">True if blackout should be enabled, else false</param>
        /// <param name="animationTime">Animation duration in miliseconds</param>
        public void blackOut(bool val, int animationTime)
		{
            System.Windows.Media.Animation.Storyboard blackoutAnimation = (System.Windows.Media.Animation.Storyboard)FindResource(val ? "blackoutAnimationOn" : "blackoutAnimationOff");
            blackoutAnimation.SpeedRatio = (animationTime == 0 ? 100 : 1000f / (float)animationTime);
            blackoutAnimation.Begin(this);
		}

        public void setText(List<TextBlock> textBlocks)
        {
            TextBlock bl = textBlocks[0];
            String str = string.Empty;
            for (int i=0;i<bl.Lines.Count;i++)
            {
                str += bl.Lines[i].Text + "\n"; ;
            }
            //textBlock1.Text = str;
            //textBlock1.Width = this.Width - (2 * textBlock1.Margin.Left);
            //textBlock1.Height = this.Height - (2 * textBlock1.Margin.Top);
        }

        /*
        TextContent.Text = "aasdfasdfasdf\naasdfasdfasdf\naasdfasdfasdf\naasdfasdfasdf\naasdfasdfasdf\n";
        TextContent.Width = this.Width - (2 * TextContent.Margin.Left);
        TextContent.Height = this.Height - (2 * TextContent.Margin.Top);
        */
        /*
                    textBlock1.Text = "Animation: "+fadeTime+" ms";
                    textBlock1.Visibility = System.Windows.Visibility.Visible;
                    textBlock1.Width = this.Width - (2 * textBlock1.Margin.Left);
                    textBlock1.Height = this.Height - (2 * textBlock1.Margin.Top);
                    */
	}
}

