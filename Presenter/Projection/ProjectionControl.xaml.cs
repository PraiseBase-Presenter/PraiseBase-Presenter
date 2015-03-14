/*
 *   PraiseBase Presenter
 *   The open source lyrics and image projection software for churches
 *
 *   http://praisebase.org
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
 */

using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace PraiseBase.Presenter.Projection
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    ///
    public partial class WpfProjectionControl : UserControl
    {
        #region Delegates

        public delegate void AnimationFinish(object sender, EventArgs e);

        #endregion Delegates

        public WpfProjectionControl()
        {
            InitializeComponent();
            ProjectionBackgroundColor = Color.Black;
        }

        public Color ProjectionBackgroundColor { get; set; }

        public event AnimationFinish AnimationFinished;

        private void ProjectionControlLoaded(object sender, RoutedEventArgs e)
        {
            var bmp = new Bitmap(1, 1);
            Graphics gr = Graphics.FromImage(bmp);
            gr.FillRectangle(new SolidBrush(ProjectionBackgroundColor), 0, 0, 1, 1);
            blackoutImage.Source = LoadBitmap(bmp);
            gr.Dispose();
            blackoutImage.Opacity = 0f;
        }

        /// <summary>
        /// Load a bitmap and convert it to a WPF image source
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected static BitmapSource LoadBitmap(Bitmap source)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(source.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty,
                                                         BitmapSizeOptions.FromEmptyOptions());
        }

        /// <summary>
        /// Set a new image
        /// </summary>
        /// <param name="img">Image that will be shown</param>
        /// <param name="fadeTime">Animation time in miliseconds</param>
        public void SetProjectionImage(Bitmap img, int fadeTime)
        {
            if (fadeTime > 0)
            {
                projectionImage.Opacity = 0f;
                projectionImage.Source = LoadBitmap(img);

                var imageAnimation = (Storyboard)FindResource("imageAnimation");
                imageAnimation.SpeedRatio = 1000f / fadeTime;
                imageAnimation.Begin(this);
            }
            else
            {
                projectionImage.Source = LoadBitmap(img);
                projectionImageBack.Source = projectionImage.Source;
            }
        }

        public void SetProjectionText(Bitmap img, int fadeTime)
        {
            if (fadeTime > 0)
            {
                textImage.Opacity = 0f;
                textImage.Source = LoadBitmap(img);

                var imageAnimation2 = (Storyboard)FindResource("textAnimation2");
                imageAnimation2.SpeedRatio = 1000f / fadeTime;
                imageAnimation2.Begin(this);

                var imageAnimation = (Storyboard)FindResource("textAnimation");
                imageAnimation.SpeedRatio = 1000f / fadeTime;
                imageAnimation.Begin(this);
            }
            else
            {
                textImage.Source = LoadBitmap(img);
                textImageBack.Source = textImage.Source;
                textImageBack.Opacity = 1f;
            }
        }

        /// <summary>
        /// Fired when the animation is finished
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoubleAnimationCompleted(object sender, EventArgs e)
        {
            projectionImageBack.Source = projectionImage.Source;
            if (AnimationFinished != null)
            {
                AnimationFinished(this, new EventArgs());
            }
        }

        private void DoubleAnimationCompleted2(object sender, EventArgs e)
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
        public void BlackOut(bool val, int animationTime)
        {
            var blackoutAnimation = (Storyboard)FindResource(val ? "blackoutAnimationOn" : "blackoutAnimationOff");
            blackoutAnimation.SpeedRatio = (animationTime == 0 ? 100 : 1000f / animationTime);
            blackoutAnimation.Begin(this);
        }

        //public void SetText(List<TextBlock> textBlocks)
        //{
        //    TextBlock bl = textBlocks[0];
        //    String str = string.Empty;
        //    for (int i = 0; i < bl.Lines.Count; i++)
        //    {
        //        str += bl.Lines[i].Text + "\n";
        //        ;
        //    }
        //    //textBlock1.Text = str;
        //    //textBlock1.Width = this.Width - (2 * textBlock1.Margin.Left);
        //    //textBlock1.Height = this.Height - (2 * textBlock1.Margin.Top);
        //}

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