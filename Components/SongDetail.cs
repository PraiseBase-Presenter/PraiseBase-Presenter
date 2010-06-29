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
    public partial class SongDetail : UserControl
    {
		Pbp.Song currentSong;

		int elemHeight = 62;
		int numParts = 0;
		int slidePanelOffset = 0;

		Label currentSlidePanel = null;

		public delegate void slideClick(object sender, SlideClickEventArgs e);
		public event slideClick SlideClicked;

        public delegate void imageClick(object sender, SlideImageClickEventArgs e);
        public event imageClick ImageClicked;

        public SongDetail()
        {
            InitializeComponent();
        }

		private void SongDetail_Load(object sender, EventArgs e)
        {
            this.KeyDown += new KeyEventHandler(SongDetail_KeyDown);
        }

        // TODO
        void SongDetail_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
        }

        public void setSong(Pbp.Song sng)
        {
            this.SuspendLayout();
	
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
				//pnl.BackColor = Color.Red;
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
					Panel spnl = new Panel();
					spnl.Tag = j;
					//spnl.BackColor = Color.Blue;
					spnl.Location = new Point(slidePanelOffset, j * elemHeight);
					spnl.Height = elemHeight;
					spnl.Paint += new PaintEventHandler(spnl_Paint);
					//spnl.Cursor = Cursors.Hand;
					//spnl.Click += new EventHandler(spnl_Click);
					pnl.Controls.Add(spnl);

					PictureBox pcBox = new PictureBox();
                    int imgNr = sng.Parts[numParts].Slides[j].ImageNumber;
                    pcBox.Image = thumbs.Images[imgNr];
                    pcBox.Tag = sng.RelativeImagePaths.Count >= imgNr && imgNr > 0 ? sng.RelativeImagePaths[imgNr - 1] : String.Empty;
					pcBox.Location = new Point(1, 1);
					pcBox.Size = new Size(90, spnl.Height);
					pcBox.Enabled = true;
                    pcBox.Cursor = Cursors.Hand;
                    pcBox.Click += new EventHandler(pcBox_Click);
					spnl.Controls.Add(pcBox);

					Label textLbl = new Label();
					textLbl.Text = sng.Parts[numParts].Slides[j].oneLineText();
					textLbl.ForeColor = Color.Black;
					//textLbl.BackColor = Color.Brown;
					textLbl.Location = new Point(100,1);
                    textLbl.Height = spnl.Height - 2;
                    textLbl.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
					textLbl.Font = txfnt;
					textLbl.Paint += new PaintEventHandler(textLbl_Paint);
					textLbl.Enabled = true;
                    textLbl.Cursor = Cursors.Hand;
                    textLbl.Tag = j;
					textLbl.Click += new EventHandler(textLbl_Click);
                    textLbl.MouseEnter += new EventHandler(textLbl_MouseEnter);
                    textLbl.MouseLeave += new EventHandler(textLbl_MouseLeave);
					spnl.Controls.Add(textLbl);
				}
			}
			currentSong = sng;
			this.ResumeLayout();
		}

        void textLbl_MouseLeave(object sender, EventArgs e)
        {
            if (currentSlidePanel == (Label)sender)
                ((Label)sender).BackColor = Color.AliceBlue;
            else
                ((Label)sender).BackColor = Color.Transparent;
        }

        void textLbl_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.LightBlue;
        }

        void pcBox_Click(object sender, EventArgs e)
        {
            if (ImageClicked != null)
            {
                this.Focus();
                SlideImageClickEventArgs p = new SlideImageClickEventArgs((string)((PictureBox)sender).Tag);
                ImageClicked(this, p);
            }
        }


		void textLbl_Click(object sender, EventArgs e)
		{
            Label pnl = ((Label)sender);

            if (currentSlidePanel != null)
            {
                currentSlidePanel.BackColor = Color.Transparent;
            }

            pnl.BackColor = Color.AliceBlue;
            currentSlidePanel = pnl;


            if (SlideClicked != null)
            {
                this.Focus();
                SlideClickEventArgs p = new SlideClickEventArgs((int)pnl.Parent.Parent.Tag, (int)pnl.Tag);
                SlideClicked(this, p);
            }
		}
        

		/* Paint Events */

		void textLbl_Paint(object sender, PaintEventArgs e)
		{
			Label lbl = ((Label)sender);
			lbl.Width = (lbl.Parent.Width - 100) - 10;			
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
    }

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



}

