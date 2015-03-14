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
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using PraiseBase.Presenter.Manager;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.UI.Presenter;

namespace PraiseBase.Presenter
{
    internal static class Program
    {
        static public List<CultureInfo> AvailableLanguages = new List<CultureInfo>();

        static Program()
        {
            AvailableLanguages.Add(CultureInfo.CreateSpecificCulture("de-CH"));
            AvailableLanguages.Add(CultureInfo.CreateSpecificCulture("en-US"));
        }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(Settings.Default.SelectedCulture);

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

            // Check Data directory
            if (Settings.Default.DataDirectory == "")
            {
                Settings.Default.DataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + Path.DirectorySeparatorChar + Settings.Default.DataDirDefaultName;
                if (Directory.Exists(Settings.Default.DataDirectory))
                {
                    Directory.CreateDirectory(Settings.Default.DataDirectory);
                }
                Settings.Default.Save();
            }

            string songDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SongDir;
            SongManager songManager = new SongManager(songDir);

            if (Settings.Default.ShowLoadingScreen)
            {
                LoadingScreen ldg = new LoadingScreen(songManager);
                ldg.SetLabel("PraiseBase Presenter wird gestartet...");
                ldg.Show();

                ldg.SetLabel("Prüfe Miniaturbilder...");
                ImageManager.Instance.CheckThumbs();

                ldg.SetLabel("Lade Liederdatenbank...");
                songManager.Reload();

                GC.Collect();
                ldg.Close();
                ldg.Dispose();
            }
            else
            {
                ImageManager.Instance.CheckThumbs();
                songManager.Reload();
                GC.Collect();
            }

            Console.WriteLine(@"Loading took " + (DateTime.Now - startTime).TotalSeconds + @" seconds!");
            
            // Detect if program is called with a setlist file as argument
            string setlistFile = null;
            if (args.Length == 1)
            {
                setlistFile = args[0];
            }

            MainWindow mw = new MainWindow(songManager, setlistFile);
            Application.Run(mw);
            GC.KeepAlive(mutex);
        }
    }
}