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
