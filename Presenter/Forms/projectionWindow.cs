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
using System.Drawing;
using System.Windows.Forms;
using Pbp.Properties;

namespace Pbp.Forms
{
    public partial class ProjectionWindow : Form
    {
        private Screen _projScreen;

        #region Delegates

        public delegate void ProjectionChange(object sender, ProjectionChangedEventArgs e);

        #endregion

        public event ProjectionChange ProjectionChanged;

        
        private ProjectionWindow()
        {
            InitializeComponent();

            ScanScreens(0);
            Location = _projScreen.WorkingArea.Location;
            Size = new Size(_projScreen.WorkingArea.Width, _projScreen.WorkingArea.Height);

            var wpc = new WpfProjectionControl
            {
                ProjectionBackgroundColor = Settings.Default.ProjectionBackColor
            };
            projectionControlHost.Child = wpc;
        }

        static private ProjectionWindow _instance;
        static readonly object SingletonPadlock = new object();

        /// <summary>
        /// Returns a singleton of mainWindow
        /// </summary>
        /// <returns>Returns the mainWindow instance</returns>
        static public ProjectionWindow Instance
        {
            get
            {
                // Thread safety
                lock (SingletonPadlock)
                {
                    return _instance ?? (_instance = new ProjectionWindow());
                }
            }
        }

        private void ProjectionWindow_Load(object sender, EventArgs e)
        {
            ScanScreens(0);
            Location = _projScreen.WorkingArea.Location;
            Size = new Size(_projScreen.WorkingArea.Width, _projScreen.WorkingArea.Height);
        }

        public void SetBlackout(bool enable, bool animate)
        {
            ((WpfProjectionControl)(projectionControlHost.Child)).BlackOut(enable, (animate ? Settings.Default.ProjectionFadeTime : 0));
        }

        /**
         * Scans for suitable secondary screens. If none is found, an
         * error message is displayed and the primary screen is chosen
         * for projection.
         */
        public void ScanScreens(int success)
        {
            bool allowProjection = false;
            Screen[] screenList = Screen.AllScreens;
            foreach (Screen t in screenList)
            {
                if (!t.Primary)
                {
                    _projScreen = t;
                    allowProjection = true;
                    break;
                }
            }
            if (!allowProjection)
            {
                _projScreen = Screen.PrimaryScreen;
                //MessageBox.Show("Kein zweiter Bildschirm gefunden! Der Primärbildschirm wird stattdessen verwendet.", "Projektion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (success == 1)
            {
                string msg = "Projektionsbildschirm gefunden!" + Environment.NewLine;
                msg += "Name: " + Util.ConvertString(_projScreen.DeviceName) + Environment.NewLine;
                msg += "Auflösung: " + _projScreen.WorkingArea.Width + "x" + _projScreen.WorkingArea.Height + " Pixel" + Environment.NewLine;
                MessageBox.Show(msg, Resources.Projektion, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void DisplayLayer(int layer, TextLayer tl)
        {
            DisplayLayer(layer, tl, Settings.Default.ProjectionFadeTime);
        }

        public void DisplayLayer(int layer, Image background)
        {
            DisplayLayer(layer, background, Settings.Default.ProjectionFadeTime);
        }
        
        public void DisplayLayer(int layer, TextLayer tl, int fadetime)
        {
            var bmp = new Bitmap(Width,Height);
            Graphics gr = Graphics.FromImage(bmp);
            tl.writeOut(gr);

            if (layer == 2)
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionText(bmp, fadetime);
            else
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionImage(bmp, fadetime);

            if (ProjectionChanged != null)
            {
                ProjectionChanged(this, new ProjectionChangedEventArgs { Image = bmp, Layer = layer});
            }
        }

        public void DisplayLayer(int layer, Image background, int fadetime)
        {
            var bmp = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.FillRectangle(new SolidBrush(Settings.Default.ProjectionBackColor), 0, 0, Width, Height);
            if (background != null)
            {
                gr.DrawImage(background, new Rectangle(0, 0, Width, Height), 0, 0, background.Width, background.Height, GraphicsUnit.Pixel);
            }

            if (layer == 2)
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionText(bmp, fadetime);
            else
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionImage(bmp, fadetime);

            if (ProjectionChanged != null)
            {
                ProjectionChanged(this, new ProjectionChangedEventArgs { Image = bmp, Layer = layer });
            }
        }

        public void HideLayer(int layer)
        {
            HideLayer(layer, Settings.Default.ProjectionFadeTime);
        }

        public void HideLayer(int layer, int fadetime)
        {
            var bmp = new Bitmap(Width, Height);
            if (layer == 2)
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionText(bmp, fadetime);
            else
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionImage(bmp, fadetime);
            /*
            if (ProjectionChanged != null)
            {
                ProjectionChanged(this, new ProjectionChangedEventArgs { Image = bmp, Layer = layer });
            }*/
        }

        public class ProjectionChangedEventArgs : EventArgs
        {
            public Image Image { get; set; }
            public int Layer { get; set; }
        }
    }
}
