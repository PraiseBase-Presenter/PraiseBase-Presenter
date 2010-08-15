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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Configuration; 
using System.Collections.Specialized;
using System.Xml;

using Pbp.Properties;
using Pbp.Forms;

//using PowerPoint = Microsoft.Office.Interop.PowerPoint;


namespace Pbp.Forms
{
	/// <summary>
	/// The main window class provides the central
	/// gui of this software, including the songlist, 
	/// setlist, imagelist and the diashow interface.
	/// </summary>
    public partial class MainWindow : Form
    {
		static private MainWindow instance;
        private projectionWindow projWindow; // Todo: use singleton

        private Image currentBackground;

		private Timer blackOutTimer;
        private Timer diaTimer;
		private bool blackout;
        private List<String> imageSearchResults;

        private bool linkLayers = true;

		/// <summary>
		/// Private constructor
		/// </summary>
        private MainWindow()
        {
            InitializeComponent();
        }

		/// <summary>
		/// Returns a singleton of mainWindow
		/// </summary>
		/// <returns>Returns the mainWindow instance</returns>
		static public MainWindow getInstance()
		{
			if (instance == null)
				instance = new MainWindow();
			return instance;
		}

		/// <summary>
		/// Initializes some basic form stuff
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Threading.Thread newThread;
            newThread = new System.Threading.Thread(UpdateCheck.DoCheck);
            newThread.Name = "UpdateChecker";
            newThread.Start();

            System.Threading.Thread bThread;
            bThread = new System.Threading.Thread(loadBibles);
            bThread.Name = "BibleLoader";
            bThread.Start();
            

            projWindow = projectionWindow.getInstance();

			this.WindowState = Settings.Default.ViewerWindowState;
            this.Text += " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            blackout = false;
            blackOutTimer = new Timer(); // Timer anlegen
            blackOutTimer.Interval = 500; // Intervall festlegen, hier 100 ms
            blackOutTimer.Tick += new EventHandler(t1_Tick); // Eventhandler ezeugen der beim Timerablauf aufgerufen wird

            loadSongList();
            songSearchTextBox.Focus();

            imageTreeViewInit();

            if (Settings.Default.ProjectionFadeTime==3)
                radioButtonFade3.Checked = true;
            else if (Settings.Default.ProjectionFadeTime == 2)
                radioButtonFade2.Checked = true;
            else if (Settings.Default.ProjectionFadeTime == 1)
                radioButtonFade1.Checked = true;
            else
                radioButtonFade0.Checked = true;

			
			UserControl1.getInstance().setFadeSteps(Settings.Default.ProjectionFadeTime);

            linkLayers = Settings.Default.LinkLayers;
            setLinkLayerUI();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            numericUpDown1.Value = (int)Settings.Default.ProjectionMasterFont.Size;


        }


        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow ab = new AboutWindow();
            ab.ShowDialog(this);
        }

        private void songSearchBox_TextChanged(object sender, EventArgs e)
        {
            searchSongs(songSearchTextBox.Text);
        }

        /**
         * Load Songs
         */
        void loadSongList()
        {
            setStatus("Lade Liederliste...");
            searchSongs("");
            setStatus(listViewSongs.Items.Count.ToString() + " Lieder geladen");
        }

        void searchSongs(string needle)
        {
            listViewSongs.BeginUpdate();
            listViewSongs.SuspendLayout();
            listViewSongs.Items.Clear();
            int cnt = 0;
            
            List<ListViewItem> lviList = new List<ListViewItem>();
            foreach (Song sng in SongManager.Instance.getSearchResults(needle, radioSongSearchAll.Checked ? 1 : 0))
            {
                ListViewItem lvi = new ListViewItem(sng.Title);
                lvi.Tag = sng.GUID;
                lviList.Add(lvi);
                cnt++;
            }
            listViewSongs.Items.AddRange(lviList.ToArray());

            if (cnt == 1 && listViewSongs.Items.Count>0)
            {
                    try
                    {
						listViewSongs.Items[0].Selected = true;
                        SongManager.Instance.CurrentSong = SongManager.Instance.SongList[(Guid)listViewSongs.SelectedItems[0].Tag];
						showCurrentSongDetails();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
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
            if (((ToolStripItem)sender).Name == "toolStripButtonProjectionOff" 
                || ((ToolStripItem)sender).Name == "präsentationausToolStripMenuItem")
			{
				toolStripButtonProjectionOff.CheckState = CheckState.Checked;
				toolStripButtonProjectionOn.CheckState = CheckState.Unchecked;
                toolStripButtonBlackout.CheckState = CheckState.Unchecked;
				projWindow.Hide();
                if (blackout)
                {
                    UserControl1.getInstance().blackOut(false,false);
                    blackout = false;
                }
            }
            else if (((ToolStripItem)sender).Name == "toolStripButtonBlackout"
                  || ((ToolStripItem)sender).Name == "blackoutToolStripMenuItem")
            { 
                if (!blackout)
                {
                    toolStripButtonProjectionOff.CheckState = CheckState.Unchecked;
                    toolStripButtonBlackout.CheckState = CheckState.Checked;
                    toolStripButtonProjectionOn.CheckState = CheckState.Unchecked;
                    if (!projWindow.Visible)
                    {
                        projWindow.Show();
                        UserControl1.getInstance().blackOut(true, false);
                    }
                    else
                    {
                        UserControl1.getInstance().blackOut(true, true);
                    }
                    blackout = true;
                }
            }
            else if (((ToolStripItem)sender).Name == "toolStripButtonProjectionOn"
                  || ((ToolStripItem)sender).Name == "präsentationeinToolStripMenuItem")
            {
                toolStripButtonProjectionOff.CheckState = CheckState.Unchecked;
                toolStripButtonBlackout.CheckState = CheckState.Unchecked;
                toolStripButtonProjectionOn.CheckState = CheckState.Checked;
                if (!projWindow.Visible)
                {
                    projWindow.Show();
                    UserControl1.getInstance().blackOut(false,false);
                    blackout = false;
                }
                else if (blackout)
                {
                    UserControl1.getInstance().blackOut(false,true);
                    blackout = false;
                }

            }
            songSearchTextBox.Focus();
        }

        void t1_Tick(object sender, EventArgs e)
        {

        }

        private void optionenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsWindow stWnd = new settingsWindow();
            stWnd.ShowDialog(this);           
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            settingsWindow stWnd = new settingsWindow();
            stWnd.ShowDialog(this);
        }

        private void liederlisteNeuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
			reloadSongList();
        }

		private void reloadSongList()
		{
            songSearchTextBox.Text = "";
            SongManager.Instance.reload();
			loadSongList();

            for (int i=0;i<listViewSetList.Items.Count;i++)
            {
                listViewSetList.Items[i].Tag = SongManager.Instance.getGUID(listViewSetList.Items[i].Text);
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
                    if (SongManager.Instance.CurrentSong == null || SongManager.Instance.CurrentSong.GUID != (Guid)listViewSongs.SelectedItems[0].Tag)
                    {
                        SongManager.Instance.CurrentSong = SongManager.Instance.SongList[(Guid)listViewSongs.SelectedItems[0].Tag];
                        showCurrentSongDetails();

                        buttonSetListAdd.Enabled = true;
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
                if (SongManager.Instance.CurrentSong == null || SongManager.Instance.CurrentSong.GUID != (Guid)listViewSongs.SelectedItems[0].Tag)
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

                SongManager.getInstance().CurrentSong = SongManager.getInstance().SongList[(Guid)listViewSetList.SelectedItems[0].Tag];
                showCurrentSongDetails();
            }
        }

        private void listViewSetList_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewSetList.SelectedIndices.Count > 0 && SongManager.Instance.CurrentSong.GUID != (Guid)listViewSetList.SelectedItems[0].Tag)
            {
                listViewSetList_SelectedIndexChanged(sender, e);
            }
        }
        
		private void showCurrentSongDetails()
		{
			Application.DoEvents();

            groupBoxSongContents.Text = SongManager.Instance.CurrentSong.Title;
            songDetailElement.setSong(SongManager.Instance.CurrentSong);

            if (SongManager.Instance.CurrentSong.Comment != String.Empty || SongManager.Instance.CurrentSong.hasQA())
            {
                toolStripButton3.Image = global::Pbp.Properties.Resources.highlight_red;
            }
            else
            {
                toolStripButton3.Image = global::Pbp.Properties.Resources.highlight;
            }
		}

		private void songDetailElement_SlideClicked(object sender, SongDetails.SlideClickEventArgs e)
		{
            Application.DoEvents();

            if (listViewSongHistory.Items.Count==0 || (Guid)listViewSongHistory.Items[0].Tag != SongManager.Instance.CurrentSong.GUID)
            {
                ListViewItem lvi = new ListViewItem(SongManager.Instance.CurrentSong.Title);
                lvi.Tag = SongManager.Instance.CurrentSong.GUID;
                listViewSongHistory.Items.Insert(0, lvi);
                listViewSongHistory.Columns[0].Width = -2;
            }


			int pn = e.PartNumber;
			int sn = e.SlideNumber;

			if (projWindow != null)
			{
                setStatus("Projiziere '" + SongManager.Instance.CurrentSong.Title + "' ...");

                // CTRL pressed, use image stack
				if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
				{
					if (listViewImageQueue.Items.Count > 0)
					{
						Image img = ImageManager.Instance.getImageFromRelPath((string)listViewImageQueue.Items[0].Tag);
                        object[] args = {pn,sn};
                        pictureBoxPreview.Image = projWindow.showSlide(SongManager.Instance.CurrentSong, img, args);
                        imageHistoryAdd((string)listViewImageQueue.Items[0].Tag);
						listViewImageQueue.Items[0].Remove();
                        this.currentBackground = img;
					}
					else
					{
                        object [] args = {pn,sn};
                        pictureBoxPreview.Image = projWindow.showSlide(SongManager.Instance.CurrentSong, currentBackground, args);
					}
				}

                // SHIFT pressed, use current slide
                else if (!linkLayers ^ ((Control.ModifierKeys & Keys.Shift) == Keys.Shift))
				{
                    object[] args = { pn, sn };
					pictureBoxPreview.Image = projWindow.showSlide(SongManager.Instance.CurrentSong, currentBackground, args);
				}
                // Current slide + attached image
				else
				{
                    object[] args = { pn, sn };
                    Image img = SongManager.Instance.CurrentSong.getImage(SongManager.Instance.CurrentSong.Parts[pn].Slides[sn].ImageNumber);
					pictureBoxPreview.Image = projWindow.showSlide(SongManager.Instance.CurrentSong, img, args);
                    this.currentBackground = img;
                    if (SongManager.Instance.CurrentSong.RelativeImagePaths.Count > 0)
                        imageHistoryAdd(SongManager.Instance.CurrentSong.RelativeImagePaths[SongManager.Instance.CurrentSong.Parts[pn].Slides[sn].ImageNumber-1]);
				}
				setStatus("'" + SongManager.Instance.CurrentSong.Title + "' ist aktiv");

                SongManager.Instance.CurrentPartNr = pn;
                SongManager.Instance.CurrentSlideNr = sn;

			}
		}

        private void songDetailElement_ImageClicked(object sender, SongDetails.SlideImageClickEventArgs e)
        {
            Application.DoEvents();

            // Stack
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                listViewImageQueue.LargeImageList.Images.Add(ImageManager.Instance.getThumbFromRelPath(e.relativePath));
                ListViewItem lvi = new ListViewItem("");
                lvi.Tag = e.relativePath;
                lvi.ImageIndex = listViewImageQueue.LargeImageList.Images.Count - 1;
                listViewImageQueue.Items.Add(lvi);
            }
            // Favorite
            else if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                imageFavoriteAdd(e.relativePath);
            }
            else
            {
                Image img = ImageManager.Instance.getImageFromRelPath(e.relativePath);

                // Show current songtext with new image
                if (!linkLayers ^ ((Control.ModifierKeys & Keys.Shift) == Keys.Shift))
                {
                    object[] args = { SongManager.Instance.CurrentPartNr, SongManager.Instance.CurrentSlideNr };
                    pictureBoxPreview.Image = projWindow.showSlide(SongManager.Instance.CurrentSong, img, args);
                }
                // Show image only
                else
                {
                    pictureBoxPreview.Image = projWindow.showSlide(null, img);
                }
                this.currentBackground = img;
                if (e.relativePath!=String.Empty)
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
            else if (tabControlTextLayer.SelectedIndex == 2)
            {
                
            }
        }

        private void webToolStripMenuItem_Click(object sender, EventArgs e)
        {
			System.Diagnostics.Process.Start(Settings.Default.Weburl);
        }

        public void imageTreeViewInit()
        {
			string rootDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.ImageDir;
            treeViewImageDirectories.Nodes.Clear();
            PopulateTreeView(rootDir, null);
			treeViewImageDirectories.ExpandAll();
            treeViewImageDirectories.Nodes.Add("Suchergebnisse");
            treeViewImageDirectories.SelectedNode = treeViewImageDirectories.Nodes[0];

            imageSearchResults = new List<String>();

            ImageList iml = new ImageList();
			iml.ImageSize = Settings.Default.ThumbSize;
            iml.ColorDepth = ColorDepth.Depth32Bit;
			listViewImageHistory.LargeImageList = iml;
			listViewImageHistory.TileSize = new Size(Settings.Default.ThumbSize.Width + 8,Settings.Default.ThumbSize.Height + 5) ;

			ImageList iml2 = new ImageList();
			iml2.ImageSize = Settings.Default.ThumbSize;
            iml2.ColorDepth = ColorDepth.Depth32Bit;
			listViewImageQueue.LargeImageList = iml2;
			listViewImageQueue.TileSize = new Size(Settings.Default.ThumbSize.Width + 8, Settings.Default.ThumbSize.Height + 5);

            if (Settings.Default.ImageFavorites == null)
                Settings.Default.ImageFavorites = new System.Collections.ArrayList();

            ImageList iml3 = new ImageList();
            iml3.ImageSize = Settings.Default.ThumbSize;
            iml3.ColorDepth = ColorDepth.Depth32Bit;
            listViewFavorites.LargeImageList = iml3;
            listViewFavorites.TileSize = new Size(Settings.Default.ThumbSize.Width + 8, Settings.Default.ThumbSize.Height + 5);

            foreach (string relImagePath in Settings.Default.ImageFavorites)
            {
                listViewFavorites.LargeImageList.Images.Add(ImageManager.Instance.getThumbFromRelPath(relImagePath));
                ListViewItem lvi = new ListViewItem("");
                lvi.Tag = relImagePath;
                lvi.ImageIndex = listViewFavorites.LargeImageList.Images.Count - 1;
                listViewFavorites.Items.Add(lvi);
                listViewFavorites.EnsureVisible(listViewFavorites.Items.Count - 1);
            }
            tabPageImageFavorites.Text = "Favoriten (" + Settings.Default.ImageFavorites.Count + ")";
		}

        public void PopulateTreeView(string directoryValue, TreeNode parentNode)
        {
            try
            {
                if (Directory.Exists(directoryValue))
                {
                    string[] directoryArray =
                    Directory.GetDirectories(directoryValue);

                    if (directoryArray.Length != 0)
                    {
						int subLen = (Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.ImageDir + Path.DirectorySeparatorChar).Length;
                        foreach (string directory in directoryArray)
                        {
                            string dName = Path.GetFileName(directory);
                            if (dName.Substring(0, 1) != "[" && dName.Substring(0, 1) != ".")
                            {
                                TreeNode myNode = new TreeNode(dName);

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
                if (treeViewImageDirectories.SelectedNode.Index == treeViewImageDirectories.Nodes.Count - 1)
                {
                    ImageList imList = new ImageList();
                    imList.ImageSize = Settings.Default.ThumbSize;
                    imList.ColorDepth = ColorDepth.Depth32Bit;

                    List<ListViewItem> lviList = new List<ListViewItem>();
                    
                    string pathPrefix = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.ThumbDir + Path.DirectorySeparatorChar;
                    int i = 0;

                    foreach (string file in imageSearchResults)
                    {
                        ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(file));
                        lvi.Tag = file;
                        lvi.ImageIndex = i;
                        imList.Images.Add(Image.FromFile(pathPrefix + file));
                        lviList.Add(lvi);
                        i++;
                    }
                    listViewDirectoryImages.Items.AddRange(lviList.ToArray());
                    listViewDirectoryImages.LargeImageList = imList;

                    labelImgDirName.Text = "Suchergebnisse ("+i+" Bilder)";

                }
                else
                {
                    string relativeImageDir = ((string)treeViewImageDirectories.SelectedNode.Tag) + Path.DirectorySeparatorChar;
                    string imDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.ThumbDir + Path.DirectorySeparatorChar + relativeImageDir;

                    if (Directory.Exists(imDir))
                    {
                        ImageList imList = new ImageList();
                        imList.ImageSize = Settings.Default.ThumbSize;
                        imList.ColorDepth = ColorDepth.Depth32Bit;

                        string[] songFilePaths = Directory.GetFiles(imDir, "*.jpg", SearchOption.TopDirectoryOnly);
                        int i = 0;
                        foreach (string file in songFilePaths)
                        {
                            ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(file));
                            lvi.Tag = relativeImageDir + Path.GetFileName(file);
                            lvi.ImageIndex = i;
                            listViewDirectoryImages.Items.Add(lvi);
                            imList.Images.Add(Image.FromFile(file));
                            i++;
                        }
                        listViewDirectoryImages.LargeImageList = imList;

                        labelImgDirName.Text = "Kategorie '" + Path.GetFileName(((string)treeViewImageDirectories.SelectedNode.Tag)) + "' (" + i + " Bilder):";
                    }
                }

                listViewDirectoryImages.ResumeLayout();
                listViewDirectoryImages.EndUpdate();
            }
        }

        private void listViewDirectoryImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projWindow != null && listViewDirectoryImages.SelectedIndices.Count > 0)
            {
				Application.DoEvents();
				int idx = listViewDirectoryImages.SelectedIndices[0];

                // Stack
				if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
				{
					listViewImageQueue.LargeImageList.Images.Add(ImageManager.Instance.getThumbFromRelPath((string)listViewDirectoryImages.Items[idx].Tag));
					ListViewItem lvi = new ListViewItem("");
					lvi.Tag = listViewDirectoryImages.Items[idx].Tag;
					lvi.ImageIndex = listViewImageQueue.LargeImageList.Images.Count - 1;
					listViewImageQueue.Items.Add(lvi);
					//listViewImageQueue.EnsureVisible(listViewImageHistory.Items.Count - 1);
				}
                // Favorite
                else if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
				{
                    imageFavoriteAdd((string)listViewDirectoryImages.Items[idx].Tag);                   
				}
				else
				{
					Image img = ImageManager.Instance.getImageFromRelPath((string)listViewDirectoryImages.Items[idx].Tag);
                    // Linked layers
					if (!linkLayers ^ ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && SongManager.Instance.CurrentSong != null && SongManager.Instance.CurrentSong.CurrentSlide >= 0))
					{
                        Object[] args = {SongManager.Instance.CurrentPartNr,SongManager.Instance.CurrentSlideNr};
						pictureBoxPreview.Image = projWindow.showSlide(SongManager.Instance.CurrentSong, img, args);
					}
					else
					{
                        pictureBoxPreview.Image = projWindow.showSlide(null,img);
					}
                    this.currentBackground = img;

					// Add image to history
                    imageHistoryAdd((string)listViewDirectoryImages.Items[idx].Tag);
				}
            }
        }

        private void imageHistoryAdd(string relImagePath)
        {
            if (listViewImageHistory.Items.Count == 0 || (string)listViewImageHistory.Items[listViewImageHistory.Items.Count - 1].Tag != relImagePath)
            {
                for (int i = 0; i < listViewImageHistory.Items.Count; i++)
                {
                    if ((string)listViewImageHistory.Items[i].Tag == relImagePath)
                        listViewImageHistory.Items.RemoveAt(i);

                }
                listViewImageHistory.LargeImageList.Images.Add(ImageManager.Instance.getThumbFromRelPath(relImagePath));
                ListViewItem lvi = new ListViewItem("");
                lvi.Tag = relImagePath;
                lvi.ImageIndex = listViewImageHistory.LargeImageList.Images.Count - 1;
                listViewImageHistory.Items.Add(lvi);
                listViewImageHistory.EnsureVisible(listViewImageHistory.Items.Count - 1);
            }
        }

        private void imageFavoriteAdd(string relImagePath)
        {
            if (!Settings.Default.ImageFavorites.Contains(relImagePath))
            {
                listViewFavorites.LargeImageList.Images.Add(ImageManager.Instance.getThumbFromRelPath(relImagePath));
                ListViewItem lvi = new ListViewItem("");
                lvi.Tag = relImagePath;
                lvi.ImageIndex = listViewFavorites.LargeImageList.Images.Count - 1;
                listViewFavorites.Items.Add(lvi);
                listViewFavorites.EnsureVisible(listViewFavorites.Items.Count - 1);
                Settings.Default.ImageFavorites.Add(relImagePath);
                Settings.Default.Save();
                tabPageImageFavorites.Text = "Favoriten (" + Settings.Default.ImageFavorites.Count+ ")";
            }
        }

        private void imageFavoriterRemove(string relImagePath)
        {
            if (Settings.Default.ImageFavorites.Contains(relImagePath))
            {
                Settings.Default.ImageFavorites.Remove(relImagePath);
                Settings.Default.Save();
                tabPageImageFavorites.Text = "Favoriten (" + Settings.Default.ImageFavorites.Count + ")";
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
            EditorWindow wnd = EditorWindow.getInstance();
            wnd.Show();
            wnd.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
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

                ImageList imList = new ImageList();
				imList.ImageSize = Settings.Default.ThumbSize;
                imList.ColorDepth = ColorDepth.Depth32Bit;

                string[] extensions = { "*.jpg", "*.png", "*.bmp", "*.gif" };
                int i = 0;
                foreach (string ext in extensions)    
                {
                    string[] filePaths = Directory.GetFiles(searchDir, ext, SearchOption.TopDirectoryOnly);
                    foreach (string file in filePaths)
                    {
                        ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(file));
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
                projWindow.showSlide(null, null);
                buttonDiaShow.Text = "Diaschau starten";
                return;
            }

            if (listViewDias.Items.Count == 0)
            {
                MessageBox.Show("Keine Bilder ausgewählt!");
                return;
            }
            buttonDiaShow.Text = "Diaschau stoppen";

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
                diaTimer.Tick += new EventHandler(diaTimer_Tick);

                Queue<string> diaStack = new Queue<string>();
                foreach (ListViewItem lvi in listViewDias.Items)
                {
                    if (lvi.Checked)
                    {
                        diaStack.Enqueue((string)lvi.Tag);
                    }
                }
                if (diaStack.Count == 0)
                {
                    MessageBox.Show("Keine Bilder ausgewählt!");
                    return;
                }
                diaTimer.Tag = diaStack;
                pictureBoxPreview.Image = projWindow.showSlide(null,Image.FromFile(diaStack.Dequeue()));
                diaTimer.Start();
            }
        }

        private void diaTimer_Tick(object sender, EventArgs e)
        {
            if (((Queue<string>)((Timer)sender).Tag).Count == 0)
            {
                ((Timer)sender).Stop();
                projWindow.showSlide(null, null);
                buttonDiaShow.Text = "Diaschau starten";
                return;
            }
            pictureBoxPreview.Image = projWindow.showSlide(null,Image.FromFile(((Queue<string>)((Timer)sender).Tag).Dequeue()));
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDiaDuration.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDiaDuration.Enabled = false;
        }

        private void checkBoxQASpelling_CheckedChanged(object sender, EventArgs e)
        {
            if (SongManager.Instance.CurrentSong != null)
            {
				if (((CheckBox)sender).Checked)
					SongManager.Instance.CurrentSong.setQA(Song.QualityAssuranceIndicators.Spelling);
				else
					SongManager.Instance.CurrentSong.remQA(Song.QualityAssuranceIndicators.Spelling);
				SongManager.Instance.CurrentSong.save(null);
				setStatus("Qualitätssicherungs-Information gespeichert!");
            }
        }

        private void checkBoxQATranslation_CheckedChanged(object sender, EventArgs e)
        {
            if (SongManager.Instance.CurrentSong != null)
            {
				if (((CheckBox)sender).Checked)
					SongManager.Instance.CurrentSong.setQA(Song.QualityAssuranceIndicators.Translation);
				else
					SongManager.Instance.CurrentSong.remQA(Song.QualityAssuranceIndicators.Translation);
				SongManager.Instance.CurrentSong.save(null);
				setStatus("Qualitätssicherungs-Information gespeichert!");
            }
        }

        private void checkBoxQAImages_CheckedChanged(object sender, EventArgs e)
        {
			if (SongManager.Instance.CurrentSong != null)
            {
				if (((CheckBox)sender).Checked)
					SongManager.Instance.CurrentSong.setQA(Song.QualityAssuranceIndicators.Images);
				else
					SongManager.Instance.CurrentSong.remQA(Song.QualityAssuranceIndicators.Images);
				SongManager.Instance.CurrentSong.save(null);
				setStatus("Qualitätssicherungs-Information gespeichert!");
            }
        }

		private void checkBoxQASegmentation_CheckedChanged(object sender, EventArgs e)
		{
			if (SongManager.Instance.CurrentSong != null)
			{
				if (((CheckBox)sender).Checked)
					SongManager.Instance.CurrentSong.setQA(Song.QualityAssuranceIndicators.Segmentation);
				else
					SongManager.Instance.CurrentSong.remQA(Song.QualityAssuranceIndicators.Segmentation);
				SongManager.Instance.CurrentSong.save(null);
				setStatus("Qualitätssicherungs-Information gespeichert!");
			}
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
            if (projWindow != null && listViewImageHistory.SelectedIndices.Count > 0)
            {
                Application.DoEvents();
                int idx = listViewImageHistory.SelectedIndices[0];


                // Stack
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    listViewImageQueue.LargeImageList.Images.Add(ImageManager.Instance.getThumbFromRelPath((string)listViewImageHistory.Items[idx].Tag));
                    ListViewItem lvi = new ListViewItem("");
                    lvi.Tag = listViewImageHistory.Items[idx].Tag;
                    lvi.ImageIndex = listViewImageQueue.LargeImageList.Images.Count - 1;
                    listViewImageQueue.Items.Add(lvi);
                }
                else if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    imageFavoriteAdd((string)listViewImageHistory.Items[idx].Tag);
                }
                else
                {
                    Image img = ImageManager.Instance.getImageFromRelPath((string)listViewImageHistory.Items[idx].Tag);
                    if (!linkLayers ^ ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && SongManager.Instance.CurrentSong != null && SongManager.Instance.CurrentSong.CurrentSlide >= 0))
                    {
                        Object[] args = { SongManager.Instance.CurrentPartNr,SongManager.Instance.CurrentSlideNr};
                        pictureBoxPreview.Image = projWindow.showSlide(SongManager.Instance.CurrentSong, img, args);
                    }
                    else
                    {
                        pictureBoxPreview.Image = projWindow.showSlide(null,img);
                    }
                    this.currentBackground = img;
                }
            }
        }

        private void buttonClearImageHistory_Click(object sender, EventArgs e)
        {
            listViewImageHistory.Items.Clear();
			listViewImageHistory.LargeImageList.Images.Clear();
            GC.Collect();
        }

        private void listViewImageHistory_Leave(object sender, EventArgs e)
        {
			if (listViewImageHistory.SelectedIndices.Count > 0)
			{
				int idx = listViewImageHistory.SelectedIndices[0];
				listViewImageHistory.Items[idx].Selected = false;
			}
        }

        private void searchTextBoxImages_TextChanged(object sender, EventArgs e)
        {
            string needle = searchTextBoxImages.Text.ToLower().Trim();
            if (needle != String.Empty && needle.Length>2)
            {
                treeViewImageDirectories.SelectedNode = null;
                imageSearchResults.Clear();
                string rootDir = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.ThumbDir + Path.DirectorySeparatorChar;
                int rootDirStrLen = rootDir.Length;
                string[] imgFilePaths = Directory.GetFiles(rootDir, "*.jpg", SearchOption.AllDirectories);

                foreach (string ims in imgFilePaths)
                {
                    if (!ims.Contains("[Thumbnails]"))
                    {
                        string haystack = Path.GetFileNameWithoutExtension(ims);
                        if (haystack.ToLower().Contains(needle))
                        {
                            imageSearchResults.Add(ims.Substring(rootDirStrLen));
                        }
                    }
                }
                treeViewImageDirectories.SelectedNode = treeViewImageDirectories.Nodes[treeViewImageDirectories.Nodes.Count - 1];
            }
        }

		private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Default.ViewerWindowState = this.WindowState;
			Settings.Default.Save();
		}

		private void datenverzeichnisÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Settings.Default.DataDirectory);
		}

		private void toolStripButtonDataFolder_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Settings.Default.DataDirectory);
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
			if (MessageBox.Show("Setliste wirklich leeren?", "Viewer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
				if (idx < listViewSetList.Items.Count-1)
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
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.AddExtension = true;
			dlg.CheckPathExists = true;
			dlg.Filter = "PraiseBase-Presenter Setliste (*.pbpl)|*.pbpl";
			dlg.InitialDirectory = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SetListDir;
			dlg.Title = "Setliste speichern unter...";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.AppendChild(xmlDoc.CreateNode(XmlNodeType.XmlDeclaration, "", ""));
				xmlDoc.AppendChild(xmlDoc.CreateElement("setlist"));
				XmlElement xmlRoot = xmlDoc.DocumentElement;
				xmlRoot.AppendChild(xmlDoc.CreateElement("items"));
				for (int i = 0; i < listViewSetList.Items.Count; i++)
				{
					XmlNode nd = xmlDoc.CreateElement("item");
					nd.InnerText = SongManager.getInstance().SongList[(Guid)listViewSetList.Items[i].Tag].Title;
					xmlRoot["items"].AppendChild(nd);
				}
				XmlWriter wrt = new XmlTextWriter(dlg.FileName, Encoding.UTF8);
				xmlDoc.WriteTo(wrt);
				wrt.Flush();
				wrt.Close();
			}
		}

		private void buttonOpenSetList_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.AddExtension = true;
			dlg.CheckPathExists = true;
			dlg.CheckFileExists = true;
			dlg.Filter = "PraiseBase-Presenter Setliste (*.pbpl)|*.pbpl";
			dlg.InitialDirectory = Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SetListDir;
			dlg.Title = "Setliste öffnen...";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(dlg.FileName);
				XmlElement xmlRoot = xmlDoc.DocumentElement;
				try
				{
					if (xmlRoot.Name != "setlist")
						throw new Exception("Ungültige Setlist!");

					if (xmlRoot["items"] != null)
					{
						listViewSetList.Items.Clear();
						for (int i = 0; i < xmlRoot["items"].ChildNodes.Count; i++)
						{
							if (xmlRoot["items"].ChildNodes[i].Name == "item")
							{
								Guid g = SongManager.getInstance().getGUID(xmlRoot["items"].ChildNodes[i].InnerText);
								if (g != Guid.Empty)
								{
									ListViewItem lvi = new ListViewItem(SongManager.Instance.SongList[g].Title);
									lvi.Tag = g;
									listViewSetList.Items.Add(lvi);
									buttonSetListClear.Enabled = true;
									buttonSaveSetList.Enabled = true;
								}
							}
						}
						listViewSetList.Columns[0].Width = -2;
					}

				}
				catch (Exception err)
				{
					MessageBox.Show(err.ToString(),"Viewer",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
			}
		}

		private void toolStripButtonDisplaySettings_Click(object sender, EventArgs e)
		{
			// Todo: OS Check
            try
            {
                System.Diagnostics.Process.Start("displayswitch.exe");
            }
            catch
            {
                System.Diagnostics.Process.Start("control", "desk.cpl,@0,4");
            }
		}

		public void setProgessBarTransitionValue(int value)
		{
			progressBarTransition.Value = Math.Min(value,progressBarTransition.Maximum);
		}


		public void setStatus(string text)
		{
            toolStripStatusLabelInfo.Text = text;
			Timer statusTimer = new Timer();
			statusTimer.Interval = 2000;
			statusTimer.Tick += new EventHandler(statusTimer_Tick);
			statusTimer.Start();
		}

		void statusTimer_Tick(object sender, EventArgs e)
		{
            toolStripStatusLabelInfo.Text = string.Empty;
			((Timer)sender).Stop();
			((Timer)sender).Dispose();
		}

		private void liederToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SongDir);
		}

		private void bilderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.ImageDir);
		}

		private void setlistenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Settings.Default.DataDirectory + Path.DirectorySeparatorChar + Settings.Default.SetListDir);
		}

		private void toolStripButtonDataFolder_ButtonClick(object sender, EventArgs e)
		{
			toolStripButtonDataFolder.ShowDropDown();
		}

		private void datenverzeichnisToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Settings.Default.DataDirectory);
		}

		private void toolStripButtonOpenCurrentSong_Click(object sender, EventArgs e)
		{
			if (listViewSongs.SelectedItems.Count > 0)
			{
				EditorWindow wnd = EditorWindow.getInstance();
				wnd.openSong(SongManager.Instance.CurrentSong.FilePath);
				wnd.Show();
				wnd.Focus();
			}
			else
			{
				EditorWindow wnd = EditorWindow.getInstance();
				wnd.Show();
				wnd.Focus();
			}
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			SongDialog dlg = new SongDialog();
			dlg.ShowDialog(this);
			if (dlg.OpenInEditor)
			{
				EditorWindow.getInstance().Show();
				EditorWindow.getInstance().BringToFront();
			}
		}

		private void fehlerMeldenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Settings.Default.BugReportUrl);
		}

		private void praiseBoxDatenbankToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SongImporter dlg = new SongImporter(SongImporter.ImportFormat.PraiseBox);
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				reloadSongList();
			}
		}

		private void worToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SongImporter dlg = new SongImporter(SongImporter.ImportFormat.WorshipSystem);
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				reloadSongList();
			}
		}

		private void powerpraiseLiederToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SongImporter dlg = new SongImporter(SongImporter.ImportFormat.PowerPraise);
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				reloadSongList();
			}
		}

		private void songbeamerLiederToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SongImporter dlg = new SongImporter(SongImporter.ImportFormat.SongBeamer);
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				reloadSongList();
			}
		}

		private void miniaturbilderPrüfenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ImageManager.Instance.checkThumbs();
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
			if (projWindow != null && listViewImageQueue.SelectedIndices.Count > 0)
			{
				Application.DoEvents();
				int idx = listViewImageQueue.SelectedIndices[0];

				Image img = ImageManager.Instance.getImageFromRelPath((string)listViewImageQueue.Items[idx].Tag);
				if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && SongManager.Instance.CurrentSong != null && SongManager.Instance.CurrentSong.CurrentSlide >= 0)
				{
                    Object[] args = { SongManager.Instance.CurrentPartNr, SongManager.Instance.CurrentSlideNr };
					pictureBoxPreview.Image = projWindow.showSlide(SongManager.Instance.CurrentSong, img, args);
				}
				else
				{
                    pictureBoxPreview.Image = projWindow.showSlide(null, img);
				}
                this.currentBackground = img;
			}
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			if (SongManager.Instance.CurrentSong != null)
			{
				QADialog qd = new QADialog();
				qd.ShowDialog(this);
				if (qd.DialogResult == DialogResult.OK)
				{
					//labelComment.Text = SongManager.Instance.CurrentSong.Comment;
					//alignCommentLabel(;
                    if (SongManager.Instance.CurrentSong.Comment != String.Empty || SongManager.Instance.CurrentSong.hasQA())
                    {
                        toolStripButton3.Image = global::Pbp.Properties.Resources.highlight_red;
                    }
                    else
                    {
                        toolStripButton3.Image = global::Pbp.Properties.Resources.highlight;
                    }
				}
			}
			else
			{
				MessageBox.Show("Kein aktives Lied!");
			}			
		}

		private void labelComment_Click(object sender, EventArgs e)
		{
			toolStripButton3_Click(sender, e);
		}

        private void button2_Click_1(object sender, EventArgs e)
        {
            linkLayers = !linkLayers;
            Settings.Default.LinkLayers=linkLayers;
            Settings.Default.Save();
            setLinkLayerUI();
        }

        private void setLinkLayerUI()
        {
            if (linkLayers)
            {
                this.buttonToggleLayerMode.Image = global::Pbp.Properties.Resources.link;   
                label3.Text = "Text und Bild sind verknüpft";
            }
            else
            {
                this.buttonToggleLayerMode.Image = global::Pbp.Properties.Resources.unlink ;  
                
                label3.Text = "Text und Bild sind unabhängig";
            }
        }

        private void listViewFavorites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projWindow != null && listViewFavorites.SelectedIndices.Count > 0)
            {
                Application.DoEvents();
                int idx = listViewFavorites.SelectedIndices[0];
                
                // Stack
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    listViewImageQueue.LargeImageList.Images.Add(ImageManager.Instance.getThumbFromRelPath((string)listViewFavorites.Items[idx].Tag));
                    ListViewItem lvi = new ListViewItem("");
                    lvi.Tag = listViewFavorites.Items[idx].Tag;
                    lvi.ImageIndex = listViewImageQueue.LargeImageList.Images.Count - 1;
                    listViewImageQueue.Items.Add(lvi);
                }
                // ALT remove from favorites
                else if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    imageFavoriterRemove((string)listViewFavorites.Items[idx].Tag);
                    listViewFavorites.Items.RemoveAt(idx);
                }
                else
                {
                    Image img = ImageManager.Instance.getImageFromRelPath((string)listViewFavorites.Items[idx].Tag);
                    if (!linkLayers ^ ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && SongManager.Instance.CurrentSong != null && SongManager.Instance.CurrentSong.CurrentSlide >= 0))
                    {
                        Object[] args = { SongManager.Instance.CurrentPartNr, SongManager.Instance.CurrentSlideNr };
                        pictureBoxPreview.Image = projWindow.showSlide(SongManager.Instance.CurrentSong, img, args);
                    }
                    else
                    {
                        pictureBoxPreview.Image = projWindow.showSlide(null,img);
                    }
                    this.currentBackground = img;

                    // Add image to history
                    imageHistoryAdd((string)listViewFavorites.Items[idx].Tag);
                }
            }
        }


        private void buttonShowLiveText_Click(object sender, EventArgs e)
        {
            LiveText lt = new LiveText(textBoxLiveText.SelectedText != String.Empty ? textBoxLiveText.SelectedText  : textBoxLiveText.Text);
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
            pictureBoxPreview.Image = projWindow.showSlide(lt, currentBackground);
            
        }

        private void buttonClearText_Click(object sender, EventArgs e)
        {
            pictureBoxPreview.Image = projWindow.showSlide(null, currentBackground);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            pictureBoxPreview.Image = projWindow.showSlide(null, currentBackground);
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
            System.Diagnostics.Process.Start(Settings.Default.HelpUrl);
        }

        private void timerSearchBoxHL_Tick(object sender, EventArgs e)
        {
            ((Control)((Timer)sender).Tag).BackColor = SystemColors.Window;
            ((Timer)sender).Stop();
        }

        private void bildschirmeSuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projWindow.scanScreens(1);
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

        private void radioButtonFade0_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {                
                setFadeTimeState(int.Parse((string)((RadioButton)sender).Tag));
            }
        }

        private void setFadeTimeState(int value)
        {
            Settings.Default.ProjectionFadeTime = value;
            Settings.Default.Save();
            UserControl1.getInstance().setFadeSteps(value);
        }

        private void listViewSongHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSongHistory.SelectedIndices.Count > 0)
            {
                SongManager.getInstance().CurrentSong = SongManager.getInstance().SongList[(Guid)listViewSongHistory.SelectedItems[0].Tag];
                showCurrentSongDetails();
            }
        }


        #region Bible

        int bookIdx = -1, chapterIdx = -1, verseIdx = -1, verseToIdx = -1;

        private void loadBibles()
        {
            bool reload = false;
            if (comboBoxBible.Items.Count == 0 || reload)
            {
                comboBoxBible.Items.Clear();
                comboBoxBible.Items.Add("Übersetzung wählen...");
                comboBoxBible.SelectedIndex = 0;
                comboBoxBible.DisplayMember = "Title";

                foreach (string fi in XMLBible.getBibleFiles())
                {
                    XMLBible bbl = new XMLBible(fi);
                    if (bbl.isValid)
                    {
                        comboBoxBible.Items.Add(bbl);
                    }
                }
            }
        }

        private void comboBoxBible_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBible.SelectedIndex > 0)
            {
                listBoxBibleVerse.Items.Clear();
                listBoxBibleVerseTo.Items.Clear();
                listBoxBibleChapter.Items.Clear();

                listBoxBibleBook.Items.Clear();
                listBoxBibleBook.DisplayMember = "Name";

                XMLBible bbl = ((XMLBible)comboBoxBible.SelectedItem);

                foreach (XMLBible.Book bk in bbl.getBooks())
                {
                    listBoxBibleBook.Items.Add(bk);
                }

                if (bookIdx >= 0 && bookIdx < listBoxBibleBook.Items.Count)
                {
                    listBoxBibleBook.SelectedIndex = bookIdx;
                }

                searchTextBoxBible.Enabled = true;
            }
            else
                searchTextBoxBible.Enabled = false;
        }

        private void listBoxBibleBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            XMLBible.Book bk = ((XMLBible.Book)listBoxBibleBook.SelectedItem);

            listBoxBibleVerse.Items.Clear();
            listBoxBibleVerseTo.Items.Clear();

            listBoxBibleChapter.Items.Clear();
            listBoxBibleChapter.DisplayMember = "Number";

            foreach (XMLBible.Chapter cp in bk.getChapters())
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
            XMLBible.Chapter cp = ((XMLBible.Chapter)listBoxBibleChapter.SelectedItem);

            listBoxBibleVerse.Items.Clear();
            listBoxBibleVerseTo.Items.Clear();
            listBoxBibleVerse.DisplayMember = "Number";
            listBoxBibleVerseTo.DisplayMember = "Number";

            foreach (XMLBible.Verse v in cp.getVerses())
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
            XMLBible.Verse v = ((XMLBible.Verse)listBoxBibleVerse.SelectedItem);

            listBoxBibleVerseTo.Items.Clear();
            foreach (XMLBible.Verse tv in v.Chapter.getVerses())
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
                XMLBible.VerseSelection vs = new XMLBible.VerseSelection(((XMLBible.Verse)listBoxBibleVerse.SelectedItem), ((XMLBible.Verse)listBoxBibleVerseTo.SelectedItem));

                labelBibleTextName.Text = vs.ToString();
                textBoxBibleText.Text = vs.Text;

                verseToIdx = listBoxBibleVerseTo.SelectedIndex;

                buttonAddToBibleVerseList.Enabled = true;
            }
        }

        private void buttonBibleTextShow_Click(object sender, EventArgs e)
        {
            BibleLayer bl = new BibleLayer();
            bl.FontSize = (float)numericUpDown2.Value;

            object[] args = { new XMLBible.VerseSelection(((XMLBible.Verse)listBoxBibleVerse.SelectedItem), ((XMLBible.Verse)listBoxBibleVerseTo.SelectedItem)) };

            pictureBoxPreview.Image = projWindow.showSlide(bl, currentBackground,args);
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            pictureBoxPreview.Image = projWindow.showSlide(null, currentBackground);
        }

        private void buttonAddToBibleVerseList_Click(object sender, EventArgs e)
        {
            XMLBible.VerseSelection vs = new XMLBible.VerseSelection(((XMLBible.Verse)listBoxBibleVerse.SelectedItem), ((XMLBible.Verse)listBoxBibleVerseTo.SelectedItem));
            ListViewItem lvi = new ListViewItem(vs.ToString());
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
                XMLBible.VerseSelection vs = (XMLBible.VerseSelection)listViewBibleVerseList.SelectedItems[0].Tag;
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

        XMLBible.Book searchedBook;

        private void searchTextBoxBible_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxBible.SelectedItem != null)
            {
                string needle = searchTextBoxBible.Text.Trim().ToLower();

                if (needle == string.Empty)
                {
                    searchedBook = null;
                }
                else
                {


                    List<XMLBible.Book> bkCandidates = new List<XMLBible.Book>();

                    XMLBible bbl = ((XMLBible)comboBoxBible.SelectedItem);
                    foreach (XMLBible.Book bk in bbl.getBooks())
                    {
                        if (needle.Length <= bk.Name.Length && needle == bk.Name.ToLower().Substring(0, needle.Length))
                        {
                            bkCandidates.Add(bk);
                        }
                    }
                    if (bkCandidates.Count == 1)
                    {
                        searchedBook = bkCandidates[0];

                        if (bkCandidates[0].Name.Length != needle.Length)
                        {
                            searchTextBoxBible.Text = bkCandidates[0].Name + " ";
                            searchTextBoxBible.select(searchTextBoxBible.Text.Length, 0);
                        }

                        listBoxBibleBook.SelectedIndex = bkCandidates[0].Number - 1;
                        labelBibleSearchMsg.ForeColor = Color.Black;
                        labelBibleSearchMsg.Text = "";

                    }
                    else if (bkCandidates.Count == 0)
                    {
                        labelBibleSearchMsg.ForeColor = Color.Red;
                        labelBibleSearchMsg.Text = "Nichts gefunden!";
                    }
                    else
                    {
                        labelBibleSearchMsg.ForeColor = Color.Black;
                        labelBibleSearchMsg.Text = "";
                    }
                }
            }



        }

        #endregion



        private void button1_Click_4(object sender, EventArgs e)
        {
            /*
            PowerPoint.Application oPPT = new PowerPoint.ApplicationClass();
            PowerPoint.Presentations objPresetSet;
            string strPres = "C:/Users/Nicolas/Documents/Visual Studio 2010/Projects/praisebase/Presenter/trunk/bin/Release/foo.pptx";
            //oPPT.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            objPresetSet = oPPT.Presentations;
            PowerPoint.Presentation objPreset = objPresetSet.Open2007(strPres, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoFalse);
            PowerPoint.SlideShowSettings objSSS = objPreset.SlideShowSettings;
            objSSS.StartingSlide = 1;
            objSSS.EndingSlide = objPreset.Slides.Count;
            objSSS.Run();
            while (oPPT.SlideShowWindows.Count >= 1)
            {
                System.Threading.Thread.Sleep(100);
            }
            try
            {
                objPreset.Close();
            }
            catch(
            { 

            }
            oPPT.Quit();
             */ 
        }


    }
}
