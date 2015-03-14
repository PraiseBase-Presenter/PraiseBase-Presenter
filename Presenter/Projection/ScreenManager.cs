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
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PraiseBase.Presenter.Projection
{
    class ScreenManager
    {
        /// <summary>
        /// Singleton variable
        /// </summary>
        private static ScreenManager _instance;

        /// <summary>
        /// Gets the singleton of this class (field alternative)
        /// </summary>
        public static ScreenManager Instance
        {
            get { return _instance ?? (_instance = new ScreenManager()); }
        }

        /// <summary>
        /// Available Projection screens
        /// </summary>
        public List<Screen> AvailableProjectionScreens { get; protected set; }

        public Screen MainScreen { get; protected set; }

        private int _selectedScreen = -1;
        public int SelectedScreenIndex
        {
            get 
            {
                return _selectedScreen;
            }
            set
            {
                if (value >= 0 && value < AvailableProjectionScreens.Count)
                {
                    _selectedScreen = value;
                }
                else if (AvailableProjectionScreens.Count > 0)
                {
                    _selectedScreen = 0;
                }
            } 
        }

        public Screen SelectedScreen 
        { 
            get 
            { 
                return AvailableProjectionScreens[SelectedScreenIndex];  
            } 
        }

        protected int ScannedScreensHash;
        public bool ScreensChangedSinceLastScan { get; protected set; }

        // Screen change detection event
        public delegate void ScreensChange(ScreensChangedEventArgs e);
        public event ScreensChange ScreensChanged;
        public class ScreensChangedEventArgs : EventArgs { }

        /// <summary>
        /// The constructor
        /// </summary>
        private ScreenManager()
        {
            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
        }

        /// <summary>
        /// Throws a ScreensChange event if screen configuration has been changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            // Use a delay of one second to give the screen api enough time to detect new resolution
            Timer tmr = new Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            if (ScreensChanged != null)
            {
                ScreensChanged(new ScreensChangedEventArgs { });
            }
        }

        /// <summary>
        /// Detect screen configuration
        /// </summary>
        /// <returns></returns>
        public bool detectScreens() 
        {
            AvailableProjectionScreens = new List<Screen>();

            Screen[] screenList = Screen.AllScreens;
            int hash = 0;
            foreach (Screen t in screenList)
            {
                if (!t.Primary)
                {
                    AvailableProjectionScreens.Add(t);
                    Console.WriteLine("Detected projection screen " + t.DeviceName + ", " + t.WorkingArea);
                }
                else
                {
                    MainScreen = t;
                    Console.WriteLine("Detected main screen " + t.DeviceName + ", " + t.WorkingArea);
                }
                hash += t.GetHashCode();
            }
            ScreensChangedSinceLastScan = (ScannedScreensHash != hash);
            ScannedScreensHash = hash;

            if (AvailableProjectionScreens.Count > 0) 
            {
                if (_selectedScreen < 0)
                {
                    _selectedScreen = 0;
                }
                else if (_selectedScreen > AvailableProjectionScreens.Count) 
                {
                    _selectedScreen = AvailableProjectionScreens.Count;
                }
                return true;
            }
            return false;
        }
    }
}
