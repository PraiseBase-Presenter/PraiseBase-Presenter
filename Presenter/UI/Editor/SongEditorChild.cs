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
using PraiseBase.Presenter.Controls;
using PraiseBase.Presenter.Forms;
using PraiseBase.Presenter.Manager;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Projection;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Template;
using PraiseBase.Presenter.UI.Presenter;
using PraiseBase.Presenter.Util;

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

        /// <summary>
        /// Song template mapper instance
        /// </summary>
        readonly SongTemplateMapper _templateMapper;

        private readonly ImageManager _imgManager;

        private readonly ISlideTextFormattingMapper<Song> _previewFormattingMapper = new SongSlideTextFormattingMapper();

        public SongEditorChild(Settings settings, ImageManager imgManager, Song sng)
        {
            _settings = settings;
            _imgManager = imgManager;
            _templateMapper = new SongTemplateMapper(_settings);
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
            textBoxRightsManagement.DataBindings.Add("Text", Song, "RightsManagement");
            textBoxPublisher.DataBindings.Add("Text", Song, "Publisher");

            labelGUID.Text = Song.Guid != Guid.Empty ? Song.Guid.ToString() : "";

            textBoxAuthors.Text = Song.Author.ToString();
            textBoxSongbooks.Text = Song.SongBooks.ToString();

            PopulateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[0];

            PopulatePartList();

            PopulateQa();

            PopulateLanguageBox();
            PopulateTags();

            // Preview
            PreviewSlide();
        }

        private void PopulateQa()
        {
            textBoxComment.DataBindings.Add("Text", Song, "Comment");
            checkBoxQASpelling.Checked = Song.QualityIssues.Contains(SongQualityAssuranceIndicator.Spelling);
            checkBoxQATranslation.Checked = Song.QualityIssues.Contains(SongQualityAssuranceIndicator.Translation);
            checkBoxQAImages.Checked = Song.QualityIssues.Contains(SongQualityAssuranceIndicator.Images);
            checkBoxQASegmentation.Checked = Song.QualityIssues.Contains(SongQualityAssuranceIndicator.Segmentation);
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
                    AddSongPartUpdateTree(res);
            }
        }

        private void addSongPartFormokButton_Click(object sender, EventArgs e)
        {
            ((Form)((Button)sender).Parent).DialogResult = DialogResult.OK;
            ((Form)((Button)sender).Parent).Close();
        }

        public void partAddMenu_click(object sender, EventArgs e)
        {
            AddSongPartUpdateTree(((ToolStripMenuItem)sender).Text);
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

        private void AddSongPartUpdateTree(string caption)
        {
            var newPart = _templateMapper.AddSongPart(Song, caption);
            Song.PartSequence.Add(newPart);
            PopulateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[treeViewContents.Nodes.Count - 1].LastNode;
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Song.Language = comboBoxLanguage.Text;
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private void buttonAddNewSlide_Click(object sender, EventArgs e)
        {
            _templateMapper.AddSongSlide(Song.Parts[_currentPartId]);
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
            Song.QualityIssues.Set(SongQualityAssuranceIndicator.Spelling, checkBoxQASpelling.Checked);
        }

        private void checkBoxQATranslation_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxQATranslation.ForeColor = checkBoxQATranslation.Checked ? Color.Red : SystemColors.ControlText;
            Song.QualityIssues.Set(SongQualityAssuranceIndicator.Translation, checkBoxQATranslation.Checked);
        }

        private void checkBoxQAImages_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxQAImages.ForeColor = checkBoxQAImages.Checked ? Color.Red : SystemColors.ControlText;
            Song.QualityIssues.Set(SongQualityAssuranceIndicator.Images, checkBoxQAImages.Checked);
        }

        private void checkBoxQASegmentation_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxQASegmentation.ForeColor = checkBoxQASegmentation.Checked ? Color.Red : SystemColors.ControlText;
            Song.QualityIssues.Set(SongQualityAssuranceIndicator.Segmentation, checkBoxQASegmentation.Checked);
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
                    SongPart p = Song.Parts[partId];
                    for (var i = Song.PartSequence.Count - 1; i >= 0; i--)
                    {
                        if (Equals(p, Song.PartSequence[i]))
                        {
                            Song.PartSequence.RemoveAt(i);
                        }
                    }
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
            ImageDialog imd = new ImageDialog(_imgManager)
            {
                Background = Song.Parts[_currentPartId].Slides[_currentSlideId].Background
            };

            if (Song.GetNumberOfBackgroundImages() == 0)
            {
                imd.UseForAll = true;
            }

            if (imd.ShowDialog(this) == DialogResult.OK)
            {
                if (imd.Background != null)
                {
                    if (imd.UseForAll)
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
                    if (imd.UseForAll)
                    {
                        foreach (SongPart t in Song.Parts)
                        {
                            foreach (SongSlide t1 in t.Slides)
                            {
                                t1.Background = _templateMapper.GetDefaultBackground();
                            }
                        }
                    }
                    else
                    {
                        Song.Parts[_currentPartId].Slides[_currentSlideId].Background = _templateMapper.GetDefaultBackground(); 
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

            _previewFormattingMapper.Map(Song, ref slideFormatting);

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

            ImageLayer il = new ImageLayer(_settings.ProjectionBackColor);

            IBackground bg = Song.Parts[_currentPartId].Slides[_currentSlideId].Background;
            il.Image = _imgManager.GetImage(bg);

            var bmp = new Bitmap(1024, 768);
            Graphics gr = Graphics.FromImage(bmp);
            gr.CompositingQuality = CompositingQuality.HighSpeed;
            gr.SmoothingMode = SmoothingMode.HighSpeed;

            il.WriteOut(gr, null);
            sl.WriteOut(gr, null);

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