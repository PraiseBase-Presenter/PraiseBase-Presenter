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
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.UI.Editor;

namespace PraiseBase.Presenter
{
    internal static class Editor
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // code to ensure that only one copy of the software is running.
            Mutex mutex;
            string strLoc = Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string sExeName = fileInfo.Name;
            string mutexName = "Global\\" + sExeName;
            try
            {
                mutex = Mutex.OpenExisting(mutexName);

                //since it hasn’t thrown an exception, then we already have one copy of the app open.

                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                String appTitle = ((AssemblyProductAttribute)attributes[0]).Product;

                MessageBox.Show(StringResources.ProgramInstanceAlreadyRunning, appTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            catch
            {
                //since we didn’t find a mutex with that name, create one
                mutex = new Mutex(true, mutexName);
            }

            Application.Run(new SongEditor(Settings.Default));

            GC.KeepAlive(mutex);
        }
    }
}