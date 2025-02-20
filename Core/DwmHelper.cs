using System;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PraiseBase.Presenter
{
    public static class DwmHelper
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                     DWMWINDOWATTRIBUTE attribute,
                                                     ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                     uint cbAttribute);

        [DllImport("user32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("user32.dll")]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        public static void SetWindowRoundCornerPreference(IntPtr hwnd, DWM_WINDOW_CORNER_PREFERENCE preference)
        {
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            DwmSetWindowAttribute(hwnd, attribute, ref preference, sizeof(uint));
        }

        public static void SetCorner(Form form, DWM_WINDOW_CORNER_PREFERENCE preference)
        {
            try
            {
                if (IsWindows11OrGreater())
                {
                    SetWindowRoundCornerPreference(form.Handle, preference);
                }
                else
                {
                    SetRoundCornersForOlderWindows(form);
                }
            }
            catch (Exception ex)
            {
                log.Error($"Failed to set window corner preference: {ex.Message}", ex);
            }
        }

        private static bool IsWindows11OrGreater()
        {
            Version currentVersion = Environment.OSVersion.Version;
            return currentVersion.Major == 10 && currentVersion.Build >= 22000;
        }

        private static void SetRoundCornersForOlderWindows(Form form)
        {
            int radius = 20;
            IntPtr hRgn = CreateRoundRectRgn(0, 0, form.Width, form.Height, radius, radius);
            SetWindowRgn(form.Handle, hRgn, true);
        }
    }
}
