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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Persistence;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.UI;
using PraiseBase.Presenter.UI.Editor;
using PraiseBase.Presenter.Util;

namespace PraiseBase.Presenter.Forms
{
    public partial class SongEditor : LocalizableForm
    {
        static private SongEditor _instance;

        public string fileBoxInitialDir;
        public int fileOpenBoxFilterIndex;
        public int fileSaveBoxFilterIndex;

        private int childFormNumber = 0;

        private SongEditor()
        {
            InitializeComponent();

            this.Size = Settings.Default.EditorWindowSize;

            fileBoxInitialDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SongDir;
            fileOpenBoxFilterIndex = 0;
            fileSaveBoxFilterIndex = 0;
            this.WindowState = Settings.Default.EditorWindowState;

            foreach (var l in Program.AvailableLanguages)
            {
                ToolStripMenuItem selectLanguageToolStripMenuItem = new ToolStripMenuItem(l.DisplayName);
                selectLanguageToolStripMenuItem.Tag = l;
                selectLanguageToolStripMenuItem.Click += new EventHandler(selectLanguageToolStripMenuItem_Click);
                if (l.Name == System.Threading.Thread.CurrentThread.CurrentUICulture.Name)
                {
                    selectLanguageToolStripMenuItem.Checked = true;
                }
                this.spracheToolStripMenuItem.DropDownItems.Add(selectLanguageToolStripMenuItem);
            }

            base.registerChild(this);
        }

        void selectLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage((CultureInfo)((ToolStripMenuItem)sender).Tag);

            foreach (ToolStripMenuItem i in this.spracheToolStripMenuItem.DropDownItems)
            {
                i.Checked = ((CultureInfo)i.Tag == System.Threading.Thread.CurrentThread.CurrentUICulture);
            }
        }

        static public SongEditor getInstance()
        {
            if (_instance == null)
                _instance = new SongEditor();
            return _instance;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Song sng = createNewSong(Settings.Default);

            SongTemplateUtil.ApplyFormattingFromSettings(Settings.Default, sng);

            SongEditorChild childForm = createSongEditorChildForm(sng, null);

            childForm.Text = childForm.Song.Title + " " + ++childFormNumber;
        }

        private static Song createNewSong(Settings settings)
        {
            Song sng = new Song();
            sng.GUID = SongManager.Instance.GenerateGuid();
            sng.Title = settings.SongDefaultName;
            sng.Language = settings.SongDefaultLanguage;

            SongPart tmpPart = new SongPart();
            tmpPart.Caption = settings.SongPartDefaultName;

            SongSlide tmpSlide = new SongSlide();
            tmpSlide.Background = new ColorBackground(Settings.Default.ProjectionBackColor);
            tmpPart.Slides.Add(tmpSlide);
            sng.Parts.Add(tmpPart);

            return sng;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = fileBoxInitialDir;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Title = Properties.StringResources.OpenSong;

            openFileDialog.Filter = GetFileBoxFilter();
            openFileDialog.FilterIndex = fileOpenBoxFilterIndex;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                fileBoxInitialDir = Path.GetDirectoryName(FileName);
                fileOpenBoxFilterIndex = openFileDialog.FilterIndex;
                openSong(FileName);
            }
        }

        /// <summary>
        /// Returns the filter string used in open file dialogs
        /// </summary>
        /// <returns></returns>
        public string GetFileBoxFilter()
        {
            String exts = String.Empty;
            String fltr = String.Empty;
            foreach (var t in SongFilePluginFactory.GetPlugins())
            {
                if (t.IsWritingSupported())
                {
                    if (exts != String.Empty)
                    {
                        exts += ";";
                    }
                    exts += "*" + t.GetFileExtension();
                    if (fltr != string.Empty)
                    {
                        fltr += "|";
                    }
                    fltr += t.GetFileTypeDescription() + " (*" + t.GetFileExtension() + ")|*" + t.GetFileExtension();
                }
            }
            return "Alle Lieddateien (" + exts + ")|" + exts + "|" + fltr + "|Alle Dateien (*.*)|*.*";
        }

        public void openSong(string fileName)
        {
            for (int i = 0; i < MdiChildren.Count(); i++)
            {
                EditorChildMetaData md = (EditorChildMetaData)MdiChildren[i].Tag;
                if (md.Filename != String.Empty && 
                    String.Compare(
                    Path.GetFullPath(md.Filename).TrimEnd('\\'),
                    Path.GetFullPath(fileName).TrimEnd('\\'),
                    StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    MdiChildren[i].Show();
                    MdiChildren[i].Focus();
                    return;
                }
            }

            Song sng;
            Console.WriteLine("Loading song from file " + fileName);
            try
            {
                sng = SongFilePluginFactory.Create(fileName).Load(fileName);
                if (sng.GUID == Guid.Empty)
                {
                    var smGuid = SongManager.Instance.GetGUIDByPath(fileName);
                    if (smGuid != Guid.Empty)
                    {
                        sng.GUID = smGuid;
                    }
                    else
                    {
                        sng.GUID = SongManager.Instance.GenerateGuid();
                    }
                }
            }
            catch (NotImplementedException)
            {
                MessageBox.Show(Properties.StringResources.SongFormatNotSupported, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(Properties.StringResources.SongFileHasErrors + " (" + e.Message + ")!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            createSongEditorChildForm(sng, fileName);
        }

        private SongEditorChild createSongEditorChildForm(Song sng, String fileName)
        {
            SongEditorChild childForm = new SongEditorChild(sng);
            childForm.Tag = new EditorChildMetaData(fileName, sng.GetHashCode());
            childForm.MdiParent = this;
            childForm.FormClosing += childForm_FormClosing;
            childForm.Show();
            base.registerChild(childForm);
            setStatus(string.Format(Properties.StringResources.LoadedSong, sng.Title));

            return childForm;
        }

        void childForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SongEditorChild window = ((SongEditorChild)sender);

            String filename = ((EditorChildMetaData)window.Tag).Filename;

            if (((EditorChildMetaData)window.Tag).HashCode != window.Song.GetHashCode())
            {
                DialogResult dlg = MessageBox.Show(string.Format(Properties.StringResources.SaveChangesMadeToTheSong, window.Song.Title),
                    Properties.StringResources.SongEditor,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    save(window.Song, ((EditorChildMetaData)window.Tag).Filename);
                }
                else if (dlg == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            else if (filename != null && !File.Exists(filename))
            {
                saveAs(window.Song, ((EditorChildMetaData)window.Tag).Filename);
            }
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
            Settings.Default.EditorWindowSize = this.Size;
            Settings.Default.EditorWindowState = this.WindowState;

            //this.Hide();
            //e.Cancel = true;
        }

        private void saveChild(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                SongEditorChild window = ((SongEditorChild)ActiveMdiChild);
                if (save(window.Song, ((EditorChildMetaData)window.Tag).Filename))
                {
                    ((EditorChildMetaData)window.Tag).HashCode = window.Song.GetHashCode();
                }
            }
        }

        public bool save(Song sng, String songFilename)
        {
            Console.WriteLine(this.ActiveControl.Name);
            this.ValidateChildren();

            if (songFilename == null || songFilename == string.Empty)
            {
                return saveAs(sng, null);
            }
            else
            {
                try
                {
                    SongFilePluginFactory.Create(songFilename).Save(sng, songFilename);

                    setStatus(String.Format(Properties.StringResources.SongSavedAs, songFilename));

                    SongManager.Instance.ReloadSongByPath(songFilename);

                    return true;
                }
                catch (NotImplementedException)
                {
                    MessageBox.Show(Properties.StringResources.SongCannotBeSavedInThisFormat, Properties.StringResources.FormatNotSupported,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return saveAs(sng, songFilename);
                }
            }
        }

        private void saveChildAs(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                SongEditorChild window = ((SongEditorChild)ActiveMdiChild);
                if (saveAs(window.Song, null))
                {
                    ((EditorChildMetaData)window.Tag).HashCode = window.Song.GetHashCode();
                }
            }
        }
        
        public bool saveAs(Song sng, String songFilename)
        {
            if (sng.Title == PraiseBase.Presenter.Properties.Settings.Default.SongDefaultName)
            {
                if (MessageBox.Show(string.Format(Properties.StringResources.DoesTheSongReallyHaveTheDefaultTitle, sng.Title), Properties.StringResources.Attention,
                    MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    // TODO
                    //textBoxSongTitle.SelectAll();
                    //textBoxSongTitle.Focus();
                    return false;
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (songFilename != null)
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(songFilename);
            }
            else
            {
                saveFileDialog.InitialDirectory = fileBoxInitialDir;
            }
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.FileName = sng.Title;
            saveFileDialog.Filter = GetSaveFileBoxFilter();
            saveFileDialog.FilterIndex = fileSaveBoxFilterIndex;
            saveFileDialog.AddExtension = true;
            saveFileDialog.Title = Properties.StringResources.SaveSongAs;

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    CreateByTypeIndex(saveFileDialog.FilterIndex - 1).Save(sng, saveFileDialog.FileName);
                    fileSaveBoxFilterIndex = saveFileDialog.FilterIndex;
                    setStatus(string.Format(Properties.StringResources.SongSavedAs, saveFileDialog.FileName));

                    SongManager.Instance.ReloadSongByPath(saveFileDialog.FileName);
                    return true;
                }
                catch (NotImplementedException)
                {
                    MessageBox.Show(Properties.StringResources.SongCannotBeSavedInThisFormat, Properties.StringResources.SongEditor,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        public string GetSaveFileBoxFilter()
        {
            String fltr = String.Empty;
            foreach (ISongFilePlugin t in SongFilePluginFactory.GetWriterPlugins())
            {
                if (fltr != string.Empty)
                {
                    fltr += "|";
                }
                fltr += t.GetFileTypeDescription() + " (*" + t.GetFileExtension() + ")|*" + t.GetFileExtension();
            }
            return fltr;
        }

        public ISongFilePlugin CreateByTypeIndex(int index)
        {
            if (index >= 0 && index < SongFilePluginFactory.GetWriterPlugins().Count)
            {
                return SongFilePluginFactory.GetWriterPlugins().ToArray()[index];
            }
            throw new NotImplementedException();
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
            SongImporter dlg = new SongImporter(Settings.Default, ImportFormat.PraiseBox);
            dlg.ShowDialog(this);
        }

        private void EditorWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
            GC.Collect();
        }
    }
}