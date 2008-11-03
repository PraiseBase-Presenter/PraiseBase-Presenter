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
	public partial class SongDialog : Form
	{
		public SongDialog()
		{
			InitializeComponent();
		}

		private void SongDialog_Load(object sender, EventArgs e)
		{
			fillList();
			textBoxSearch.Focus();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{

		}

		private void buttonUseInEditor_Click(object sender, EventArgs e)
		{
			EditorWindow.getInstance().Show();
			foreach (ListViewItem lvi in listViewItems.SelectedItems)
			{
				EditorWindow.getInstance().openSong(SongManager.getInstance().Songs[(int)(lvi.Tag)].FilePath);
			}
			EditorWindow.getInstance().Show();
			this.Close();
		}

		private void buttonSearch_Click(object sender, EventArgs e)
		{
			fillList();
		}

		private void fillList()
		{
			listViewItems.Items.Clear();
			string searchText = textBoxSearch.Text.Trim().ToLower();
			foreach (Song sng in SongManager.getInstance().Songs)
			{
				bool use = true;
				if (searchText != String.Empty && !sng.SearchText.Contains(searchText))
					use = false;

				if (checkBoxHasImages.Checked && sng.ImagePaths.Count > 0)
					use = false;

				if (checkBoxHasComments.Checked && sng.Comment==string.Empty)
					use = false;


				if (checkBoxQAImages.Checked && !sng.getQA(Song.QualityAssuranceIndicators.Images))
					use = false;
				if (checkBoxQASegmentation.Checked && !sng.getQA(Song.QualityAssuranceIndicators.Segmentation))
					use = false;
				if (checkBoxQASpelling.Checked && !sng.getQA(Song.QualityAssuranceIndicators.Spelling))
					use = false;
				if (checkBoxQATranslation.Checked && !sng.getQA(Song.QualityAssuranceIndicators.Translation))
					use = false;

				if (use)
				{
					ListViewItem lvi = new ListViewItem(sng.Title);
					lvi.Tag = sng.ID;
					listViewItems.Items.Add(lvi);
				}
			}
			labelResults.Text = listViewItems.Items.Count.ToString() + " Treffer";
			textBoxSearch.Focus();
		}

		private void buttonReset_Click(object sender, EventArgs e)
		{
			textBoxSearch.Text = String.Empty;
			checkBoxHasImages.Checked = false;
			checkBoxHasNoTranslation.Checked = false;
			checkBoxHasComments.Checked = false;
			checkBoxQAImages.Checked = false;
			checkBoxQASegmentation.Checked = false;
			checkBoxQASpelling.Checked = false;
			checkBoxQATranslation.Checked = false;
			fillList();
			textBoxSearch.Focus();
		}

		private void SongDialog_Shown(object sender, EventArgs e)
		{
			textBoxSearch.Focus();
		}
	}
}
