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

            WpfProjectionControl wpc = new WpfProjectionControl();
            wpc.ProjectionBackgroundColor = Pbp.Properties.Settings.Default.ProjectionBackColor;
            wpc.AnimationFinished += new WpfProjectionControl.AnimationFinish(wpc_AnimationFinished);
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
            ((WpfProjectionControl)(projectionControlHost.Child)).BlackOut(enable, (animate ? Settings.Default.ProjectionFadeTime : 0));
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
                msg += "Name: " + Util.ConvertString(projScreen.DeviceName) + Environment.NewLine;
                msg += "Auflösung: " + projScreen.WorkingArea.Width.ToString() + "x" + projScreen.WorkingArea.Height.ToString() + " Pixel" + Environment.NewLine;
                MessageBox.Show(msg, "Projektion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void displayLayer(int layer, TextLayer tl)
        {
            displayLayer(layer, tl, Settings.Default.ProjectionFadeTime);
        }

        public void displayLayer(int layer, Image background)
        {
            displayLayer(layer, background, Settings.Default.ProjectionFadeTime);
        }
        
        public void displayLayer(int layer, TextLayer tl, int fadetime)
        {
            Bitmap bmp = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(bmp);
            tl.writeOut(gr);

            if (layer == 2)
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionText(bmp, fadetime);
            else
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionImage(bmp, fadetime);
        }

        public void displayLayer(int layer, Image background, int fadetime)
        {
            var bmp = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(bmp);
            gr.FillRectangle(new SolidBrush(Settings.Default.ProjectionBackColor), 0, 0, w, h);
            gr.DrawImage(background, new Rectangle(0, 0, w, h), 0, 0, background.Width, background.Height, GraphicsUnit.Pixel);

            if (layer == 2)
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionText(bmp, fadetime);
            else
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionImage(bmp, fadetime);
        }

        public void hideLayer(int layer)
        {
            hideLayer(layer, Settings.Default.ProjectionFadeTime);
        }

        public void hideLayer(int layer, int fadetime)
        {
            var bmp = new Bitmap(w, h);
            if (layer == 2)
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionText(bmp, fadetime);
            else
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionImage(bmp, fadetime);
        }

        int tmri = 0;
        /*
        public Image showSlide(TextLayer tl, Image background)
        {
            Object[] textLayerArgs = { };
            return showSlide(tl, background, textLayerArgs, ProjectionMode.Projection);
        }

        public Image showSlide(TextLayer tl, Image background, Object[] textLayerArgs)
        {
            return showSlide(tl, background, textLayerArgs, ProjectionMode.Projection);
        }
        
        public Image showSlide(TextLayer tl, Image background, Object[] textLayerArgs,ProjectionMode pm)
        {
            //DateTime startTime = DateTime.Now;

            MainWindow.Instance.setProgessBarTransitionValue(0);

            Application.DoEvents();

            Bitmap bmp = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(bmp);

            //Console.WriteLine("Init " + (DateTime.Now - startTime).TotalSeconds);
            //startTime = DateTime.Now;

            // Background color
			gr.FillRectangle(new SolidBrush(Settings.Default.ProjectionBackColor), 0, 0, w, h);

            //Console.WriteLine("BG color " + (DateTime.Now - startTime).TotalSeconds);
            //startTime = DateTime.Now;
            
            // Background image
            if (background != null)
            {
                gr.DrawImage(background, new Rectangle(0, 0, w, h), 0, 0, background.Width, background.Height, GraphicsUnit.Pixel);
            }

            //Console.WriteLine("BG image " + (DateTime.Now - startTime).TotalSeconds);
            //startTime = DateTime.Now;

            Bitmap bmp2 = new Bitmap(w, h);
            Graphics gr2 = Graphics.FromImage(bmp2);

            // Apply text layer
            if (tl != null)
            {
                tl.writeOut(gr2, textLayerArgs, pm);
            }

            //Console.WriteLine("Text " + (DateTime.Now - startTime).TotalSeconds);
            //startTime = DateTime.Now;

            //Console.WriteLine("Hash " + (DateTime.Now - startTime).TotalSeconds);
            //startTime = DateTime.Now;

            if (pm == ProjectionMode.Projection)
            {
                if (Settings.Default.ProjectionFadeTime > 0)
                {
                    int timerInterval = (int)((float)Settings.Default.ProjectionFadeTime / 10f);
                    if (timerInterval > 0)
                    {
                        tmr.Interval = timerInterval;
                        tmr.Start();
                    }
                }
                ((WPFProjectionControl)(projectionControlHost.Child)).setProjectionImage(bmp, Settings.Default.ProjectionFadeTime);
                ((WPFProjectionControl)(projectionControlHost.Child)).setProjectionText(bmp2, Settings.Default.ProjectionFadeTime);
            }

            //Console.WriteLine("Projection " + (DateTime.Now - startTime).TotalSeconds);
            //startTime = DateTime.Now;


            //if (tl != null)
            //{
                //((WPFProjectionControl)(projectionControlHost.Child)).setText(tl.getTextBlocks(textLayerArgs));
            //}
            gr.Dispose();

            //String hash = Util.GetMD5Hash(bmp);

            return bmp;
        }*/

        void tmr_Tick(object sender, EventArgs e)
        {
            tmri += 10;
            MainWindow.Instance.setProgessBarTransitionValue(tmri);
        }

        void wpc_AnimationFinished(object sender, EventArgs e)
        {
            tmr.Stop();
            tmri = 0;
            MainWindow.Instance.setProgessBarTransitionValue(0);
        }
    }
}
