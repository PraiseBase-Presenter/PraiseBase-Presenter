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
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Pbp.Properties;
using Pbp.IO;

namespace Pbp.Forms
{
    public partial class EditorWindow : Form
    {
        static private EditorWindow _instance;

        public string fileBoxInitialDir;
        public int fileBoxFilterIndex;

        private int childFormNumber = 0;

        private EditorWindow()
        {
            InitializeComponent();
            fileBoxInitialDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SongDir;
            fileBoxFilterIndex = 0;
            this.WindowState = Settings.Default.EditorWindowState;
            //this.Text += " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        static public EditorWindow getInstance()
        {
            if (_instance == null)
                _instance = new EditorWindow();
            return _instance;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            EditorChild childForm = new EditorChild(null);
            childForm.MdiParent = this;
            childForm.Tag = "";

            childForm.Text = childForm.sng.Title + ++childFormNumber;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = fileBoxInitialDir;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Lied öffnen";

            openFileDialog.Filter = SongFileReaderFactory.Instance.GetFileBoxFilter();
            openFileDialog.FilterIndex = fileBoxFilterIndex;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                fileBoxInitialDir = Path.GetDirectoryName(FileName);
                fileBoxFilterIndex = openFileDialog.FilterIndex;
                openSong(FileName);
            }
        }

        public void openSong(string fileName)
        {
            for (int i = 0; i < MdiChildren.Count(); i++)
            {
                if (MdiChildren[i].Tag.ToString() == fileName)
                {
                    MdiChildren[i].Show();
                    MdiChildren[i].Focus();
                    return;
                }
            }

            EditorChild childForm = new EditorChild(fileName);
            childForm.Tag = fileName;
            childForm.MdiParent = this;
            if (childForm.valid)
                childForm.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                if (((EditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
                {
                    ((TextBox)((EditorChild)ActiveMdiChild).ActiveControl).Cut();
                }
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                if (((EditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
                {
                    ((TextBox)((EditorChild)ActiveMdiChild).ActiveControl).Copy();
                }
            }
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                if (((EditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
                {
                    ((TextBox)((EditorChild)ActiveMdiChild).ActiveControl).Paste();
                }
            }
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow ab = new AboutWindow();
            ab.ShowDialog(this);
        }

        private void webToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Settings.Default.Weburl);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsWindow stWnd = new SettingsWindow();
            stWnd.ShowDialog(this);
        }

        private void EditorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.EditorWindowState = this.WindowState;

            //this.Hide();
            //e.Cancel = true;
        }

        private void saveChild(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ((EditorChild)ActiveMdiChild).save();
            }
        }

        private void saveChildAs(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ((EditorChild)ActiveMdiChild).saveAs();
            }
        }

        public void setStatus(string text)
        {
            toolStripStatusLabel1.Text = text;
            Timer statusTimer = new Timer();
            statusTimer.Interval = 2000;
            statusTimer.Tick += new EventHandler(statusTimer_Tick);
            statusTimer.Start();
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = string.Empty;
            ((Timer)sender).Stop();
            ((Timer)sender).Dispose();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                if (((EditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
                {
                    ((TextBox)((EditorChild)ActiveMdiChild).ActiveControl).SelectAll();
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                if (((EditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
                {
                    ((TextBox)((EditorChild)ActiveMdiChild).ActiveControl).Undo();
                }
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                if (((EditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
                {
                    ((TextBox)((EditorChild)ActiveMdiChild).ActiveControl).ClearUndo();
                }
            }
        }

        private void liedSchliessenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ((EditorChild)ActiveMdiChild).Close();
            }
        }

        private void allesSchliessenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MdiChildren.Count() > 0)
            {
                foreach (EditorChild c in MdiChildren)
                {
                    ((EditorChild)c).Close();
                }
            }
        }

        private void EditorWindow_Load(object sender, EventArgs e)
        {
        }

        private void datenverzeichnisAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Settings.Default.DataDirectory);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Settings.Default.DataDirectory);
        }

        private void fehlerMeldenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Settings.Default.BugReportUrl);
        }

        private void praiseBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongImporter dlg = new SongImporter(SongImporter.ImportFormat.PraiseBox);
            dlg.ShowDialog(this);
        }

        private void EditorWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
            GC.Collect();
        }
    }
}