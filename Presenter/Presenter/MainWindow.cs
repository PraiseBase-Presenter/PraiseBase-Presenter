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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using PraiseBase.Presenter.Controls;
using PraiseBase.Presenter.Editor;
using PraiseBase.Presenter.Forms;
using PraiseBase.Presenter.Importer;
using PraiseBase.Presenter.Manager;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Bible;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Persistence;
using PraiseBase.Presenter.Persistence.Setlists;
using PraiseBase.Presenter.Projection;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Util;
using Timer = System.Windows.Forms.Timer;
using System.ComponentModel;

namespace PraiseBase.Presenter.Presenter
{
    /// <summary>
    /// The main window class provides the central
    /// gui of this software, including the songlist,
    /// setlist, imagelist and the diashow interface.
    /// </summary>
    public partial class MainWindow : LocalizableForm
    {
        // Here is the once-per-class call to initialize the log object
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Timer _diaTimer;
        private List<String> _imageSearchResults;

        private bool _linkLayers = true;

        private SongEditor _songEditor;

        private string _currentSetlistFile;

        private int _currentSetListHashCode;

        private readonly string _originalFormTitle;

        private readonly SongManager _songManager;

        private readonly ImageManager _imgManager;

        private readonly BibleManager _bibleManager;

        public MainWindow(SongManager songManager, ImageManager imgManager, BibleManager bibleManager, string setlistFile)
        {
            _songManager = songManager;
            _imgManager = imgManager;
            _bibleManager = bibleManager;

            InitializeComponent();

            Size = Settings.Default.MainWindowSize;
            
            RegisterChild(this);

            _originalFormTitle = Text;

            // Load setlist file if specified
            LoadSetListIfExists(setlistFile);

            songDetailElement.ImageManager = imgManager;

            songDetailElement.AvailableSongCaption = Settings.Default.SongParts;
        }

        /// <summary>
        /// Initializes some basic form stuff
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            var newThread = new Thread(DoUpdateCheck) { Name = "UpdateChecker" };
            newThread.Start();

            LoadBiblesInBackground();

            WindowState = Settings.Default.ViewerWindowState;
            //Text += " " + Assembly.GetExecutingAssembly().GetName().Version;

            if (Settings.Default.LayerContentSplitterPosition > 0)
            {
                splitContainerLayerContent.SplitterDistance = Settings.Default.LayerContentSplitterPosition;
            }

            LoadSongList();

            ImageTreeViewInit();

            trackBarFadeTime.Value = Settings.Default.ProjectionFadeTime / 500;
            labelFadeTime.Text = (trackBarFadeTime.Value * 0.5) + @" s";

            trackBarFadeTimeLayer1.Value = Settings.Default.ProjectionFadeTimeLayer1 / 500;
            labelFadeTimeLayer1.Text = (trackBarFadeTimeLayer1.Value * 0.5) + @" s";

            _linkLayers = Settings.Default.LinkLayers;
            SetLinkLayerUi();

            if (Settings.Default.SongSearchMode == SongSearchMode.Title)
            {
                titelToolStripMenuItem.Checked = true;
                titelUndTextToolStripMenuItem.Checked = false;
            }
            else
            {
                titelToolStripMenuItem.Checked = false;
                titelUndTextToolStripMenuItem.Checked = true;
            }

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

            UpdatePresenterSongViewModeButtons(Settings.Default.PresenterSongViewMode);

            ProjectionManager.Instance.ProjectionChanged += Instance_ProjectionChanged;

            listViewBibleVerses.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

            checkBoxBibleAutoShowVerse.Checked = Settings.Default.AutoShowBibleVerse;

            comboBoxWebVideoService.DataSource = Enum.GetValues(typeof(WebVideoService));

            ToggleChromaKeying(Settings.Default.ChromaKeyingEnabled);
        }

        #region SongEditor

        private SongEditor GetSongEditor()
        {
            if (_songEditor == null || _songEditor.IsDisposed)
            {
                _songEditor = CreateSongEditorInstance();
            }
            return _songEditor;
        }

        private SongEditor CreateSongEditorInstance()
        {
            var se = new SongEditor(Settings.Default, _imgManager, null);
            se.SongSaved += SongEditorWndOnSongSaved;
            se.DataDirChanged += se_DataDirChanged;
            return se;
        }

        private void SongEditorWndOnSongSaved(object sender, SongSavedEventArgs songSavedEventArgs)
        {
            UpdateSongListItem(songSavedEventArgs.FileName);
        }

        private void UpdateSongListItem(string filename)
        {
            var item = _songManager.GetSongItemByPath(filename);
            if (item != null)
            {
                _songManager.ReloadSongItem(item);
                if (_songManager.CurrentSong == item)
                {
                    ShowCurrentSongDetails();
                }
            }
            else
            {
                _songManager.Reload();
                LoadSongList();
            }
        }

        void se_DataDirChanged(object sender, EventArgs e)
        {
            UpdateDataDir();
        }

        private void ShowAndFocusSongEditor()
        {
            var se = GetSongEditor();
            se.Show();
            se.Focus();
        }

        private void ShowAndBringSongEditorToFront()
        {
            var se = GetSongEditor();
            se.Show();
            se.BringToFront();
        }

        private void OpenSongInSongEditor(Song song)
        {
            ShowAndBringSongEditorToFront();
            var se = GetSongEditor();
            se.OpenNewSongObject(song);
        }

        #endregion

        #region UpdateCheck

        /// <summary>
        /// Checks if there is an update available. If yes, shows an info message
        /// </summary>
        void DoUpdateCheck()
        {
            UpdateChecker uc = new UpdateChecker();
            UpdateInformation ui = uc.GetNewVersion(Settings.Default.UpdateCheckUrl);
            if (ui.UpdateAvailable)
            {
                // Return if user already has hidden notifications about this update
                if (Settings.Default.HideUpdateVersion != String.Empty)
                {
                    Version hideVer = new Version(Settings.Default.HideUpdateVersion);
                    if (hideVer == ui.OnlineVersion)
                    {
                        return;
                    }
                }

                // ask the user if he would like to download the new version
                UpdateCheckDialog ucdlg = new UpdateCheckDialog(ui);
                if (ucdlg.ShowDialog() == DialogResult.Yes)
                {
                    // navigate the default web browser to our app
                    // homepage (the url comes from the xml content)
                    Process.Start(ui.DownloadUrl);
                }
                else
                {
                    if (ucdlg.HideNotification)
                    {
                        Settings.Default.HideUpdateVersion = ui.OnlineVersion.ToString();
                        Settings.Default.Save();
                    }
                }
            }
        }

        #endregion

        void selectLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage((CultureInfo)((ToolStripMenuItem)sender).Tag);
            foreach (ToolStripMenuItem i in spracheToolStripMenuItem.DropDownItems)
            {
                i.Checked = ((CultureInfo)i.Tag == Thread.CurrentThread.CurrentUICulture);
            }
        }

        void Instance_ProjectionChanged(object sender, ProjectionManager.ProjectionChangedEventArgs e)
        {
            pictureBoxbeamerPreview.Image = e.Image;
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ab = new AboutDialog(Settings.Default.UpdateCheckUrl, Settings.Default.AuthorInfo);
            ab.ShowDialog(this);
        }

        private void songSearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchSongs(songSearchTextBox.Text);
        }

        /**
         * Load Songs
         */

        private void LoadSongList()
        {
            SearchSongs(null);
        }

        private void SearchSongs(string needle)
        {
            listViewSongs.BeginUpdate();
            listViewSongs.SuspendLayout();
            listViewSongs.Items.Clear();

            var lviList = new List<ListViewItem>();

            // Fill list of songs
            int cnt = 0;
            if (!String.IsNullOrEmpty(needle))
            {
                // Search matching songs
                foreach (var elem in _songManager.GetSearchResults(needle, Settings.Default.SongSearchMode))
                {
                    var lvi = new ListViewItem(elem.Value.Song.Title)
                    {
                        Tag = elem.Key
                    };
                    lviList.Add(lvi);
                    cnt++;
                }
            }
            else
            {
                // Load all songs
                foreach (var elem in _songManager.SongList)
                {
                    var lvi = new ListViewItem(elem.Value.Song.Title)
                    {
                        Tag = elem.Key
                    };
                    lviList.Add(lvi);
                    cnt++;
                }
            }
            listViewSongs.Items.AddRange(lviList.ToArray());

            // If only one song remains, set this as current song
            if (cnt == 1)
            {
                try
                {
                    listViewSongs.Items[0].Selected = true;
                    var key = (String) listViewSongs.SelectedItems[0].Tag;
                    _songManager.CurrentSong = _songManager.SongList[key];
                    ShowCurrentSongDetails();
                }
                catch (Exception e)
                {
                    log.Error(@"Song search exception: " + e);
                }
            }

            listViewSongs.Columns[0].Width = -2;
            listViewSongs.ResumeLayout();
            listViewSongs.EndUpdate();
        }

        private void ToggleProjection(object sender, EventArgs e)
        {
            // Disable projection
            if (((ToolStripItem)sender).Name == "toolStripButtonProjectionOff"
                || ((ToolStripItem)sender).Name == "präsentationausToolStripMenuItem")
            {
                toolStripButtonProjectionOff.CheckState = CheckState.Checked;
                toolStripButtonProjectionOn.CheckState = CheckState.Unchecked;
                toolStripButtonBlackout.CheckState = CheckState.Unchecked;
                
                ProjectionManager.Instance.HideProjectionWindow();
            }
            // Blackout
            else if (((ToolStripItem)sender).Name == "toolStripButtonBlackout"
                     || ((ToolStripItem)sender).Name == "blackoutToolStripMenuItem")
            {
                toolStripButtonProjectionOff.CheckState = CheckState.Unchecked;
                toolStripButtonBlackout.CheckState = CheckState.Checked;
                toolStripButtonProjectionOn.CheckState = CheckState.Unchecked;
                
                ProjectionManager.Instance.ShowBlackout();
            }
            // Show projection
            else if (((ToolStripItem)sender).Name == "toolStripButtonProjectionOn"
                     || ((ToolStripItem)sender).Name == "präsentationeinToolStripMenuItem")
            {
                toolStripButtonProjectionOff.CheckState = CheckState.Unchecked;
                toolStripButtonBlackout.CheckState = CheckState.Unchecked;
                toolStripButtonProjectionOn.CheckState = CheckState.Checked;

                ProjectionManager.Instance.ShowProjectionWindow();
            }
            songSearchTextBox.Focus();
        }

        private void optionenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettingsDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            OpenSettingsDialog();
        }

        private void OpenSettingsDialog()
        {
            String dataDirectory = Settings.Default.DataDirectory;
            new ProgramSettingsDialog(Settings.Default).ShowDialog(this);

            // Reload songs and images if data directory changed
            if (dataDirectory != Settings.Default.DataDirectory)
            {
                UpdateDataDir();
            }
        }

        private void UpdateDataDir()
        {
            _songManager.SongDirPath = SettingsUtil.GetSongDirPath(Settings.Default);
            _imgManager.ImageDirPath = SettingsUtil.GetImageDirPath(Settings.Default);
            _imgManager.ThumbDirPath = SettingsUtil.GetThumbDirPath(Settings.Default);
            _bibleManager.BibleDirectory = SettingsUtil.GetBibleDirPath(Settings.Default);
            ReloadSongList();
            ReloadImageList();
            CheckThumbnails();
            reloadBibles();
        }

        private void liederlisteNeuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadSongList();
        }

        private void ReloadSongList()
        {
            songSearchTextBox.Text = "";
            _songManager.Reload();
            LoadSongList();

            for (int i = 0; i < listViewSetList.Items.Count; i++)
            {
                var setListItemTitle = listViewSetList.Items[i].Text;
                var key = _songManager.GetKeyByTitle(setListItemTitle);
                if (key != null)
                {
                    listViewSetList.Items[i].Tag = key;
                }
                else
                {
                    MessageBox.Show(String.Format(StringResources.SongDoesNotExist, setListItemTitle));
                }
            }

            songSearchTextBox.Focus();
            GC.Collect();
        }

        private void listViewSongs_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewSongs.SelectedIndices.Count > 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    listViewSetList.Items.Add((ListViewItem)listViewSongs.SelectedItems[0].Clone());
                    listViewSetList.Columns[0].Width = -2;
                    buttonSetListClear.Enabled = true;
                    buttonSaveSetList.Enabled = true;
                }
                else
                {
                    string key = (string) listViewSongs.SelectedItems[0].Tag;
                    if (_songManager.CurrentSong == null || _songManager.CurrentSong.Song == null || _songManager.CurrentSong.Filename != key)
                    {
                        if (_songManager.SongList.ContainsKey(key))
                        {
                            _songManager.CurrentSong = _songManager.SongList[key];
                            ShowCurrentSongDetails();
                            buttonSetListAdd.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show(StringResources.SongDoesNotExistInSonglist, StringResources.Error, 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                buttonSetListAdd.Enabled = true;
            }
            else
            {
                buttonSetListAdd.Enabled = false;
            }
        }

        private void listViewSongs_KeyUp(object sender, KeyEventArgs e)
        {
            if (listViewSongs.SelectedItems.Count > 0)
            {
                var key = (string) listViewSongs.SelectedItems[0].Tag;
                if (_songManager.SongList.ContainsKey(key) && (_songManager.CurrentSong == null || _songManager.CurrentSong.Filename != key))
                {
                    _songManager.CurrentSong = _songManager.SongList[key];
                    ShowCurrentSongDetails();

                    buttonSetListAdd.Enabled = true;
                }
            }
        }

        private void listViewSetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSetList.SelectedIndices.Count > 0)
            {
                Song previousSong = null;
                Song nextSong = null;

                if (tabControlTextLayer.SelectedIndex != 0)
                    tabControlTextLayer.SelectedIndex = 0;

                int idx = listViewSetList.SelectedIndices[0];
                if (idx > 0)
                {
                    buttonSetListUp.Enabled = true;
                    string prevSongId = (string)listViewSetList.Items[idx - 1].Tag;
                    previousSong = _songManager.SongList[prevSongId].Song;
                }
                else
                {
                    buttonSetListUp.Enabled = false;
                }
                if (idx < listViewSetList.Items.Count - 1)
                {
                    buttonSetListDown.Enabled = true;
                    string nextSongId = (string)listViewSetList.Items[idx + 1].Tag;
                    nextSong = _songManager.SongList[nextSongId].Song;
                }
                else
                {
                    buttonSetListDown.Enabled = false;
                }
                buttonSetListRem.Enabled = true;

                string currentSongId = (string)listViewSetList.SelectedItems[0].Tag;
                _songManager.CurrentSong = _songManager.SongList[currentSongId];
                ShowCurrentSongDetails(previousSong, nextSong);
            }
        }

        private void ShowCurrentSongDetails(Song previousSong = null, Song nextSong = null)
        {
            Application.DoEvents();

            label3.Text = _songManager.CurrentSong.Song.Title;
            songDetailElement.SetSong(_songManager.CurrentSong.Song, previousSong, nextSong);

            toolStripButtonQA.Enabled = true;
            UpdateQaButtonState();
            qaSpellingToolStripMenuItem.Checked = _songManager.CurrentSong.Song.QualityIssues.Contains(SongQualityAssuranceIndicator.Spelling);
            qaTranslationToolStripMenuItem.Checked = _songManager.CurrentSong.Song.QualityIssues.Contains(SongQualityAssuranceIndicator.Translation);
            qaImagesToolStripMenuItem.Checked = _songManager.CurrentSong.Song.QualityIssues.Contains(SongQualityAssuranceIndicator.Images);
            qaSegmentationToolStripMenuItem.Checked = _songManager.CurrentSong.Song.QualityIssues.Contains(SongQualityAssuranceIndicator.Segmentation);

            if (_songManager.CurrentSong.Song.HasTranslation())
            {
                toolStripButtonToggleTranslationText.Enabled = true;
                toolStripButtonToggleTranslationText.Image = _songManager.CurrentSong.SwitchTextAndTranlation ? Resources.translate_active : Resources.translate;
            }
            else
            {
                toolStripButtonToggleTranslationText.Enabled = false;
                toolStripButtonToggleTranslationText.Image = Resources.translate;
            }
        }

        private void songDetailElement_SlideClicked(object sender, SlideClickEventArgs e)
        {
            Application.DoEvents();

            var s = _songManager.CurrentSong.Song;

            if (listViewSongHistory.Items.Count == 0 || (string)listViewSongHistory.Items[0].Tag != _songManager.CurrentSong.Filename)
            {
                var lvi = new ListViewItem(s.Title)
                {
                    Tag = _songManager.CurrentSong.Filename
                };
                listViewSongHistory.Items.Insert(0, lvi);
                listViewSongHistory.Columns[0].Width = -2;
            }

            SongSlide cs = s.Parts[e.PartNumber].Slides[e.SlideNumber];

            SlideTextFormatting slideFormatting = new SlideTextFormatting();

            AdditionalInformationPosition sourcePosition;
            AdditionalInformationPosition copyrightPosition;

            // Formatting based on master styling
            if (Settings.Default.ProjectionUseMaster|| s.Formatting == null)
            {
                ISlideTextFormattingMapper<Settings> mapper = new SettingsSlideTextFormattingMapper();
                mapper.Map(Settings.Default, ref slideFormatting);
                sourcePosition = Settings.Default.ProjectionMasterSourcePosition;
                copyrightPosition = Settings.Default.ProjectionMasterCopyrightPosition;
            }
            // Formatting based on song settings
            else
            {
                ISlideTextFormattingMapper<Song> mapper = new SongSlideTextFormattingMapper();
                mapper.Map(s, ref slideFormatting);
                sourcePosition = s.Formatting.SourcePosition;
                copyrightPosition = s.Formatting.CopyrightPosition;
            }
            slideFormatting.ScaleFontSize = Settings.Default.ProjectionFontScaling;
            slideFormatting.SmoothShadow = Settings.Default.ProjectionSmoothShadow;

            TextLayer ssl = new TextLayer(slideFormatting);
            ssl.DrawBordersForDebugging = Settings.Default.DebugMode;

            // Set text and translation (based on translation switch state)
            if (cs.Translated && _songManager.CurrentSong.SwitchTextAndTranlation)
            {
                ssl.MainText = cs.Translation.ToArray();
                ssl.SubText = cs.Lines.ToArray();
            }
            else
            {
                ssl.MainText = cs.Lines.ToArray();
                ssl.SubText = cs.Translation.ToArray();
            }

            // Set header text (song source)
            if (sourcePosition == AdditionalInformationPosition.FirstSlide && e.isFirst ||
                sourcePosition == AdditionalInformationPosition.LastSlide && e.isLast || 
                sourcePosition == AdditionalInformationPosition.Always)
            {
                ssl.HeaderText = new[]
                {
                    s.SongBooks.ToString()
                };
            }

            // Set footer text (copyright)
            if (s.Copyright != null && (
                copyrightPosition == AdditionalInformationPosition.FirstSlide && e.isFirst ||
                copyrightPosition == AdditionalInformationPosition.LastSlide && e.isLast ||
                copyrightPosition == AdditionalInformationPosition.Always))
            {
                String[] copyRightLines = s.Copyright.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
                if (!String.IsNullOrEmpty(s.CcliIdentifier))
                {
                    copyRightLines = copyRightLines.Concat(new [] { "CCLI #" + s.CcliIdentifier }).ToArray();
                }
                ssl.FooterText = copyRightLines;
            }

            // CTRL pressed, use image stack
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (listViewImageQueue.Items.Count > 0)
                {
                    ImageLayer iml = new ImageLayer(Settings.Default.ProjectionBackColor);
                    IBackground bg = (IBackground)listViewImageQueue.Items[0].Tag;
                    iml.Image = _imgManager.GetImage(bg);
                    ProjectionManager.Instance.DisplayImage(iml, Settings.Default.ProjectionFadeTimeLayer1);
                    ProjectionManager.Instance.DisplayText(ssl);
                    if (bg != null && bg.GetType() == typeof(ImageBackground))
                    {
                        ImageHistoryAdd(((ImageBackground)bg).ImagePath);
                    }
                    listViewImageQueue.Items[0].Remove();
                }
                else
                {
                    ProjectionManager.Instance.DisplayText(ssl);
                }
            }

                // SHIFT pressed, use current slide
            else if (!_linkLayers ^ ((ModifierKeys & Keys.Shift) == Keys.Shift))
            {
                ProjectionManager.Instance.DisplayText(ssl);
            }

                // Current slide + attached image
            else
            {
                ImageLayer iml = new ImageLayer(Settings.Default.ProjectionBackColor)
                {
                    Image = _imgManager.GetImage(cs.Background)
                };
                ProjectionManager.Instance.DisplayImage(iml, Settings.Default.ProjectionFadeTimeLayer1);
                ProjectionManager.Instance.DisplayText(ssl);

                if (cs.Background != null && cs.Background.GetType() == typeof(ImageBackground))
                {
                    ImageHistoryAdd(((ImageBackground)cs.Background).ImagePath);
                }
            }
        }

        private void songDetailElement_ImageClicked(object sender, SlideImageClickEventArgs e)
        {
            Application.DoEvents();

            // Stack
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                listViewImageQueue.LargeImageList.Images.Add(_imgManager.GetThumb(e.Background));
                var lvi = new ListViewItem("")
                {
                    Tag = e.Background,
                    ImageIndex = listViewImageQueue.LargeImageList.Images.Count - 1
                };
                listViewImageQueue.Items.Add(lvi);
            }

            // Favorite
            else if ((ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                if (e.Background != null && e.Background.GetType() == typeof(ImageBackground))
                {
                    ImageFavoriteAdd(((ImageBackground)e.Background).ImagePath);
                }
            }
            else
            {
                // Hide text if layers are linked OR shift is pressed and the layers are not linked
                if (!(!_linkLayers ^ ((ModifierKeys & Keys.Shift) == Keys.Shift)))
                {
                    ProjectionManager.Instance.HideText();
                }

                // Show image
                ImageLayer iml = new ImageLayer(Settings.Default.ProjectionBackColor)
                {
                    Image = _imgManager.GetImage(e.Background)
                };
                ProjectionManager.Instance.DisplayImage(iml, Settings.Default.ProjectionFadeTimeLayer1);

                if (e.Background != null && e.Background.GetType() == typeof(ImageBackground))
                {
                    ImageHistoryAdd(((ImageBackground)e.Background).ImagePath);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlTextLayer.SelectedIndex == 0)
            {
                songSearchTextBox.Focus();
            }
            else if (tabControlTextLayer.SelectedIndex == 1)
            {
                textBoxLiveText.Focus();
            }
            else if (tabControlTextLayer.SelectedIndex == 3)
            {
                textBoxWebVideoID.Focus();
                textBoxWebVideoID.SelectAll();
            }
        }

        private void webToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.Weburl);
        }

        public void ImageTreeViewInit()
        {
            string rootDir = _imgManager.ImageDirPath;
            treeViewImageDirectories.Nodes.Clear();
            PopulateTreeView(rootDir, null);
            treeViewImageDirectories.ExpandAll();
            treeViewImageDirectories.Nodes.Add(StringResources.SearchResults);
            treeViewImageDirectories.SelectedNode = treeViewImageDirectories.Nodes[0];

            _imageSearchResults = new List<String>();

            var iml = new ImageList
            {
                ImageSize = Settings.Default.ThumbSize,
                ColorDepth = ColorDepth.Depth32Bit
            };
            listViewImageHistory.LargeImageList = iml;
            listViewImageHistory.TileSize = new Size(Settings.Default.ThumbSize.Width + 8,
                                                     Settings.Default.ThumbSize.Height + 5);

            var iml2 = new ImageList
            {
                ImageSize = Settings.Default.ThumbSize,
                ColorDepth = ColorDepth.Depth32Bit
            };
            listViewImageQueue.LargeImageList = iml2;
            listViewImageQueue.TileSize = new Size(Settings.Default.ThumbSize.Width + 8,
                                                   Settings.Default.ThumbSize.Height + 5);

            if (Settings.Default.ImageFavorites == null)
                Settings.Default.ImageFavorites = new ArrayList();

            var iml3 = new ImageList
            {
                ImageSize = Settings.Default.ThumbSize,
                ColorDepth = ColorDepth.Depth32Bit
            };
            listViewFavorites.LargeImageList = iml3;
            listViewFavorites.TileSize = new Size(Settings.Default.ThumbSize.Width + 8,
                                                  Settings.Default.ThumbSize.Height + 5);

            foreach (string relImagePath in Settings.Default.ImageFavorites)
            {
                listViewFavorites.LargeImageList.Images.Add(_imgManager.GetThumbFromRelPath(relImagePath));
                var lvi = new ListViewItem("")
                {
                    Tag = relImagePath,
                    ImageIndex = listViewFavorites.LargeImageList.Images.Count - 1
                };
                listViewFavorites.Items.Add(lvi);
                listViewFavorites.EnsureVisible(listViewFavorites.Items.Count - 1);
            }
            tabPageImageFavorites.Text = StringResources.Favorites + @" (" + Settings.Default.ImageFavorites.Count + @")";
        }

        public void PopulateTreeView(string directoryValue, TreeNode parentNode)
        {
            try
            {
                if (Directory.Exists(directoryValue))
                {
                    if (parentNode == null)
                    {
                        var myNode = new TreeNode(StringResources.TopDirectory)
                        {
                            Tag = ""
                        };
                        treeViewImageDirectories.Nodes.Add(myNode);
                        parentNode = myNode;
                    }

                    string[] directoryArray =
                        Directory.GetDirectories(directoryValue);

                    if (directoryArray.Length != 0)
                    {
                        int subLen = (_imgManager.ImageDirPath + Path.DirectorySeparatorChar).Length;
                        foreach (string directory in directoryArray)
                        {
                            string dName = Path.GetFileName(directory);
                            if (dName.Substring(0, 1) != "[" && dName.Substring(0, 1) != ".")
                            {
                                var myNode = new TreeNode(dName)
                                {
                                    Tag = directory.Substring(subLen)
                                };

                                if (parentNode == null)
                                    treeViewImageDirectories.Nodes.Add(myNode);
                                else
                                    parentNode.Nodes.Add(myNode);
                                PopulateTreeView(directory, myNode);
                            }
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
            } // end catch
        }

        private void treeViewImageDirectories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewImageDirectories.Nodes.Count > 1)
            {
                listViewDirectoryImages.BeginUpdate();
                listViewDirectoryImages.SuspendLayout();
                listViewDirectoryImages.Items.Clear();

                if (listViewDirectoryImages.LargeImageList != null)
                {
                    listViewDirectoryImages.LargeImageList.Dispose();
                }

                // Search
                if (treeViewImageDirectories.SelectedNode.Level == 0 && treeViewImageDirectories.SelectedNode.Index == treeViewImageDirectories.Nodes.Count - 1)
                {
                    var imList = new ImageList
                    {
                        ImageSize = Settings.Default.ThumbSize,
                        ColorDepth = ColorDepth.Depth32Bit
                    };

                    var lviList = new List<ListViewItem>();

                    string pathPrefix = _imgManager.ThumbDirPath + Path.DirectorySeparatorChar;
                    int i = 0;

                    foreach (string file in _imageSearchResults)
                    {
                        var lvi = new ListViewItem(Path.GetFileNameWithoutExtension(file))
                        {
                            Tag = file,
                            ImageIndex = i
                        };
                        imList.Images.Add(Image.FromFile(pathPrefix + file));
                        lviList.Add(lvi);
                        i++;
                    }
                    listViewDirectoryImages.Items.AddRange(lviList.ToArray());
                    listViewDirectoryImages.LargeImageList = imList;

                    labelImgDirName.Text = StringResources.SearchResults + @" (" + i + @" " + StringResources.Images + @")";
                }
                else
                {
                    string relativeImageDir = ((string)treeViewImageDirectories.SelectedNode.Tag) + Path.DirectorySeparatorChar;
                    string imDir = _imgManager.ThumbDirPath + Path.DirectorySeparatorChar + relativeImageDir;

                    if (Directory.Exists(imDir))
                    {
                        var imList = new ImageList
                        {
                            ImageSize = Settings.Default.ThumbSize,
                            ColorDepth = ColorDepth.Depth32Bit
                        };

                        string[] songFilePaths = Directory.GetFiles(imDir, "*.jpg", SearchOption.TopDirectoryOnly);
                        int i = 0;
                        foreach (string file in songFilePaths)
                        {
                            var lvi = new ListViewItem(Path.GetFileNameWithoutExtension(file))
                            {
                                Tag = relativeImageDir + Path.GetFileName(file),
                                ImageIndex = i
                            };
                            listViewDirectoryImages.Items.Add(lvi);
                            imList.Images.Add(Image.FromFile(file));
                            i++;
                        }
                        listViewDirectoryImages.LargeImageList = imList;

                        string categoryName;
                        if (treeViewImageDirectories.SelectedNode.Level == 0)
                        {
                            categoryName = StringResources.TopDirectory;
                        }
                        else
                        {
                            categoryName = StringResources.Category + " '" + Path.GetFileName(((string)treeViewImageDirectories.SelectedNode.Tag));
                        }

                        labelImgDirName.Text = categoryName + @"' (" + i + @" " + StringResources.Images + @"):";
                    }
                }

                listViewDirectoryImages.ResumeLayout();
                listViewDirectoryImages.EndUpdate();
            }
        }

        private void listViewDirectoryImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDirectoryImages.SelectedIndices.Count > 0)
            {
                Application.DoEvents();
                int idx = listViewDirectoryImages.SelectedIndices[0];

                // Stack
                if ((ModifierKeys & Keys.Control) == Keys.Control)
                {
                    listViewImageQueue.LargeImageList.Images.Add(
                        _imgManager.GetThumbFromRelPath((string)listViewDirectoryImages.Items[idx].Tag));
                    var lvi = new ListViewItem("")
                    {
                        Tag = listViewDirectoryImages.Items[idx].Tag,
                        ImageIndex = listViewImageQueue.LargeImageList.Images.Count - 1
                    };
                    listViewImageQueue.Items.Add(lvi);

                    //listViewImageQueue.EnsureVisible(listViewImageHistory.Items.Count - 1);
                }

                // Favorite
                else if ((ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    ImageFavoriteAdd((string)listViewDirectoryImages.Items[idx].Tag);
                }
                else
                {
                    // Linked layers
                    if (
                        !(!_linkLayers ^
                           ((ModifierKeys & Keys.Shift) == Keys.Shift && _songManager.CurrentSong != null)))
                    {
                        ProjectionManager.Instance.HideText(Settings.Default.ProjectionFadeTime);
                    }

                    ImageLayer iml = new ImageLayer(Settings.Default.ProjectionBackColor)
                    {
                        Image = _imgManager.GetImageFromRelPath((string) listViewDirectoryImages.Items[idx].Tag)
                    };
                    ProjectionManager.Instance.DisplayImage(iml, Settings.Default.ProjectionFadeTimeLayer1);

                    // Add image to history
                    ImageHistoryAdd((string)listViewDirectoryImages.Items[idx].Tag);
                }
            }
        }

        private void ImageHistoryAdd(string relImagePath)
        {
            if (listViewImageHistory.Items.Count == 0 ||
                (string)listViewImageHistory.Items[listViewImageHistory.Items.Count - 1].Tag != relImagePath)
            {
                for (int i = 0; i < listViewImageHistory.Items.Count; i++)
                {
                    if ((string)listViewImageHistory.Items[i].Tag == relImagePath)
                    {
                        listViewImageHistory.Items.RemoveAt(i);
                    }
                }
                var img = _imgManager.GetThumbFromRelPath(relImagePath);
                if (img != null)
                {
                    listViewImageHistory.LargeImageList.Images.Add(img);
                    var lvi = new ListViewItem("")
                    {
                        Tag = relImagePath,
                        ImageIndex = listViewImageHistory.LargeImageList.Images.Count - 1
                    };
                    listViewImageHistory.Items.Add(lvi);
                    listViewImageHistory.EnsureVisible(listViewImageHistory.Items.Count - 1);
                }
            }
        }

        private void ImageFavoriteAdd(string relImagePath)
        {
            if (!Settings.Default.ImageFavorites.Contains(relImagePath))
            {
                listViewFavorites.LargeImageList.Images.Add(_imgManager.GetThumbFromRelPath(relImagePath));
                var lvi = new ListViewItem("")
                {
                    Tag = relImagePath,
                    ImageIndex = listViewFavorites.LargeImageList.Images.Count - 1
                };
                listViewFavorites.Items.Add(lvi);
                listViewFavorites.EnsureVisible(listViewFavorites.Items.Count - 1);
                Settings.Default.ImageFavorites.Add(relImagePath);
                Settings.Default.Save();
                tabPageImageFavorites.Text = StringResources.Favorites +  @" (" + Settings.Default.ImageFavorites.Count + @")";
            }
        }

        private void ImageFavoriterRemove(string relImagePath)
        {
            if (Settings.Default.ImageFavorites.Contains(relImagePath))
            {
                Settings.Default.ImageFavorites.Remove(relImagePath);
                Settings.Default.Save();
                tabPageImageFavorites.Text = StringResources.Favorites + @" (" + Settings.Default.ImageFavorites.Count + @")";
            }
        }

        private void bilderlisteNeuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadImageList();
        }

        private void ReloadImageList()
        {
            ImageTreeViewInit();
            listViewDirectoryImages.Items.Clear();
            GC.Collect();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ShowAndFocusSongEditor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            if (listViewDias.Tag != null)
                dlg.SelectedPath = (string)listViewDias.Tag;
            else
                dlg.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadDias(dlg.SelectedPath);
                labelDiaDirectory.Text = dlg.SelectedPath;
                listViewDias.Tag = dlg.SelectedPath;
            }
        }

        private void LoadDias(string searchDir)
        {
            if (Directory.Exists(searchDir))
            {
                listViewDias.Items.Clear();
                if (listViewDias.LargeImageList != null)
                {
                    listViewDias.LargeImageList.Dispose();
                }

                var imList = new ImageList
                {
                    ImageSize = Settings.Default.ThumbSize,
                    ColorDepth = ColorDepth.Depth32Bit
                };

                string[] extensions = { "*.jpg", "*.png", "*.bmp", "*.gif" };
                int i = 0;
                foreach (string ext in extensions)
                {
                    string[] filePaths = Directory.GetFiles(searchDir, ext, SearchOption.TopDirectoryOnly);
                    foreach (string file in filePaths)
                    {
                        var lvi = new ListViewItem(Path.GetFileNameWithoutExtension(file))
                        {
                            Tag = file,
                            ImageIndex = i,
                            Checked = true
                        };
                        listViewDias.Items.Add(lvi);
                        i++;
                    }
                    foreach (string file in filePaths)
                    {
                        Application.DoEvents();
                        imList.Images.Add(Image.FromFile(file));
                    }
                }
                listViewDias.LargeImageList = imList;
            }
        }

        private void buttonEnableAllDias_Click(object sender, EventArgs e)
        {
            if (listViewDias.Items.Count > 0)
            {
                foreach (ListViewItem lvi in listViewDias.Items)
                {
                    lvi.Checked = true;
                }
            }
        }

        private void buttonDisableAllDias_Click(object sender, EventArgs e)
        {
            if (listViewDias.Items.Count > 0)
            {
                foreach (ListViewItem lvi in listViewDias.Items)
                {
                    lvi.Checked = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_diaTimer != null && _diaTimer.Enabled)
            {
                _diaTimer.Stop();
                ProjectionManager.Instance.HideImage();
                buttonDiaShow.Text = StringResources.StartSlideshow;
                return;
            }

            if (listViewDias.Items.Count == 0)
            {
                MessageBox.Show(StringResources.NoImagesSelected, StringResources.Error);
                return;
            }
            buttonDiaShow.Text = StringResources.StopSlideshow;

            if (radioButtonAutoDiaShow.Checked)
            {
                int duration;
                try
                {
                    duration = int.Parse(textBoxDiaDuration.Text);
                }
                catch
                {
                    duration = 3;
                }
                duration = duration > 0 ? duration : 3;
                textBoxDiaDuration.Text = duration.ToString();

                _diaTimer = new Timer
                {
                    Interval = duration*1000
                };
                _diaTimer.Tick += diaTimer_Tick;

                var diaStack = new Queue<string>();
                foreach (ListViewItem lvi in listViewDias.Items)
                {
                    if (lvi.Checked)
                    {
                        diaStack.Enqueue((string)lvi.Tag);
                    }
                }
                if (diaStack.Count == 0)
                {
                    MessageBox.Show(StringResources.NoImagesSelected, StringResources.Error);
                    return;
                }
                _diaTimer.Tag = diaStack;
                ImageLayer iml = new ImageLayer(Settings.Default.ProjectionBackColor)
                {
                    Image = Image.FromFile(diaStack.Dequeue())
                };
                ProjectionManager.Instance.DisplayImage(iml, Settings.Default.ProjectionFadeTimeLayer1);
                _diaTimer.Start();
            }
        }

        private void diaTimer_Tick(object sender, EventArgs e)
        {
            if (((Queue<string>)((Timer)sender).Tag).Count == 0)
            {
                ((Timer)sender).Stop();
                ProjectionManager.Instance.HideImage();
                buttonDiaShow.Text = StringResources.StartSlideshow;
                return;
            }
            ImageLayer iml = new ImageLayer(Settings.Default.ProjectionBackColor)
            {
                Image = Image.FromFile(((Queue<string>) ((Timer) sender).Tag).Dequeue())
            };
            ProjectionManager.Instance.DisplayImage(iml, Settings.Default.ProjectionFadeTimeLayer1);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDiaDuration.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDiaDuration.Enabled = false;
        }

        private void listViewDirectoryImages_Leave(object sender, EventArgs e)
        {
            if (listViewDirectoryImages.SelectedIndices.Count > 0)
            {
                int idx = listViewDirectoryImages.SelectedIndices[0];
                listViewDirectoryImages.Items[idx].Selected = false;
            }
        }

        /// <summary>
        /// Show image from history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewImageHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewImageHistory.SelectedIndices.Count > 0)
            {
                Application.DoEvents();
                int idx = listViewImageHistory.SelectedIndices[0];

                // Stack
                if ((ModifierKeys & Keys.Control) == Keys.Control)
                {
                    listViewImageQueue.LargeImageList.Images.Add(
                        _imgManager.GetThumbFromRelPath((string)listViewImageHistory.Items[idx].Tag));
                    var lvi = new ListViewItem("")
                    {
                        Tag = listViewImageHistory.Items[idx].Tag,
                        ImageIndex = listViewImageQueue.LargeImageList.Images.Count - 1
                    };
                    listViewImageQueue.Items.Add(lvi);
                }
                else if ((ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    ImageFavoriteAdd((string)listViewImageHistory.Items[idx].Tag);
                }
                else
                {
                    if (
                        !(!_linkLayers ^
                          ((ModifierKeys & Keys.Shift) == Keys.Shift && _songManager.CurrentSong != null)))
                    {
                        ProjectionManager.Instance.HideText();
                    }

                    ImageLayer iml = new ImageLayer(Settings.Default.ProjectionBackColor)
                    {
                        Image = _imgManager.GetImageFromRelPath((string) listViewImageHistory.Items[idx].Tag)
                    };
                    ProjectionManager.Instance.DisplayImage(iml, Settings.Default.ProjectionFadeTimeLayer1);
                }
            }
        }

        private void buttonClearImageHistory_Click(object sender, EventArgs e)
        {
            listViewImageHistory.Items.Clear();
            listViewImageHistory.LargeImageList.Images.Clear();
            GC.Collect();
        }

        private void searchTextBoxImages_TextChanged(object sender, EventArgs e)
        {
            string needle = searchTextBoxImages.Text.ToLower().Trim();
            if (needle != String.Empty && needle.Length > 2)
            {
                treeViewImageDirectories.SelectedNode = null;
                _imageSearchResults.Clear();
                log.Debug("Search: "+ needle);
                foreach (string ims in _imgManager.SearchImages(needle))
                {
                    log.Debug("Found: " + ims);
                    _imageSearchResults.Add(ims);
                }
                treeViewImageDirectories.SelectedNode = treeViewImageDirectories.Nodes[treeViewImageDirectories.Nodes.Count - 1];
            }
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            AskIfSetlistShouldBeSaved(e);

            // Remember last active bible
            if (comboBoxBible.SelectedItem != null)
            {
                var bi = ((KeyValuePair<string, BibleManager.BibleItem>)comboBoxBible.SelectedItem);
                Settings.Default.LastActiveBible = bi.Value.Bible.Identifier;
            }

            Settings.Default.ViewerWindowState = WindowState;
            Settings.Default.MainWindowSize = Size;
            Settings.Default.AutoShowBibleVerse = checkBoxBibleAutoShowVerse.Checked;
            Settings.Default.ChromaKeyingEnabled = ProjectionManager.Instance.ChromaKeyingEnabled;
            Settings.Default.Save();

            ProjectionManager.Instance.Dispose();
        }

        private void datenverzeichnisOeffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.DataDirectory);
        }

        private void toolStripButtonDisplaySettings_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Settings.Default.DisplaySwitchCommand);
            }
            catch
            {
                Process.Start(Settings.Default.SystemControlCommand, Settings.Default.DisplayControlCommand);
            }
        }

        private void liederToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SongDir);
        }

        private void bilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(_imgManager.ImageDirPath);
        }

        private void setlistenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SetListDir);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SongBrowserDialog dlg = new SongBrowserDialog(_songManager)
            {
                Tags = Settings.Default.Tags
            };
            dlg.ShowDialog(this);
            if (dlg.SelectedAction == SongBrowserDialog.SongBrowseDialogAction.OpenInEditor && dlg.SelectedItems.Any())
            {
                foreach (var fn in dlg.SelectedItems)
                {
                    GetSongEditor().OpenSong(fn);
                }
                ShowAndBringSongEditorToFront();
            }
            else if (dlg.SelectedAction == SongBrowserDialog.SongBrowseDialogAction.LoadInSetList && dlg.SelectedItems.Any())
            {
                foreach (var fn in dlg.SelectedItems)
                {
                    AddSongToSetList(fn);
                }
            }
        }

        private void fehlerMeldenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.BugReportUrl);
        }

        private void praiseBoxDatenbankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSongImporter(ImportFormat.PraiseBox);
        }

        private void worToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSongImporter(ImportFormat.WorshipSystem);
        }

        private void OpenSongImporter(ImportFormat format)
        {
            var dlg = new SongImporter(Settings.Default, format);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                ReloadSongList();
                if (dlg.OpenInEditor.Any())
                {
                    foreach (var fn in dlg.OpenInEditor)
                    {
                        GetSongEditor().OpenSong(fn);
                    }
                    ShowAndBringSongEditorToFront();
                }
            }
        }

        private void miniaturbilderPrüfenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckThumbnails();
        }

        private void CheckThumbnails()
        {
            SimpleProgressWindow wnd = new SimpleProgressWindow(StringResources.Thumbnails);
            wnd.SetLabel(StringResources.CreatingThumbnails + "...");
            wnd.Show();

            BackgroundWorker bw = new BackgroundWorker();

            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;
                _imgManager.CheckThumbs(true);
            });

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate (object o, RunWorkerCompletedEventArgs args)
            {
                wnd.Close();
            });

            bw.RunWorkerAsync();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listViewImageQueue.Items.Clear();
            listViewImageQueue.LargeImageList.Images.Clear();
        }

        /// <summary>
        /// Show image from image queue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewImageQueue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewImageQueue.SelectedIndices.Count > 0)
            {
                Application.DoEvents();

                if (
                    !((ModifierKeys & Keys.Shift) == Keys.Shift && _songManager.CurrentSong != null))
                {
                    ProjectionManager.Instance.HideText();
                }

                int idx = listViewImageQueue.SelectedIndices[0];
                ImageLayer iml = new ImageLayer(Settings.Default.ProjectionBackColor)
                {
                    Image = _imgManager.GetImageFromRelPath((string) listViewImageQueue.Items[idx].Tag)
                };
                ProjectionManager.Instance.DisplayImage(iml, Settings.Default.ProjectionFadeTimeLayer1);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            _linkLayers = !_linkLayers;
            Settings.Default.LinkLayers = _linkLayers;
            Settings.Default.Save();
            SetLinkLayerUi();
        }

        private void SetLinkLayerUi()
        {
            buttonToggleLayerMode.Image = _linkLayers ? Resources.link : Resources.unlink;
        }

        private void listViewFavorites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFavorites.SelectedIndices.Count > 0)
            {
                Application.DoEvents();
                int idx = listViewFavorites.SelectedIndices[0];

                // Stack
                if ((ModifierKeys & Keys.Control) == Keys.Control)
                {
                    listViewImageQueue.LargeImageList.Images.Add(
                        _imgManager.GetThumbFromRelPath((string)listViewFavorites.Items[idx].Tag));
                    var lvi = new ListViewItem("")
                    {
                        Tag = listViewFavorites.Items[idx].Tag,
                        ImageIndex = listViewImageQueue.LargeImageList.Images.Count - 1
                    };
                    listViewImageQueue.Items.Add(lvi);
                }

                // ALT remove from favorites
                else if ((ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    ImageFavoriterRemove((string)listViewFavorites.Items[idx].Tag);
                    listViewFavorites.Items.RemoveAt(idx);
                }
                else
                {
                    if (
                        !(!_linkLayers ^
                           ((ModifierKeys & Keys.Shift) == Keys.Shift && _songManager.CurrentSong != null)))
                    {
                        ProjectionManager.Instance.HideText();
                    }
                    ImageLayer iml = new ImageLayer(Settings.Default.ProjectionBackColor)
                    {
                        Image = _imgManager.GetImageFromRelPath((string) listViewFavorites.Items[idx].Tag)
                    };
                    ProjectionManager.Instance.DisplayImage(iml);

                    // Add image to history
                    ImageHistoryAdd((string)listViewFavorites.Items[idx].Tag);
                }
            }
        }

        private void buttonShowLiveText_Click(object sender, EventArgs e)
        {
            String text = textBoxLiveText.SelectedText != String.Empty
                                 ? textBoxLiveText.SelectedText
                                 : textBoxLiveText.Text;

            // TODO Dedicated formatting for live text
            SlideTextFormatting slideFormatting = new SlideTextFormatting();
            ISlideTextFormattingMapper<Settings> mapper = new SettingsSlideTextFormattingMapper();
            mapper.Map(Settings.Default, ref slideFormatting);
            slideFormatting.ScaleFontSize = Settings.Default.ProjectionFontScaling;
            slideFormatting.SmoothShadow = Settings.Default.ProjectionSmoothShadow;
            
            slideFormatting.LineWrap = true;

            TextLayer lt = new TextLayer(slideFormatting)
            {
                MainText = text.Split(new[] {Environment.NewLine}, StringSplitOptions.None)
            };
            lt.DrawBordersForDebugging = Settings.Default.DebugMode;

            ProjectionManager.Instance.DisplayText(lt);
        }

        private void liedSuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerElementHighlight.Tag = songSearchTextBox;
            timerElementHighlight.Start();
            songSearchTextBox.Text = "";
            songSearchTextBox.Focus();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.HelpUrl);
        }

        private void timerSearchBoxHL_Tick(object sender, EventArgs e)
        {
            ((Control)((Timer)sender).Tag).BackColor = SystemColors.Window;
            ((Timer)sender).Stop();
        }

        private void bildschirmeSuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ProjectionManager.Instance.InitializeWindows())
            {
                MessageBox.Show(StringResources.NoSecondScreenFoundUsingMainScreen, StringResources.Projection, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void listViewFavorites_Leave(object sender, EventArgs e)
        {
            if (((ListView)sender).SelectedIndices.Count > 0)
            {
                ((ListView)sender).Items[((ListView)sender).SelectedIndices[0]].Selected = false;
            }
        }

        private void listViewImageHistory_Leave_1(object sender, EventArgs e)
        {
            if (((ListView)sender).SelectedIndices.Count > 0)
            {
                ((ListView)sender).Items[((ListView)sender).SelectedIndices[0]].Selected = false;
            }
        }

        private void trackBarFadeTime_Scroll(object sender, EventArgs e)
        {
            labelFadeTime.Text = (trackBarFadeTime.Value * 0.5) + @" s";
            Settings.Default.ProjectionFadeTime = trackBarFadeTime.Value * 500;
        }

        private void trackBarFadeTimeLayer1_Scroll(object sender, EventArgs e)
        {
            labelFadeTimeLayer1.Text = (trackBarFadeTimeLayer1.Value * 0.5) + @" s";
            Settings.Default.ProjectionFadeTimeLayer1 = trackBarFadeTimeLayer1.Value * 500;
        }

        private void listViewSongHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSongHistory.SelectedIndices.Count > 0)
            {
                var key = (string) listViewSongHistory.SelectedItems[0].Tag;
                _songManager.CurrentSong = _songManager.SongList[key];
                ShowCurrentSongDetails();
            }
        }

        #region Bible

        private int _bookIdx = -1, _chapterIdx = -1;
        private int _verseIdx = -1, _verseToIdx = -1;
        private int _chapterJumpIdx = -1, _verseJumpIdx = -1;
        BibleManager.BiblePassageSearchResult _biblePassageSearchResult;

        private void LoadBiblesInBackground()
        {
            var bThread = new Thread(loadBibles) { Name = "BibleLoader" };
            bThread.Start();
        }

        private void loadBibles()
        {
            if (comboBoxBible.Items.Count == 0)
            {
                _bibleManager.LoadBibleInfo();
                PopulateBibleList(_bibleManager);
            }
        }

        private void reloadBibles()
        {
            comboBoxBible.DataSource = null;
            _bibleManager.LoadBibleInfo();
            PopulateBibleList(_bibleManager);
        }

        delegate void SetTextCallback(BibleManager bibleManager);

        private void PopulateBibleList(BibleManager bibleManager)
        {
            if (comboBoxBible.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(PopulateBibleList);
                Invoke(d, new object[] { bibleManager });
            }
            else
            {
                comboBoxBible.Items.Clear();
                if (bibleManager.BibleList.Count > 0)
                {
                    comboBoxBible.DataSource = new BindingSource(bibleManager.BibleList, null);
                    comboBoxBible.DisplayMember = "Value";
                    comboBoxBible.ValueMember = "Key";

                    int idx = 0;
                    if (!string.IsNullOrEmpty(Settings.Default.LastActiveBible))
                    {
                        int i = 0;
                        foreach (var e in bibleManager.BibleList)
                        {
                            if (e.Key == Settings.Default.LastActiveBible)
                            {
                                idx = i;
                                break;
                            }
                            i++;
                        }
                    }
                    comboBoxBible.SelectedIndex = idx;
                }
            }
        }

        private void comboBoxBible_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewBibleVerses.Items.Clear();
            listBoxBibleChapter.Items.Clear();

            listBoxBibleBook.Items.Clear();
            listBoxBibleBook.DisplayMember = "Name";

            if (comboBoxBible.SelectedIndex >= 0)
            {
                var bi = ((KeyValuePair<string, BibleManager.BibleItem>)comboBoxBible.SelectedItem);
                if (bi.Value.Bible.Books == null)
                {
                    _bibleManager.LoadBibleData(bi.Key);
                }

                foreach (BibleBook bk in bi.Value.Bible.Books)
                {
                    listBoxBibleBook.Items.Add(bk);
                }

                if (_bookIdx >= 0 && _bookIdx < listBoxBibleBook.Items.Count)
                {
                    listBoxBibleBook.SelectedIndex = _bookIdx;
                }
            }

            searchTextBoxBible.Enabled = true;
        }

        private void listBoxBibleBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonBibleTextShow.Enabled = false;
            labelBibleTextName.Text = string.Empty;

            var bk = ((BibleBook)listBoxBibleBook.SelectedItem);
            if (bk == null)
            {
                return;
            }

            listViewBibleVerses.Items.Clear();

            listBoxBibleChapter.Items.Clear();
            listBoxBibleChapter.DisplayMember = "Number";

            foreach (BibleChapter cp in bk.Chapters)
            {
                listBoxBibleChapter.Items.Add(cp);
            }

            if (_chapterJumpIdx >= 0 && _chapterJumpIdx < listBoxBibleChapter.Items.Count)
            {
                listBoxBibleChapter.SelectedIndex = _chapterJumpIdx;
                _chapterJumpIdx = -1;
            }
            else if (_bookIdx == listBoxBibleBook.SelectedIndex && _chapterIdx >= 0 && listBoxBibleChapter.Items.Count > _chapterIdx)
            {
                listBoxBibleChapter.SelectedIndex = _chapterIdx;
            }

            _bookIdx = listBoxBibleBook.SelectedIndex;
        }

        private void listBoxBibleChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonBibleTextShow.Enabled = false;
            labelBibleTextName.Text = string.Empty;

            // Get number of selected chapter
            var cp = ((BibleChapter)listBoxBibleChapter.SelectedItem);
            if (cp == null)
            {
                return;
            }

            // Populate listview with verses from selected chapter
            listViewBibleVerses.Items.Clear();
            foreach (BibleVerse v in cp.Verses)
            {
                ListViewItem lvi = new ListViewItem(new string[]{v.Number.ToString(), v.Text});
                lvi.Tag = v;
                listViewBibleVerses.Items.Add(lvi);
            }

            if (_verseJumpIdx >= 0 && _verseJumpIdx < listViewBibleVerses.Items.Count)
            {
                listViewBibleVerses.SelectedIndices.Clear();
                listViewBibleVerses.SelectedIndices.Add(_verseJumpIdx);
                listViewBibleVerses.EnsureVisible(_verseJumpIdx);
                _verseJumpIdx = -1;
            }
            else if (_chapterIdx == listBoxBibleChapter.SelectedIndex && _verseIdx >= 0 && listViewBibleVerses.Items.Count > _verseIdx)
            {
                listViewBibleVerses.SelectedIndices.Clear();
                listViewBibleVerses.SelectedIndices.Add(_verseIdx);
                listViewBibleVerses.EnsureVisible(_verseIdx);
                buttonBibleTextShow.Enabled = true;
            }

            // Remember current chapter number
            _chapterIdx = listBoxBibleChapter.SelectedIndex;
        }

        private void listViewBibleVerses_Resize(object sender, EventArgs e)
        {
            // Resize verse text column so that it spans the width of the listview (minus the width of the verse number column)
            listViewBibleVerses.Columns[1].Width = listViewBibleVerses.ClientSize.Width - listViewBibleVerses.Columns[0].Width;
        }

        private void listViewBibleVerses_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedVersesCount = listViewBibleVerses.SelectedItems.Count;
            buttonBibleTextShow.Enabled = selectedVersesCount > 0;
            buttonAddToBibleVerseList.Enabled = selectedVersesCount > 0;
            if (selectedVersesCount > 0)
            {
                BibleVerse first = (BibleVerse)listViewBibleVerses.SelectedItems[0].Tag;
                BibleVerse last = (BibleVerse)listViewBibleVerses.SelectedItems[selectedVersesCount - 1].Tag;

                _verseIdx = first.Number - 1;
                _verseToIdx = last.Number - 1;

                BibleVerseSelection vs = new BibleVerseSelection(first, last);
                labelBibleTextName.Text = vs.ToString();

                if (checkBoxBibleAutoShowVerse.Checked)
                {
                    displayBibleVerseSelection(vs);
                }
            }
            else
            {
                labelBibleTextName.Text = string.Empty;
            }
        }

        private void buttonBibleTextShow_Click(object sender, EventArgs e)
        {
            int selectedVersesCount = listViewBibleVerses.SelectedItems.Count;
            if (selectedVersesCount == 0) return;

            BibleVerse first = (BibleVerse)listViewBibleVerses.SelectedItems[0].Tag;
            BibleVerse last = (BibleVerse)listViewBibleVerses.SelectedItems[selectedVersesCount - 1].Tag;
            BibleVerseSelection vs = new BibleVerseSelection(first, last);

            displayBibleVerseSelection(vs);
        }

        private void displayBibleVerseSelection(BibleVerseSelection vs)
        {
            BibleManager.BibleItem bibleItem = ((KeyValuePair<String, BibleManager.BibleItem>)comboBoxBible.SelectedItem).Value;
            List<string> copyrightItems = new List<string>
            {
                bibleItem.Bible.Title
            };
            if (!string.IsNullOrEmpty(bibleItem.Bible.Publisher)
                && bibleItem.Bible.Publisher != "nobody")
            {
                copyrightItems.Add(bibleItem.Bible.Publisher);
            }

            string title = vs.ToString();
            string text = vs.Text;

            // TODO Dedicated formatting for bible text
            SlideTextFormatting slideFormatting = new SlideTextFormatting();
            ISlideTextFormattingMapper<Settings> mapper = new SettingsSlideTextFormattingMapper();
            mapper.Map(Settings.Default, ref slideFormatting);
            slideFormatting.ScaleFontSize = Settings.Default.ProjectionFontScaling;
            slideFormatting.SmoothShadow = Settings.Default.ProjectionSmoothShadow;

            slideFormatting.LineWrap = true;

            TextLayer lt = new TextLayer(slideFormatting)
            {
                MainText = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None),
                HeaderText = new[] { title },
                FooterText = copyrightItems.ToArray()
            };
            lt.DrawBordersForDebugging = Settings.Default.DebugMode;

            ProjectionManager.Instance.DisplayText(lt);
        }

        private void buttonAddToBibleVerseList_Click(object sender, EventArgs e)
        {
            int selectedVersesCount = listViewBibleVerses.SelectedItems.Count;
            if (selectedVersesCount == 0) return;

            BibleVerse first = (BibleVerse)listViewBibleVerses.SelectedItems[0].Tag;
            BibleVerse last = (BibleVerse)listViewBibleVerses.SelectedItems[selectedVersesCount - 1].Tag;
            BibleVerseSelection vs = new BibleVerseSelection(first, last);

            var lvi = new ListViewItem(vs.ToString())
            {
                Tag = vs
            };
            listViewBibleVerseList.Items.Add(lvi);
            listViewBibleVerseList.Columns[0].Width = -2;
        }

        private void buttonRemoveFromBibleVerseList_Click(object sender, EventArgs e)
        {
            if (listViewBibleVerseList.SelectedItems.Count > 0)
            {
                listViewBibleVerseList.Items.RemoveAt(listViewBibleVerseList.SelectedIndices[0]);

                if (listViewBibleVerseList.Items.Count == 0)
                    buttonRemoveFromBibleVerseList.Enabled = false;

                listViewBibleVerseList.Columns[0].Width = -2;
            }
        }

        private void listViewBibleVerseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewBibleVerseList.SelectedItems.Count > 0)
            {
                var vs = (BibleVerseSelection)listViewBibleVerseList.SelectedItems[0].Tag;
                listBoxBibleBook.SelectedIndex = vs.Chapter.Book.Number - 1;
                listBoxBibleChapter.SelectedIndex = vs.Chapter.Number - 1;
                listViewBibleVerses.SelectedIndices.Clear();
                listViewBibleVerses.SelectedIndices.Add(vs.StartVerse.Number - 1);
                listViewBibleVerses.SelectedIndices.Add(vs.EndVerse.Number - vs.StartVerse.Number);
                buttonRemoveFromBibleVerseList.Enabled = true;

                if (checkBoxBibleShowVerseFromListDirectly.Checked)
                {
                    buttonBibleTextShow_Click(sender, e);
                }
            }
            else
                buttonRemoveFromBibleVerseList.Enabled = false;
        }

        private void searchTextBoxBible_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxBible.SelectedItem != null)
            {
                string needle = searchTextBoxBible.Text.Trim().ToLower();

                if (needle == string.Empty)
                {
                    labelBibleSearchMsg.ForeColor = Color.Black;
                    labelBibleSearchMsg.Text = "";
                }
                else
                {
                    BibleManager.BibleItem bibleItem = ((KeyValuePair<String,BibleManager.BibleItem>)comboBoxBible.SelectedItem).Value;

                    _biblePassageSearchResult = _bibleManager.SearchPassage(bibleItem.Bible, needle);
                    if (_biblePassageSearchResult.Status == BibleManager.BiblePassageSearchStatus.Found)
                    {
                        if (_biblePassageSearchResult.Passage.Book != null)
                        {
                            if (needle.Length < _biblePassageSearchResult.Passage.Book.Name.Length)
                            {
                                searchTextBoxBible.Text = _biblePassageSearchResult.Passage.Book.Name + " ";
                                searchTextBoxBible.Select(searchTextBoxBible.Text.Length, 0);
                            }

                            if (_biblePassageSearchResult.Passage.Book != null 
                                &&_biblePassageSearchResult.Passage.Chapter != null 
                                && _biblePassageSearchResult.Passage.Verse != null)
                            {
                                int bookIdx = _biblePassageSearchResult.Passage.Book.Number - 1;
                                int chapterIdx = _biblePassageSearchResult.Passage.Chapter.Number - 1;
                                int verseIdx = _biblePassageSearchResult.Passage.Verse.Number - 1;

                                if (listBoxBibleBook.SelectedIndex == bookIdx)
                                {
                                    if (listBoxBibleChapter.SelectedIndex == chapterIdx)
                                    {
                                        if (verseIdx < listViewBibleVerses.Items.Count)
                                        {
                                            listViewBibleVerses.SelectedIndices.Clear();
                                            listViewBibleVerses.SelectedIndices.Add(verseIdx);
                                            listViewBibleVerses.EnsureVisible(verseIdx);
                                        }
                                    }
                                    else
                                    {
                                        if (chapterIdx < listBoxBibleChapter.Items.Count)
                                        {
                                            _verseJumpIdx = verseIdx;
                                            listBoxBibleChapter.SelectedIndex = chapterIdx;
                                        }
                                    }
                                }
                                else
                                {
                                    if (bookIdx < listBoxBibleBook.Items.Count)
                                    {
                                        _chapterJumpIdx = chapterIdx;
                                        _verseJumpIdx = verseIdx;
                                        listBoxBibleBook.SelectedIndex = bookIdx;
                                    }
                                }
                            }

                        }

                        labelBibleSearchMsg.ForeColor = Color.Black;
                        labelBibleSearchMsg.Text = "";
                    }
                    else if (_biblePassageSearchResult.Status == BibleManager.BiblePassageSearchStatus.NotFound)
                    {
                        labelBibleSearchMsg.ForeColor = Color.Red;
                        labelBibleSearchMsg.Text = StringResources.NothingFound;
                    }
                    else
                    {
                        labelBibleSearchMsg.ForeColor = Color.Black;
                        labelBibleSearchMsg.Text = "";
                    }

                }
            }
        }

        #endregion Bible

        private void buttonToggleLayer2_Click(object sender, EventArgs e)
        {
            ProjectionManager.Instance.HideText();
        }

        private void buttonToggleLayer1_Click(object sender, EventArgs e)
        {
            ProjectionManager.Instance.HideImage();
        }

        private void titelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.SongSearchMode = SongSearchMode.Title;
            titelToolStripMenuItem.Checked = true;
            titelUndTextToolStripMenuItem.Checked = false;
            SearchSongs(songSearchTextBox.Text);
        }

        private void titelUndTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.SongSearchMode = SongSearchMode.TitleAndText;
            titelToolStripMenuItem.Checked = false;
            titelUndTextToolStripMenuItem.Checked = true;
            SearchSongs(songSearchTextBox.Text);
        }

        private void toolStripButtonDataFolder_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.DataDirectory);
        }

        private void toolStripButtonToggleTranslationText_Click(object sender, EventArgs e)
        {
            if (_songManager.CurrentSong != null)
            {
                if (_songManager.CurrentSong.SwitchTextAndTranlation)
                {
                    toolStripButtonToggleTranslationText.Image = Resources.translate;
                    _songManager.CurrentSong.SwitchTextAndTranlation = false;
                }
                else
                {
                    toolStripButtonToggleTranslationText.Image = Resources.translate_active;
                    _songManager.CurrentSong.SwitchTextAndTranlation = true;
                }
            }
        }

        private void openSongEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((listViewSongs.SelectedItems.Count > 0 || listViewSetList.SelectedItems.Count > 0) && _songManager.CurrentSong != null)
            {
                String fn = _songManager.CurrentSong.Filename;
                GetSongEditor().OpenSong(fn);
            }
            ShowAndFocusSongEditor();
        }

        private void qaSpellingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _songManager.CurrentSong.Song.QualityIssues.Set(SongQualityAssuranceIndicator.Spelling, qaSpellingToolStripMenuItem.Checked);
            if (SaveCurrentSong())
            {
                UpdateQaButtonState();
            }
        }

        private void qaTranslationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _songManager.CurrentSong.Song.QualityIssues.Set(SongQualityAssuranceIndicator.Translation, qaTranslationToolStripMenuItem.Checked);
            if (SaveCurrentSong())
            {
                UpdateQaButtonState();
            }
        }

        private void qaImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _songManager.CurrentSong.Song.QualityIssues.Set(SongQualityAssuranceIndicator.Images, qaImagesToolStripMenuItem.Checked);
            if (SaveCurrentSong())
            {
                UpdateQaButtonState();
            }
        }

        private void qaSegmentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _songManager.CurrentSong.Song.QualityIssues.Set(SongQualityAssuranceIndicator.Segmentation, qaSegmentationToolStripMenuItem.Checked);
            if (SaveCurrentSong())
            {
                UpdateQaButtonState();
            }
        }

        private bool SaveCurrentSong()
        {
            try
            {
                _songManager.SaveCurrentSong();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, StringResources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void UpdateQaButtonState()
        {
            if (_songManager.CurrentSong.Song.Comment != String.Empty || _songManager.CurrentSong.Song.QualityIssues.Any())
            {
                toolStripButtonQA.Image = Resources.highlight_red__36;
            }
            else
            {
                toolStripButtonQA.Image = Resources.highlight_36;
            }
        }

        /// <summary>
        /// Shows a dialog box for editing a song comment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qAcommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_songManager.CurrentSong != null)
            {
                CommentDialog qd = new CommentDialog
                {
                    Comment = _songManager.CurrentSong.Song.Comment
                };
                qd.ShowDialog(this);
                if (qd.DialogResult == DialogResult.OK)
                {
                    _songManager.CurrentSong.Song.Comment = qd.Comment;
                    if (SaveCurrentSong())
                    {
                        UpdateQaButtonState();
                    }
                }
            }
            else
            {
                MessageBox.Show(StringResources.NoActiveSong);
            }
        }

        private void splitContainerLayerContent_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Settings.Default.LayerContentSplitterPosition = splitContainerLayerContent.SplitterDistance;
        }

        private void songDetailElement_PreviousSongClicked(object sender, SongSwitchEventArgs e)
        {
            if (e.Song != null)
            {
                int idx = listViewSetList.SelectedIndices[0];
                if (idx > 0)
                {
                    listViewSetList.Items[idx - 1].Selected = true;
                    songDetailElement.Focus();
                }
            }
        }

        private void songDetailElement_NextSongClicked(object sender, SongSwitchEventArgs e)
        {
            if (e.Song != null)
            {
                int idx = listViewSetList.SelectedIndices[0];
                if (idx < listViewSetList.Items.Count - 1)
                {
                    listViewSetList.Items[idx + 1].Selected = true;
                    songDetailElement.Focus();
                }
            }
        }

        #region Setlist

        private void buttonSetListAdd_Click(object sender, EventArgs e)
        {
            if (listViewSongs.SelectedItems.Count > 0)
            {
                listViewSetList.Items.Add((ListViewItem)listViewSongs.SelectedItems[0].Clone());
                listViewSetList.Columns[0].Width = -2;
                buttonSetListClear.Enabled = true;
                buttonSaveSetList.Enabled = true;
            }
            else
            {
                buttonSetListAdd.Enabled = false;
            }
        }

        private void buttonSetListUp_Click(object sender, EventArgs e)
        {
            if (listViewSetList.SelectedIndices.Count > 0)
            {
                int idx = listViewSetList.SelectedIndices[0];
                if (idx > 0)
                {
                    ListViewItem lvi = listViewSetList.Items[idx];
                    listViewSetList.Items.RemoveAt(idx);
                    listViewSetList.Items.Insert(idx - 1, lvi);
                    listViewSetList.Items[idx - 1].Selected = true;
                }
            }
        }

        private void buttonSetListDown_Click(object sender, EventArgs e)
        {
            if (listViewSetList.SelectedIndices.Count > 0)
            {
                int idx = listViewSetList.SelectedIndices[0];
                if (idx < listViewSetList.Items.Count - 1)
                {
                    ListViewItem lvi = listViewSetList.Items[idx];
                    listViewSetList.Items.RemoveAt(idx);
                    listViewSetList.Items.Insert(idx + 1, lvi);
                    listViewSetList.Items[idx + 1].Selected = true;
                }
            }
        }

        private void buttonSetListRem_Click(object sender, EventArgs e)
        {
            if (listViewSetList.SelectedItems.Count > 0)
            {
                listViewSetList.Items.RemoveAt(listViewSetList.SelectedIndices[0]);
                buttonSetListRem.Enabled = false;
                buttonSetListDown.Enabled = false;
                buttonSetListUp.Enabled = false;
                if (listViewSetList.Items.Count == 0)
                {
                    buttonSaveSetList.Enabled = false;
                    buttonSetListClear.Enabled = false;
                }
            }
        }

        private void buttonOpenSetList_Click(object sender, EventArgs e)
        {
            ShowLoadSetListDialog();
        }

        /// <summary>
        /// Shows a dialog for loading a setlist
        /// </summary>
        private void ShowLoadSetListDialog()
        {
            string setlistDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SetListDir;
            if (!Directory.Exists(setlistDir))
            {
                Directory.CreateDirectory(setlistDir);
            }
            if (_currentSetlistFile != null && File.Exists(_currentSetlistFile))
            {
                setlistDir = Path.GetDirectoryName(_currentSetlistFile);
            }

            var dlg = new OpenFileDialog
            {
                AddExtension = true,
                CheckPathExists = true,
                CheckFileExists = true,
                Filter = GetSetListFileFilter(),
                InitialDirectory = setlistDir,
                Title = StringResources.OpenSetlist
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadSetList(dlg.FileName);
            }
        }

        /// <summary>
        /// Loads a setlist file if it exits
        /// </summary>
        /// <param name="setlistFile"></param>
        private void LoadSetListIfExists(string setlistFile)
        {
            if (!string.IsNullOrEmpty(setlistFile) && File.Exists(setlistFile))
            {
                LoadSetList(setlistFile);
            }
        }

        /// <summary>
        /// Loads a setlist from file
        /// </summary>
        /// <param name="fileName"></param>
        private void LoadSetList(string fileName)
        {
            SetlistReader sr = new SetlistReader();
            try
            {
                listViewSetList.Items.Clear();

                Setlist sl = sr.read(fileName);
                if (sl.Items.Count > 0)
                {
                    foreach (var i in sl.Items)
                    {
                        var key = _songManager.GetKeyByTitle(i);
                        if (key != null)
                        {
                            var s = _songManager.SongList[key].Song;
                            var lvi = new ListViewItem(s.Title)
                            {
                                Tag = key
                            };
                            listViewSetList.Items.Add(lvi);
                        }
                    }
                    buttonSetListClear.Enabled = true;
                    buttonSaveSetList.Enabled = true;
                    listViewSetList.Columns[0].Width = -2;
                }

                // Save hashcode
                _currentSetListHashCode = GeCurrentSetListtHashCode();

                // Save name of current setlist file
                SetCurrentSetListFile(fileName);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Adds a song to the setlist
        /// </summary>
        /// <param name="key"></param>
        private void AddSongToSetList(string key)
        {
            if (_songManager.SongList.ContainsKey(key))
            {
                var s = _songManager.SongList[key].Song;
                var lvi = new ListViewItem(s.Title)
                {
                    Tag = key
                };
                listViewSetList.Items.Add(lvi);

                buttonSetListClear.Enabled = true;
                buttonSaveSetList.Enabled = true;
                listViewSetList.Columns[0].Width = -2;
            }
        }

        private void buttonSaveSetList_Click(object sender, EventArgs e)
        {
            ShowSaveSetlistDialog();
        }

        /// <summary>
        /// Shows a dialog for saving the current setlist
        /// </summary>
        /// <returns></returns>
        private DialogResult ShowSaveSetlistDialog()
        {
            // Define directory, use directory of current setlist file if available
            string setlistDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SetListDir;
            if (!Directory.Exists(setlistDir))
            {
                Directory.CreateDirectory(setlistDir);
            }
            if (_currentSetlistFile != null && File.Exists(_currentSetlistFile))
            {
                setlistDir = Path.GetDirectoryName(_currentSetlistFile);
            }

            // Define proposed filename, use current setlist file if available
            var proposedFileName = _currentSetlistFile != null ? Path.GetFileName(_currentSetlistFile) : GetSetListDefaultName();

            var dlg = new SaveFileDialog
            {
                AddExtension = true,
                CheckPathExists = true,
                Filter = GetSetListFileFilter(),
                InitialDirectory = setlistDir,
                Title = StringResources.SaveSetlistAs,
                FileName = proposedFileName
            };
            var dlgRes = dlg.ShowDialog();
            if (dlgRes == DialogResult.OK)
            {
                SaveSetList(dlg.FileName);
            }
            return dlgRes;
        }

        private string GetSetListDefaultName()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        private string GetSetListFileFilter()
        {
            return String.Format("{0} (*.{1})|*.{1}", StringResources.SetlistFile, SetlistWriter.FileExtension);
        }

        /// <summary>
        /// Saves the current setlist
        /// </summary>
        /// <param name="filename">Target file name</param>
        private void SaveSetList(string filename)
        {
            Setlist sl = new Setlist();
            for (int i = 0; i < listViewSetList.Items.Count; i++)
            {
                var tag = (string) listViewSetList.Items[i].Tag;
                var song = _songManager.SongList[tag].Song;
                sl.Items.Add(song.Title);
            }
            SetlistWriter swr = new SetlistWriter();
            swr.Write(filename, sl);

            // Save hashcode
            _currentSetListHashCode = GeCurrentSetListtHashCode();

            // Save name of current setlist file
            SetCurrentSetListFile(filename);
        }

        /// <summary>
        /// Gets a hash code of the currently loaded setlist
        /// </summary>
        /// <returns></returns>
        private int GeCurrentSetListtHashCode()
        {
            int hash = 19;
            for (int i = 0; i < listViewSetList.Items.Count; i++)
            {
                var tag = (string)listViewSetList.Items[i].Tag;
                var song = _songManager.SongList[tag].Song;
                hash = hash * 31 + song.GetHashCode();
            }
            return hash;
        }

        private void buttonSetListClear_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(StringResources.ReallyEmptySetlist, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                ClearSetList();
            }
        }

        /// <summary>
        /// Clears the setlist, removes all items and resets button states
        /// </summary>
        private void ClearSetList()
        {
            listViewSetList.Items.Clear();
            buttonSetListRem.Enabled = false;
            buttonSetListClear.Enabled = false;
            buttonSaveSetList.Enabled = false;
            buttonSetListDown.Enabled = false;
            buttonSetListUp.Enabled = false;

            // Reset setlist hash code
            _currentSetListHashCode = 0;

            // Reset name of current setlist file
            SetCurrentSetListFile(null);
        }

        /// <summary>
        /// If setlist contains items, ask if the list should be saved
        /// </summary>
        /// <param name="e"></param>
        private void AskIfSetlistShouldBeSaved(FormClosingEventArgs e)
        {
            if (listViewSetList.Items.Count > 0 && _currentSetListHashCode != GeCurrentSetListtHashCode())
            {
                var res = MessageBox.Show(StringResources.ShouldCurrentSetlistBeSaved, Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (ShowSaveSetlistDialog() == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
                else if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void SetCurrentSetListFile(string setListFile)
        {
            if (!String.IsNullOrEmpty(setListFile))
            {
                Text = _originalFormTitle + @" - [" + Path.GetFileNameWithoutExtension(setListFile) + @"]";
            }
            else
            {
                Text = _originalFormTitle;
            }
            _currentSetlistFile = setListFile;
        }

        #endregion

        private void buttonToggleSongViewMode_Click(object sender, EventArgs e)
        {
            UpdatePresenterSongViewModeButtons(SongViewMode.Structure);
            UpdatePresenterSongViewMode(SongViewMode.Structure);
        }

        private void toolStripMenuItemLogFile_Click(object sender, EventArgs e)
        {
            string logfile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\praisebase.log";
            TextFileViewer viewer = new TextFileViewer();
            viewer.FilePath = logfile;
            viewer.ShowDialog(this);
        }

        private void cCLISongSelectDateiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoImportSong();
        }

        private void Importer_SongSaved(object sender, SongSavedEventArgs e)
        {
            UpdateSongListItem(e.FileName);
        }

        private void toolStripButtonImportFile_Click(object sender, EventArgs e)
        {
            DoImportSong();
        }

        private void DoImportSong()
        {
            try
            {
                SongFileImporter importer = new SongFileImporter(Settings.Default);
                importer.SongSaved += Importer_SongSaved;
                importer.ImportDialog(this);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, StringResources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxWebVideoID_TextChanged(object sender, EventArgs e)
        {
            buttonPlayWebVideo.Enabled = textBoxWebVideoID.Text.Length > 0;
        }

        private void buttonPlayWebVideo_Click(object sender, EventArgs e)
        {
            string videoID = textBoxWebVideoID.Text;
            Uri uri = null;

            // YouTube
            if ((WebVideoService)comboBoxWebVideoService.SelectedItem == WebVideoService.YouTube)
            {
                // See API documentation at https://developers.google.com/youtube/player_parameters
                uri = new Uri("https://www.youtube.com/embed/" + videoID + "?autoplay=1&controls=0&modestbranding=1&rel=0&showinfo=0");
            }
            // Vimeo
            if ((WebVideoService)comboBoxWebVideoService.SelectedItem == WebVideoService.Vimeo)
            {
                // See API documentation at https://developer.vimeo.com/player/embedding
                uri = new Uri("https://player.vimeo.com/video/" + videoID + "?autoplay=1&badge=0&byline=0&portrait=0&title=0&api=0&player_id=praisebasepresenter");
            }

            if (uri != null)
            {
                buttonStopWebVideo.Enabled = true;
                ProjectionManager.Instance.DisplayWebsite(uri);
            }
        }

        private void buttonStopWebVideo_Click(object sender, EventArgs e)
        {
            buttonStopWebVideo.Enabled = false;
            ProjectionManager.Instance.HideWebsite();
        }

        private void comboBoxWebVideoService_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxWebVideoID.Focus();
        }

        private void toolStripMenuItemChromaKeying_Click(object sender, EventArgs e)
        {
            ToggleChromaKeying(!toolStripMenuItemChromaKeying.Checked);
        }

        private void ToggleChromaKeying(bool enable)
        {
            ProjectionManager.Instance.ChromaKeyingEnabled = enable;
            toolStripButtonChromaKeying.Checked = enable;
            toolStripMenuItemChromaKeying.Checked = enable;
        }

        private void toolStripMenuItemImportText_Click(object sender, EventArgs e)
        {
            TextImportDialog dlg = new TextImportDialog(Settings.Default);
            DialogResult result = dlg.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                OpenSongInSongEditor(dlg.ImportedSong);
            }
        }

        private void toolStripButtonImportFile_ButtonClick(object sender, EventArgs e)
        {
            toolStripMenuItemImportText_Click(sender, e);
        }

        private void toolStripMenuItemSongStatistics_Click(object sender, EventArgs e)
        {
            SongStatsticsViewer window = new SongStatsticsViewer(_songManager);
            window.Show();
        }

        private void toolStripMenuItemMetadataEditor_Click(object sender, EventArgs e)
        {
            SongMetadataEditor window = new SongMetadataEditor(_songManager);
            window.ShowDialog(this);
            LoadSongList();
        }

        private void buttonSongViewModeSequence_Click(object sender, EventArgs e)
        {
            UpdatePresenterSongViewModeButtons(SongViewMode.Sequence);
            UpdatePresenterSongViewMode(SongViewMode.Sequence);
        }

        private void UpdatePresenterSongViewModeButtons(SongViewMode mode)
        {
            if (mode == SongViewMode.Sequence)
            {
                buttonSongViewModeStructure.BackColor = Color.White;
                buttonSongViewModeSequence.BackColor = Color.LightGray;
            }
            else if (mode == SongViewMode.Structure)
            {
                buttonSongViewModeStructure.BackColor = Color.LightGray;
                buttonSongViewModeSequence.BackColor = Color.White;
            }
            songDetailElement.SongViewMode = mode;

            if (_songManager.CurrentSong != null)
            {
                ShowCurrentSongDetails();
            }
        }

        private void UpdatePresenterSongViewMode(SongViewMode mode)
        {
            Settings.Default.PresenterSongViewMode = mode;
            Settings.Default.Save();
        }

    }
}