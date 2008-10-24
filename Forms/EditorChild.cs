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
        Settings setting;
        projectionWindow projWindow;
		public bool valid;
		public bool changed = false;

        public EditorChild(string fileName)
        {
            InitializeComponent();

            projWindow = projectionWindow.getInstance();

            this.WindowState = FormWindowState.Maximized;
            setting = new Settings();

			sng = new EditableSong(fileName);
            if (sng.isValid)
            {
                this.Text = sng.title;
                populateTree();
                treeViewContents.SelectedNode = treeViewContents.Nodes[0];
				valid = true;
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
            treeViewContents.Nodes.Add(sng.title);
            int j = 0;
            foreach (Song.Part part in sng.parts)
            {
                TreeNode partNode = new TreeNode(part.caption);
                int i = 0;
                foreach (Song.Slide slide in part.slides)
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
				if (sng.parts[partId].slides.Count > 1)
					buttonDelItem.Enabled = true;
				else
					buttonDelItem.Enabled = false;
				if (slideId < sng.parts[partId].slides.Count - 1)
					buttonMoveDown.Enabled = true;
				else
					buttonMoveDown.Enabled = false;
				if (slideId > 0)
					buttonMoveUp.Enabled = true;
				else
					buttonMoveUp.Enabled = false;
				
				tabControlEditor.SelectedIndex = 2;
               
				Song.Slide sld = sng.parts[partId].slides[slideId];
                textBoxSongText.Text = sld.lineBreakText();
				textBoxSongTranslation.Text = sld.lineBreakTranslation();

                comboBoxSlideHorizOrientation.SelectedIndex = (int)sld.horizAlign;
                comboBoxSlideVertOrientation.SelectedIndex = (int)sld.vertAlign;

                pictureBoxPreview.Image = projWindow.showSlide(sld, sng.getImage(sld.imageNumber), true);

            }
            else if (treeViewContents.SelectedNode.Level == 1)
            {
				int partId = treeViewContents.SelectedNode.Index;

				buttonAddItem.Enabled = true;
				if (sng.parts.Count > 1)
					buttonDelItem.Enabled = true;
				else
					buttonDelItem.Enabled = false;
				if (partId < sng.parts.Count-1)
					buttonMoveDown.Enabled = true;
				else
					buttonMoveDown.Enabled = false;
				if (partId > 0)
					buttonMoveUp.Enabled = true;
				else
					buttonMoveUp.Enabled = false;

				tabControlEditor.SelectedIndex = 1;
                
                Song.Part prt = sng.parts[partId];
                textBoxSongPartCaption.Text = prt.caption;

            }
            else
            {
				buttonAddItem.Enabled = true;
				buttonDelItem.Enabled = false;
				buttonMoveDown.Enabled = false;
				buttonMoveUp.Enabled = false;


                tabControlEditor.SelectedIndex = 0;

                textBoxSongTitle.Text = sng.title;

                textBoxComment.Text = sng.comment;
                checkBoxQAImages.Checked = sng.QAImage;
                checkBoxQASpelling.Checked = sng.QASpelling;
                checkBoxQATranslation.Checked = sng.QATranslation;
                checkBoxQASegmentation.Checked = sng.QASegmentation;

                labelFont.Text = sng.font.Name + ", " + sng.font.Style.ToString() + ", " + sng.font.Size.ToString();
                labelFontTranslation.Text = sng.fontTranslation.Name + ", " + sng.fontTranslation.Style.ToString() + ", " + sng.fontTranslation.Size.ToString();
                pictureBoxFontColor.BackColor= sng.fontColor;
                pictureBoxFontTranslationColor.BackColor = sng.fontColorTranslation;

                trackBarLineSpacing.Value = sng.lineSpacing;
                labelLineSpacing.Text = sng.lineSpacing.ToString();

                comboBoxLanguage.Items.Clear();
                comboBoxLanguage.Text = sng.language;
                comboBoxLanguage.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBoxLanguage.AutoCompleteSource = AutoCompleteSource.ListItems;
                foreach (string str in setting.languages)
                {
                    comboBoxLanguage.Items.Add(str);
                }

                comboBoxSongParts.Items.Clear();
                comboBoxSongParts.Text = "";
                comboBoxSongParts.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBoxSongParts.AutoCompleteSource = AutoCompleteSource.ListItems;
                foreach (string str in setting.songParts)
                {
                    comboBoxSongParts.Items.Add(str);
                }

                int i=0;
                checkedListBoxTags.Items.Clear();
                foreach (string str in setting.tags)
                {
                    if (sng.tags.Contains(str))
						checkedListBoxTags.Items.Add(str, true);
					else
						checkedListBoxTags.Items.Add(str);
					i++;
                }
            }
        }

        private void textBoxSongTitle_TextChanged(object sender, EventArgs e)
        {
            sng.title = textBoxSongTitle.Text;
            treeViewContents.Nodes[0].Text = sng.title;
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
			Song.Part prt = new Song.Part(sng,caption);
			Song.Slide sld = new Song.Slide(sng);
			prt.slides.Add(sld);
			sng.parts.Add(prt);

			populateTree();
			treeViewContents.SelectedNode = treeViewContents.Nodes[0].LastNode.LastNode;
		}

        private void button1_Click(object sender, EventArgs e)
        {
            populateTree();
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            sng.language = comboBoxLanguage.Text;
        }


        private void textBoxSongPartCaption_TextChanged(object sender, EventArgs e)
        {
            string cap = textBoxSongPartCaption.Text.Trim();
            sng.setPartCaption(cap, treeViewContents.SelectedNode.Index);
            treeViewContents.SelectedNode.Text = cap;
        }

        private void EditorChild_Load(object sender, EventArgs e)
        {
            ((EditorWindow)MdiParent).setStatus("Lied " + sng.path + " geöffnet");
        }

        private void buttonAddNewSlide_Click(object sender, EventArgs e)
        {
            int partId = 0;
            Song.Slide sld = new Song.Slide(sng);
            sld.imageNumber = -1;
            if (treeViewContents.SelectedNode.Level == 1)
            {
                partId = treeViewContents.SelectedNode.Index;
                sng.parts[partId].slides.Add(sld);
                populateTree();
                treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId].LastNode;
            }
            else if (treeViewContents.SelectedNode.Level == 2)
            {
                partId = treeViewContents.SelectedNode.Parent.Index;
                sng.parts[partId].slides.Add(sld);
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
					if (sng.parts[partId].swapSlideWithUpperSlide(slideId))
					{
						populateTree();
						treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId].Nodes[slideId-1];
					}
				}
				else if (treeViewContents.SelectedNode.Level == 1)
				{
					int partId = treeViewContents.SelectedNode.Index;
					if (sng.swapPartWithUpperPart(partId))
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
					if (sng.parts[partId].swapSlideWithLowerSlide(slideId))
					{
						populateTree();
						treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId].Nodes[slideId + 1];
					}
				}
				else if (treeViewContents.SelectedNode.Level == 1)
				{
					int partId = treeViewContents.SelectedNode.Index;
					if (sng.swapPartWithLowerPart(partId))
					{
						populateTree();
						treeViewContents.SelectedNode = treeViewContents.Nodes[0].Nodes[partId + 1];
					}
				}
			}
		}

        private void textBoxComment_TextChanged(object sender, EventArgs e)
        {
            sng.comment = textBoxComment.Text.Trim();
        }

        private void checkBoxQASpelling_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQASpelling.Checked)
                checkBoxQASpelling.ForeColor = Color.Red;
            else
                checkBoxQASpelling.ForeColor = SystemColors.ControlText;
            sng.QASpelling = checkBoxQASpelling.Checked;
        }

        private void checkBoxQATranslation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQATranslation.Checked)
                checkBoxQATranslation.ForeColor = Color.Red;
            else
                checkBoxQATranslation.ForeColor = SystemColors.ControlText;

            sng.QATranslation = checkBoxQATranslation.Checked;
        }

        private void checkBoxQAImages_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQAImages.Checked)
                checkBoxQAImages.ForeColor = Color.Red;
            else
                checkBoxQAImages.ForeColor = SystemColors.ControlText;
            sng.QAImage = checkBoxQAImages.Checked;
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

        private void checkBoxQASegmentation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQASegmentation.Checked)
                checkBoxQASegmentation.ForeColor = Color.Red;
            else
                checkBoxQASegmentation.ForeColor = SystemColors.ControlText;
            sng.QASegmentation = checkBoxQASegmentation.Checked;
        }



        private void comboBoxSlideHorizOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int partIdx = treeViewContents.SelectedNode.Parent.Index;
            int slideIdx = treeViewContents.SelectedNode.Index;
            sng.parts[partIdx].slides[slideIdx].horizAlign = (Song.SongTextHorizontalAlign)comboBoxSlideHorizOrientation.SelectedIndex;
            pictureBoxPreview.Image = projWindow.showSlide(sng.parts[partIdx].slides[slideIdx], sng.getImage(sng.parts[partIdx].slides[slideIdx].imageNumber), true);
        }

        private void comboBoxSlideVertOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int partIdx = treeViewContents.SelectedNode.Parent.Index;
            int slideIdx = treeViewContents.SelectedNode.Index;
            sng.parts[partIdx].slides[slideIdx].vertAlign = (Song.SongTextVerticalAlign)comboBoxSlideVertOrientation.SelectedIndex;
            pictureBoxPreview.Image = projWindow.showSlide(sng.parts[partIdx].slides[slideIdx], sng.getImage(sng.parts[partIdx].slides[slideIdx].imageNumber), true);
        }

        private void buttonProjectionMasterFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.Font = sng.font;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sng.font = dlg.Font;
                labelFont.Text = sng.font.Name+ ", " + sng.font.Style.ToString() + ", "+ sng.font.Size.ToString();
            }
        }

        private void buttonTranslationFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.Font = sng.fontTranslation;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sng.fontTranslation = dlg.Font;
                labelFontTranslation.Text = sng.fontTranslation.Name + ", " + sng.fontTranslation.Style.ToString() + ", " + sng.fontTranslation.Size.ToString();
            }
        }

        private void buttonChooseProjectionForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = sng.fontColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sng.fontColor = dlg.Color;
                pictureBoxFontColor.BackColor = sng.fontColor;
            }
        }

        private void buttonTranslationColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = sng.fontColorTranslation;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sng.fontColorTranslation = dlg.Color;
                pictureBoxFontTranslationColor.BackColor = sng.fontColorTranslation;
            }
        }

        private void trackBarLineSpacing_Scroll(object sender, EventArgs e)
        {
            sng.lineSpacing = trackBarLineSpacing.Value;
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
			if (sng.parts[partId].slides.Count > 1)
			{
				if (MessageBox.Show("Folie wirklich löschen?", "Liededitor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int slideId = treeViewContents.SelectedNode.Index;
					sng.parts[partId].slides.RemoveAt(slideId);
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
			if (sng.parts.Count > 1)
			{
				if (MessageBox.Show("Liedteil wirklich löschen?", "Liededitor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int partId = treeViewContents.SelectedNode.Index;
					sng.parts.RemoveAt(partId);
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
				sng.parts[partId].duplicateSlide(slideId);
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
				sng.parts[partId].splitSlide(slideId);

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

				sng.parts[partIdx].slides[slideIdx].setSlideTextTranslation(textBoxSongTranslation.Text);

				pictureBoxPreview.Image = projWindow.showSlide(sng.parts[partIdx].slides[slideIdx], sng.getImage(sng.parts[partIdx].slides[slideIdx].imageNumber), true);

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
				sng.tags.Add(checkedListBoxTags.Items[e.Index].ToString());
			}
			else
			{
				sng.tags.Remove(checkedListBoxTags.Items[e.Index].ToString());
			}
		}

		public void save()
		{
			if (sng.path == null)
				saveAs();
			else
			{
				sng.save(null);
				((EditorWindow)MdiParent).setStatus("Lied gespeichert als " + sng.path + "");
			}
		}

		public void saveAs()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = ((EditorWindow)MdiParent).fileBoxInitialDir;
			saveFileDialog.CheckPathExists = true;
			saveFileDialog.Filter = Song.fileType.getFilterSave();
			saveFileDialog.FilterIndex = ((EditorWindow)MdiParent).fileBoxFilterIndex;
			saveFileDialog.AddExtension = true;
			saveFileDialog.Title = "Lied speichern unter...";

			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				sng.save(saveFileDialog.FileName);
				((EditorWindow)MdiParent).setStatus("Lied gespeichert als " + saveFileDialog.FileName + "");
			}
		}

		private void EditorChild_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult dlg = MessageBox.Show("Willst du die Änderungen im Lied "+sng.title+" speichern?", "Liededitor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (dlg == DialogResult.Yes)
			{
				save();
			}
			else if (dlg == DialogResult.Cancel)
			{
				e.Cancel = true;
			}
		}

		private void updateSongText(object sender, EventArgs e)
		{
			if (treeViewContents.SelectedNode.Level == 2)
			{
				int partIdx = treeViewContents.SelectedNode.Parent.Index;
				int slideIdx = treeViewContents.SelectedNode.Index;

				sng.parts[partIdx].slides[slideIdx].setSlideText(textBoxSongText.Text);

				pictureBoxPreview.Image = projWindow.showSlide(sng.parts[partIdx].slides[slideIdx], sng.getImage(sng.parts[partIdx].slides[slideIdx].imageNumber), true);

			}
		}

    }
}
