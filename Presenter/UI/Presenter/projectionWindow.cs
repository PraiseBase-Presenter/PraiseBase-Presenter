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
using System.Collections.Generic;

namespace Pbp.Forms
{
    public partial class ProjectionWindow : Form
    {
        protected Dictionary<int, BaseLayer> currentLayers;
        protected Dictionary<int, Image> currentLayerImages;

        public ProjectionWindow(Screen projScreen)
        {
            InitializeComponent();
            currentLayers = new Dictionary<int, BaseLayer>();
            currentLayerImages = new Dictionary<int, Image>();

            AssignToScreen(projScreen);

            var wpc = new WpfProjectionControl
            {
                ProjectionBackgroundColor = Settings.Default.ProjectionBackColor
            };
            projectionControlHost.Child = wpc;
        }

        /// <summary>
        /// Assigns the window to a screen's coordinates
        /// </summary>
        /// <param name="projScreen"></param>
        public void AssignToScreen(Screen projScreen)
        {
            Location = projScreen.WorkingArea.Location;
            Size = new Size(projScreen.WorkingArea.Width, projScreen.WorkingArea.Height);

            if (currentLayers.Count > 0)
            {
                RedrawLayers();
            }
        }

        /// <summary>
        /// Set to blackout
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="animate"></param>
        public void SetBlackout(bool enable, bool animate)
        {
            ((WpfProjectionControl)(projectionControlHost.Child)).BlackOut(enable, (animate ? Settings.Default.ProjectionFadeTime : 0));
        }

        /// <summary>
        /// Display text layer
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="tl"></param>
        public void DisplayLayer(int layerNum, BaseLayer layerContents)
        {
            DisplayLayer(layerNum, layerContents, Settings.Default.ProjectionFadeTime);
        }

        /// <summary>
        /// Display text layer with transition
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="tl"></param>
        /// <param name="fadetime"></param>
        public void DisplayLayer(int layerNum, BaseLayer layerContents, int fadetime)
        {
            var bmp = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(bmp);
            layerContents.writeOut(gr);

            if (layerNum == 2)
            {
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionText(bmp, fadetime);
            }
            else
            {
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionImage(bmp, fadetime);
            }
            currentLayers[layerNum] = layerContents;
            currentLayerImages[layerNum] = bmp;
        }


        /// <summary>
        /// Hide layer
        /// </summary>
        /// <param name="layer"></param>
        public void HideLayer(int layer)
        {
            HideLayer(layer, Settings.Default.ProjectionFadeTime);
        }

        /// <summary>
        /// Hide layer with transition
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="fadetime"></param>
        public void HideLayer(int layerNum, int fadetime)
        {
            var bmp = new Bitmap(Width, Height);

            if (layerNum == 2)
            {
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionText(bmp, fadetime);
            }
            else if (layerNum == 1)
            {
                ((WpfProjectionControl)(projectionControlHost.Child)).SetProjectionImage(bmp, fadetime);
            }

            currentLayerImages[layerNum] = bmp;            
        }

        /// <summary>
        /// Redraw all layers (e.g. after screen change)
        /// </summary>
        public void RedrawLayers()
        {
            Dictionary<int, BaseLayer> tempDict = new Dictionary<int, BaseLayer>();
            foreach (var kvp in currentLayers)
            {
                tempDict.Add(kvp.Key, kvp.Value);
            }
            foreach (var kvp in tempDict)
            {
                DisplayLayer(kvp.Key, kvp.Value, 0);
            }
        }

        /// <summary>
        /// Create preview image
        /// </summary>
        /// <returns></returns>
        public Image GetPreviewImage()
        {
            Image frame = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(frame);
            
            int usedLayers = 0;
            int i = 0;
            while (true)
            {
                if (currentLayerImages.ContainsKey(i))
                {
                    gr.DrawImage(currentLayerImages[i], new Rectangle(0, 0, frame.Width, frame.Height), new Rectangle(0, 0, frame.Width, frame.Height), GraphicsUnit.Pixel);
                    usedLayers++;
                }
                if (usedLayers >= currentLayerImages.Count)
                {
                    break;
                }
                i++;
            }
            return frame;
        }
    }
}