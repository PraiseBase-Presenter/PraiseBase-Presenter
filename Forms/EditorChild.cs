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
			}
            else
            {
                MessageBox.Show("Diese Lieddatei ist leider fehlerhaft!","Liededitor",MessageBoxButtons.OK,MessageBoxIcon.Error);
				valid = false;
				this.Close();
            }

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
                    i++;
                    partNode.Nodes.Add(slideNode);
                }
                treeViewContents.Nodes[0].Nodes.Add(partNode);
                j++;
            }
            treeViewContents.ExpandAll();
        }

        private void treeViewContents_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewContents.SelectedNode.Level == 2)
            {
				int partId = treeViewContents.SelectedNode.Parent.Index;
				int slideId = treeViewContents.SelectedNode.Index;

				buttonAddItem.Enabled = true;
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
				
				tabControlEditor.SelectedIndex = 2;
               
				Song.Slide sld = sng.Parts[partId].Slides[slideId];
                textBoxSongText.Text = sld.lineBreakText();
				textBoxSongTranslation.Text = sld.lineBreakTranslation();

                comboBoxSlideHorizOrientation.SelectedIndex = (int)sld.HorizontalAlign;
                comboBoxSlideVertOrientation.SelectedIndex = (int)sld.VerticalAlign;

                pictureBoxPreview.Image = projWindow.showSlide(sld, sng.getImage(sld.ImageNumber), true);

            }
            else if (treeViewContents.SelectedNode.Level == 1)
            {
				int partId = treeViewContents.SelectedNode.Index;

				buttonAddItem.Enabled = true;
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

				tabControlEditor.SelectedIndex = 1;
                
                Song.Part prt = sng.Parts[partId];
                textBoxSongPartCaption.Text = prt.Caption;

            }
            else
            {
				buttonAddItem.Enabled = true;
				buttonDelItem.Enabled = false;
				buttonMoveDown.Enabled = false;
				buttonMoveUp.Enabled = false;


                tabControlEditor.SelectedIndex = 0;

                textBoxSongTitle.Text = sng.Title;

                textBoxComment.Text = sng.Comment;
                checkBoxQAImages.Checked = sng.getQA(Song.QualityAssuranceIndicators.Images);
                checkBoxQASpelling.Checked = sng.getQA(Song.QualityAssuranceIndicators.Spelling);
                checkBoxQATranslation.Checked = sng.getQA(Song.QualityAssuranceIndicators.Translation);
                checkBoxQASegmentation.Checked = sng.getQA(Song.QualityAssuranceIndicators.Segmentation);

                labelFont.Text = sng.TextFont.Name + ", " + sng.TextFont.Style.ToString() + ", " + sng.TextFont.Size.ToString();
                labelFontTranslation.Text = sng.TranslationFont.Name + ", " + sng.TranslationFont.Style.ToString() + ", " + sng.TranslationFont.Size.ToString();
                pictureBoxFontColor.BackColor= sng.TextColor;
                pictureBoxFontTranslationColor.BackColor = sng.TranslationColor;

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

                comboBoxSongParts.Items.Clear();
                comboBoxSongParts.Text = "";
                comboBoxSongParts.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBoxSongParts.AutoCompleteSource = AutoCompleteSource.ListItems;
				foreach (string str in Settings.Instance.SongParts)
                {
                    comboBoxSongParts.Items.Add(str);
                }

                int i=0;
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
        }

        private void textBoxSongTitle_TextChanged(object sender, EventArgs e)
        {
            sng.Title = textBoxSongTitle.Text;
            treeViewContents.Nodes[0].Text = sng.Title;
        }

        private void buttonNewSongPart_Click(object sender, EventArgs e)
        {
            comboBoxSongParts.Text = comboBoxSongParts.Text.Trim();
            if (comboBoxSongParts.Text == "")
            {
                MessageBox.Show("Der Name für diesen Liedteil fehlt!","Liededitor",MessageBoxButtons.OK,MessageBoxIcon.Error);
                comboBoxSongParts.Focus();
                return;
            }
			addSongPart(comboBoxSongParts.Text);

			textBoxSongText.Focus();
            comboBoxSongParts.Text = "";
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


        private void textBoxSongPartCaption_TextChanged(object sender, EventArgs e)
        {
            string cap = textBoxSongPartCaption.Text.Trim();
			sng.Parts[treeViewContents.SelectedNode.Index].Caption = cap;
            treeViewContents.SelectedNode.Text = cap;
        }

        private void EditorChild_Load(object sender, EventArgs e)
        {
            ((EditorWindow)MdiParent).setStatus("Lied " + sng.FilePath + " geöffnet");
        }

        private void buttonAddNewSlide_Click(object sender, EventArgs e)
        {
            int partId = 0;
            Song.Slide sld = new Song.Slide(sng);
            sld.ImageNumber = 0;
			sld.HorizontalAlign = sng.DefaultHorizAlign;
			sld.VerticalAlign = sng.DefaultVertAlign;
            if (treeViewContents.SelectedNode.Level == 1)
            {
                partId = treeViewContents.SelectedNode.Index;
                sng.Parts[partId].Slides.Add(sld);
                populateTree();
                treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId].LastNode;
            }
            else if (treeViewContents.SelectedNode.Level == 2)
            {
                partId = treeViewContents.SelectedNode.Parent.Index;
                sng.Parts[partId].Slides.Add(sld);
                populateTree();
                treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId].LastNode;
            }           
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (treeViewContents.SelectedNode != null)
            {
                if (treeViewContents.SelectedNode.Level == 2)
                {
                    buttonAddNewSlide_Click(sender, e);
                }
                else if (treeViewContents.SelectedNode.Level == 1)
                {
                    buttonAddNewSlide_Click(sender, e);
                }
                else
                {
					addSongPart(null);
                }
            }
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


        private void tabControlEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlEditor.SelectedIndex == 2)
            {
                if (treeViewContents.SelectedNode.Level == 0)
                    treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[0].Nodes[0];
                else if (treeViewContents.SelectedNode.Level == 1)
                    treeViewContents.SelectedNode = treeViewContents.SelectedNode.Nodes[0];
				alignTextFields();
            }
            else if (tabControlEditor.SelectedIndex == 1)
            {
                if (treeViewContents.SelectedNode.Level==0)
                    treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[0];
                else if (treeViewContents.SelectedNode.Level==2)
                    treeViewContents.SelectedNode = treeViewContents.SelectedNode.Parent;
            }
            else
            {
                treeViewContents.SelectedNode = treeViewContents.Nodes[0];
            }
        }




        private void comboBoxSlideHorizOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int partIdx = treeViewContents.SelectedNode.Parent.Index;
            int slideIdx = treeViewContents.SelectedNode.Index;
            sng.Parts[partIdx].Slides[slideIdx].HorizontalAlign = (Song.SongTextHorizontalAlign)comboBoxSlideHorizOrientation.SelectedIndex;
            pictureBoxPreview.Image = projWindow.showSlide(sng.Parts[partIdx].Slides[slideIdx], sng.getImage(sng.Parts[partIdx].Slides[slideIdx].ImageNumber), true);

			sng.DefaultHorizAlign = sng.Parts[partIdx].Slides[slideIdx].HorizontalAlign;
        }

        private void comboBoxSlideVertOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int partIdx = treeViewContents.SelectedNode.Parent.Index;
            int slideIdx = treeViewContents.SelectedNode.Index;
            sng.Parts[partIdx].Slides[slideIdx].VerticalAlign = (Song.SongTextVerticalAlign)comboBoxSlideVertOrientation.SelectedIndex;
            pictureBoxPreview.Image = projWindow.showSlide(sng.Parts[partIdx].Slides[slideIdx], sng.getImage(sng.Parts[partIdx].Slides[slideIdx].ImageNumber), true);

			sng.DefaultVertAlign = sng.Parts[partIdx].Slides[slideIdx].VerticalAlign;
        }

        private void buttonProjectionMasterFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.Font = sng.TextFont;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sng.TextFont = dlg.Font;
                labelFont.Text = sng.TextFont.Name+ ", " + sng.TextFont.Style.ToString() + ", "+ sng.TextFont.Size.ToString();
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
            }
        }

        private void buttonChooseProjectionForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = sng.TextColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sng.TextColor = dlg.Color;
                pictureBoxFontColor.BackColor = sng.TextColor;
            }
        }

        private void buttonTranslationColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = sng.TranslationColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sng.TranslationColor = dlg.Color;
                pictureBoxFontTranslationColor.BackColor = sng.TranslationColor;
            }
        }

        private void trackBarLineSpacing_Scroll(object sender, EventArgs e)
        {
            sng.TextLineSpacing = trackBarLineSpacing.Value;
            labelLineSpacing.Text = trackBarLineSpacing.Value.ToString();
        }

        private void comboBoxSongParts_Click(object sender, EventArgs e)
        {
            comboBoxSongParts.DroppedDown = true;
        }

        private void comboBoxSongParts_Enter(object sender, EventArgs e)
        {
            comboBoxSongParts.DroppedDown = true;
        }



		private void buttonDelSlide_Click(object sender, EventArgs e)
		{
			int partId = treeViewContents.SelectedNode.Parent.Index;
			if (sng.Parts[partId].Slides.Count > 1)
			{
				if (MessageBox.Show("Folie wirklich löschen?", "Liededitor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int slideId = treeViewContents.SelectedNode.Index;
					sng.Parts[partId].Slides.RemoveAt(slideId);
					populateTree();
					treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId];
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
			if (treeViewContents.SelectedNode != null && treeViewContents.SelectedNode.Level == 2)
			{
				int partId = treeViewContents.SelectedNode.Parent.Index;
				int slideId = treeViewContents.SelectedNode.Index;
				sng.Parts[partId].Slides.duplicate(slideId);
				populateTree();
				treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId].Nodes[slideId];
			}
		}

		private void buttonSlideSeparate_Click(object sender, EventArgs e)
		{
			if (treeViewContents.SelectedNode != null && treeViewContents.SelectedNode.Level == 2)
			{
				int partId = treeViewContents.SelectedNode.Parent.Index;
				int slideId = treeViewContents.SelectedNode.Index;
				sng.Parts[partId].Slides.duplicate(slideId);

				populateTree();
				treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId].Nodes[slideId];
			}
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
			textBoxSongText.Width = (tabPage3.Width - 20) / 2;
			textBoxSongTranslation.Left = textBoxSongText.Right + 5;
			textBoxSongTranslation.Width = tabPage3.Width - 10 - textBoxSongTranslation.Left;
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
			if (treeViewContents.SelectedNode.Level == 2)
			{
				int partIdx = treeViewContents.SelectedNode.Parent.Index;
				int slideIdx = treeViewContents.SelectedNode.Index;

				ImageDialog imd = new ImageDialog();

				if (sng.Parts[partIdx].Slides[slideIdx].ImageNumber > 0)
					imd.imagePath = Settings.Instance.DataDirectory + Path.DirectorySeparatorChar + Settings.Instance.ImageDir + Path.DirectorySeparatorChar + sng.ImagePaths[sng.Parts[partIdx].Slides[slideIdx].ImageNumber - 1];

				if (sng.ImagePaths.Count == 0)
					imd.forAll = true;

				if (imd.ShowDialog(this) == DialogResult.OK)
				{
					if (imd.imagePath != "")
					{
						string imString = imd.imagePath.Substring((Settings.Instance.DataDirectory + Path.DirectorySeparatorChar + Settings.Instance.ImageDir + Path.DirectorySeparatorChar).Length);

						if (imd.forAll)
						{
							sng.ImagePaths.Clear();
							sng.ImagePaths.Add(imString);
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
							if (sng.ImagePaths.Contains(imString))
							{
								sng.Parts[partIdx].Slides[slideIdx].ImageNumber = sng.ImagePaths.IndexOf(imString) + 1;
							}
							else
							{
								sng.ImagePaths.Add(imString);
								sng.Parts[partIdx].Slides[slideIdx].ImageNumber = sng.ImagePaths.Count;
							}
						}
					}
					else
					{
						if (imd.forAll)
						{
							sng.ImagePaths.Clear();
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
							sng.Parts[partIdx].Slides[slideIdx].ImageNumber = 0;
						}
					}
					pictureBoxPreview.Image = projWindow.showSlide(sng.Parts[partIdx].Slides[slideIdx], sng.getImage(sng.Parts[partIdx].Slides[slideIdx].ImageNumber), true);
					

				}
			}
		}



    }
}
