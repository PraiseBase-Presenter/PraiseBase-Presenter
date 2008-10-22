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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorChild));
			this.treeViewContents = new System.Windows.Forms.TreeView();
			this.textBoxSongText = new System.Windows.Forms.TextBox();
			this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
			this.textBoxSongTitle = new System.Windows.Forms.TextBox();
			this.labelSongTitle = new System.Windows.Forms.Label();
			this.labelLanguage = new System.Windows.Forms.Label();
			this.groupBoxSongSettings = new System.Windows.Forms.GroupBox();
			this.pictureBoxFontTranslationColor = new System.Windows.Forms.PictureBox();
			this.pictureBoxFontColor = new System.Windows.Forms.PictureBox();
			this.label7 = new System.Windows.Forms.Label();
			this.buttonProjectionMasterFont = new System.Windows.Forms.Button();
			this.labelLineSpacing = new System.Windows.Forms.Label();
			this.buttonChooseProjectionForeColor = new System.Windows.Forms.Button();
			this.trackBarLineSpacing = new System.Windows.Forms.TrackBar();
			this.buttonTranslationFont = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.buttonTranslationColor = new System.Windows.Forms.Button();
			this.labelFontTranslation = new System.Windows.Forms.Label();
			this.labelFont = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.checkBoxQASegmentation = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBoxQAImages = new System.Windows.Forms.CheckBox();
			this.checkBoxQATranslation = new System.Windows.Forms.CheckBox();
			this.checkBoxQASpelling = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxComment = new System.Windows.Forms.TextBox();
			this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
			this.checkedListBoxTags = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBoxNewSongPart = new System.Windows.Forms.GroupBox();
			this.comboBoxSongParts = new System.Windows.Forms.ComboBox();
			this.buttonNewSongPart = new System.Windows.Forms.Button();
			this.labelNewSongPart = new System.Windows.Forms.Label();
			this.groupBoxSongPart = new System.Windows.Forms.GroupBox();
			this.buttonDelSongPart = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxSongPartCaption = new System.Windows.Forms.TextBox();
			this.groupBoxNewSlide = new System.Windows.Forms.GroupBox();
			this.buttonAddNewSlide = new System.Windows.Forms.Button();
			this.buttonAddItem = new System.Windows.Forms.Button();
			this.buttonDelItem = new System.Windows.Forms.Button();
			this.tabControlEditor = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.textBoxSongTranslation = new System.Windows.Forms.TextBox();
			this.buttonDelSlide = new System.Windows.Forms.Button();
			this.buttonSlideSeparate = new System.Windows.Forms.Button();
			this.buttonSlideDuplicate = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBoxSlideVertOrientation = new System.Windows.Forms.ComboBox();
			this.comboBoxSlideHorizOrientation = new System.Windows.Forms.ComboBox();
			this.buttonSlideBackground = new System.Windows.Forms.Button();
			this.buttonMoveUp = new System.Windows.Forms.Button();
			this.buttonMoveDown = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
			this.groupBoxSongSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontTranslationColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarLineSpacing)).BeginInit();
			this.groupBoxNewSongPart.SuspendLayout();
			this.groupBoxSongPart.SuspendLayout();
			this.groupBoxNewSlide.SuspendLayout();
			this.tabControlEditor.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeViewContents
			// 
			this.treeViewContents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.treeViewContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.treeViewContents.HideSelection = false;
			this.treeViewContents.Location = new System.Drawing.Point(4, 4);
			this.treeViewContents.Name = "treeViewContents";
			this.treeViewContents.Size = new System.Drawing.Size(253, 667);
			this.treeViewContents.TabIndex = 0;
			this.treeViewContents.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewContents_AfterSelect);
			// 
			// textBoxSongText
			// 
			this.textBoxSongText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxSongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSongText.Location = new System.Drawing.Point(5, 466);
			this.textBoxSongText.Multiline = true;
			this.textBoxSongText.Name = "textBoxSongText";
			this.textBoxSongText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxSongText.Size = new System.Drawing.Size(355, 203);
			this.textBoxSongText.TabIndex = 1;
			this.textBoxSongText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.updateSongText);
			// 
			// pictureBoxPreview
			// 
			this.pictureBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxPreview.Location = new System.Drawing.Point(2, 6);
			this.pictureBoxPreview.Name = "pictureBoxPreview";
			this.pictureBoxPreview.Size = new System.Drawing.Size(572, 454);
			this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxPreview.TabIndex = 2;
			this.pictureBoxPreview.TabStop = false;
			// 
			// textBoxSongTitle
			// 
			this.textBoxSongTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSongTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSongTitle.Location = new System.Drawing.Point(97, 28);
			this.textBoxSongTitle.Name = "textBoxSongTitle";
			this.textBoxSongTitle.Size = new System.Drawing.Size(522, 26);
			this.textBoxSongTitle.TabIndex = 4;
			this.textBoxSongTitle.TextChanged += new System.EventHandler(this.textBoxSongTitle_TextChanged);
			// 
			// labelSongTitle
			// 
			this.labelSongTitle.AutoSize = true;
			this.labelSongTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSongTitle.Location = new System.Drawing.Point(8, 31);
			this.labelSongTitle.Name = "labelSongTitle";
			this.labelSongTitle.Size = new System.Drawing.Size(83, 20);
			this.labelSongTitle.TabIndex = 5;
			this.labelSongTitle.Text = "Liedname:";
			// 
			// labelLanguage
			// 
			this.labelLanguage.AutoSize = true;
			this.labelLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLanguage.Location = new System.Drawing.Point(8, 63);
			this.labelLanguage.Name = "labelLanguage";
			this.labelLanguage.Size = new System.Drawing.Size(73, 20);
			this.labelLanguage.TabIndex = 6;
			this.labelLanguage.Text = "Sprache:";
			// 
			// groupBoxSongSettings
			// 
			this.groupBoxSongSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxSongSettings.Controls.Add(this.pictureBoxFontTranslationColor);
			this.groupBoxSongSettings.Controls.Add(this.pictureBoxFontColor);
			this.groupBoxSongSettings.Controls.Add(this.label7);
			this.groupBoxSongSettings.Controls.Add(this.buttonProjectionMasterFont);
			this.groupBoxSongSettings.Controls.Add(this.labelLineSpacing);
			this.groupBoxSongSettings.Controls.Add(this.buttonChooseProjectionForeColor);
			this.groupBoxSongSettings.Controls.Add(this.trackBarLineSpacing);
			this.groupBoxSongSettings.Controls.Add(this.buttonTranslationFont);
			this.groupBoxSongSettings.Controls.Add(this.label10);
			this.groupBoxSongSettings.Controls.Add(this.buttonTranslationColor);
			this.groupBoxSongSettings.Controls.Add(this.labelFontTranslation);
			this.groupBoxSongSettings.Controls.Add(this.labelFont);
			this.groupBoxSongSettings.Controls.Add(this.label11);
			this.groupBoxSongSettings.Controls.Add(this.checkBoxQASegmentation);
			this.groupBoxSongSettings.Controls.Add(this.label6);
			this.groupBoxSongSettings.Controls.Add(this.checkBoxQAImages);
			this.groupBoxSongSettings.Controls.Add(this.checkBoxQATranslation);
			this.groupBoxSongSettings.Controls.Add(this.checkBoxQASpelling);
			this.groupBoxSongSettings.Controls.Add(this.label2);
			this.groupBoxSongSettings.Controls.Add(this.textBoxComment);
			this.groupBoxSongSettings.Controls.Add(this.comboBoxLanguage);
			this.groupBoxSongSettings.Controls.Add(this.checkedListBoxTags);
			this.groupBoxSongSettings.Controls.Add(this.label1);
			this.groupBoxSongSettings.Controls.Add(this.labelSongTitle);
			this.groupBoxSongSettings.Controls.Add(this.labelLanguage);
			this.groupBoxSongSettings.Controls.Add(this.textBoxSongTitle);
			this.groupBoxSongSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxSongSettings.Location = new System.Drawing.Point(7, 6);
			this.groupBoxSongSettings.Name = "groupBoxSongSettings";
			this.groupBoxSongSettings.Size = new System.Drawing.Size(633, 589);
			this.groupBoxSongSettings.TabIndex = 8;
			this.groupBoxSongSettings.TabStop = false;
			this.groupBoxSongSettings.Text = "Liedeinstellungen";
			// 
			// pictureBoxFontTranslationColor
			// 
			this.pictureBoxFontTranslationColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxFontTranslationColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxFontTranslationColor.Location = new System.Drawing.Point(588, 253);
			this.pictureBoxFontTranslationColor.Name = "pictureBoxFontTranslationColor";
			this.pictureBoxFontTranslationColor.Size = new System.Drawing.Size(31, 29);
			this.pictureBoxFontTranslationColor.TabIndex = 67;
			this.pictureBoxFontTranslationColor.TabStop = false;
			this.pictureBoxFontTranslationColor.Click += new System.EventHandler(this.buttonTranslationColor_Click);
			// 
			// pictureBoxFontColor
			// 
			this.pictureBoxFontColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxFontColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxFontColor.Location = new System.Drawing.Point(588, 210);
			this.pictureBoxFontColor.Name = "pictureBoxFontColor";
			this.pictureBoxFontColor.Size = new System.Drawing.Size(31, 29);
			this.pictureBoxFontColor.TabIndex = 66;
			this.pictureBoxFontColor.TabStop = false;
			this.pictureBoxFontColor.Click += new System.EventHandler(this.buttonChooseProjectionForeColor_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(9, 215);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(134, 20);
			this.label7.TabIndex = 59;
			this.label7.Text = "Projektionsschrift:";
			// 
			// buttonProjectionMasterFont
			// 
			this.buttonProjectionMasterFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonProjectionMasterFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonProjectionMasterFont.Location = new System.Drawing.Point(314, 211);
			this.buttonProjectionMasterFont.Name = "buttonProjectionMasterFont";
			this.buttonProjectionMasterFont.Size = new System.Drawing.Size(133, 28);
			this.buttonProjectionMasterFont.TabIndex = 56;
			this.buttonProjectionMasterFont.Text = "Schrift wählen...";
			this.buttonProjectionMasterFont.UseVisualStyleBackColor = true;
			this.buttonProjectionMasterFont.Click += new System.EventHandler(this.buttonProjectionMasterFont_Click);
			// 
			// labelLineSpacing
			// 
			this.labelLineSpacing.AutoSize = true;
			this.labelLineSpacing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLineSpacing.Location = new System.Drawing.Point(276, 295);
			this.labelLineSpacing.Name = "labelLineSpacing";
			this.labelLineSpacing.Size = new System.Drawing.Size(14, 20);
			this.labelLineSpacing.TabIndex = 65;
			this.labelLineSpacing.Text = "-";
			// 
			// buttonChooseProjectionForeColor
			// 
			this.buttonChooseProjectionForeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonChooseProjectionForeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonChooseProjectionForeColor.Location = new System.Drawing.Point(453, 211);
			this.buttonChooseProjectionForeColor.Name = "buttonChooseProjectionForeColor";
			this.buttonChooseProjectionForeColor.Size = new System.Drawing.Size(119, 28);
			this.buttonChooseProjectionForeColor.TabIndex = 55;
			this.buttonChooseProjectionForeColor.Text = "Schriftfarbe...";
			this.buttonChooseProjectionForeColor.UseVisualStyleBackColor = true;
			this.buttonChooseProjectionForeColor.Click += new System.EventHandler(this.buttonChooseProjectionForeColor_Click);
			// 
			// trackBarLineSpacing
			// 
			this.trackBarLineSpacing.Location = new System.Drawing.Point(129, 295);
			this.trackBarLineSpacing.Maximum = 50;
			this.trackBarLineSpacing.Name = "trackBarLineSpacing";
			this.trackBarLineSpacing.Size = new System.Drawing.Size(141, 42);
			this.trackBarLineSpacing.TabIndex = 64;
			this.trackBarLineSpacing.TickFrequency = 5;
			this.trackBarLineSpacing.Scroll += new System.EventHandler(this.trackBarLineSpacing_Scroll);
			// 
			// buttonTranslationFont
			// 
			this.buttonTranslationFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonTranslationFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonTranslationFont.Location = new System.Drawing.Point(314, 254);
			this.buttonTranslationFont.Name = "buttonTranslationFont";
			this.buttonTranslationFont.Size = new System.Drawing.Size(133, 28);
			this.buttonTranslationFont.TabIndex = 57;
			this.buttonTranslationFont.Text = "Schrift wählen...";
			this.buttonTranslationFont.UseVisualStyleBackColor = true;
			this.buttonTranslationFont.Click += new System.EventHandler(this.buttonTranslationFont_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(9, 300);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(114, 20);
			this.label10.TabIndex = 63;
			this.label10.Text = "Zeilenabstand:";
			// 
			// buttonTranslationColor
			// 
			this.buttonTranslationColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonTranslationColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonTranslationColor.Location = new System.Drawing.Point(453, 254);
			this.buttonTranslationColor.Name = "buttonTranslationColor";
			this.buttonTranslationColor.Size = new System.Drawing.Size(119, 28);
			this.buttonTranslationColor.TabIndex = 58;
			this.buttonTranslationColor.Text = "Schriftfarbe...";
			this.buttonTranslationColor.UseVisualStyleBackColor = true;
			this.buttonTranslationColor.Click += new System.EventHandler(this.buttonTranslationColor_Click);
			// 
			// labelFontTranslation
			// 
			this.labelFontTranslation.AutoSize = true;
			this.labelFontTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFontTranslation.Location = new System.Drawing.Point(171, 256);
			this.labelFontTranslation.Name = "labelFontTranslation";
			this.labelFontTranslation.Size = new System.Drawing.Size(14, 20);
			this.labelFontTranslation.TabIndex = 62;
			this.labelFontTranslation.Text = "-";
			// 
			// labelFont
			// 
			this.labelFont.AutoSize = true;
			this.labelFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFont.Location = new System.Drawing.Point(149, 215);
			this.labelFont.Name = "labelFont";
			this.labelFont.Size = new System.Drawing.Size(14, 20);
			this.labelFont.TabIndex = 60;
			this.labelFont.Text = "-";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(9, 256);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(156, 20);
			this.label11.TabIndex = 61;
			this.label11.Text = "Übersetzungsschrift:";
			// 
			// checkBoxQASegmentation
			// 
			this.checkBoxQASegmentation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxQASegmentation.AutoSize = true;
			this.checkBoxQASegmentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxQASegmentation.Location = new System.Drawing.Point(364, 558);
			this.checkBoxQASegmentation.Name = "checkBoxQASegmentation";
			this.checkBoxQASegmentation.Size = new System.Drawing.Size(162, 20);
			this.checkBoxQASegmentation.TabIndex = 17;
			this.checkBoxQASegmentation.Text = "Aufteilung nicht optimal";
			this.checkBoxQASegmentation.UseVisualStyleBackColor = true;
			this.checkBoxQASegmentation.CheckedChanged += new System.EventHandler(this.checkBoxQASegmentation_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 532);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(145, 20);
			this.label6.TabIndex = 16;
			this.label6.Text = "Qualitätssicherung:";
			// 
			// checkBoxQAImages
			// 
			this.checkBoxQAImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxQAImages.AutoSize = true;
			this.checkBoxQAImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxQAImages.Location = new System.Drawing.Point(188, 558);
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
			this.checkBoxQATranslation.Location = new System.Drawing.Point(364, 532);
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
			this.checkBoxQASpelling.Location = new System.Drawing.Point(188, 532);
			this.checkBoxQASpelling.Name = "checkBoxQASpelling";
			this.checkBoxQASpelling.Size = new System.Drawing.Size(136, 20);
			this.checkBoxQASpelling.TabIndex = 13;
			this.checkBoxQASpelling.Text = "Text enthält Fehler";
			this.checkBoxQASpelling.UseVisualStyleBackColor = true;
			this.checkBoxQASpelling.CheckedChanged += new System.EventHandler(this.checkBoxQASpelling_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(9, 343);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 20);
			this.label2.TabIndex = 12;
			this.label2.Text = "Kommentar:";
			// 
			// textBoxComment
			// 
			this.textBoxComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxComment.Location = new System.Drawing.Point(109, 343);
			this.textBoxComment.Multiline = true;
			this.textBoxComment.Name = "textBoxComment";
			this.textBoxComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxComment.Size = new System.Drawing.Size(510, 174);
			this.textBoxComment.TabIndex = 11;
			this.textBoxComment.TextChanged += new System.EventHandler(this.textBoxComment_TextChanged);
			// 
			// comboBoxLanguage
			// 
			this.comboBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxLanguage.FormattingEnabled = true;
			this.comboBoxLanguage.Location = new System.Drawing.Point(97, 60);
			this.comboBoxLanguage.Name = "comboBoxLanguage";
			this.comboBoxLanguage.Size = new System.Drawing.Size(522, 28);
			this.comboBoxLanguage.TabIndex = 10;
			this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
			// 
			// checkedListBoxTags
			// 
			this.checkedListBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.checkedListBoxTags.CheckOnClick = true;
			this.checkedListBoxTags.ColumnWidth = 200;
			this.checkedListBoxTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkedListBoxTags.FormattingEnabled = true;
			this.checkedListBoxTags.Location = new System.Drawing.Point(97, 94);
			this.checkedListBoxTags.MultiColumn = true;
			this.checkedListBoxTags.Name = "checkedListBoxTags";
			this.checkedListBoxTags.Size = new System.Drawing.Size(522, 109);
			this.checkedListBoxTags.Sorted = true;
			this.checkedListBoxTags.TabIndex = 9;
			this.checkedListBoxTags.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxTags_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 94);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 20);
			this.label1.TabIndex = 8;
			this.label1.Text = "Tags:";
			// 
			// groupBoxNewSongPart
			// 
			this.groupBoxNewSongPart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxNewSongPart.Controls.Add(this.comboBoxSongParts);
			this.groupBoxNewSongPart.Controls.Add(this.buttonNewSongPart);
			this.groupBoxNewSongPart.Controls.Add(this.labelNewSongPart);
			this.groupBoxNewSongPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxNewSongPart.Location = new System.Drawing.Point(7, 601);
			this.groupBoxNewSongPart.Name = "groupBoxNewSongPart";
			this.groupBoxNewSongPart.Size = new System.Drawing.Size(632, 71);
			this.groupBoxNewSongPart.TabIndex = 9;
			this.groupBoxNewSongPart.TabStop = false;
			this.groupBoxNewSongPart.Text = "Neuer Liedteil";
			// 
			// comboBoxSongParts
			// 
			this.comboBoxSongParts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSongParts.FormattingEnabled = true;
			this.comboBoxSongParts.Location = new System.Drawing.Point(100, 25);
			this.comboBoxSongParts.Name = "comboBoxSongParts";
			this.comboBoxSongParts.Size = new System.Drawing.Size(329, 28);
			this.comboBoxSongParts.TabIndex = 11;
			this.comboBoxSongParts.Enter += new System.EventHandler(this.comboBoxSongParts_Enter);
			// 
			// buttonNewSongPart
			// 
			this.buttonNewSongPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonNewSongPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonNewSongPart.Location = new System.Drawing.Point(453, 25);
			this.buttonNewSongPart.Name = "buttonNewSongPart";
			this.buttonNewSongPart.Size = new System.Drawing.Size(157, 28);
			this.buttonNewSongPart.TabIndex = 10;
			this.buttonNewSongPart.Text = "Hinzufügen";
			this.buttonNewSongPart.UseVisualStyleBackColor = true;
			this.buttonNewSongPart.Click += new System.EventHandler(this.buttonNewSongPart_Click);
			// 
			// labelNewSongPart
			// 
			this.labelNewSongPart.AutoSize = true;
			this.labelNewSongPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNewSongPart.Location = new System.Drawing.Point(8, 29);
			this.labelNewSongPart.Name = "labelNewSongPart";
			this.labelNewSongPart.Size = new System.Drawing.Size(55, 20);
			this.labelNewSongPart.TabIndex = 8;
			this.labelNewSongPart.Text = "Name:";
			// 
			// groupBoxSongPart
			// 
			this.groupBoxSongPart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxSongPart.Controls.Add(this.buttonDelSongPart);
			this.groupBoxSongPart.Controls.Add(this.label3);
			this.groupBoxSongPart.Controls.Add(this.textBoxSongPartCaption);
			this.groupBoxSongPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxSongPart.Location = new System.Drawing.Point(6, 6);
			this.groupBoxSongPart.Name = "groupBoxSongPart";
			this.groupBoxSongPart.Size = new System.Drawing.Size(633, 121);
			this.groupBoxSongPart.TabIndex = 10;
			this.groupBoxSongPart.TabStop = false;
			this.groupBoxSongPart.Text = "Liedteil-Einstellungen";
			// 
			// buttonDelSongPart
			// 
			this.buttonDelSongPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonDelSongPart.Location = new System.Drawing.Point(12, 78);
			this.buttonDelSongPart.Name = "buttonDelSongPart";
			this.buttonDelSongPart.Size = new System.Drawing.Size(286, 28);
			this.buttonDelSongPart.TabIndex = 13;
			this.buttonDelSongPart.Text = "Liedteil löschen";
			this.buttonDelSongPart.UseVisualStyleBackColor = true;
			this.buttonDelSongPart.Click += new System.EventHandler(this.buttonDelSongPart_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 31);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(106, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "Bezeichnung:";
			// 
			// textBoxSongPartCaption
			// 
			this.textBoxSongPartCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSongPartCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSongPartCaption.Location = new System.Drawing.Point(120, 28);
			this.textBoxSongPartCaption.Name = "textBoxSongPartCaption";
			this.textBoxSongPartCaption.Size = new System.Drawing.Size(499, 26);
			this.textBoxSongPartCaption.TabIndex = 4;
			this.textBoxSongPartCaption.TextChanged += new System.EventHandler(this.textBoxSongPartCaption_TextChanged);
			// 
			// groupBoxNewSlide
			// 
			this.groupBoxNewSlide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxNewSlide.Controls.Add(this.buttonAddNewSlide);
			this.groupBoxNewSlide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxNewSlide.Location = new System.Drawing.Point(6, 145);
			this.groupBoxNewSlide.Name = "groupBoxNewSlide";
			this.groupBoxNewSlide.Size = new System.Drawing.Size(633, 70);
			this.groupBoxNewSlide.TabIndex = 12;
			this.groupBoxNewSlide.TabStop = false;
			this.groupBoxNewSlide.Text = "Neue Folie";
			// 
			// buttonAddNewSlide
			// 
			this.buttonAddNewSlide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAddNewSlide.Location = new System.Drawing.Point(12, 25);
			this.buttonAddNewSlide.Name = "buttonAddNewSlide";
			this.buttonAddNewSlide.Size = new System.Drawing.Size(286, 28);
			this.buttonAddNewSlide.TabIndex = 10;
			this.buttonAddNewSlide.Text = "Hinzufügen";
			this.buttonAddNewSlide.UseVisualStyleBackColor = true;
			this.buttonAddNewSlide.Click += new System.EventHandler(this.buttonAddNewSlide_Click);
			// 
			// buttonAddItem
			// 
			this.buttonAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonAddItem.Enabled = false;
			this.buttonAddItem.Location = new System.Drawing.Point(4, 678);
			this.buttonAddItem.Name = "buttonAddItem";
			this.buttonAddItem.Size = new System.Drawing.Size(78, 23);
			this.buttonAddItem.TabIndex = 13;
			this.buttonAddItem.Text = "Hinzufügen";
			this.buttonAddItem.UseVisualStyleBackColor = true;
			this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
			// 
			// buttonDelItem
			// 
			this.buttonDelItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonDelItem.Enabled = false;
			this.buttonDelItem.Location = new System.Drawing.Point(194, 678);
			this.buttonDelItem.Name = "buttonDelItem";
			this.buttonDelItem.Size = new System.Drawing.Size(63, 23);
			this.buttonDelItem.TabIndex = 14;
			this.buttonDelItem.Text = "Löschen";
			this.buttonDelItem.UseVisualStyleBackColor = true;
			this.buttonDelItem.Click += new System.EventHandler(this.buttonDelItem_Click);
			// 
			// tabControlEditor
			// 
			this.tabControlEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlEditor.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControlEditor.Controls.Add(this.tabPage1);
			this.tabControlEditor.Controls.Add(this.tabPage2);
			this.tabControlEditor.Controls.Add(this.tabPage3);
			this.tabControlEditor.Location = new System.Drawing.Point(263, 4);
			this.tabControlEditor.Name = "tabControlEditor";
			this.tabControlEditor.SelectedIndex = 0;
			this.tabControlEditor.Size = new System.Drawing.Size(727, 705);
			this.tabControlEditor.TabIndex = 15;
			this.tabControlEditor.SelectedIndexChanged += new System.EventHandler(this.tabControlEditor_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBoxSongSettings);
			this.tabPage1.Controls.Add(this.groupBoxNewSongPart);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(719, 676);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Lied";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBoxSongPart);
			this.tabPage2.Controls.Add(this.groupBoxNewSlide);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(719, 676);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Liedteil";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.textBoxSongTranslation);
			this.tabPage3.Controls.Add(this.buttonDelSlide);
			this.tabPage3.Controls.Add(this.buttonSlideSeparate);
			this.tabPage3.Controls.Add(this.buttonSlideDuplicate);
			this.tabPage3.Controls.Add(this.label5);
			this.tabPage3.Controls.Add(this.label4);
			this.tabPage3.Controls.Add(this.comboBoxSlideVertOrientation);
			this.tabPage3.Controls.Add(this.comboBoxSlideHorizOrientation);
			this.tabPage3.Controls.Add(this.buttonSlideBackground);
			this.tabPage3.Controls.Add(this.textBoxSongText);
			this.tabPage3.Controls.Add(this.pictureBoxPreview);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(719, 676);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Folie";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// textBoxSongTranslation
			// 
			this.textBoxSongTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSongTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSongTranslation.Location = new System.Drawing.Point(366, 466);
			this.textBoxSongTranslation.Multiline = true;
			this.textBoxSongTranslation.Name = "textBoxSongTranslation";
			this.textBoxSongTranslation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxSongTranslation.Size = new System.Drawing.Size(355, 203);
			this.textBoxSongTranslation.TabIndex = 11;
			this.textBoxSongTranslation.TextChanged += new System.EventHandler(this.textBoxSongTranslation_TextChanged);
			// 
			// buttonDelSlide
			// 
			this.buttonDelSlide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDelSlide.Location = new System.Drawing.Point(583, 261);
			this.buttonDelSlide.Name = "buttonDelSlide";
			this.buttonDelSlide.Size = new System.Drawing.Size(114, 23);
			this.buttonDelSlide.TabIndex = 10;
			this.buttonDelSlide.Text = "Folie löschen";
			this.buttonDelSlide.UseVisualStyleBackColor = true;
			this.buttonDelSlide.Click += new System.EventHandler(this.buttonDelSlide_Click);
			// 
			// buttonSlideSeparate
			// 
			this.buttonSlideSeparate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSlideSeparate.Location = new System.Drawing.Point(583, 221);
			this.buttonSlideSeparate.Name = "buttonSlideSeparate";
			this.buttonSlideSeparate.Size = new System.Drawing.Size(114, 23);
			this.buttonSlideSeparate.TabIndex = 9;
			this.buttonSlideSeparate.Text = "Auf zwei aufteilen";
			this.buttonSlideSeparate.UseVisualStyleBackColor = true;
			this.buttonSlideSeparate.Click += new System.EventHandler(this.buttonSlideSeparate_Click);
			// 
			// buttonSlideDuplicate
			// 
			this.buttonSlideDuplicate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSlideDuplicate.Location = new System.Drawing.Point(583, 182);
			this.buttonSlideDuplicate.Name = "buttonSlideDuplicate";
			this.buttonSlideDuplicate.Size = new System.Drawing.Size(114, 23);
			this.buttonSlideDuplicate.TabIndex = 8;
			this.buttonSlideDuplicate.Text = "Folie duplizieren";
			this.buttonSlideDuplicate.UseVisualStyleBackColor = true;
			this.buttonSlideDuplicate.Click += new System.EventHandler(this.buttonSlideDuplicate_Click);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(580, 103);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(110, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Vertikale Ausrichtung:";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(580, 52);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(122, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Horizontale Ausrichtung:";
			// 
			// comboBoxSlideVertOrientation
			// 
			this.comboBoxSlideVertOrientation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSlideVertOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSlideVertOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxSlideVertOrientation.FormattingEnabled = true;
			this.comboBoxSlideVertOrientation.Items.AddRange(new object[] {
            "Oben",
            "Mitte",
            "Unten"});
			this.comboBoxSlideVertOrientation.Location = new System.Drawing.Point(583, 129);
			this.comboBoxSlideVertOrientation.Name = "comboBoxSlideVertOrientation";
			this.comboBoxSlideVertOrientation.Size = new System.Drawing.Size(114, 24);
			this.comboBoxSlideVertOrientation.TabIndex = 5;
			this.comboBoxSlideVertOrientation.SelectedIndexChanged += new System.EventHandler(this.comboBoxSlideVertOrientation_SelectedIndexChanged);
			// 
			// comboBoxSlideHorizOrientation
			// 
			this.comboBoxSlideHorizOrientation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSlideHorizOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSlideHorizOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxSlideHorizOrientation.FormattingEnabled = true;
			this.comboBoxSlideHorizOrientation.Items.AddRange(new object[] {
            "Linksbündig",
            "Zentriert",
            "Rechtsbündig"});
			this.comboBoxSlideHorizOrientation.Location = new System.Drawing.Point(583, 76);
			this.comboBoxSlideHorizOrientation.Name = "comboBoxSlideHorizOrientation";
			this.comboBoxSlideHorizOrientation.Size = new System.Drawing.Size(114, 24);
			this.comboBoxSlideHorizOrientation.TabIndex = 4;
			this.comboBoxSlideHorizOrientation.SelectedIndexChanged += new System.EventHandler(this.comboBoxSlideHorizOrientation_SelectedIndexChanged);
			// 
			// buttonSlideBackground
			// 
			this.buttonSlideBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSlideBackground.Location = new System.Drawing.Point(583, 16);
			this.buttonSlideBackground.Name = "buttonSlideBackground";
			this.buttonSlideBackground.Size = new System.Drawing.Size(114, 23);
			this.buttonSlideBackground.TabIndex = 3;
			this.buttonSlideBackground.Text = "Hintergrundbild...";
			this.buttonSlideBackground.UseVisualStyleBackColor = true;
			// 
			// buttonMoveUp
			// 
			this.buttonMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonMoveUp.Enabled = false;
			this.buttonMoveUp.Location = new System.Drawing.Point(88, 678);
			this.buttonMoveUp.Name = "buttonMoveUp";
			this.buttonMoveUp.Size = new System.Drawing.Size(51, 23);
			this.buttonMoveUp.TabIndex = 16;
			this.buttonMoveUp.Text = "Auf";
			this.buttonMoveUp.UseVisualStyleBackColor = true;
			this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
			// 
			// buttonMoveDown
			// 
			this.buttonMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonMoveDown.Enabled = false;
			this.buttonMoveDown.Location = new System.Drawing.Point(145, 678);
			this.buttonMoveDown.Name = "buttonMoveDown";
			this.buttonMoveDown.Size = new System.Drawing.Size(43, 23);
			this.buttonMoveDown.TabIndex = 17;
			this.buttonMoveDown.Text = "Ab";
			this.buttonMoveDown.UseVisualStyleBackColor = true;
			this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
			// 
			// EditorChild
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(992, 710);
			this.Controls.Add(this.buttonMoveDown);
			this.Controls.Add(this.buttonMoveUp);
			this.Controls.Add(this.tabControlEditor);
			this.Controls.Add(this.buttonDelItem);
			this.Controls.Add(this.buttonAddItem);
			this.Controls.Add(this.treeViewContents);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "EditorChild";
			this.ShowInTaskbar = false;
			this.Text = "Liededitor";
			this.Load += new System.EventHandler(this.EditorChild_Load);
			this.Resize += new System.EventHandler(this.EditorChild_Resize);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
			this.groupBoxSongSettings.ResumeLayout(false);
			this.groupBoxSongSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontTranslationColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFontColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarLineSpacing)).EndInit();
			this.groupBoxNewSongPart.ResumeLayout(false);
			this.groupBoxNewSongPart.PerformLayout();
			this.groupBoxSongPart.ResumeLayout(false);
			this.groupBoxSongPart.PerformLayout();
			this.groupBoxNewSlide.ResumeLayout(false);
			this.tabControlEditor.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewContents;
        private System.Windows.Forms.TextBox textBoxSongText;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.TextBox textBoxSongTitle;
        private System.Windows.Forms.Label labelSongTitle;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.GroupBox groupBoxSongSettings;
        private System.Windows.Forms.GroupBox groupBoxNewSongPart;
        private System.Windows.Forms.Label labelNewSongPart;
        private System.Windows.Forms.Button buttonNewSongPart;
        private System.Windows.Forms.CheckedListBox checkedListBoxTags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.ComboBox comboBoxSongParts;
        private System.Windows.Forms.GroupBox groupBoxSongPart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSongPartCaption;
        private System.Windows.Forms.GroupBox groupBoxNewSlide;
        private System.Windows.Forms.Button buttonAddNewSlide;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Button buttonDelItem;
        private System.Windows.Forms.TabControl tabControlEditor;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxQASpelling;
        private System.Windows.Forms.CheckBox checkBoxQAImages;
        private System.Windows.Forms.CheckBox checkBoxQATranslation;
        private System.Windows.Forms.Button buttonSlideBackground;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSlideVertOrientation;
        private System.Windows.Forms.ComboBox comboBoxSlideHorizOrientation;
        private System.Windows.Forms.CheckBox checkBoxQASegmentation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonProjectionMasterFont;
        private System.Windows.Forms.Label labelLineSpacing;
        private System.Windows.Forms.Button buttonChooseProjectionForeColor;
        private System.Windows.Forms.TrackBar trackBarLineSpacing;
        private System.Windows.Forms.Button buttonTranslationFont;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonTranslationColor;
        private System.Windows.Forms.Label labelFontTranslation;
        private System.Windows.Forms.Label labelFont;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBoxFontTranslationColor;
        private System.Windows.Forms.PictureBox pictureBoxFontColor;
		private System.Windows.Forms.Button buttonSlideSeparate;
		private System.Windows.Forms.Button buttonSlideDuplicate;
		private System.Windows.Forms.Button buttonDelSlide;
		private System.Windows.Forms.Button buttonDelSongPart;
		private System.Windows.Forms.TextBox textBoxSongTranslation;
    }
}