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
        private Song currentSong;

        private int numParts = 0;
        private int slidePanelOffset = 0;

        public delegate void slideClick(object sender, SlideClickEventArgs e);

        public event slideClick SlideClicked;

        public delegate void imageClick(object sender, SlideImageClickEventArgs e);

        public event imageClick ImageClicked;

        [Description("Icon shown at link for choosing previous song"), Category("SongDetail")]
        public Image PreviousSongIcon { get; set; }

        [Description("Icon shown at link for choosing next song"), Category("SongDetail")]
        public Image NextSongIcon { get; set; }

        private List<Label> slideTexts;
        private List<PictureBox> slideImages;
        private int currentSlideTextIdx = -1;

        private int refrainIndex;
        private int prechorusIndex;
        private int bridgeIndex;
        private int verse1Index;
        private int verse2Index;
        private int verse3Index;
        private int verse4Index;

        //
        // Look and feel
        //

        private Color spacerColor = Color.LightGray;
        private const int spaceHeight = 1;
        private const int spacerMargin = 4;

        private Color borderNormalColor = Color.Transparent;
        private Color borderHoverColor = Color.DarkGray;
        private Color borderActiveColor = Color.Black;

        private Color itemNormalFG = Color.Black;
        private Color itemHoverFG = Color.Black;
        private Color itemActiveFG = Color.White;

        private Color itemNormalBG = Color.White;
        private Color itemHoverBG = Color.LightBlue;
        private Color itemActiveBG = SystemColors.Highlight;

        private Font partCaptionFont = new Font("Arial", 16);
        private Font slideTextFont = new Font("Arial", 11);
        private Font prevNextSongFont = new Font("Arial", 12);

        private const int thumbnailLabelSpacing = 6;

        private const int itemBorderWidth = 2;
        private const int slidePanelElementSpacing = 1;

        private const int songSwitchPanelPadding = 6;

        private const int leftMargin = 5;
        private const int rightMargin = 24;
        private const int topMargin = 5;
        private const int bottomMargin = 5;

        private Size thumbSize;

        public SongDetail()
        {
            InitializeComponent();
            slideTexts = new List<Label>();
            slideImages = new List<PictureBox>();

            thumbSize = PraiseBase.Presenter.Properties.Settings.Default.ThumbSize;
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

                // Add panel for previous song
                Panel pnl = new Panel();
                pnl.Name = "prevPanel";
                pnl.Tag = previousSong;
                pnl.Paint += new PaintEventHandler(songSwitchPnl_Paint);
                pnl.Location = new Point(leftMargin, topMargin);
                pnl.Height = measured.Height + (2 * songSwitchPanelPadding);
                pnl.Cursor = Cursors.Hand;

                int titleXOffset = 10;

                // Add icon
                if (PreviousSongIcon != null)
                {
                    PictureBox arrowIcon = new PictureBox();
                    arrowIcon.Location = new Point(titleXOffset, songSwitchPanelPadding);
                    arrowIcon.Image = PreviousSongIcon;
                    arrowIcon.Size = new Size(PreviousSongIcon.Width, measured.Height);
                    pnl.Controls.Add(arrowIcon);

                    titleXOffset += arrowIcon.Size.Width + 8;
                }

                // Add song title to panel
                Label plbl = new Label();
                plbl.Location = new Point(titleXOffset, songSwitchPanelPadding);
                plbl.Size = measured;
                plbl.Text = previousSong.Title;
                plbl.Font = slideTextFont;
                pnl.Controls.Add(plbl);
                
                this.Controls.Add(pnl);

                ypos += pnl.Height;

                ypos += addSpacer(ypos, "spacerPanelprev");
            }

            for (numParts = 0; numParts < sng.Parts.Count; numParts++)
            {
                int numSlides = sng.Parts[numParts].Slides.Count;

                int slidePanelHeight = thumbSize.Height + (2 * itemBorderWidth);

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

                    int pictureBoxPanelWidth = thumbSize.Width + (2 * itemBorderWidth);

                    // Picture box banel
                    Panel panelPreviewPictureBoxContainer = new Panel();
                    panelPreviewPictureBoxContainer.Location = new Point(0, 0);
                    panelPreviewPictureBoxContainer.Size = new Size(pictureBoxPanelWidth, slidePanelHeight);
                    panelPreviewPictureBoxContainer.BackColor = borderNormalColor;
                    slidePanel.Controls.Add(panelPreviewPictureBoxContainer);

                    // Picture box
                    PictureBox previewPictureBox = new PictureBox();
                    previewPictureBox.Location = new Point(itemBorderWidth, itemBorderWidth);
                    previewPictureBox.Size = thumbSize;
                    IBackground bg = sng.Parts[numParts].Slides[j].Background;
                    previewPictureBox.Image = PraiseBase.Presenter.ImageManager.Instance.GetThumb(bg);
                    previewPictureBox.Tag = bg;
                    previewPictureBox.Enabled = true;
                    previewPictureBox.Cursor = Cursors.Hand;
                    previewPictureBox.Click += new EventHandler(pcBox_Click);
                    previewPictureBox.MouseEnter += new EventHandler(previewPictureBox_MouseEnter);
                    previewPictureBox.MouseLeave += new EventHandler(previewPictureBox_MouseLeave);
                    panelPreviewPictureBoxContainer.Controls.Add(previewPictureBox);

                    slideImages.Add(previewPictureBox);

                    // Text label panel
                    Panel panelTextLabelContainer = new Panel();
                    panelTextLabelContainer.Location = new Point(pictureBoxPanelWidth + thumbnailLabelSpacing, 0);
                    panelTextLabelContainer.Height = slidePanelHeight;
                    panelTextLabelContainer.BackColor = borderNormalColor;
                    panelTextLabelContainer.Paint += new PaintEventHandler(tpnl_Paint);
                    slidePanel.Controls.Add(panelTextLabelContainer);

                    // Text label
                    Label textLbl = new Label();
                    textLbl.Location = new Point(itemBorderWidth, itemBorderWidth);
                    textLbl.Height = panelTextLabelContainer.Height - (2 * itemBorderWidth);
                    textLbl.Text = sng.Parts[numParts].Slides[j].GetOneLineText();
                    textLbl.Padding = new System.Windows.Forms.Padding(2);
                    textLbl.ForeColor = itemNormalFG;
                    textLbl.BackColor = itemNormalBG;
                    textLbl.Font = slideTextFont;
                    textLbl.Enabled = true;
                    textLbl.AutoEllipsis = true;
                    textLbl.UseCompatibleTextRendering = true;
                    textLbl.Cursor = Cursors.Hand;
                    textLbl.Tag = j;
                    textLbl.Paint += new PaintEventHandler(textLbl_Paint);
                    textLbl.Click += new EventHandler(textLbl_Click);
                    textLbl.MouseEnter += new EventHandler(textLbl_MouseEnter);
                    textLbl.MouseLeave += new EventHandler(textLbl_MouseLeave);

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

                    panelTextLabelContainer.Controls.Add(textLbl);
                }


                // Add spacer panel (gray line)
                ypos += addSpacer(ypos, "spacerPanel" + numParts.ToString());

            }

            if (nextSong != null)
            {
                Size measured = TextRenderer.MeasureText(nextSong.Title, prevNextSongFont);

                // Add panel for next song
                Panel pnl = new Panel();
                pnl.Name = "nextPanel";
                pnl.Tag = nextSong;
                pnl.Paint += new PaintEventHandler(songSwitchPnl_Paint);
                pnl.Location = new Point(leftMargin, ypos);
                pnl.Height = measured.Height + (2 * songSwitchPanelPadding);
                pnl.Cursor = Cursors.Hand;

                int titleXOffset = 10;

                // Add icon
                if (NextSongIcon != null)
                {
                    PictureBox arrowIcon = new PictureBox();
                    arrowIcon.Location = new Point(titleXOffset, songSwitchPanelPadding);
                    arrowIcon.Image = NextSongIcon;
                    arrowIcon.Size = new Size(NextSongIcon.Width, measured.Height);
                    pnl.Controls.Add(arrowIcon);

                    titleXOffset += arrowIcon.Size.Width + 8;
                }

                // Add song title to panel
                Label plbl = new Label();
                plbl.Location = new Point(titleXOffset, songSwitchPanelPadding);
                plbl.Size = measured;
                plbl.Text = nextSong.Title;
                plbl.Font = slideTextFont;
                pnl.Controls.Add(plbl);

                this.Controls.Add(pnl);
            }

            currentSong = sng;

            this.ResumeLayout();
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

        private void SongDetail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && currentSlideTextIdx >= 0 && currentSlideTextIdx < slideTexts.Count - 1)
            {
                textLbl_Click(slideTexts[currentSlideTextIdx + 1], new EventArgs());
            }
            else if (e.KeyCode == Keys.Up && currentSlideTextIdx > 0)
            {
                textLbl_Click(slideTexts[currentSlideTextIdx - 1], new EventArgs());
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

        private void textLbl_Click(object sender, EventArgs e)
        {
            Label lbl = ((Label)sender);

            if (currentSlideTextIdx >= 0)
            {
                slideTexts[currentSlideTextIdx].BackColor = itemNormalBG;
                slideTexts[currentSlideTextIdx].ForeColor = itemNormalFG;
                slideTexts[currentSlideTextIdx].Parent.BackColor = borderNormalColor;

                slideImages[currentSlideTextIdx].Parent.BackColor = borderNormalColor;
            }

            int newSlideIdx = slideTexts.IndexOf(lbl);

            if (currentSlideTextIdx < newSlideIdx)
            {
                int tOffset = ((Panel)lbl.Parent.Parent).Parent.Bottom;
                if (tOffset + VerticalScroll.Value > this.Height)
                    VerticalScroll.Value = tOffset + VerticalScroll.Value - this.Height + 2;
                PerformLayout();
            }
            else
            {
                int tOffset = ((Panel)lbl.Parent.Parent).Parent.Top;
                if (tOffset < 0)
                    VerticalScroll.Value += tOffset - 5;
                PerformLayout();
            }

            currentSlideTextIdx = newSlideIdx;

            lbl.BackColor = itemActiveBG;
            lbl.ForeColor = itemActiveFG;
            lbl.Parent.BackColor = borderActiveColor;

            slideImages[currentSlideTextIdx].Parent.BackColor = borderActiveColor;

            if (SlideClicked != null)
            {
                this.Focus();
                SlideClickEventArgs p = new SlideClickEventArgs((int)lbl.Parent.Parent.Parent.Tag, (int)lbl.Tag);
                SlideClicked(this, p);
            }
        }

        private void pcBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = ((PictureBox)sender);

            if (currentSlideTextIdx >= 0)
            {
                slideTexts[currentSlideTextIdx].Parent.BackColor = borderNormalColor;
                slideTexts[currentSlideTextIdx].BackColor = itemNormalBG;
                slideTexts[currentSlideTextIdx].ForeColor = itemNormalFG;
                currentSlideTextIdx = -1;
            }

            pb.Parent.BackColor = borderActiveColor;

            if (ImageClicked != null)
            {
                this.Focus();
                SlideImageClickEventArgs p = new SlideImageClickEventArgs((IBackground)pb.Tag);
                ImageClicked(this, p);
            }
        }

        private void previewPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (slideImages.IndexOf((PictureBox)sender) != currentSlideTextIdx)
                ((PictureBox)sender).Parent.BackColor = borderHoverColor;
        }

        private void previewPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (slideImages.IndexOf((PictureBox)sender) != currentSlideTextIdx)
                ((PictureBox)sender).Parent.BackColor = borderNormalColor;
        }

        private void textLbl_MouseEnter(object sender, EventArgs e)
        {
            if (currentSlideTextIdx < 0 || slideTexts[currentSlideTextIdx] != (Label)sender)
            {
                ((Label)sender).Parent.BackColor = borderHoverColor;
                ((Label)sender).BackColor = itemHoverBG;
                ((Label)sender).ForeColor = itemHoverFG;
                int idx = slideTexts.IndexOf((Label)sender);
                if (idx >= 0 && idx < slideImages.Count)
                {
                    slideImages[idx].Parent.BackColor = borderHoverColor;
                }
            }
        }

        private void textLbl_MouseLeave(object sender, EventArgs e)
        {
            if (currentSlideTextIdx < 0 || slideTexts[currentSlideTextIdx] != (Label)sender)
            {
                ((Label)sender).Parent.BackColor = borderNormalColor;
                ((Label)sender).BackColor = itemNormalBG;
                ((Label)sender).ForeColor = itemNormalFG;
                int idx = slideTexts.IndexOf((Label)sender);
                if (idx >= 0 && idx < slideImages.Count)
                {
                    slideImages[slideTexts.IndexOf((Label)sender)].Parent.BackColor = borderNormalColor;
                }
            }
        }

        #endregion Events caused by user action

        #region Paint Events

        private void tpnl_Paint(object sender, PaintEventArgs e)
        {
            Panel lbl = ((Panel)sender);
            lbl.Width = (lbl.Parent.Width - lbl.Location.X);
        }

        private void textLbl_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = ((Label)sender);
            lbl.Width = (lbl.Parent.Width) - (2 * itemBorderWidth);
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

    #endregion Helper classes
}