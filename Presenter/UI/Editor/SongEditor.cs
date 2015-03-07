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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Persistence;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.UI;
using PraiseBase.Presenter.UI.Editor;
using PraiseBase.Presenter.Util;
using Timer = System.Windows.Forms.Timer;

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
                if (l.Name == Thread.CurrentThread.CurrentUICulture.Name)
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
                i.Checked = ((CultureInfo)i.Tag == Thread.CurrentThread.CurrentUICulture);
            }
        }

        static public SongEditor GetInstance()
        {
            if (_instance == null)
                _instance = new SongEditor();
            return _instance;
        }

        /// <summary>
        /// Event handler for creating a new file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowNewForm(object sender, EventArgs e)
        {
            Song sng = CreateNewSong(Settings.Default);

            SongTemplateUtil.ApplyFormattingFromSettings(Settings.Default, sng);

            SongEditorChild childForm = CreateSongEditorChildForm(sng, null);

            childForm.Text = childForm.Song.Title + " " + ++childFormNumber;
        }

        /// <summary>
        /// Event handler for opening an existing file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = fileBoxInitialDir;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Title = StringResources.OpenSong;

            openFileDialog.Filter = GetOpenFileBoxFilter();
            openFileDialog.FilterIndex = fileOpenBoxFilterIndex;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                fileBoxInitialDir = Path.GetDirectoryName(fileName);
                fileOpenBoxFilterIndex = openFileDialog.FilterIndex;
                OpenSong(fileName);
            }
        }

        /// <summary>
        /// Opens a new song in a song editor child window
        /// </summary>
        /// <param name="fileName"></param>
        public void OpenSong(string fileName)
        {
            for (int i = 0; i < MdiChildren.Count(); i++)
            {
                EditorChildMetaData md = (EditorChildMetaData)MdiChildren[i].Tag;
                if (!string.IsNullOrEmpty(md.Filename) && 
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
            Console.WriteLine(@"Loading song from file " + fileName);
            try
            {
                sng = SongFilePluginFactory.Create(fileName).Load(fileName);
                if (sng.GUID == Guid.Empty)
                {
                    var smGuid = SongManager.Instance.GetGUIDByPath(fileName);
                    sng.GUID = smGuid != Guid.Empty ? smGuid : SongManager.Instance.GenerateGuid();
                }
            }
            catch (NotImplementedException)
            {
                MessageBox.Show(StringResources.SongFormatNotSupported, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(StringResources.SongFileHasErrors + " (" + e.Message + ")!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CreateSongEditorChildForm(sng, fileName);
        }

        /// <summary>
        /// Creates a song editor child form with the given song and file name
        /// </summary>
        /// <param name="sng">Song</param>
        /// <param name="fileName">File name, may be null</param>
        /// <returns></returns>
        private SongEditorChild CreateSongEditorChildForm(Song sng, String fileName)
        {
            int hashCode = sng.GetHashCode();
            SongEditorChild childForm = new SongEditorChild(sng)
            {
                Tag = new EditorChildMetaData(fileName, hashCode),
                MdiParent = this
            };
            childForm.FormClosing += childForm_FormClosing;
            childForm.Show();
            base.registerChild(childForm);
            SetStatus(string.Format(StringResources.LoadedSong, sng.Title));

            return childForm;
        }

        private void SaveChild(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                SongEditorChild window = ((SongEditorChild)ActiveMdiChild);
                if (Save(window.Song, ((EditorChildMetaData)window.Tag).Filename))
                {
                    int hashCode = window.Song.GetHashCode();
                    ((EditorChildMetaData)window.Tag).HashCode = hashCode;
                }
            }
        }

        private void SaveChildAs(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                SongEditorChild window = ((SongEditorChild)ActiveMdiChild);
                if (SaveAs(window.Song, null))
                {
                    int hashCode = window.Song.GetHashCode();
                    ((EditorChildMetaData)window.Tag).HashCode = hashCode;
                }
            }
        }

        private bool Save(Song sng, String songFilename)
        {
            ValidateChildren();

            if (string.IsNullOrEmpty(songFilename))
            {
                return SaveAs(sng, null);
            }
            try
            {
                SongFilePluginFactory.Create(songFilename).Save(sng, songFilename);

                SetStatus(String.Format(StringResources.SongSavedAs, songFilename));

                SongManager.Instance.ReloadSongByPath(songFilename);

                return true;
            }
            catch (NotImplementedException)
            {
                MessageBox.Show(StringResources.SongCannotBeSavedInThisFormat, StringResources.FormatNotSupported,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return SaveAs(sng, songFilename);
            }
        }

        private bool SaveAs(Song sng, String songFilename)
        {
            if (sng.Title == Settings.Default.SongDefaultName)
            {
                if (MessageBox.Show(string.Format(StringResources.DoesTheSongReallyHaveTheDefaultTitle, sng.Title), StringResources.Attention,
                    MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    // TODO
                    //textBoxSongTitle.SelectAll();
                    //textBoxSongTitle.Focus();
                    return false;
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = songFilename != null
                    ? Path.GetDirectoryName(songFilename)
                    : fileBoxInitialDir,
                CheckPathExists = true,
                FileName = sng.Title,
                Filter = GetSaveFileBoxFilter(),
                FilterIndex = fileSaveBoxFilterIndex,
                AddExtension = true,
                Title = StringResources.SaveSongAs
            };

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    string selectedFileName = saveFileDialog.FileName;
                    CreateByTypeIndex(saveFileDialog.FilterIndex - 1).Save(sng, selectedFileName);
                    fileSaveBoxFilterIndex = saveFileDialog.FilterIndex;
                    SetStatus(string.Format(StringResources.SongSavedAs, selectedFileName));

                    SongManager.Instance.ReloadSongByPath(selectedFileName);
                    return true;
                }
                catch (NotImplementedException)
                {
                    MessageBox.Show(StringResources.SongCannotBeSavedInThisFormat, StringResources.SongEditor,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        /// <summary>
        /// Handles saving of changed data when closing a song window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void childForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SongEditorChild window = ((SongEditorChild)sender);

            String filename = ((EditorChildMetaData)window.Tag).Filename;

            int storedHashCode = ((EditorChildMetaData)window.Tag).HashCode;
            int songHashCode = window.Song.GetHashCode();
            if (storedHashCode != songHashCode)
            {
                DialogResult dlg = MessageBox.Show(string.Format(StringResources.SaveChangesMadeToTheSong, window.Song.Title),
                    StringResources.SongEditor,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    Save(window.Song, ((EditorChildMetaData)window.Tag).Filename);
                }
                else if (dlg == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            else if (filename != null && !File.Exists(filename))
            {
                DialogResult dlg = MessageBox.Show(string.Format(StringResources.SaveChangesMadeToTheSong, window.Song.Title),
                    StringResources.SongEditor,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    SaveAs(window.Song, ((EditorChildMetaData)window.Tag).Filename);
                }
                else if (dlg == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
        
        /// <summary>
        /// Returns the filter string used in open file dialogs
        /// </summary>
        /// <returns></returns>
        private static string GetOpenFileBoxFilter()
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

        /// <summary>
        /// Returns the filter string used in save file dialogs
        /// </summary>
        /// <returns></returns>
        private static string GetSaveFileBoxFilter()
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

        /// <summary>
        /// Gets a song file plugin by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private static ISongFilePlugin CreateByTypeIndex(int index)
        {
            if (index >= 0 && index < SongFilePluginFactory.GetWriterPlugins().Count)
            {
                return SongFilePluginFactory.GetWriterPlugins().ToArray()[index];
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new song with default name and one part with one slide
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        private static Song CreateNewSong(Settings settings)
        {
            Song sng = new Song
            {
                GUID = SongManager.Instance.GenerateGuid(),
                Title = settings.SongDefaultName,
                Language = settings.SongDefaultLanguage
            };

            SongPart tmpPart = new SongPart
            {
                Caption = settings.SongPartDefaultName
            };

            SongSlide tmpSlide = new SongSlide
            {
                Background = new ColorBackground(Settings.Default.ProjectionBackColor)
            };
            tmpPart.Slides.Add(tmpSlide);
            sng.Parts.Add(tmpPart);

            return sng;
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog ab = new AboutDialog();
            ab.ShowDialog(this);
        }

        private void webToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.Weburl);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramSettingsDialog stWnd = new ProgramSettingsDialog();
            stWnd.ShowDialog(this);
        }

        private void EditorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                Settings.Default.EditorWindowSize = Size;
            }
            Settings.Default.EditorWindowState = WindowState;
        }

        private void SetStatus(string text)
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
            if (MdiChildren.Any())
            {
                foreach (var c in MdiChildren)
                {
                    c.Close();
                }
            }
        }

        private void EditorWindow_Load(object sender, EventArgs e)
        {
        }

        private void datenverzeichnisAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.DataDirectory);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.DataDirectory);
        }

        private void fehlerMeldenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.BugReportUrl);
        }

        private void EditorWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
            GC.Collect();
        }
    }
}