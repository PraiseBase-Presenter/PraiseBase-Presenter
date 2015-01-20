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
using System.Windows.Forms;
using System.Drawing;

namespace PraiseBase.Presenter.Manager
{
    class ProjectionManager
    {
        /// <summary>
        /// Singleton variable
        /// </summary>
        private static ProjectionManager _instance;

        /// <summary>
        /// Gets the singleton of this class (field alternative)
        /// </summary>
        public static ProjectionManager Instance
        {
            get { return _instance ?? (_instance = new ProjectionManager()); }
        }

        protected List<PraiseBase.Presenter.Forms.ProjectionWindow> projectionWindows;

        protected ProjectionState currentState = ProjectionState.Disabled;

        protected enum ProjectionState
        {
            Disabled,
            Blackout,
            Active
        }

        #region Delegates

        public delegate void ProjectionChange(object sender, ProjectionChangedEventArgs e);

        public class ProjectionChangedEventArgs : EventArgs
        {
            public Image Image { get; set; }
        }
        public event ProjectionChange ProjectionChanged;

        #endregion Delegates

        /// <summary>
        /// The constructor
        /// </summary>
        private ProjectionManager()
        {
            InitializeWindows();
            ScreenManager.Instance.ScreensChanged += new ScreenManager.ScreensChange(Instance_ScreensChanged);
        }

        /// <summary>
        /// If the screen configuration is changed, initialize the windows again
        /// </summary>
        /// <param name="e"></param>
        void Instance_ScreensChanged(ScreenManager.ScreensChangedEventArgs e)
        {
            InitializeWindows();
        }

        /// <summary>
        /// Initialize projection windows
        /// </summary>
        /// <returns>True if any projection windows have been found and initialized, false if main screen is used for projection</returns>
        public bool InitializeWindows()
        {
            ScreenManager.Instance.detectScreens();

            // Check if projection windows have not been initialized or screens have changed
            if (projectionWindows == null || ScreenManager.Instance.ScreensChangedSinceLastScan)
            {
                // First use
                if (projectionWindows == null)
                {
                    projectionWindows = new List<Forms.ProjectionWindow>();
                    if (ScreenManager.Instance.AvailableProjectionScreens.Count > 0)
                    {
                        foreach (var s in ScreenManager.Instance.AvailableProjectionScreens)
                        {
                            Forms.ProjectionWindow pw = new Forms.ProjectionWindow(s);
                            projectionWindows.Add(pw);
                        }
                        return true;
                    }
                    else
                    {
                        Forms.ProjectionWindow pw = new Forms.ProjectionWindow(ScreenManager.Instance.MainScreen);
                        projectionWindows.Add(pw);
                        return false;
                    }
                }
                // Projection windows have already been initialized once
                else
                {
                    // If any projection screens available
                    if (ScreenManager.Instance.AvailableProjectionScreens.Count > 0)
                    {
                        for (int i = 0; i < Math.Max(ScreenManager.Instance.AvailableProjectionScreens.Count, projectionWindows.Count); i++)
                        {
                            // Move existing window to screen and update it
                            if (i < projectionWindows.Count && i < ScreenManager.Instance.AvailableProjectionScreens.Count)
                            {
                                projectionWindows[i].AssignToScreen(ScreenManager.Instance.AvailableProjectionScreens[i]);
                            }
                            // Create new window if a screen has been added
                            else if (i < ScreenManager.Instance.AvailableProjectionScreens.Count)
                            {
                                Forms.ProjectionWindow pw = new Forms.ProjectionWindow(ScreenManager.Instance.AvailableProjectionScreens[i]);
                                projectionWindows.Add(pw);
                            }
                            // Destroy window if a screen has been removed
                            else
                            {
                                projectionWindows[i].Close();
                                projectionWindows.RemoveAt(i);
                            }
                        }
                        return true;
                    }
                    // Only use main screen
                    else
                    {
                        for (int i = 0; i < projectionWindows.Count; i++)
                        {
                            // Projection window on main screen
                            if (i == 0)
                            {
                                projectionWindows[0].AssignToScreen(ScreenManager.Instance.MainScreen);
                            }
                            // Destroy the rest
                            else
                            {
                                projectionWindows[i].Close();
                                projectionWindows.RemoveAt(i);
                            }
                        }
                        return false;
                    }
                }
            }
            return (ScreenManager.Instance.AvailableProjectionScreens.Count > 0);
        }

        /// <summary>
        /// Hide all projection windows
        /// </summary>
        public void HideProjectionWindow() 
        {
            foreach (var pw in projectionWindows)
            {
                if (currentState != ProjectionState.Disabled)
                {
                    pw.Hide();
                }
            }
            currentState = ProjectionState.Disabled;
        }

        /// <summary>
        /// Enable blackout (show the window is it is not shown already)
        /// </summary>
        public void ShowBlackout()
        {
            foreach (var pw in projectionWindows)
            {
                if (currentState == ProjectionState.Active)
                {
                    pw.SetBlackout(true, true);
                }
                else if (currentState == ProjectionState.Disabled)
                {
                    pw.SetBlackout(true, false);
                    pw.Show();
                }
            }
            currentState = ProjectionState.Blackout;
        }

        /// <summary>
        /// Show the projection window and disable blackout
        /// </summary>
        public void ShowProjectionWindow()
        {
            foreach (var pw in projectionWindows)
            {
                if (currentState == ProjectionState.Disabled)
                {
                    pw.SetBlackout(false, false);
                    pw.Show();
                }
                else if (currentState == ProjectionState.Blackout)
                {
                    pw.SetBlackout(false, true);
                }
            }
            currentState = ProjectionState.Active;
        }

        /// <summary>
        /// Display a layer on all windows
        /// </summary>
        /// <param name="layerNum"></param>
        /// <param name="layerContent"></param>
        public void DisplayLayer(int layerNum, BaseLayer layerContent)
        {
            if (projectionWindows.Count > 0)
            {
                foreach (var pw in projectionWindows)
                {
                    pw.DisplayLayer(layerNum, layerContent);
                }
                if (ProjectionChanged != null)
                {
                    ProjectionChanged(this, new ProjectionChangedEventArgs { Image = projectionWindows[0].GetPreviewImage() });
                }
            }
        }

        /// <summary>
        /// Display a layer on all windows
        /// </summary>
        /// <param name="layerNum"></param>
        /// <param name="layerContent"></param>
        /// <param name="fadetime"></param>
        public void DisplayLayer(int layerNum, BaseLayer layerContent, int fadetime)
        {
            if (projectionWindows.Count > 0)
            {
                foreach (var pw in projectionWindows)
                {
                    pw.DisplayLayer(layerNum, layerContent, fadetime);
                }
                if (ProjectionChanged != null)
                {
                    ProjectionChanged(this, new ProjectionChangedEventArgs { Image = projectionWindows[0].GetPreviewImage() });
                }
            }
        }

        /// <summary>
        /// Hide a layer on all windows
        /// </summary>
        /// <param name="layerNum"></param>
        public void HideLayer(int layerNum)
        {
            if (projectionWindows.Count > 0)
            {
                foreach (var pw in projectionWindows)
                {
                    pw.HideLayer(layerNum);
                }
                if (ProjectionChanged != null)
                {
                    ProjectionChanged(this, new ProjectionChangedEventArgs { Image = projectionWindows[0].GetPreviewImage() });
                }
            }
        }

        /// <summary>
        /// Hide a layer on all windows
        /// </summary>
        /// <param name="layerNum"></param>
        /// <param name="fadetime"></param>
        public void HideLayer(int layerNum, int fadetime)
        {
            if (projectionWindows.Count > 0)
            {
                foreach (var pw in projectionWindows)
                {
                    pw.HideLayer(layerNum, fadetime);
                }
                if (ProjectionChanged != null)
                {
                    ProjectionChanged(this, new ProjectionChangedEventArgs { Image = projectionWindows[0].GetPreviewImage() });
                }
            }
        }
    }
}
