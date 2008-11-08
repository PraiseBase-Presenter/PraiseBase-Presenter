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
		
		private Timer blackOutTimer;
        private Timer diaTimer;
		private bool blackout;
        private List<String> imageSearchResults;

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
            projWindow = projectionWindow.getInstance();

			this.WindowState = Settings.Instance.ViewerWindowState;
			this.Text += " " + Settings.Instance.Version;

            blackout = false;
            blackOutTimer = new Timer(); // Timer anlegen
            blackOutTimer.Interval = 500; // Intervall festlegen, hier 100 ms
            blackOutTimer.Tick += new EventHandler(t1_Tick); // Eventhandler ezeugen der beim Timerablauf aufgerufen wird

            loadSongList();
            songSearchBox.Focus();

            imageTreeViewInit();

			trackBarFadeTimer.Value = Settings.Instance.ProjectionFadeTime;
			labelFadeTime.Text = Settings.Instance.ProjectionFadeTime.ToString(); // + " ms";
			UserControl1.getInstance().setFadeSteps(Settings.Instance.ProjectionFadeTime);

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
            searchSongs(songSearchBox.Text);
        }


        private void songSearchResetButton_Click(object sender, EventArgs e)
        {
            songSearchBox.Text = "";
            songSearchBox.Focus();
        }

        /**
         * Load Songs
         */
        void loadSongList()
        {
			SongManager songMan = SongManager.getInstance();

            toolStripStatusLabel.Text = "Lade Liederliste...";
            
            listViewSongs.Items.Clear();
            int cnt = 0;
            foreach (Song sng in songMan.Songs)
            {
                ListViewItem lvi = new ListViewItem(sng.Title);
                lvi.Tag = sng.ID;
                listViewSongs.Items.Add(lvi);
                cnt++;
            }
            listViewSongs.Columns[0].Width = -2;
			setStatus(cnt.ToString() + " Lieder geladen");
        }

        void searchSongs(string needle)
        {
			SongManager songMan = SongManager.getInstance();

            listViewSongs.Items.Clear();
            int cnt = 0;
            foreach (Song sng in songMan.getSearchResults(needle,radioSongSearchAll.Checked ? 1 : 0))
            {
                ListViewItem lvi = new ListViewItem(sng.Title);
                lvi.Tag = sng.ID;
                listViewSongs.Items.Add(lvi);
                cnt++;
            }
            if (cnt == 1)
            {
                if (listViewSongs.Items.Count>0)
                {
                    try
                    {

                        listViewSongs.Items[0].Selected = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }

                 }
            }
            listViewSongs.Columns[0].Width = -2;
        }


        private void radioSongSearchAll_CheckedChanged(object sender, EventArgs e)
        {
            searchSongs(songSearchBox.Text);
        }

        private void songDetailItems_Leave(object sender, EventArgs e)
        {
			try
			{
				int idx = songDetailItems.SelectedIndices[0];
				songDetailItems.Items[idx].Selected = false;
			}
			catch
			{

			}
        }


        private void bildschirmeErneutSuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projWindow.scanScreens(1);
        }



        private void toggleProjection(object sender, EventArgs e)
        {
			if ((sender.GetType() == typeof(ToolStripButton) && ((ToolStripButton)sender).Name == "toolStripButtonProjectionOff") 
				|| (projWindow.Visible 
					&& ((ToolStripButton)sender).Name != "toolStripButtonProjectionOn"))
			{
				toolStripButtonProjectionOff.CheckState = CheckState.Checked;
				toolStripButtonProjectionOn.CheckState = CheckState.Unchecked;
				projWindow.Hide();
			}
            else
            {
                toolStripButtonProjectionOff.CheckState = CheckState.Unchecked;
                toolStripButtonProjectionOn.CheckState = CheckState.Checked;
                projWindow.Show();
            }
            songSearchBox.Focus();
        }


        private void toggleBlackOut(object sender, EventArgs e)
        {
            if (blackout)
            {
                blackOutTimer.Stop();
                blackout = false;
                toolStripButton2.CheckState = CheckState.Unchecked;
                toolStripButton2.Image = global::Pbp.Properties.Resources.Blackout_on;
				UserControl1.getInstance().blackOut(false);
            }
            else
            {
                blackout = true;
                toolStripButton2.CheckState = CheckState.Checked;
				UserControl1.getInstance().blackOut(true);
                toolStripButton2.Image = global::Pbp.Properties.Resources.Blackout_on2;
                blackOutTimer.Tag = 1;
                blackOutTimer.Start();
            }
        }

        void t1_Tick(object sender, EventArgs e)
        {
            if ((int)blackOutTimer.Tag == 1)
            {
                toolStripButton2.Image = global::Pbp.Properties.Resources.Blackout_on;
                blackOutTimer.Tag = 0;
            }
            else
            {
                toolStripButton2.Image = global::Pbp.Properties.Resources.Blackout_on2;
                blackOutTimer.Tag = 1;
            }
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
			songSearchBox.Text = "";
			SongManager.getInstance().reload();
			loadSongList();
			songSearchBox.Focus();
			GC.Collect();
		}

        /**
         * Load song details based on song list selection 
         */
		/*
        private void listViewSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (listViewSongs.SelectedIndices.Count > 0)
			{
				SongManager.getInstance().CurrentSong = SongManager.getInstance().Songs[(int)listViewSongs.SelectedItems[0].Tag];
				showCurrentSongDetails();
				buttonSetListAdd.Enabled = true;
			}
			else
			{
				buttonSetListAdd.Enabled = false;
			}
        }
		*/

		private void listViewSongs_MouseClick(object sender, MouseEventArgs e)
		{
			if (listViewSongs.SelectedItems.Count > 0)
			{
				if (e.Button == MouseButtons.Right)
				{
					listViewSetList.Items.Add((ListViewItem)listViewSongs.SelectedItems[0].Clone());
					listViewSetList.Columns[0].Width = -2;
					buttonSetListClear.Enabled = true;
					buttonSaveSetList.Enabled = true;
				}
				buttonSetListAdd.Enabled = true;
			}
			else
			{
				buttonSetListAdd.Enabled = false;
			}
		}


		private void listViewSongs_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (listViewSongs.SelectedIndices.Count > 0)
			{
				SongManager.getInstance().CurrentSong = SongManager.getInstance().Songs[(int)listViewSongs.SelectedItems[0].Tag];
				showCurrentSongDetails();
				buttonSetListAdd.Enabled = true;
			}
		}


		private void showCurrentSongDetails()
		{
			SongManager songMan = SongManager.getInstance();
			Application.DoEvents();

			songDetailItems.Items.Clear();
			songDetailImages.Items.Clear();

			songDetailImages.LargeImageList = songMan.CurrentSong.getThumbs();
			for (int i = 1; i < songDetailImages.LargeImageList.Images.Count; i++)
			{
				ListViewItem lvi = new ListViewItem();
				lvi.ImageIndex = i;
				songDetailImages.Items.Add(lvi);
			}

			songDetailItems.SmallImageList = songMan.CurrentSong.getThumbs();
			foreach (Song.Part prt in songMan.CurrentSong.Parts)
			{
				int sj = 1;
				foreach (Song.Slide sld in prt.Slides)
				{
					ListViewItem lvi = new ListViewItem(new string[] 
                        { 
                            prt.Slides.Count > 1 ? prt.Caption + " ("+sj+")" : prt.Caption, 
                            sld.oneLineText() }
					);
					lvi.ImageIndex = sld.ImageNumber;
					songDetailItems.Items.Add(lvi);
					sj++;
				}
			}

			songDetailItems.Columns[0].Width = -2;
			songDetailItems.Columns[1].Width = -2;

			commentCancel();
			buttonCommentEnable.Enabled = true;
			textBoxComment.Text = songMan.CurrentSong.Comment;
			if (textBoxComment.Text != "")
				buttonClearComment.Enabled = true;

			checkBoxQASpelling.Checked = songMan.CurrentSong.getQA(Song.QualityAssuranceIndicators.Spelling);
			checkBoxQATranslation.Checked = songMan.CurrentSong.getQA(Song.QualityAssuranceIndicators.Translation);
			checkBoxQAImages.Checked = songMan.CurrentSong.getQA(Song.QualityAssuranceIndicators.Images);
			checkBoxQASegmentation.Checked = songMan.CurrentSong.getQA(Song.QualityAssuranceIndicators.Segmentation);

			groupBox3.Text = "Lied-Details '" + songMan.CurrentSong.Title + "'";
		}

        private void songDetailItems_SelectedIndexChanged(object sender, EventArgs e)
        {
			SongManager songMan = SongManager.getInstance();

            if (projWindow != null && songDetailItems.SelectedIndices.Count > 0)
            {
                Application.DoEvents();
                songMan.CurrentSong.CurrentSlide = songDetailItems.SelectedIndices[0];

                toolStripStatusLabel.Text = "Projiziere '" + songMan.CurrentSong.Title + "' ...";

                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                {
					pictureBoxPreview.Image = projWindow.showSlide(songMan.CurrentSong.Slides[songMan.CurrentSong.CurrentSlide], null, false);
                }
                else
                {
					pictureBoxPreview.Image = projWindow.showSlide(songMan.CurrentSong.Slides[songMan.CurrentSong.CurrentSlide], songMan.CurrentSong.getImage(songMan.CurrentSong.Slides[songMan.CurrentSong.CurrentSlide].ImageNumber), false);
                }
				setStatus("'" + songMan.CurrentSong.Title + "' ist aktiv");
            }
        }

        private void songDetailImages_SelectedIndexChanged(object sender, EventArgs e)
        {
			SongManager songMan = SongManager.getInstance();

            if (projWindow != null && songDetailImages.SelectedIndices.Count > 0)
            {
                Application.DoEvents();
                int idx = songDetailImages.SelectedIndices[0];
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                {
					pictureBoxPreview.Image = projWindow.showSlide(songMan.CurrentSong.Slides[songMan.CurrentSong.CurrentSlide], songMan.CurrentSong.getImage(idx + 1), false);
                }
                else
                {
					pictureBoxPreview.Image = projWindow.showImage(songMan.CurrentSong.getImage(idx + 1));
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                songSearchBox.Focus();
            else if (tabControl1.SelectedIndex == 1)
            {
                textBoxImageSearch.Focus();
            }
        }

        private void webToolStripMenuItem_Click(object sender, EventArgs e)
        {
			System.Diagnostics.Process.Start(Settings.Instance.Weburl);
        }


        private void songDetailImages_Leave(object sender, EventArgs e)
        {
			if (songDetailImages.SelectedIndices.Count > 0)
			{
				int idx = songDetailImages.SelectedIndices[0];
				songDetailImages.Items[idx].Selected = false;
			}
        }


        private void songSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return 
                && listViewSongs.Items.Count == 1 
                && listViewSongs.Items[0].Selected == true 
                && songDetailItems.Items.Count >0)
            {
                int i = 0;
                int sldIdx = 0;
                foreach (ListViewItem itm in songDetailItems.Items)
                {
                    if (itm.SubItems[1].Text.ToLower().Contains(songSearchBox.Text.ToLower()))
                    {
                        sldIdx = i;
                        break;
                    }
                    i++;
                }
                songDetailItems.Items[sldIdx].Selected = true;
                
            }
        }


        public void imageTreeViewInit()
        {
			string rootDir = Settings.Instance.DataDirectory + Path.DirectorySeparatorChar + Settings.Instance.ImageDir;
            treeViewImageDirectories.Nodes.Clear();
            TreeNode rootTreeNode = new TreeNode("Bilder");
            rootTreeNode.Tag = rootDir;
            treeViewImageDirectories.Nodes.Add(rootTreeNode);
            PopulateTreeView(rootDir, treeViewImageDirectories.Nodes[0]);
            treeViewImageDirectories.Nodes[0].Expand();
            treeViewImageDirectories.Nodes.Add("Suchergebnisse");

            imageSearchResults = new List<String>();

            ImageList iml = new ImageList();
			iml.ImageSize = Settings.Instance.ThumbSize;
            iml.ColorDepth = ColorDepth.Depth32Bit;
			listViewImageHistory.LargeImageList = iml;
			listViewImageHistory.TileSize = new Size(Settings.Instance.ThumbSize.Width + 8,Settings.Instance.ThumbSize.Height + 5) ;
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
						int subLen = (Settings.Instance.DataDirectory + Path.DirectorySeparatorChar + Settings.Instance.ImageDir + Path.DirectorySeparatorChar).Length;
                        foreach (string directory in directoryArray)
                        {
                            string dName = Path.GetFileName(directory);
                            if (dName.Substring(0, 1) != "[" && dName.Substring(0, 1) != ".")
                            {
                                TreeNode myNode = new TreeNode(dName);

								myNode.Tag = directory.Substring(subLen);
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
            listViewDirectoryImages.Items.Clear();
            if (listViewDirectoryImages.LargeImageList != null)
            {
                listViewDirectoryImages.LargeImageList.Dispose();
            }
            if (treeViewImageDirectories.SelectedNode == treeViewImageDirectories.Nodes[1])
            {
                    labelImgDirName.Text = "Suchergebnisse";

                    ImageList imList = new ImageList();
					imList.ImageSize = Settings.Instance.ThumbSize;
                    imList.ColorDepth = ColorDepth.Depth32Bit;
                    listViewDirectoryImages.LargeImageList = imList;

                    int i = 0;
                    foreach (string file in imageSearchResults)
                    {
                        ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(file));
                        lvi.Tag = file;
                        lvi.ImageIndex = i;
                        listViewDirectoryImages.LargeImageList.Images.Add(Image.FromFile(file));
                        listViewDirectoryImages.Items.Add(lvi);
                        i++;
                        Application.DoEvents();
                    }
            }
            else
            {
				string relativeImageDir = ((string)treeViewImageDirectories.SelectedNode.Tag);
				string imDir = Settings.Instance.DataDirectory + Path.DirectorySeparatorChar + Settings.Instance.ThumbDir + Path.DirectorySeparatorChar + relativeImageDir;

				if (Directory.Exists(imDir))
				{
					labelImgDirName.Text = "Verzeichnisinhalt '" + Path.GetFileName(relativeImageDir) + "':";

					ImageList imList = new ImageList();
					imList.ImageSize = Settings.Instance.ThumbSize;
					imList.ColorDepth = ColorDepth.Depth32Bit;

					string[] songFilePaths = Directory.GetFiles(imDir, "*.jpg", SearchOption.TopDirectoryOnly);
					int i = 0;
					
					foreach (string file in songFilePaths)
					{
						Application.DoEvents();
						ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(file));
						lvi.Tag = relativeImageDir + Path.DirectorySeparatorChar + Path.GetFileName(file);
						lvi.ImageIndex = i;
						listViewDirectoryImages.Items.Add(lvi);
						imList.Images.Add(Image.FromFile(file));
						i++;
					}
					listViewDirectoryImages.LargeImageList = imList;
				}
            }

        }

        private void listViewDirectoryImages_SelectedIndexChanged(object sender, EventArgs e)
        {
			SongManager songMan = SongManager.getInstance();

            if (projWindow != null && listViewDirectoryImages.SelectedIndices.Count > 0)
            {
                Application.DoEvents();
                int idx = listViewDirectoryImages.SelectedIndices[0];

				Image img = ImageManager.Instance.getImageFromRelPath((string)listViewDirectoryImages.Items[idx].Tag);
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && songMan.CurrentSong != null && songMan.CurrentSong.CurrentSlide>=0)
                {
					pictureBoxPreview.Image = projWindow.showSlide(songMan.CurrentSong.Slides[songMan.CurrentSong.CurrentSlide], img, false);
                }
                else
                {
					pictureBoxPreview.Image = projWindow.showImage(img);
                }

                // History
                if (listViewImageHistory.Items.Count==0 || (string)listViewImageHistory.Items[listViewImageHistory.Items.Count - 1].Tag != (string)listViewDirectoryImages.Items[idx].Tag)
                {
                    listViewImageHistory.LargeImageList.Images.Add(ImageManager.Instance.getThumbFromRelPath((string)listViewDirectoryImages.Items[idx].Tag));

                    if (listViewImageHistory.Items.Count > 20)
                    {
                        listViewImageHistory.Items.RemoveAt(0);
                    }

                    ListViewItem lvi = new ListViewItem("");
                    lvi.Tag = listViewDirectoryImages.Items[idx].Tag;
					lvi.ImageIndex = listViewImageHistory.LargeImageList.Images.Count - 1;
                    listViewImageHistory.Items.Add(lvi);
                    listViewImageHistory.EnsureVisible(listViewImageHistory.Items.Count-1);
                }

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

        private void textBoxSongComment_TextChanged(object sender, EventArgs e)
        {

        }

        private void songSearchBox_Click(object sender, EventArgs e)
        {
            songSearchBox.SelectAll();
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
				imList.ImageSize = Settings.Instance.ThumbSize;
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
            if (diaTimer!= null && diaTimer.Enabled)
            {
                diaTimer.Stop();
                projWindow.showNone();
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
				pictureBoxPreview.Image = projWindow.showImage(Image.FromFile(diaStack.Dequeue()));
                diaTimer.Start();
            }
        }

        private void diaTimer_Tick(object sender, EventArgs e)
        {
            if (((Queue<string>)((Timer)sender).Tag).Count == 0)
            {
                    ((Timer)sender).Stop();
                    projWindow.showNone();
                    buttonDiaShow.Text = "Diaschau starten";
                    return;                
            }
			pictureBoxPreview.Image = projWindow.showImage(Image.FromFile(((Queue<string>)((Timer)sender).Tag).Dequeue()));
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
			SongManager songMan = SongManager.getInstance();

            if (songMan.CurrentSong != null)
            {
				if (((CheckBox)sender).Checked)
					songMan.CurrentSong.setQA(Song.QualityAssuranceIndicators.Spelling);
				else
					songMan.CurrentSong.remQA(Song.QualityAssuranceIndicators.Spelling);
				songMan.CurrentSong.save(null);
				setStatus("Qualitätssicherungs-Information gespeichert!");
            }
        }

        private void checkBoxQATranslation_CheckedChanged(object sender, EventArgs e)
        {
			SongManager songMan = SongManager.getInstance();

            if (songMan.CurrentSong != null)
            {
				if (((CheckBox)sender).Checked)
					songMan.CurrentSong.setQA(Song.QualityAssuranceIndicators.Translation);
				else
					songMan.CurrentSong.remQA(Song.QualityAssuranceIndicators.Translation);
				songMan.CurrentSong.save(null);
				setStatus("Qualitätssicherungs-Information gespeichert!");
            }
        }

        private void checkBoxQAImages_CheckedChanged(object sender, EventArgs e)
        {
			SongManager songMan = SongManager.getInstance();

            if (songMan.CurrentSong != null)
            {
				if (((CheckBox)sender).Checked)
					songMan.CurrentSong.setQA(Song.QualityAssuranceIndicators.Images);
				else
					songMan.CurrentSong.remQA(Song.QualityAssuranceIndicators.Images);
				songMan.CurrentSong.save(null);
				setStatus("Qualitätssicherungs-Information gespeichert!");
            }
        }

		private void checkBoxQASegmentation_CheckedChanged(object sender, EventArgs e)
		{
			SongManager songMan = SongManager.getInstance();

			if (songMan.CurrentSong != null)
			{
				if (((CheckBox)sender).Checked)
					songMan.CurrentSong.setQA(Song.QualityAssuranceIndicators.Segmentation);
				else
					songMan.CurrentSong.remQA(Song.QualityAssuranceIndicators.Segmentation);
				songMan.CurrentSong.save(null);
				setStatus("Qualitätssicherungs-Information gespeichert!");
			}
		}

        private void listViewDirectoryImages_Leave(object sender, EventArgs e)
        {
			SongManager songMan = SongManager.getInstance();

            if (listViewDirectoryImages.SelectedIndices.Count > 0)
            {
                int idx = listViewDirectoryImages.SelectedIndices[0];
                listViewDirectoryImages.Items[idx].Selected = false;
            }
        }

        private void listViewImageHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
			SongManager songMan = SongManager.getInstance();

            if (projWindow != null && listViewImageHistory.SelectedIndices.Count > 0)
            {
                Application.DoEvents();
                int idx = listViewImageHistory.SelectedIndices[0];

				Image img = ImageManager.Instance.getImageFromRelPath((string)listViewImageHistory.Items[idx].Tag);
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && songMan.CurrentSong != null && songMan.CurrentSong.CurrentSlide >= 0)
                {
					pictureBoxPreview.Image = projWindow.showSlide(songMan.CurrentSong.Slides[songMan.CurrentSong.CurrentSlide], img, false);
                }
                else
                {
					pictureBoxPreview.Image = projWindow.showImage(img);
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



        private void buttonSearchImages_Click(object sender, EventArgs e)
        {
            string haystack = textBoxImageSearch.Text.ToLower().Trim();
            if (haystack != String.Empty)
            {
                treeViewImageDirectories.SelectedNode = null;
                imageSearchResults.Clear();
				string[] imgFilePaths = Directory.GetFiles(Settings.Instance.DataDirectory + Path.DirectorySeparatorChar + Settings.Instance.ImageDir, "*.jpg", SearchOption.AllDirectories);
                foreach (string ims in imgFilePaths)
                {
                    if (!ims.Contains("[Thumbnails]"))
                    {
                        string needle = Path.GetFileNameWithoutExtension(ims);
                        if (needle.ToLower().Contains(haystack))
                        {
                            imageSearchResults.Add(ims);
                        }
                    }
                }
                treeViewImageDirectories.SelectedNode = treeViewImageDirectories.Nodes[1];
            }
            textBoxImageSearch.SelectAll();
            textBoxImageSearch.Focus();
        }

        private void textBoxImageSearch_Click(object sender, EventArgs e)
        {
            textBoxImageSearch.SelectAll();
        }

        private void textBoxImageSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && textBoxImageSearch.Text.Trim() != String.Empty)
            {
                buttonSearchImages_Click(sender, e);
            }
        }

		private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Instance.ViewerWindowState = this.WindowState;
			Settings.Instance.Save();
		}

		private void datenverzeichnisÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Settings.Instance.DataDirectory);
		}

		private void toolStripButtonDataFolder_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Settings.Instance.DataDirectory);
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

		private void listViewSetList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewSetList.SelectedIndices.Count > 0)
			{
				if (tabControl1.SelectedIndex != 0)
					tabControl1.SelectedIndex = 0;

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

				SongManager.getInstance().CurrentSong = SongManager.getInstance().Songs[(int)listViewSetList.SelectedItems[0].Tag];
				showCurrentSongDetails();
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
			//dlg.FileName = 
			dlg.Filter = "PraiseBase-Presenter Setliste (*.pbpl)|*.pbpl";
			dlg.InitialDirectory = Settings.Instance.DataDirectory + Path.DirectorySeparatorChar + Settings.Instance.SetListDir;
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
					nd.InnerText = SongManager.getInstance().Songs[(int)listViewSetList.Items[i].Tag].Title;
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
			dlg.InitialDirectory = Settings.Instance.DataDirectory + Path.DirectorySeparatorChar + Settings.Instance.SetListDir;
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
								int id = SongManager.getInstance().getIdByTitle(xmlRoot["items"].ChildNodes[i].InnerText);
								if (id != -1)
								{
									ListViewItem lvi = new ListViewItem(xmlRoot["items"].ChildNodes[i].InnerText);
									lvi.Tag = id;
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

		private void trackBarFadeTimer_Scroll(object sender, EventArgs e)
		{
			labelFadeTime.Text = trackBarFadeTimer.Value.ToString(); // +" ms";
			Settings.Instance.ProjectionFadeTime = trackBarFadeTimer.Value;
			Settings.Instance.Save();
			UserControl1.getInstance().setFadeSteps(trackBarFadeTimer.Value);
		}

		private void trackBarFadeTimer_MouseUp(object sender, MouseEventArgs e)
		{
		}

		private void toolStripButtonDisplaySettings_Click(object sender, EventArgs e)
		{
			// Todo: OS Check
			System.Diagnostics.Process.Start("control", "desk.cpl,@0,4");
		}

		public void setProgessBarTransitionValue(int value)
		{
			progressBarTransition.Value = Math.Min(value,progressBarTransition.Maximum);
		}

		private void buttonCommentEnable_Click(object sender, EventArgs e)
		{
			if (!textBoxComment.ReadOnly)
			{
				commentSave();
			}
			else
			{
				commentEdit();
			}
		}

		private void commentEdit()
		{
			if (SongManager.getInstance().CurrentSong != null)
			{
				buttonCommentEnable.Image = global::Pbp.Properties.Resources.filesave;
				textBoxComment.BackColor = SystemColors.Window;
				textBoxComment.ReadOnly = false;
				textBoxComment.SelectAll();
				textBoxComment.Focus();
			}
		}

		private void commentCancel()
		{
			buttonCommentEnable.Image = global::Pbp.Properties.Resources.edit;
			textBoxComment.BackColor = SystemColors.Info;
			textBoxComment.ReadOnly = true;
		}

		private void commentSave()
		{
			buttonCommentEnable.Image = global::Pbp.Properties.Resources.edit;
			textBoxComment.BackColor = SystemColors.Info;
			textBoxComment.ReadOnly = true;
			SongManager.getInstance().CurrentSong.Comment = textBoxComment.Text.Trim();
			SongManager.getInstance().CurrentSong.save(null);
			setStatus("Kommentar gespeichert!");
		}

		private void textBoxComment_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (textBoxComment.ReadOnly)
				commentEdit();
		}

		private void buttonClearComment_Click(object sender, EventArgs e)
		{
			if (SongManager.getInstance().CurrentSong != null)
			{
				textBoxComment.Text = "";
				commentSave();
				buttonClearComment.Enabled = false;
			}
		}

		private void textBoxComment_TextChanged(object sender, EventArgs e)
		{
			if (textBoxComment.Text != "")
				buttonClearComment.Enabled = true;
		}

		public void setStatus(string text)
		{
			toolStripStatusLabel.Text = text;
			Timer statusTimer = new Timer();
			statusTimer.Interval = 2000;
			statusTimer.Tick += new EventHandler(statusTimer_Tick);
			statusTimer.Start();
		}

		void statusTimer_Tick(object sender, EventArgs e)
		{
			toolStripStatusLabel.Text = string.Empty;
			((Timer)sender).Stop();
			((Timer)sender).Dispose();
		}

		private void liederToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Settings.Instance.DataDirectory + Path.DirectorySeparatorChar + Settings.Instance.SongDir);
		}

		private void bilderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Settings.Instance.DataDirectory + Path.DirectorySeparatorChar + Settings.Instance.ImageDir);
		}

		private void setlistenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Settings.Instance.DataDirectory + Path.DirectorySeparatorChar + Settings.Instance.SetListDir);
		}

		private void toolStripButtonDataFolder_ButtonClick(object sender, EventArgs e)
		{
			toolStripButtonDataFolder.ShowDropDown();
		}

		private void datenverzeichnisToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Settings.Instance.DataDirectory);
		}

		private void toolStripButtonOpenCurrentSong_Click(object sender, EventArgs e)
		{
			if (listViewSongs.SelectedItems.Count > 0)
			{
				EditorWindow wnd = EditorWindow.getInstance();
				wnd.openSong(SongManager.Instance.Songs[(int)listViewSongs.SelectedItems[0].Tag].FilePath);
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
		}

		private void fehlerMeldenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Settings.Instance.BugReportUrl);
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

		private void listViewSetList_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private void listViewSetList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			listViewSetList.DoDragDrop(listViewSetList.SelectedItems[0],DragDropEffects.Move);
		}

		private void listViewSetList_DragDrop(object sender, DragEventArgs e)
		{
			//listViewSetList.Items.Add((ListViewItem)e.Data.GetData(typeof(ListViewItem)));
		}



    }
}
