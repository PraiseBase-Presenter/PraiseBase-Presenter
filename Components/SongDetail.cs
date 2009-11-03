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

		Panel currentSlidePanel = null;

		public delegate void slideClick(object sender, SlideClickEventArgs e);
		public event slideClick SlideClicked;

        public SongDetail()
        {
            InitializeComponent();
        }

		private void SongDetail_Load(object sender, EventArgs e)
        {

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
					spnl.Cursor = Cursors.Hand;
					spnl.Click += new EventHandler(spnl_Click);
					pnl.Controls.Add(spnl);

					PictureBox pcBox = new PictureBox();
					pcBox.Image = thumbs.Images[sng.Parts[numParts].Slides[j].ImageNumber];
					pcBox.Location = new Point(1, 1);
					pcBox.Size = new Size(90, spnl.Height);
					pcBox.Enabled = false;
					spnl.Controls.Add(pcBox);

					Label textLbl = new Label();
					textLbl.Text = sng.Parts[numParts].Slides[j].oneLineText();
					textLbl.ForeColor = Color.Black;
					//textLbl.BackColor = Color.Brown;
					textLbl.Location = new Point(100,5);
					textLbl.Font = txfnt;
					textLbl.Paint += new PaintEventHandler(textLbl_Paint);
					textLbl.Enabled = true;
					textLbl.Height = spnl.Height - 10;
					textLbl.Click += new EventHandler(textLbl_Click);
					spnl.Controls.Add(textLbl);
				}
			}
			currentSong = sng;
			this.ResumeLayout();
		}


		void textLbl_Click(object sender, EventArgs e)
		{
			spnl_Click(((Label)sender).Parent, e);
		}

		void spnl_Click(object sender, EventArgs e)
		{
			Panel pnl = ((Panel)sender);

			if (currentSlidePanel != null)
				currentSlidePanel.BackColor = Color.Transparent;
			pnl.BackColor = Color.LightBlue;
			currentSlidePanel = pnl;

			if (SlideClicked != null)
			{
				SlideClickEventArgs p = new SlideClickEventArgs((int)pnl.Parent.Tag,(int)pnl.Tag);
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




}

