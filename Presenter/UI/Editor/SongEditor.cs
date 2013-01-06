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
    public partial class SongEditor : Form
    {
        static private SongEditor _instance;

        public string fileBoxInitialDir;
        public int fileOpenBoxFilterIndex;
        public int fileSaveBoxFilterIndex;

        private int childFormNumber = 0;

        private SongEditor()
        {
            InitializeComponent();
            fileBoxInitialDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SongDir;
            fileOpenBoxFilterIndex = 0;
            fileSaveBoxFilterIndex = 0;
            this.WindowState = Settings.Default.EditorWindowState;
            //this.Text += " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        static public SongEditor getInstance()
        {
            if (_instance == null)
                _instance = new SongEditor();
            return _instance;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            SongEditorChild childForm = new SongEditorChild(null);
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
            openFileDialog.FilterIndex = fileOpenBoxFilterIndex;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                fileBoxInitialDir = Path.GetDirectoryName(FileName);
                fileOpenBoxFilterIndex = openFileDialog.FilterIndex;
                openSong(FileName);
            }
        }

        public void openSong(string fileName)
        {
            for (int i = 0; i < MdiChildren.Count(); i++)
            {
                if (String.Compare(
                    Path.GetFullPath(MdiChildren[i].Tag.ToString()).TrimEnd('\\'),
                    Path.GetFullPath(fileName).TrimEnd('\\'),
                    StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    MdiChildren[i].Show();
                    MdiChildren[i].Focus();
                    return;
                }
            }

            SongEditorChild childForm = new SongEditorChild(fileName);
            childForm.Tag = fileName;
            childForm.MdiParent = this;
            if (childForm.valid)
                childForm.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DoCopy(Control control)
        {
            if (control is ContainerControl)
                DoCopy(((ContainerControl)control).ActiveControl);
            else if (control is TextBox)
                ((TextBox)control).Copy();
            else if (control is RichTextBox)
                ((RichTextBox)control).Copy();
            else
                throw new NotSupportedException("The selected control can't copy!");
        }

        private void DoCut(Control control)
        {
            if (control is ContainerControl)
                DoCut(((ContainerControl)control).ActiveControl);
            else if (control is TextBox)
                ((TextBox)control).Cut();
            else if (control is RichTextBox)
                ((RichTextBox)control).Cut();
            else
                throw new NotSupportedException("The selected control can't cut!");
        }

        private void DoPaste(Control control)
        {
            if (control is ContainerControl)
                DoPaste(((ContainerControl)control).ActiveControl);
            else if (control is TextBox)
                ((TextBox)control).Paste();
            else if (control is RichTextBox)
                ((RichTextBox)control).Paste();
            else
                throw new NotSupportedException("The selected control can't paste!");
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                DoCut(((SongEditorChild)ActiveMdiChild).ActiveControl);
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                DoCopy(((SongEditorChild)ActiveMdiChild).ActiveControl);
            }
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                DoPaste(((SongEditorChild)ActiveMdiChild).ActiveControl);
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
            AboutDialog ab = new AboutDialog();
            ab.ShowDialog(this);
        }

        private void webToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Settings.Default.Weburl);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramSettingsDialog stWnd = new ProgramSettingsDialog();
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
                ((SongEditorChild)ActiveMdiChild).save();
            }
        }

        private void saveChildAs(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ((SongEditorChild)ActiveMdiChild).saveAs();
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
                if (((SongEditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
                {
                    ((TextBox)((SongEditorChild)ActiveMdiChild).ActiveControl).SelectAll();
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                if (((SongEditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
                {
                    ((TextBox)((SongEditorChild)ActiveMdiChild).ActiveControl).Undo();
                }
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                if (((SongEditorChild)ActiveMdiChild).ActiveControl.GetType() == typeof(TextBox))
                {
                    ((TextBox)((SongEditorChild)ActiveMdiChild).ActiveControl).ClearUndo();
                }
            }
        }

        private void liedSchliessenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ((SongEditorChild)ActiveMdiChild).Close();
            }
        }

        private void allesSchliessenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MdiChildren.Count() > 0)
            {
                foreach (SongEditorChild c in MdiChildren)
                {
                    ((SongEditorChild)c).Close();
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