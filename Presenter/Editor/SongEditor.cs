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
using PraiseBase.Presenter.Forms;
using PraiseBase.Presenter.Manager;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Persistence;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Template;
using Timer = System.Windows.Forms.Timer;

namespace PraiseBase.Presenter.Editor
{
    public partial class SongEditor : LocalizableForm
    {
        #region internalVariables

        /// <summary>
        /// Initial directory of file open/save dialog
        /// </summary>
        private string _fileBoxInitialDir;

        /// <summary>
        /// Type filter index of file open dialog
        /// </summary>
        private int _fileOpenBoxFilterIndex;

        /// <summary>
        /// Type filter index of file save dialog
        /// </summary>
        private int _fileSaveBoxFilterIndex;

        /// <summary>
        /// Number of open child forms
        /// </summary>
        private int _childFormNumber;
        
        /// <summary>
        /// Settings instance holder
        /// </summary>
        private readonly Settings _settings;

        #endregion

        private const int StatusMessageDuration = 2000;

        /// <summary>
        /// Delegate to inform subscribers that a song has been saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void SongSave(object sender, SongSavedEventArgs e);

        /// <summary>
        /// Song saved event
        /// </summary>
        public event SongSave SongSaved;

        private readonly ImageManager _imgManager;

        public SongEditor(Settings settings, ImageManager imgManager, String filename)
        {
            // Initialize internal variables
            _settings = settings;
            _imgManager = imgManager;
            _fileBoxInitialDir = _settings.DataDirectory + Path.DirectorySeparatorChar + _settings.SongDir;
            _fileOpenBoxFilterIndex = 0;
            _fileSaveBoxFilterIndex = 0;

            InitializeComponent();

            RegisterChild(this);

            if (!String.IsNullOrEmpty(filename) && File.Exists(filename))
            {
                OpenSong(filename);
            }
        }

        void selectLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage((CultureInfo)((ToolStripMenuItem)sender).Tag);

            foreach (ToolStripMenuItem i in spracheToolStripMenuItem.DropDownItems)
            {
                i.Checked = (Equals((CultureInfo)i.Tag, Thread.CurrentThread.CurrentUICulture));
            }
        }

        /// <summary>
        /// Event handler for creating a new file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowNewForm(object sender, EventArgs e)
        {
            SongTemplateMapper stm = new SongTemplateMapper(_settings);
            Song sng = stm.CreateNewSong();
            stm.ApplyFormattingFromSettings(sng);

            SongEditorChild childForm = CreateSongEditorChildForm(sng, null);

            childForm.Text = childForm.Song.Title + @" " + ++_childFormNumber;
        }

        /// <summary>
        /// Event handler for opening an existing file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = _fileBoxInitialDir,
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                Title = StringResources.OpenSong,
                Filter = GetOpenFileBoxFilter(),
                FilterIndex = _fileOpenBoxFilterIndex
            };

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                _fileBoxInitialDir = Path.GetDirectoryName(fileName);
                _fileOpenBoxFilterIndex = openFileDialog.FilterIndex;
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
            try
            {
                sng = SongFilePluginFactory.Create(fileName).Load(fileName);
            }
            catch (NotImplementedException)
            {
                MessageBox.Show(StringResources.SongFormatNotSupported, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(StringResources.SongFileHasErrors + @" (" + e.Message + @")!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            SongEditorChild childForm = new SongEditorChild(_settings, _imgManager, sng)
            {
                Tag = new EditorChildMetaData(fileName, hashCode),
                MdiParent = this
            };
            childForm.FormClosing += childForm_FormClosing;
            childForm.Show();
            RegisterChild(childForm);
            
            // Se status
            SetStatus(string.Format(StringResources.LoadedSong, sng.Title));

            return childForm;
        }

        /// <summary>
        /// Save event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChild(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                SongEditorChild window = ((SongEditorChild)ActiveMdiChild);
                window.ValidateChildren();
                string fileName = Save(window.Song, ((EditorChildMetaData) window.Tag).Filename);
                if (fileName != null)
                {
                    int hashCode = window.Song.GetHashCode();
                    ((EditorChildMetaData)window.Tag).HashCode = hashCode;
                    ((EditorChildMetaData)window.Tag).Filename = fileName;
                }
            }
        }

        /// <summary>
        /// Save as event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChildAs(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                SongEditorChild window = ((SongEditorChild)ActiveMdiChild);
                window.ValidateChildren();
                string fileName = SaveAs(window.Song, null);
                if (fileName != null)
                {
                    int hashCode = window.Song.GetHashCode();
                    ((EditorChildMetaData)window.Tag).HashCode = hashCode;
                    ((EditorChildMetaData)window.Tag).Filename = fileName;
                }
            }
        }

        /// <summary>
        /// Save given song at the filename specified
        /// </summary>
        /// <param name="sng"></param>
        /// <param name="fileName"></param>
        /// <returns>Filename used or null</returns>
        private string Save(Song sng, String fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return SaveAs(sng, null);
            }
            try
            {
                SaveSong(sng, fileName);
                return fileName;
            }
            catch (NotImplementedException)
            {
                MessageBox.Show(StringResources.SongCannotBeSavedInThisFormat, StringResources.FormatNotSupported,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return SaveAs(sng, fileName);
            }
        }

        /// <summary>
        /// Save given song, asking for filename
        /// </summary>
        /// <param name="sng"></param>
        /// <param name="fileName"></param>
        /// <returns>Filename used or null</returns>
        private string SaveAs(Song sng, String fileName)
        {
            // Check is using default name
            if (sng.Title == _settings.SongDefaultName)
            {
                if (MessageBox.Show(string.Format(StringResources.DoesTheSongReallyHaveTheDefaultTitle, sng.Title), StringResources.Attention,
                    MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return null;
                }
            }

            try
            {
                return SaveSongAskForName(sng, fileName);
            }
            catch (NotImplementedException)
            {
                MessageBox.Show(StringResources.SongCannotBeSavedInThisFormat, StringResources.SongEditor,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
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
        /// Saves a song
        /// </summary>
        /// <param name="sng">Song to be saved</param>
        /// <param name="fileName">Target file name</param>
        private void SaveSong(Song sng, String fileName)
        {
            // Load plugin based on the song filename
            ISongFilePlugin plugin = SongFilePluginFactory.Create(fileName);

            // Save song using plugin
            plugin.Save(sng, fileName);

            // Set status
            SetStatus(String.Format(StringResources.SongSavedAs, fileName));

            // Inform others by firing a SongSaved event
            if (SongSaved != null)
            {
                SongSavedEventArgs p = new SongSavedEventArgs(sng, fileName);
                SongSaved(this, p);
            }
        }

        /// <summary>
        /// Saves a song by asking for a file name
        /// </summary>
        /// <param name="sng">Song to be saved</param>
        /// <param name="fileName">Existing filename, can be null</param>
        /// <returns>The choosen name, if the song has been saved, or null if the action has been cancelled</returns>
        private string SaveSongAskForName(Song sng, String fileName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = fileName != null
                    ? Path.GetDirectoryName(fileName)
                    : _fileBoxInitialDir,
                CheckPathExists = true,
                FileName = sng.Title,
                Filter = GetSaveFileBoxFilter(),
                FilterIndex = _fileSaveBoxFilterIndex,
                AddExtension = true,
                Title = StringResources.SaveSongAs
            };
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Load plugin based on selected filter index
                ISongFilePlugin plugin = CreateByTypeIndex(saveFileDialog.FilterIndex - 1);

                // Save song using plugin
                plugin.Save(sng, saveFileDialog.FileName);

                // Store selected filter index
                _fileSaveBoxFilterIndex = saveFileDialog.FilterIndex;

                // Set status
                SetStatus(string.Format(StringResources.SongSavedAs, saveFileDialog.FileName));

                // Inform others by firing a SongSaved event
                if (SongSaved != null)
                {
                    SongSavedEventArgs p = new SongSavedEventArgs(sng, saveFileDialog.FileName);
                    SongSaved(this, p);
                }

                // Return file name
                return saveFileDialog.FileName;
            }
            return null;
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
        /// <exception cref="NotImplementedException">Thrown if the selected plugin has no implementation</exception>
        /// <returns></returns>
        private static ISongFilePlugin CreateByTypeIndex(int index)
        {
            if (index >= 0 && index < SongFilePluginFactory.GetWriterPlugins().Count)
            {
                return SongFilePluginFactory.GetWriterPlugins().ToArray()[index];
            }
            throw new NotImplementedException();
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
            AboutDialog ab = new AboutDialog(_settings.UpdateCheckUrl);
            ab.ShowDialog(this);
        }

        private void webToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(_settings.Weburl);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramSettingsDialog stWnd = new ProgramSettingsDialog(_settings);
            stWnd.ShowDialog(this);
        }

        private void EditorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                _settings.EditorWindowSize = Size;
            }
            _settings.EditorWindowState = WindowState;
        }

        /// <summary>
        /// Displays a message in the status bar for 2 seconds
        /// </summary>
        /// <param name="text"></param>
        private void SetStatus(string text)
        {
            toolStripStatusLabel1.Text = text;
            Timer statusTimer = new Timer
            {
                Interval = StatusMessageDuration
            };
            statusTimer.Tick += statusTimer_Tick;
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
            // Set size and window state
            WindowState = _settings.EditorWindowState;
            Size = _settings.EditorWindowSize;

            // Add languages to menu
            foreach (var l in Constants.AvailableLanguages)
            {
                ToolStripMenuItem selectLanguageToolStripMenuItem = new ToolStripMenuItem(l.DisplayName)
                {
                    Tag = l
                };
                selectLanguageToolStripMenuItem.Click += selectLanguageToolStripMenuItem_Click;
                if (l.Name == Thread.CurrentThread.CurrentUICulture.Name)
                {
                    selectLanguageToolStripMenuItem.Checked = true;
                }
                spracheToolStripMenuItem.DropDownItems.Add(selectLanguageToolStripMenuItem);
            }
        }

        private void datenverzeichnisAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(_settings.DataDirectory);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Process.Start(_settings.DataDirectory);
        }

        private void fehlerMeldenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(_settings.BugReportUrl);
        }

        private void EditorWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(_settings.HelpUrl);
        }
    }
}