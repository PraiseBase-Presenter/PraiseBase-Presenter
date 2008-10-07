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

        private Timer t1;

        public mainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setting = new Settings();
            projWindow = new projectionWindow();
            SongManager songMan = SongManager.getInstance();

            blackout = false;
            t1 = new Timer(); // Timer anlegen
            t1.Interval = 500; // Intervall festlegen, hier 100 ms
            t1.Tick += new EventHandler(t1_Tick); // Eventhandler ezeugen der beim Timerablauf aufgerufen wird
       
            projectionFont = new Font("Arial", 50, FontStyle.Bold);

            /*
            ColorButton colorButton3 = new ColorButton();
            colorButton3.Size = new Size(32, 21);
            colorButton3.Location = new Point(110, 20);
            colorButton3.Click += new EventHandler(ColorButton_Click);
            colorButton3.BackColor = SystemColors.Control;
            colorButton3.CenterColor = Color.Black;
            colorButton3.FlatStyle = FlatStyle.Flat;
            groupBox1.Controls.Add(colorButton3);
            */

            loadSongList(0);
            songSearchBox.Focus();
        }

        /*
        void ColorButton_Click(object sender, System.EventArgs e)
        {
            ColorButton callingButton = (ColorButton)sender;
            Point p = new Point(callingButton.Left + groupBox1.Left, callingButton.Top + callingButton.Height + groupBox1.Top);
            p = PointToScreen(p);
            Color color = new Color();
            ColorPaletteDialog clDlg = new ColorPaletteDialog(p.X, p.Y);
            clDlg.ShowDialog();

            if (clDlg.DialogResult == DialogResult.OK)
                color = clDlg.Color;

            callingButton.CenterColor = color;
            loadColor(color);

            Invalidate();

            clDlg.Dispose();
        }  	 
        */
          

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
        void loadSongList(int reload)
        {
            SongManager songMan = SongManager.getInstance();
            if (reload == 1)
                songMan.loadSongs();
            listViewSongs.Items.Clear();
            foreach (Song sng in songMan.getAll())
            {
                ListViewItem lvi = new ListViewItem(sng.title());
                lvi.Tag = sng;
                listViewSongs.Items.Add(lvi);
            }
            listViewSongs.Columns[0].Width = -2;
        }

        void searchSongs(string needle)
        {
            SongManager songMan = SongManager.getInstance();
            listViewSongs.Items.Clear();
            foreach (Song sng in songMan.getSearchResults(needle,radioSongSearchAll.Checked ? 1 : 0))
            {
                ListViewItem lvi = new ListViewItem(sng.title());
                lvi.Tag = sng;
                listViewSongs.Items.Add(lvi);
            }
            listViewSongs.Columns[0].Width = -2;
        }


        private void radioSongSearchAll_CheckedChanged(object sender, EventArgs e)
        {
            searchSongs(songSearchBox.Text);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.Font = projectionFont;
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                projectionFont = fontDlg.Font;
            }
        }

        private void songDetailItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projWindow != null && songDetailItems.SelectedIndices.Count > 0)
            {
                int idx = songDetailItems.SelectedIndices[0];
                Song currentSong = (Song)listViewSongs.Items[listViewSongs.SelectedIndices[0]].Tag;
                Song.slide sld = (Song.slide)songDetailItems.Items[idx].Tag;
                
                if (checkBoxUseSongImage.Checked == true)
                    projWindow.showText(sld.nlText, projectionFont, currentSong.getImage(sld.imageNumber));
                else
                    projWindow.showText(sld.nlText, projectionFont, null);
            }
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
            stWnd.ShowDialog(this);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            settingsWindow stWnd = new settingsWindow();
            stWnd.ShowDialog(this);
        }

        private void liederlisteNeuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            songSearchBox.Text = "";
            loadSongList(1);
            songSearchBox.Focus();

        }

        private void listViewSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSongs.SelectedIndices.Count > 0)
            {
                Application.DoEvents();

                songDetailItems.Items.Clear();
                songDetailImages.Items.Clear();

                Song currentSong = (Song)listViewSongs.Items[listViewSongs.SelectedIndices[0]].Tag;

                songDetailItems.SmallImageList = currentSong.getThumbs();

                /*
                ImageList largerImages = currentSong.getImageList();
                songDetailImages.LargeImageList = imageList;
                for (int i = 0; i < imageList.Images.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageIndex = i;
                    songDetailImages.Items.Add(lvi);
                }*/


                int j = 0;
                foreach (Song.part bla in currentSong.parts)
                {
                    int i = 0;
                    foreach (Song.slide sld in bla.slides)
                    {
                        ListViewItem lvi = new ListViewItem(new string[] {bla.caption + "  ["+(i+1).ToString()+"]",
                        bla.slides[i].text});
                        lvi.ImageIndex = bla.slides[i].imageNumber;
                        lvi.Tag = sld;
                        songDetailItems.Items.Add(lvi);
                        i++;
                        j++;
                    }
                }
                songDetailItems.Columns[0].Width = -2;
                songDetailItems.Columns[1].Width = -2;
            }
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                songSearchBox.Focus();
        }

        private void webToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.nicu.ch/pbp");
        }

    }
}
