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
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PraiseBase.Presenter.Model;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Projection;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.UI.Presenter;
using TreeEx;

namespace PraiseBase.Presenter.UI.Editor
{
    public partial class SongEditorChild : Form
    {
        public Song Song { get; protected set; }

        /// <summary>
        /// Index of currently selected part
        /// </summary>
        private int _currentPartId;

        /// <summary>
        /// Index of currently selected slide
        /// </summary>
        private int _currentSlideId;

        /// <summary>
        /// Settings instance holder
        /// </summary>
        private readonly Settings _settings;

        public SongEditorChild(Settings settings, Song sng)
        {
            _settings = settings;
            Song = sng;

            InitializeComponent();
        }

        private void EditorChild_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            // Set window title
            Text = Song.Title;

            // Data bindings
            textBoxSongTitle.DataBindings.Add("Text", Song, "Title");
            textBoxCCLISongID.DataBindings.Add("Text", Song, "CcliIdentifier");
            if (Song.IsCCliIdentifierReadonly)
            {
                textBoxCCLISongID.ReadOnly = true;
            }
            textBoxCopyright.DataBindings.Add("Text", Song, "Copyright");
            textBoxComment.DataBindings.Add("Text", Song, "Comment");
            textBoxRightsManagement.DataBindings.Add("Text", Song, "RightsManagement");
            textBoxPublisher.DataBindings.Add("Text", Song, "Publisher");

            labelGUID.DataBindings.Add("Text", Song, "GUID");

            textBoxAuthors.Text = Song.Author.ToString();
            textBoxSongbooks.Text = Song.SongBooks.ToString();

            PopulateEffects();

            PopulateSpacing();

            PopulateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[0];

            PopulatePartList();

            PopulateQa();

            buttonChooseProjectionForeColor.BackColor = Song.MainText.Color;
            buttonTranslationColor.BackColor = Song.TranslationText.Color;

            PopulateOrientation();
            PopulateLanguageBox();
            PopulateTags();

            // Preview
            PreviewSlide();
        }

        private void PopulateEffects()
        {
            checkBoxOutlineEnabled.DataBindings.Add("Checked", Song, "TextOutlineEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxShadowEnabled.DataBindings.Add("Checked", Song, "TextShadowEnabled", false, DataSourceUpdateMode.OnPropertyChanged);

            numericUpDownShadowDirection.DataBindings.Add("Value", Song.MainText.Shadow, "Direction", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void PopulateSpacing()
        {
            numericUpDownMainTextLineSpacing.DataBindings.Add("Value", Song.MainText, "LineSpacing", false, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDownMainTextOutline.DataBindings.Add("Value", Song.MainText.Outline, "Width", false, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDownMainTextShadow.DataBindings.Add("Value", Song.MainText.Shadow, "Distance", false, DataSourceUpdateMode.OnPropertyChanged);

            numericUpDownTranslationTextLineSpacing.DataBindings.Add("Value", Song.TranslationText, "LineSpacing", false, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDownTranslationTextOutline.DataBindings.Add("Value", Song.TranslationText.Outline, "Width", false, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDownTranslationTextShadow.DataBindings.Add("Value", Song.TranslationText.Shadow, "Distance", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void PopulateQa()
        {
            checkBoxQAImages.Checked = Song.HasQuailityIssue(SongQualityAssuranceIndicator.Images);
            checkBoxQASpelling.Checked = Song.HasQuailityIssue(SongQualityAssuranceIndicator.Spelling);
            checkBoxQATranslation.Checked = Song.HasQuailityIssue(SongQualityAssuranceIndicator.Translation);
            checkBoxQASegmentation.Checked = Song.HasQuailityIssue(SongQualityAssuranceIndicator.Segmentation);
        }

        private void PopulateOrientation()
        {
            comboBoxSlideHorizOrientation.DataSource = Enum.GetValues(typeof(HorizontalOrientation));
            comboBoxSlideHorizOrientation.DataBindings.Add("SelectedItem", Song.TextOrientation, "Horizontal", false, DataSourceUpdateMode.OnPropertyChanged);

            comboBoxSlideVertOrientation.DataSource = Enum.GetValues(typeof(VerticalOrientation));
            comboBoxSlideVertOrientation.DataBindings.Add("SelectedItem", Song.TextOrientation, "Vertical", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void PopulateLanguageBox()
        {
            comboBoxLanguage.Items.Clear();
            comboBoxLanguage.Text = Song.Language;
            comboBoxLanguage.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxLanguage.AutoCompleteSource = AutoCompleteSource.ListItems;
            foreach (string str in _settings.Languages)
            {
                comboBoxLanguage.Items.Add(str);
            }
        }

        private void PopulateTags()
        {
            checkedListBoxTags.Items.Clear();
            foreach (string str in _settings.Tags)
            {
                if (Song.Themes.Contains(str))
                    checkedListBoxTags.Items.Add(str, true);
                else
                    checkedListBoxTags.Items.Add(str);
            }
        }

        private void PopulatePartList()
        {
            foreach (string str in _settings.SongParts)
            {
                ToolStripMenuItem tItem = new ToolStripMenuItem(str);
                tItem.Click += partAddMenu_click;
                addContextMenu.Items.Add(tItem);
            }
            addContextMenu.Items.Add(new ToolStripSeparator());
            ToolStripMenuItem oItem = new ToolStripMenuItem(StringResources.OtherName + "...");
            oItem.Click += partAddMenuOther_click;
            addContextMenu.Items.Add(oItem);
        }

        public void partAddMenuOther_click(object sender, EventArgs e)
        {
            TextBox iTBox = new TextBox
            {
                Location = new Point(5, 5), 
                Width = 300, 
                Name = "songPartText"
            };
            iTBox.Font = new Font(iTBox.Font.FontFamily, 12);

            Button okButton = new Button
            {
                Text = StringResources.Add, 
                Location = new Point(310, 5), 
                Name = "okButton"
            };
            okButton.Click += addSongPartFormokButton_Click;

            Button cancelButton = new Button
            {
                Text = StringResources.Cancel,
                Location = new Point(310 + okButton.Width + 5, 5),
                Name = "cancelButton"
            };

            Form iForm = new Form
            {
                Width = cancelButton.Right + 15,
                Height = 60,
                Text = StringResources.NameOfTheSongPart,
                ShowInTaskbar = false,
                ControlBox = false,
                AcceptButton = okButton,
                CancelButton = cancelButton,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent
            };

            iForm.Controls.Add(iTBox);
            iForm.Controls.Add(okButton);
            iForm.Controls.Add(cancelButton);

            iForm.ShowDialog(this);
            if (iForm.DialogResult == DialogResult.OK)
            {
                Control[] textField = iForm.Controls.Find("songPartText", true);
                string res = ((TextBox)textField[0]).Text.Trim();
                if (res != "")
                    AddSongPart(res);
            }
        }

        private void addSongPartFormokButton_Click(object sender, EventArgs e)
        {
            ((Form)((Button)sender).Parent).DialogResult = DialogResult.OK;
            ((Form)((Button)sender).Parent).Close();
        }

        public void partAddMenu_click(object sender, EventArgs e)
        {
            AddSongPart(((ToolStripMenuItem)sender).Text);
        }

        public void PopulateTree()
        {
            treeViewContents.Nodes.Clear();
            foreach (SongPart part in Song.Parts)
            {
                TreeNode partNode = new TreeNode(part.Caption);
                for (int i = 0; i < part.Slides.Count; i++)
                {
                    TreeNode slideNode = new TreeNode(StringResources.Slide + " " + (i + 1))
                    {
                        ContextMenuStrip = slideContextMenu
                    };
                    partNode.Nodes.Add(slideNode);
                }
                partNode.ContextMenuStrip = partContextMenu;
                treeViewContents.Nodes.Add(partNode);
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

                buttonDelItem.Enabled = Song.Parts[partId].Slides.Count > 1;
                buttonMoveDown.Enabled = slideId < Song.Parts[partId].Slides.Count - 1;
                buttonMoveUp.Enabled = slideId > 0;

                buttonDuplicateSlide.Enabled = true;
            }
            else if (treeViewContents.SelectedNode.Level == 0)
            {
                partId = treeViewContents.SelectedNode.Index;

                buttonDelItem.Enabled = Song.Parts.Count > 1;
                buttonMoveDown.Enabled = partId < Song.Parts.Count - 1;
                buttonMoveUp.Enabled = partId > 0;

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
                partId = _currentPartId;
            if (slideId < 0)
                slideId = _currentSlideId;

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

            _currentPartId = partId;
            _currentSlideId = slideId;

            PreviewSlide();
        }

        private void AddSongPart(string caption)
        {
            SongPart prt = new SongPart
            {
                Caption = caption
            };
            SongSlide sld = new SongSlide
            {
                Background = GetDefaultBackground()
            };

            prt.Slides.Add(sld);
            Song.Parts.Add(prt);

            PopulateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[treeViewContents.Nodes.Count - 1].LastNode;
        }

        private ColorBackground GetDefaultBackground()
        {
            // TODO: Configurable default color
            return new ColorBackground(Color.Black);
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Song.Language = comboBoxLanguage.Text;
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private void buttonAddNewSlide_Click(object sender, EventArgs e)
        {
            SongSlide sld = new SongSlide
            {
                Background = GetDefaultBackground()
            };
            Song.Parts[_currentPartId].Slides.Add(sld);
            PopulateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[_currentPartId].LastNode;
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
                        PopulateTree();
                        treeViewContents.SelectedNode = treeViewContents.Nodes[partId].Nodes[slideId - 1];
                    }
                }
                else if (treeViewContents.SelectedNode.Level == 0)
                {
                    int partId = treeViewContents.SelectedNode.Index;
                    if (Song.Parts.SwapWithUpper(partId))
                    {
                        PopulateTree();
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
                        PopulateTree();
                        treeViewContents.SelectedNode = treeViewContents.Nodes[partId].Nodes[slideId + 1];
                    }
                }
                else if (treeViewContents.SelectedNode.Level == 0)
                {
                    int partId = treeViewContents.SelectedNode.Index;
                    if (Song.Parts.SwapWithLower(partId))
                    {
                        PopulateTree();
                        treeViewContents.SelectedNode = treeViewContents.Nodes[partId + 1];
                    }
                }
            }
        }

        private void checkBoxQASpelling_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxQASpelling.ForeColor = checkBoxQASpelling.Checked ? Color.Red : SystemColors.ControlText;
            Song.SetQualityIssue(SongQualityAssuranceIndicator.Spelling, checkBoxQASpelling.Checked);
        }

        private void checkBoxQATranslation_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxQATranslation.ForeColor = checkBoxQATranslation.Checked ? Color.Red : SystemColors.ControlText;
            Song.SetQualityIssue(SongQualityAssuranceIndicator.Translation, checkBoxQATranslation.Checked);
        }

        private void checkBoxQAImages_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxQAImages.ForeColor = checkBoxQAImages.Checked ? Color.Red : SystemColors.ControlText;
            Song.SetQualityIssue(SongQualityAssuranceIndicator.Images, checkBoxQAImages.Checked);
        }

        private void checkBoxQASegmentation_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxQASegmentation.ForeColor = checkBoxQASegmentation.Checked ? Color.Red : SystemColors.ControlText;
            Song.SetQualityIssue(SongQualityAssuranceIndicator.Segmentation, checkBoxQASegmentation.Checked);
        }

        private void buttonProjectionMasterFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog
            {
                Font = Song.MainText.Font
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Song.MainText.Font = dlg.Font;
                PreviewSlide();
            }
        }

        private void buttonTranslationFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog
            {
                Font = Song.TranslationText.Font
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Song.TranslationText.Font = dlg.Font;
                PreviewSlide();
            }
        }

        private void buttonChooseProjectionForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog
            {
                Color = Song.MainText.Color
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Song.MainText.Color = dlg.Color;
                buttonChooseProjectionForeColor.BackColor = Song.MainText.Color;
                PreviewSlide();
            }
        }

        private void buttonTranslationColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog
            {
                Color = Song.TranslationText.Color
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Song.TranslationText.Color = dlg.Color;
                buttonTranslationColor.BackColor = Song.TranslationText.Color;
                PreviewSlide();
            }
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private void buttonDelSlide_Click(object sender, EventArgs e)
        {
            if (Song.Parts[_currentPartId].Slides.Count > 1)
            {
                if (MessageBox.Show(StringResources.ReallyDeleteSlide, StringResources.SongEditor, 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int slideId = treeViewContents.SelectedNode.Index;
                    Song.Parts[_currentPartId].Slides.RemoveAt(slideId);
                    PopulateTree();
                    _currentSlideId = Math.Max(0, slideId - 1);
                    treeViewContents.SelectedNode = treeViewContents.Nodes[_currentPartId].Nodes[_currentSlideId];
                }
            }
            else
            {
                MessageBox.Show(StringResources.SongPartsNeedsAtLeastOneSlide, StringResources.SongEditor, 
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private void buttonDelSongPart_Click(object sender, EventArgs e)
        {
            if (Song.Parts.Count > 1)
            {
                if (MessageBox.Show(StringResources.ReallyDeleteSongPart, StringResources.SongEditor, 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int partId = treeViewContents.SelectedNode.Index;
                    Song.Parts.RemoveAt(partId);
                    PopulateTree();
                    treeViewContents.SelectedNode = treeViewContents.Nodes[0];
                }
            }
            else
            {
                MessageBox.Show(StringResources.SongNeedsAtLeastOneSongPart, StringResources.SongEditor, 
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonSlideDuplicate_Click(object sender, EventArgs e)
        {
            Song.Parts[_currentPartId].Slides.Duplicate(_currentSlideId);
            PopulateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[_currentPartId].Nodes[_currentSlideId];
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private void buttonSlideSeparate_Click(object sender, EventArgs e)
        {
            Song.Parts[_currentPartId].Slides.Split(_currentSlideId);
            PopulateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[_currentPartId].Nodes[_currentSlideId];
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
            ImageDialog imd = new ImageDialog
            {
                Background = Song.Parts[_currentPartId].Slides[_currentSlideId].Background
            };

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
                        foreach (SongPart t in Song.Parts)
                        {
                            foreach (SongSlide t1 in t.Slides)
                            {
                                t1.Background = imd.Background;
                            }
                        }
                    }
                    else
                    {
                        Song.Parts[_currentPartId].Slides[_currentSlideId].Background = imd.Background;
                    }
                }
                else
                {
                    if (imd.forAll)
                    {
                        foreach (SongPart t in Song.Parts)
                        {
                            foreach (SongSlide t1 in t.Slides)
                            {
                                t1.Background = GetDefaultBackground();
                            }
                        }
                    }
                    else
                    {
                        Song.Parts[_currentPartId].Slides[_currentSlideId].Background = GetDefaultBackground(); 
                    }
                }
                PreviewSlide();
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

        private void PreviewSlide()
        {
            SongSlide slide = (SongSlide)Song.Parts[_currentPartId].Slides[_currentSlideId].Clone();
            slide.Text = textBoxSongText.Text;
            slide.TranslationText = textBoxSongTranslation.Text;
            SlideTextFormatting slideFormatting = new SlideTextFormatting();

            SongSlideTextFormattingMapper.Map(Song, ref slideFormatting);

            // Disabled for performance
            slideFormatting.OutlineEnabled = false;
            slideFormatting.SmoothShadow = false;

            slideFormatting.ScaleFontSize = _settings.ProjectionFontScaling;
            slideFormatting.SmoothShadow = false;

            TextLayer sl = new TextLayer(slideFormatting)
            {
                MainText = slide.Lines.ToArray(),
                SubText = slide.Translation.ToArray()
            };

            ImageLayer il = new ImageLayer();

            IBackground bg = Song.Parts[_currentPartId].Slides[_currentSlideId].Background;
            il.Image = ImageManager.Instance.GetImage(bg);

            var bmp = new Bitmap(1024, 768);
            Graphics gr = Graphics.FromImage(bmp);
            gr.CompositingQuality = CompositingQuality.HighSpeed;
            gr.SmoothingMode = SmoothingMode.HighSpeed;

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

        private void treeViewContents_ValidateLabelEdit(object sender, ValidateLabelEditEventArgs e)
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
            if (textBoxSongTitle.Text == _settings.SongDefaultName)
            {
                textBoxSongTitle.SelectAll();
                textBoxSongTitle.Focus();
            }
        }

        private void textBoxSongTitle_Enter(object sender, EventArgs e)
        {
            if (textBoxSongTitle.Text == _settings.SongDefaultName)
            {
                textBoxSongTitle.SelectAll();
            }
        }

        private void textBoxSongTitle_TextChanged(object sender, EventArgs e)
        {
            Text = textBoxSongTitle.Text;
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
            pictureBoxPreview.Left = panelPreview.Width / 2 - (pictureBoxPreview.Width/2);
        }

        private void textBoxSongText_KeyUp(object sender, KeyEventArgs e)
        {
            PreviewSlide();
        }

        private void textBoxSongTranslation_KeyUp(object sender, KeyEventArgs e)
        {
            PreviewSlide();
        }

        private void numericUpDownMainTextLineSpacing_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownMainTextLineSpacing.DataBindings.Count > 0)
            {
                numericUpDownMainTextLineSpacing.DataBindings[0].WriteValue();
            }
            PreviewSlide();
        }

        private void numericUpDownTranslationTextLineSpacing_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownTranslationTextLineSpacing.DataBindings.Count > 0)
            {
                numericUpDownTranslationTextLineSpacing.DataBindings[0].WriteValue();
            }
            PreviewSlide();
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

        private void comboBoxSlideHorizOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSlideHorizOrientation.DataBindings.Count > 0) 
            {
                comboBoxSlideHorizOrientation.DataBindings[0].WriteValue();
            }
            PreviewSlide();
        }

        private void comboBoxSlideVertOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSlideVertOrientation.DataBindings.Count > 0)
            {
                comboBoxSlideVertOrientation.DataBindings[0].WriteValue();
            }
            PreviewSlide();
        }

        private void textBoxAuthors_TextChanged(object sender, EventArgs e)
        {
            Song.Author.FromString(((TextBox)sender).Text);
        }

        private void textBoxSongbooks_TextChanged(object sender, EventArgs e)
        {
            Song.SongBooks.FromString(((TextBox)sender).Text);
        }

    }
}