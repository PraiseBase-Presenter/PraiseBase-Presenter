namespace Pbp.Forms
{
    partial class EditorChild
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorChild));
			this.labelLanguage = new System.Windows.Forms.Label();
			this.buttonProjectionMasterFont = new System.Windows.Forms.Button();
			this.labelLineSpacing = new System.Windows.Forms.Label();
			this.trackBarLineSpacing = new System.Windows.Forms.TrackBar();
			this.buttonTranslationFont = new System.Windows.Forms.Button();
			this.labelFontTranslation = new System.Windows.Forms.Label();
			this.labelFont = new System.Windows.Forms.Label();
			this.textBoxComment = new System.Windows.Forms.TextBox();
			this.checkBoxQASegmentation = new System.Windows.Forms.CheckBox();
			this.checkBoxQAImages = new System.Windows.Forms.CheckBox();
			this.checkBoxQATranslation = new System.Windows.Forms.CheckBox();
			this.checkBoxQASpelling = new System.Windows.Forms.CheckBox();
			this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
			this.checkedListBoxTags = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonAddItem = new System.Windows.Forms.Button();
			this.addContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.liedteilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.folieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonDelItem = new System.Windows.Forms.Button();
			this.buttonMoveUp = new System.Windows.Forms.Button();
			this.buttonMoveDown = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBoxSongTranslation = new System.Windows.Forms.TextBox();
			this.comboBoxSlideVertOrientation = new System.Windows.Forms.ComboBox();
			this.comboBoxSlideHorizOrientation = new System.Windows.Forms.ComboBox();
			this.buttonSlideBackground = new System.Windows.Forms.Button();
			this.textBoxSongText = new System.Windows.Forms.TextBox();
			this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
			this.slideContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.neueFolieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aufToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.abToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.löschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.teilenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.löschenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.buttonChooseProjectionForeColor = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.buttonTranslationColor = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.partContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.umbenennenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.löschenToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.songContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.umbenennenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.treeViewContents = new TreeEx.TreeLE();
			((System.ComponentModel.ISupportInitialize)(this.trackBarLineSpacing)).BeginInit();
			this.addContextMenu.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
			this.slideContextMenu.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.partContextMenu.SuspendLayout();
			this.songContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelLanguage
			// 
			this.labelLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelLanguage.AutoSize = true;
			this.labelLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLanguage.Location = new System.Drawing.Point(7, 399);
			this.labelLanguage.Name = "labelLanguage";
			this.labelLanguage.Size = new System.Drawing.Size(50, 13);
			this.labelLanguage.TabIndex = 6;
			this.labelLanguage.Text = "Sprache:";
			// 
			// buttonProjectionMasterFont
			// 
			this.buttonProjectionMasterFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonProjectionMasterFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonProjectionMasterFont.Location = new System.Drawing.Point(5, 204);
			this.buttonProjectionMasterFont.Name = "buttonProjectionMasterFont";
			this.buttonProjectionMasterFont.Size = new System.Drawing.Size(100, 23);
			this.buttonProjectionMasterFont.TabIndex = 56;
			this.buttonProjectionMasterFont.Text = "Schrift wählen...";
			this.buttonProjectionMasterFont.UseVisualStyleBackColor = true;
			this.buttonProjectionMasterFont.Click += new System.EventHandler(this.buttonProjectionMasterFont_Click);
			// 
			// labelLineSpacing
			// 
			this.labelLineSpacing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelLineSpacing.AutoSize = true;
			this.labelLineSpacing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLineSpacing.Location = new System.Drawing.Point(609, 442);
			this.labelLineSpacing.Name = "labelLineSpacing";
			this.labelLineSpacing.Size = new System.Drawing.Size(14, 20);
			this.labelLineSpacing.TabIndex = 65;
			this.labelLineSpacing.Text = "-";
			// 
			// trackBarLineSpacing
			// 
			this.trackBarLineSpacing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.trackBarLineSpacing.Location = new System.Drawing.Point(473, 440);
			this.trackBarLineSpacing.Maximum = 50;
			this.trackBarLineSpacing.Name = "trackBarLineSpacing";
			this.trackBarLineSpacing.Size = new System.Drawing.Size(130, 42);
			this.trackBarLineSpacing.TabIndex = 64;
			this.trackBarLineSpacing.TickFrequency = 5;
			this.trackBarLineSpacing.Scroll += new System.EventHandler(this.trackBarLineSpacing_Scroll);
			// 
			// buttonTranslationFont
			// 
			this.buttonTranslationFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonTranslationFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonTranslationFont.Location = new System.Drawing.Point(6, 204);
			this.buttonTranslationFont.Name = "buttonTranslationFont";
			this.buttonTranslationFont.Size = new System.Drawing.Size(100, 23);
			this.buttonTranslationFont.TabIndex = 57;
			this.buttonTranslationFont.Text = "Schrift wählen...";
			this.buttonTranslationFont.UseVisualStyleBackColor = true;
			this.buttonTranslationFont.Click += new System.EventHandler(this.buttonTranslationFont_Click);
			// 
			// labelFontTranslation
			// 
			this.labelFontTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelFontTranslation.AutoSize = true;
			this.labelFontTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFontTranslation.Location = new System.Drawing.Point(143, 205);
			this.labelFontTranslation.Name = "labelFontTranslation";
			this.labelFontTranslation.Size = new System.Drawing.Size(14, 20);
			this.labelFontTranslation.TabIndex = 62;
			this.labelFontTranslation.Text = "-";
			// 
			// labelFont
			// 
			this.labelFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelFont.AutoSize = true;
			this.labelFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFont.Location = new System.Drawing.Point(143, 204);
			this.labelFont.Name = "labelFont";
			this.labelFont.Size = new System.Drawing.Size(14, 20);
			this.labelFont.TabIndex = 60;
			this.labelFont.Text = "-";
			// 
			// textBoxComment
			// 
			this.textBoxComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxComment.Location = new System.Drawing.Point(6, 19);
			this.textBoxComment.Multiline = true;
			this.textBoxComment.Name = "textBoxComment";
			this.textBoxComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxComment.Size = new System.Drawing.Size(245, 74);
			this.textBoxComment.TabIndex = 68;
			this.textBoxComment.TextChanged += new System.EventHandler(this.textBoxComment_TextChanged);
			// 
			// checkBoxQASegmentation
			// 
			this.checkBoxQASegmentation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxQASegmentation.AutoSize = true;
			this.checkBoxQASegmentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxQASegmentation.Location = new System.Drawing.Point(6, 177);
			this.checkBoxQASegmentation.Name = "checkBoxQASegmentation";
			this.checkBoxQASegmentation.Size = new System.Drawing.Size(162, 20);
			this.checkBoxQASegmentation.TabIndex = 17;
			this.checkBoxQASegmentation.Text = "Aufteilung nicht optimal";
			this.checkBoxQASegmentation.UseVisualStyleBackColor = true;
			this.checkBoxQASegmentation.CheckedChanged += new System.EventHandler(this.checkBoxQASegmentation_CheckedChanged);
			// 
			// checkBoxQAImages
			// 
			this.checkBoxQAImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxQAImages.AutoSize = true;
			this.checkBoxQAImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxQAImages.Location = new System.Drawing.Point(6, 125);
			this.checkBoxQAImages.Name = "checkBoxQAImages";
			this.checkBoxQAImages.Size = new System.Drawing.Size(101, 20);
			this.checkBoxQAImages.TabIndex = 15;
			this.checkBoxQAImages.Text = "Bilder fehlen";
			this.checkBoxQAImages.UseVisualStyleBackColor = true;
			this.checkBoxQAImages.CheckedChanged += new System.EventHandler(this.checkBoxQAImages_CheckedChanged);
			// 
			// checkBoxQATranslation
			// 
			this.checkBoxQATranslation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxQATranslation.AutoSize = true;
			this.checkBoxQATranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxQATranslation.Location = new System.Drawing.Point(6, 151);
			this.checkBoxQATranslation.Name = "checkBoxQATranslation";
			this.checkBoxQATranslation.Size = new System.Drawing.Size(229, 20);
			this.checkBoxQATranslation.TabIndex = 14;
			this.checkBoxQATranslation.Text = "Übersetzung fehlt/ist unvollständig";
			this.checkBoxQATranslation.UseVisualStyleBackColor = true;
			this.checkBoxQATranslation.CheckedChanged += new System.EventHandler(this.checkBoxQATranslation_CheckedChanged);
			// 
			// checkBoxQASpelling
			// 
			this.checkBoxQASpelling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxQASpelling.AutoSize = true;
			this.checkBoxQASpelling.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxQASpelling.Location = new System.Drawing.Point(6, 99);
			this.checkBoxQASpelling.Name = "checkBoxQASpelling";
			this.checkBoxQASpelling.Size = new System.Drawing.Size(136, 20);
			this.checkBoxQASpelling.TabIndex = 13;
			this.checkBoxQASpelling.Text = "Text enthält Fehler";
			this.checkBoxQASpelling.UseVisualStyleBackColor = true;
			this.checkBoxQASpelling.CheckedChanged += new System.EventHandler(this.checkBoxQASpelling_CheckedChanged);
			// 
			// comboBoxLanguage
			// 
			this.comboBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.comboBoxLanguage.FormattingEnabled = true;
			this.comboBoxLanguage.Location = new System.Drawing.Point(63, 396);
			this.comboBoxLanguage.Name = "comboBoxLanguage";
			this.comboBoxLanguage.Size = new System.Drawing.Size(198, 21);
			this.comboBoxLanguage.TabIndex = 10;
			this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
			this.comboBoxLanguage.Enter += new System.EventHandler(this.comboBoxLanguage_Enter);
			// 
			// checkedListBoxTags
			// 
			this.checkedListBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkedListBoxTags.CheckOnClick = true;
			this.checkedListBoxTags.ColumnWidth = 200;
			this.checkedListBoxTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkedListBoxTags.FormattingEnabled = true;
			this.checkedListBoxTags.Location = new System.Drawing.Point(63, 423);
			this.checkedListBoxTags.Name = "checkedListBoxTags";
			this.checkedListBoxTags.Size = new System.Drawing.Size(197, 72);
			this.checkedListBoxTags.Sorted = true;
			this.checkedListBoxTags.TabIndex = 9;
			this.checkedListBoxTags.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxTags_ItemCheck);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(7, 428);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Tags:";
			// 
			// buttonAddItem
			// 
			this.buttonAddItem.Location = new System.Drawing.Point(4, 4);
			this.buttonAddItem.Name = "buttonAddItem";
			this.buttonAddItem.Size = new System.Drawing.Size(78, 23);
			this.buttonAddItem.TabIndex = 13;
			this.buttonAddItem.Text = "Hinzufügen";
			this.buttonAddItem.UseVisualStyleBackColor = true;
			this.buttonAddItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonAddItem_MouseDown);
			// 
			// addContextMenu
			// 
			this.addContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liedteilToolStripMenuItem,
            this.folieToolStripMenuItem});
			this.addContextMenu.Name = "addContextMenu";
			this.addContextMenu.Size = new System.Drawing.Size(119, 48);
			this.addContextMenu.VisibleChanged += new System.EventHandler(this.addContextMenu_VisibleChanged);
			// 
			// liedteilToolStripMenuItem
			// 
			this.liedteilToolStripMenuItem.Name = "liedteilToolStripMenuItem";
			this.liedteilToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.liedteilToolStripMenuItem.Text = "Liedteil";
			// 
			// folieToolStripMenuItem
			// 
			this.folieToolStripMenuItem.Name = "folieToolStripMenuItem";
			this.folieToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.folieToolStripMenuItem.Text = "Folie";
			this.folieToolStripMenuItem.Click += new System.EventHandler(this.folieToolStripMenuItem_Click);
			// 
			// buttonDelItem
			// 
			this.buttonDelItem.Enabled = false;
			this.buttonDelItem.Location = new System.Drawing.Point(194, 4);
			this.buttonDelItem.Name = "buttonDelItem";
			this.buttonDelItem.Size = new System.Drawing.Size(63, 23);
			this.buttonDelItem.TabIndex = 14;
			this.buttonDelItem.Text = "Löschen";
			this.buttonDelItem.UseVisualStyleBackColor = true;
			this.buttonDelItem.Click += new System.EventHandler(this.buttonDelItem_Click);
			// 
			// buttonMoveUp
			// 
			this.buttonMoveUp.Enabled = false;
			this.buttonMoveUp.Location = new System.Drawing.Point(88, 4);
			this.buttonMoveUp.Name = "buttonMoveUp";
			this.buttonMoveUp.Size = new System.Drawing.Size(51, 23);
			this.buttonMoveUp.TabIndex = 16;
			this.buttonMoveUp.Text = "Auf";
			this.buttonMoveUp.UseVisualStyleBackColor = true;
			this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
			// 
			// buttonMoveDown
			// 
			this.buttonMoveDown.Enabled = false;
			this.buttonMoveDown.Location = new System.Drawing.Point(145, 4);
			this.buttonMoveDown.Name = "buttonMoveDown";
			this.buttonMoveDown.Size = new System.Drawing.Size(43, 23);
			this.buttonMoveDown.TabIndex = 17;
			this.buttonMoveDown.Text = "Ab";
			this.buttonMoveDown.UseVisualStyleBackColor = true;
			this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.textBoxComment);
			this.groupBox1.Controls.Add(this.checkBoxQASpelling);
			this.groupBox1.Controls.Add(this.checkBoxQAImages);
			this.groupBox1.Controls.Add(this.checkBoxQATranslation);
			this.groupBox1.Controls.Add(this.checkBoxQASegmentation);
			this.groupBox1.Location = new System.Drawing.Point(4, 501);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(257, 204);
			this.groupBox1.TabIndex = 69;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Qualitätssicherung";
			// 
			// textBoxSongTranslation
			// 
			this.textBoxSongTranslation.AcceptsReturn = true;
			this.textBoxSongTranslation.AcceptsTab = true;
			this.textBoxSongTranslation.AllowDrop = true;
			this.textBoxSongTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSongTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSongTranslation.Location = new System.Drawing.Point(6, 19);
			this.textBoxSongTranslation.Multiline = true;
			this.textBoxSongTranslation.Name = "textBoxSongTranslation";
			this.textBoxSongTranslation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxSongTranslation.ShortcutsEnabled = false;
			this.textBoxSongTranslation.Size = new System.Drawing.Size(331, 179);
			this.textBoxSongTranslation.TabIndex = 80;
			this.textBoxSongTranslation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSongTranslation_KeyUp);
			// 
			// comboBoxSlideVertOrientation
			// 
			this.comboBoxSlideVertOrientation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSlideVertOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSlideVertOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxSlideVertOrientation.FormattingEnabled = true;
			this.comboBoxSlideVertOrientation.Items.AddRange(new object[] {
            "Oben",
            "Mitte",
            "Unten"});
			this.comboBoxSlideVertOrientation.Location = new System.Drawing.Point(872, 441);
			this.comboBoxSlideVertOrientation.Name = "comboBoxSlideVertOrientation";
			this.comboBoxSlideVertOrientation.Size = new System.Drawing.Size(114, 24);
			this.comboBoxSlideVertOrientation.TabIndex = 74;
			this.comboBoxSlideVertOrientation.SelectedValueChanged += new System.EventHandler(this.comboBoxSlideVertOrientation_SelectedIndexChanged);
			// 
			// comboBoxSlideHorizOrientation
			// 
			this.comboBoxSlideHorizOrientation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSlideHorizOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSlideHorizOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxSlideHorizOrientation.FormattingEnabled = true;
			this.comboBoxSlideHorizOrientation.Items.AddRange(new object[] {
            "Linksbündig",
            "Zentriert",
            "Rechtsbündig"});
			this.comboBoxSlideHorizOrientation.Location = new System.Drawing.Point(752, 441);
			this.comboBoxSlideHorizOrientation.Name = "comboBoxSlideHorizOrientation";
			this.comboBoxSlideHorizOrientation.Size = new System.Drawing.Size(114, 24);
			this.comboBoxSlideHorizOrientation.TabIndex = 73;
			this.comboBoxSlideHorizOrientation.SelectedValueChanged += new System.EventHandler(this.comboBoxSlideHorizOrientation_SelectedIndexChanged);
			// 
			// buttonSlideBackground
			// 
			this.buttonSlideBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonSlideBackground.Location = new System.Drawing.Point(270, 441);
			this.buttonSlideBackground.Name = "buttonSlideBackground";
			this.buttonSlideBackground.Size = new System.Drawing.Size(114, 23);
			this.buttonSlideBackground.TabIndex = 72;
			this.buttonSlideBackground.Text = "Hintergrundbild...";
			this.buttonSlideBackground.UseVisualStyleBackColor = true;
			this.buttonSlideBackground.Click += new System.EventHandler(this.buttonSlideBackground_Click);
			// 
			// textBoxSongText
			// 
			this.textBoxSongText.AcceptsReturn = true;
			this.textBoxSongText.AcceptsTab = true;
			this.textBoxSongText.AllowDrop = true;
			this.textBoxSongText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSongText.Location = new System.Drawing.Point(6, 19);
			this.textBoxSongText.Multiline = true;
			this.textBoxSongText.Name = "textBoxSongText";
			this.textBoxSongText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxSongText.Size = new System.Drawing.Size(355, 179);
			this.textBoxSongText.TabIndex = 70;
			this.textBoxSongText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSongText_KeyUp);
			// 
			// pictureBoxPreview
			// 
			this.pictureBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxPreview.Location = new System.Drawing.Point(267, 4);
			this.pictureBoxPreview.Name = "pictureBoxPreview";
			this.pictureBoxPreview.Size = new System.Drawing.Size(719, 430);
			this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxPreview.TabIndex = 71;
			this.pictureBoxPreview.TabStop = false;
			this.pictureBoxPreview.DoubleClick += new System.EventHandler(this.buttonSlideBackground_Click);
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
			this.slideContextMenu.Size = new System.Drawing.Size(138, 136);
			// 
			// neueFolieToolStripMenuItem
			// 
			this.neueFolieToolStripMenuItem.Name = "neueFolieToolStripMenuItem";
			this.neueFolieToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.neueFolieToolStripMenuItem.Text = "Neue Folie";
			this.neueFolieToolStripMenuItem.Click += new System.EventHandler(this.neueFolieToolStripMenuItem_Click);
			// 
			// aufToolStripMenuItem
			// 
			this.aufToolStripMenuItem.Name = "aufToolStripMenuItem";
			this.aufToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.aufToolStripMenuItem.Text = "Auf";
			this.aufToolStripMenuItem.Click += new System.EventHandler(this.aufToolStripMenuItem_Click);
			// 
			// abToolStripMenuItem
			// 
			this.abToolStripMenuItem.Name = "abToolStripMenuItem";
			this.abToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.abToolStripMenuItem.Text = "Ab";
			this.abToolStripMenuItem.Click += new System.EventHandler(this.abToolStripMenuItem_Click);
			// 
			// löschenToolStripMenuItem
			// 
			this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
			this.löschenToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.löschenToolStripMenuItem.Text = "Duplizieren";
			this.löschenToolStripMenuItem.Click += new System.EventHandler(this.löschenToolStripMenuItem_Click);
			// 
			// teilenToolStripMenuItem
			// 
			this.teilenToolStripMenuItem.Name = "teilenToolStripMenuItem";
			this.teilenToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.teilenToolStripMenuItem.Text = "Teilen";
			this.teilenToolStripMenuItem.Click += new System.EventHandler(this.teilenToolStripMenuItem_Click);
			// 
			// löschenToolStripMenuItem1
			// 
			this.löschenToolStripMenuItem1.Name = "löschenToolStripMenuItem1";
			this.löschenToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
			this.löschenToolStripMenuItem1.Text = "Löschen";
			this.löschenToolStripMenuItem1.Click += new System.EventHandler(this.löschenToolStripMenuItem1_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.buttonChooseProjectionForeColor);
			this.groupBox2.Controls.Add(this.labelFont);
			this.groupBox2.Controls.Add(this.buttonProjectionMasterFont);
			this.groupBox2.Controls.Add(this.textBoxSongText);
			this.groupBox2.Location = new System.Drawing.Point(270, 471);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(367, 234);
			this.groupBox2.TabIndex = 82;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Liedtext";
			// 
			// buttonChooseProjectionForeColor
			// 
			this.buttonChooseProjectionForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonChooseProjectionForeColor.Location = new System.Drawing.Point(112, 204);
			this.buttonChooseProjectionForeColor.Name = "buttonChooseProjectionForeColor";
			this.buttonChooseProjectionForeColor.Size = new System.Drawing.Size(25, 23);
			this.buttonChooseProjectionForeColor.TabIndex = 71;
			this.buttonChooseProjectionForeColor.UseVisualStyleBackColor = true;
			this.buttonChooseProjectionForeColor.Click += new System.EventHandler(this.buttonChooseProjectionForeColor_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.buttonTranslationColor);
			this.groupBox3.Controls.Add(this.textBoxSongTranslation);
			this.groupBox3.Controls.Add(this.buttonTranslationFont);
			this.groupBox3.Controls.Add(this.labelFontTranslation);
			this.groupBox3.Location = new System.Drawing.Point(643, 471);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(343, 234);
			this.groupBox3.TabIndex = 83;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Übersetzung";
			// 
			// buttonTranslationColor
			// 
			this.buttonTranslationColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonTranslationColor.Location = new System.Drawing.Point(112, 204);
			this.buttonTranslationColor.Name = "buttonTranslationColor";
			this.buttonTranslationColor.Size = new System.Drawing.Size(25, 23);
			this.buttonTranslationColor.TabIndex = 72;
			this.buttonTranslationColor.UseVisualStyleBackColor = true;
			this.buttonTranslationColor.Click += new System.EventHandler(this.buttonTranslationColor_Click);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(390, 447);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 84;
			this.label2.Text = "Zeilenabstand:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(646, 447);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 13);
			this.label3.TabIndex = 85;
			this.label3.Text = "Textausrichtung:";
			// 
			// partContextMenu
			// 
			this.partContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.umbenennenToolStripMenuItem,
            this.löschenToolStripMenuItem2});
			this.partContextMenu.Name = "partContextMenu";
			this.partContextMenu.Size = new System.Drawing.Size(149, 48);
			// 
			// umbenennenToolStripMenuItem
			// 
			this.umbenennenToolStripMenuItem.Name = "umbenennenToolStripMenuItem";
			this.umbenennenToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.umbenennenToolStripMenuItem.Text = "Umbenennen";
			this.umbenennenToolStripMenuItem.Click += new System.EventHandler(this.umbenennenToolStripMenuItem_Click);
			// 
			// löschenToolStripMenuItem2
			// 
			this.löschenToolStripMenuItem2.Name = "löschenToolStripMenuItem2";
			this.löschenToolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
			this.löschenToolStripMenuItem2.Text = "Löschen";
			this.löschenToolStripMenuItem2.Click += new System.EventHandler(this.löschenToolStripMenuItem2_Click);
			// 
			// songContextMenu
			// 
			this.songContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.umbenennenToolStripMenuItem1});
			this.songContextMenu.Name = "songContextMenu";
			this.songContextMenu.Size = new System.Drawing.Size(149, 26);
			// 
			// umbenennenToolStripMenuItem1
			// 
			this.umbenennenToolStripMenuItem1.Name = "umbenennenToolStripMenuItem1";
			this.umbenennenToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
			this.umbenennenToolStripMenuItem1.Text = "Umbenennen";
			this.umbenennenToolStripMenuItem1.Click += new System.EventHandler(this.umbenennenToolStripMenuItem1_Click);
			// 
			// treeViewContents
			// 
			this.treeViewContents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.treeViewContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.treeViewContents.HideSelection = false;
			this.treeViewContents.Location = new System.Drawing.Point(4, 35);
			this.treeViewContents.Name = "treeViewContents";
			this.treeViewContents.Size = new System.Drawing.Size(253, 355);
			this.treeViewContents.TabIndex = 0;
			this.treeViewContents.ValidateLabelEdit += new TreeEx.TreeLE.ValidateLabelEditEventHandler(this.treeViewContents_ValidateLabelEdit);
			this.treeViewContents.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewContents_AfterLabelEdit);
			this.treeViewContents.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewContents_AfterSelect);
			this.treeViewContents.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewContents_BeforeLabelEdit);
			this.treeViewContents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewContents_KeyDown);
			// 
			// EditorChild
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(992, 710);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.pictureBoxPreview);
			this.Controls.Add(this.comboBoxSlideVertOrientation);
			this.Controls.Add(this.buttonMoveDown);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.buttonMoveUp);
			this.Controls.Add(this.buttonDelItem);
			this.Controls.Add(this.buttonAddItem);
			this.Controls.Add(this.labelLineSpacing);
			this.Controls.Add(this.buttonSlideBackground);
			this.Controls.Add(this.comboBoxSlideHorizOrientation);
			this.Controls.Add(this.treeViewContents);
			this.Controls.Add(this.comboBoxLanguage);
			this.Controls.Add(this.checkedListBoxTags);
			this.Controls.Add(this.labelLanguage);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.trackBarLineSpacing);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "EditorChild";
			this.ShowInTaskbar = false;
			this.Text = "Liededitor";
			this.Load += new System.EventHandler(this.EditorChild_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorChild_FormClosing);
			this.Resize += new System.EventHandler(this.EditorChild_Resize);
			((System.ComponentModel.ISupportInitialize)(this.trackBarLineSpacing)).EndInit();
			this.addContextMenu.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
			this.slideContextMenu.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.partContextMenu.ResumeLayout(false);
			this.songContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion


		private TreeEx.TreeLE treeViewContents;
		private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.CheckedListBox checkedListBoxTags;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Button buttonAddItem;
		private System.Windows.Forms.Button buttonDelItem;
        private System.Windows.Forms.Button buttonMoveUp;
		private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.CheckBox checkBoxQASpelling;
        private System.Windows.Forms.CheckBox checkBoxQAImages;
		private System.Windows.Forms.CheckBox checkBoxQATranslation;
		private System.Windows.Forms.CheckBox checkBoxQASegmentation;
        private System.Windows.Forms.Button buttonProjectionMasterFont;
		private System.Windows.Forms.Label labelLineSpacing;
        private System.Windows.Forms.TrackBar trackBarLineSpacing;
		private System.Windows.Forms.Button buttonTranslationFont;
        private System.Windows.Forms.Label labelFontTranslation;
		private System.Windows.Forms.Label labelFont;
		private System.Windows.Forms.TextBox textBoxComment;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBoxSongTranslation;
		private System.Windows.Forms.ComboBox comboBoxSlideVertOrientation;
		private System.Windows.Forms.ComboBox comboBoxSlideHorizOrientation;
		private System.Windows.Forms.Button buttonSlideBackground;
		private System.Windows.Forms.TextBox textBoxSongText;
		private System.Windows.Forms.PictureBox pictureBoxPreview;
		private System.Windows.Forms.ContextMenuStrip addContextMenu;
		private System.Windows.Forms.ToolStripMenuItem liedteilToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem folieToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip slideContextMenu;
		private System.Windows.Forms.ToolStripMenuItem aufToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem abToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem teilenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button buttonChooseProjectionForeColor;
		private System.Windows.Forms.Button buttonTranslationColor;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ToolStripMenuItem neueFolieToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip partContextMenu;
		private System.Windows.Forms.ToolStripMenuItem umbenennenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem2;
		private System.Windows.Forms.ContextMenuStrip songContextMenu;
		private System.Windows.Forms.ToolStripMenuItem umbenennenToolStripMenuItem1;
    }
}