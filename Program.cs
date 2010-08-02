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
using System.Windows.Forms;
using Pbp.Forms;
using Pbp.Properties;

namespace Pbp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			DateTime startTime = DateTime.Now;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			if (Settings.Instance.ShowLoadingScreen)
			{
				LoadingScreen ldg = new LoadingScreen();
				ldg.setLabel("PraiseBase Presenter wird gestartet...");
				ldg.Show();
				Application.DoEvents();

                if (Settings.Instance.DataDirectory == "")
                {
                    // Todo: check and create
                    Settings.Instance.DataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal).ToString() + System.IO.Path.DirectorySeparatorChar + Settings.Instance.DataDirDefaultName;
                    Settings.Instance.Save();
                }

				ldg.setLabel("Prüfe Miniaturbilder...");
				ImageManager.Instance.checkThumbs(ldg);

				ldg.setLabel("Lade Liederdatenbank...");
				SongManager.getInstance(ldg);

				ldg.setLabel("Suche Projektionsschirm...");
				projectionWindow.getInstance();

				ldg.setLabel("Initialisiere Programmoberfläche...");
				GC.Collect();
				ldg.Close();
				ldg.Dispose();
			}
			else
			{
				SongManager.getInstance();
				ImageManager.Instance.checkThumbs();
				projectionWindow.getInstance();
				GC.Collect();
			}
            
			Console.WriteLine("Loading took " + (DateTime.Now - startTime).TotalSeconds + " seconds!");

			Application.Run(MainWindow.getInstance());

        }
    }
}
