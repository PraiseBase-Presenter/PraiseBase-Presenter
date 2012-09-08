namespace Pbp.Forms
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
            this.songContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.umbenennenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageFormatting = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListBoxTags = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxQASegmentation = new System.Windows.Forms.CheckBox();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.checkBoxQATranslation = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBoxQASpelling = new System.Windows.Forms.CheckBox();
            this.checkBoxQAImages = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.trackBarLineSpacing = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.labelLineSpacing = new System.Windows.Forms.Label();
            this.labelFont = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelFontTranslation = new System.Windows.Forms.Label();
            this.buttonTranslationFont = new System.Windows.Forms.Button();
            this.buttonProjectionMasterFont = new System.Windows.Forms.Button();
            this.buttonChooseProjectionForeColor = new System.Windows.Forms.Button();
            this.buttonTranslationColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageContent = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSlideVertOrientation = new System.Windows.Forms.ComboBox();
            this.comboBoxSlideHorizOrientation = new System.Windows.Forms.ComboBox();
            this.buttonDuplicateSlide = new System.Windows.Forms.Button();
            this.textBoxCCLISongID = new System.Windows.Forms.TextBox();
            this.textBoxCopyright = new System.Windows.Forms.TextBox();
            this.textBoxSongTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonAddSlide = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxPartCaption = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.textBoxSongText = new System.Windows.Forms.TextBox();
            this.textBoxPartCaptionTranslated = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSongTranslation = new System.Windows.Forms.TextBox();
            this.comboBoxLanguageTranslated = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonDelItem = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.tabControlTextLayer = new System.Windows.Forms.TabControl();
            this.treeViewContents = new TreeEx.TreeLE();
            this.slideContextMenu.SuspendLayout();
            this.partContextMenu.SuspendLayout();
            this.songContextMenu.SuspendLayout();
            this.tabPageFormatting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLineSpacing)).BeginInit();
            this.tabPageContent.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.tabControlTextLayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // addContextMenu
            // 
            this.addContextMenu.Name = "addContextMenu";
            this.addContextMenu.Size = new System.Drawing.Size(61, 4);
            this.addContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.addContextMenu_Opening);
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
            this.slideContextMenu.Size = new System.Drawing.Size(134, 136);
            // 
            // neueFolieToolStripMenuItem
            // 
            this.neueFolieToolStripMenuItem.Name = "neueFolieToolStripMenuItem";
            this.neueFolieToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.neueFolieToolStripMenuItem.Text = "Neue Folie";
            this.neueFolieToolStripMenuItem.Click += new System.EventHandler(this.neueFolieToolStripMenuItem_Click);
            // 
            // aufToolStripMenuItem
            // 
            this.aufToolStripMenuItem.Name = "aufToolStripMenuItem";
            this.aufToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.aufToolStripMenuItem.Text = "Auf";
            this.aufToolStripMenuItem.Click += new System.EventHandler(this.aufToolStripMenuItem_Click);
            // 
            // abToolStripMenuItem
            // 
            this.abToolStripMenuItem.Name = "abToolStripMenuItem";
            this.abToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.abToolStripMenuItem.Text = "Ab";
            this.abToolStripMenuItem.Click += new System.EventHandler(this.abToolStripMenuItem_Click);
            // 
            // löschenToolStripMenuItem
            // 
            this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
            this.löschenToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.löschenToolStripMenuItem.Text = "Duplizieren";
            this.löschenToolStripMenuItem.Click += new System.EventHandler(this.löschenToolStripMenuItem_Click);
            // 
            // teilenToolStripMenuItem
            // 
            this.teilenToolStripMenuItem.Name = "teilenToolStripMenuItem";
            this.teilenToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.teilenToolStripMenuItem.Text = "Teilen";
            this.teilenToolStripMenuItem.Click += new System.EventHandler(this.teilenToolStripMenuItem_Click);
            // 
            // löschenToolStripMenuItem1
            // 
            this.löschenToolStripMenuItem1.Name = "löschenToolStripMenuItem1";
            this.löschenToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.löschenToolStripMenuItem1.Text = "Löschen";
            this.löschenToolStripMenuItem1.Click += new System.EventHandler(this.löschenToolStripMenuItem1_Click);
            // 
            // partContextMenu
            // 
            this.partContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.umbenennenToolStripMenuItem,
            this.löschenToolStripMenuItem2});
            this.partContextMenu.Name = "partContextMenu";
            this.partContextMenu.Size = new System.Drawing.Size(147, 48);
            // 
            // umbenennenToolStripMenuItem
            // 
            this.umbenennenToolStripMenuItem.Name = "umbenennenToolStripMenuItem";
            this.umbenennenToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.umbenennenToolStripMenuItem.Text = "Umbenennen";
            this.umbenennenToolStripMenuItem.Click += new System.EventHandler(this.umbenennenToolStripMenuItem_Click);
            // 
            // löschenToolStripMenuItem2
            // 
            this.löschenToolStripMenuItem2.Name = "löschenToolStripMenuItem2";
            this.löschenToolStripMenuItem2.Size = new System.Drawing.Size(146, 22);
            this.löschenToolStripMenuItem2.Text = "Löschen";
            this.löschenToolStripMenuItem2.Click += new System.EventHandler(this.löschenToolStripMenuItem2_Click);
            // 
            // songContextMenu
            // 
            this.songContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.umbenennenToolStripMenuItem1});
            this.songContextMenu.Name = "songContextMenu";
            this.songContextMenu.Size = new System.Drawing.Size(147, 26);
            // 
            // umbenennenToolStripMenuItem1
            // 
            this.umbenennenToolStripMenuItem1.Name = "umbenennenToolStripMenuItem1";
            this.umbenennenToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.umbenennenToolStripMenuItem1.Text = "Umbenennen";
            this.umbenennenToolStripMenuItem1.Click += new System.EventHandler(this.umbenennenToolStripMenuItem1_Click);
            // 
            // tabPageFormatting
            // 
            this.tabPageFormatting.Controls.Add(this.groupBox1);
            this.tabPageFormatting.Controls.Add(this.groupBox4);
            this.tabPageFormatting.Controls.Add(this.groupBox2);
            this.tabPageFormatting.Controls.Add(this.label2);
            this.tabPageFormatting.Location = new System.Drawing.Point(4, 29);
            this.tabPageFormatting.Name = "tabPageFormatting";
            this.tabPageFormatting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFormatting.Size = new System.Drawing.Size(970, 529);
            this.tabPageFormatting.TabIndex = 3;
            this.tabPageFormatting.Text = "Sonstiges";
            this.tabPageFormatting.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.checkedListBoxTags);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 345);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tags";
            // 
            // checkedListBoxTags
            // 
            this.checkedListBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBoxTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxTags.CheckOnClick = true;
            this.checkedListBoxTags.FormattingEnabled = true;
            this.checkedListBoxTags.Location = new System.Drawing.Point(9, 19);
            this.checkedListBoxTags.Name = "checkedListBoxTags";
            this.checkedListBoxTags.Size = new System.Drawing.Size(273, 317);
            this.checkedListBoxTags.TabIndex = 99;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.checkBoxQASegmentation);
            this.groupBox4.Controls.Add(this.textBoxComment);
            this.groupBox4.Controls.Add(this.checkBoxQATranslation);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.checkBoxQASpelling);
            this.groupBox4.Controls.Add(this.checkBoxQAImages);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(470, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(494, 517);
            this.groupBox4.TabIndex = 103;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Qualitätssicherung";
            // 
            // checkBoxQASegmentation
            // 
            this.checkBoxQASegmentation.AutoSize = true;
            this.checkBoxQASegmentation.Location = new System.Drawing.Point(109, 278);
            this.checkBoxQASegmentation.Name = "checkBoxQASegmentation";
            this.checkBoxQASegmentation.Size = new System.Drawing.Size(159, 17);
            this.checkBoxQASegmentation.TabIndex = 98;
            this.checkBoxQASegmentation.Text = "Aufteilung nicht optimal";
            this.checkBoxQASegmentation.UseVisualStyleBackColor = true;
            // 
            // textBoxComment
            // 
            this.textBoxComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxComment.Location = new System.Drawing.Point(109, 28);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(379, 175);
            this.textBoxComment.TabIndex = 93;
            // 
            // checkBoxQATranslation
            // 
            this.checkBoxQATranslation.AutoSize = true;
            this.checkBoxQATranslation.Location = new System.Drawing.Point(109, 255);
            this.checkBoxQATranslation.Name = "checkBoxQATranslation";
            this.checkBoxQATranslation.Size = new System.Drawing.Size(213, 17);
            this.checkBoxQATranslation.TabIndex = 97;
            this.checkBoxQATranslation.Text = "Übersetzung fehlt oder fehlerhaft";
            this.checkBoxQATranslation.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(7, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 92;
            this.label13.Text = "Kommentar:";
            // 
            // checkBoxQASpelling
            // 
            this.checkBoxQASpelling.AutoSize = true;
            this.checkBoxQASpelling.Location = new System.Drawing.Point(109, 232);
            this.checkBoxQASpelling.Name = "checkBoxQASpelling";
            this.checkBoxQASpelling.Size = new System.Drawing.Size(167, 17);
            this.checkBoxQASpelling.TabIndex = 96;
            this.checkBoxQASpelling.Text = "Text fehlt oder fehlerhaft";
            this.checkBoxQASpelling.UseVisualStyleBackColor = true;
            // 
            // checkBoxQAImages
            // 
            this.checkBoxQAImages.AutoSize = true;
            this.checkBoxQAImages.Location = new System.Drawing.Point(110, 209);
            this.checkBoxQAImages.Name = "checkBoxQAImages";
            this.checkBoxQAImages.Size = new System.Drawing.Size(97, 17);
            this.checkBoxQAImages.TabIndex = 94;
            this.checkBoxQAImages.Text = "Bilder fehlen";
            this.checkBoxQAImages.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(7, 209);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 95;
            this.label14.Text = "Markierungen:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.trackBarLineSpacing);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.labelLineSpacing);
            this.groupBox2.Controls.Add(this.labelFont);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.labelFontTranslation);
            this.groupBox2.Controls.Add(this.buttonTranslationFont);
            this.groupBox2.Controls.Add(this.buttonProjectionMasterFont);
            this.groupBox2.Controls.Add(this.buttonChooseProjectionForeColor);
            this.groupBox2.Controls.Add(this.buttonTranslationColor);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 166);
            this.groupBox2.TabIndex = 99;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Schrift und Farbe";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 98;
            this.label10.Text = "Zeilenabstand:";
            // 
            // trackBarLineSpacing
            // 
            this.trackBarLineSpacing.BackColor = System.Drawing.SystemColors.Window;
            this.trackBarLineSpacing.Location = new System.Drawing.Point(86, 109);
            this.trackBarLineSpacing.Maximum = 50;
            this.trackBarLineSpacing.Name = "trackBarLineSpacing";
            this.trackBarLineSpacing.Size = new System.Drawing.Size(196, 45);
            this.trackBarLineSpacing.TabIndex = 86;
            this.trackBarLineSpacing.TickFrequency = 5;
            this.trackBarLineSpacing.Scroll += new System.EventHandler(this.trackBarLineSpacing_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 98;
            this.label9.Text = "Übersetzung:";
            // 
            // labelLineSpacing
            // 
            this.labelLineSpacing.AutoSize = true;
            this.labelLineSpacing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLineSpacing.Location = new System.Drawing.Point(288, 104);
            this.labelLineSpacing.Name = "labelLineSpacing";
            this.labelLineSpacing.Size = new System.Drawing.Size(14, 20);
            this.labelLineSpacing.TabIndex = 87;
            this.labelLineSpacing.Text = "-";
            // 
            // labelFont
            // 
            this.labelFont.AutoSize = true;
            this.labelFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFont.Location = new System.Drawing.Point(231, 27);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(14, 20);
            this.labelFont.TabIndex = 60;
            this.labelFont.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 97;
            this.label8.Text = "Liedtext:";
            // 
            // labelFontTranslation
            // 
            this.labelFontTranslation.AutoSize = true;
            this.labelFontTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFontTranslation.Location = new System.Drawing.Point(230, 65);
            this.labelFontTranslation.Name = "labelFontTranslation";
            this.labelFontTranslation.Size = new System.Drawing.Size(14, 20);
            this.labelFontTranslation.TabIndex = 62;
            this.labelFontTranslation.Text = "-";
            // 
            // buttonTranslationFont
            // 
            this.buttonTranslationFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTranslationFont.Location = new System.Drawing.Point(125, 64);
            this.buttonTranslationFont.Name = "buttonTranslationFont";
            this.buttonTranslationFont.Size = new System.Drawing.Size(100, 23);
            this.buttonTranslationFont.TabIndex = 57;
            this.buttonTranslationFont.Text = "Schrift wählen...";
            this.buttonTranslationFont.UseVisualStyleBackColor = true;
            this.buttonTranslationFont.Click += new System.EventHandler(this.buttonTranslationFont_Click);
            // 
            // buttonProjectionMasterFont
            // 
            this.buttonProjectionMasterFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProjectionMasterFont.Location = new System.Drawing.Point(125, 27);
            this.buttonProjectionMasterFont.Name = "buttonProjectionMasterFont";
            this.buttonProjectionMasterFont.Size = new System.Drawing.Size(100, 23);
            this.buttonProjectionMasterFont.TabIndex = 56;
            this.buttonProjectionMasterFont.Text = "Schrift wählen...";
            this.buttonProjectionMasterFont.UseVisualStyleBackColor = true;
            this.buttonProjectionMasterFont.Click += new System.EventHandler(this.buttonProjectionMasterFont_Click);
            // 
            // buttonChooseProjectionForeColor
            // 
            this.buttonChooseProjectionForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChooseProjectionForeColor.Location = new System.Drawing.Point(94, 27);
            this.buttonChooseProjectionForeColor.Name = "buttonChooseProjectionForeColor";
            this.buttonChooseProjectionForeColor.Size = new System.Drawing.Size(25, 23);
            this.buttonChooseProjectionForeColor.TabIndex = 71;
            this.buttonChooseProjectionForeColor.UseVisualStyleBackColor = true;
            this.buttonChooseProjectionForeColor.Click += new System.EventHandler(this.buttonChooseProjectionForeColor_Click);
            // 
            // buttonTranslationColor
            // 
            this.buttonTranslationColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTranslationColor.Location = new System.Drawing.Point(94, 64);
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
            this.label2.Location = new System.Drawing.Point(170, 578);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 90;
            this.label2.Text = "Zeilenabstand:";
            // 
            // tabPageContent
            // 
            this.tabPageContent.Controls.Add(this.label1);
            this.tabPageContent.Controls.Add(this.label3);
            this.tabPageContent.Controls.Add(this.comboBoxSlideVertOrientation);
            this.tabPageContent.Controls.Add(this.comboBoxSlideHorizOrientation);
            this.tabPageContent.Controls.Add(this.buttonDuplicateSlide);
            this.tabPageContent.Controls.Add(this.textBoxCCLISongID);
            this.tabPageContent.Controls.Add(this.textBoxCopyright);
            this.tabPageContent.Controls.Add(this.textBoxSongTitle);
            this.tabPageContent.Controls.Add(this.label4);
            this.tabPageContent.Controls.Add(this.label7);
            this.tabPageContent.Controls.Add(this.label12);
            this.tabPageContent.Controls.Add(this.buttonAddSlide);
            this.tabPageContent.Controls.Add(this.splitContainer1);
            this.tabPageContent.Controls.Add(this.label11);
            this.tabPageContent.Controls.Add(this.pictureBoxPreview);
            this.tabPageContent.Controls.Add(this.treeViewContents);
            this.tabPageContent.Controls.Add(this.buttonAddItem);
            this.tabPageContent.Controls.Add(this.buttonMoveUp);
            this.tabPageContent.Controls.Add(this.buttonDelItem);
            this.tabPageContent.Controls.Add(this.buttonMoveDown);
            this.tabPageContent.Location = new System.Drawing.Point(4, 29);
            this.tabPageContent.Name = "tabPageContent";
            this.tabPageContent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageContent.Size = new System.Drawing.Size(970, 529);
            this.tabPageContent.TabIndex = 0;
            this.tabPageContent.Text = "Inhalt";
            this.tabPageContent.UseVisualStyleBackColor = true;
            this.tabPageContent.Click += new System.EventHandler(this.tabPageContent_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(635, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 108;
            this.label1.Text = "Formatierung";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(635, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 107;
            this.label3.Text = "Textausrichtung:";
            // 
            // comboBoxSlideVertOrientation
            // 
            this.comboBoxSlideVertOrientation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxSlideVertOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSlideVertOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSlideVertOrientation.FormattingEnabled = true;
            this.comboBoxSlideVertOrientation.Items.AddRange(new object[] {
            "Oben",
            "Mitte",
            "Unten"});
            this.comboBoxSlideVertOrientation.Location = new System.Drawing.Point(847, 343);
            this.comboBoxSlideVertOrientation.Name = "comboBoxSlideVertOrientation";
            this.comboBoxSlideVertOrientation.Size = new System.Drawing.Size(114, 24);
            this.comboBoxSlideVertOrientation.TabIndex = 106;
            // 
            // comboBoxSlideHorizOrientation
            // 
            this.comboBoxSlideHorizOrientation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxSlideHorizOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSlideHorizOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSlideHorizOrientation.FormattingEnabled = true;
            this.comboBoxSlideHorizOrientation.Items.AddRange(new object[] {
            "Linksbündig",
            "Zentriert",
            "Rechtsbündig"});
            this.comboBoxSlideHorizOrientation.Location = new System.Drawing.Point(727, 343);
            this.comboBoxSlideHorizOrientation.Name = "comboBoxSlideHorizOrientation";
            this.comboBoxSlideHorizOrientation.Size = new System.Drawing.Size(114, 24);
            this.comboBoxSlideHorizOrientation.TabIndex = 105;
            // 
            // buttonDuplicateSlide
            // 
            this.buttonDuplicateSlide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDuplicateSlide.Enabled = false;
            this.buttonDuplicateSlide.Image = global::Pbp.Properties.Resources.editcopy;
            this.buttonDuplicateSlide.Location = new System.Drawing.Point(194, 314);
            this.buttonDuplicateSlide.Name = "buttonDuplicateSlide";
            this.buttonDuplicateSlide.Size = new System.Drawing.Size(26, 23);
            this.buttonDuplicateSlide.TabIndex = 104;
            this.buttonDuplicateSlide.UseVisualStyleBackColor = true;
            this.buttonDuplicateSlide.Click += new System.EventHandler(this.buttonSlideDuplicate_Click);
            // 
            // textBoxCCLISongID
            // 
            this.textBoxCCLISongID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCCLISongID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCCLISongID.Location = new System.Drawing.Point(318, 343);
            this.textBoxCCLISongID.Name = "textBoxCCLISongID";
            this.textBoxCCLISongID.Size = new System.Drawing.Size(110, 22);
            this.textBoxCCLISongID.TabIndex = 88;
            // 
            // textBoxCopyright
            // 
            this.textBoxCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCopyright.Location = new System.Drawing.Point(318, 371);
            this.textBoxCopyright.Name = "textBoxCopyright";
            this.textBoxCopyright.Size = new System.Drawing.Size(275, 22);
            this.textBoxCopyright.TabIndex = 90;
            // 
            // textBoxSongTitle
            // 
            this.textBoxSongTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSongTitle.Location = new System.Drawing.Point(11, 36);
            this.textBoxSongTitle.Name = "textBoxSongTitle";
            this.textBoxSongTitle.Size = new System.Drawing.Size(238, 22);
            this.textBoxSongTitle.TabIndex = 1;
            this.textBoxSongTitle.TextChanged += new System.EventHandler(this.textBoxSongTitle_TextChanged);
            this.textBoxSongTitle.Enter += new System.EventHandler(this.textBoxSongTitle_Enter);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(256, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "Copyright:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(256, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 103;
            this.label7.Text = "Informationen";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(256, 348);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 89;
            this.label12.Text = "CCLI ID:";
            // 
            // buttonAddSlide
            // 
            this.buttonAddSlide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddSlide.Image = global::Pbp.Properties.Resources.edit_add;
            this.buttonAddSlide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddSlide.Location = new System.Drawing.Point(77, 314);
            this.buttonAddSlide.Name = "buttonAddSlide";
            this.buttonAddSlide.Size = new System.Drawing.Size(54, 23);
            this.buttonAddSlide.TabIndex = 97;
            this.buttonAddSlide.Text = "Folie";
            this.buttonAddSlide.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAddSlide.UseVisualStyleBackColor = true;
            this.buttonAddSlide.Click += new System.EventHandler(this.buttonAddSlide_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(253, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxPartCaption);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxLanguage);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxSongText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxPartCaptionTranslated);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxSongTranslation);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxLanguageTranslated);
            this.splitContainer1.Size = new System.Drawing.Size(714, 317);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 101;
            // 
            // textBoxPartCaption
            // 
            this.textBoxPartCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPartCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPartCaption.Location = new System.Drawing.Point(6, 36);
            this.textBoxPartCaption.Name = "textBoxPartCaption";
            this.textBoxPartCaption.Size = new System.Drawing.Size(222, 22);
            this.textBoxPartCaption.TabIndex = 97;
            this.textBoxPartCaption.TextChanged += new System.EventHandler(this.textBoxPartCaption_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 96;
            this.label5.Text = "Liedtext";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(234, 34);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(120, 24);
            this.comboBoxLanguage.TabIndex = 10;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            this.comboBoxLanguage.Enter += new System.EventHandler(this.comboBoxLanguage_Enter);
            // 
            // textBoxSongText
            // 
            this.textBoxSongText.AcceptsReturn = true;
            this.textBoxSongText.AcceptsTab = true;
            this.textBoxSongText.AllowDrop = true;
            this.textBoxSongText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSongText.Location = new System.Drawing.Point(6, 64);
            this.textBoxSongText.Multiline = true;
            this.textBoxSongText.Name = "textBoxSongText";
            this.textBoxSongText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSongText.Size = new System.Drawing.Size(348, 243);
            this.textBoxSongText.TabIndex = 2;
            this.textBoxSongText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSongText_KeyUp);
            // 
            // textBoxPartCaptionTranslated
            // 
            this.textBoxPartCaptionTranslated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPartCaptionTranslated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPartCaptionTranslated.Location = new System.Drawing.Point(3, 36);
            this.textBoxPartCaptionTranslated.Name = "textBoxPartCaptionTranslated";
            this.textBoxPartCaptionTranslated.Size = new System.Drawing.Size(224, 22);
            this.textBoxPartCaptionTranslated.TabIndex = 100;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 97;
            this.label6.Text = "Übersetzung";
            // 
            // textBoxSongTranslation
            // 
            this.textBoxSongTranslation.AcceptsReturn = true;
            this.textBoxSongTranslation.AcceptsTab = true;
            this.textBoxSongTranslation.AllowDrop = true;
            this.textBoxSongTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSongTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSongTranslation.Location = new System.Drawing.Point(3, 64);
            this.textBoxSongTranslation.Multiline = true;
            this.textBoxSongTranslation.Name = "textBoxSongTranslation";
            this.textBoxSongTranslation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSongTranslation.Size = new System.Drawing.Size(350, 243);
            this.textBoxSongTranslation.TabIndex = 80;
            this.textBoxSongTranslation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSongTranslation_KeyUp);
            // 
            // comboBoxLanguageTranslated
            // 
            this.comboBoxLanguageTranslated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLanguageTranslated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLanguageTranslated.FormattingEnabled = true;
            this.comboBoxLanguageTranslated.Location = new System.Drawing.Point(233, 34);
            this.comboBoxLanguageTranslated.Name = "comboBoxLanguageTranslated";
            this.comboBoxLanguageTranslated.Size = new System.Drawing.Size(120, 24);
            this.comboBoxLanguageTranslated.TabIndex = 99;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 100;
            this.label11.Text = "Titel und Struktur";
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxPreview.BackColor = System.Drawing.Color.Black;
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPreview.Location = new System.Drawing.Point(6, 343);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(240, 180);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPreview.TabIndex = 95;
            this.pictureBoxPreview.TabStop = false;
            this.pictureBoxPreview.Click += new System.EventHandler(this.buttonSlideBackground_Click);
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddItem.Image = global::Pbp.Properties.Resources.edit_add;
            this.buttonAddItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddItem.Location = new System.Drawing.Point(6, 314);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(65, 23);
            this.buttonAddItem.TabIndex = 13;
            this.buttonAddItem.Text = "Liedteil";
            this.buttonAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonAddItem_MouseDown);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMoveUp.Enabled = false;
            this.buttonMoveUp.Image = global::Pbp.Properties.Resources.arrowup;
            this.buttonMoveUp.Location = new System.Drawing.Point(135, 314);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(26, 23);
            this.buttonMoveUp.TabIndex = 16;
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonDelItem
            // 
            this.buttonDelItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelItem.Enabled = false;
            this.buttonDelItem.Image = global::Pbp.Properties.Resources.edit_remove;
            this.buttonDelItem.Location = new System.Drawing.Point(223, 314);
            this.buttonDelItem.Name = "buttonDelItem";
            this.buttonDelItem.Size = new System.Drawing.Size(26, 23);
            this.buttonDelItem.TabIndex = 14;
            this.buttonDelItem.UseVisualStyleBackColor = true;
            this.buttonDelItem.Click += new System.EventHandler(this.buttonDelItem_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMoveDown.Enabled = false;
            this.buttonMoveDown.Image = global::Pbp.Properties.Resources.arrowdown;
            this.buttonMoveDown.Location = new System.Drawing.Point(165, 314);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(26, 23);
            this.buttonMoveDown.TabIndex = 17;
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // tabControlTextLayer
            // 
            this.tabControlTextLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlTextLayer.Controls.Add(this.tabPageContent);
            this.tabControlTextLayer.Controls.Add(this.tabPageFormatting);
            this.tabControlTextLayer.ItemSize = new System.Drawing.Size(60, 25);
            this.tabControlTextLayer.Location = new System.Drawing.Point(4, 3);
            this.tabControlTextLayer.Name = "tabControlTextLayer";
            this.tabControlTextLayer.SelectedIndex = 0;
            this.tabControlTextLayer.Size = new System.Drawing.Size(978, 562);
            this.tabControlTextLayer.TabIndex = 88;
            // 
            // treeViewContents
            // 
            this.treeViewContents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewContents.HideSelection = false;
            this.treeViewContents.Location = new System.Drawing.Point(9, 64);
            this.treeViewContents.Name = "treeViewContents";
            this.treeViewContents.Size = new System.Drawing.Size(240, 243);
            this.treeViewContents.TabIndex = 0;
            this.treeViewContents.ValidateLabelEdit += new TreeEx.TreeLE.ValidateLabelEditEventHandler(this.treeViewContents_ValidateLabelEdit);
            this.treeViewContents.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewContents_BeforeLabelEdit);
            this.treeViewContents.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewContents_AfterLabelEdit);
            this.treeViewContents.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewContents_AfterSelect);
            this.treeViewContents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewContents_KeyDown);
            // 
            // SongEditorChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 567);
            this.Controls.Add(this.tabControlTextLayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(200, 100);
            this.Name = "SongEditorChild";
            this.ShowInTaskbar = false;
            this.Text = "Liededitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorChild_FormClosing);
            this.Load += new System.EventHandler(this.EditorChild_Load);
            this.Shown += new System.EventHandler(this.EditorChild_Shown);
            this.Resize += new System.EventHandler(this.EditorChild_Resize);
            this.slideContextMenu.ResumeLayout(false);
            this.partContextMenu.ResumeLayout(false);
            this.songContextMenu.ResumeLayout(false);
            this.tabPageFormatting.ResumeLayout(false);
            this.tabPageFormatting.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLineSpacing)).EndInit();
            this.tabPageContent.ResumeLayout(false);
            this.tabPageContent.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.tabControlTextLayer.ResumeLayout(false);
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
		private System.Windows.Forms.ContextMenuStrip songContextMenu;
        private System.Windows.Forms.ToolStripMenuItem umbenennenToolStripMenuItem1;
        private System.Windows.Forms.TabPage tabPageFormatting;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trackBarLineSpacing;
        private System.Windows.Forms.Label labelLineSpacing;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelFont;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelFontTranslation;
        private System.Windows.Forms.Button buttonTranslationFont;
        private System.Windows.Forms.Button buttonProjectionMasterFont;
        private System.Windows.Forms.Button buttonChooseProjectionForeColor;
        private System.Windows.Forms.Button buttonTranslationColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageContent;
        private System.Windows.Forms.Button buttonDuplicateSlide;
        private System.Windows.Forms.TextBox textBoxCCLISongID;
        private System.Windows.Forms.TextBox textBoxCopyright;
        private System.Windows.Forms.TextBox textBoxSongTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
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
        private TreeEx.TreeLE treeViewContents;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonDelItem;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.TabControl tabControlTextLayer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxSlideVertOrientation;
        private System.Windows.Forms.ComboBox comboBoxSlideHorizOrientation;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxQASegmentation;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.CheckBox checkBoxQATranslation;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBoxQASpelling;
        private System.Windows.Forms.CheckBox checkBoxQAImages;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckedListBox checkedListBoxTags;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}