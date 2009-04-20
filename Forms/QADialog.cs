using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pbp.Forms
{
	public partial class QADialog : Form
	{
		public QADialog()
		{
			InitializeComponent();
		}

		private void QADialog_Load(object sender, EventArgs e)
		{	
			textBoxComment.Text = SongManager.Instance.CurrentSong.Comment;

			checkBoxQASpelling.Checked = SongManager.Instance.CurrentSong.getQA(Song.QualityAssuranceIndicators.Spelling);
			checkBoxQATranslation.Checked = SongManager.Instance.CurrentSong.getQA(Song.QualityAssuranceIndicators.Translation);
			checkBoxQAImages.Checked = SongManager.Instance.CurrentSong.getQA(Song.QualityAssuranceIndicators.Images);
			checkBoxQASegmentation.Checked = SongManager.Instance.CurrentSong.getQA(Song.QualityAssuranceIndicators.Segmentation);
		}

		private void buttonAccept_Click(object sender, EventArgs e)
		{
			SongManager.Instance.CurrentSong.Comment = textBoxComment.Text;

			if (checkBoxQASpelling.Checked)
				SongManager.Instance.CurrentSong.setQA(Song.QualityAssuranceIndicators.Spelling);
			else
				SongManager.Instance.CurrentSong.remQA(Song.QualityAssuranceIndicators.Spelling);

			if (checkBoxQATranslation.Checked)
				SongManager.Instance.CurrentSong.setQA(Song.QualityAssuranceIndicators.Translation);
			else
				SongManager.Instance.CurrentSong.remQA(Song.QualityAssuranceIndicators.Translation);

			if (checkBoxQAImages.Checked)
				SongManager.Instance.CurrentSong.setQA(Song.QualityAssuranceIndicators.Images);
			else
				SongManager.Instance.CurrentSong.remQA(Song.QualityAssuranceIndicators.Images);

			if (checkBoxQASegmentation.Checked)
				SongManager.Instance.CurrentSong.setQA(Song.QualityAssuranceIndicators.Segmentation);
			else
				SongManager.Instance.CurrentSong.remQA(Song.QualityAssuranceIndicators.Segmentation);

			SongManager.Instance.CurrentSong.save();
			DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
