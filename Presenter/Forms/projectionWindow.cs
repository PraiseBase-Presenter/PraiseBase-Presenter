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
    public partial class ProjectionWindow : Form
    {
        private int h;
        private int w;
        private Screen projScreen;
        Timer tmr;
        
        private ProjectionWindow()
        {
            InitializeComponent();

            h = 1;
            w = 1;

            scanScreens(0);
            this.Location = projScreen.WorkingArea.Location;
            this.Size = new Size(projScreen.WorkingArea.Width, projScreen.WorkingArea.Height);
            h = this.Height;
            w = this.Width;

            WPFProjectionControl wpc = new WPFProjectionControl();
            wpc.ProjectionBackgroundColor = Pbp.Properties.Settings.Default.ProjectionBackColor;
            wpc.AnimationFinished += new WPFProjectionControl.animationFinish(wpc_AnimationFinished);
            projectionControlHost.Child = wpc;

            tmr = new Timer();
            tmr.Tick += new EventHandler(tmr_Tick);
        }

        static private ProjectionWindow instance;
        static readonly object singletonPadlock = new object();

        /// <summary>
        /// Returns a singleton of mainWindow
        /// </summary>
        /// <returns>Returns the mainWindow instance</returns>
        static public ProjectionWindow Instance
        {
            get
            {
                // Thread safety
                lock (singletonPadlock)
                {
                    if (instance == null)
                        instance = new ProjectionWindow();
                    return instance;
                }
            }
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

        public void setBlackout(bool enable, bool animate)
        {
            ((WPFProjectionControl)(projectionControlHost.Child)).blackOut(enable, (animate ? Settings.Default.ProjectionFadeTime : 0));
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

        public Image showSlide(TextLayer tl, Image background)
        {
            Object[] textLayerArgs = { };
            return showSlide(tl, background, textLayerArgs, ProjectionMode.Projection);
        }

        public Image showSlide(TextLayer tl, Image background, Object[] textLayerArgs)
        {
            return showSlide(tl, background, textLayerArgs, ProjectionMode.Projection);
        }

        int tmri = 0;

        public Image showSlide(TextLayer tl, Image background, Object[] textLayerArgs,ProjectionMode pm)
        {
            MainWindow.Instance.setProgessBarTransitionValue(0);

            Application.DoEvents();

            Bitmap bmp = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(bmp);

            // Background color
			gr.FillRectangle(new SolidBrush(Settings.Default.ProjectionBackColor), 0, 0, w, h);
            
            // Background image
            if (background != null)
            {
                gr.DrawImage(background, new Rectangle(0, 0, w, h), 0, 0, background.Width, background.Height, GraphicsUnit.Pixel);
            }

            // Apply text layer
            if (tl != null)
            {
                tl.writeOut(gr, textLayerArgs, pm);
            }

            if (pm == ProjectionMode.Projection)
            {
                tmr.Interval = Settings.Default.ProjectionFadeTime / 10;
                tmr.Start();
                ((WPFProjectionControl)(projectionControlHost.Child)).setProjectionImage(bmp, Settings.Default.ProjectionFadeTime);
            }

            if (tl != null)
            {
                //((WPFProjectionControl)(projectionControlHost.Child)).setText(tl.getTextBlocks(textLayerArgs));
            }
            gr.Dispose();
            return bmp;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            tmri += 10;
            MainWindow.Instance.setProgessBarTransitionValue(tmri);
        }

        void wpc_AnimationFinished(object sender, EventArgs e)
        {
            tmr.Stop();
            int tmri = 0;
            //MainWindow.Instance.setProgessBarTransitionValue(100);
        }


        public string ConvertString(string unicode)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in unicode)
                if (c >= 32 && c <= 255)
                    sb.Append(c);
            return sb.ToString();
        }
    }
}
