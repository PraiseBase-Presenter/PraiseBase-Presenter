/*
 *   PraiseBase Presenter 
 *   The open source lyrics and image projection software for churches
 *   
 *   http://code.google.com/p/praisebasepresenter
 *
 *   This program is free software; you can redistribute it and/or
 *   modify it under the terms of the GNU General Public License
 *   as published by the Free Software Foundation; either version 2
 *   of the License, or (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program; if not, write to the Free Software
 *   Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 *   Author:
 *      Nicolas Perrenoud <nicu_at_lavine.ch>
 *   Co-authors:
 *      ...
 *
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Pbp.Properties;

namespace Pbp.Forms
{
    public partial class EditorChild : Form
    {
        EditableSong sng;
        projectionWindow projWindow;
		public bool valid;
		public bool changed = false;
		int hashCode;

		private int currentPartId = 0;
		private int currentSlideId = 0;

        public EditorChild(string fileName)
        {
            InitializeComponent();

            projWindow = projectionWindow.getInstance();

            this.WindowState = FormWindowState.Maximized;

			sng = new EditableSong(fileName);
            if (sng.IsValid)
            {
                this.Text = sng.Title;
                populateTree();
                treeViewContents.SelectedNode = treeViewContents.Nodes[0];
				valid = true;
				hashCode = sng.GetHashCode();

				populatePartList();

				textBoxComment.Text = sng.Comment;
				checkBoxQAImages.Checked = sng.getQA(Song.QualityAssuranceIndicators.Images);
				checkBoxQASpelling.Checked = sng.getQA(Song.QualityAssuranceIndicators.Spelling);
				checkBoxQATranslation.Checked = sng.getQA(Song.QualityAssuranceIndicators.Translation);
				checkBoxQASegmentation.Checked = sng.getQA(Song.QualityAssuranceIndicators.Segmentation);

				labelFont.Text = sng.TextFont.Name + ", " + sng.TextFont.Style.ToString() + ", " + sng.TextFont.Size.ToString();
				labelFontTranslation.Text = sng.TranslationFont.Name + ", " + sng.TranslationFont.Style.ToString() + ", " + sng.TranslationFont.Size.ToString();
				buttonChooseProjectionForeColor.BackColor= sng.TextColor;
				buttonTranslationColor.BackColor = sng.TranslationColor;

				trackBarLineSpacing.Value = sng.TextLineSpacing;
				labelLineSpacing.Text = sng.TextLineSpacing.ToString();

				comboBoxLanguage.Items.Clear();
				comboBoxLanguage.Text = sng.Language;
				comboBoxLanguage.AutoCompleteMode = AutoCompleteMode.Suggest;
				comboBoxLanguage.AutoCompleteSource = AutoCompleteSource.ListItems;
				foreach (string str in Settings.Instance.Languages)
				{
					comboBoxLanguage.Items.Add(str);
				}

				int i = 0;
				checkedListBoxTags.Items.Clear();
				foreach (string str in Settings.Instance.Tags)
				{
					if (sng.Tags.Contains(str))
						checkedListBoxTags.Items.Add(str, true);
					else
						checkedListBoxTags.Items.Add(str);
					i++;
				}

				
			}
            else
            {
                MessageBox.Show("Diese Lieddatei ist leider fehlerhaft!","Liededitor",MessageBoxButtons.OK,MessageBoxIcon.Error);
				valid = false;
				this.Close();
            }

        }

		public void populatePartList()
		{
			foreach (string str in Settings.Instance.SongParts)
			{
				ToolStripMenuItem tItem = new ToolStripMenuItem(str);
				tItem.Click += new EventHandler(partAddMenu_click);
				this.liedteilToolStripMenuItem.DropDownItems.Add(tItem);
			}
			this.liedteilToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
			ToolStripMenuItem oItem = new ToolStripMenuItem("Anderer Name...");
			oItem.Click += new EventHandler(partAddMenuOther_click);
			this.liedteilToolStripMenuItem.DropDownItems.Add(oItem);
		}

		public void partAddMenuOther_click(object sender, EventArgs e)
		{
			TextBox iTBox = new TextBox();
			iTBox.Location = new Point(5, 5);
			iTBox.Width = 300;
			iTBox.Name = "songPartText";
			iTBox.Font = new Font(iTBox.Font.FontFamily, 12);

			Button okButton = new Button();
			okButton.Text = "Hinzufügen";
			okButton.Location = new Point(310, 5);
			okButton.Name = "okButton";
			okButton.Click += new EventHandler(addSongPartFormokButton_Click);

			Button cancelButton = new Button();
			cancelButton.Text = "Abbrechen";
			cancelButton.Location = new Point(310 + okButton.Width + 5, 5);
			cancelButton.Name = "cancelButton";
			
			Form iForm = new Form();
			iForm.Width = cancelButton.Right + 15;
			iForm.Height = 60;
			iForm.Text = "Name des Liedteils";
			iForm.ShowInTaskbar = false;
			iForm.ControlBox = false;
			iForm.AcceptButton = okButton;
			iForm.CancelButton = cancelButton;
			iForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			iForm.StartPosition = FormStartPosition.CenterParent;

			iForm.Controls.Add(iTBox);
			iForm.Controls.Add(okButton);
			iForm.Controls.Add(cancelButton);

			iForm.ShowDialog(this);

			if (iForm.DialogResult == DialogResult.OK)
			{
				System.Windows.Forms.Control[] textField = iForm.Controls.Find("songPartText",true);
				string res = ((TextBox)textField[0]).Text.Trim();
				if (res != "")
					addSongPart(res);
			}
		}

		void addSongPartFormokButton_Click(object sender, EventArgs e)
		{
			((Form)((Button)sender).Parent).DialogResult = DialogResult.OK;
			((Form)((Button)sender).Parent).Close();
		}

		public void partAddMenu_click(object sender, EventArgs e)
		{
			addSongPart(((ToolStripMenuItem)sender).Text);
		}

        public void populateTree()
        {
            treeViewContents.Nodes.Clear();
            treeViewContents.Nodes.Add(sng.Title);
            int j = 0;
            foreach (Song.Part part in sng.Parts)
            {
                TreeNode partNode = new TreeNode(part.Caption);
                int i = 0;
                foreach (Song.Slide slide in part.Slides)
                {
                    TreeNode slideNode = new TreeNode("Folie " + (i + 1).ToString());
					slideNode.ContextMenuStrip = slideContextMenu;
                    i++;
                    partNode.Nodes.Add(slideNode);
                }
				partNode.ContextMenuStrip = partContextMenu;
                treeViewContents.Nodes[0].Nodes.Add(partNode);
                j++;
            }
			treeViewContents.Nodes[0].ContextMenuStrip = songContextMenu;
            treeViewContents.ExpandAll();
        }

        private void treeViewContents_AfterSelect(object sender, TreeViewEventArgs e)
        {
			int partId = -1;
			int slideId = -1;
            if (treeViewContents.SelectedNode.Level == 2)
            {
				partId = treeViewContents.SelectedNode.Parent.Index;
				slideId = treeViewContents.SelectedNode.Index;

				if (sng.Parts[partId].Slides.Count > 1)
					buttonDelItem.Enabled = true;
				else
					buttonDelItem.Enabled = false;
				if (slideId < sng.Parts[partId].Slides.Count - 1)
					buttonMoveDown.Enabled = true;
				else
					buttonMoveDown.Enabled = false;
				if (slideId > 0)
					buttonMoveUp.Enabled = true;
				else
					buttonMoveUp.Enabled = false;				
				
            }
            else if (treeViewContents.SelectedNode.Level == 1)
            {
				partId = treeViewContents.SelectedNode.Index;

				if (sng.Parts.Count > 1)
					buttonDelItem.Enabled = true;
				else
					buttonDelItem.Enabled = false;
				if (partId < sng.Parts.Count-1)
					buttonMoveDown.Enabled = true;
				else
					buttonMoveDown.Enabled = false;
				if (partId > 0)
					buttonMoveUp.Enabled = true;
				else
					buttonMoveUp.Enabled = false;
				                
            }
            else
            {
				buttonDelItem.Enabled = false;
				buttonMoveDown.Enabled = false;
				buttonMoveUp.Enabled = false;
            }

			if (partId < 0)
				partId = currentPartId;
			if (slideId < 0)
				slideId = currentSlideId;

			if (partId >= sng.Parts.Count)
				partId = sng.Parts.Count - 1;
			if (slideId >= sng.Parts[partId].Slides.Count)
				slideId = sng.Parts[partId].Slides.Count;
			
			Song.Slide sld = sng.Parts[partId].Slides[slideId];
			textBoxSongText.Text = sld.lineBreakText();
			textBoxSongTranslation.Text = sld.lineBreakTranslation();
			comboBoxSlideHorizOrientation.SelectedIndex = (int)sld.HorizontalAlign;
			comboBoxSlideVertOrientation.SelectedIndex = (int)sld.VerticalAlign;
			pictureBoxPreview.Image = projWindow.showSlide(sld, sng.getImage(sld.ImageNumber), true);

			currentPartId = partId;
			currentSlideId = slideId;
        }

		private void addSongPart(string caption)
		{
			Song.Part prt = new Song.Part(caption);
			Song.Slide sld = new Song.Slide(sng);
			sld.ImageNumber = 0;
			sld.HorizontalAlign = sng.DefaultHorizAlign;
			sld.VerticalAlign = sng.DefaultVertAlign;

			prt.Slides.Add(sld);
			sng.Parts.Add(prt);

			populateTree();
			treeViewContents.SelectedNode = treeViewContents.Nodes[0].LastNode.LastNode;
		}

        private void button1_Click(object sender, EventArgs e)
        {
            populateTree();
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            sng.Language = comboBoxLanguage.Text;
        }


        private void EditorChild_Load(object sender, EventArgs e)
        {
            ((EditorWindow)MdiParent).setStatus("Lied " + sng.FilePath + " geöffnet");
        }

        private void buttonAddNewSlide_Click(object sender, EventArgs e)
        {
            Song.Slide sld = new Song.Slide(sng);
			sng.Parts[currentPartId].Slides.Add(sld);
            populateTree();
			treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[currentPartId].LastNode;
        }

        private void buttonDelItem_Click(object sender, EventArgs e)
        {
            if (treeViewContents.SelectedNode != null)
            {
                if (treeViewContents.SelectedNode.Level == 2)
                {
					buttonDelSlide_Click(sender, e);
                }
                else if (treeViewContents.SelectedNode.Level == 1)
                {
					buttonDelSongPart_Click(sender, e);
                }
            }
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
			if (treeViewContents.SelectedNode != null)
			{
				if (treeViewContents.SelectedNode.Level == 2)
				{
					int partId = treeViewContents.SelectedNode.Parent.Index;
					int slideId = treeViewContents.SelectedNode.Index;
					if (sng.Parts[partId].Slides.swapWithUpper(slideId))
					{
						populateTree();
						treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId].Nodes[slideId-1];
					}
				}
				else if (treeViewContents.SelectedNode.Level == 1)
				{
					int partId = treeViewContents.SelectedNode.Index;
					if (sng.Parts.swapWithUpper(partId))
					{
						populateTree();
						treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId-1];
					}
				}
			}
        }


		private void buttonMoveDown_Click(object sender, EventArgs e)
		{
			if (treeViewContents.SelectedNode != null)
			{
				if (treeViewContents.SelectedNode.Level == 2)
				{
					int partId = treeViewContents.SelectedNode.Parent.Index;
					int slideId = treeViewContents.SelectedNode.Index;
					if (sng.Parts[partId].Slides.swapWithLower(slideId))
					{
						populateTree();
						treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId].Nodes[slideId + 1];
					}
				}
				else if (treeViewContents.SelectedNode.Level == 1)
				{
					int partId = treeViewContents.SelectedNode.Index;
					if (sng.Parts.swapWithLower(partId))
					{
						populateTree();
						treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId + 1];
					}
				}
			}
		}

        private void textBoxComment_TextChanged(object sender, EventArgs e)
        {
			sng.Comment = textBoxComment.Text.Trim();
        }

        private void checkBoxQASpelling_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxQASpelling.Checked)
			{
				checkBoxQASpelling.ForeColor = Color.Red;
				sng.setQA(Song.QualityAssuranceIndicators.Spelling);
			}
			else
			{
				checkBoxQASpelling.ForeColor = SystemColors.ControlText;
				sng.remQA(Song.QualityAssuranceIndicators.Spelling);
			}
        }

        private void checkBoxQATranslation_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxQATranslation.Checked)
			{
				checkBoxQATranslation.ForeColor = Color.Red;
				sng.setQA(Song.QualityAssuranceIndicators.Translation);
			}
			else
			{
				checkBoxQATranslation.ForeColor = SystemColors.ControlText;
				sng.remQA(Song.QualityAssuranceIndicators.Translation);
			}
        }

        private void checkBoxQAImages_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxQAImages.Checked)
			{
				checkBoxQAImages.ForeColor = Color.Red;
				sng.setQA(Song.QualityAssuranceIndicators.Images);
			}
			else
			{
				checkBoxQAImages.ForeColor = SystemColors.ControlText;
				sng.remQA(Song.QualityAssuranceIndicators.Images);
			}
        }

		private void checkBoxQASegmentation_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxQASegmentation.Checked)
			{
				checkBoxQASegmentation.ForeColor = Color.Red;
				sng.setQA(Song.QualityAssuranceIndicators.Segmentation);
			}
			else
			{
				checkBoxQASegmentation.ForeColor = SystemColors.ControlText;
				sng.remQA(Song.QualityAssuranceIndicators.Segmentation);
			}
		}


        private void comboBoxSlideHorizOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            sng.Parts[currentPartId].Slides[currentSlideId].HorizontalAlign = (Song.SongTextHorizontalAlign)comboBoxSlideHorizOrientation.SelectedIndex;
			sng.DefaultHorizAlign = sng.Parts[currentPartId].Slides[currentSlideId].HorizontalAlign;
			previewSlide();
        }

        private void comboBoxSlideVertOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
			sng.Parts[currentPartId].Slides[currentSlideId].VerticalAlign = (Song.SongTextVerticalAlign)comboBoxSlideVertOrientation.SelectedIndex;
			sng.DefaultVertAlign = sng.Parts[currentPartId].Slides[currentSlideId].VerticalAlign;
			previewSlide();
		}

        private void buttonProjectionMasterFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.Font = sng.TextFont;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sng.TextFont = dlg.Font;
                labelFont.Text = sng.TextFont.Name+ ", " + sng.TextFont.Style.ToString() + ", "+ sng.TextFont.Size.ToString();
				previewSlide();
			}
        }

        private void buttonTranslationFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.Font = sng.TranslationFont;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sng.TranslationFont = dlg.Font;
                labelFontTranslation.Text = sng.TranslationFont.Name + ", " + sng.TranslationFont.Style.ToString() + ", " + sng.TranslationFont.Size.ToString();
				previewSlide();
			}
        }

        private void buttonChooseProjectionForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = sng.TextColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sng.TextColor = dlg.Color;
				buttonChooseProjectionForeColor.BackColor = sng.TextColor;
				previewSlide();
            }
        }

        private void buttonTranslationColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = sng.TranslationColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sng.TranslationColor = dlg.Color;
				buttonTranslationColor.BackColor = sng.TranslationColor;
				previewSlide();
			}
        }

        private void trackBarLineSpacing_Scroll(object sender, EventArgs e)
        {
            sng.TextLineSpacing = trackBarLineSpacing.Value;
            labelLineSpacing.Text = trackBarLineSpacing.Value.ToString();
			previewSlide();
		}


		private void buttonDelSlide_Click(object sender, EventArgs e)
		{
			if (sng.Parts[currentPartId].Slides.Count > 1)
			{
				if (MessageBox.Show("Folie wirklich löschen?", "Liededitor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int slideId = treeViewContents.SelectedNode.Index;
					sng.Parts[currentPartId].Slides.RemoveAt(slideId);
					populateTree();
					currentSlideId = slideId - 1;
					treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[currentPartId].Nodes[currentSlideId];
				}
			}
			else
			{
				MessageBox.Show("Der Liedteil muss mindestens eine Folie haben!", "Liededitor", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}


		private void buttonDelSongPart_Click(object sender, EventArgs e)
		{
			if (sng.Parts.Count > 1)
			{
				if (MessageBox.Show("Liedteil wirklich löschen?", "Liededitor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int partId = treeViewContents.SelectedNode.Index;
					sng.Parts.RemoveAt(partId);
					populateTree();
					treeViewContents.SelectedNode = treeViewContents.Nodes[0];
				}
			}
			else
			{
				MessageBox.Show("Das Lied muss mindestens einen Liedteil haben!", "Liededitor", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private void buttonSlideDuplicate_Click(object sender, EventArgs e)
		{
				sng.Parts[currentPartId].Slides.duplicate(currentSlideId);
				populateTree();
				treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[currentPartId].Nodes[currentSlideId];
		}

		private void buttonSlideSeparate_Click(object sender, EventArgs e)
		{
			sng.Parts[currentPartId].Slides.split(currentSlideId);
			populateTree();
			treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[currentPartId].Nodes[currentSlideId];
		}

		private void EditorChild_Resize(object sender, EventArgs e)
		{
			alignTextFields();
		}

		private void textBoxSongTranslation_TextChanged(object sender, EventArgs e)
		{
			if (treeViewContents.SelectedNode.Level == 2)
			{
				int partIdx = treeViewContents.SelectedNode.Parent.Index;
				int slideIdx = treeViewContents.SelectedNode.Index;

				sng.Parts[partIdx].Slides[slideIdx].setSlideTextTranslation(textBoxSongTranslation.Text);

				pictureBoxPreview.Image = projWindow.showSlide(sng.Parts[partIdx].Slides[slideIdx], sng.getImage(sng.Parts[partIdx].Slides[slideIdx].ImageNumber), true);

			}
		}

		private void alignTextFields()
		{
			//textBoxSongText.Width = (tabPage3.Width - 20) / 2;
			//textBoxSongTranslation.Left = textBoxSongText.Right + 5;
			//textBoxSongTranslation.Width = tabPage3.Width - 10 - textBoxSongTranslation.Left;
		}

		private void groupBoxNewSongPart_Enter(object sender, EventArgs e)
		{

		}

		private void comboBoxLanguage_Enter(object sender, EventArgs e)
		{
			comboBoxLanguage.DroppedDown = true;
		}

		private void checkedListBoxTags_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (e.CurrentValue == CheckState.Unchecked)
			{
				sng.Tags.Add(checkedListBoxTags.Items[e.Index].ToString());
			}
			else
			{
				sng.Tags.Remove(checkedListBoxTags.Items[e.Index].ToString());
			}
		}

		public void save()
		{
			if (sng.FilePath == null)
				saveAs();
			else
			{
				sng.save(null);
				hashCode = sng.GetHashCode();
				((EditorWindow)MdiParent).setStatus("Lied gespeichert als " + sng.FilePath + "");
				SongManager.getInstance().reloadSong(sng.FilePath);
			}
		}

		public void saveAs()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = ((EditorWindow)MdiParent).fileBoxInitialDir;
			saveFileDialog.CheckPathExists = true;
			saveFileDialog.FileName = sng.Title;
			saveFileDialog.Filter = Song.getFileBoxFilterSave();
			saveFileDialog.FilterIndex = ((EditorWindow)MdiParent).fileBoxFilterIndex;
			saveFileDialog.AddExtension = true;
			saveFileDialog.Title = "Lied speichern unter...";

			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				hashCode = sng.GetHashCode();
				sng.save(saveFileDialog.FileName);
				((EditorWindow)MdiParent).setStatus("Lied gespeichert als " + saveFileDialog.FileName + "");
			}

			SongManager.getInstance().reloadSong(sng.FilePath);

		}

		private void EditorChild_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (hashCode != sng.GetHashCode())
			{
				DialogResult dlg = MessageBox.Show("Willst du die Änderungen im Lied " + sng.Title + " speichern?", "Liededitor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (dlg == DialogResult.Yes)
				{
					save();
				}
				else if (dlg == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
			}
		}

		private void updateSongText(object sender, EventArgs e)
		{
			if (treeViewContents.SelectedNode.Level == 2)
			{
				int partIdx = treeViewContents.SelectedNode.Parent.Index;
				int slideIdx = treeViewContents.SelectedNode.Index;

				sng.Parts[partIdx].Slides[slideIdx].setSlideText(textBoxSongText.Text);

				pictureBoxPreview.Image = projWindow.showSlide(sng.Parts[partIdx].Slides[slideIdx], sng.getImage(sng.Parts[partIdx].Slides[slideIdx].ImageNumber), true);

			}
		}

		private void buttonSlideBackground_Click(object sender, EventArgs e)
		{
				ImageDialog imd = new ImageDialog();

				if (sng.Parts[currentPartId].Slides[currentSlideId].ImageNumber > 0)
				{
					imd.imagePath = sng.RelativeImagePaths[sng.Parts[currentPartId].Slides[currentSlideId].ImageNumber - 1];
				}

				if (sng.RelativeImagePaths.Count == 0)
					imd.forAll = true;

				if (imd.ShowDialog(this) == DialogResult.OK)
				{
					if (imd.imagePath != "")
					{
						if (imd.forAll)
						{
							sng.RelativeImagePaths.Clear();
							sng.RelativeImagePaths.Add(imd.imagePath);
							for (int i = 0; i < sng.Parts.Count; i++)
							{
								for (int j = 0; j < sng.Parts[i].Slides.Count; j++)
								{
									sng.Parts[i].Slides[j].ImageNumber = 1;
								}
							}
						}
						else
						{
							if (sng.RelativeImagePaths.Contains(imd.imagePath))
							{
								sng.Parts[currentPartId].Slides[currentSlideId].ImageNumber = sng.RelativeImagePaths.IndexOf(imd.imagePath) + 1;
							}
							else
							{
								sng.RelativeImagePaths.Add(imd.imagePath);
								sng.Parts[currentPartId].Slides[currentSlideId].ImageNumber = sng.RelativeImagePaths.Count;
							}
						}
					}
					else
					{
						if (imd.forAll)
						{
							sng.RelativeImagePaths.Clear();
							for (int i = 0; i < sng.Parts.Count; i++)
							{
								for (int j = 0; j < sng.Parts[i].Slides.Count; j++)
								{
									sng.Parts[i].Slides[j].ImageNumber = 0;
								}
							}
						}
						else
						{
							sng.Parts[currentPartId].Slides[currentSlideId].ImageNumber = 0;
						}
					}
					previewSlide();
				}
			
		}

		private void buttonAddItem_MouseDown(object sender, MouseEventArgs e)
		{
			if (addContextMenu.Visible)
			{
				addContextMenu.Hide();
				return;
			}
			if (e.Button == MouseButtons.Left)
			{
				addContextMenu.Show();
			}
		}

		private void addContextMenu_VisibleChanged(object sender, EventArgs e)
		{
			addContextMenu.Show(buttonAddItem.PointToScreen(new Point(0, buttonAddItem.Height-1)));
		}

		private void textBoxSongText_KeyUp(object sender, KeyEventArgs e)
		{
			string text = ((TextBox)sender).Text.Trim();
			sng.Parts[currentPartId].Slides[currentSlideId].setSlideText(text);
			previewSlide();
		}

		private void previewSlide()
		{
			pictureBoxPreview.Image = projWindow.showSlide(sng.Parts[currentPartId].Slides[currentSlideId], sng.getImage(sng.Parts[currentPartId].Slides[currentSlideId].ImageNumber), true);
		}

		private void textBoxSongTranslation_KeyUp(object sender, KeyEventArgs e)
		{
			string text = ((TextBox)sender).Text.Trim();
			sng.Parts[currentPartId].Slides[currentSlideId].setSlideTextTranslation(text);
			previewSlide();
		}

		private void neueFolieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			buttonAddNewSlide_Click(sender, e);
		}

		private void aufToolStripMenuItem_Click(object sender, EventArgs e)
		{
			buttonMoveUp_Click(sender, e);
		}

		private void abToolStripMenuItem_Click(object sender, EventArgs e)
		{
			buttonMoveDown_Click(sender, e);
		}

		private void löschenToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			buttonDelItem_Click(sender, e);
		}

		private void folieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			buttonAddNewSlide_Click(sender, e);
		}

		private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			buttonSlideDuplicate_Click(sender, e);
		}

		private void teilenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			buttonSlideSeparate_Click(sender, e);
		}

		private void treeViewContents_KeyDown(object sender, KeyEventArgs e)
		{
			if (treeViewContents.SelectedNode != null)
				switch (e.KeyCode)
				{
					case Keys.F2:
						treeViewContents.BeginEdit();
						break;
					case Keys.Space:
						treeViewContents.SelectedNode.Toggle();
						break;
					default:
						break;
				}
		}

		private void treeViewContents_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			// --- Here we can customize label for editing ---
			TreeNode tn = treeViewContents.SelectedNode;
			if (tn.Level > 1)
				e.CancelEdit = true;
		}

		private void treeViewContents_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			// --- Here we can transform edited label back to its original format ---
			TreeNode tn = treeViewContents.SelectedNode;
			if (tn.Level == 0)
			{
				tn.Text = e.Label;
				sng.Title = e.Label;
				this.Text = e.Label;
			}
			else if (tn.Level == 1)
			{
				tn.Text = e.Label;
				sng.Parts[tn.Index].Caption = e.Label;
			}

		}

		private void treeViewContents_ValidateLabelEdit(object sender, TreeEx.ValidateLabelEditEventArgs e)
		{
			if(e.Label.Trim()=="") 
			{
				MessageBox.Show("The tree node label cannot be empty",
					"Label Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				e.Cancel = true;
				return;
			}
			if (e.Label.IndexOfAny(new char[]{'\\', '/', ':', '*', '?', '"', '<', '>', '|'})!=-1) {
				MessageBox.Show("Invalid tree node label.\n" + 
					"The tree node label must not contain following characters:\n \\ / : * ? \" < > |", 
					"Label Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				e.Cancel = true;
				return;
			}
		
		}

		private void umbenennenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			treeViewContents.BeginEdit();
		}

		private void umbenennenToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			treeViewContents.BeginEdit();
		}

		private void löschenToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			buttonDelSongPart_Click(sender, e);
		}
    }
}
