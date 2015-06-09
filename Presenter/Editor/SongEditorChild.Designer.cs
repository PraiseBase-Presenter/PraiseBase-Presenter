using PraiseBase.Presenter.Controls;

namespace PraiseBase.Presenter.Editor
{
    partial class SongEditorChild
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongEditorChild));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelSongText = new System.Windows.Forms.Label();
            this.textBoxSongText = new System.Windows.Forms.TextBox();
            this.labelTranslation = new System.Windows.Forms.Label();
            this.textBoxSongTranslation = new System.Windows.Forms.TextBox();
            this.addContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.slideContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.neueFolieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aufToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.löschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teilenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.löschenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.partContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.umbenennenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.löschenToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.buttonDuplicateSlide = new System.Windows.Forms.Button();
            this.textBoxSongTitle = new System.Windows.Forms.TextBox();
            this.buttonAddSlide = new System.Windows.Forms.Button();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonDelItem = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.treeViewContents = new System.Windows.Forms.TreeView();
            this.panelSongStructure = new System.Windows.Forms.Panel();
            this.labelStructure = new System.Windows.Forms.Label();
            this.tabControlMeta = new System.Windows.Forms.TabControl();
            this.tabPageInformation = new System.Windows.Forms.TabPage();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.labelRightsManagement = new System.Windows.Forms.Label();
            this.textBoxSongbooks = new System.Windows.Forms.TextBox();
            this.textBoxRightsManagement = new System.Windows.Forms.TextBox();
            this.labelSongbook = new System.Windows.Forms.Label();
            this.textBoxPublisher = new System.Windows.Forms.TextBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelPublisher = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.textBoxAuthors = new System.Windows.Forms.TextBox();
            this.labelCcliIdentifier = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelThemes = new System.Windows.Forms.Label();
            this.textBoxCopyright = new System.Windows.Forms.TextBox();
            this.textBoxCCLISongID = new System.Windows.Forms.TextBox();
            this.checkedListBoxThemes = new System.Windows.Forms.CheckedListBox();
            this.tabPageQA = new System.Windows.Forms.TabPage();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.labelMarkers = new System.Windows.Forms.Label();
            this.checkBoxQAImages = new System.Windows.Forms.CheckBox();
            this.checkBoxQASegmentation = new System.Windows.Forms.CheckBox();
            this.checkBoxQATranslation = new System.Windows.Forms.CheckBox();
            this.labelComment = new System.Windows.Forms.Label();
            this.checkBoxQASpelling = new System.Windows.Forms.CheckBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.slideContextMenu.SuspendLayout();
            this.partContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.panelSongStructure.SuspendLayout();
            this.tabControlMeta.SuspendLayout();
            this.tabPageInformation.SuspendLayout();
            this.tabPageQA.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelSongText);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxSongText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelTranslation);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxSongTranslation);
            // 
            // labelSongText
            // 
            resources.ApplyResources(this.labelSongText, "labelSongText");
            this.labelSongText.Name = "labelSongText";
            // 
            // textBoxSongText
            // 
            this.textBoxSongText.AcceptsReturn = true;
            this.textBoxSongText.AcceptsTab = true;
            this.textBoxSongText.AllowDrop = true;
            resources.ApplyResources(this.textBoxSongText, "textBoxSongText");
            this.textBoxSongText.Name = "textBoxSongText";
            this.textBoxSongText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSongText_KeyUp);
            // 
            // labelTranslation
            // 
            resources.ApplyResources(this.labelTranslation, "labelTranslation");
            this.labelTranslation.Name = "labelTranslation";
            // 
            // textBoxSongTranslation
            // 
            this.textBoxSongTranslation.AcceptsReturn = true;
            this.textBoxSongTranslation.AcceptsTab = true;
            this.textBoxSongTranslation.AllowDrop = true;
            resources.ApplyResources(this.textBoxSongTranslation, "textBoxSongTranslation");
            this.textBoxSongTranslation.Name = "textBoxSongTranslation";
            this.textBoxSongTranslation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSongTranslation_KeyUp);
            // 
            // addContextMenu
            // 
            this.addContextMenu.Name = "addContextMenu";
            resources.ApplyResources(this.addContextMenu, "addContextMenu");
            this.addContextMenu.VisibleChanged += new System.EventHandler(this.addContextMenu_VisibleChanged);
            // 
            // slideContextMenu
            // 
            this.slideContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neueFolieToolStripMenuItem,
            this.aufToolStripMenuItem,
            this.abToolStripMenuItem,
            this.löschenToolStripMenuItem,
            this.teilenToolStripMenuItem,
            this.löschenToolStripMenuItem1});
            this.slideContextMenu.Name = "slideContextMenu";
            resources.ApplyResources(this.slideContextMenu, "slideContextMenu");
            // 
            // neueFolieToolStripMenuItem
            // 
            this.neueFolieToolStripMenuItem.Name = "neueFolieToolStripMenuItem";
            resources.ApplyResources(this.neueFolieToolStripMenuItem, "neueFolieToolStripMenuItem");
            this.neueFolieToolStripMenuItem.Click += new System.EventHandler(this.neueFolieToolStripMenuItem_Click);
            // 
            // aufToolStripMenuItem
            // 
            this.aufToolStripMenuItem.Name = "aufToolStripMenuItem";
            resources.ApplyResources(this.aufToolStripMenuItem, "aufToolStripMenuItem");
            this.aufToolStripMenuItem.Click += new System.EventHandler(this.aufToolStripMenuItem_Click);
            // 
            // abToolStripMenuItem
            // 
            this.abToolStripMenuItem.Name = "abToolStripMenuItem";
            resources.ApplyResources(this.abToolStripMenuItem, "abToolStripMenuItem");
            this.abToolStripMenuItem.Click += new System.EventHandler(this.abToolStripMenuItem_Click);
            // 
            // löschenToolStripMenuItem
            // 
            this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
            resources.ApplyResources(this.löschenToolStripMenuItem, "löschenToolStripMenuItem");
            this.löschenToolStripMenuItem.Click += new System.EventHandler(this.löschenToolStripMenuItem_Click);
            // 
            // teilenToolStripMenuItem
            // 
            this.teilenToolStripMenuItem.Name = "teilenToolStripMenuItem";
            resources.ApplyResources(this.teilenToolStripMenuItem, "teilenToolStripMenuItem");
            this.teilenToolStripMenuItem.Click += new System.EventHandler(this.teilenToolStripMenuItem_Click);
            // 
            // löschenToolStripMenuItem1
            // 
            this.löschenToolStripMenuItem1.Name = "löschenToolStripMenuItem1";
            resources.ApplyResources(this.löschenToolStripMenuItem1, "löschenToolStripMenuItem1");
            this.löschenToolStripMenuItem1.Click += new System.EventHandler(this.löschenToolStripMenuItem1_Click);
            // 
            // partContextMenu
            // 
            this.partContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.umbenennenToolStripMenuItem,
            this.löschenToolStripMenuItem2});
            this.partContextMenu.Name = "partContextMenu";
            resources.ApplyResources(this.partContextMenu, "partContextMenu");
            // 
            // umbenennenToolStripMenuItem
            // 
            this.umbenennenToolStripMenuItem.Name = "umbenennenToolStripMenuItem";
            resources.ApplyResources(this.umbenennenToolStripMenuItem, "umbenennenToolStripMenuItem");
            this.umbenennenToolStripMenuItem.Click += new System.EventHandler(this.umbenennenToolStripMenuItem_Click);
            // 
            // löschenToolStripMenuItem2
            // 
            this.löschenToolStripMenuItem2.Name = "löschenToolStripMenuItem2";
            resources.ApplyResources(this.löschenToolStripMenuItem2, "löschenToolStripMenuItem2");
            this.löschenToolStripMenuItem2.Click += new System.EventHandler(this.löschenToolStripMenuItem2_Click);
            // 
            // pictureBoxPreview
            // 
            resources.ApplyResources(this.pictureBoxPreview, "pictureBoxPreview");
            this.pictureBoxPreview.BackColor = System.Drawing.Color.Black;
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.TabStop = false;
            this.pictureBoxPreview.Click += new System.EventHandler(this.buttonSlideBackground_Click);
            // 
            // buttonDuplicateSlide
            // 
            resources.ApplyResources(this.buttonDuplicateSlide, "buttonDuplicateSlide");
            this.buttonDuplicateSlide.Image = global::PraiseBase.Presenter.Properties.Resources.editcopy;
            this.buttonDuplicateSlide.Name = "buttonDuplicateSlide";
            this.toolTip1.SetToolTip(this.buttonDuplicateSlide, resources.GetString("buttonDuplicateSlide.ToolTip"));
            this.buttonDuplicateSlide.UseVisualStyleBackColor = true;
            this.buttonDuplicateSlide.Click += new System.EventHandler(this.buttonSlideDuplicate_Click);
            // 
            // textBoxSongTitle
            // 
            resources.ApplyResources(this.textBoxSongTitle, "textBoxSongTitle");
            this.textBoxSongTitle.Name = "textBoxSongTitle";
            this.textBoxSongTitle.TextChanged += new System.EventHandler(this.textBoxSongTitle_TextChanged);
            this.textBoxSongTitle.Enter += new System.EventHandler(this.textBoxSongTitle_Enter);
            // 
            // buttonAddSlide
            // 
            resources.ApplyResources(this.buttonAddSlide, "buttonAddSlide");
            this.buttonAddSlide.Image = global::PraiseBase.Presenter.Properties.Resources.edit_add;
            this.buttonAddSlide.Name = "buttonAddSlide";
            this.toolTip1.SetToolTip(this.buttonAddSlide, resources.GetString("buttonAddSlide.ToolTip"));
            this.buttonAddSlide.UseVisualStyleBackColor = true;
            this.buttonAddSlide.Click += new System.EventHandler(this.buttonAddSlide_Click);
            // 
            // buttonAddItem
            // 
            resources.ApplyResources(this.buttonAddItem, "buttonAddItem");
            this.buttonAddItem.Image = global::PraiseBase.Presenter.Properties.Resources.edit_add;
            this.buttonAddItem.Name = "buttonAddItem";
            this.toolTip1.SetToolTip(this.buttonAddItem, resources.GetString("buttonAddItem.ToolTip"));
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonAddItem_MouseDown);
            // 
            // buttonMoveUp
            // 
            resources.ApplyResources(this.buttonMoveUp, "buttonMoveUp");
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.toolTip1.SetToolTip(this.buttonMoveUp, resources.GetString("buttonMoveUp.ToolTip"));
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonDelItem
            // 
            resources.ApplyResources(this.buttonDelItem, "buttonDelItem");
            this.buttonDelItem.Image = global::PraiseBase.Presenter.Properties.Resources.edit_remove;
            this.buttonDelItem.Name = "buttonDelItem";
            this.toolTip1.SetToolTip(this.buttonDelItem, resources.GetString("buttonDelItem.ToolTip"));
            this.buttonDelItem.UseVisualStyleBackColor = true;
            this.buttonDelItem.Click += new System.EventHandler(this.buttonDelItem_Click);
            // 
            // buttonMoveDown
            // 
            resources.ApplyResources(this.buttonMoveDown, "buttonMoveDown");
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.toolTip1.SetToolTip(this.buttonMoveDown, resources.GetString("buttonMoveDown.ToolTip"));
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // treeViewContents
            // 
            resources.ApplyResources(this.treeViewContents, "treeViewContents");
            this.treeViewContents.HideSelection = false;
            this.treeViewContents.Name = "treeViewContents";
            this.treeViewContents.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewContents_AfterSelect);
            this.treeViewContents.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewContents_NodeMouseClick);
            this.treeViewContents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewContents_KeyDown);
            // 
            // panelSongStructure
            // 
            resources.ApplyResources(this.panelSongStructure, "panelSongStructure");
            this.panelSongStructure.Controls.Add(this.labelStructure);
            this.panelSongStructure.Controls.Add(this.buttonAddItem);
            this.panelSongStructure.Controls.Add(this.buttonAddSlide);
            this.panelSongStructure.Controls.Add(this.buttonDuplicateSlide);
            this.panelSongStructure.Controls.Add(this.buttonMoveUp);
            this.panelSongStructure.Controls.Add(this.buttonDelItem);
            this.panelSongStructure.Controls.Add(this.buttonMoveDown);
            this.panelSongStructure.Controls.Add(this.treeViewContents);
            this.panelSongStructure.Name = "panelSongStructure";
            // 
            // labelStructure
            // 
            resources.ApplyResources(this.labelStructure, "labelStructure");
            this.labelStructure.Name = "labelStructure";
            // 
            // tabControlMeta
            // 
            resources.ApplyResources(this.tabControlMeta, "tabControlMeta");
            this.tabControlMeta.Controls.Add(this.tabPageInformation);
            this.tabControlMeta.Controls.Add(this.tabPageQA);
            this.tabControlMeta.Name = "tabControlMeta";
            this.tabControlMeta.SelectedIndex = 0;
            // 
            // tabPageInformation
            // 
            this.tabPageInformation.Controls.Add(this.labelTitle);
            this.tabPageInformation.Controls.Add(this.labelLanguage);
            this.tabPageInformation.Controls.Add(this.labelRightsManagement);
            this.tabPageInformation.Controls.Add(this.textBoxSongbooks);
            this.tabPageInformation.Controls.Add(this.textBoxRightsManagement);
            this.tabPageInformation.Controls.Add(this.labelSongbook);
            this.tabPageInformation.Controls.Add(this.textBoxPublisher);
            this.tabPageInformation.Controls.Add(this.comboBoxLanguage);
            this.tabPageInformation.Controls.Add(this.labelPublisher);
            this.tabPageInformation.Controls.Add(this.textBoxSongTitle);
            this.tabPageInformation.Controls.Add(this.labelCopyright);
            this.tabPageInformation.Controls.Add(this.textBoxAuthors);
            this.tabPageInformation.Controls.Add(this.labelCcliIdentifier);
            this.tabPageInformation.Controls.Add(this.labelAuthor);
            this.tabPageInformation.Controls.Add(this.labelThemes);
            this.tabPageInformation.Controls.Add(this.textBoxCopyright);
            this.tabPageInformation.Controls.Add(this.textBoxCCLISongID);
            this.tabPageInformation.Controls.Add(this.checkedListBoxThemes);
            resources.ApplyResources(this.tabPageInformation, "tabPageInformation");
            this.tabPageInformation.Name = "tabPageInformation";
            this.tabPageInformation.UseVisualStyleBackColor = true;
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // labelLanguage
            // 
            resources.ApplyResources(this.labelLanguage, "labelLanguage");
            this.labelLanguage.Name = "labelLanguage";
            // 
            // labelRightsManagement
            // 
            resources.ApplyResources(this.labelRightsManagement, "labelRightsManagement");
            this.labelRightsManagement.Name = "labelRightsManagement";
            // 
            // textBoxSongbooks
            // 
            resources.ApplyResources(this.textBoxSongbooks, "textBoxSongbooks");
            this.textBoxSongbooks.Name = "textBoxSongbooks";
            this.textBoxSongbooks.TextChanged += new System.EventHandler(this.textBoxSongbooks_TextChanged);
            // 
            // textBoxRightsManagement
            // 
            resources.ApplyResources(this.textBoxRightsManagement, "textBoxRightsManagement");
            this.textBoxRightsManagement.Name = "textBoxRightsManagement";
            // 
            // labelSongbook
            // 
            resources.ApplyResources(this.labelSongbook, "labelSongbook");
            this.labelSongbook.Name = "labelSongbook";
            // 
            // textBoxPublisher
            // 
            resources.ApplyResources(this.textBoxPublisher, "textBoxPublisher");
            this.textBoxPublisher.Name = "textBoxPublisher";
            // 
            // comboBoxLanguage
            // 
            resources.ApplyResources(this.comboBoxLanguage, "comboBoxLanguage");
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            this.comboBoxLanguage.Enter += new System.EventHandler(this.comboBoxLanguage_Enter);
            // 
            // labelPublisher
            // 
            resources.ApplyResources(this.labelPublisher, "labelPublisher");
            this.labelPublisher.Name = "labelPublisher";
            // 
            // labelCopyright
            // 
            resources.ApplyResources(this.labelCopyright, "labelCopyright");
            this.labelCopyright.Name = "labelCopyright";
            // 
            // textBoxAuthors
            // 
            resources.ApplyResources(this.textBoxAuthors, "textBoxAuthors");
            this.textBoxAuthors.Name = "textBoxAuthors";
            this.textBoxAuthors.TextChanged += new System.EventHandler(this.textBoxAuthors_TextChanged);
            // 
            // labelCcliIdentifier
            // 
            resources.ApplyResources(this.labelCcliIdentifier, "labelCcliIdentifier");
            this.labelCcliIdentifier.Name = "labelCcliIdentifier";
            // 
            // labelAuthor
            // 
            resources.ApplyResources(this.labelAuthor, "labelAuthor");
            this.labelAuthor.Name = "labelAuthor";
            // 
            // labelThemes
            // 
            resources.ApplyResources(this.labelThemes, "labelThemes");
            this.labelThemes.Name = "labelThemes";
            // 
            // textBoxCopyright
            // 
            resources.ApplyResources(this.textBoxCopyright, "textBoxCopyright");
            this.textBoxCopyright.Name = "textBoxCopyright";
            // 
            // textBoxCCLISongID
            // 
            resources.ApplyResources(this.textBoxCCLISongID, "textBoxCCLISongID");
            this.textBoxCCLISongID.Name = "textBoxCCLISongID";
            // 
            // checkedListBoxThemes
            // 
            resources.ApplyResources(this.checkedListBoxThemes, "checkedListBoxThemes");
            this.checkedListBoxThemes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxThemes.CheckOnClick = true;
            this.checkedListBoxThemes.FormattingEnabled = true;
            this.checkedListBoxThemes.Name = "checkedListBoxThemes";
            this.checkedListBoxThemes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxTags_ItemCheck);
            // 
            // tabPageQA
            // 
            this.tabPageQA.Controls.Add(this.textBoxComment);
            this.tabPageQA.Controls.Add(this.labelMarkers);
            this.tabPageQA.Controls.Add(this.checkBoxQAImages);
            this.tabPageQA.Controls.Add(this.checkBoxQASegmentation);
            this.tabPageQA.Controls.Add(this.checkBoxQATranslation);
            this.tabPageQA.Controls.Add(this.labelComment);
            this.tabPageQA.Controls.Add(this.checkBoxQASpelling);
            resources.ApplyResources(this.tabPageQA, "tabPageQA");
            this.tabPageQA.Name = "tabPageQA";
            this.tabPageQA.UseVisualStyleBackColor = true;
            // 
            // textBoxComment
            // 
            resources.ApplyResources(this.textBoxComment, "textBoxComment");
            this.textBoxComment.Name = "textBoxComment";
            // 
            // labelMarkers
            // 
            resources.ApplyResources(this.labelMarkers, "labelMarkers");
            this.labelMarkers.Name = "labelMarkers";
            // 
            // checkBoxQAImages
            // 
            resources.ApplyResources(this.checkBoxQAImages, "checkBoxQAImages");
            this.checkBoxQAImages.Name = "checkBoxQAImages";
            this.checkBoxQAImages.UseVisualStyleBackColor = true;
            this.checkBoxQAImages.CheckedChanged += new System.EventHandler(this.checkBoxQAImages_CheckedChanged);
            // 
            // checkBoxQASegmentation
            // 
            resources.ApplyResources(this.checkBoxQASegmentation, "checkBoxQASegmentation");
            this.checkBoxQASegmentation.Name = "checkBoxQASegmentation";
            this.checkBoxQASegmentation.UseVisualStyleBackColor = true;
            this.checkBoxQASegmentation.CheckedChanged += new System.EventHandler(this.checkBoxQASegmentation_CheckedChanged);
            // 
            // checkBoxQATranslation
            // 
            resources.ApplyResources(this.checkBoxQATranslation, "checkBoxQATranslation");
            this.checkBoxQATranslation.Name = "checkBoxQATranslation";
            this.checkBoxQATranslation.UseVisualStyleBackColor = true;
            this.checkBoxQATranslation.CheckedChanged += new System.EventHandler(this.checkBoxQATranslation_CheckedChanged);
            // 
            // labelComment
            // 
            resources.ApplyResources(this.labelComment, "labelComment");
            this.labelComment.Name = "labelComment";
            // 
            // checkBoxQASpelling
            // 
            resources.ApplyResources(this.checkBoxQASpelling, "checkBoxQASpelling");
            this.checkBoxQASpelling.Name = "checkBoxQASpelling";
            this.checkBoxQASpelling.UseVisualStyleBackColor = true;
            this.checkBoxQASpelling.CheckedChanged += new System.EventHandler(this.checkBoxQASpelling_CheckedChanged);
            // 
            // SongEditorChild
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlMeta);
            this.Controls.Add(this.panelSongStructure);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SongEditorChild";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.EditorChild_Load);
            this.Shown += new System.EventHandler(this.EditorChild_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.slideContextMenu.ResumeLayout(false);
            this.partContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.panelSongStructure.ResumeLayout(false);
            this.panelSongStructure.PerformLayout();
            this.tabControlMeta.ResumeLayout(false);
            this.tabPageInformation.ResumeLayout(false);
            this.tabPageInformation.PerformLayout();
            this.tabPageQA.ResumeLayout(false);
            this.tabPageQA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip addContextMenu;
		private System.Windows.Forms.ContextMenuStrip slideContextMenu;
		private System.Windows.Forms.ToolStripMenuItem aufToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem abToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem teilenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem neueFolieToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip partContextMenu;
		private System.Windows.Forms.ToolStripMenuItem umbenennenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem2;
        private System.Windows.Forms.Button buttonDuplicateSlide;
        private System.Windows.Forms.TextBox textBoxSongTitle;
        private System.Windows.Forms.Button buttonAddSlide;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelSongText;
        private System.Windows.Forms.TextBox textBoxSongText;
        private System.Windows.Forms.Label labelTranslation;
        private System.Windows.Forms.TextBox textBoxSongTranslation;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.TreeView treeViewContents;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonDelItem;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panelSongStructure;
        private System.Windows.Forms.TabControl tabControlMeta;
        private System.Windows.Forms.TabPage tabPageInformation;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.Label labelRightsManagement;
        private System.Windows.Forms.TextBox textBoxSongbooks;
        private System.Windows.Forms.TextBox textBoxRightsManagement;
        private System.Windows.Forms.Label labelSongbook;
        private System.Windows.Forms.TextBox textBoxPublisher;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelPublisher;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.TextBox textBoxAuthors;
        private System.Windows.Forms.Label labelCcliIdentifier;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelThemes;
        private System.Windows.Forms.TextBox textBoxCopyright;
        private System.Windows.Forms.TextBox textBoxCCLISongID;
        private System.Windows.Forms.CheckedListBox checkedListBoxThemes;
        private System.Windows.Forms.TabPage tabPageQA;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label labelMarkers;
        private System.Windows.Forms.CheckBox checkBoxQAImages;
        private System.Windows.Forms.CheckBox checkBoxQASegmentation;
        private System.Windows.Forms.CheckBox checkBoxQATranslation;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.CheckBox checkBoxQASpelling;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelStructure;
    }
}