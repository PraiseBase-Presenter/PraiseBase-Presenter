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

        private int elemHeight = 62;
        private int numParts = 0;
        private int slidePanelOffset = 0;

        public delegate void slideClick(object sender, SlideClickEventArgs e);

        public event slideClick SlideClicked;

        public delegate void imageClick(object sender, SlideImageClickEventArgs e);

        public event imageClick ImageClicked;

        private List<Label> slideTexts;
        private List<PictureBox> slideImages;
        private int currentSlideTextIdx = -1;

        //private int currentSlideImageIdx = -1;

        private int refrainIndex;
        private int prechorusIndex;
        private int bridgeIndex;
        private int verse1Index;
        private int verse2Index;
        private int verse3Index;
        private int verse4Index;

        private Color borderHoverColor = Color.DarkGray;
        private Color borderActiveColor = Color.Black;
        private Color itemActiveFG = Color.White;
        private Color itemActiveBG = SystemColors.Highlight;

        private int thumbWidth;

        public SongDetail()
        {
            InitializeComponent();
            slideTexts = new List<Label>();
            slideImages = new List<PictureBox>();

            thumbWidth = PraiseBase.Presenter.Properties.Settings.Default.ThumbSize.Width;
        }

        public void setSong(Song sng)
        {
            this.VerticalScroll.Value = 0;
            PerformLayout();

            this.SuspendLayout();

            slideTexts.Clear();
            slideImages.Clear();
            currentSlideTextIdx = -1;
            refrainIndex = -1;
            prechorusIndex = -1;
            bridgeIndex = -1;
            verse1Index = -1;
            verse2Index = -1;
            verse3Index = -1;
            verse4Index = -1;

            // Clear
            for (int j = numParts - 1; j >= 0; j--)
            {
                this.Controls.RemoveByKey("partPanel" + j.ToString());
                this.Controls.RemoveByKey("spacerPanel" + j.ToString());
            }

            // Draw new stuff

            Point startPoint = new Point(0, 5);
            Font pfnt = new Font("Arial", 16);
            Font txfnt = new Font("Arial", 11);
            int ypos = startPoint.Y;
            //var thumbs = PraiseBase.Presenter.ImageManager.Instance.GetThumbsFromList(sng.RelativeImagePaths);

            Size labelSize = new Size(0, 0);
            for (int i = 0; i < sng.Parts.Count; i++)
            {
                Size measured = TextRenderer.MeasureText(sng.Parts[i].Caption, pfnt);
                labelSize = new Size(Math.Max(labelSize.Width, measured.Width), Math.Max(labelSize.Height, measured.Height));
            }
            slidePanelOffset = labelSize.Width + 20;

            for (numParts = 0; numParts < sng.Parts.Count; numParts++)
            {
                int numSlides = sng.Parts[numParts].Slides.Count;

                Panel pnl = new Panel();
                pnl.Name = "partPanel" + numParts.ToString();
                pnl.Tag = numParts;

                pnl.Paint += new PaintEventHandler(partPnl_Paint);
                pnl.Location = new Point(startPoint.X, ypos);
                pnl.Height = numSlides * (elemHeight) + 4;

                Label plbl = new Label();
                plbl.Text = sng.Parts[numParts].Caption;
                plbl.Font = pfnt;
                plbl.Location = new Point(5, 5);
                plbl.Size = labelSize;
                pnl.Controls.Add(plbl);

                ypos += pnl.Height + 10;
                this.Controls.Add(pnl);

                if (numParts < sng.Parts.Count - 1)
                {
                    Panel lpnl = new Panel();
                    lpnl.Name = "spacerPanel" + numParts.ToString();
                    lpnl.Location = new Point(startPoint.X + 5, ypos - 8);
                    lpnl.BackColor = Color.LightBlue;
                    lpnl.Height = 2;
                    lpnl.Paint += new PaintEventHandler(lpnl_Paint);
                    this.Controls.Add(lpnl);
                }

                for (int j = 0; j < numSlides; j++)
                {
                    Panel slidePanel = new Panel();
                    slidePanel.Tag = j;
                    slidePanel.Location = new Point(slidePanelOffset, j * elemHeight);
                    slidePanel.Height = elemHeight;
                    slidePanel.Paint += new PaintEventHandler(spnl_Paint);
                    pnl.Controls.Add(slidePanel);

                    Panel panelPreviewPictureBoxContainer = new Panel();
                    panelPreviewPictureBoxContainer.Location = new Point(1, 1);
                    panelPreviewPictureBoxContainer.Size = new Size(thumbWidth, slidePanel.Height);
                    panelPreviewPictureBoxContainer.BackColor = Color.Transparent;
                    slidePanel.Controls.Add(panelPreviewPictureBoxContainer);

                    PictureBox previewPictureBox = new PictureBox();
                    previewPictureBox.Location = new Point(2, 2);
                    previewPictureBox.Size = new Size(panelPreviewPictureBoxContainer.Width - 4, panelPreviewPictureBoxContainer.Height - 5);
                    var bg = sng.Parts[numParts].Slides[j].Background;
                    previewPictureBox.Image = PraiseBase.Presenter.ImageManager.Instance.GetThumb(bg);
                    previewPictureBox.Tag = bg;
                    previewPictureBox.Enabled = true;
                    previewPictureBox.Cursor = Cursors.Hand;
                    previewPictureBox.Click += new EventHandler(pcBox_Click);
                    previewPictureBox.MouseEnter += new EventHandler(previewPictureBox_MouseEnter);
                    previewPictureBox.MouseLeave += new EventHandler(previewPictureBox_MouseLeave);
                    panelPreviewPictureBoxContainer.Controls.Add(previewPictureBox);

                    slideImages.Add(previewPictureBox);

                    Panel panelTextLabelContainer = new Panel();
                    panelTextLabelContainer.Location = new Point(thumbWidth + 10, 1);
                    panelTextLabelContainer.Height = slidePanel.Height - 1;
                    panelTextLabelContainer.BackColor = Color.Transparent;
                    panelTextLabelContainer.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
                    panelTextLabelContainer.Paint += new PaintEventHandler(tpnl_Paint);
                    slidePanel.Controls.Add(panelTextLabelContainer);

                    Label textLbl = new Label();
                    textLbl.Location = new Point(2, 2);
                    textLbl.Height = panelTextLabelContainer.Height - 4;
                    textLbl.Text = sng.Parts[numParts].Slides[j].GetOneLineText();
                    textLbl.ForeColor = Color.Black;
                    textLbl.BackColor = Color.White;
                    textLbl.Font = txfnt;
                    textLbl.Enabled = true;
                    textLbl.AutoEllipsis = true;
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
            }
            currentSong = sng;

            this.ResumeLayout();
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
                slideTexts[currentSlideTextIdx].BackColor = Color.White;
                slideTexts[currentSlideTextIdx].ForeColor = Color.Black;
                slideTexts[currentSlideTextIdx].Parent.BackColor = Color.Transparent;

                slideImages[currentSlideTextIdx].Parent.BackColor = Color.Transparent;
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
                slideTexts[currentSlideTextIdx].Parent.BackColor = Color.Transparent;
                slideTexts[currentSlideTextIdx].BackColor = Color.White;
                slideTexts[currentSlideTextIdx].ForeColor = Color.Black;
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
                ((PictureBox)sender).Parent.BackColor = Color.Transparent;
        }

        private void textLbl_MouseEnter(object sender, EventArgs e)
        {
            if (currentSlideTextIdx < 0 || slideTexts[currentSlideTextIdx] != (Label)sender)
            {
                ((Label)sender).Parent.BackColor = borderHoverColor;
                ((Label)sender).BackColor = Color.LightBlue;
                slideImages[slideTexts.IndexOf((Label)sender)].Parent.BackColor = borderHoverColor;
            }
        }

        private void textLbl_MouseLeave(object sender, EventArgs e)
        {
            if (currentSlideTextIdx < 0 || slideTexts[currentSlideTextIdx] != (Label)sender)
            {
                ((Label)sender).Parent.BackColor = Color.Transparent;
                ((Label)sender).BackColor = Color.White;
                slideImages[slideTexts.IndexOf((Label)sender)].Parent.BackColor = Color.Transparent;
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
            lbl.Width = (lbl.Parent.Width) - 4;
        }

        private void spnl_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            pnl.Width = pnl.Parent.Width - slidePanelOffset;
        }

        private void lpnl_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            pnl.Width = this.Width - pnl.Left - 24;
        }

        private void partPnl_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            pnl.Width = this.Width - pnl.Left - 24;
        }

        #endregion Paint Events

        private void SongDetail_Load(object sender, EventArgs e)
        {
        }
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