using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PraiseBase.Presenter.Model.Song;

namespace SongDetails
{
    [DefaultEvent("SlideClicked")]
    public partial class SongDetail : UserControl
    {
        //
        // Events
        //

        public delegate void slideClick(object sender, SlideClickEventArgs e);
        public event slideClick SlideClicked;

        public delegate void imageClick(object sender, SlideImageClickEventArgs e);
        public event imageClick ImageClicked;

        public delegate void previousSongClick(object sender, SongSwitchEventArgs e);
        public event previousSongClick PreviousSongClicked;

        public delegate void nextSongClick(object sender, SongSwitchEventArgs e);
        public event nextSongClick NextSongClicked;

        //
        // Public settings
        //

        [Description("Icon shown at link for choosing previous song"), Category("SongDetail")]
        public Image PreviousSongIcon { get; set; }

        [Description("Icon shown at link for choosing next song"), Category("SongDetail")]
        public Image NextSongIcon { get; set; }

        [Description("Size of song background thumbnail"), Category("SongDetail"), DefaultValue(typeof(Size), "80, 60")]
        public Size ThumbnailSize { get; set; }

        //
        // Runtime variables
        //

        private List<Button> slideTexts;
        private List<PictureBox> slideImages;
        private int currentSlideTextIdx = -1;

        private int numParts = 0;
        private int slidePanelOffset = 0;
        private Song currentSong;

        private int refrainIndex;
        private int prechorusIndex;
        private int bridgeIndex;
        private int verse1Index;
        private int verse2Index;
        private int verse3Index;
        private int verse4Index;

        private Button prevSongButton;
        private Button nextSongButton;

        //
        // Look and feel
        //

        private Color spacerColor = Color.LightGray;
        private const int spaceHeight = 1;
        private const int spacerMargin = 4;

        private Color itemNormalFG = Color.Black;
        private Color itemNormalBG = Color.White;

        private Color itemActiveFG = Color.White;
        private Color itemActiveBG = SystemColors.Highlight;

        private Font partCaptionFont = new Font("Arial", 14);
        private Font slideTextFont = new Font("Arial", 9);
        private Font prevNextSongFont = new Font("Arial", 12);

        private const int thumbnailLabelSpacing = 5;

        private const int slidePanelElementSpacing = 1;

        private const int songSwitchPanelPadding = 4;

        private const int leftMargin = 5;
        private const int rightMargin = 24;
        private const int topMargin = 5;
        private const int bottomMargin = 5;

        public SongDetail()
        {
            InitializeComponent();
            slideTexts = new List<Button>();
            slideImages = new List<PictureBox>();
        }

        public void setSong(Song sng)
        {
            setSong(sng, null, null);
        }

        public void setSong(Song sng, Song previousSong, Song nextSong)
        {
            PerformLayout();
            SuspendLayout();

            //
            // Cleanup
            //

            // Reset indices
            currentSlideTextIdx = -1;
            refrainIndex = -1;
            prechorusIndex = -1;
            bridgeIndex = -1;
            verse1Index = -1;
            verse2Index = -1;
            verse3Index = -1;
            verse4Index = -1;

            // Clear controls
            this.Controls.RemoveByKey("prevPanel");
            this.Controls.RemoveByKey("nextPanel");
            this.Controls.RemoveByKey("spacerPanelprev");
            this.Controls.RemoveByKey("endSpace");

            for (int j = numParts - 1; j >= 0; j--)
            {
                this.Controls.RemoveByKey("partPanel" + j.ToString());
                this.Controls.RemoveByKey("spacerPanel" + j.ToString());
            }

            // Set scroll value
            this.VerticalScroll.Value = 0;

            // Clear lists
            slideTexts.Clear();
            slideImages.Clear();

            //
            // Draw new stuff
            //

            int ypos = topMargin;

            Size labelSize = new Size(0, 0);
            for (int i = 0; i < sng.Parts.Count; i++)
            {
                Size measured = TextRenderer.MeasureText(sng.Parts[i].Caption, partCaptionFont);
                labelSize = new Size(Math.Max(labelSize.Width, measured.Width), Math.Max(labelSize.Height, measured.Height));
            }
            slidePanelOffset = labelSize.Width + 20;

            if (previousSong != null)
            {
                Size measured = TextRenderer.MeasureText(previousSong.Title, prevNextSongFont);
                int buttonHeight = measured.Height + 6 + (2 * songSwitchPanelPadding);

                // Add panel for previous song
                Panel pnl = new Panel();
                pnl.Name = "prevPanel";
                pnl.Paint += new PaintEventHandler(songSwitchPnl_Paint);
                pnl.Location = new Point(leftMargin, topMargin);
                pnl.Height = buttonHeight;

                // Add song title to panel
                prevSongButton = new Button();
                prevSongButton.Location = new Point(0, 0);
                prevSongButton.Height = buttonHeight;
                prevSongButton.Text = " " + previousSong.Title;
                prevSongButton.Font = slideTextFont;
                prevSongButton.TextAlign = ContentAlignment.MiddleLeft;
                prevSongButton.Tag = previousSong;
                if (PreviousSongIcon != null)
                {
                    prevSongButton.Image = PreviousSongIcon;
                    prevSongButton.ImageAlign = ContentAlignment.MiddleLeft;
                    prevSongButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                }
                prevSongButton.FlatStyle = FlatStyle.Flat;
                prevSongButton.FlatAppearance.BorderColor = Color.White;
                prevSongButton.FlatAppearance.BorderSize = 0;
                prevSongButton.Padding = new System.Windows.Forms.Padding(songSwitchPanelPadding);
                prevSongButton.Cursor = Cursors.Hand;
                prevSongButton.Paint += plbl_Paint;
                prevSongButton.Click += plbl_ClickPrev;

                pnl.Controls.Add(prevSongButton);
                
                this.Controls.Add(pnl);

                ypos += pnl.Height;

                ypos += addSpacer(ypos, "spacerPanelprev");
            }

            for (numParts = 0; numParts < sng.Parts.Count; numParts++)
            {
                int numSlides = sng.Parts[numParts].Slides.Count;

                int slidePanelHeight = ThumbnailSize.Height;

                // Add panel for this part
                int panelHeight = (numSlides * slidePanelHeight) + ((numSlides - 1) * slidePanelElementSpacing);
                Panel songPartPanel = addPartPanel(ypos, panelHeight, "partPanel" + numParts);
                ypos += songPartPanel.Height;

                // Add part caption label to panel
                Label plbl = new Label();
                plbl.Location = new Point(0, 0);
                plbl.Size = labelSize;
                plbl.Text = sng.Parts[numParts].Caption;
                plbl.Font = partCaptionFont;
                songPartPanel.Controls.Add(plbl);

                int slidePanelY = 0;

                // Add sub-panels for each slide
                for (int j = 0; j < numSlides; j++)
                {
                     // Slide panel
                    Panel slidePanel = new Panel();
                    slidePanel.Location = new Point(slidePanelOffset, slidePanelY);
                    slidePanel.Height = slidePanelHeight;
                    slidePanel.Tag = j;
                    slidePanel.Paint += new PaintEventHandler(spnl_Paint);
                    songPartPanel.Controls.Add(slidePanel);

                    slidePanelY += slidePanelHeight + slidePanelElementSpacing;

                    int pictureBoxPanelWidth = ThumbnailSize.Width;

                    // Picture box
                    PictureBox previewPictureBox = new PictureBox();
                    previewPictureBox.Location = new Point(0, 0);
                    previewPictureBox.Size = ThumbnailSize;
                    IBackground bg = sng.Parts[numParts].Slides[j].Background;
                    previewPictureBox.Image = PraiseBase.Presenter.ImageManager.Instance.GetThumb(bg);
                    previewPictureBox.Tag = bg;
                    previewPictureBox.Enabled = true;
                    previewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    previewPictureBox.Cursor = Cursors.Hand;
                    previewPictureBox.Click += new EventHandler(pcBox_Click);
                    slidePanel.Controls.Add(previewPictureBox);

                    slideImages.Add(previewPictureBox);

                    // Text label
                    Button textLbl = new Button();
                    textLbl.Location = new Point(pictureBoxPanelWidth + thumbnailLabelSpacing, 0);
                    textLbl.Height = slidePanelHeight;
                    textLbl.Text = sng.Parts[numParts].Slides[j].GetOneLineText();
                    textLbl.Padding = new Padding(2);
                    textLbl.FlatStyle = FlatStyle.Flat;
                    textLbl.FlatAppearance.BorderColor = Color.White;
                    textLbl.FlatAppearance.BorderSize = 0;
                    textLbl.ForeColor = itemNormalFG;
                    textLbl.BackColor = itemNormalBG;
                    textLbl.Font = slideTextFont;
                    textLbl.Enabled = true;
                    textLbl.AutoEllipsis = true;
                    textLbl.UseCompatibleTextRendering = true;
                    textLbl.TextAlign = ContentAlignment.TopLeft;
                    textLbl.Cursor = Cursors.Hand;
                    textLbl.Tag = j;
                    textLbl.Paint += new PaintEventHandler(textLbl_Paint);
                    textLbl.Click += new EventHandler(textLbl_Click);
                    textLbl.KeyUp += textLbl_KeyUp;
                    slidePanel.Controls.Add(textLbl);

                    slideTexts.Add(textLbl);

                    if (j == 0)
                    {
                        if (refrainIndex < 0 && (sng.Parts[numParts].Caption == "Refrain" || sng.Parts[numParts].Caption == "Chorus"))
                        {
                            refrainIndex = slideTexts.Count - 1;
                        }
                        else if (prechorusIndex < 0 && (sng.Parts[numParts].Caption == "Pre-Chorus" || sng.Parts[numParts].Caption == "Prechorus"))
                        {
                            prechorusIndex = slideTexts.Count - 1;
                        }
                        else if (bridgeIndex < 0 && (sng.Parts[numParts].Caption == "Bridge"))
                        {
                            bridgeIndex = slideTexts.Count - 1;
                        }
                        else if (verse1Index < 0 && (sng.Parts[numParts].Caption == "Strophe 1" || sng.Parts[numParts].Caption == "Teil 1" || sng.Parts[numParts].Caption == "Verse 1"))
                        {
                            verse1Index = slideTexts.Count - 1;
                        }
                        else if (verse2Index < 0 && (sng.Parts[numParts].Caption == "Strophe 2" || sng.Parts[numParts].Caption == "Teil 2" || sng.Parts[numParts].Caption == "Verse 2"))
                        {
                            verse2Index = slideTexts.Count - 1;
                        }
                        else if (verse3Index < 0 && (sng.Parts[numParts].Caption == "Strophe 3" || sng.Parts[numParts].Caption == "Teil 3" || sng.Parts[numParts].Caption == "Verse 3"))
                        {
                            verse3Index = slideTexts.Count - 1;
                        }
                        else if (verse4Index < 0 && (sng.Parts[numParts].Caption == "Strophe 4" || sng.Parts[numParts].Caption == "Teil 4" || sng.Parts[numParts].Caption == "Verse 4"))
                        {
                            verse4Index = slideTexts.Count - 1;
                        }
                    }
                }


                // Add spacer panel (gray line)
                ypos += addSpacer(ypos, "spacerPanel" + numParts.ToString());

            }

            if (nextSong != null)
            {
                Size measured = TextRenderer.MeasureText(nextSong.Title, prevNextSongFont);

                int buttonHeight = measured.Height + 6 + (2 * songSwitchPanelPadding);

                // Add panel for next song
                Panel pnl = new Panel();
                pnl.Name = "nextPanel";
                pnl.Paint += new PaintEventHandler(songSwitchPnl_Paint);
                pnl.Location = new Point(leftMargin, ypos);
                pnl.Height = buttonHeight;

                // Add song title to panel
                nextSongButton = new Button();
                nextSongButton.Location = new Point(0, 0);
                nextSongButton.Height = buttonHeight;
                nextSongButton.Text = " " + nextSong.Title;
                nextSongButton.Font = slideTextFont;
                nextSongButton.TextAlign = ContentAlignment.MiddleLeft;
                nextSongButton.Tag = nextSong;
                if (NextSongIcon != null)
                {
                    nextSongButton.Image = NextSongIcon;
                    nextSongButton.ImageAlign = ContentAlignment.MiddleLeft;
                    nextSongButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                }
                nextSongButton.FlatStyle = FlatStyle.Flat;
                nextSongButton.FlatAppearance.BorderColor = Color.White;
                nextSongButton.FlatAppearance.BorderSize = 0;
                nextSongButton.Padding = new System.Windows.Forms.Padding(songSwitchPanelPadding);
                nextSongButton.Cursor = Cursors.Hand;
                nextSongButton.Paint += plbl_Paint;
                nextSongButton.Click += plbl_ClickNext;

                pnl.Controls.Add(nextSongButton);

                this.Controls.Add(pnl);

                ypos += pnl.Height;
            }

            Panel lpnl = new Panel();
            lpnl.Name = "endSpace";
            lpnl.Location = new Point(leftMargin, ypos + bottomMargin - 1);
            lpnl.BackColor = Color.White;
            lpnl.Height = 1;
            this.Controls.Add(lpnl);

            currentSong = sng;

            this.ResumeLayout();
        }

        void textLbl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (currentSlideTextIdx >= 0 && currentSlideTextIdx < slideTexts.Count - 1)
                {
                    textLbl_Click(slideTexts[currentSlideTextIdx + 1], new EventArgs());
                }
                else if (nextSongButton != null) 
                {
                    plbl_ClickNext(nextSongButton, e);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (currentSlideTextIdx > 0)
                {
                    textLbl_Click(slideTexts[currentSlideTextIdx - 1], new EventArgs());
                }
                else if (prevSongButton != null)
                {
                    plbl_ClickPrev(prevSongButton, e);
                }
            }
            else if (e.KeyCode == Keys.PageDown && currentSlideTextIdx >= 0 && currentSlideTextIdx < slideTexts.Count - 1)
            {
                textLbl_Click(slideTexts[slideTexts.Count - 1], new EventArgs());
            }
            else if (e.KeyCode == Keys.PageUp && currentSlideTextIdx > 0)
            {
                textLbl_Click(slideTexts[0], new EventArgs());
            }
            else if ((e.KeyCode == Keys.R || e.KeyCode == Keys.C) && refrainIndex >= 0)
            {
                textLbl_Click(slideTexts[refrainIndex], new EventArgs());
            }
            else if ((e.KeyCode == Keys.P) && prechorusIndex >= 0)
            {
                textLbl_Click(slideTexts[prechorusIndex], new EventArgs());
            }
            else if ((e.KeyCode == Keys.B) && bridgeIndex >= 0)
            {
                textLbl_Click(slideTexts[bridgeIndex], new EventArgs());
            }
            else if ((e.KeyCode == Keys.D1) && verse1Index >= 0)
            {
                textLbl_Click(slideTexts[verse1Index], new EventArgs());
            }
            else if ((e.KeyCode == Keys.D2) && verse2Index >= 0)
            {
                textLbl_Click(slideTexts[verse2Index], new EventArgs());
            }
            else if ((e.KeyCode == Keys.D3) && verse3Index >= 0)
            {
                textLbl_Click(slideTexts[verse3Index], new EventArgs());
            }
            else if ((e.KeyCode == Keys.D4) && verse4Index >= 0)
            {
                textLbl_Click(slideTexts[verse4Index], new EventArgs());
            }
        }

        private Panel addPartPanel(int ypos, int height, string name)
        {
            Panel pnl = new Panel();
            pnl.Location = new Point(leftMargin, ypos);
            pnl.Height = height;
            pnl.Name = name;
            pnl.Tag = numParts;
            pnl.Paint += new PaintEventHandler(partPnl_Paint);
            this.Controls.Add(pnl);

            return pnl;
        }

        /// <summary>
        /// Add spacer panel (gray line)
        /// </summary>
        private int addSpacer(int ypos, string name)
        {
            Panel lpnl = new Panel();
            lpnl.Name = name;
            lpnl.Location = new Point(leftMargin, ypos + spacerMargin);
            lpnl.BackColor = spacerColor;
            lpnl.Height = spaceHeight;
            lpnl.Paint += new PaintEventHandler(lpnl_Paint);
            this.Controls.Add(lpnl);

            return spacerMargin + lpnl.Height + spacerMargin;
        }

        #region Events caused by user action


        private void textLbl_Click(object sender, EventArgs e)
        {
            Button lbl = ((Button)sender);

            if (currentSlideTextIdx >= 0)
            {
                slideTexts[currentSlideTextIdx].BackColor = itemNormalBG;
                slideTexts[currentSlideTextIdx].ForeColor = itemNormalFG;
            }

            int newSlideIdx = slideTexts.IndexOf(lbl);

            if (currentSlideTextIdx < newSlideIdx)
            {
                int tOffset = ((Panel)lbl.Parent).Parent.Bottom;
                if (tOffset + VerticalScroll.Value > this.Height)
                    VerticalScroll.Value = tOffset + VerticalScroll.Value - this.Height + 2;
                PerformLayout();
            }
            else
            {
                int tOffset = ((Panel)lbl.Parent).Parent.Top;
                if (tOffset < 0)
                    VerticalScroll.Value += tOffset - 5;
                PerformLayout();
            }

            currentSlideTextIdx = newSlideIdx;

            lbl.BackColor = itemActiveBG;
            lbl.ForeColor = itemActiveFG;

            if (SlideClicked != null)
            {
                this.Focus();
                SlideClickEventArgs p = new SlideClickEventArgs((int)lbl.Parent.Parent.Tag, (int)lbl.Tag);
                SlideClicked(this, p);
            }
        }

        private void pcBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = ((PictureBox)sender);

            if (currentSlideTextIdx >= 0)
            {
                slideTexts[currentSlideTextIdx].BackColor = itemNormalBG;
                slideTexts[currentSlideTextIdx].ForeColor = itemNormalFG;
                currentSlideTextIdx = -1;
            }

            if (ImageClicked != null)
            {
                this.Focus();
                SlideImageClickEventArgs p = new SlideImageClickEventArgs((IBackground)pb.Tag);
                ImageClicked(this, p);
            }
        }

        
        void plbl_ClickPrev(object sender, EventArgs e)
        {
            if (PreviousSongClicked != null)
            {
                SongSwitchEventArgs p = new SongSwitchEventArgs((Song)((Button)sender).Tag);
                PreviousSongClicked(this, p);
            }
        }

        void plbl_ClickNext(object sender, EventArgs e)
        {
            if (NextSongClicked != null)
            {
                SongSwitchEventArgs p = new SongSwitchEventArgs((Song)((Button)sender).Tag);
                NextSongClicked(this, p);
            }
        }        

        #endregion Events caused by user action

        #region Paint Events

        private void textLbl_Paint(object sender, PaintEventArgs e)
        {
            Button lbl = ((Button)sender);
            lbl.Width = (lbl.Parent.Width - lbl.Location.X);
        }

        private void spnl_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            pnl.Width = pnl.Parent.Width - slidePanelOffset;
        }

        private void lpnl_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            pnl.Width = this.Width - pnl.Left - rightMargin;
        }

        private void partPnl_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            pnl.Width = this.Width - pnl.Left - rightMargin;
        }
       
        private void songSwitchPnl_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            pnl.Width = this.Width - pnl.Left - rightMargin;
        }

        void plbl_Paint(object sender, PaintEventArgs e)
        {
            Button lbl = ((Button)sender);
            lbl.Width = lbl.Parent.Width;
        }
        
        #endregion Paint Events
    }

    #region Helper classes

    public class SlideClickEventArgs : EventArgs
    {
        public SlideClickEventArgs(int partNum, int slideNum)
        {
            this.SlideNumber = slideNum;
            this.PartNumber = partNum;
        }

        public int SlideNumber { get; set; }

        public int PartNumber { get; set; }
    }

    public class SlideImageClickEventArgs : EventArgs
    {
        public SlideImageClickEventArgs(IBackground bg)
        {
            this.Background = bg;
        }

        public IBackground Background { get; set; }
    }

    public class SongSwitchEventArgs : EventArgs
    {
        public SongSwitchEventArgs(Song song)
        {
            this.Song = song;
        }

        public Song Song { get; set; }
    }

    #endregion Helper classes
}