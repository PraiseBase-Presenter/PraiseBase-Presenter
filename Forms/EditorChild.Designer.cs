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
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.checkBoxQASegmentation = new System.Windows.Forms.CheckBox();
            this.checkBoxQAImages = new System.Windows.Forms.CheckBox();
            this.checkBoxQATranslation = new System.Windows.Forms.CheckBox();
            this.checkBoxQASpelling = new System.Windows.Forms.CheckBox();
            this.checkedListBoxTags = new System.Windows.Forms.CheckedListBox();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.addContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.liedteilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDelItem = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonTranslationColor = new System.Windows.Forms.Button();
            this.buttonTranslationFont = new System.Windows.Forms.Button();
            this.labelFontTranslation = new System.Windows.Forms.Label();
            this.buttonChooseProjectionForeColor = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonApplyAlignmentToAll = new System.Windows.Forms.Button();
            this.comboBoxSlideTextOrientation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSlideBackground = new System.Windows.Forms.Button();
            this.labelFont = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSongText = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.textBoxSongTranslation = new System.Windows.Forms.TextBox();
            this.buttonProjectionMasterFont = new System.Windows.Forms.Button();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSongTitle = new System.Windows.Forms.TextBox();
            this.treeViewContents = new TreeEx.TreeLE();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.addContextMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.slideContextMenu.SuspendLayout();
            this.partContextMenu.SuspendLayout();
            this.songContextMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
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
            this.textBoxComment.Size = new System.Drawing.Size(699, 556);
            this.textBoxComment.TabIndex = 68;
            this.textBoxComment.TextChanged += new System.EventHandler(this.textBoxComment_TextChanged);
            // 
            // checkBoxQASegmentation
            // 
            this.checkBoxQASegmentation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxQASegmentation.AutoSize = true;
            this.checkBoxQASegmentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxQASegmentation.Location = new System.Drawing.Point(6, 659);
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
            this.checkBoxQAImages.Location = new System.Drawing.Point(6, 607);
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
            this.checkBoxQATranslation.Location = new System.Drawing.Point(6, 633);
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
            this.checkBoxQASpelling.Location = new System.Drawing.Point(6, 581);
            this.checkBoxQASpelling.Name = "checkBoxQASpelling";
            this.checkBoxQASpelling.Size = new System.Drawing.Size(136, 20);
            this.checkBoxQASpelling.TabIndex = 13;
            this.checkBoxQASpelling.Text = "Text enthält Fehler";
            this.checkBoxQASpelling.UseVisualStyleBackColor = true;
            this.checkBoxQASpelling.CheckedChanged += new System.EventHandler(this.checkBoxQASpelling_CheckedChanged);
            // 
            // checkedListBoxTags
            // 
            this.checkedListBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBoxTags.CheckOnClick = true;
            this.checkedListBoxTags.ColumnWidth = 200;
            this.checkedListBoxTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxTags.FormattingEnabled = true;
            this.checkedListBoxTags.Location = new System.Drawing.Point(6, 19);
            this.checkedListBoxTags.Name = "checkedListBoxTags";
            this.checkedListBoxTags.Size = new System.Drawing.Size(252, 650);
            this.checkedListBoxTags.Sorted = true;
            this.checkedListBoxTags.TabIndex = 9;
            this.checkedListBoxTags.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxTags_ItemCheck);
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddItem.Image = global::Pbp.Properties.Resources.edit_add;
            this.buttonAddItem.Location = new System.Drawing.Point(3, 433);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(50, 23);
            this.buttonAddItem.TabIndex = 13;
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonAddItem_MouseDown);
            // 
            // addContextMenu
            // 
            this.addContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liedteilToolStripMenuItem,
            this.folieToolStripMenuItem});
            this.addContextMenu.Name = "addContextMenu";
            this.addContextMenu.Size = new System.Drawing.Size(113, 48);
            this.addContextMenu.VisibleChanged += new System.EventHandler(this.addContextMenu_VisibleChanged);
            // 
            // liedteilToolStripMenuItem
            // 
            this.liedteilToolStripMenuItem.Name = "liedteilToolStripMenuItem";
            this.liedteilToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.liedteilToolStripMenuItem.Text = "Liedteil";
            // 
            // folieToolStripMenuItem
            // 
            this.folieToolStripMenuItem.Name = "folieToolStripMenuItem";
            this.folieToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.folieToolStripMenuItem.Text = "Folie";
            this.folieToolStripMenuItem.Click += new System.EventHandler(this.folieToolStripMenuItem_Click);
            // 
            // buttonDelItem
            // 
            this.buttonDelItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelItem.Enabled = false;
            this.buttonDelItem.Image = global::Pbp.Properties.Resources.edit_remove;
            this.buttonDelItem.Location = new System.Drawing.Point(171, 433);
            this.buttonDelItem.Name = "buttonDelItem";
            this.buttonDelItem.Size = new System.Drawing.Size(50, 23);
            this.buttonDelItem.TabIndex = 14;
            this.buttonDelItem.UseVisualStyleBackColor = true;
            this.buttonDelItem.Click += new System.EventHandler(this.buttonDelItem_Click);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMoveUp.Enabled = false;
            this.buttonMoveUp.Image = global::Pbp.Properties.Resources.arrowup;
            this.buttonMoveUp.Location = new System.Drawing.Point(59, 433);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(50, 23);
            this.buttonMoveUp.TabIndex = 16;
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMoveDown.Enabled = false;
            this.buttonMoveDown.Image = global::Pbp.Properties.Resources.arrowdown;
            this.buttonMoveDown.Location = new System.Drawing.Point(115, 433);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(50, 23);
            this.buttonMoveDown.TabIndex = 17;
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxComment);
            this.groupBox1.Controls.Add(this.checkBoxQASpelling);
            this.groupBox1.Controls.Add(this.checkBoxQAImages);
            this.groupBox1.Controls.Add(this.checkBoxQATranslation);
            this.groupBox1.Controls.Add(this.checkBoxQASegmentation);
            this.groupBox1.Location = new System.Drawing.Point(276, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(711, 686);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Qualitätssicherung";
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(917, 661);
            this.tabControl1.TabIndex = 86;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonTranslationColor);
            this.tabPage1.Controls.Add(this.buttonTranslationFont);
            this.tabPage1.Controls.Add(this.labelFontTranslation);
            this.tabPage1.Controls.Add(this.buttonChooseProjectionForeColor);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.labelFont);
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.buttonProjectionMasterFont);
            this.tabPage1.Controls.Add(this.pictureBoxPreview);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(909, 635);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inhalt";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);

            // 
            // buttonTranslationColor
            // 
            this.buttonTranslationColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTranslationColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTranslationColor.Location = new System.Drawing.Point(150, 512);
            this.buttonTranslationColor.Name = "buttonTranslationColor";
            this.buttonTranslationColor.Size = new System.Drawing.Size(25, 23);
            this.buttonTranslationColor.TabIndex = 103;
            this.buttonTranslationColor.UseVisualStyleBackColor = true;
            // 
            // buttonTranslationFont
            // 
            this.buttonTranslationFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTranslationFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTranslationFont.Location = new System.Drawing.Point(15, 542);
            this.buttonTranslationFont.Name = "buttonTranslationFont";
            this.buttonTranslationFont.Size = new System.Drawing.Size(100, 23);
            this.buttonTranslationFont.TabIndex = 101;
            this.buttonTranslationFont.Text = "Schrift wählen...";
            this.buttonTranslationFont.UseVisualStyleBackColor = true;
            // 
            // labelFontTranslation
            // 
            this.labelFontTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFontTranslation.AutoSize = true;
            this.labelFontTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFontTranslation.Location = new System.Drawing.Point(130, 510);
            this.labelFontTranslation.Name = "labelFontTranslation";
            this.labelFontTranslation.Size = new System.Drawing.Size(14, 20);
            this.labelFontTranslation.TabIndex = 102;
            this.labelFontTranslation.Text = "-";
            // 
            // buttonChooseProjectionForeColor
            // 
            this.buttonChooseProjectionForeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonChooseProjectionForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChooseProjectionForeColor.Location = new System.Drawing.Point(150, 483);
            this.buttonChooseProjectionForeColor.Name = "buttonChooseProjectionForeColor";
            this.buttonChooseProjectionForeColor.Size = new System.Drawing.Size(25, 23);
            this.buttonChooseProjectionForeColor.TabIndex = 71;
            this.buttonChooseProjectionForeColor.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.buttonApplyAlignmentToAll);
            this.panel2.Controls.Add(this.comboBoxSlideTextOrientation);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.buttonSlideBackground);
            this.panel2.Location = new System.Drawing.Point(645, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 300);
            this.panel2.TabIndex = 100;
            // 
            // buttonApplyAlignmentToAll
            // 
            this.buttonApplyAlignmentToAll.Location = new System.Drawing.Point(99, 71);
            this.buttonApplyAlignmentToAll.Name = "buttonApplyAlignmentToAll";
            this.buttonApplyAlignmentToAll.Size = new System.Drawing.Size(114, 23);
            this.buttonApplyAlignmentToAll.TabIndex = 107;
            this.buttonApplyAlignmentToAll.Text = "Für alle übernehmen";
            this.buttonApplyAlignmentToAll.UseVisualStyleBackColor = true;
            this.buttonApplyAlignmentToAll.Click += new System.EventHandler(this.buttonApplyAlignmentToAll_Click);
            // 
            // comboBoxSlideTextOrientation
            // 
            this.comboBoxSlideTextOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSlideTextOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSlideTextOrientation.FormattingEnabled = true;
            this.comboBoxSlideTextOrientation.Items.AddRange(new object[] {
            "Oben links",
            "Oben zentriert",
            "Oben rechts",
            "Mitte links",
            "Mitte zentriert",
            "Mitte rechts",
            "Unten links",
            "Unten zentriert",
            "Unten rechts"});
            this.comboBoxSlideTextOrientation.Location = new System.Drawing.Point(98, 41);
            this.comboBoxSlideTextOrientation.Name = "comboBoxSlideTextOrientation";
            this.comboBoxSlideTextOrientation.Size = new System.Drawing.Size(114, 24);
            this.comboBoxSlideTextOrientation.TabIndex = 106;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 105;
            this.label5.Text = "Hintergrundbild:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 104;
            this.label3.Text = "Textausrichtung:";
            // 
            // buttonSlideBackground
            // 
            this.buttonSlideBackground.Location = new System.Drawing.Point(97, 9);
            this.buttonSlideBackground.Name = "buttonSlideBackground";
            this.buttonSlideBackground.Size = new System.Drawing.Size(114, 23);
            this.buttonSlideBackground.TabIndex = 100;
            this.buttonSlideBackground.Text = "Bild wählen...";
            this.buttonSlideBackground.UseVisualStyleBackColor = true;
            this.buttonSlideBackground.Click += new System.EventHandler(this.buttonSlideBackground_Click);
            // 
            // labelFont
            // 
            this.labelFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFont.AutoSize = true;
            this.labelFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFont.Location = new System.Drawing.Point(130, 483);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(14, 20);
            this.labelFont.TabIndex = 60;
            this.labelFont.Text = "-";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(239, 312);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(667, 317);
            this.splitContainer1.SplitterDistance = 335;
            this.splitContainer1.TabIndex = 98;
            this.splitContainer1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxSongText);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 311);
            this.groupBox2.TabIndex = 94;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Liedtext";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Dies ist der Originaltext des Liedes";
            // 
            // textBoxSongText
            // 
            this.textBoxSongText.AcceptsReturn = true;
            this.textBoxSongText.AcceptsTab = true;
            this.textBoxSongText.AllowDrop = true;
            this.textBoxSongText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSongText.Location = new System.Drawing.Point(6, 46);
            this.textBoxSongText.Multiline = true;
            this.textBoxSongText.Name = "textBoxSongText";
            this.textBoxSongText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSongText.Size = new System.Drawing.Size(317, 229);
            this.textBoxSongText.TabIndex = 70;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.comboBoxLanguage);
            this.groupBox3.Controls.Add(this.labelLanguage);
            this.groupBox3.Controls.Add(this.textBoxSongTranslation);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 311);
            this.groupBox3.TabIndex = 95;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Übersetzung";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Pbp.Properties.Resources.trash;
            this.button1.Location = new System.Drawing.Point(244, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 23);
            this.button1.TabIndex = 83;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(63, 19);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(175, 21);
            this.comboBoxLanguage.TabIndex = 82;
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLanguage.Location = new System.Drawing.Point(7, 22);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(50, 13);
            this.labelLanguage.TabIndex = 81;
            this.labelLanguage.Text = "Sprache:";
            // 
            // textBoxSongTranslation
            // 
            this.textBoxSongTranslation.AcceptsReturn = true;
            this.textBoxSongTranslation.AcceptsTab = true;
            this.textBoxSongTranslation.AllowDrop = true;
            this.textBoxSongTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSongTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSongTranslation.Location = new System.Drawing.Point(6, 46);
            this.textBoxSongTranslation.Multiline = true;
            this.textBoxSongTranslation.Name = "textBoxSongTranslation";
            this.textBoxSongTranslation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSongTranslation.Size = new System.Drawing.Size(310, 229);
            this.textBoxSongTranslation.TabIndex = 80;
            // 
            // buttonProjectionMasterFont
            // 
            this.buttonProjectionMasterFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonProjectionMasterFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProjectionMasterFont.Location = new System.Drawing.Point(15, 571);
            this.buttonProjectionMasterFont.Name = "buttonProjectionMasterFont";
            this.buttonProjectionMasterFont.Size = new System.Drawing.Size(100, 23);
            this.buttonProjectionMasterFont.TabIndex = 56;
            this.buttonProjectionMasterFont.Text = "Schrift wählen...";
            this.buttonProjectionMasterFont.UseVisualStyleBackColor = true;
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Location = new System.Drawing.Point(239, 6);
            this.pictureBoxPreview.MinimumSize = new System.Drawing.Size(400, 300);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(400, 300);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPreview.TabIndex = 90;
            this.pictureBoxPreview.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxSongTitle);
            this.panel1.Controls.Add(this.treeViewContents);
            this.panel1.Controls.Add(this.buttonAddItem);
            this.panel1.Controls.Add(this.buttonDelItem);
            this.panel1.Controls.Add(this.buttonMoveUp);
            this.panel1.Controls.Add(this.buttonMoveDown);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 459);
            this.panel1.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Titel:";
            // 
            // textBoxSongTitle
            // 
            this.textBoxSongTitle.Location = new System.Drawing.Point(39, 4);
            this.textBoxSongTitle.Name = "textBoxSongTitle";
            this.textBoxSongTitle.Size = new System.Drawing.Size(182, 20);
            this.textBoxSongTitle.TabIndex = 18;
            this.textBoxSongTitle.TextChanged += new System.EventHandler(this.textBoxSongTitle_TextChanged);
            // 
            // treeViewContents
            // 
            this.treeViewContents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewContents.HideSelection = false;
            this.treeViewContents.Location = new System.Drawing.Point(3, 30);
            this.treeViewContents.Name = "treeViewContents";
            this.treeViewContents.ShowPlusMinus = false;
            this.treeViewContents.Size = new System.Drawing.Size(218, 397);
            this.treeViewContents.TabIndex = 0;
            this.treeViewContents.ValidateLabelEdit += new TreeEx.TreeLE.ValidateLabelEditEventHandler(this.treeViewContents_ValidateLabelEdit);
            this.treeViewContents.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewContents_BeforeLabelEdit);
            this.treeViewContents.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewContents_AfterLabelEdit);
            this.treeViewContents.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewContents_AfterSelect);
            this.treeViewContents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewContents_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(909, 635);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Daten";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkedListBoxTags);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 686);
            this.groupBox4.TabIndex = 70;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tags";
            // 
            // EditorChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 667);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(940, 705);
            this.Name = "EditorChild";
            this.ShowInTaskbar = false;
            this.Text = "Liededitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorChild_FormClosing);
            this.Load += new System.EventHandler(this.EditorChild_Load);
            this.Resize += new System.EventHandler(this.EditorChild_Resize);
            this.addContextMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.slideContextMenu.ResumeLayout(false);
            this.partContextMenu.ResumeLayout(false);
            this.songContextMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private TreeEx.TreeLE treeViewContents;
        private System.Windows.Forms.CheckedListBox checkedListBoxTags;
        private System.Windows.Forms.Button buttonAddItem;
		private System.Windows.Forms.Button buttonDelItem;
        private System.Windows.Forms.Button buttonMoveUp;
		private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.CheckBox checkBoxQASpelling;
        private System.Windows.Forms.CheckBox checkBoxQAImages;
		private System.Windows.Forms.CheckBox checkBoxQATranslation;
        private System.Windows.Forms.CheckBox checkBoxQASegmentation;
		private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ContextMenuStrip addContextMenu;
		private System.Windows.Forms.ToolStripMenuItem liedteilToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem folieToolStripMenuItem;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxSongTranslation;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonChooseProjectionForeColor;
        private System.Windows.Forms.Label labelFont;
        private System.Windows.Forms.Button buttonProjectionMasterFont;
        private System.Windows.Forms.TextBox textBoxSongText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxSongTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSlideBackground;
        private System.Windows.Forms.Button buttonTranslationColor;
        private System.Windows.Forms.Button buttonTranslationFont;
        private System.Windows.Forms.Label labelFontTranslation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxSlideTextOrientation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonApplyAlignmentToAll;
    }
}