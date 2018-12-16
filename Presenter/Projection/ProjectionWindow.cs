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

using System.Drawing;
using System.Windows.Forms;
using PraiseBase.Presenter.Properties;
using System;

namespace PraiseBase.Presenter.Projection
{
    public partial class ProjectionWindow : Form
    {
        Image CurrentPreviewImage;
        Image CurrentPreviewText;

        public ProjectionWindow(Screen projScreen)
        {
            InitializeComponent();
            AssignToScreen(projScreen);
            projectionControlHost.Child = new ProjectionControl();
        }

        /// <summary>
        /// Assigns the window to a screen's coordinates
        /// </summary>
        /// <param name="projScreen"></param>
        public void AssignToScreen(Screen projScreen)
        {
            Location = projScreen.WorkingArea.Location;
            Size = new Size(projScreen.WorkingArea.Width, projScreen.WorkingArea.Height);
        }

        /// <summary>
        /// Set to blackout
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="animate"></param>
        public void SetBlackout(bool enable, bool animate)
        {
            ((ProjectionControl)(projectionControlHost.Child)).BlackOut(enable, (animate ? Settings.Default.ProjectionFadeTime : 0));
        }

        /// <summary>
        /// Display image with transition
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="fadetime"></param>
        public void DisplayImage(Bitmap bmp, int fadetime)
        {
            ((ProjectionControl)(projectionControlHost.Child)).SetProjectionImage(bmp, fadetime);
            CurrentPreviewImage = bmp;
        }

        /// <summary>
        /// Hide image with transition
        /// </summary>
        /// <param name="fadetime"></param>
        public void HideImage(int fadetime)
        {
            ((ProjectionControl)(projectionControlHost.Child)).HideProjectionImage(fadetime);
            CurrentPreviewImage = new Bitmap(Width, Height);
        }

        /// <summary>
        /// Display text with transition
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="fadetime"></param>
        public void DisplayText(Bitmap bmp, int fadetime)
        {
            ((ProjectionControl)(projectionControlHost.Child)).SetProjectionText(bmp, fadetime);
            CurrentPreviewText = bmp;
        }

        /// <summary>
        /// Hide text with transition
        /// </summary>
        /// <param name="fadetime"></param>
        public void HideText(int fadetime)
        {
            var bmp = new Bitmap(Width, Height);
            ((ProjectionControl)(projectionControlHost.Child)).SetProjectionText(bmp, fadetime);
            CurrentPreviewText = bmp;
        }

        public void ShowWebsite(Uri uri)
        {
            ((ProjectionControl)(projectionControlHost.Child)).ShowWebsite(uri);
            // TODO
            var bmp = new Bitmap(Width, Height);
            CurrentPreviewImage = bmp;
            CurrentPreviewText = bmp;
        }

        public void HideWebsite()
        {
            ((ProjectionControl)(projectionControlHost.Child)).HideWebsite();
            // TODO
            var bmp = new Bitmap(Width, Height);
            CurrentPreviewImage = bmp;
            CurrentPreviewText = bmp;
        }

        /// <summary>
        /// Create preview image
        /// </summary>
        /// <returns></returns>
        public Image GetPreviewImage()
        {
            Image frame = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(frame);
            if (CurrentPreviewImage != null)
            {
                gr.DrawImage(CurrentPreviewImage, new Rectangle(0, 0, frame.Width, frame.Height), new Rectangle(0, 0, frame.Width, frame.Height), GraphicsUnit.Pixel);
            }
            if (CurrentPreviewText != null)
            {
                gr.DrawImage(CurrentPreviewText, new Rectangle(0, 0, frame.Width, frame.Height), new Rectangle(0, 0, frame.Width, frame.Height), GraphicsUnit.Pixel);
            }
            return frame;
        }

        public new void Dispose()
        {
            ((ProjectionControl)(projectionControlHost.Child)).Dispose();
            base.Dispose();
        }

        private void projectionControlHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}