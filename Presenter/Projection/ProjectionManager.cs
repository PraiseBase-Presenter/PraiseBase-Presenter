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

using PraiseBase.Presenter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace PraiseBase.Presenter.Projection
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

        protected List<ProjectionWindow> ProjectionWindows;

        protected ProjectionState CurrentState = ProjectionState.Disabled;

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
            ScreenManager.Instance.ScreensChanged += Instance_ScreensChanged;
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
            ScreenManager.Instance.DetectScreens();

            // Check if projection windows have not been initialized or screens have changed
            if (ProjectionWindows == null || ScreenManager.Instance.ScreensChangedSinceLastScan)
            {
                // First use
                if (ProjectionWindows == null)
                {
                    ProjectionWindows = new List<ProjectionWindow>();
                    if (ScreenManager.Instance.AvailableProjectionScreens.Count > 0)
                    {
                        foreach (var s in ScreenManager.Instance.AvailableProjectionScreens)
                        {
                            ProjectionWindow pw = new ProjectionWindow(s);
                            ProjectionWindows.Add(pw);
                        }
                        return true;
                    }
                    else
                    {
                        ProjectionWindow pw = new ProjectionWindow(ScreenManager.Instance.MainScreen);
                        ProjectionWindows.Add(pw);
                        return false;
                    }
                }
                // Projection windows have already been initialized once
                else
                {
                    // If any projection screens available
                    if (ScreenManager.Instance.AvailableProjectionScreens.Count > 0)
                    {
                        for (int i = 0; i < Math.Max(ScreenManager.Instance.AvailableProjectionScreens.Count, ProjectionWindows.Count); i++)
                        {
                            // Move existing window to screen and update it
                            if (i < ProjectionWindows.Count && i < ScreenManager.Instance.AvailableProjectionScreens.Count)
                            {
                                ProjectionWindows[i].AssignToScreen(ScreenManager.Instance.AvailableProjectionScreens[i]);
                            }
                            // Create new window if a screen has been added
                            else if (i < ScreenManager.Instance.AvailableProjectionScreens.Count)
                            {
                                ProjectionWindow pw = new ProjectionWindow(ScreenManager.Instance.AvailableProjectionScreens[i]);
                                ProjectionWindows.Add(pw);
                            }
                            // Destroy window if a screen has been removed
                            else
                            {
                                ProjectionWindows[i].Close();
                                ProjectionWindows.RemoveAt(i);
                            }
                        }
                        return true;
                    }
                    // Only use main screen
                    else
                    {
                        for (int i = 0; i < ProjectionWindows.Count; i++)
                        {
                            // Projection window on main screen
                            if (i == 0)
                            {
                                ProjectionWindows[0].AssignToScreen(ScreenManager.Instance.MainScreen);
                            }
                            // Destroy the rest
                            else
                            {
                                ProjectionWindows[i].Close();
                                ProjectionWindows.RemoveAt(i);
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
            foreach (var pw in ProjectionWindows)
            {
                if (CurrentState != ProjectionState.Disabled)
                {
                    pw.Hide();
                }
            }
            CurrentState = ProjectionState.Disabled;
        }

        /// <summary>
        /// Enable blackout (show the window is it is not shown already)
        /// </summary>
        public void ShowBlackout()
        {
            foreach (var pw in ProjectionWindows)
            {
                if (CurrentState == ProjectionState.Active)
                {
                    pw.SetBlackout(true, true);
                }
                else if (CurrentState == ProjectionState.Disabled)
                {
                    pw.SetBlackout(true, false);
                    pw.Show();
                }
            }
            CurrentState = ProjectionState.Blackout;
        }

        /// <summary>
        /// Show the projection window and disable blackout
        /// </summary>
        public void ShowProjectionWindow()
        {
            foreach (var pw in ProjectionWindows)
            {
                if (CurrentState == ProjectionState.Disabled)
                {
                    pw.SetBlackout(false, false);
                    pw.Show();
                }
                else if (CurrentState == ProjectionState.Blackout)
                {
                    pw.SetBlackout(false, true);
                }
            }
            CurrentState = ProjectionState.Active;
        }

        /// <summary>
        /// Display a layer on all windows
        /// </summary>
        /// <param name="layerNum"></param>
        /// <param name="layerContent"></param>
        /// <param name="fadetime"></param>
        private void DisplayLayer(int layerNum, BaseLayer layerContent, int fadetime)
        {
            if (ProjectionWindows.Count > 0)
            {
                foreach (var pw in ProjectionWindows)
                {
                    pw.DisplayLayer(layerNum, layerContent, fadetime);
                }
                ProjectionChanged?.Invoke(this, new ProjectionChangedEventArgs { Image = ProjectionWindows[0].GetPreviewImage() });
            }
        }

        public void DisplayImage(ImageLayer layerContent)
        {
            DisplayImage(layerContent, Settings.Default.ProjectionFadeTime);
        }

        public void DisplayImage(ImageLayer layerContent, int fadetime)
        {
            DisplayLayer(1, layerContent, fadetime);
        }

        public void DisplayText(TextLayer layerContent)
        {
            DisplayText(layerContent, Settings.Default.ProjectionFadeTime);
        }

        public void DisplayText(TextLayer layerContent, int fadetime)
        {
            DisplayLayer(2, layerContent, fadetime);
        }

        /// <summary>
        /// Hide a layer on all windows
        /// </summary>
        /// <param name="layerNum"></param>
        /// <param name="fadetime"></param>
        private void HideLayer(int layerNum, int fadetime)
        {
            if (ProjectionWindows.Count > 0)
            {
                foreach (var pw in ProjectionWindows)
                {
                    pw.HideLayer(layerNum, fadetime);
                }
                ProjectionChanged?.Invoke(this, new ProjectionChangedEventArgs { Image = ProjectionWindows[0].GetPreviewImage() });
            }
        }

        public void HideImage()
        {
            HideImage(Settings.Default.ProjectionFadeTime);
        }

        public void HideImage(int fadetime)
        {
            HideLayer(1, fadetime);
        }

        public void HideText()
        {
            HideText(Settings.Default.ProjectionFadeTime);
        }

        public void HideText(int fadetime)
        {
            HideLayer(2, fadetime);
        }
    }
}
