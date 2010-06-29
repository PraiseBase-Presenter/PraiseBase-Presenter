using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SongDetails
{
    [DefaultEvent("SlideClicked")]
    public partial class SongDetail : UserControl
    {
		Pbp.Song currentSong;

		int elemHeight = 62;
		int numParts = 0;
		int slidePanelOffset = 0;

		public delegate void slideClick(object sender, SlideClickEventArgs e);
		public event slideClick SlideClicked;

        public delegate void imageClick(object sender, SlideImageClickEventArgs e);
        public event imageClick ImageClicked;

        private List<Label> slideTexts;
        private List<PictureBox> slideImages;
        private int currentSlideTextIdx = -1;
        private int currentSlideImageIdx = -1;

        Color borderHoverColor = Color.DarkGray;
        Color borderActiveColor = Color.Black;

        public SongDetail()
        {
            InitializeComponent();
            slideTexts = new List<Label>();
            slideImages = new List<PictureBox>();
        }

        public void setSong(Pbp.Song sng)
        {
            this.VerticalScroll.Value = 0;
            PerformLayout();
            this.SuspendLayout();
            slideTexts.Clear();
            slideImages.Clear();
            currentSlideTextIdx = -1;
	
			// Clear
			for (int j = numParts-1; j >= 0; j--)
			{
				this.Controls.RemoveByKey("partPanel" + j.ToString());
				this.Controls.RemoveByKey("spacerPanel" + j.ToString());
			}
			
			// Draw new stuff

			Point startPoint = new Point(0, 5);
			Font pfnt = new Font("Arial",16);
			Font txfnt = new Font("Arial", 12);
			int ypos = startPoint.Y;
			ImageList thumbs = sng.getThumbs();
            

			Size labelSize = new Size(0,0);
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
				pnl.Name = "partPanel"+numParts.ToString();
				pnl.Tag = numParts;

				pnl.Paint+=new PaintEventHandler(partPnl_Paint);
				pnl.Location = new Point(startPoint.X, ypos);
				pnl.Height = numSlides * (elemHeight)+4;

				Label plbl = new Label();
				plbl.Text = sng.Parts[numParts].Caption;
				plbl.Font = pfnt;
				plbl.Location = new Point(5,5);
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
                    panelPreviewPictureBoxContainer.Size = new Size(90, slidePanel.Height);
                    panelPreviewPictureBoxContainer.BackColor = Color.Transparent;
                    slidePanel.Controls.Add(panelPreviewPictureBoxContainer);

					PictureBox previewPictureBox = new PictureBox();
                    previewPictureBox.Location = new Point(2, 2);
                    previewPictureBox.Size = new Size(panelPreviewPictureBoxContainer.Width - 4, panelPreviewPictureBoxContainer.Height - 5);
                    int imgNr = sng.Parts[numParts].Slides[j].ImageNumber;
                    previewPictureBox.Image = thumbs.Images[imgNr];
                    previewPictureBox.Tag = sng.RelativeImagePaths.Count >= imgNr && imgNr > 0 ? sng.RelativeImagePaths[imgNr - 1] : String.Empty;
					previewPictureBox.Enabled = true;
                    previewPictureBox.Cursor = Cursors.Hand;
                    previewPictureBox.Click += new EventHandler(pcBox_Click);
                    previewPictureBox.MouseEnter += new EventHandler(previewPictureBox_MouseEnter);
                    previewPictureBox.MouseLeave += new EventHandler(previewPictureBox_MouseLeave);
                    panelPreviewPictureBoxContainer.Controls.Add(previewPictureBox);

                    slideImages.Add(previewPictureBox);

                    Panel panelTextLabelContainer = new Panel();
                    panelTextLabelContainer.Location = new Point(100, 1);
                    panelTextLabelContainer.Height = slidePanel.Height - 1;
                    panelTextLabelContainer.BackColor = Color.Transparent;
                    panelTextLabelContainer.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
                    panelTextLabelContainer.Paint += new PaintEventHandler(tpnl_Paint);
                    slidePanel.Controls.Add(panelTextLabelContainer);

					Label textLbl = new Label();
                    textLbl.Location = new Point(2, 2);
                    textLbl.Height = panelTextLabelContainer.Height-4;
                    textLbl.Text = sng.Parts[numParts].Slides[j].oneLineText();
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

                    panelTextLabelContainer.Controls.Add(textLbl);
				}
			}
			currentSong = sng;
			this.ResumeLayout();
		}

        #region Events caused by user action

        void SongDetail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && currentSlideTextIdx >= 0 && currentSlideTextIdx < slideTexts.Count - 1)
            {
                int tOffset = ((Panel)slideTexts[currentSlideTextIdx + 1].Parent.Parent).Parent.Bottom;
                if (tOffset + VerticalScroll.Value > this.Height)
                    VerticalScroll.Value = tOffset + VerticalScroll.Value - this.Height + 2;
                PerformLayout();

                textLbl_Click(slideTexts[currentSlideTextIdx + 1], new EventArgs());
            }
            else if (e.KeyCode == Keys.Up && currentSlideTextIdx > 0)
            {
                int tOffset = ((Panel)slideTexts[currentSlideTextIdx - 1].Parent.Parent).Parent.Top;
                if (tOffset < 0)
                    VerticalScroll.Value += tOffset - 5;
                PerformLayout();

                textLbl_Click(slideTexts[currentSlideTextIdx - 1], new EventArgs());
            }
        }

        void textLbl_Click(object sender, EventArgs e)
        {
            Label pnl = ((Label)sender);

            if (currentSlideTextIdx >= 0)
            {
                slideTexts[currentSlideTextIdx].BackColor = Color.White;
                slideTexts[currentSlideTextIdx].Parent.BackColor = Color.Transparent;

                slideImages[currentSlideTextIdx].Parent.BackColor = Color.Transparent;
            }

            currentSlideTextIdx = slideTexts.IndexOf(pnl);

            pnl.BackColor = Color.LightBlue;
            pnl.Parent.BackColor = borderActiveColor;

            slideImages[currentSlideTextIdx].Parent.BackColor = borderActiveColor;

            if (SlideClicked != null)
            {
                this.Focus();
                SlideClickEventArgs p = new SlideClickEventArgs((int)pnl.Parent.Parent.Parent.Tag, (int)pnl.Tag);
                SlideClicked(this, p);
            }
        }

        void pcBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = ((PictureBox)sender);

            if (currentSlideTextIdx >= 0)
            {
                slideTexts[currentSlideTextIdx].Parent.BackColor = Color.Transparent;
                slideTexts[currentSlideTextIdx].BackColor = Color.White;
                currentSlideTextIdx = -1;
            }

            pb.Parent.BackColor = borderActiveColor;

            if (ImageClicked != null)
            {
                this.Focus();
                SlideImageClickEventArgs p = new SlideImageClickEventArgs((string)pb.Tag);
                ImageClicked(this, p);
            }
        }
        
        void previewPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (slideImages.IndexOf((PictureBox)sender) != currentSlideTextIdx)
                ((PictureBox)sender).Parent.BackColor = borderHoverColor;
        }

        void previewPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (slideImages.IndexOf((PictureBox)sender) != currentSlideTextIdx) 
                ((PictureBox)sender).Parent.BackColor = Color.Transparent;
        }

        void textLbl_MouseEnter(object sender, EventArgs e)
        {
            if (currentSlideTextIdx < 0 || slideTexts[currentSlideTextIdx] != (Label)sender)
            {
                ((Label)sender).Parent.BackColor = borderHoverColor;
                slideImages[slideTexts.IndexOf((Label)sender)].Parent.BackColor = borderHoverColor;
            }
        }

        void textLbl_MouseLeave(object sender, EventArgs e)
        {
            if (currentSlideTextIdx < 0 || slideTexts[currentSlideTextIdx] != (Label)sender)
            {
                ((Label)sender).Parent.BackColor = Color.Transparent;
                slideImages[slideTexts.IndexOf((Label)sender)].Parent.BackColor = Color.Transparent;
            }
        }
        
        #endregion

        #region Paint Events

        void tpnl_Paint(object sender, PaintEventArgs e)
        {
            Panel lbl = ((Panel)sender);
            lbl.Width = (lbl.Parent.Width - 100);
        }

		void textLbl_Paint(object sender, PaintEventArgs e)
		{
			Label lbl = ((Label)sender);
			lbl.Width = (lbl.Parent.Width) - 4;
		}
        
		void spnl_Paint(object sender, PaintEventArgs e)
		{
			Panel pnl = ((Panel)sender);
			pnl.Width = pnl.Parent.Width - slidePanelOffset;
		}
        
		void lpnl_Paint(object sender, PaintEventArgs e)
		{
			Panel pnl = ((Panel)sender);
			pnl.Width = this.Width - pnl.Left - 24;
		}

		void partPnl_Paint(object sender, PaintEventArgs e)
		{
			Panel pnl = ((Panel)sender);
			pnl.Width = this.Width - pnl.Left - 24;

        }

        #endregion
    }

    #region Helper classes
    public class SlideClickEventArgs : EventArgs
	{
		public SlideClickEventArgs(int partNum, int slideNum)
		{
			this.SlideNumber = slideNum;
			this.PartNumber = partNum;
		}
		public int SlideNumber {get;set;}
		public int PartNumber {get;set;}

	}

    public class SlideImageClickEventArgs : EventArgs
	{
		public SlideImageClickEventArgs(string relativePath)
		{
			this.relativePath = relativePath;
		}
		public string relativePath {get;set;}

	}

    #endregion

}

