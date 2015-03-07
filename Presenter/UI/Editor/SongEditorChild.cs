/*
 *   PraiseBase Presenter
 *   The open source lyrics and image projection software for churches
 *
 *   http://praisebase.org
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
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Persistence;
using PraiseBase.Presenter.Projection;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Util;

namespace PraiseBase.Presenter.Forms
{
    public partial class SongEditorChild : Form
    {
        public Song Song { get; protected set; }

        private int currentPartId = 0;
        private int currentSlideId = 0;

        public SongEditorChild(Song sng)
        {
            this.Song = sng;

            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

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
            textBoxAuthors.DataBindings.Add("Text", sng, "AuthorString");
            textBoxSongbooks.DataBindings.Add("Text", sng, "SongBooksString");

            checkBoxOutlineEnabled.DataBindings.Add("Checked", sng, "TextOutlineEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxShadowEnabled.DataBindings.Add("Checked", sng, "TextShadowEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            
            numericUpDownShadowDirection.DataBindings.Add("Value", sng.MainText.Shadow, "Direction", false, DataSourceUpdateMode.OnPropertyChanged);

            numericUpDownMainTextLineSpacing.DataBindings.Add("Value", sng.MainText, "LineSpacing", false, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDownMainTextOutline.DataBindings.Add("Value", sng.MainText.Outline, "Width", false, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDownMainTextShadow.DataBindings.Add("Value", sng.MainText.Shadow, "Distance", false, DataSourceUpdateMode.OnPropertyChanged);

            numericUpDownTranslationTextLineSpacing.DataBindings.Add("Value", sng.TranslationText, "LineSpacing", false, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDownTranslationTextOutline.DataBindings.Add("Value", sng.TranslationText.Outline, "Width", false, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDownTranslationTextShadow.DataBindings.Add("Value", sng.TranslationText.Shadow, "Distance", false, DataSourceUpdateMode.OnPropertyChanged);

            populateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[0];

            populatePartList();

            checkBoxQAImages.Checked = sng.GetQA(SongQualityAssuranceIndicator.Images);
            checkBoxQASpelling.Checked = sng.GetQA(SongQualityAssuranceIndicator.Spelling);
            checkBoxQATranslation.Checked = sng.GetQA(SongQualityAssuranceIndicator.Translation);
            checkBoxQASegmentation.Checked = sng.GetQA(SongQualityAssuranceIndicator.Segmentation);

            buttonChooseProjectionForeColor.BackColor = sng.MainText.Color;
            buttonTranslationColor.BackColor = sng.TranslationText.Color;

            comboBoxSlideHorizOrientation.DataSource = Enum.GetValues(typeof(HorizontalOrientation));
            comboBoxSlideHorizOrientation.DataBindings.Add("SelectedItem", sng.TextOrientation, "Horizontal", false, DataSourceUpdateMode.OnPropertyChanged);

            comboBoxSlideVertOrientation.DataSource = Enum.GetValues(typeof(VerticalOrientation));
            comboBoxSlideVertOrientation.DataBindings.Add("SelectedItem", sng.TextOrientation, "Vertical", false, DataSourceUpdateMode.OnPropertyChanged);

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

        protected String getFontNameString(Font f) 
        {
            return f.Name + ", " + f.Style.ToString() + ", " + f.Size.ToString();
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
            ToolStripMenuItem oItem = new ToolStripMenuItem(Properties.StringResources.OtherName + "...");
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
            okButton.Text = Properties.StringResources.Add;
            okButton.Location = new Point(310, 5);
            okButton.Name = "okButton";
            okButton.Click += new EventHandler(addSongPartFormokButton_Click);

            Button cancelButton = new Button();
            cancelButton.Text = Properties.StringResources.Cancel;
            cancelButton.Location = new Point(310 + okButton.Width + 5, 5);
            cancelButton.Name = "cancelButton";

            Form iForm = new Form();
            iForm.Width = cancelButton.Right + 15;
            iForm.Height = 60;
            iForm.Text = Properties.StringResources.NameOfTheSongPart;
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
            foreach (SongPart part in Song.Parts)
            {
                TreeNode partNode = new TreeNode(part.Caption);
                int i = 0;
                foreach (SongSlide slide in part.Slides)
                {
                    TreeNode slideNode = new TreeNode(Properties.StringResources.Slide + " " + (i + 1).ToString());
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

                if (Song.Parts[partId].Slides.Count > 1)
                    buttonDelItem.Enabled = true;
                else
                    buttonDelItem.Enabled = false;
                if (slideId < Song.Parts[partId].Slides.Count - 1)
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

                if (Song.Parts.Count > 1)
                    buttonDelItem.Enabled = true;
                else
                    buttonDelItem.Enabled = false;
                if (partId < Song.Parts.Count - 1)
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

            if (partId >= Song.Parts.Count)
                partId = Song.Parts.Count - 1;
            if (slideId >= Song.Parts[partId].Slides.Count)
                slideId = Song.Parts[partId].Slides.Count-1;

            textBoxPartCaption.DataBindings.Clear();
            textBoxPartCaption.DataBindings.Add("Text", Song.Parts[partId], "Caption");

            SongSlide sld = Song.Parts[partId].Slides[slideId];
            textBoxSongText.DataBindings.Clear();
            textBoxSongText.DataBindings.Add("Text", sld, "Text");

            textBoxSongTranslation.DataBindings.Clear();
            textBoxSongTranslation.DataBindings.Add("Text", sld, "TranslationText");

            currentPartId = partId;
            currentSlideId = slideId;

            previewSlide();
        }

        private void addSongPart(string caption)
        {
            SongPart prt = new SongPart();
            prt.Caption = caption;
            SongSlide sld = new SongSlide();
            sld.Background = getDefaultBackground();

            prt.Slides.Add(sld);
            Song.Parts.Add(prt);

            populateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[treeViewContents.Nodes.Count - 1].LastNode;
        }

        private ColorBackground getDefaultBackground()
        {
            // TODO: Configurable default color
            return new ColorBackground(Color.Black);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            populateTree();
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Song.Language = comboBoxLanguage.Text;
        }

        private void EditorChild_Load(object sender, EventArgs e)
        {
            previewSlide();
        }

        private void buttonAddNewSlide_Click(object sender, EventArgs e)
        {
            SongSlide sld = new SongSlide();
            Song.Parts[currentPartId].Slides.Add(sld);
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
                    if (Song.Parts[partId].Slides.SwapWithUpper(slideId))
                    {
                        populateTree();
                        treeViewContents.SelectedNode = treeViewContents.Nodes[partId].Nodes[slideId - 1];
                    }
                }
                else if (treeViewContents.SelectedNode.Level == 0)
                {
                    int partId = treeViewContents.SelectedNode.Index;
                    if (Song.Parts.SwapWithUpper(partId))
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
                    if (Song.Parts[partId].Slides.SwapWithLower(slideId))
                    {
                        populateTree();
                        treeViewContents.SelectedNode = treeViewContents.Nodes[partId].Nodes[slideId + 1];
                    }
                }
                else if (treeViewContents.SelectedNode.Level == 0)
                {
                    int partId = treeViewContents.SelectedNode.Index;
                    if (Song.Parts.SwapWithLower(partId))
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
                Song.SetQA(SongQualityAssuranceIndicator.Spelling);
            }
            else
            {
                checkBoxQASpelling.ForeColor = SystemColors.ControlText;
                Song.RemQA(SongQualityAssuranceIndicator.Spelling);
            }
        }

        private void checkBoxQATranslation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQATranslation.Checked)
            {
                checkBoxQATranslation.ForeColor = Color.Red;
                Song.SetQA(SongQualityAssuranceIndicator.Translation);
            }
            else
            {
                checkBoxQATranslation.ForeColor = SystemColors.ControlText;
                Song.RemQA(SongQualityAssuranceIndicator.Translation);
            }
        }

        private void checkBoxQAImages_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQAImages.Checked)
            {
                checkBoxQAImages.ForeColor = Color.Red;
                Song.SetQA(SongQualityAssuranceIndicator.Images);
            }
            else
            {
                checkBoxQAImages.ForeColor = SystemColors.ControlText;
                Song.RemQA(SongQualityAssuranceIndicator.Images);
            }
        }

        private void checkBoxQASegmentation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQASegmentation.Checked)
            {
                checkBoxQASegmentation.ForeColor = Color.Red;
                Song.SetQA(SongQualityAssuranceIndicator.Segmentation);
            }
            else
            {
                checkBoxQASegmentation.ForeColor = SystemColors.ControlText;
                Song.RemQA(SongQualityAssuranceIndicator.Segmentation);
            }
        }

        private void comboBoxSlideHorizOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            previewSlide();
        }

        private void comboBoxSlideVertOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            previewSlide();
        }

        private void buttonProjectionMasterFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.Font = Song.MainText.Font;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Song.MainText.Font = dlg.Font;
                previewSlide();
            }
        }

        private void buttonTranslationFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.Font = Song.TranslationText.Font;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Song.TranslationText.Font = dlg.Font;
                previewSlide();
            }
        }

        private void buttonChooseProjectionForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = Song.MainText.Color;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Song.MainText.Color = dlg.Color;
                buttonChooseProjectionForeColor.BackColor = Song.MainText.Color;
                previewSlide();
            }
        }

        private void buttonTranslationColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = Song.TranslationText.Color;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Song.TranslationText.Color = dlg.Color;
                buttonTranslationColor.BackColor = Song.TranslationText.Color;
                previewSlide();
            }
        }

        private void buttonDelSlide_Click(object sender, EventArgs e)
        {
            if (Song.Parts[currentPartId].Slides.Count > 1)
            {
                if (MessageBox.Show(Properties.StringResources.ReallyDeleteSlide, Properties.StringResources.SongEditor, 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int slideId = treeViewContents.SelectedNode.Index;
                    Song.Parts[currentPartId].Slides.RemoveAt(slideId);
                    populateTree();
                    currentSlideId = slideId - 1;
                    treeViewContents.SelectedNode = treeViewContents.Nodes[currentPartId].Nodes[currentSlideId];
                }
            }
            else
            {
                MessageBox.Show(Properties.StringResources.SongPartsNeedsAtLeastOneSlide, Properties.StringResources.SongEditor, 
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonDelSongPart_Click(object sender, EventArgs e)
        {
            if (Song.Parts.Count > 1)
            {
                if (MessageBox.Show(Properties.StringResources.ReallyDeleteSongPart, Properties.StringResources.SongEditor, 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int partId = treeViewContents.SelectedNode.Index;
                    Song.Parts.RemoveAt(partId);
                    populateTree();
                    treeViewContents.SelectedNode = treeViewContents.Nodes[0];
                }
            }
            else
            {
                MessageBox.Show(Properties.StringResources.SongNeedsAtLeastOneSongPart, Properties.StringResources.SongEditor, 
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonSlideDuplicate_Click(object sender, EventArgs e)
        {
            Song.Parts[currentPartId].Slides.Duplicate(currentSlideId);
            populateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[currentPartId].Nodes[currentSlideId];
        }

        private void buttonSlideSeparate_Click(object sender, EventArgs e)
        {
            Song.Parts[currentPartId].Slides.Split(currentSlideId);
            populateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[currentPartId].Nodes[currentSlideId];
        }

        private void textBoxSongTranslation_TextChanged(object sender, EventArgs e)
        {
            if (treeViewContents.SelectedNode.Level == 1)
            {
                int partIdx = treeViewContents.SelectedNode.Parent.Index;
                int slideIdx = treeViewContents.SelectedNode.Index;

                Song.Parts[partIdx].Slides[slideIdx].TranslationText = textBoxSongTranslation.Text;
            }
        }

        private void comboBoxLanguage_Enter(object sender, EventArgs e)
        {
            comboBoxLanguage.DroppedDown = true;
        }

        private void checkedListBoxTags_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                Song.Themes.Add(checkedListBoxTags.Items[e.Index].ToString());
            }
            else
            {
                Song.Themes.Remove(checkedListBoxTags.Items[e.Index].ToString());
            }
        }

        private void buttonSlideBackground_Click(object sender, EventArgs e)
        {
            ImageDialog imd = new ImageDialog();
            imd.Background = Song.Parts[currentPartId].Slides[currentSlideId].Background;

            if (Song.GetNumberOfBackgroundImages() == 0)
            {
                imd.forAll = true;
            }

            if (imd.ShowDialog(this) == DialogResult.OK)
            {
                if (imd.Background != null)
                {
                    if (imd.forAll)
                    {
                        for (int i = 0; i < Song.Parts.Count; i++)
                        {
                            for (int j = 0; j < Song.Parts[i].Slides.Count; j++)
                            {
                                Song.Parts[i].Slides[j].Background = imd.Background;
                            }
                        }
                    }
                    else
                    {
                        Song.Parts[currentPartId].Slides[currentSlideId].Background = imd.Background;
                    }
                }
                else
                {
                    if (imd.forAll)
                    {
                        for (int i = 0; i < Song.Parts.Count; i++)
                        {
                            for (int j = 0; j < Song.Parts[i].Slides.Count; j++)
                            {
                                Song.Parts[i].Slides[j].Background = getDefaultBackground();
                            }
                        }
                    }
                    else
                    {
                        Song.Parts[currentPartId].Slides[currentSlideId].Background = getDefaultBackground(); 
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
            SongSlide slide = (SongSlide)Song.Parts[currentPartId].Slides[currentSlideId].Clone();
            slide.Text = textBoxSongText.Text;
            slide.TranslationText = textBoxSongTranslation.Text;
            SlideTextFormatting slideFormatting = new SlideTextFormatting();

            SongSlideTextFormattingMapper.Map(Song, ref slideFormatting);

            // Disabled for performance
            slideFormatting.OutlineEnabled = false;
            slideFormatting.SmoothShadow = false;

            slideFormatting.ScaleFontSize = Settings.Default.ProjectionFontScaling;
            slideFormatting.SmoothShadow = false;

            TextLayer sl = new TextLayer(slideFormatting);
            sl.MainText = slide.Lines.ToArray();
            sl.SubText = slide.Translation.ToArray();

            ImageLayer il = new ImageLayer();

            IBackground bg = Song.Parts[currentPartId].Slides[currentSlideId].Background;
            il.Image = ImageManager.Instance.GetImage(bg);

            var bmp = new Bitmap(1024, 768);
            Graphics gr = Graphics.FromImage(bmp);
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            il.writeOut(gr, null);
            sl.writeOut(gr, null);

            pictureBoxPreview.Image = bmp;
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
            if (textBoxSongTitle.Text == PraiseBase.Presenter.Properties.Settings.Default.SongDefaultName)
            {
                textBoxSongTitle.SelectAll();
                textBoxSongTitle.Focus();
            }
        }

        private void textBoxSongTitle_Enter(object sender, EventArgs e)
        {
            if (textBoxSongTitle.Text == PraiseBase.Presenter.Properties.Settings.Default.SongDefaultName)
            {
                textBoxSongTitle.SelectAll();
            }
        }

        private void textBoxSongTitle_TextChanged(object sender, EventArgs e)
        {
            this.Text = textBoxSongTitle.Text;
            Song.Title = textBoxSongTitle.Text;
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

        private void panelPreview_Resize(object sender, EventArgs e)
        {
            pictureBoxPreview.Height = panelPreview.Height;
            pictureBoxPreview.Width = (int)Math.Floor(pictureBoxPreview.Height / 0.75);
            pictureBoxPreview.Top = 0;
            pictureBoxPreview.Left = (int)(panelPreview.Width / 2 - (pictureBoxPreview.Width/2));
        }

        private void textBoxSongText_KeyUp(object sender, KeyEventArgs e)
        {
            previewSlide();
        }

        private void textBoxSongTranslation_KeyUp(object sender, KeyEventArgs e)
        {
            previewSlide();
        }

        private void numericUpDownMainTextLineSpacing_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownMainTextLineSpacing.DataBindings.Count > 0)
            {
                numericUpDownMainTextLineSpacing.DataBindings[0].WriteValue();
            }
            previewSlide();
        }

        private void numericUpDownTranslationTextLineSpacing_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownTranslationTextLineSpacing.DataBindings.Count > 0)
            {
                numericUpDownTranslationTextLineSpacing.DataBindings[0].WriteValue();
            }
            previewSlide();
        }

        private void checkBoxOutlineEnabled_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMainTextOutline.Enabled = checkBoxOutlineEnabled.Checked;
            numericUpDownTranslationTextOutline.Enabled = checkBoxOutlineEnabled.Checked;
            label20.Enabled = checkBoxOutlineEnabled.Checked;
            label23.Enabled = checkBoxOutlineEnabled.Checked;
        }

        private void checkBoxShadowEnabled_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownMainTextShadow.Enabled = checkBoxShadowEnabled.Checked;
            numericUpDownTranslationTextShadow.Enabled = checkBoxShadowEnabled.Checked;
            numericUpDownShadowDirection.Enabled = checkBoxShadowEnabled.Checked;
            label21.Enabled = checkBoxShadowEnabled.Checked;
            label22.Enabled = checkBoxShadowEnabled.Checked;
            label24.Enabled = checkBoxShadowEnabled.Checked;
        }

        private void comboBoxSlideHorizOrientation_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxSlideHorizOrientation.DataBindings.Count > 0) 
            {
                comboBoxSlideHorizOrientation.DataBindings[0].WriteValue();
            }
            previewSlide();
        }

        private void comboBoxSlideVertOrientation_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxSlideVertOrientation.DataBindings.Count > 0)
            {
                comboBoxSlideVertOrientation.DataBindings[0].WriteValue();
            }
            previewSlide();
        }

    }
}