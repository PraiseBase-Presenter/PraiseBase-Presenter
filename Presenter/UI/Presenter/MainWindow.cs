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
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using PraiseBase.Presenter.Properties;
using SongDetails;
using Timer = System.Windows.Forms.Timer;
using PraiseBase.Presenter.Manager;
using System.Globalization;
using PraiseBase.Presenter.UI;
using PraiseBase.Presenter.Model.Bible;
using PraiseBase.Presenter.Persistence.Setlists;
using PraiseBase.Presenter.Projection;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Forms
{
    /// <summary>
    /// The main window class provides the central
    /// gui of this software, including the songlist,
    /// setlist, imagelist and the diashow interface.
    /// </summary>
    public partial class MainWindow : LocalizableForm
    {
        private static MainWindow _instance;
        private static readonly object singletonPadlock = new object();

        private Timer diaTimer;
        private List<String> imageSearchResults;

        private bool linkLayers = true;

        /// <summary>
        /// Private constructor
        /// </summary>
        private MainWindow()
        {
            InitializeComponent();

            this.Size = Settings.Default.MainWindowSize;
            
            base.registerChild(this);
        }

        /// <summary>
        /// Returns a singleton of mainWindow
        /// </summary>
        /// <returns>Returns the mainWindow instance</returns>
        public static MainWindow Instance
        {
            get
            {
                // Thread safety
                lock (singletonPadlock)
                {
                    return _instance ?? (_instance = new MainWindow());
                }
            }
        }

        /// <summary>
        /// Initializes some basic form stuff
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            var newThread = new Thread(UpdateCheck.DoCheck) { Name = "UpdateChecker" };
            newThread.Start();

            var bThread = new Thread(loadBibles) { Name = "BibleLoader" };
            bThread.Start();

            WindowState = Settings.Default.ViewerWindowState;
            //Text += " " + Assembly.GetExecutingAssembly().GetName().Version;

            loadSongList();

            imageTreeViewInit();

            trackBarFadeTime.Value = Settings.Default.ProjectionFadeTime / 500;
            labelFadeTime.Text = (trackBarFadeTime.Value * 0.5) + " s";

            trackBarFadeTimeLayer1.Value = Settings.Default.ProjectionFadeTimeLayer1 / 500;
            labelFadeTimeLayer1.Text = (trackBarFadeTimeLayer1.Value * 0.5) + " s";

            linkLayers = Settings.Default.LinkLayers;
            setLinkLayerUI();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            numericUpDown1.Value = (int)Settings.Default.ProjectionMasterFont.Size;

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

            ProjectionManager.Instance.ProjectionChanged += Instance_ProjectionChanged;
        }

        void selectLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage((CultureInfo)((ToolStripMenuItem)sender).Tag);
            foreach (ToolStripMenuItem i in this.spracheToolStripMenuItem.DropDownItems)
            {
                i.Checked = ((CultureInfo)i.Tag == System.Threading.Thread.CurrentThread.CurrentUICulture);
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
            var ab = new AboutDialog();
            ab.ShowDialog(this);
        }

        private void songSearchBox_TextChanged(object sender, EventArgs e)
        {
            searchSongs(songSearchTextBox.Text);
        }

        /**
         * Load Songs
         */

        private void loadSongList()
        {
            searchSongs("");
        }

        private void searchSongs(string needle)
        {
            listViewSongs.BeginUpdate();
            listViewSongs.SuspendLayout();
            listViewSongs.Items.Clear();
            int cnt = 0;

            var lviList = new List<ListViewItem>();
            foreach (SongManager.SongItem si in SongManager.Instance.GetSearchResults(needle, Settings.Default.SongSearchMode))
            {
                var lvi = new ListViewItem(si.Song.Title);
                lvi.Tag = si.Song.GUID;
                lviList.Add(lvi);
                cnt++;
            }
            listViewSongs.Items.AddRange(lviList.ToArray());

            if (cnt == 1 && listViewSongs.Items.Count > 0)
            {
                try
                {
                    listViewSongs.Items[0].Selected = true;
                    SongManager.Instance.CurrentSong = SongManager.Instance.SongList[(Guid)listViewSongs.SelectedItems[0].Tag];
                    showCurrentSongDetails();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Song search exception: " + e.ToString());
                }
            }
            listViewSongs.Columns[0].Width = -2;
            listViewSongs.ResumeLayout();
            listViewSongs.EndUpdate();
        }

        private void radioSongSearchAll_CheckedChanged(object sender, EventArgs e)
        {
            searchSongs(songSearchTextBox.Text);
        }

        private void toggleProjection(object sender, EventArgs e)
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
            new ProgramSettingsDialog().ShowDialog(this);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            new ProgramSettingsDialog().ShowDialog(this);
        }

        private void liederlisteNeuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadSongList();
        }

        private void reloadSongList()
        {
            songSearchTextBox.Text = "";
            SongManager.Instance.Reload();
            loadSongList();

            for (int i = 0; i < listViewSetList.Items.Count; i++)
            {
                Guid g = SongManager.Instance.GetGuidByTitle(listViewSetList.Items[i].Text);
                if (g != Guid.Empty)
                {
                    listViewSetList.Items[i].Tag = g;
                }
                else
                {
                    MessageBox.Show(String.Format(StringResources.SongDoesNotExist, listViewSetList.Items[i].Text));
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
                    if (SongManager.Instance.CurrentSong == null || SongManager.Instance.CurrentSong.Song == null || SongManager.Instance.CurrentSong.Song.GUID != (Guid)listViewSongs.SelectedItems[0].Tag)
                    {
                        var g = (Guid)listViewSongs.SelectedItems[0].Tag;
                        if (SongManager.Instance.SongList.ContainsKey(g))
                        {
                            SongManager.Instance.CurrentSong = SongManager.Instance.SongList[g];
                            showCurrentSongDetails();
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
                if (SongManager.Instance.CurrentSong == null ||
                    SongManager.Instance.CurrentSong.Song.GUID != (Guid)listViewSongs.SelectedItems[0].Tag)
                {
                    SongManager.Instance.CurrentSong = SongManager.Instance.SongList[(Guid)listViewSongs.SelectedItems[0].Tag];
                    showCurrentSongDetails();

                    buttonSetListAdd.Enabled = true;
                }
            }
        }

        private void listViewSetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSetList.SelectedIndices.Count > 0)
            {
                if (tabControlTextLayer.SelectedIndex != 0)
                    tabControlTextLayer.SelectedIndex = 0;

                int idx = listViewSetList.SelectedIndices[0];
                if (idx > 0)
                    buttonSetListUp.Enabled = true;
                else
                    buttonSetListUp.Enabled = false;
                if (idx < listViewSetList.Items.Count - 1)
                    buttonSetListDown.Enabled = true;
                else
                    buttonSetListDown.Enabled = false;
                buttonSetListRem.Enabled = true;

                SongManager.Instance.CurrentSong = SongManager.Instance.SongList[(Guid)listViewSetList.SelectedItems[0].Tag];
                showCurrentSongDetails();
            }
        }

        private void showCurrentSongDetails()
        {
            Application.DoEvents();

            label3.Text = SongManager.Instance.CurrentSong.Song.Title;
            songDetailElement.setSong(SongManager.Instance.CurrentSong.Song);

            toolStripButtonQA.Enabled = true;
            updateQAButtonStage();
            qaSpellingToolStripMenuItem.Checked = SongManager.Instance.CurrentSong.Song.GetQA(SongQualityAssuranceIndicator.Spelling);
            qaTranslationToolStripMenuItem.Checked = SongManager.Instance.CurrentSong.Song.GetQA(SongQualityAssuranceIndicator.Translation);
            qaImagesToolStripMenuItem.Checked = SongManager.Instance.CurrentSong.Song.GetQA(SongQualityAssuranceIndicator.Images);
            qaSegmentationToolStripMenuItem.Checked = SongManager.Instance.CurrentSong.Song.GetQA(SongQualityAssuranceIndicator.Segmentation);

            if (SongManager.Instance.CurrentSong.Song.HasTranslation)
            {
                toolStripButtonToggleTranslationText.Enabled = true;
                if (SongManager.Instance.CurrentSong.SwitchTextAndTranlation)
                {
                    toolStripButtonToggleTranslationText.Image = Properties.Resources.translate_active;
                }
                else
                {
                    toolStripButtonToggleTranslationText.Image = Properties.Resources.translate;
                }
            }
            else
            {
                toolStripButtonToggleTranslationText.Enabled = false;
                toolStripButtonToggleTranslationText.Image = Properties.Resources.translate;
            }
        }

        private void songDetailElement_SlideClicked(object sender, SlideClickEventArgs e)
        {
            Application.DoEvents();

            var s = SongManager.Instance.CurrentSong.Song;

            if (listViewSongHistory.Items.Count == 0 ||
                (Guid)listViewSongHistory.Items[0].Tag != s.GUID)
            {
                var lvi = new ListViewItem(s.Title);
                lvi.Tag = s.GUID;
                listViewSongHistory.Items.Insert(0, lvi);
                listViewSongHistory.Columns[0].Width = -2;
            }

            PraiseBase.Presenter.Model.Song.SongSlide cs = s.Parts[e.PartNumber].Slides[e.SlideNumber];

            SlideTextFormatting slideFormatting = new SlideTextFormatting();

            AdditionalInformationPosition sourcePosition;
            AdditionalInformationPosition copyrightPosition;

            // Formatting based on master styling
            if (Settings.Default.ProjectionUseMaster)
            {
                SongSlideTextFormattingMapper.Map(Settings.Default, ref slideFormatting);
                sourcePosition = Settings.Default.ProjectionMasterSourcePosition;
                copyrightPosition = Settings.Default.ProjectionMasterCopyrightPosition;
            }
            // Formatting based on song settings
            else
            {
                SongSlideTextFormattingMapper.Map(s, ref slideFormatting);
                sourcePosition = s.SourcePosition;
                copyrightPosition = s.CopyrightPosition;
            }
            slideFormatting.ScaleFontSize = Settings.Default.ProjectionFontScaling;
            slideFormatting.SmoothShadow = Settings.Default.ProjectionSmoothShadow;

            var ssl = new SongSlideLayer(slideFormatting);

            // Set text and translation (based on translation switch state)
            if (cs.Translated && SongManager.Instance.CurrentSong.SwitchTextAndTranlation)
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
            if (sourcePosition == AdditionalInformationPosition.FirstSlide && isFirstSlide(e.PartNumber, e.SlideNumber) ||
                sourcePosition == AdditionalInformationPosition.LastSlide && isLastSlide(s, e.PartNumber, e.SlideNumber))
            {
                ssl.HeaderText = new String[] { s.SongBooksString };
            }

            // Set footer text (copyright)
            if (copyrightPosition == AdditionalInformationPosition.FirstSlide && isFirstSlide(e.PartNumber, e.SlideNumber) ||
                copyrightPosition == AdditionalInformationPosition.LastSlide && isLastSlide(s, e.PartNumber, e.SlideNumber))
            {
                ssl.FooterText = s.Copyright.Split(new String[] { Environment.NewLine }, StringSplitOptions.None);
            }

            // CTRL pressed, use image stack
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (listViewImageQueue.Items.Count > 0)
                {
                    ImageLayer iml = new ImageLayer();
                    iml.Image = ImageManager.Instance.GetImageFromRelPath((string)listViewImageQueue.Items[0].Tag);
                    ProjectionManager.Instance.DisplayLayer(1, iml, Settings.Default.ProjectionFadeTimeLayer1);
                    ProjectionManager.Instance.DisplayLayer(2, ssl);
                    imageHistoryAdd((string)listViewImageQueue.Items[0].Tag);
                    listViewImageQueue.Items[0].Remove();
                }
                else
                {
                    ProjectionManager.Instance.DisplayLayer(2, ssl);
                }
            }

                // SHIFT pressed, use current slide
            else if (!linkLayers ^ ((ModifierKeys & Keys.Shift) == Keys.Shift))
            {
                ProjectionManager.Instance.DisplayLayer(2, ssl);
            }

                // Current slide + attached image
            else
            {
                ImageLayer iml = new ImageLayer();
                iml.Image = ImageManager.Instance.GetImage(s.GetImage(cs.ImageNumber));
                ProjectionManager.Instance.DisplayLayer(1, iml, Settings.Default.ProjectionFadeTimeLayer1);
                ProjectionManager.Instance.DisplayLayer(2, ssl);

                if (s.RelativeImagePaths.Count > 0)
                    imageHistoryAdd(s.RelativeImagePaths[cs.ImageNumber]);
            }
        }

        private bool isFirstSlide(int partNumber, int slideNumber)
        {
            return partNumber == 0 && slideNumber == 0;
        }

        private bool isLastSlide(Song s, int partNumber, int slideNumber)
        {
            return partNumber == s.Parts.Count - 1 && slideNumber == s.Parts[partNumber].Slides.Count - 1;
        }

        private void songDetailElement_ImageClicked(object sender, SlideImageClickEventArgs e)
        {
            Application.DoEvents();

            // Stack
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                listViewImageQueue.LargeImageList.Images.Add(ImageManager.Instance.GetThumbFromRelPath(e.relativePath));
                var lvi = new ListViewItem("");
                lvi.Tag = e.relativePath;
                lvi.ImageIndex = listViewImageQueue.LargeImageList.Images.Count - 1;
                listViewImageQueue.Items.Add(lvi);
            }

            // Favorite
            else if ((ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                imageFavoriteAdd(e.relativePath);
            }
            else
            {
                // Hide text if layers are linked OR shift is pressed and the layers are not linked
                if (!(!linkLayers ^ ((ModifierKeys & Keys.Shift) == Keys.Shift)))
                {
                    ProjectionManager.Instance.HideLayer(2);
                }

                // Show image
                ImageLayer iml = new ImageLayer();
                iml.Image = ImageManager.Instance.GetImageFromRelPath(e.relativePath);
                ProjectionManager.Instance.DisplayLayer(1, iml, Settings.Default.ProjectionFadeTimeLayer1);

                if (e.relativePath != String.Empty)
                    imageHistoryAdd(e.relativePath);
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
        }

        private void webToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.Weburl);
        }

        public void imageTreeViewInit()
        {
            string rootDir = ImageManager.Instance.ImageDirPath;
            treeViewImageDirectories.Nodes.Clear();
            PopulateTreeView(rootDir, null);
            treeViewImageDirectories.ExpandAll();
            treeViewImageDirectories.Nodes.Add(StringResources.SearchResults);
            treeViewImageDirectories.SelectedNode = treeViewImageDirectories.Nodes[0];

            imageSearchResults = new List<String>();

            var iml = new ImageList();
            iml.ImageSize = Settings.Default.ThumbSize;
            iml.ColorDepth = ColorDepth.Depth32Bit;
            listViewImageHistory.LargeImageList = iml;
            listViewImageHistory.TileSize = new Size(Settings.Default.ThumbSize.Width + 8,
                                                     Settings.Default.ThumbSize.Height + 5);

            var iml2 = new ImageList();
            iml2.ImageSize = Settings.Default.ThumbSize;
            iml2.ColorDepth = ColorDepth.Depth32Bit;
            listViewImageQueue.LargeImageList = iml2;
            listViewImageQueue.TileSize = new Size(Settings.Default.ThumbSize.Width + 8,
                                                   Settings.Default.ThumbSize.Height + 5);

            if (Settings.Default.ImageFavorites == null)
                Settings.Default.ImageFavorites = new ArrayList();

            var iml3 = new ImageList();
            iml3.ImageSize = Settings.Default.ThumbSize;
            iml3.ColorDepth = ColorDepth.Depth32Bit;
            listViewFavorites.LargeImageList = iml3;
            listViewFavorites.TileSize = new Size(Settings.Default.ThumbSize.Width + 8,
                                                  Settings.Default.ThumbSize.Height + 5);

            foreach (string relImagePath in Settings.Default.ImageFavorites)
            {
                listViewFavorites.LargeImageList.Images.Add(ImageManager.Instance.GetThumbFromRelPath(relImagePath));
                var lvi = new ListViewItem("");
                lvi.Tag = relImagePath;
                lvi.ImageIndex = listViewFavorites.LargeImageList.Images.Count - 1;
                listViewFavorites.Items.Add(lvi);
                listViewFavorites.EnsureVisible(listViewFavorites.Items.Count - 1);
            }
            tabPageImageFavorites.Text = StringResources.Favorites + " (" + Settings.Default.ImageFavorites.Count + ")";
        }

        public void PopulateTreeView(string directoryValue, TreeNode parentNode)
        {
            try
            {
                if (Directory.Exists(directoryValue))
                {
                    if (parentNode == null)
                    {
                        var myNode = new TreeNode(Properties.StringResources.TopDirectory);
                        myNode.Tag = "";
                        treeViewImageDirectories.Nodes.Add(myNode);
                        parentNode = myNode;
                    }

                    string[] directoryArray =
                        Directory.GetDirectories(directoryValue);

                    if (directoryArray.Length != 0)
                    {
                        int subLen = (ImageManager.Instance.ImageDirPath + Path.DirectorySeparatorChar).Length;
                        foreach (string directory in directoryArray)
                        {
                            string dName = Path.GetFileName(directory);
                            if (dName.Substring(0, 1) != "[" && dName.Substring(0, 1) != ".")
                            {
                                var myNode = new TreeNode(dName);

                                myNode.Tag = directory.Substring(subLen);
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
                    var imList = new ImageList();
                    imList.ImageSize = Settings.Default.ThumbSize;
                    imList.ColorDepth = ColorDepth.Depth32Bit;

                    var lviList = new List<ListViewItem>();

                    string pathPrefix = ImageManager.Instance.ThumbDirPath + Path.DirectorySeparatorChar;
                    int i = 0;

                    foreach (string file in imageSearchResults)
                    {
                        var lvi = new ListViewItem(Path.GetFileNameWithoutExtension(file));
                        lvi.Tag = file;
                        lvi.ImageIndex = i;
                        imList.Images.Add(Image.FromFile(pathPrefix + file));
                        lviList.Add(lvi);
                        i++;
                    }
                    listViewDirectoryImages.Items.AddRange(lviList.ToArray());
                    listViewDirectoryImages.LargeImageList = imList;

                    labelImgDirName.Text = StringResources.SearchResults + " (" + i + " " + StringResources.Images + ")";
                }
                else
                {
                    string relativeImageDir = ((string)treeViewImageDirectories.SelectedNode.Tag) + Path.DirectorySeparatorChar;
                    string imDir = ImageManager.Instance.ThumbDirPath + Path.DirectorySeparatorChar + relativeImageDir;

                    if (Directory.Exists(imDir))
                    {
                        var imList = new ImageList();
                        imList.ImageSize = Settings.Default.ThumbSize;
                        imList.ColorDepth = ColorDepth.Depth32Bit;

                        string[] songFilePaths = Directory.GetFiles(imDir, "*.jpg", SearchOption.TopDirectoryOnly);
                        int i = 0;
                        foreach (string file in songFilePaths)
                        {
                            var lvi = new ListViewItem(Path.GetFileNameWithoutExtension(file));
                            lvi.Tag = relativeImageDir + Path.GetFileName(file);
                            lvi.ImageIndex = i;
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

                        labelImgDirName.Text = categoryName + "' (" + i + " " + StringResources.Images + "):";
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
                        ImageManager.Instance.GetThumbFromRelPath((string)listViewDirectoryImages.Items[idx].Tag));
                    var lvi = new ListViewItem("");
                    lvi.Tag = listViewDirectoryImages.Items[idx].Tag;
                    lvi.ImageIndex = listViewImageQueue.LargeImageList.Images.Count - 1;
                    listViewImageQueue.Items.Add(lvi);

                    //listViewImageQueue.EnsureVisible(listViewImageHistory.Items.Count - 1);
                }

                // Favorite
                else if ((ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    imageFavoriteAdd((string)listViewDirectoryImages.Items[idx].Tag);
                }
                else
                {
                    // Linked layers
                    if (
                        !(!linkLayers ^
                           ((ModifierKeys & Keys.Shift) == Keys.Shift && SongManager.Instance.CurrentSong != null &&
                            SongManager.Instance.CurrentSong.Song.CurrentSlide >= 0)))
                    {
                        ProjectionManager.Instance.HideLayer(2, Settings.Default.ProjectionFadeTime);
                    }

                    ImageLayer iml = new ImageLayer();
                    iml.Image = ImageManager.Instance.GetImageFromRelPath((string)listViewDirectoryImages.Items[idx].Tag);
                    ProjectionManager.Instance.DisplayLayer(1, iml, Settings.Default.ProjectionFadeTimeLayer1);

                    // Add image to history
                    imageHistoryAdd((string)listViewDirectoryImages.Items[idx].Tag);
                }
            }
        }

        private void imageHistoryAdd(string relImagePath)
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
                var img = ImageManager.Instance.GetThumbFromRelPath(relImagePath);
                if (img != null)
                {
                    listViewImageHistory.LargeImageList.Images.Add(img);
                    var lvi = new ListViewItem("");
                    lvi.Tag = relImagePath;
                    lvi.ImageIndex = listViewImageHistory.LargeImageList.Images.Count - 1;
                    listViewImageHistory.Items.Add(lvi);
                    listViewImageHistory.EnsureVisible(listViewImageHistory.Items.Count - 1);
                }
            }
        }

        private void imageFavoriteAdd(string relImagePath)
        {
            if (!Settings.Default.ImageFavorites.Contains(relImagePath))
            {
                listViewFavorites.LargeImageList.Images.Add(ImageManager.Instance.GetThumbFromRelPath(relImagePath));
                var lvi = new ListViewItem("");
                lvi.Tag = relImagePath;
                lvi.ImageIndex = listViewFavorites.LargeImageList.Images.Count - 1;
                listViewFavorites.Items.Add(lvi);
                listViewFavorites.EnsureVisible(listViewFavorites.Items.Count - 1);
                Settings.Default.ImageFavorites.Add(relImagePath);
                Settings.Default.Save();
                tabPageImageFavorites.Text = StringResources.Favorites +  " (" + Settings.Default.ImageFavorites.Count + ")";
            }
        }

        private void imageFavoriterRemove(string relImagePath)
        {
            if (Settings.Default.ImageFavorites.Contains(relImagePath))
            {
                Settings.Default.ImageFavorites.Remove(relImagePath);
                Settings.Default.Save();
                tabPageImageFavorites.Text = StringResources.Favorites + " (" + Settings.Default.ImageFavorites.Count + ")";
            }
        }

        private void bilderlisteNeuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageTreeViewInit();
            listViewDirectoryImages.Items.Clear();
            GC.Collect();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            SongEditor wnd = SongEditor.getInstance();
            wnd.Show();
            wnd.Focus();
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
                loadDias(dlg.SelectedPath);
                labelDiaDirectory.Text = dlg.SelectedPath;
                listViewDias.Tag = dlg.SelectedPath;
            }
        }

        private void loadDias(string searchDir)
        {
            if (Directory.Exists(searchDir))
            {
                listViewDias.Items.Clear();
                if (listViewDias.LargeImageList != null)
                {
                    listViewDias.LargeImageList.Dispose();
                }

                var imList = new ImageList();
                imList.ImageSize = Settings.Default.ThumbSize;
                imList.ColorDepth = ColorDepth.Depth32Bit;

                string[] extensions = { "*.jpg", "*.png", "*.bmp", "*.gif" };
                int i = 0;
                foreach (string ext in extensions)
                {
                    string[] filePaths = Directory.GetFiles(searchDir, ext, SearchOption.TopDirectoryOnly);
                    foreach (string file in filePaths)
                    {
                        var lvi = new ListViewItem(Path.GetFileNameWithoutExtension(file));
                        lvi.Tag = file;
                        lvi.ImageIndex = i;
                        lvi.Checked = true;
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
            if (diaTimer != null && diaTimer.Enabled)
            {
                diaTimer.Stop();
                ProjectionManager.Instance.HideLayer(1);
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

                diaTimer = new Timer();
                diaTimer.Interval = duration * 1000;
                diaTimer.Tick += diaTimer_Tick;

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
                diaTimer.Tag = diaStack;
                ImageLayer iml = new ImageLayer();
                iml.Image = Image.FromFile(diaStack.Dequeue());
                ProjectionManager.Instance.DisplayLayer(1, iml, Settings.Default.ProjectionFadeTimeLayer1);
                diaTimer.Start();
            }
        }

        private void diaTimer_Tick(object sender, EventArgs e)
        {
            if (((Queue<string>)((Timer)sender).Tag).Count == 0)
            {
                ((Timer)sender).Stop();
                ProjectionManager.Instance.HideLayer(1);
                buttonDiaShow.Text = StringResources.StartSlideshow;
                return;
            }
            ImageLayer iml = new ImageLayer();
            iml.Image = Image.FromFile(((Queue<string>)((Timer)sender).Tag).Dequeue());
            ProjectionManager.Instance.DisplayLayer(1, iml, Settings.Default.ProjectionFadeTimeLayer1);
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
                        ImageManager.Instance.GetThumbFromRelPath((string)listViewImageHistory.Items[idx].Tag));
                    var lvi = new ListViewItem("");
                    lvi.Tag = listViewImageHistory.Items[idx].Tag;
                    lvi.ImageIndex = listViewImageQueue.LargeImageList.Images.Count - 1;
                    listViewImageQueue.Items.Add(lvi);
                }
                else if ((ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    imageFavoriteAdd((string)listViewImageHistory.Items[idx].Tag);
                }
                else
                {
                    if (
                        !(!linkLayers ^
                          ((ModifierKeys & Keys.Shift) == Keys.Shift && SongManager.Instance.CurrentSong != null &&
                           SongManager.Instance.CurrentSong.Song.CurrentSlide >= 0)))
                    {
                        ProjectionManager.Instance.HideLayer(2);
                    }

                    ImageLayer iml = new ImageLayer();
                    iml.Image = ImageManager.Instance.GetImageFromRelPath((string)listViewImageHistory.Items[idx].Tag);
                    ProjectionManager.Instance.DisplayLayer(1, iml, Settings.Default.ProjectionFadeTimeLayer1);
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
                imageSearchResults.Clear();
                Console.WriteLine("Search: "+ needle);
                foreach (string ims in ImageManager.Instance.SearchImages(needle))
                {
                    Console.WriteLine("Found: " + ims);
                    imageSearchResults.Add(ims);
                }
                treeViewImageDirectories.SelectedNode = treeViewImageDirectories.Nodes[treeViewImageDirectories.Nodes.Count - 1];
            }
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.ViewerWindowState = WindowState;
            Settings.Default.MainWindowSize = this.Size;
            Settings.Default.Save();
        }

        private void datenverzeichnisOeffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.DataDirectory);
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

        private void buttonSetListClear_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(StringResources.ReallyEmptySetlist, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                listViewSetList.Items.Clear();
                buttonSetListRem.Enabled = false;
                buttonSetListClear.Enabled = false;
                buttonSaveSetList.Enabled = false;
                buttonSetListDown.Enabled = false;
                buttonSetListUp.Enabled = false;
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

        private void buttonSaveSetList_Click(object sender, EventArgs e)
        {
            string setlistDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SetListDir;
            if (!Directory.Exists(setlistDir))
            {
                Directory.CreateDirectory(setlistDir);
            }

            var dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.CheckPathExists = true;
            dlg.Filter = StringResources.SetlistFile + " (*.pbpl)|*.pbpl";
            dlg.InitialDirectory = setlistDir;
            dlg.Title = StringResources.SaveSetlistAs;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                PraiseBase.Presenter.Model.Setlist sl = new PraiseBase.Presenter.Model.Setlist();
                for (int i = 0; i < listViewSetList.Items.Count; i++)
                {
                    sl.Items.Add(SongManager.Instance.SongList[(Guid)listViewSetList.Items[i].Tag].Song.Title);
                }
                SetlistWriter swr = new SetlistWriter();
                swr.Write(dlg.FileName, sl);
            }
        }

        private void buttonOpenSetList_Click(object sender, EventArgs e)
        {
            string setlistDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SetListDir;
            if (!Directory.Exists(setlistDir))
            {
                Directory.CreateDirectory(setlistDir);
            }

            var dlg = new OpenFileDialog();
            dlg.AddExtension = true;
            dlg.CheckPathExists = true;
            dlg.CheckFileExists = true;
            dlg.Filter = StringResources.SetlistFile + " (*.pbpl)|*.pbpl";
            dlg.InitialDirectory = setlistDir;
            dlg.Title = StringResources.OpenSetlist;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SetlistReader sr = new SetlistReader();
                try {
                    PraiseBase.Presenter.Model.Setlist sl = sr.read(dlg.FileName);
                    if (sl.Items.Count > 0)
                    {
                        foreach (var i in sl.Items)                
                        {
                            Guid g = SongManager.Instance.GetGuidByTitle(i);
                            if (g != Guid.Empty)
                            {
                                var s = SongManager.Instance.SongList[g].Song;
                                var lvi = new ListViewItem(s.Title);
                                lvi.Tag = s.GUID;
                                listViewSetList.Items.Add(lvi);
                            }
                        }
                        buttonSetListClear.Enabled = true;
                        buttonSaveSetList.Enabled = true;
                        listViewSetList.Columns[0].Width = -2;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            Process.Start(ImageManager.Instance.ImageDirPath);
        }

        private void setlistenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SetListDir);
        }

        private void toolStripButtonDataFolder_ButtonClick(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.DataDirectory);
        }

        private void datenverzeichnisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.DataDirectory);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var dlg = new SongBrowserDialog();
            dlg.ShowDialog(this);
            if (dlg.OpenInEditor)
            {
                SongEditor.getInstance().Show();
                SongEditor.getInstance().BringToFront();
            }
        }

        private void fehlerMeldenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.BugReportUrl);
        }

        private void praiseBoxDatenbankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new SongImporter(SongImporter.ImportFormat.PraiseBox);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                reloadSongList();
            }
        }

        private void worToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new SongImporter(SongImporter.ImportFormat.WorshipSystem);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                reloadSongList();
            }
        }

        private void powerpraiseLiederToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new SongImporter(SongImporter.ImportFormat.PowerPraise);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                reloadSongList();
            }
        }

        private void songbeamerLiederToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new SongImporter(SongImporter.ImportFormat.SongBeamer);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                reloadSongList();
            }
        }

        private void miniaturbilderPrüfenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgressWindow wnd = new ProgressWindow(StringResources.CreatingThumbnails + "...", 0);
            wnd.Show();
            ImageManager.Instance.ThumbnailCreated += new ImageManager.ThumbnailCreate(Instance_ThumbnailCreated);
            ImageManager.Instance.CheckThumbs();
            wnd.Close();
        }

        void Instance_ThumbnailCreated(ImageManager.ThumbnailCreateEventArgs e)
        {
            //TODO
            //wnd.UpdateStatus("Erstelle Miniaturbilder " + i.ToString() + "/" + cnt.ToString(), i);
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
                    !((ModifierKeys & Keys.Shift) == Keys.Shift && SongManager.Instance.CurrentSong != null &&
                       SongManager.Instance.CurrentSong.Song.CurrentSlide >= 0))
                {
                    ProjectionManager.Instance.HideLayer(2);
                }

                int idx = listViewImageQueue.SelectedIndices[0];
                ImageLayer iml = new ImageLayer();
                iml.Image = ImageManager.Instance.GetImageFromRelPath((string)listViewImageQueue.Items[idx].Tag);
                ProjectionManager.Instance.DisplayLayer(1, iml, Settings.Default.ProjectionFadeTimeLayer1);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            linkLayers = !linkLayers;
            Settings.Default.LinkLayers = linkLayers;
            Settings.Default.Save();
            setLinkLayerUI();
        }

        private void setLinkLayerUI()
        {
            if (linkLayers)
            {
                buttonToggleLayerMode.Image = PraiseBase.Presenter.Properties.Resources.link;

                //label3.Text = "Text und Bild sind verknüpft";
            }
            else
            {
                buttonToggleLayerMode.Image = PraiseBase.Presenter.Properties.Resources.unlink;

                //label3.Text = "Text und Bild sind unabhängig";
            }
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
                        ImageManager.Instance.GetThumbFromRelPath((string)listViewFavorites.Items[idx].Tag));
                    var lvi = new ListViewItem("");
                    lvi.Tag = listViewFavorites.Items[idx].Tag;
                    lvi.ImageIndex = listViewImageQueue.LargeImageList.Images.Count - 1;
                    listViewImageQueue.Items.Add(lvi);
                }

                // ALT remove from favorites
                else if ((ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    imageFavoriterRemove((string)listViewFavorites.Items[idx].Tag);
                    listViewFavorites.Items.RemoveAt(idx);
                }
                else
                {
                    if (
                        !(!linkLayers ^
                           ((ModifierKeys & Keys.Shift) == Keys.Shift && SongManager.Instance.CurrentSong != null &&
                            SongManager.Instance.CurrentSong.Song.CurrentSlide >= 0)))
                    {
                        ProjectionManager.Instance.HideLayer(2);
                    }
                    ImageLayer iml = new ImageLayer();
                    iml.Image = ImageManager.Instance.GetImageFromRelPath((string)listViewFavorites.Items[idx].Tag);
                    ProjectionManager.Instance.DisplayLayer(2, iml);

                    // Add image to history
                    imageHistoryAdd((string)listViewFavorites.Items[idx].Tag);
                }
            }
        }

        private void buttonShowLiveText_Click(object sender, EventArgs e)
        {
            var lt =
                new LiveText(textBoxLiveText.SelectedText != String.Empty
                                 ? textBoxLiveText.SelectedText
                                 : textBoxLiveText.Text);
            if (comboBox1.SelectedIndex == 2)
                lt.HorizontalAlign = StringAlignment.Far;
            else if (comboBox1.SelectedIndex == 1)
                lt.HorizontalAlign = StringAlignment.Center;
            else
                lt.HorizontalAlign = StringAlignment.Near;

            if (comboBox2.SelectedIndex == 2)
                lt.VerticalAlign = StringAlignment.Far;
            else if (comboBox2.SelectedIndex == 1)
                lt.VerticalAlign = StringAlignment.Center;
            else
                lt.VerticalAlign = StringAlignment.Near;
            lt.FontSize = (float)numericUpDown1.Value;

            ProjectionManager.Instance.DisplayLayer(2, lt);
        }

        private void buttonClearText_Click(object sender, EventArgs e)
        {
            ProjectionManager.Instance.HideLayer(2);
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
            labelFadeTime.Text = (trackBarFadeTime.Value * 0.5) + " s";
            Settings.Default.ProjectionFadeTime = trackBarFadeTime.Value * 500;
        }

        private void trackBarFadeTimeLayer1_Scroll(object sender, EventArgs e)
        {
            labelFadeTimeLayer1.Text = (trackBarFadeTimeLayer1.Value * 0.5) + " s";
            Settings.Default.ProjectionFadeTimeLayer1 = trackBarFadeTimeLayer1.Value * 500;
        }

        private void listViewSongHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSongHistory.SelectedIndices.Count > 0)
            {
                SongManager.Instance.CurrentSong =
                    SongManager.Instance.SongList[(Guid)listViewSongHistory.SelectedItems[0].Tag];
                showCurrentSongDetails();
            }
        }

        #region Bible

        private int bookIdx = -1, chapterIdx = -1;
        private int verseIdx = -1, verseToIdx = -1;
        BibleManager.BiblePassageSearchResult biblePassageSearchResult;

        private void loadBibles()
        {
            bool reload = false;
            if (comboBoxBible.Items.Count == 0 || reload)
            {
                comboBoxBible.Items.Clear();
                BibleManager.Instance.LoadBibleInfo();
                if (BibleManager.Instance.BibleList.Count > 0)
                {
                    comboBoxBible.DataSource = new BindingSource(BibleManager.Instance.BibleList, null);
                    comboBoxBible.DisplayMember = "Value";
                    comboBoxBible.ValueMember = "Key";
                    comboBoxBible.SelectedIndex = 0;
                }
            }
        }

        private void comboBoxBible_SelectedIndexChanged(object sender, EventArgs e)
        {
                listBoxBibleVerse.Items.Clear();
                listBoxBibleVerseTo.Items.Clear();
                listBoxBibleChapter.Items.Clear();

                listBoxBibleBook.Items.Clear();
                listBoxBibleBook.DisplayMember = "Name";

                var bi = ((KeyValuePair<string, BibleManager.BibleItem>)comboBoxBible.SelectedItem);
                if (bi.Value.Bible.Books == null)
                {
                    BibleManager.Instance.LoadBibleData(bi.Key);
                }

                foreach (PraiseBase.Presenter.Model.Bible.BibleBook bk in  bi.Value.Bible.Books)
                {
                    listBoxBibleBook.Items.Add(bk);
                }

                if (bookIdx >= 0 && bookIdx < listBoxBibleBook.Items.Count)
                {
                    listBoxBibleBook.SelectedIndex = bookIdx;
                }

                searchTextBoxBible.Enabled = true;
        }

        private void listBoxBibleBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bk = ((PraiseBase.Presenter.Model.Bible.BibleBook)listBoxBibleBook.SelectedItem);

            listBoxBibleVerse.Items.Clear();
            listBoxBibleVerseTo.Items.Clear();

            listBoxBibleChapter.Items.Clear();
            listBoxBibleChapter.DisplayMember = "Number";

            foreach (PraiseBase.Presenter.Model.Bible.BibleChapter cp in bk.Chapters)
            {
                listBoxBibleChapter.Items.Add(cp);
            }

            if (bookIdx == listBoxBibleBook.SelectedIndex && chapterIdx >= 0)
            {
                listBoxBibleChapter.SelectedIndex = chapterIdx;
            }

            bookIdx = listBoxBibleBook.SelectedIndex;
        }

        private void listBoxBibleChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cp = ((PraiseBase.Presenter.Model.Bible.BibleChapter)listBoxBibleChapter.SelectedItem);

            listBoxBibleVerse.Items.Clear();
            listBoxBibleVerseTo.Items.Clear();
            listBoxBibleVerse.DisplayMember = "Number";
            listBoxBibleVerseTo.DisplayMember = "Number";

            foreach (PraiseBase.Presenter.Model.Bible.BibleVerse v in cp.Verses)
            {
                listBoxBibleVerse.Items.Add(v);
                listBoxBibleVerseTo.Items.Add(v);
            }


            if (chapterIdx == listBoxBibleChapter.SelectedIndex && verseIdx >= 0)
            {
                listBoxBibleVerse.SelectedIndex = verseIdx;
            }

            chapterIdx = listBoxBibleChapter.SelectedIndex;
        }

        private void listBoxBibleVerse_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = ((PraiseBase.Presenter.Model.Bible.BibleVerse)listBoxBibleVerse.SelectedItem);

            listBoxBibleVerseTo.Items.Clear();
            foreach (PraiseBase.Presenter.Model.Bible.BibleVerse tv in v.Chapter.Verses)
            {
                if (tv.Number >= v.Number)
                {
                    listBoxBibleVerseTo.Items.Add(tv);
                }
            }

            if (verseIdx == listBoxBibleVerse.SelectedIndex && verseToIdx >= 0)
            {
                listBoxBibleVerseTo.SelectedIndex = verseToIdx;
            }
            else
                listBoxBibleVerseTo.SelectedIndex = 0;

            verseIdx = listBoxBibleVerse.SelectedIndex;
        }

        private void listBoxBibleVerseTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxBibleVerse.SelectedItem != null && listBoxBibleVerseTo.SelectedItem != null)
            {
                var vs = new PraiseBase.Presenter.Model.Bible.BibleVerseSelection(((PraiseBase.Presenter.Model.Bible.BibleVerse)listBoxBibleVerse.SelectedItem),
                                                     ((PraiseBase.Presenter.Model.Bible.BibleVerse)listBoxBibleVerseTo.SelectedItem));

                labelBibleTextName.Text = vs.ToString();
                textBoxBibleText.Text = vs.Text;

                verseToIdx = listBoxBibleVerseTo.SelectedIndex;

                buttonAddToBibleVerseList.Enabled = true;
            }
        }

        private void buttonBibleTextShow_Click(object sender, EventArgs e)
        {
            var bl =
                new BibleLayer(new PraiseBase.Presenter.Model.Bible.BibleVerseSelection(((PraiseBase.Presenter.Model.Bible.BibleVerse)listBoxBibleVerse.SelectedItem),
                                                           ((PraiseBase.Presenter.Model.Bible.BibleVerse)listBoxBibleVerseTo.SelectedItem)));
            bl.FontSize = (float)numericUpDown2.Value;
            ProjectionManager.Instance.DisplayLayer(2, bl);
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            ProjectionManager.Instance.HideLayer(2);
        }

        private void buttonAddToBibleVerseList_Click(object sender, EventArgs e)
        {
            var vs = new PraiseBase.Presenter.Model.Bible.BibleVerseSelection(((PraiseBase.Presenter.Model.Bible.BibleVerse)listBoxBibleVerse.SelectedItem),
                                                 ((PraiseBase.Presenter.Model.Bible.BibleVerse)listBoxBibleVerseTo.SelectedItem));
            var lvi = new ListViewItem(vs.ToString());
            lvi.Tag = vs;
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
                var vs = (PraiseBase.Presenter.Model.Bible.BibleVerseSelection)listViewBibleVerseList.SelectedItems[0].Tag;
                listBoxBibleBook.SelectedIndex = vs.Chapter.Book.Number - 1;
                listBoxBibleChapter.SelectedIndex = vs.Chapter.Number - 1;
                listBoxBibleVerse.SelectedIndex = vs.StartVerse.Number - 1;
                listBoxBibleVerseTo.SelectedIndex = vs.EndVerse.Number - vs.StartVerse.Number;
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
                    PraiseBase.Presenter.BibleManager.BibleItem bibleItem = ((KeyValuePair<String,PraiseBase.Presenter.BibleManager.BibleItem>)comboBoxBible.SelectedItem).Value;

                    biblePassageSearchResult = BibleManager.Instance.SearchPassage(bibleItem.Bible, needle);
                    if (biblePassageSearchResult.Status == BibleManager.BiblePassageSearchStatus.Found)
                    {
                        if (biblePassageSearchResult.Passage.Book != null)
                        {
                            if (needle.Length < biblePassageSearchResult.Passage.Book.Name.Length)
                            {
                                searchTextBoxBible.Text = biblePassageSearchResult.Passage.Book.Name + " ";
                                searchTextBoxBible.select(searchTextBoxBible.Text.Length, 0);
                            }

                            /*
                            if (biblePassageSearchResult.Passage.Chapter != null)
                            {
                                chapterIdx = biblePassageSearchResult.Passage.Chapter.Number - 1;
                            }
                            if (biblePassageSearchResult.Passage.Verse != null)
                            {
                                verseIdx = biblePassageSearchResult.Passage.Verse.Number - 1;
                            }*/

                            listBoxBibleBook.SelectedIndex = biblePassageSearchResult.Passage.Book.Number - 1;
                            

                        }

                        labelBibleSearchMsg.ForeColor = Color.Black;
                        labelBibleSearchMsg.Text = "";
                    }
                    else if (biblePassageSearchResult.Status == BibleManager.BiblePassageSearchStatus.NotFound)
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
            ProjectionManager.Instance.HideLayer(2);
        }

        private void buttonToggleLayer1_Click(object sender, EventArgs e)
        {
            ProjectionManager.Instance.HideLayer(1);
        }

        private void titelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.SongSearchMode = SongSearchMode.Title;
            titelToolStripMenuItem.Checked = true;
            titelUndTextToolStripMenuItem.Checked = false;
            searchSongs(songSearchTextBox.Text);
        }

        private void titelUndTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.SongSearchMode = SongSearchMode.TitleAndText;
            titelToolStripMenuItem.Checked = false;
            titelUndTextToolStripMenuItem.Checked = true;
            searchSongs(songSearchTextBox.Text);
        }

        private void aufUpdatePrüfenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCheck.DoCheck(true);
        }

        private void toolStripButtonDataFolder_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.DataDirectory);
        }

        private void toolStripButtonToggleTranslationText_Click(object sender, EventArgs e)
        {
            if (SongManager.Instance.CurrentSong != null)
            {
                if (SongManager.Instance.CurrentSong.SwitchTextAndTranlation)
                {
                    toolStripButtonToggleTranslationText.Image = Properties.Resources.translate;
                    SongManager.Instance.CurrentSong.SwitchTextAndTranlation = false;
                }
                else
                {
                    toolStripButtonToggleTranslationText.Image = Properties.Resources.translate_active;
                    SongManager.Instance.CurrentSong.SwitchTextAndTranlation = true;
                }
            }
        }

        private void openSongEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewSongs.SelectedItems.Count > 0)
            {
                SongEditor wnd = SongEditor.getInstance();
                wnd.openSong(SongManager.Instance.CurrentSong.Filename);
                wnd.Show();
                wnd.Focus();
            }
            else
            {
                SongEditor wnd = SongEditor.getInstance();
                wnd.Show();
                wnd.Focus();
            }
        }

        private void qaSpellingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongManager.Instance.CurrentSong.Song.SetQA(SongQualityAssuranceIndicator.Spelling, qaSpellingToolStripMenuItem.Checked);
            saveCurrentSong();
            updateQAButtonStage();
        }

        private void qaTranslationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongManager.Instance.CurrentSong.Song.SetQA(SongQualityAssuranceIndicator.Translation, qaTranslationToolStripMenuItem.Checked);
            saveCurrentSong();
            updateQAButtonStage();
        }

        private void qaImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongManager.Instance.CurrentSong.Song.SetQA(SongQualityAssuranceIndicator.Images, qaImagesToolStripMenuItem.Checked);
            saveCurrentSong();
            updateQAButtonStage();
        }

        private void qaSegmentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongManager.Instance.CurrentSong.Song.SetQA(SongQualityAssuranceIndicator.Segmentation, qaSegmentationToolStripMenuItem.Checked);
            saveCurrentSong();
            updateQAButtonStage();
        }

        private void saveCurrentSong()
        {
            try
            {
                SongManager.Instance.SaveCurrentSong();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateQAButtonStage()
        {
            if (SongManager.Instance.CurrentSong.Song.Comment != String.Empty || SongManager.Instance.CurrentSong.Song.HasQA())
            {
                toolStripButtonQA.Image = PraiseBase.Presenter.Properties.Resources.highlight_red__36;
            }
            else
            {
                toolStripButtonQA.Image = PraiseBase.Presenter.Properties.Resources.highlight_36;
            }
        }

        private void qAcommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SongManager.Instance.CurrentSong != null)
            {
                var qd = new QADialog();
                qd.ShowDialog(this);
                if (qd.DialogResult == DialogResult.OK)
                {
                    updateQAButtonStage();
                }
            }
            else
            {
                MessageBox.Show(StringResources.NoActiveSong);
            }
        }
    }
}