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
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.checkedListBoxTags = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxNewSongPart = new System.Windows.Forms.GroupBox();
            this.comboBoxSongParts = new System.Windows.Forms.ComboBox();
            this.buttonNewSongPart = new System.Windows.Forms.Button();
            this.labelNewSongPart = new System.Windows.Forms.Label();
            this.groupBoxSongPart = new System.Windows.Forms.GroupBox();
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
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxQASpelling = new System.Windows.Forms.CheckBox();
            this.checkBoxQATranslation = new System.Windows.Forms.CheckBox();
            this.checkBoxQAImages = new System.Windows.Forms.CheckBox();
            this.buttonSlideBackground = new System.Windows.Forms.Button();
            this.comboBoxSlideHorizOrientation = new System.Windows.Forms.ComboBox();
            this.comboBoxSlideVertOrientation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.groupBoxSongSettings.SuspendLayout();
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
            this.treeViewContents.Size = new System.Drawing.Size(253, 532);
            this.treeViewContents.TabIndex = 0;
            this.treeViewContents.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewContents_AfterSelect);
            // 
            // textBoxSongText
            // 
            this.textBoxSongText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSongText.Location = new System.Drawing.Point(5, 380);
            this.textBoxSongText.Multiline = true;
            this.textBoxSongText.Name = "textBoxSongText";
            this.textBoxSongText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSongText.Size = new System.Drawing.Size(608, 154);
            this.textBoxSongText.TabIndex = 1;
            this.textBoxSongText.TextChanged += new System.EventHandler(this.textBoxSongText_TextChanged);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(619, 335);
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
            this.textBoxSongTitle.Size = new System.Drawing.Size(496, 26);
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
            this.groupBoxSongSettings.Size = new System.Drawing.Size(607, 454);
            this.groupBoxSongSettings.TabIndex = 8;
            this.groupBoxSongSettings.TabStop = false;
            this.groupBoxSongSettings.Text = "Liedeinstellungen";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(97, 60);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(496, 28);
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
            this.checkedListBoxTags.Size = new System.Drawing.Size(496, 118);
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
            this.groupBoxNewSongPart.Location = new System.Drawing.Point(7, 466);
            this.groupBoxNewSongPart.Name = "groupBoxNewSongPart";
            this.groupBoxNewSongPart.Size = new System.Drawing.Size(606, 71);
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
            this.comboBoxSongParts.Size = new System.Drawing.Size(303, 28);
            this.comboBoxSongParts.TabIndex = 11;
            // 
            // buttonNewSongPart
            // 
            this.buttonNewSongPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewSongPart.Location = new System.Drawing.Point(427, 25);
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
            this.groupBoxSongPart.Controls.Add(this.label3);
            this.groupBoxSongPart.Controls.Add(this.textBoxSongPartCaption);
            this.groupBoxSongPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSongPart.Location = new System.Drawing.Point(6, 6);
            this.groupBoxSongPart.Name = "groupBoxSongPart";
            this.groupBoxSongPart.Size = new System.Drawing.Size(607, 69);
            this.groupBoxSongPart.TabIndex = 10;
            this.groupBoxSongPart.TabStop = false;
            this.groupBoxSongPart.Text = "Liedteil-Einstellungen";
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
            this.textBoxSongPartCaption.Size = new System.Drawing.Size(473, 26);
            this.textBoxSongPartCaption.TabIndex = 4;
            this.textBoxSongPartCaption.TextChanged += new System.EventHandler(this.textBoxSongPartCaption_TextChanged);
            // 
            // groupBoxNewSlide
            // 
            this.groupBoxNewSlide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxNewSlide.Controls.Add(this.buttonAddNewSlide);
            this.groupBoxNewSlide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNewSlide.Location = new System.Drawing.Point(6, 81);
            this.groupBoxNewSlide.Name = "groupBoxNewSlide";
            this.groupBoxNewSlide.Size = new System.Drawing.Size(607, 70);
            this.groupBoxNewSlide.TabIndex = 12;
            this.groupBoxNewSlide.TabStop = false;
            this.groupBoxNewSlide.Text = "Neue Folie";
            // 
            // buttonAddNewSlide
            // 
            this.buttonAddNewSlide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddNewSlide.Location = new System.Drawing.Point(12, 25);
            this.buttonAddNewSlide.Name = "buttonAddNewSlide";
            this.buttonAddNewSlide.Size = new System.Drawing.Size(260, 28);
            this.buttonAddNewSlide.TabIndex = 10;
            this.buttonAddNewSlide.Text = "Hinzufügen";
            this.buttonAddNewSlide.UseVisualStyleBackColor = true;
            this.buttonAddNewSlide.Click += new System.EventHandler(this.buttonAddNewSlide_Click);
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddItem.Location = new System.Drawing.Point(4, 543);
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
            this.buttonDelItem.Location = new System.Drawing.Point(194, 543);
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
            this.tabControlEditor.Size = new System.Drawing.Size(627, 570);
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
            this.tabPage1.Size = new System.Drawing.Size(619, 541);
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
            this.tabPage2.Size = new System.Drawing.Size(619, 541);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Liedteil";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
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
            this.tabPage3.Size = new System.Drawing.Size(619, 541);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Folie";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMoveUp.Location = new System.Drawing.Point(88, 543);
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
            this.buttonMoveDown.Location = new System.Drawing.Point(145, 543);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(43, 23);
            this.buttonMoveDown.TabIndex = 17;
            this.buttonMoveDown.Text = "Ab";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            // 
            // textBoxComment
            // 
            this.textBoxComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxComment.Location = new System.Drawing.Point(109, 357);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxComment.Size = new System.Drawing.Size(484, 60);
            this.textBoxComment.TabIndex = 11;
            this.textBoxComment.TextChanged += new System.EventHandler(this.textBoxComment_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Kommentar:";
            // 
            // checkBoxQASpelling
            // 
            this.checkBoxQASpelling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxQASpelling.AutoSize = true;
            this.checkBoxQASpelling.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxQASpelling.Location = new System.Drawing.Point(109, 423);
            this.checkBoxQASpelling.Name = "checkBoxQASpelling";
            this.checkBoxQASpelling.Size = new System.Drawing.Size(136, 20);
            this.checkBoxQASpelling.TabIndex = 13;
            this.checkBoxQASpelling.Text = "Text enthält Fehler";
            this.checkBoxQASpelling.UseVisualStyleBackColor = true;
            this.checkBoxQASpelling.CheckedChanged += new System.EventHandler(this.checkBoxQASpelling_CheckedChanged);
            // 
            // checkBoxQATranslation
            // 
            this.checkBoxQATranslation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxQATranslation.AutoSize = true;
            this.checkBoxQATranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxQATranslation.Location = new System.Drawing.Point(251, 423);
            this.checkBoxQATranslation.Name = "checkBoxQATranslation";
            this.checkBoxQATranslation.Size = new System.Drawing.Size(229, 20);
            this.checkBoxQATranslation.TabIndex = 14;
            this.checkBoxQATranslation.Text = "Übersetzung fehlt/ist unvollständig";
            this.checkBoxQATranslation.UseVisualStyleBackColor = true;
            this.checkBoxQATranslation.CheckedChanged += new System.EventHandler(this.checkBoxQATranslation_CheckedChanged);
            // 
            // checkBoxQAImages
            // 
            this.checkBoxQAImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxQAImages.AutoSize = true;
            this.checkBoxQAImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxQAImages.Location = new System.Drawing.Point(492, 423);
            this.checkBoxQAImages.Name = "checkBoxQAImages";
            this.checkBoxQAImages.Size = new System.Drawing.Size(101, 20);
            this.checkBoxQAImages.TabIndex = 15;
            this.checkBoxQAImages.Text = "Bilder fehlen";
            this.checkBoxQAImages.UseVisualStyleBackColor = true;
            this.checkBoxQAImages.CheckedChanged += new System.EventHandler(this.checkBoxQAImages_CheckedChanged);
            // 
            // buttonSlideBackground
            // 
            this.buttonSlideBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSlideBackground.Location = new System.Drawing.Point(6, 351);
            this.buttonSlideBackground.Name = "buttonSlideBackground";
            this.buttonSlideBackground.Size = new System.Drawing.Size(113, 23);
            this.buttonSlideBackground.TabIndex = 3;
            this.buttonSlideBackground.Text = "Hintergrundbild...";
            this.buttonSlideBackground.UseVisualStyleBackColor = true;
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
            this.comboBoxSlideHorizOrientation.Location = new System.Drawing.Point(253, 351);
            this.comboBoxSlideHorizOrientation.Name = "comboBoxSlideHorizOrientation";
            this.comboBoxSlideHorizOrientation.Size = new System.Drawing.Size(124, 24);
            this.comboBoxSlideHorizOrientation.TabIndex = 4;
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
            this.comboBoxSlideVertOrientation.Location = new System.Drawing.Point(499, 351);
            this.comboBoxSlideVertOrientation.Name = "comboBoxSlideVertOrientation";
            this.comboBoxSlideVertOrientation.Size = new System.Drawing.Size(114, 24);
            this.comboBoxSlideVertOrientation.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Horizontale Ausrichtung:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(383, 356);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Vertikale Ausrichtung:";
            // 
            // EditorChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 575);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.groupBoxSongSettings.ResumeLayout(false);
            this.groupBoxSongSettings.PerformLayout();
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
    }
}