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

namespace Pbp
{
    public partial class mainWindow : Form
    {
        private bool blackout;

        private Settings setting;
        private projectionWindow projWindow;

        private Font projectionFont;
        private Color projctionBackgroundColor;

        private Timer t1;
        private Timer diaTimer;

        SongManager songMan;
        ImageManager imgMan;

        private List<String> imageSearchResults;

        public mainWindow()
        {
            setting = new Settings();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            projWindow = projectionWindow.getInstance();
            songMan = SongManager.getInstance();
            imgMan = ImageManager.getInstance();

            blackout = false;
            t1 = new Timer(); // Timer anlegen
            t1.Interval = 500; // Intervall festlegen, hier 100 ms
            t1.Tick += new EventHandler(t1_Tick); // Eventhandler ezeugen der beim Timerablauf aufgerufen wird

            projectionFont = setting.projectionMasterFont;
            projctionBackgroundColor = setting.projectionBackColor;

            loadSongList();
            songSearchBox.Focus();

            imageTreeViewInit();
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
            toolStripStatusLabel.Text = "Lade Liederliste...";
            
            listViewSongs.Items.Clear();
            int cnt = 0;
            foreach (Song sng in songMan.getAll())
            {
                ListViewItem lvi = new ListViewItem(sng.title);
                lvi.Tag = sng.id;
                listViewSongs.Items.Add(lvi);
                cnt++;
            }
            listViewSongs.Columns[0].Width = -2;
            toolStripStatusLabel.Text = cnt.ToString() + " Lieder geladen";
        }

        void searchSongs(string needle)
        {
            listViewSongs.Items.Clear();
            int cnt = 0;
            foreach (Song sng in songMan.getSearchResults(needle,radioSongSearchAll.Checked ? 1 : 0))
            {
                ListViewItem lvi = new ListViewItem(sng.title);
                lvi.Tag = sng.id;
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
            int idx = songDetailItems.SelectedIndices[0];
            songDetailItems.Items[idx].Selected = false;
        }


        private void bildschirmeErneutSuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projWindow.scanScreens(1);
        }



        // 
        // Tool Strip
        //

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (projWindow.Visible)
            {
                toolStripButton1.CheckState = CheckState.Checked;
                toolStripButton3.CheckState = CheckState.Unchecked;
                projWindow.Hide();
            }
            songSearchBox.Focus();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!projWindow.Visible)
            {
                toolStripButton1.CheckState = CheckState.Unchecked;
                toolStripButton3.CheckState = CheckState.Checked;
                projWindow.Show();
            }
            songSearchBox.Focus();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (blackout)
            {
                t1.Stop();
                blackout = false;
                toolStripButton2.CheckState = CheckState.Unchecked;
                toolStripButton2.Image = global::Pbp.Properties.Resources.Blackout_on;
                projWindow.blackout(0);
            }
            else
            {
                blackout = true;
                toolStripButton2.CheckState = CheckState.Checked;
                projWindow.blackout(1);
                toolStripButton2.Image = global::Pbp.Properties.Resources.Blackout_on2;
                t1.Tag = 1;
                t1.Start();
            }
        }

        void t1_Tick(object sender, EventArgs e)
        {
            if ((int)t1.Tag == 1)
            {
                toolStripButton2.Image = global::Pbp.Properties.Resources.Blackout_on;
                t1.Tag = 0;
            }
            else
            {
                toolStripButton2.Image = global::Pbp.Properties.Resources.Blackout_on2;
                t1.Tag = 1;
            }
        }

        private void optionenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsWindow stWnd = new settingsWindow();
            if (stWnd.ShowDialog(this) == DialogResult.OK)
            {
                setting.Reload();
            }            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            settingsWindow stWnd = new settingsWindow();
            if (stWnd.ShowDialog(this) == DialogResult.OK)
            {
                setting.Reload();
            }
        }

        private void liederlisteNeuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            songSearchBox.Text = "";
            songMan.loadSongs();
            loadSongList();
            songSearchBox.Focus();
            GC.Collect();
        }

        /**
         * Load song details based on song list selection 
         */
        private void listViewSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSongs.SelectedIndices.Count > 0)
            {
                songMan.currentSong = songMan.get((int)listViewSongs.SelectedItems[0].Tag);

                Application.DoEvents();

                songDetailItems.Items.Clear();
                songDetailImages.Items.Clear();

                songDetailItems.SmallImageList = songMan.currentSong.getThumbs();

                ImageList songImages = songMan.currentSong.getThumbs();
                songDetailImages.LargeImageList = songImages;
                for (int i = 0; i < songImages.Images.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageIndex = i;
                    songDetailImages.Items.Add(lvi);
                }

                foreach (Song.Part prt in songMan.currentSong.parts)
                {
                    int sj = 1;
                    foreach (Song.Slide sld in prt.partSlides)
                    {
                        ListViewItem lvi = new ListViewItem(new string[] 
                        { 
                            prt.partSlides.Count > 1 ? prt.caption + " ("+sj+")" : prt.caption, 
                            sld.oneLineText() }
                        );
                        lvi.ImageIndex = sld.imageNumber;
                        songDetailItems.Items.Add(lvi);
                        sj++;
                    }
                }

                songDetailItems.Columns[0].Width = -2;
                songDetailItems.Columns[1].Width = -2;

                // Set comment
                setSongComment(songMan.currentSong.comment);

                checkBoxQASpelling.Checked = songMan.currentSong.QASpelling;
                checkBoxQATranslation.Checked = songMan.currentSong.QATranslation;
                checkBoxQAImages.Checked = songMan.currentSong.QAImage;
                checkBoxQASegmentation.Checked = songMan.currentSong.QASegmentation;

                groupBox3.Text = "Lied-Details '" + songMan.currentSong.title + "'";
            }            
        }

        private void songDetailItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projWindow != null && songDetailItems.SelectedIndices.Count > 0)
            {
                Application.DoEvents();
                songMan.currentSong.currentSlide = songDetailItems.SelectedIndices[0];

                toolStripStatusLabel.Text = "Projiziere '" + songMan.currentSong.title + "' ...";

                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                {
                    projWindow.showSlide(songMan.currentSong.slides[songMan.currentSong.currentSlide], null, false);
                }
                else
                {
                    projWindow.showSlide(songMan.currentSong.slides[songMan.currentSong.currentSlide], songMan.currentSong.getImage(songMan.currentSong.slides[songMan.currentSong.currentSlide].imageNumber), false);
                }
                toolStripStatusLabel.Text = "'" + songMan.currentSong.title + "' ist aktiv";
            }
        }

        private void songDetailImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projWindow != null && songDetailImages.SelectedIndices.Count > 0)
            {
                Application.DoEvents();
                int idx = songDetailImages.SelectedIndices[0];
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                {
                    projWindow.showSlide(songMan.currentSong.slides[songMan.currentSong.currentSlide],songMan.currentSong.getImage(idx), false);
                }
                else
                {
                    projWindow.showImage(songMan.currentSong.getImage(idx));
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
            System.Diagnostics.Process.Start("http://www.nicu.ch/pbp");
        }



        private void songDetailImages_Leave(object sender, EventArgs e)
        {
            int idx = songDetailImages.SelectedIndices[0];
            songDetailImages.Items[idx].Selected = false;
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


        //
        // Song comments
        //

        private void textBoxSongComment_DoubleClick(object sender, EventArgs e)
        {
            editSongComment();
        }

        public void setSongComment(string cmt)
        {
            textBoxSongComment.Text = cmt;
            textBoxSongComment.Enabled = true;
        }

        public void editSongComment()
        {
            textBoxSongComment.ReadOnly = false;
            textBoxSongComment.BackColor = Color.White;
            toolStripStatusLabel.Text = "Zum Beenden der Kommentarfunktion ENTER drücken";
        }

        public void saveSongComment()
        {
            textBoxSongComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            textBoxSongComment.ReadOnly = true;
            if (songMan.currentSong != null)
            {
                toolStripStatusLabel.Text = "Kommentar gespeichert";
                songMan.currentSong.comment = textBoxSongComment.Text;
                songMan.currentSong.save(null);
            }
        }

        private void textBoxSongComment_Leave(object sender, EventArgs e)
        {
            saveSongComment();
        }

        private void textBoxSongComment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                saveSongComment();
            }
        }


        public void imageTreeViewInit()
        {
            string rootDir = setting.dataDirectory + Path.DirectorySeparatorChar + setting.imageDir;
            treeViewImageDirectories.Nodes.Clear();
            TreeNode rootTreeNode = new TreeNode("Bilder");
            rootTreeNode.Tag = rootDir;
            treeViewImageDirectories.Nodes.Add(rootTreeNode);
            PopulateTreeView(rootDir, treeViewImageDirectories.Nodes[0]);
            treeViewImageDirectories.Nodes[0].Expand();
            treeViewImageDirectories.Nodes.Add("Suchergebnisse");

            imageSearchResults = new List<String>();

            ImageList iml = new ImageList();
            iml.ImageSize = new Size(150, 112);
            iml.ColorDepth = ColorDepth.Depth32Bit;
            listViewImageHistory.LargeImageList = iml;
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
                        foreach (string directory in directoryArray)
                        {
                            string dName = Path.GetFileName(directory);
                            if (dName.Substring(0, 1) != "[" && dName.Substring(0, 1) != ".")
                            {
                                TreeNode myNode = new TreeNode(dName);
                                myNode.Tag = directory;
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
                    imList.ImageSize = new Size(150, 112);
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
            else if (Directory.Exists((string)treeViewImageDirectories.SelectedNode.Tag))
            {


                labelImgDirName.Text = "Verzeichnisinhalt '" + Path.GetFileName((string)treeViewImageDirectories.SelectedNode.Tag) + "':";

                ImageList imList = new ImageList();
                imList.ImageSize = new Size(150, 112);
                imList.ColorDepth = ColorDepth.Depth32Bit;

                string[] songFilePaths = Directory.GetFiles((string)treeViewImageDirectories.SelectedNode.Tag, "*.jpg", SearchOption.TopDirectoryOnly);
                int i = 0;
                foreach (string file in songFilePaths)
                {
                    Application.DoEvents();
                    ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(file));
                    lvi.Tag = file;
                    lvi.ImageIndex = i;
                    listViewDirectoryImages.Items.Add(lvi);
                    imList.Images.Add(Image.FromFile(file));
                    i++;
                }
                listViewDirectoryImages.LargeImageList = imList;

            }

        }

        private void listViewDirectoryImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projWindow != null && listViewDirectoryImages.SelectedIndices.Count > 0)
            {
                Application.DoEvents();
                int idx = listViewDirectoryImages.SelectedIndices[0];

                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && songMan.currentSong != null && songMan.currentSong.currentSlide>=0)
                {

                    projWindow.showSlide(songMan.currentSong.slides[songMan.currentSong.currentSlide], Image.FromFile((string)listViewDirectoryImages.Items[idx].Tag), false);
                }
                else
                {
                    projWindow.showImage(Image.FromFile((string)listViewDirectoryImages.Items[idx].Tag));
                }

                // History
                if (listViewImageHistory.Items.Count==0 || (string)listViewImageHistory.Items[listViewImageHistory.Items.Count - 1].Tag != (string)listViewDirectoryImages.Items[idx].Tag)
                {
                    listViewImageHistory.LargeImageList.Images.Add(Image.FromFile((string)listViewDirectoryImages.Items[idx].Tag));

                    if (listViewImageHistory.Items.Count > 10)
                    {
                        listViewImageHistory.Items.RemoveAt(0);
                    }

                    ListViewItem lvi = new ListViewItem(listViewDirectoryImages.Items[idx].Text);
                    lvi.Tag = listViewDirectoryImages.Items[idx].Tag;
                    lvi.ImageIndex = listViewImageHistory.LargeImageList.Images.Count-1;
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
                imList.ImageSize = new Size(100,75);
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

                Stack<string> diaStack = new Stack<string>();
                foreach (ListViewItem lvi in listViewDias.Items)
                {
                    if (lvi.Checked)
                    {
                        diaStack.Push((string)lvi.Tag);
                    }
                }
                if (diaStack.Count == 0)
                {
                    MessageBox.Show("Keine Bilder ausgewählt!");
                    return;
                }
                diaTimer.Tag = diaStack;
                projWindow.showImage(Image.FromFile(diaStack.Pop()));
                diaTimer.Start();
            }
        }

        private void diaTimer_Tick(object sender, EventArgs e)
        {
            if (((Stack<string>)((Timer)sender).Tag).Count == 0)
            {
                    ((Timer)sender).Stop();
                    projWindow.showNone();
                    buttonDiaShow.Text = "Diaschau starten";
                    return;                
            }
            projWindow.showImage(Image.FromFile(((Stack<string>)((Timer)sender).Tag).Pop()));
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
            if (songMan.currentSong != null)
            {
                songMan.currentSong.QASpelling = ((CheckBox)sender).Checked;
                songMan.currentSong.save(null);
            }
        }

        private void checkBoxQATranslation_CheckedChanged(object sender, EventArgs e)
        {
            if (songMan.currentSong != null)
            {
                songMan.currentSong.QATranslation = ((CheckBox)sender).Checked;
                songMan.currentSong.save(null);
            }
        }

        private void checkBoxQAImages_CheckedChanged(object sender, EventArgs e)
        {
            if (songMan.currentSong != null)
            {
                songMan.currentSong.QAImage = ((CheckBox)sender).Checked;
                songMan.currentSong.save(null);
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

        private void listViewImageHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projWindow != null && listViewImageHistory.SelectedIndices.Count > 0)
            {
                Application.DoEvents();
                int idx = listViewImageHistory.SelectedIndices[0];

                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && songMan.currentSong != null && songMan.currentSong.currentSlide >= 0)
                {

                    projWindow.showSlide(songMan.currentSong.slides[songMan.currentSong.currentSlide], Image.FromFile((string)listViewImageHistory.Items[idx].Tag), false);
                }
                else
                {
                    projWindow.showImage(Image.FromFile((string)listViewImageHistory.Items[idx].Tag));
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
            int idx = listViewImageHistory.SelectedIndices[0];
            listViewImageHistory.Items[idx].Selected = false;

        }

        private void checkBoxQASegmentation_CheckedChanged(object sender, EventArgs e)
        {
            if (songMan.currentSong != null)
            {
                songMan.currentSong.QASegmentation = ((CheckBox)sender).Checked;
                songMan.currentSong.save(null);
            }
        }

        private void buttonSearchImages_Click(object sender, EventArgs e)
        {
            string haystack = textBoxImageSearch.Text.ToLower().Trim();
            if (haystack != String.Empty)
            {
                treeViewImageDirectories.SelectedNode = null;
                imageSearchResults.Clear();
                string[] imgFilePaths = Directory.GetFiles(setting.dataDirectory + Path.DirectorySeparatorChar + setting.imageDir, "*.jpg", SearchOption.AllDirectories);
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


    }
}
