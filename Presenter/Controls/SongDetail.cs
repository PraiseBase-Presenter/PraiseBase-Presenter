using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PraiseBase.Presenter.Manager;
using PraiseBase.Presenter.Model.Song;

namespace PraiseBase.Presenter.Controls
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

        [Description("Show first and last background image as selectable item"), Category("SongDetail"), DefaultValue(false)]
        public Boolean ShowFirstAndLastBackground { get; set; }

        //
        // Runtime variables
        //

        private readonly List<Button> _slideTexts = new List<Button>();
        private int _currentSlideTextIdx = -1;

        private int _slidePanelOffset;
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

        private SelectAfterLoad _selectAfterLoad = SelectAfterLoad.None;

        //
        // Look and feel
        //

        private readonly Color _spacerColor = Color.LightGray;
        private const int SpaceHeight = 1;
        private const int SpacerMargin = 4;

        private readonly Color _itemNormalFg = Color.Black;
        private readonly Color _itemNormalBg = Color.White;

        private readonly Color _itemActiveFg = Color.White;
        private readonly Color _itemActiveBg = SystemColors.Highlight;

        private readonly Font _partCaptionFont = new Font("Arial", 13);
        private readonly Font _slideTextFont = new Font("Arial", 9);
        private readonly Font _prevNextSongFont = new Font("Arial", 12);

        private const int ThumbnailLabelSpacing = 5;

        private const int SlidePanelElementSpacing = 1;

        private const int SongSwitchPanelPadding = 4;

        private const int LeftMargin = 5;
        private const int RightMargin = 24;
        private const int TopMargin = 5;
        private const int BottomMargin = 5;

        public ImageManager ImageManager { get; set; }

        public StringCollection AvailableSongCaption { get; set; }

        public SongDetail()
        {
            InitializeComponent();
        }

        public void SetSong(Song sng)
        {
            SetSong(sng, null, null);
        }

        public void SetSong(Song sng, Song previousSong, Song nextSong)
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

            // Clear existing controls
            RemoveControls(Controls);

            // Set scroll value
            VerticalScroll.Value = 0;

            // Clear lists
            _slideTexts.Clear();

            //
            // Draw new stuff
            //

            bool showFirstLastBackgrounds = ShowFirstAndLastBackground || (sng.Parts.Count > 0 && (previousSong != null || nextSong != null));

            int ypos = TopMargin;

            Size labelSize = new Size(0, 0);
            if (AvailableSongCaption != null)
            {
                foreach (var caption in AvailableSongCaption)
                {
                    labelSize = MeasureSize(caption, labelSize);
                }
            }
            else
            {
                foreach (SongPart part in sng.Parts)
                {
                    labelSize = MeasureSize(part.Caption, labelSize);
                }
            }
            _slidePanelOffset = labelSize.Width + 20;

            if (previousSong != null)
            {
                Size measured = TextRenderer.MeasureText(previousSong.Title, _prevNextSongFont);
                int buttonHeight = measured.Height + 6 + (2 * SongSwitchPanelPadding);

                // Add panel for previous song
                Panel pnl = new Panel
                {
                    Height = buttonHeight
                };
                pnl.Paint += songSwitchPnl_Paint;
                pnl.Location = new Point(LeftMargin, TopMargin);

                // Add song title to panel
                _prevSongButton = new Button
                {
                    Location = new Point(0, 0),
                    Height = buttonHeight,
                    Text = @" " + previousSong.Title,
                    Font = _slideTextFont,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Tag = previousSong,
                    FlatStyle = FlatStyle.Flat,
                    Padding = new Padding(SongSwitchPanelPadding),
                    Cursor = Cursors.Hand
                };
                _prevSongButton.FlatAppearance.BorderColor = Color.White;
                _prevSongButton.FlatAppearance.BorderSize = 0;
                if (PreviousSongIcon != null)
                {
                    _prevSongButton.Image = PreviousSongIcon;
                    _prevSongButton.ImageAlign = ContentAlignment.MiddleLeft;
                    _prevSongButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                }
                _prevSongButton.Paint += plbl_Paint;
                _prevSongButton.Click += plbl_ClickPrev;

                pnl.Controls.Add(_prevSongButton);
                
                Controls.Add(pnl);

                ypos += pnl.Height;

                ypos += AddSpacer(ypos);
            }

            if (showFirstLastBackgrounds)
            {
                List<PartPanelElement> fe = new List<PartPanelElement>
                {
                    new PartPanelElement
                    {
                        Background = sng.Parts[0].Slides[0].Background
                    }
                };
                ypos += AddPartCopmponent(ypos, fe, ThumbnailSize.Height, labelSize, -1, null);
            }

            for (int i = 0; i < sng.Parts.Count; i++)
            {
                List<PartPanelElement> elements = new List<PartPanelElement>();
                foreach (var e in  sng.Parts[i].Slides)
                {
                    elements.Add(new PartPanelElement
                    {
                        Text = e.GetOneLineText(),
                        Background = e.Background
                    });
                }
                ypos += AddPartCopmponent(ypos, elements, ThumbnailSize.Height, labelSize, i, sng.Parts[i].Caption);
            }

            if (showFirstLastBackgrounds)
            {
                List<PartPanelElement> fe2 = new List<PartPanelElement>
                {
                    new PartPanelElement
                    {
                        Background = sng.Parts[sng.Parts.Count-1].Slides[sng.Parts[sng.Parts.Count-1].Slides.Count-1].Background
                    }
                };
                ypos += AddPartCopmponent(ypos, fe2, ThumbnailSize.Height, labelSize, -1, null);
            }

            if (nextSong != null)
            {
                Size measured = TextRenderer.MeasureText(nextSong.Title, _prevNextSongFont);

                int buttonHeight = measured.Height + 6 + (2 * SongSwitchPanelPadding);

                // Add panel for next song
                Panel pnl = new Panel
                {
                    Location = new Point(LeftMargin, ypos),
                    Height = buttonHeight
                };
                pnl.Paint += songSwitchPnl_Paint;

                // Add song title to panel
                _nextSongButton = new Button
                {
                    Location = new Point(0, 0),
                    Height = buttonHeight,
                    Text = @" " + nextSong.Title,
                    Font = _slideTextFont,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Tag = nextSong,
                    FlatStyle = FlatStyle.Flat,
                    Padding = new Padding(SongSwitchPanelPadding),
                    Cursor = Cursors.Hand
                };
                _nextSongButton.FlatAppearance.BorderColor = Color.White;
                _nextSongButton.FlatAppearance.BorderSize = 0;
                _nextSongButton.Paint += plbl_Paint;
                _nextSongButton.Click += plbl_ClickNext;
                if (NextSongIcon != null)
                {
                    _nextSongButton.Image = NextSongIcon;
                    _nextSongButton.ImageAlign = ContentAlignment.MiddleLeft;
                    _nextSongButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                }

                pnl.Controls.Add(_nextSongButton);

                Controls.Add(pnl);

                ypos += pnl.Height;
            }

            Panel lpnl = new Panel
            {
                Location = new Point(LeftMargin, ypos + BottomMargin - 1),
                BackColor = Color.White,
                Height = 1
            };
            Controls.Add(lpnl); 

            _currentSong = sng;

            ResumeLayout();

            if (_selectAfterLoad == SelectAfterLoad.First && _slideTexts.Count > 0)
            {
                _selectAfterLoad = SelectAfterLoad.None;
                _slideTexts[0].Focus();
                textLbl_Click(_slideTexts[0], new EventArgs());
            }
            else if (_selectAfterLoad == SelectAfterLoad.Last && _slideTexts.Count > 0)
            {
                _selectAfterLoad = SelectAfterLoad.None;
                _slideTexts[_slideTexts.Count - 1].Focus();
                textLbl_Click(_slideTexts[_slideTexts.Count - 1], new EventArgs());
            }
        }

        private void RemoveControls(ControlCollection ctls)
        {
            if (ctls.Count > 0)
            {
                for (int i = Controls.Count - 1; i >= 0; i--)
                {
                    Controls.RemoveAt(i);
                }
            }
        }

        private int AddPartCopmponent(int startPos, List<PartPanelElement> elements, int slidePanelHeight, Size labelSize, int partNumber, string caption)
        {
            int numSlides = elements.Count;
            int ypos = 0;

            // Add panel for this part
            int panelHeight = (numSlides * slidePanelHeight) + ((numSlides - 1) * SlidePanelElementSpacing);
            Panel songPartPanel = AddPartPanel(startPos, panelHeight, partNumber);
            ypos += songPartPanel.Height;

            // Add part caption label to panel
            Label plbl = new Label
            {
                Location = new Point(0, 0),
                Size = labelSize,
                Text = caption,
                Font = _partCaptionFont
            };
            songPartPanel.Controls.Add(plbl);

            int slidePanelY = 0;

            // Add sub-panels for each slide
            for (int j = 0; j < numSlides; j++)
            {
                    // Slide panel
                Panel slidePanel = new Panel
                {
                    Location = new Point(_slidePanelOffset, slidePanelY),
                    Height = slidePanelHeight,
                    Tag = j
                };
                slidePanel.Paint += spnl_Paint;
                songPartPanel.Controls.Add(slidePanel);

                slidePanelY += slidePanelHeight + SlidePanelElementSpacing;

                int pictureBoxPanelWidth = ThumbnailSize.Width;

                // Picture box
                IBackground bg = elements[j].Background;
                PictureBox previewPictureBox = new PictureBox
                {
                    Location = new Point(0, 0),
                    Size = ThumbnailSize,
                    Image = ImageManager.GetThumb(bg),
                    Tag = bg,
                    Enabled = true,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Cursor = Cursors.Hand
                };
                previewPictureBox.Click += pcBox_Click;
                slidePanel.Controls.Add(previewPictureBox);

                // Text label
                Button textLbl = new Button
                {
                    Location = new Point(pictureBoxPanelWidth + ThumbnailLabelSpacing, 0),
                    Height = slidePanelHeight,
                    Text = elements[j].Text ?? "(Nur Hintergrund)",
                    Padding = new Padding(2),
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = _itemNormalFg,
                    BackColor = _itemNormalBg,
                    Font = _slideTextFont,
                    Enabled = true,
                    AutoEllipsis = true,
                    UseCompatibleTextRendering = true,
                    TextAlign = ContentAlignment.TopLeft,
                    Cursor = Cursors.Hand,
                    Tag = (elements[j].Text != null ? (object)j : (object)elements[j].Background)
                };
                textLbl.FlatAppearance.BorderColor = Color.White;
                textLbl.FlatAppearance.BorderSize = 0;
                textLbl.Paint += textLbl_Paint;
                textLbl.Click += textLbl_Click;
                textLbl.KeyUp += textLbl_KeyUp;
                slidePanel.Controls.Add(textLbl);

                _slideTexts.Add(textLbl);

                if (j == 0)
                {
                    if (_refrainIndex < 0 && (caption == "Refrain" || caption == "Chorus"))
                    {
                        _refrainIndex = _slideTexts.Count - 1;
                    }
                    else if (_prechorusIndex < 0 && (caption == "Pre-Chorus" || caption == "Prechorus"))
                    {
                        _prechorusIndex = _slideTexts.Count - 1;
                    }
                    else if (_bridgeIndex < 0 && (caption == "Bridge"))
                    {
                        _bridgeIndex = _slideTexts.Count - 1;
                    }
                    else if (_verse1Index < 0 && (caption == "Strophe 1" || caption == "Teil 1" || caption == "Verse 1"))
                    {
                        _verse1Index = _slideTexts.Count - 1;
                    }
                    else if (_verse2Index < 0 && (caption == "Strophe 2" || caption == "Teil 2" || caption == "Verse 2"))
                    {
                        _verse2Index = _slideTexts.Count - 1;
                    }
                    else if (_verse3Index < 0 && (caption == "Strophe 3" || caption == "Teil 3" || caption == "Verse 3"))
                    {
                        _verse3Index = _slideTexts.Count - 1;
                    }
                    else if (_verse4Index < 0 && (caption == "Strophe 4" || caption == "Teil 4" || caption == "Verse 4"))
                    {
                        _verse4Index = _slideTexts.Count - 1;
                    }
                }
            }


            // Add spacer panel (gray line)
            ypos += AddSpacer(startPos + ypos);

            return ypos;
        }

        private Size MeasureSize(string s, Size labelSize)
        {
            Size measured = TextRenderer.MeasureText(s, _partCaptionFont);
            return new Size(Math.Max(labelSize.Width, measured.Width), Math.Max(labelSize.Height, measured.Height));
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

        private Panel AddPartPanel(int ypos, int height, int partNumber)
        {
            Panel pnl = new Panel
            {
                Location = new Point(LeftMargin, ypos),
                Height = height,
                Tag = partNumber
            };
            pnl.Paint += partPnl_Paint;
            Controls.Add(pnl);

            return pnl;
        }

        /// <summary>
        /// Add spacer panel (gray line)
        /// </summary>
        private int AddSpacer(int ypos)
        {
            Panel lpnl = new Panel
            {
                Location = new Point(LeftMargin, ypos + SpacerMargin),
                BackColor = _spacerColor,
                Height = SpaceHeight
            };
            lpnl.Paint += lpnl_Paint;
            Controls.Add(lpnl);

            return SpacerMargin + lpnl.Height + SpacerMargin;
        }

        #region Events caused by user action


        private void textLbl_Click(object sender, EventArgs e)
        {
            Button lbl = ((Button) sender);

            if (_currentSlideTextIdx >= 0)
            {
                _slideTexts[_currentSlideTextIdx].BackColor = _itemNormalBg;
                _slideTexts[_currentSlideTextIdx].ForeColor = _itemNormalFg;
            }

            int newSlideIdx = _slideTexts.IndexOf(lbl);

            if (_currentSlideTextIdx < newSlideIdx)
            {
                int tOffset = ((Panel) lbl.Parent).Parent.Bottom;
                if (tOffset + VerticalScroll.Value > Height)
                    VerticalScroll.Value = tOffset + VerticalScroll.Value - Height + 2;
                PerformLayout();
            }
            else
            {
                int tOffset = ((Panel) lbl.Parent).Parent.Top;
                if (tOffset < 0)
                    VerticalScroll.Value += tOffset - 5;
                PerformLayout();
            }

            _currentSlideTextIdx = newSlideIdx;

            lbl.BackColor = _itemActiveBg;
            lbl.ForeColor = _itemActiveFg;

            var bg = lbl.Tag as IBackground;
            if (bg != null)
            {
                if (ImageClicked != null)
                {
                    Focus();
                    SlideImageClickEventArgs p = new SlideImageClickEventArgs(bg);
                    ImageClicked(this, p);
                }
            }
            else
            {
                if (SlideClicked != null)
                {
                    Focus();
                    var partNumber = (int) lbl.Parent.Parent.Tag;
                    var slideNumber = (int) lbl.Tag;
                    SlideClickEventArgs p = new SlideClickEventArgs(_currentSong, partNumber, slideNumber);
                    SlideClicked(this, p);
                }
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
                Focus();
                SlideImageClickEventArgs p = new SlideImageClickEventArgs((IBackground)pb.Tag);
                ImageClicked(this, p);
            }
        }

        
        void plbl_ClickPrev(object sender, EventArgs e)
        {
            if (PreviousSongClicked != null)
            {
                _selectAfterLoad = SelectAfterLoad.Last;
                SongSwitchEventArgs p = new SongSwitchEventArgs((Song)((Button)sender).Tag);
                PreviousSongClicked(this, p);
            }
        }

        void plbl_ClickNext(object sender, EventArgs e)
        {
            if (NextSongClicked != null)
            {
                _selectAfterLoad = SelectAfterLoad.First;
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
            pnl.Width = Width - pnl.Left - RightMargin;
        }

        private void partPnl_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            pnl.Width = Width - pnl.Left - RightMargin;
        }
       
        private void songSwitchPnl_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            pnl.Width = Width - pnl.Left - RightMargin;
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
        public SlideClickEventArgs(Song song, int partNum, int slideNum)
        {
            Song = song;
            SlideNumber = slideNum;
            PartNumber = partNum;
        }

        public Song Song { get; set; }

        public int SlideNumber { get; set; }

        public int PartNumber { get; set; }
    }

    public class SlideImageClickEventArgs : EventArgs
    {
        public SlideImageClickEventArgs(IBackground bg)
        {
            Background = bg;
        }

        public IBackground Background { get; set; }
    }

    public class SongSwitchEventArgs : EventArgs
    {
        public SongSwitchEventArgs(Song song)
        {
            Song = song;
        }

        public Song Song { get; set; }
    }

    internal class PartPanelElement
    {
        public string Text { get; set; }
        public IBackground Background { get; set; }
    }

    internal enum SelectAfterLoad
    {
        None,
        First,
        Last
    }

    #endregion Helper classes
}