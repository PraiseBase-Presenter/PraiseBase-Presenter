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
using System.Windows.Forms;

namespace Pbp.Manager
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

        protected int scannedScreensHash = 0;
        public bool ScreensChangedSinceLastScan { get; protected set; }

        // Screen change detect timner and event
        Timer screenNumberSupervisorTimer;
        int recordedNumberOfScreens;
        public delegate void ScreensChange(ScreensChangedEventArgs e);
        public event ScreensChange ScreensChanged;
        public class ScreensChangedEventArgs : EventArgs { }

        /// <summary>
        /// The constructor
        /// </summary>
        private ScreenManager()
        {
            screenNumberSupervisorTimer = new Timer();
            screenNumberSupervisorTimer.Interval = 1000;
            screenNumberSupervisorTimer.Start();
            screenNumberSupervisorTimer.Tick += new EventHandler(screenNumberSupervisorTimer_Tick);
        }

        void screenNumberSupervisorTimer_Tick(object sender, EventArgs e)
        {
            if (recordedNumberOfScreens != Screen.AllScreens.Count())
            {
                if (ScreensChanged != null)
                {
                    ScreensChanged(new ScreensChangedEventArgs { });
                }
            }
            recordedNumberOfScreens = Screen.AllScreens.Count();
        }

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
            ScreensChangedSinceLastScan = (scannedScreensHash != hash);
            scannedScreensHash = hash;

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
