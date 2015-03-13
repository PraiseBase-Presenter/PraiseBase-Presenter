using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.UI.Components
{
    [DefaultEvent("SlideClicked")]
    public partial class SongDetail : UserControl
    {
        //
        // Events
        //

        public delegate void SlideClick(object sender, SlideClickEventArgs e);
        public event SlideClick SlideClicked;

        public delegate void ImageClick(object sender, SlideImageClickEventArgs e);
        public event ImageClick ImageClicked;

        public delegate void PreviousSongClick(object sender, SongSwitchEventArgs e);
        public event PreviousSongClick PreviousSongClicked;

        public delegate void NextSongClick(object sender, SongSwitchEventArgs e);
        public event NextSongClick NextSongClicked;

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

        private List<Button> _slideTexts;
        private List<PictureBox> _slideImages;
        private int _currentSlideTextIdx = -1;

        private int _numParts = 0;
        private int _slidePanelOffset = 0;
        private Song _currentSong;

        private int _refrainIndex;
        private int _prechorusIndex;
        private int _bridgeIndex;
        private int _verse1Index;
        private int _verse2Index;
        private int _verse3Index;
        private int _verse4Index;

        private Button _prevSongButton;
        private Button _nextSongButton;

        //
        // Look and feel
        //

        private Color _spacerColor = Color.LightGray;
        private const int SpaceHeight = 1;
        private const int SpacerMargin = 4;

        private Color _itemNormalFg = Color.Black;
        private Color _itemNormalBg = Color.White;

        private Color _itemActiveFg = Color.White;
        private Color _itemActiveBg = SystemColors.Highlight;

        private Font _partCaptionFont = new Font("Arial", 14);
        private Font _slideTextFont = new Font("Arial", 9);
        private Font _prevNextSongFont = new Font("Arial", 12);

        private const int ThumbnailLabelSpacing = 5;

        private const int SlidePanelElementSpacing = 1;

        private const int SongSwitchPanelPadding = 4;

        private const int LeftMargin = 5;
        private const int RightMargin = 24;
        private const int TopMargin = 5;
        private const int BottomMargin = 5;

        public SongDetail()
        {
            InitializeComponent();
            _slideTexts = new List<Button>();
            _slideImages = new List<PictureBox>();
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
            _currentSlideTextIdx = -1;
            _refrainIndex = -1;
            _prechorusIndex = -1;
            _bridgeIndex = -1;
            _verse1Index = -1;
            _verse2Index = -1;
            _verse3Index = -1;
            _verse4Index = -1;

            // Clear controls
            this.Controls.RemoveByKey("prevPanel");
            this.Controls.RemoveByKey("nextPanel");
            this.Controls.RemoveByKey("spacerPanelprev");
            this.Controls.RemoveByKey("endSpace");

            for (int j = _numParts - 1; j >= 0; j--)
            {
                this.Controls.RemoveByKey("partPanel" + j.ToString());
                this.Controls.RemoveByKey("spacerPanel" + j.ToString());
            }

            // Set scroll value
            this.VerticalScroll.Value = 0;

            // Clear lists
            _slideTexts.Clear();
            _slideImages.Clear();

            //
            // Draw new stuff
            //

            int ypos = TopMargin;

            Size labelSize = new Size(0, 0);
            for (int i = 0; i < sng.Parts.Count; i++)
            {
                Size measured = TextRenderer.MeasureText(sng.Parts[i].Caption, _partCaptionFont);
                labelSize = new Size(Math.Max(labelSize.Width, measured.Width), Math.Max(labelSize.Height, measured.Height));
            }
            _slidePanelOffset = labelSize.Width + 20;

            if (previousSong != null)
            {
                Size measured = TextRenderer.MeasureText(previousSong.Title, _prevNextSongFont);
                int buttonHeight = measured.Height + 6 + (2 * SongSwitchPanelPadding);

                // Add panel for previous song
                Panel pnl = new Panel();
                pnl.Name = "prevPanel";
                pnl.Paint += new PaintEventHandler(songSwitchPnl_Paint);
                pnl.Location = new Point(LeftMargin, TopMargin);
                pnl.Height = buttonHeight;

                // Add song title to panel
                _prevSongButton = new Button();
                _prevSongButton.Location = new Point(0, 0);
                _prevSongButton.Height = buttonHeight;
                _prevSongButton.Text = " " + previousSong.Title;
                _prevSongButton.Font = _slideTextFont;
                _prevSongButton.TextAlign = ContentAlignment.MiddleLeft;
                _prevSongButton.Tag = previousSong;
                if (PreviousSongIcon != null)
                {
                    _prevSongButton.Image = PreviousSongIcon;
                    _prevSongButton.ImageAlign = ContentAlignment.MiddleLeft;
                    _prevSongButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                }
                _prevSongButton.FlatStyle = FlatStyle.Flat;
                _prevSongButton.FlatAppearance.BorderColor = Color.White;
                _prevSongButton.FlatAppearance.BorderSize = 0;
                _prevSongButton.Padding = new System.Windows.Forms.Padding(SongSwitchPanelPadding);
                _prevSongButton.Cursor = Cursors.Hand;
                _prevSongButton.Paint += plbl_Paint;
                _prevSongButton.Click += plbl_ClickPrev;

                pnl.Controls.Add(_prevSongButton);
                
                this.Controls.Add(pnl);

                ypos += pnl.Height;

                ypos += AddSpacer(ypos, "spacerPanelprev");
            }

            for (_numParts = 0; _numParts < sng.Parts.Count; _numParts++)
            {
                int numSlides = sng.Parts[_numParts].Slides.Count;

                int slidePanelHeight = ThumbnailSize.Height;

                // Add panel for this part
                int panelHeight = (numSlides * slidePanelHeight) + ((numSlides - 1) * SlidePanelElementSpacing);
                Panel songPartPanel = AddPartPanel(ypos, panelHeight, "partPanel" + _numParts);
                ypos += songPartPanel.Height;

                // Add part caption label to panel
                Label plbl = new Label();
                plbl.Location = new Point(0, 0);
                plbl.Size = labelSize;
                plbl.Text = sng.Parts[_numParts].Caption;
                plbl.Font = _partCaptionFont;
                songPartPanel.Controls.Add(plbl);

                int slidePanelY = 0;

                // Add sub-panels for each slide
                for (int j = 0; j < numSlides; j++)
                {
                     // Slide panel
                    Panel slidePanel = new Panel();
                    slidePanel.Location = new Point(_slidePanelOffset, slidePanelY);
                    slidePanel.Height = slidePanelHeight;
                    slidePanel.Tag = j;
                    slidePanel.Paint += new PaintEventHandler(spnl_Paint);
                    songPartPanel.Controls.Add(slidePanel);

                    slidePanelY += slidePanelHeight + SlidePanelElementSpacing;

                    int pictureBoxPanelWidth = ThumbnailSize.Width;

                    // Picture box
                    PictureBox previewPictureBox = new PictureBox();
                    previewPictureBox.Location = new Point(0, 0);
                    previewPictureBox.Size = ThumbnailSize;
                    IBackground bg = sng.Parts[_numParts].Slides[j].Background;
                    previewPictureBox.Image = PraiseBase.Presenter.ImageManager.Instance.GetThumb(bg);
                    previewPictureBox.Tag = bg;
                    previewPictureBox.Enabled = true;
                    previewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    previewPictureBox.Cursor = Cursors.Hand;
                    previewPictureBox.Click += new EventHandler(pcBox_Click);
                    slidePanel.Controls.Add(previewPictureBox);

                    _slideImages.Add(previewPictureBox);

                    // Text label
                    Button textLbl = new Button();
                    textLbl.Location = new Point(pictureBoxPanelWidth + ThumbnailLabelSpacing, 0);
                    textLbl.Height = slidePanelHeight;
                    textLbl.Text = sng.Parts[_numParts].Slides[j].GetOneLineText();
                    textLbl.Padding = new Padding(2);
                    textLbl.FlatStyle = FlatStyle.Flat;
                    textLbl.FlatAppearance.BorderColor = Color.White;
                    textLbl.FlatAppearance.BorderSize = 0;
                    textLbl.ForeColor = _itemNormalFg;
                    textLbl.BackColor = _itemNormalBg;
                    textLbl.Font = _slideTextFont;
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

                    _slideTexts.Add(textLbl);

                    if (j == 0)
                    {
                        if (_refrainIndex < 0 && (sng.Parts[_numParts].Caption == "Refrain" || sng.Parts[_numParts].Caption == "Chorus"))
                        {
                            _refrainIndex = _slideTexts.Count - 1;
                        }
                        else if (_prechorusIndex < 0 && (sng.Parts[_numParts].Caption == "Pre-Chorus" || sng.Parts[_numParts].Caption == "Prechorus"))
                        {
                            _prechorusIndex = _slideTexts.Count - 1;
                        }
                        else if (_bridgeIndex < 0 && (sng.Parts[_numParts].Caption == "Bridge"))
                        {
                            _bridgeIndex = _slideTexts.Count - 1;
                        }
                        else if (_verse1Index < 0 && (sng.Parts[_numParts].Caption == "Strophe 1" || sng.Parts[_numParts].Caption == "Teil 1" || sng.Parts[_numParts].Caption == "Verse 1"))
                        {
                            _verse1Index = _slideTexts.Count - 1;
                        }
                        else if (_verse2Index < 0 && (sng.Parts[_numParts].Caption == "Strophe 2" || sng.Parts[_numParts].Caption == "Teil 2" || sng.Parts[_numParts].Caption == "Verse 2"))
                        {
                            _verse2Index = _slideTexts.Count - 1;
                        }
                        else if (_verse3Index < 0 && (sng.Parts[_numParts].Caption == "Strophe 3" || sng.Parts[_numParts].Caption == "Teil 3" || sng.Parts[_numParts].Caption == "Verse 3"))
                        {
                            _verse3Index = _slideTexts.Count - 1;
                        }
                        else if (_verse4Index < 0 && (sng.Parts[_numParts].Caption == "Strophe 4" || sng.Parts[_numParts].Caption == "Teil 4" || sng.Parts[_numParts].Caption == "Verse 4"))
                        {
                            _verse4Index = _slideTexts.Count - 1;
                        }
                    }
                }


                // Add spacer panel (gray line)
                ypos += AddSpacer(ypos, "spacerPanel" + _numParts.ToString());

            }

            if (nextSong != null)
            {
                Size measured = TextRenderer.MeasureText(nextSong.Title, _prevNextSongFont);

                int buttonHeight = measured.Height + 6 + (2 * SongSwitchPanelPadding);

                // Add panel for next song
                Panel pnl = new Panel();
                pnl.Name = "nextPanel";
                pnl.Paint += new PaintEventHandler(songSwitchPnl_Paint);
                pnl.Location = new Point(LeftMargin, ypos);
                pnl.Height = buttonHeight;

                // Add song title to panel
                _nextSongButton = new Button();
                _nextSongButton.Location = new Point(0, 0);
                _nextSongButton.Height = buttonHeight;
                _nextSongButton.Text = " " + nextSong.Title;
                _nextSongButton.Font = _slideTextFont;
                _nextSongButton.TextAlign = ContentAlignment.MiddleLeft;
                _nextSongButton.Tag = nextSong;
                if (NextSongIcon != null)
                {
                    _nextSongButton.Image = NextSongIcon;
                    _nextSongButton.ImageAlign = ContentAlignment.MiddleLeft;
                    _nextSongButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                }
                _nextSongButton.FlatStyle = FlatStyle.Flat;
                _nextSongButton.FlatAppearance.BorderColor = Color.White;
                _nextSongButton.FlatAppearance.BorderSize = 0;
                _nextSongButton.Padding = new System.Windows.Forms.Padding(SongSwitchPanelPadding);
                _nextSongButton.Cursor = Cursors.Hand;
                _nextSongButton.Paint += plbl_Paint;
                _nextSongButton.Click += plbl_ClickNext;

                pnl.Controls.Add(_nextSongButton);

                this.Controls.Add(pnl);

                ypos += pnl.Height;
            }

            Panel lpnl = new Panel();
            lpnl.Name = "endSpace";
            lpnl.Location = new Point(LeftMargin, ypos + BottomMargin - 1);
            lpnl.BackColor = Color.White;
            lpnl.Height = 1;
            this.Controls.Add(lpnl);

            _currentSong = sng;

            this.ResumeLayout();
        }

        void textLbl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (_currentSlideTextIdx >= 0 && _currentSlideTextIdx < _slideTexts.Count - 1)
                {
                    textLbl_Click(_slideTexts[_currentSlideTextIdx + 1], new EventArgs());
                }
                else if (_nextSongButton != null) 
                {
                    plbl_ClickNext(_nextSongButton, e);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (_currentSlideTextIdx > 0)
                {
                    textLbl_Click(_slideTexts[_currentSlideTextIdx - 1], new EventArgs());
                }
                else if (_prevSongButton != null)
                {
                    plbl_ClickPrev(_prevSongButton, e);
                }
            }
            else if (e.KeyCode == Keys.PageDown && _currentSlideTextIdx >= 0 && _currentSlideTextIdx < _slideTexts.Count - 1)
            {
                textLbl_Click(_slideTexts[_slideTexts.Count - 1], new EventArgs());
            }
            else if (e.KeyCode == Keys.PageUp && _currentSlideTextIdx > 0)
            {
                textLbl_Click(_slideTexts[0], new EventArgs());
            }
            else if ((e.KeyCode == Keys.R || e.KeyCode == Keys.C) && _refrainIndex >= 0)
            {
                textLbl_Click(_slideTexts[_refrainIndex], new EventArgs());
            }
            else if ((e.KeyCode == Keys.P) && _prechorusIndex >= 0)
            {
                textLbl_Click(_slideTexts[_prechorusIndex], new EventArgs());
            }
            else if ((e.KeyCode == Keys.B) && _bridgeIndex >= 0)
            {
                textLbl_Click(_slideTexts[_bridgeIndex], new EventArgs());
            }
            else if ((e.KeyCode == Keys.D1) && _verse1Index >= 0)
            {
                textLbl_Click(_slideTexts[_verse1Index], new EventArgs());
            }
            else if ((e.KeyCode == Keys.D2) && _verse2Index >= 0)
            {
                textLbl_Click(_slideTexts[_verse2Index], new EventArgs());
            }
            else if ((e.KeyCode == Keys.D3) && _verse3Index >= 0)
            {
                textLbl_Click(_slideTexts[_verse3Index], new EventArgs());
            }
            else if ((e.KeyCode == Keys.D4) && _verse4Index >= 0)
            {
                textLbl_Click(_slideTexts[_verse4Index], new EventArgs());
            }
        }

        private Panel AddPartPanel(int ypos, int height, string name)
        {
            Panel pnl = new Panel();
            pnl.Location = new Point(LeftMargin, ypos);
            pnl.Height = height;
            pnl.Name = name;
            pnl.Tag = _numParts;
            pnl.Paint += new PaintEventHandler(partPnl_Paint);
            this.Controls.Add(pnl);

            return pnl;
        }

        /// <summary>
        /// Add spacer panel (gray line)
        /// </summary>
        private int AddSpacer(int ypos, string name)
        {
            Panel lpnl = new Panel();
            lpnl.Name = name;
            lpnl.Location = new Point(LeftMargin, ypos + SpacerMargin);
            lpnl.BackColor = _spacerColor;
            lpnl.Height = SpaceHeight;
            lpnl.Paint += new PaintEventHandler(lpnl_Paint);
            this.Controls.Add(lpnl);

            return SpacerMargin + lpnl.Height + SpacerMargin;
        }

        #region Events caused by user action


        private void textLbl_Click(object sender, EventArgs e)
        {
            Button lbl = ((Button)sender);

            if (_currentSlideTextIdx >= 0)
            {
                _slideTexts[_currentSlideTextIdx].BackColor = _itemNormalBg;
                _slideTexts[_currentSlideTextIdx].ForeColor = _itemNormalFg;
            }

            int newSlideIdx = _slideTexts.IndexOf(lbl);

            if (_currentSlideTextIdx < newSlideIdx)
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

            _currentSlideTextIdx = newSlideIdx;

            lbl.BackColor = _itemActiveBg;
            lbl.ForeColor = _itemActiveFg;

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

            if (_currentSlideTextIdx >= 0)
            {
                _slideTexts[_currentSlideTextIdx].BackColor = _itemNormalBg;
                _slideTexts[_currentSlideTextIdx].ForeColor = _itemNormalFg;
                _currentSlideTextIdx = -1;
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
            pnl.Width = pnl.Parent.Width - _slidePanelOffset;
        }

        private void lpnl_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            pnl.Width = this.Width - pnl.Left - RightMargin;
        }

        private void partPnl_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            pnl.Width = this.Width - pnl.Left - RightMargin;
        }
       
        private void songSwitchPnl_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            pnl.Width = this.Width - pnl.Left - RightMargin;
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