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
using PraiseBase.Presenter.Forms;
using PraiseBase.Presenter.Manager;
using PraiseBase.Presenter.Model.Song;
using PraiseBase.Presenter.Projection;
using PraiseBase.Presenter.Properties;
using PraiseBase.Presenter.Template;

namespace PraiseBase.Presenter.Editor
{
    public partial class SongEditorChild : Form
    {
        #region Public fields

        /// <summary>
        /// Gets the song being edited
        /// </summary>
        public Song Song { get; protected set; }

        #endregion

        #region Internal variables

        /// <summary>
        /// Index of currently selected part
        /// </summary>
        protected int CurrentPartId;

        /// <summary>
        /// Index of currently selected slide
        /// </summary>
        protected int CurrentSlideId;

        /// <summary>
        /// Settings instance holder
        /// </summary>
        protected readonly Settings Settings;

        /// <summary>
        /// Song template mapper instance
        /// </summary>
        protected SongTemplateMapper TemplateMapper;

        /// <summary>
        /// Image manager instance
        /// </summary>
        protected readonly ImageManager ImgManager;

        /// <summary>
        /// Slide text formatting mapper
        /// </summary>
        protected readonly ISlideTextFormattingMapper<Song> PreviewFormattingMapper = new SongSlideTextFormattingMapper();

        /// <summary>
        /// Display mode
        /// </summary>
        private SongStructureDisplayMode _inputMode = SongStructureDisplayMode.Structured;

        /// <summary>
        /// Textual song representation mappper
        /// </summary>
        private readonly TextualSongRepresentationMapper _textualSongReprMapper = new TextualSongRepresentationMapper();

        #endregion

        public SongEditorChild(Settings settings, ImageManager imgManager, Song sng)
        {
            Settings = settings;
            ImgManager = imgManager;
            TemplateMapper = new SongTemplateMapper(Settings);

            Song = sng;

            InitializeComponent();

            InputMode = SongStructureDisplayMode.Structured;
        }

        private void EditorChild_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            UpdateTranslationUi();

            // Set window title
            SetWindowTitle(Song.Title);

            // Data bindings
            textBoxSongTitle.DataBindings.Add("Text", Song, "Title");

            textBoxCCLISongID.DataBindings.Add("Text", Song, "CcliIdentifier");
            textBoxCopyright.DataBindings.Add("Text", Song, "Copyright");
            textBoxRightsManagement.DataBindings.Add("Text", Song, "RightsManagement");
            textBoxPublisher.DataBindings.Add("Text", Song, "Publisher");

            textBoxAuthors.Text = Song.Authors.ToString();
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

        public void SetWindowTitle(string title)
        {
            Text = title;
        }

        public void EnableTranslation(bool enable)
        {
            if (enable)
            {
                if (!Song.HasTranslation())
                {
                    Song.Parts[0].Slides[0].Translation.Add(String.Empty);
                }
            }
            else
            {
                if (Song.HasTranslation())
                {
                    if (MessageBox.Show(StringResources.SongEditorChild_EnableTranslation_Should_Translation_be_removed, 
                        StringResources.SongEditorChild_EnableTranslation_Disable_translation, 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                textBoxSongTranslation.Text = String.Empty;
                foreach (var p in Song.Parts)
                {
                    foreach (var s in p.Slides)
                    {
                        s.Translation.Clear();
                    }
                }
            }
            UpdateTranslationUi();
        }

        private void UpdateTranslationUi()
        {
            splitContainer1.Panel2Collapsed = !Song.HasTranslation();
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
            foreach (string str in Settings.Languages)
            {
                comboBoxLanguage.Items.Add(str);
            }
        }

        private void PopulateTags()
        {
            checkedListBoxThemes.Items.Clear();
            foreach (string str in Settings.Tags)
            {
                if (Song.Themes.Contains(str))
                    checkedListBoxThemes.Items.Add(str, true);
                else
                    checkedListBoxThemes.Items.Add(str);
            }
        }

        private void PopulatePartList()
        {
            foreach (string str in Settings.SongParts)
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
            InputDialog dlg = new InputDialog(StringResources.NameOfTheSongPart, StringResources.NameOfTheSongPart)
            {
                InputValue = String.Empty
            };
            dlg.ShowDialog(this);
            if (dlg.DialogResult == DialogResult.OK)
            {
                var v = dlg.InputValue.Trim();
                if (!String.IsNullOrEmpty(v))
                {
                    AddSongPartUpdateTree(v);
                }
            }
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
                partId = CurrentPartId;
            if (slideId < 0)
                slideId = CurrentSlideId;

            if (partId >= Song.Parts.Count)
                partId = Song.Parts.Count - 1;
            if (slideId >= Song.Parts[partId].Slides.Count)
                slideId = Song.Parts[partId].Slides.Count-1;

            SongSlide sld = Song.Parts[partId].Slides[slideId];
            textBoxSongText.DataBindings.Clear();
            textBoxSongText.DataBindings.Add("Text", sld, "Text");

            textBoxSongTranslation.DataBindings.Clear();
            textBoxSongTranslation.DataBindings.Add("Text", sld, "TranslationText");

            CurrentPartId = partId;
            CurrentSlideId = slideId;

            PreviewSlide();
        }
        
        private void treeViewContents_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeViewContents.SelectedNode = e.Node;
            }
        }

        private void AddSongPartUpdateTree(string caption)
        {
            var newPart = TemplateMapper.AddSongPart(Song, caption);
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
            TemplateMapper.AddSongSlide(Song.Parts[CurrentPartId]);
            PopulateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[CurrentPartId].LastNode;
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
            if (Song.Parts[CurrentPartId].Slides.Count > 1)
            {
                if (MessageBox.Show(StringResources.ReallyDeleteSlide, StringResources.SongEditor, 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int slideId = treeViewContents.SelectedNode.Index;
                    Song.Parts[CurrentPartId].Slides.RemoveAt(slideId);
                    PopulateTree();
                    CurrentSlideId = Math.Max(0, slideId - 1);
                    treeViewContents.SelectedNode = treeViewContents.Nodes[CurrentPartId].Nodes[CurrentSlideId];
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
            Song.Parts[CurrentPartId].Slides.Duplicate(CurrentSlideId);
            PopulateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[CurrentPartId].Nodes[CurrentSlideId];
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private void buttonSlideSeparate_Click(object sender, EventArgs e)
        {
            Song.Parts[CurrentPartId].Slides.Split(CurrentSlideId);
            PopulateTree();
            treeViewContents.SelectedNode = treeViewContents.Nodes[CurrentPartId].Nodes[CurrentSlideId];
        }

        private void comboBoxLanguage_Enter(object sender, EventArgs e)
        {
            comboBoxLanguage.DroppedDown = true;
        }

        private void checkedListBoxTags_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                Song.Themes.Add(checkedListBoxThemes.Items[e.Index].ToString());
            }
            else
            {
                Song.Themes.Remove(checkedListBoxThemes.Items[e.Index].ToString());
            }
        }

        private void buttonSlideBackground_Click(object sender, EventArgs e)
        {
            ImageDialog imd = new ImageDialog(ImgManager)
            {
                Background = Song.Parts[CurrentPartId].Slides[CurrentSlideId].Background
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
                        Song.Parts[CurrentPartId].Slides[CurrentSlideId].Background = imd.Background;
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
                                t1.Background = TemplateMapper.GetDefaultBackground();
                            }
                        }
                    }
                    else
                    {
                        Song.Parts[CurrentPartId].Slides[CurrentSlideId].Background = TemplateMapper.GetDefaultBackground(); 
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
            addContextMenu.Show(buttonAddItem.PointToScreen(new Point(0, -addContextMenu.Height)));
        }

        private void PreviewSlide()
        {
            pictureBoxPreview.Image = PreviewSlide(Song, textBoxSongText.Text, textBoxSongTranslation.Text);
        }

        protected Image PreviewSlide(Song sng, string currentText, string currentTranslationText)
        {
            SongSlide slide = (SongSlide) sng.Parts[CurrentPartId].Slides[CurrentSlideId].Clone();
            slide.Text = currentText;
            slide.TranslationText = currentTranslationText;
            SlideTextFormatting slideFormatting = new SlideTextFormatting();

            PreviewFormattingMapper.Map(sng, ref slideFormatting);

            // Disabled for performance
            slideFormatting.OutlineEnabled = false;
            slideFormatting.SmoothShadow = false;

            slideFormatting.ScaleFontSize = Settings.ProjectionFontScaling;
            slideFormatting.SmoothShadow = false;

            TextLayer sl = new TextLayer(slideFormatting)
            {
                MainText = slide.Lines.ToArray(),
                SubText = slide.Translation.ToArray()
            };

            ImageLayer il = new ImageLayer(Settings.ProjectionBackColor);

            IBackground bg = sng.Parts[CurrentPartId].Slides[CurrentSlideId].Background;
            il.Image = ImgManager.GetImage(bg);

            var bmp = new Bitmap(1024, 768);
            Graphics gr = Graphics.FromImage(bmp);
            gr.CompositingQuality = CompositingQuality.HighSpeed;
            gr.SmoothingMode = SmoothingMode.HighSpeed;

            il.WriteOut(gr, null);
            sl.WriteOut(gr, null);

            return bmp;
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
                    case Keys.Space:
                        treeViewContents.SelectedNode.Toggle();
                        break;
                    case Keys.F2:
                        RenameActiveNode();
                        break;
                }
        }

        private void umbenennenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameActiveNode();
        }

        private void RenameActiveNode()
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
                InputDialog dlg = new InputDialog(StringResources.NameOfTheSongPart, StringResources.NameOfTheSongPart)
                {
                    InputValue = Song.Parts[partId].Caption
                };
                dlg.ShowDialog(this);
                if (dlg.DialogResult == DialogResult.OK)
                {
                    var value = dlg.InputValue.Trim();
                    if (!String.IsNullOrEmpty(value))
                    {
                        treeViewContents.Nodes[partId].Text = value;
                        Song.Parts[partId].Caption = value;
                    }
                }
            }
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
            if (textBoxSongTitle.Text == Settings.SongDefaultName)
            {
                textBoxSongTitle.SelectAll();
                textBoxSongTitle.Focus();
            }
        }

        private void textBoxSongTitle_Enter(object sender, EventArgs e)
        {
            if (textBoxSongTitle.Text == Settings.SongDefaultName)
            {
                textBoxSongTitle.SelectAll();
            }
        }

        private void textBoxSongTitle_TextChanged(object sender, EventArgs e)
        {
            Text = textBoxSongTitle.Text;
            Song.Title = textBoxSongTitle.Text;
        }

        private void textBoxSongText_KeyUp(object sender, KeyEventArgs e)
        {
            // TODO: Implement preview respecting slide background and current text section
            // _textualSongReprMapper.Map(textBoxSongText.Text, Song);
            PreviewSlide();
        }

        private void textBoxSongTranslation_KeyUp(object sender, KeyEventArgs e)
        {
            // TODO: Translation mapping textBoxSongTranslation.Text
            // _textualSongReprMapper.Map(textBoxSongText.Text, Song);
            //PreviewSlide();
        }

        private void textBoxAuthors_TextChanged(object sender, EventArgs e)
        {
            Song.Authors.FromString(((TextBox)sender).Text);
        }

        private void textBoxSongbooks_TextChanged(object sender, EventArgs e)
        {
            Song.SongBooks.FromString(((TextBox)sender).Text);
        }

        public enum SongStructureDisplayMode
        {
            Structured,
            Textual
        }

        public SongStructureDisplayMode InputMode
        {
            get
            {
                return _inputMode;
            }
            set
            {
                if (_inputMode != value)
                {
                    if (value == SongStructureDisplayMode.Structured)
                    {
                        panelSongStructure.Show();
                        PopulateTree();
                        if (CurrentPartId >= 0 && CurrentSlideId >= 0)
                        {
                            treeViewContents.SelectedNode = treeViewContents.Nodes[CurrentPartId].Nodes[CurrentSlideId];
                        }
                        else if (CurrentPartId >= 0)
                        {
                            treeViewContents.SelectedNode = treeViewContents.Nodes[CurrentPartId];
                        }
                    }
                    else if (value == SongStructureDisplayMode.Textual)
                    {
                        panelSongStructure.Hide();
                        textBoxSongText.DataBindings.Clear();
                        textBoxSongTranslation.DataBindings.Clear();

                        textBoxSongText.Text = _textualSongReprMapper.Map(Song);
                    }
                    _inputMode = value;
                }
            }
        }
    }
}