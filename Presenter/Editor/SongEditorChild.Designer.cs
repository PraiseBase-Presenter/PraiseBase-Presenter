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
            this.textBoxPartCaption = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSongText = new System.Windows.Forms.TextBox();
            this.textBoxPartCaptionTranslated = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSongTranslation = new System.Windows.Forms.TextBox();
            this.comboBoxLanguageTranslated = new System.Windows.Forms.ComboBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
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
            this.checkBoxQASegmentation = new System.Windows.Forms.CheckBox();
            this.checkBoxQATranslation = new System.Windows.Forms.CheckBox();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.checkBoxQAImages = new System.Windows.Forms.CheckBox();
            this.checkBoxQASpelling = new System.Windows.Forms.CheckBox();
            this.checkedListBoxTags = new System.Windows.Forms.CheckedListBox();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.textBoxRightsManagement = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxSongbooks = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxPublisher = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxAuthors = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonDuplicateSlide = new System.Windows.Forms.Button();
            this.textBoxCCLISongID = new System.Windows.Forms.TextBox();
            this.textBoxCopyright = new System.Windows.Forms.TextBox();
            this.textBoxSongTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonAddSlide = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonDelItem = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeViewContents = new PraiseBase.Presenter.Controls.TreeViewLabelEdit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.slideContextMenu.SuspendLayout();
            this.partContextMenu.SuspendLayout();
            this.panelPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxPartCaption);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxSongText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxPartCaptionTranslated);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxSongTranslation);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxLanguageTranslated);
            // 
            // textBoxPartCaption
            // 
            resources.ApplyResources(this.textBoxPartCaption, "textBoxPartCaption");
            this.textBoxPartCaption.Name = "textBoxPartCaption";
            this.textBoxPartCaption.TextChanged += new System.EventHandler(this.textBoxPartCaption_TextChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
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
            // textBoxPartCaptionTranslated
            // 
            resources.ApplyResources(this.textBoxPartCaptionTranslated, "textBoxPartCaptionTranslated");
            this.textBoxPartCaptionTranslated.Name = "textBoxPartCaptionTranslated";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
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
            // comboBoxLanguageTranslated
            // 
            resources.ApplyResources(this.comboBoxLanguageTranslated, "comboBoxLanguageTranslated");
            this.comboBoxLanguageTranslated.FormattingEnabled = true;
            this.comboBoxLanguageTranslated.Name = "comboBoxLanguageTranslated";
            // 
            // comboBoxLanguage
            // 
            resources.ApplyResources(this.comboBoxLanguage, "comboBoxLanguage");
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            this.comboBoxLanguage.Enter += new System.EventHandler(this.comboBoxLanguage_Enter);
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
            // textBoxComment
            // 
            resources.ApplyResources(this.textBoxComment, "textBoxComment");
            this.textBoxComment.Name = "textBoxComment";
            // 
            // checkBoxQAImages
            // 
            resources.ApplyResources(this.checkBoxQAImages, "checkBoxQAImages");
            this.checkBoxQAImages.Name = "checkBoxQAImages";
            this.checkBoxQAImages.UseVisualStyleBackColor = true;
            this.checkBoxQAImages.CheckedChanged += new System.EventHandler(this.checkBoxQAImages_CheckedChanged);
            // 
            // checkBoxQASpelling
            // 
            resources.ApplyResources(this.checkBoxQASpelling, "checkBoxQASpelling");
            this.checkBoxQASpelling.Name = "checkBoxQASpelling";
            this.checkBoxQASpelling.UseVisualStyleBackColor = true;
            this.checkBoxQASpelling.CheckedChanged += new System.EventHandler(this.checkBoxQASpelling_CheckedChanged);
            // 
            // checkedListBoxTags
            // 
            resources.ApplyResources(this.checkedListBoxTags, "checkedListBoxTags");
            this.checkedListBoxTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxTags.CheckOnClick = true;
            this.checkedListBoxTags.FormattingEnabled = true;
            this.checkedListBoxTags.Name = "checkedListBoxTags";
            this.checkedListBoxTags.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxTags_ItemCheck);
            // 
            // panelPreview
            // 
            resources.ApplyResources(this.panelPreview, "panelPreview");
            this.panelPreview.BackColor = System.Drawing.Color.LightGray;
            this.panelPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPreview.Controls.Add(this.pictureBoxPreview);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Resize += new System.EventHandler(this.panelPreview_Resize);
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
            // textBoxRightsManagement
            // 
            resources.ApplyResources(this.textBoxRightsManagement, "textBoxRightsManagement");
            this.textBoxRightsManagement.Name = "textBoxRightsManagement";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // textBoxSongbooks
            // 
            resources.ApplyResources(this.textBoxSongbooks, "textBoxSongbooks");
            this.textBoxSongbooks.Name = "textBoxSongbooks";
            this.textBoxSongbooks.TextChanged += new System.EventHandler(this.textBoxSongbooks_TextChanged);
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // textBoxPublisher
            // 
            resources.ApplyResources(this.textBoxPublisher, "textBoxPublisher");
            this.textBoxPublisher.Name = "textBoxPublisher";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // textBoxAuthors
            // 
            resources.ApplyResources(this.textBoxAuthors, "textBoxAuthors");
            this.textBoxAuthors.Name = "textBoxAuthors";
            this.textBoxAuthors.TextChanged += new System.EventHandler(this.textBoxAuthors_TextChanged);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // buttonDuplicateSlide
            // 
            resources.ApplyResources(this.buttonDuplicateSlide, "buttonDuplicateSlide");
            this.buttonDuplicateSlide.Name = "buttonDuplicateSlide";
            this.toolTip1.SetToolTip(this.buttonDuplicateSlide, resources.GetString("buttonDuplicateSlide.ToolTip"));
            this.buttonDuplicateSlide.UseVisualStyleBackColor = true;
            this.buttonDuplicateSlide.Click += new System.EventHandler(this.buttonSlideDuplicate_Click);
            // 
            // textBoxCCLISongID
            // 
            resources.ApplyResources(this.textBoxCCLISongID, "textBoxCCLISongID");
            this.textBoxCCLISongID.Name = "textBoxCCLISongID";
            // 
            // textBoxCopyright
            // 
            resources.ApplyResources(this.textBoxCopyright, "textBoxCopyright");
            this.textBoxCopyright.Name = "textBoxCopyright";
            // 
            // textBoxSongTitle
            // 
            resources.ApplyResources(this.textBoxSongTitle, "textBoxSongTitle");
            this.textBoxSongTitle.Name = "textBoxSongTitle";
            this.textBoxSongTitle.TextChanged += new System.EventHandler(this.textBoxSongTitle_TextChanged);
            this.textBoxSongTitle.Enter += new System.EventHandler(this.textBoxSongTitle_Enter);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // buttonAddSlide
            // 
            resources.ApplyResources(this.buttonAddSlide, "buttonAddSlide");
            this.buttonAddSlide.Name = "buttonAddSlide";
            this.toolTip1.SetToolTip(this.buttonAddSlide, resources.GetString("buttonAddSlide.ToolTip"));
            this.buttonAddSlide.UseVisualStyleBackColor = true;
            this.buttonAddSlide.Click += new System.EventHandler(this.buttonAddSlide_Click);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // buttonAddItem
            // 
            resources.ApplyResources(this.buttonAddItem, "buttonAddItem");
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
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.checkBoxQASegmentation);
            this.groupBox1.Controls.Add(this.checkBoxQASpelling);
            this.groupBox1.Controls.Add(this.checkBoxQATranslation);
            this.groupBox1.Controls.Add(this.checkBoxQAImages);
            this.groupBox1.Controls.Add(this.textBoxComment);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.checkedListBoxTags);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // treeViewContents
            // 
            resources.ApplyResources(this.treeViewContents, "treeViewContents");
            this.treeViewContents.HideSelection = false;
            this.treeViewContents.Name = "treeViewContents";
            this.treeViewContents.ValidateLabelEdit += new PraiseBase.Presenter.Controls.TreeViewLabelEdit.ValidateLabelEditEventHandler(this.treeViewContents_ValidateLabelEdit);
            this.treeViewContents.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewContents_BeforeLabelEdit);
            this.treeViewContents.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewContents_AfterLabelEdit);
            this.treeViewContents.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewContents_AfterSelect);
            this.treeViewContents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewContents_KeyDown);
            // 
            // SongEditorChild
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.textBoxSongbooks);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBoxRightsManagement);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.treeViewContents);
            this.Controls.Add(this.textBoxPublisher);
            this.Controls.Add(this.buttonMoveDown);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.buttonDelItem);
            this.Controls.Add(this.textBoxAuthors);
            this.Controls.Add(this.buttonMoveUp);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.buttonDuplicateSlide);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxCCLISongID);
            this.Controls.Add(this.buttonAddSlide);
            this.Controls.Add(this.textBoxCopyright);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxSongTitle);
            this.Controls.Add(this.label4);
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
            this.panelPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox textBoxCCLISongID;
        private System.Windows.Forms.TextBox textBoxCopyright;
        private System.Windows.Forms.TextBox textBoxSongTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonAddSlide;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBoxPartCaption;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.TextBox textBoxSongText;
        private System.Windows.Forms.TextBox textBoxPartCaptionTranslated;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSongTranslation;
        private System.Windows.Forms.ComboBox comboBoxLanguageTranslated;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private TreeViewLabelEdit treeViewContents;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonDelItem;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.CheckBox checkBoxQASegmentation;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.CheckBox checkBoxQATranslation;
        private System.Windows.Forms.CheckBox checkBoxQASpelling;
        private System.Windows.Forms.CheckBox checkBoxQAImages;
        private System.Windows.Forms.CheckedListBox checkedListBoxTags;
        private System.Windows.Forms.TextBox textBoxPublisher;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxAuthors;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxSongbooks;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxRightsManagement;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}