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
using System.IO;
using System.Windows.Forms;
using Pbp.Properties;
using Pbp.Data.Song;
using Pbp.IO;

namespace Pbp.Forms
{
    public partial class SongEditorChild : Form
    {
        public Song sng { get; protected set; }
        protected String songFilename;

        public bool valid;
        public bool changed = false;
        private int hashCode;

        private int currentPartId = 0;
        private int currentSlideId = 0;

        public SongEditorChild(string fileName)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            if (fileName != null)
            {
                Console.WriteLine("Loading song from file " + fileName);
                try
                {
                    sng = SongFileReaderFactory.Instance.CreateFactoryByFile(fileName).Load(fileName);
                    if (sng.GUID == Guid.Empty)
                    {
                        var smGuid = SongManager.Instance.GetGUIDByPath(fileName);
                        if (smGuid != Guid.Empty)
                        {
                            sng.GUID = smGuid;
                        }
                        else
                        {
                            sng.GUID = SongManager.Instance.GenerateGuid();
                        }
                    }
                }
                catch (NotImplementedException)
                {
                    MessageBox.Show("Dieses Dateiformat wird leider nicht unterstüzt!", "Liededitor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                    this.Close();
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Diese Lieddatei ist leider fehlerhaft (" + e.Message + ")!", "Liededitor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                    this.Close();
                    return;
                }

                songFilename = fileName;
            }
            else
            {
                sng = new Song();
                sng.GUID = SongManager.Instance.GenerateGuid();
                sng.Title = Pbp.Properties.Settings.Default.SongDefaultName;
                sng.Language = Pbp.Properties.Settings.Default.SongDefaultLanguage;
                SongPart tmpPart = new SongPart();
                tmpPart.Caption = Pbp.Properties.Settings.Default.SongPartDefaultName;
                tmpPart.Slides.Add(new SongSlide(sng));
                sng.Parts.Add(tmpPart);

                sng.TextFont = Settings.Default.ProjectionMasterFont;
                sng.TextColor = Settings.Default.ProjectionMasterFontColor;
                sng.TranslationFont = Settings.Default.ProjectionMasterFontTranslation;
                sng.TranslationColor = Settings.Default.ProjectionMasterTranslationColor;
                sng.TextLineSpacing = Settings.Default.ProjectionMasterLineSpacing;
            }

            // Set window title
            this.Text = sng.Title;

            // Data bindings
            textBoxSongTitle.DataBindings.Add("Text", sng, "Title");
            textBoxCCLISongID.DataBindings.Add("Text", sng, "CcliID");
            if (sng.CCliIDReadonly)
            {
                textBoxCCLISongID.ReadOnly = true;
            }
            textBoxCopyright.DataBindings.Add("Text", sng, "Copyright");
            textBoxComment.DataBindings.Add("Text", sng, "Comment");
            textBoxRightsManagement.DataBindings.Add("Text", sng, "RightsManagement");
            textBoxPublisher.DataBindings.Add("Text", sng, "Publisher");

            labelGUID.DataBindings.Add("Text", sng, "GUID");

            string autstr = string.Empty;
            foreach (var aut in sng.Author)
            {
                if (autstr != string.Empty)
                {
                    autstr += ";";
                }
                autstr += aut.Name;
            }
            textBoxAuthors.Text = autstr;

            string sbkstr = string.Empty;
            foreach (var sbk in sng.SongBooks)
            {
                if (sbkstr != string.Empty)
                {
                    sbkstr += ";";
                }
                sbkstr += sbk.Name;
                if (sbk.Entry != null)
                {
                    sbkstr += " " + sbk.Entry;
                }
            }
            textBoxSongbooks.Text = sbkstr;

            populateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[0];
            valid = true;

            hashCode = sng.GetHashCode();

            populatePartList();

            checkBoxQAImages.Checked = sng.GetQA(QualityAssuranceIndicators.Images);
            checkBoxQASpelling.Checked = sng.GetQA(QualityAssuranceIndicators.Spelling);
            checkBoxQATranslation.Checked = sng.GetQA(QualityAssuranceIndicators.Translation);
            checkBoxQASegmentation.Checked = sng.GetQA(QualityAssuranceIndicators.Segmentation);

            labelFont.Text = sng.TextFont.Name + ", " + sng.TextFont.Style.ToString() + ", " + sng.TextFont.Size.ToString();
            labelFontTranslation.Text = sng.TranslationFont.Name + ", " + sng.TranslationFont.Style.ToString() + ", " + sng.TranslationFont.Size.ToString();
            buttonChooseProjectionForeColor.BackColor = sng.TextColor;
            buttonTranslationColor.BackColor = sng.TranslationColor;

            trackBarLineSpacing.Value = sng.TextLineSpacing;
            labelLineSpacing.Text = sng.TextLineSpacing.ToString();

            comboBoxLanguage.Items.Clear();
            comboBoxLanguage.Text = sng.Language;
            comboBoxLanguage.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxLanguage.AutoCompleteSource = AutoCompleteSource.ListItems;
            foreach (string str in Settings.Default.Languages)
            {
                comboBoxLanguage.Items.Add(str);
            }

            int i = 0;
            checkedListBoxTags.Items.Clear();
            foreach (string str in Settings.Default.Tags)
            {
                if (sng.Themes.Contains(str))
                    checkedListBoxTags.Items.Add(str, true);
                else
                    checkedListBoxTags.Items.Add(str);
                i++;
            }
        }

        public void populatePartList()
        {
            foreach (string str in Settings.Default.SongParts)
            {
                ToolStripMenuItem tItem = new ToolStripMenuItem(str);
                tItem.Click += new EventHandler(partAddMenu_click);
                addContextMenu.Items.Add(tItem);
            }
            addContextMenu.Items.Add(new ToolStripSeparator());
            ToolStripMenuItem oItem = new ToolStripMenuItem("Anderer Name...");
            oItem.Click += new EventHandler(partAddMenuOther_click);
            addContextMenu.Items.Add(oItem);
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
                System.Windows.Forms.Control[] textField = iForm.Controls.Find("songPartText", true);
                string res = ((TextBox)textField[0]).Text.Trim();
                if (res != "")
                    addSongPart(res);
            }
        }

        private void addSongPartFormokButton_Click(object sender, EventArgs e)
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
            int j = 0;
            foreach (SongPart part in sng.Parts)
            {
                TreeNode partNode = new TreeNode(part.Caption);
                int i = 0;
                foreach (SongSlide slide in part.Slides)
                {
                    TreeNode slideNode = new TreeNode("Folie " + (i + 1).ToString());
                    slideNode.ContextMenuStrip = slideContextMenu;
                    i++;
                    partNode.Nodes.Add(slideNode);
                }
                partNode.ContextMenuStrip = partContextMenu;
                treeViewContents.Nodes.Add(partNode);
                j++;
            }
            treeViewContents.ContextMenuStrip = songContextMenu;
            treeViewContents.ExpandAll();
        }

        private void treeViewContents_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int partId = -1;
            int slideId = -1;
            if (treeViewContents.SelectedNode.Level == 1)
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

                buttonDuplicateSlide.Enabled = true;
            }
            else if (treeViewContents.SelectedNode.Level == 0)
            {
                partId = treeViewContents.SelectedNode.Index;

                if (sng.Parts.Count > 1)
                    buttonDelItem.Enabled = true;
                else
                    buttonDelItem.Enabled = false;
                if (partId < sng.Parts.Count - 1)
                    buttonMoveDown.Enabled = true;
                else
                    buttonMoveDown.Enabled = false;
                if (partId > 0)
                    buttonMoveUp.Enabled = true;
                else
                    buttonMoveUp.Enabled = false;

                buttonDuplicateSlide.Enabled = false;
            }
            else
            {
                buttonDelItem.Enabled = false;
                buttonMoveDown.Enabled = false;
                buttonMoveUp.Enabled = false;
                buttonDuplicateSlide.Enabled = false;
            }

            if (partId < 0)
                partId = currentPartId;
            if (slideId < 0)
                slideId = currentSlideId;

            if (partId >= sng.Parts.Count)
                partId = sng.Parts.Count - 1;
            if (slideId >= sng.Parts[partId].Slides.Count)
                slideId = sng.Parts[partId].Slides.Count-1;

            textBoxPartCaption.DataBindings.Clear();
            textBoxPartCaption.DataBindings.Add("Text", sng.Parts[partId], "Caption");

            SongSlide sld = sng.Parts[partId].Slides[slideId];
            textBoxSongText.DataBindings.Clear();
            textBoxSongText.DataBindings.Add("Text", sld, "Text");
            textBoxSongTranslation.DataBindings.Clear();
            textBoxSongTranslation.DataBindings.Add("Text", sld, "TranslationText");

            comboBoxSlideHorizOrientation.SelectedIndex = (int)sld.HorizontalAlign;
            comboBoxSlideVertOrientation.SelectedIndex = (int)sld.VerticalAlign;

            pictureBoxPreview.Image = ImageManager.Instance.GetImage(sng.GetImage(sld.ImageNumber));

            currentPartId = partId;
            currentSlideId = slideId;
        }

        private void addSongPart(string caption)
        {
            SongPart prt = new SongPart();
            prt.Caption = caption;
            SongSlide sld = new SongSlide(sng);
            sld.ImageNumber = 0;
            sld.HorizontalAlign = sng.DefaultHorizAlign;
            sld.VerticalAlign = sng.DefaultVertAlign;

            prt.Slides.Add(sld);
            sng.Parts.Add(prt);

            populateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[treeViewContents.Nodes.Count - 1].LastNode;
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
            ((SongEditor)MdiParent).setStatus("Lied " + sng.Title + " geöffnet");
        }

        private void buttonAddNewSlide_Click(object sender, EventArgs e)
        {
            SongSlide sld = new SongSlide(sng);
            sng.Parts[currentPartId].Slides.Add(sld);
            populateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[currentPartId].LastNode;
        }

        private void buttonDelItem_Click(object sender, EventArgs e)
        {
            if (treeViewContents.SelectedNode != null)
            {
                if (treeViewContents.SelectedNode.Level == 1)
                {
                    buttonDelSlide_Click(sender, e);
                }
                else if (treeViewContents.SelectedNode.Level == 0)
                {
                    buttonDelSongPart_Click(sender, e);
                }
            }
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (treeViewContents.SelectedNode != null)
            {
                if (treeViewContents.SelectedNode.Level == 1)
                {
                    int partId = treeViewContents.SelectedNode.Parent.Index;
                    int slideId = treeViewContents.SelectedNode.Index;
                    if (sng.Parts[partId].Slides.SwapWithUpper(slideId))
                    {
                        populateTree();
                        treeViewContents.SelectedNode = treeViewContents.Nodes[partId].Nodes[slideId - 1];
                    }
                }
                else if (treeViewContents.SelectedNode.Level == 0)
                {
                    int partId = treeViewContents.SelectedNode.Index;
                    if (sng.Parts.SwapWithUpper(partId))
                    {
                        populateTree();
                        treeViewContents.SelectedNode = treeViewContents.Nodes[partId - 1];
                    }
                }
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if (treeViewContents.SelectedNode != null)
            {
                if (treeViewContents.SelectedNode.Level == 1)
                {
                    int partId = treeViewContents.SelectedNode.Parent.Index;
                    int slideId = treeViewContents.SelectedNode.Index;
                    if (sng.Parts[partId].Slides.SwapWithLower(slideId))
                    {
                        populateTree();
                        treeViewContents.SelectedNode = treeViewContents.Nodes[partId].Nodes[slideId + 1];
                    }
                }
                else if (treeViewContents.SelectedNode.Level == 0)
                {
                    int partId = treeViewContents.SelectedNode.Index;
                    if (sng.Parts.SwapWithLower(partId))
                    {
                        populateTree();
                        treeViewContents.SelectedNode = treeViewContents.Nodes[partId + 1];
                    }
                }
            }
        }

        private void checkBoxQASpelling_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQASpelling.Checked)
            {
                checkBoxQASpelling.ForeColor = Color.Red;
                sng.SetQA(QualityAssuranceIndicators.Spelling);
            }
            else
            {
                checkBoxQASpelling.ForeColor = SystemColors.ControlText;
                sng.RemQA(QualityAssuranceIndicators.Spelling);
            }
        }

        private void checkBoxQATranslation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQATranslation.Checked)
            {
                checkBoxQATranslation.ForeColor = Color.Red;
                sng.SetQA(QualityAssuranceIndicators.Translation);
            }
            else
            {
                checkBoxQATranslation.ForeColor = SystemColors.ControlText;
                sng.RemQA(QualityAssuranceIndicators.Translation);
            }
        }

        private void checkBoxQAImages_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQAImages.Checked)
            {
                checkBoxQAImages.ForeColor = Color.Red;
                sng.SetQA(QualityAssuranceIndicators.Images);
            }
            else
            {
                checkBoxQAImages.ForeColor = SystemColors.ControlText;
                sng.RemQA(QualityAssuranceIndicators.Images);
            }
        }

        private void checkBoxQASegmentation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQASegmentation.Checked)
            {
                checkBoxQASegmentation.ForeColor = Color.Red;
                sng.SetQA(QualityAssuranceIndicators.Segmentation);
            }
            else
            {
                checkBoxQASegmentation.ForeColor = SystemColors.ControlText;
                sng.RemQA(QualityAssuranceIndicators.Segmentation);
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
                labelFont.Text = sng.TextFont.Name + ", " + sng.TextFont.Style.ToString() + ", " + sng.TextFont.Size.ToString();
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
                    treeViewContents.SelectedNode = treeViewContents.Nodes[currentPartId].Nodes[currentSlideId];
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
            sng.Parts[currentPartId].Slides.Duplicate(currentSlideId);
            populateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[currentPartId].Nodes[currentSlideId];
        }

        private void buttonSlideSeparate_Click(object sender, EventArgs e)
        {
            sng.Parts[currentPartId].Slides.Split(currentSlideId);
            populateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[currentPartId].Nodes[currentSlideId];
        }

        private void EditorChild_Resize(object sender, EventArgs e)
        {
            alignTextFields();
        }

        private void textBoxSongTranslation_TextChanged(object sender, EventArgs e)
        {
            if (treeViewContents.SelectedNode.Level == 1)
            {
                int partIdx = treeViewContents.SelectedNode.Parent.Index;
                int slideIdx = treeViewContents.SelectedNode.Index;

                sng.Parts[partIdx].Slides[slideIdx].TranslationText = textBoxSongTranslation.Text;
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
                sng.Themes.Add(checkedListBoxTags.Items[e.Index].ToString());
            }
            else
            {
                sng.Themes.Remove(checkedListBoxTags.Items[e.Index].ToString());
            }
        }

        public void save()
        {
            if (songFilename == null)
            {
                saveAs();
            }
            else
            {
                try
                {
                    SongFileWriterFactory.Instance.CreateFactoryByFile(songFilename).Save(songFilename, sng);

                    hashCode = sng.GetHashCode();
                    ((SongEditor)MdiParent).setStatus("Lied gespeichert als " + songFilename + "");

                    SongManager.Instance.ReloadSongByPath(songFilename);
                }
                catch (NotImplementedException)
                {
                    MessageBox.Show("Das Lied kann leider nicht in diesem Format gespeichert werden! Bitte wähle ein anderes Dateiformat!", "Format nicht unterstüzt!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    saveAs();
                }
            }
        }

        public void saveAs()
        {
            sng.Title = textBoxSongTitle.Text;

            if (sng.Title == Pbp.Properties.Settings.Default.SongDefaultName)
            {
                if (MessageBox.Show("Hat das Lied wirklich den Standardnamen '" + sng.Title + "'?", "Achtung", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    textBoxSongTitle.SelectAll();
                    textBoxSongTitle.Focus();
                    return;
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (songFilename != null)
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(songFilename);
            }
            else
            {
                saveFileDialog.InitialDirectory = ((SongEditor)MdiParent).fileBoxInitialDir;
            }
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.FileName = sng.Title;
            saveFileDialog.Filter = SongFileWriterFactory.Instance.GetFileBoxFilter();
            saveFileDialog.FilterIndex = ((SongEditor)MdiParent).fileSaveBoxFilterIndex;
            saveFileDialog.AddExtension = true;
            saveFileDialog.Title = Resources.Lied_speichern_unter___;

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                hashCode = sng.GetHashCode();
                try {
                    SongFileWriterFactory.Instance.CreateFactoryByTypeIndex(saveFileDialog.FilterIndex-1).Save(saveFileDialog.FileName, sng);
                    ((SongEditor)MdiParent).fileSaveBoxFilterIndex = saveFileDialog.FilterIndex;
                    ((SongEditor)MdiParent).setStatus("Lied gespeichert als " + saveFileDialog.FileName + "");
                }
                catch (NotImplementedException)
                {
                    MessageBox.Show("Dieses Dateiformat wird leider nicht unterstüzt!", "Liededitor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            SongManager.Instance.ReloadSongByPath(saveFileDialog.FileName);
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
            addContextMenu.Show(buttonAddItem.PointToScreen(new Point(0, buttonAddItem.Height - 1)));
        }

        private void previewSlide()
        {
            object[] songArgs = { currentPartId, currentSlideId };

            // TODO
            //pictureBoxPreview.Image = projWindow.showSlide(sng, sng.getImage(sng.Parts[currentPartId].Slides[currentSlideId].ImageNumber), songArgs, ProjectionMode.Simulate);
            pictureBoxPreview.Image = ImageManager.Instance.GetImage(sng.GetImage(sng.Parts[currentPartId].Slides[currentSlideId].ImageNumber));
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
            //TreeNode tn = treeViewContents.SelectedNode;
            //if (tn.Level > 1)
            e.CancelEdit = true;
        }

        private void treeViewContents_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            // --- Here we can transform edited label back to its original format ---
            /*
            TreeNode tn = treeViewContents.SelectedNode;
            if (tn.Level == 0)
            {
                tn.Text = e.Label;
                this.Text = e.Label;
            }
            else if (tn.Level == 1)
            {
                tn.Text = e.Label;
                sng.Parts[tn.Index].Caption = e.Label;
            }
            */
        }

        private void treeViewContents_ValidateLabelEdit(object sender, TreeEx.ValidateLabelEditEventArgs e)
        {
            /*
            if (e.Label.Trim() == "")
            {
                MessageBox.Show("The tree node label cannot be empty",
                    "Label Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            if (e.Label.IndexOfAny(new char[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' }) != -1)
            {
                MessageBox.Show("Invalid tree node label.\n" +
                    "The tree node label must not contain following characters:\n \\ / : * ? \" < > |",
                    "Label Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            */
            e.Cancel = true;
        }

        private void umbenennenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //treeViewContents.BeginEdit();
        }

        private void umbenennenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           // treeViewContents.BeginEdit();
        }

        private void löschenToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            buttonDelSongPart_Click(sender, e);
        }

        private void buttonAddSlide_Click(object sender, EventArgs e)
        {
            buttonAddNewSlide_Click(sender, e);
        }

        private void EditorChild_Shown(object sender, EventArgs e)
        {
            if (textBoxSongTitle.Text == Pbp.Properties.Settings.Default.SongDefaultName)
            {
                textBoxSongTitle.SelectAll();
                textBoxSongTitle.Focus();
            }
        }

        private void textBoxSongTitle_Enter(object sender, EventArgs e)
        {
            if (textBoxSongTitle.Text == Pbp.Properties.Settings.Default.SongDefaultName)
            {
                textBoxSongTitle.SelectAll();
            }
        }

        private void textBoxSongTitle_TextChanged(object sender, EventArgs e)
        {
            this.Text = textBoxSongTitle.Text;
        }

        private void textBoxPartCaption_TextChanged(object sender, EventArgs e)
        {
            int partId = -1;
            if (treeViewContents.SelectedNode.Level == 1)
            {
                partId = treeViewContents.SelectedNode.Parent.Index;
            }
            else if (treeViewContents.SelectedNode.Level == 0)
            {
                partId = treeViewContents.SelectedNode.Index;
            }
            if (partId >= 0)
            {
                treeViewContents.Nodes[partId].Text = textBoxPartCaption.Text;
            }
        }

    }
}